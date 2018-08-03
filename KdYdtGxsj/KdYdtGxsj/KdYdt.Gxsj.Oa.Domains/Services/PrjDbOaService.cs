using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Transactions;

using KdCore;
using KdCore.Data;
using KdCore.Data.DbServices;
using KdCore.Data.EntityFramework;
using KdCore.Data.Tasks;
using KdCore.Data.Users;
using KdCore.Office;

using KdYdt.Gxsj.Oa.Domains.EditModels;
using KdYdt.Gxsj.Oa.Domains.Models;
using KdYdt.Gxsj.Oa.Domains.Reports;
using KdYdt.Gxsj.Oa.Domains.ViewModels;

using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace KdYdt.Gxsj.Oa.Domains.Services
{
    public class PrjDbOaService : KdDbService<PrjDbOaContext>
    {
        #region 通知公告
        /// <summary>
        /// 保存通知公告
        /// </summary>
        /// <param name="editModel">通知公告</param> 
        /// <returns>保存结果</returns>
        public virtual KdDataResult SaveNotice(OaNoticeEdit editModel, IKdTaskOption taskOption)
        {
            KdDataResult result;
            using (TransactionScope trans = new TransactionScope())
            {
                OaNotice notice = this.GetForSave<OaNotice, OaNoticeEdit>(editModel);
                this.Save(notice);
                string[] deptIds = notice.NoticeDeptIds.Splits();
                KdDbAuthsService service = this.UserProvider as KdDbAuthsService;
                List<KdUser> users = service.GetValidKdUsers(x => deptIds.Contains(x.OwnerDeptId));
                this.TaskProvider.UpdateSourceTasks(notice, taskOption, users);
                result = this.SaveChangesResult(notice, editModel);
                trans.Complete();
            }
            return result;
        }
        /// <summary>
        /// 删除通知公告
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public virtual KdDataResult DeleteNotice(params string[] ids)
        {
            KdDataResult result;
            using (TransactionScope trans = new TransactionScope())
            {
                List<OaNotice> deleteList = this.DeleteRange<OaNotice>(ids);
                this.TaskProvider.DeleteTaskBySources(ids);
                result = this.SaveChangesResult(deleteList, ids);
                trans.Complete();
            }
            return result;
        }
        #endregion

        #region 用户工作计划安排
        protected virtual List<OaWorkPlan> GetWorkPlans(IKdUser user, DateTime start, DateTime end)
        {
            user = user ?? this.CurrUser;
            start = start.Date;
            end = end.Date.AddDays(1).AddMilliseconds(-1);
            return this.ValidQuery<OaWorkPlan>(x => x.CreatorUserId == user.Id
            && (x.PlanDate >= start && x.PlanDate <= end))
                .OrderBy(x => x.PlanDate)
                .ThenBy(x => x.StartTime)
                .ThenBy(x => x.IsCompleted)
                .ToList();
        }

        /// <summary>
        /// 获取用户的一周的工作计划安排
        /// </summary>
        /// <param name="user"></param>
        /// <param name="weekIndex"></param>
        /// <returns></returns>
        public virtual OaWorkPlanWeek GetWorkPlanWeek(IKdUser user, int? weekIndex)
        {
            OaWorkPlanWeek week = new OaWorkPlanWeek(weekIndex);
            week.WorkPlans = this.GetWorkPlans(user, week.DateStart, week.DateEnd);
            return week;
        }

        /// <summary>
        /// 保存用户的一周的工作计划安排
        /// </summary>
        /// <param name="weekIndex"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public OaWorkPlanWeek SaveWorkPlan(int? weekIndex, NameValueCollection form)
        {
            IKdUser user = this.CurrUser;
            OaWorkPlanWeek week = new OaWorkPlanWeek(weekIndex ?? 0);
            week.WorkPlans = this.GetWorkPlans(this.CurrUser, week.DateStart, week.DateEnd);
            if (week.IsSubmitted)
                return week;

            OaWorkPlan item;
            char[] sp = { '_' };
            foreach (string itemKey in form.Keys)
            {
                string[] keys = itemKey.Split(sp, StringSplitOptions.RemoveEmptyEntries);
                if (keys.IsEmpty() || keys.Length != 3) { continue; }

                DateTime date;
                if (!DateTime.TryParse(keys[1], out date)) { continue; }
                date = date.AddHours(keys[2].ToInt(9));

                item = week.WorkPlans.FirstOrDefault(x => x.PlanDate.Date == date.Date && x.StartTime == date.TimeOfDay);
                if (item == null)
                {
                    item = new OaWorkPlan { PlanSummary = form[itemKey] };
                    if (string.IsNullOrWhiteSpace(item.PlanSummary))
                        continue;

                    item.PlanDate = date.Date;
                    item.StartTime = date.TimeOfDay;
                    item.EndTime = item.StartTime.Add(TimeSpan.FromHours(3));
                    week.WorkPlans.Add(item);
                    item.SetId();
                    user.MarkModifier(item);
                    this.Add(item);
                }
                else
                {
                    item.PlanSummary = form[itemKey];
                    item.TagDeleted = string.IsNullOrWhiteSpace(item.PlanSummary);
                    user.MarkModifier(item);
                    this.Update(item);
                }
            }

            this.SaveChanges();

            return week;
        }

        /// <summary>
        /// 提交用户的一周的工作计划安排
        /// </summary>
        /// <param name="weekIndex"></param>
        /// <returns></returns>
        public OaWorkPlanWeek SubmitWorkPlan(int? weekIndex)
        {
            OaWorkPlanWeek week = new OaWorkPlanWeek(weekIndex ?? 0);
            week.WorkPlans = this.GetWorkPlans(this.CurrUser, week.DateStart, week.DateEnd);
            if (week.IsSubmitted)
                return week;

            foreach (OaWorkPlan item in week.WorkPlans)
            {
                item.IsCompleted = true;
                item.CompleteTime = DateTime.Now;
                item.CompleteStatus = string.Format("由{0}于{1:yyyy-MM-dd HH:mm}提交", this.CurrUser.UserTitle, item.CompleteTime);
                this.Update(item);
            }
            this.SaveChanges();
            return week;
        }
        #endregion

        #region 用户工作计划安排 统计

        public OaWorkPlanReport ReportWorkPlan(OaWorkPlanReport report, string rangeIndex)
        {
            report.InitDateRange(rangeIndex.ToInt());

            List<KdUser> users = report.Users = this.GetService<KdDbAuthsService>().GetValidKdUsers();
            List<string> userIds = users.Select(x => x.Id).ToList();

            IQueryable<OaWorkPlan> queryable = this.ValidQuery<OaWorkPlan>(x => x.IsCompleted);
            DateTime start = report.DateRange.DateStart;
            DateTime end = report.DateRange.DateEnd.AddDays(1);
            queryable = queryable.Where(x => x.PlanDate >= start && x.PlanDate < end)
                .Where(x => userIds.Contains(x.CreatorUserId));

            List<OaWorkPlan> list = queryable.ToList();
            list = list.Where(x => userIds.Contains(x.CreatorUserId)).SortByCreator(users);
            report.DataResponse = list.ToResponse();

            report.ReportTitle = "一周工作计划安排汇总";
            report.FileName = string.Format("一周工作计划安排汇总{0}.xls", report.DateRange.RangeTitle);
            IWorkbook book = KdUtilExcel.GetWorkbookFromFile(report.TemplatePath);
            if (book != null)
            {
                WriteDataToBook(book, report);
                if (report.OutputStream != null)
                    book.Write(report.OutputStream);
                else
                    book.SaveToFile(report.OutputPath);
            }
            return report;
        }

        /// <summary>
        /// 科室一周工作计划安排Excle取值
        /// </summary>
        /// <param name="book"></param>
        /// <param name="report"></param>
        protected void WriteDataToBook(IWorkbook book, OaWorkPlanReport report)
        {
            ISheet sheet = book.GetSheetAt(0);
            ICell cellTitle = sheet.GetCell(0, 0);
            ICell cellDate = sheet.SetCellValue(1, 0, report.DateRange.RangeTitle);
            sheet.SetCellValue(3, 0, string.Format("汇总人：{0}", report.ReporterName));

            DateTime currDate = report.DateRange.DateStart;
            int dayCount = (report.DateRange.DateEnd - report.DateRange.DateStart).Days;
            sheet.MergedCells(0, 0, 0, dayCount + 1, false);
            sheet.MergedCells(1, 0, 1, dayCount + 1, false);

            cellTitle.CellStyle.Alignment = HorizontalAlignment.Center;
            cellDate.CellStyle.Alignment = HorizontalAlignment.Center;

            IRow row = sheet.GetRow(4);
            row.MoveCell(row.GetCell(2), dayCount + 2);
            ICellStyle cellDate1 = (sheet.GetCell(4, 1)).CellStyle;
            ICellStyle cellDate2 = (sheet.GetCell(5, 1)).CellStyle;

            cellDate1.BorderLeft = cellDate1.BorderRight = BorderStyle.Thin;
            cellDate1.BorderTop = BorderStyle.Thin;
            cellDate1.BorderBottom = BorderStyle.None;

            cellDate2.BorderLeft = cellDate2.BorderRight = BorderStyle.Thin;
            cellDate2.BorderTop = BorderStyle.None;
            cellDate2.BorderBottom = BorderStyle.Thin;

            int colIndex = 1;
            int dayWidth = sheet.GetColumnWidth(1);
            while (currDate <= report.DateRange.DateEnd)
            {
                sheet.SetColumnWidth(colIndex, dayWidth);
                ICell cell1 = sheet.SetCellValue(4, colIndex, currDate.ToString("dddd"));
                cell1.CellStyle = cellDate1;
                ICell cell2 = sheet.SetCellValue(5, colIndex, currDate.ToString("(M月d日)"));
                cell2.CellStyle = cellDate2;

                colIndex++;
                currDate = currDate.AddDays(1);
            }

            int rowIndex = 6;
            ICell cellUser = sheet.GetCell(rowIndex, 0);

            ICellStyle cellDay1 = (sheet.GetCell(rowIndex, 1)).CellStyle;
            ICellStyle cellDay2 = (sheet.GetCell(rowIndex + 1, 1)).CellStyle;

            cellDay1.BorderLeft = BorderStyle.Thin;
            cellDay1.BorderRight = BorderStyle.Thin;
            cellDay1.BorderTop = BorderStyle.Thin;
            cellDay1.BorderBottom = BorderStyle.None;

            cellDay2.BorderLeft = BorderStyle.Thin;
            cellDay2.BorderRight = BorderStyle.Thin;
            cellDay2.BorderTop = BorderStyle.None;
            cellDay2.BorderBottom = BorderStyle.Thin;

            short height = sheet.GetRow(rowIndex).Height;

            foreach (KdUser user in report.Users)
            {
                CellRangeAddress range = sheet.MergedCells(rowIndex, 0, rowIndex + 1, 0);

                currDate = report.DateRange.DateStart;
                colIndex = 1;
                IRow amRow = sheet.GetRow(rowIndex) ?? sheet.CopyRow(rowIndex - 2, rowIndex);
                IRow pmRow = sheet.GetRow(rowIndex + 1) ?? sheet.CopyRow(rowIndex - 1, rowIndex + 1);
                amRow.Height = pmRow.Height = height;
                ICell cell = amRow.GetCell(0);
                cell.CellStyle = cellUser.CellStyle;
                cell.SetCellValue(string.Format("{0}({1}{2})", user.RealName, user.OwnerDeptName, user.DutyName));

                List<OaWorkPlan> plans = report.DataResponse.Where(x => x.CreatorUserId == user.Id)
                    .OrderBy(x => x.CreatorUserName)
                    .ThenBy(x => x.PlanDate)
                    .ThenBy(x => x.StartTime)
                    .ToList();
                ICell cell1;
                ICell cell2;
                if (plans.IsEmpty())
                {
                    while (currDate <= report.DateRange.DateEnd)
                    {
                        #region 填写一天的数据  
                        cell1 = amRow.GetCell(colIndex) ?? amRow.CopyCell(colIndex - 1, colIndex);
                        cell2 = pmRow.GetCell(colIndex) ?? pmRow.CopyCell(colIndex - 1, colIndex);
                        cell1.SetCellValue("上午：");
                        cell2.SetCellValue("下午：");
                        cell1.CellStyle = cellDay1;
                        cell2.CellStyle = cellDay2;
                        #endregion

                        colIndex++;
                        currDate = currDate.AddDays(1);
                    }
                }
                else
                {
                    foreach (OaWorkPlan plan in plans)
                    {
                        while (currDate <= report.DateRange.DateEnd)
                        {
                            #region 填写一天的数据 
                            List<OaWorkPlan> dayPlans = plans.Where(x => x.PlanDate.Date == currDate.Date).ToList();
                            List<string> amPlans = dayPlans.Where(x => x.StartTime.Hours < 12)
                                .Select(x => x.PlanSummary).ToList();
                            List<string> pmPlans = dayPlans.Where(x => x.StartTime.Hours >= 12)
                                .Select(x => x.PlanSummary).ToList();
                            cell1 = amRow.GetCell(colIndex) ?? amRow.CopyCell(colIndex - 1, colIndex);
                            cell2 = pmRow.GetCell(colIndex) ?? pmRow.CopyCell(colIndex - 1, colIndex);
                            cell1.SetCellValue("上午：" + amPlans.ToJoin("；"));
                            cell2.SetCellValue("下午：" + pmPlans.ToJoin("；"));
                            cell1.CellStyle = cellDay1;
                            cell2.CellStyle = cellDay2;
                            #endregion

                            colIndex++;
                            currDate = currDate.AddDays(1);
                        }
                    }
                }
                rowIndex += 2;
            }
        }
        #endregion

        #region 用户工作总结 
        /// <summary>
        /// 获取用户已填写的工作总结
        /// </summary>
        /// <param name="id"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public virtual OaUserSumup CreateUserSumup(BbCycleDate period)
        {
            if (period == BbCycleDate.None)
                period = BbCycleDate.Day;

            OaUserSumup entity = new OaUserSumup();
            entity.SetId();
            entity.SaveMode = BbSaveMode.Insert;
            this.CurrUser.MarkCreator(entity);

            entity.SumupPeriod = period;
            entity.SumupType = period.GetSumupTypeName();

            switch (period)
            {
                case BbCycleDate.Year:
                    entity.StartDate = DateTime.Today.GetYearStart();
                    entity.EndDate = DateTime.Today.GetYearEnd();
                    break;
                case BbCycleDate.Month:
                    entity.StartDate = DateTime.Today.GetMonthStart();
                    entity.EndDate = DateTime.Today.GetMonthEnd();
                    break;
                case BbCycleDate.Week:
                    entity.StartDate = DateTime.Today.GetWeekStart();
                    entity.EndDate = DateTime.Today.GetWeekEnd();
                    break;
                default:
                    entity.StartDate = DateTime.Today;
                    entity.EndDate = DateTime.Today;
                    break;
            }

            return entity;
        }

        /// <summary>
        /// 获取用户已填写的工作总结
        /// </summary>
        /// <param name="id"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public virtual OaUserSumup GetUserSumup(string id, BbCycleDate period)
        {
            if (period == BbCycleDate.None)
                period = BbCycleDate.Day;
            OaUserSumup entity = this.Get<OaUserSumup>(id);
            if (entity == null && string.IsNullOrWhiteSpace(id))
                entity = this.Query<OaUserSumup>(x => x.SumupPeriod == period && x.StartDate == DateTime.Today).FirstOrDefault();
            if (entity == null || entity.SumupPeriod != period)
                return null;

            //已提交的加载审批记录
            if (entity.IsReported)
                entity.Reviews = this.ValidQuery<OaSumupReview>(x => x.SumupId == entity.Id)
                    .OrderBy(x => x.CreateTime)
                    .ToList();

            return entity;
        }

        /// <summary>
        /// 保存用户工作总结
        /// </summary>
        /// <param name="edit"></param>
        /// <returns></returns>
        public virtual KdDataResult SaveResult(OaSumupEdit edit, bool isReport)
        {
            OaUserSumup entity = this.GetForSave<OaUserSumup, OaSumupEdit>(edit);
            KdDataResult result = KdDataResult.Create(edit, entity);
            if (entity.IsExistData())
            {
                if (entity.IsReported)
                    return result.SetError("已提交数据不能再进行修改编辑");
                if (entity.CreatorUserId != this.CurrUser.Id)
                    return result.SetError("不允许编辑他人的工作总结数据");
            }

            entity.SumupType = entity.SumupPeriod.GetSumupTypeName();
            entity.IsReported = isReport;
            entity.StartDate = entity.StartDate.Date;
            if (entity.SumupPeriod == BbCycleDate.Day)
                entity.EndDate = entity.StartDate;
            entity.IsDelayed = entity.EndDate.Date < DateTime.Today;
            return this.SaveResult(entity, edit);
        }

        /// <summary>
        /// 工作总结审批
        /// </summary>
        /// <param name="edit"></param>
        /// <returns></returns>
        public virtual KdDataResult ReviewUserSumup(string id, string reviewResult)
        {
            OaUserSumup sumup = this.Get<OaUserSumup>(id);
            sumup.IsReviewed = true;
            this.DbUpdate(sumup);

            OaSumupReview entity = new OaSumupReview();
            entity.SetId();
            entity.SumupId = id;
            entity.ReviewResult = reviewResult;
            this.Add(entity);

            return this.SaveChangesResult(entity, sumup);
        }
        #endregion

        #region 用户工作总结 统计

        /// <summary>
        /// 用户工作总结 统计
        /// </summary>
        /// <param name="report"></param>
        /// <param name="period"></param>
        /// <param name="rangeIndex"></param>
        /// <returns></returns>
        public virtual OaSumupReport GetSumpReport(OaSumupReport report, int? rangeIndex)
        {
            report.InitDateRange(rangeIndex ?? 0, report.SumupPeriod);
            report.ReportTitle = string.Format("{0} {1}统计", report.Start.ToDateString(report.End), report.SumupPeriod.GetSumupTypeName());

            DateTime sumupEnd = report.End.Value.Date.AddDays(1);
            DateTime reviewEnd;
            switch (report.SumupPeriod)
            {
                case BbCycleDate.Year:
                case BbCycleDate.Month:
                case BbCycleDate.Week:
                    reviewEnd = sumupEnd.AddMonths(1);
                    break;
                default:
                    reviewEnd = sumupEnd.AddDays(7);
                    break;
            }

            #region 查询待统计数据
            List<OaUserSumup> sumups = this.Query<OaUserSumup>(x
                => x.SumupPeriod == report.SumupPeriod
                && x.CreateTime >= report.Start
                && x.CreateTime < sumupEnd)
                .ToList();
            List<OaSumupReview> reviews = this.Query<OaSumupReview>(x
                => x.CreateTime >= report.Start
                && x.CreateTime < reviewEnd)
                .ToList();
            List<string> sumupIds = sumups.Select(x => x.Id).ToList();
            reviews = reviews.Where(x => sumupIds.Contains(x.SumupId)).ToList();
            #endregion

            #region 统计日志提交及审批数据
            List<OaSumupReportItem> items = new List<OaSumupReportItem>();
            List<KdUser> users = this.GetService<KdDbAuthsService>().GetValidKdUsers();
            OaSumupReportItem item;
            foreach (KdUser user in users)
            {
                item = new OaSumupReportItem
                {
                    Id = user.Id,
                    DeptName = user.OwnerDeptName,
                    RealName = user.UserTitle,
                    CountSubmitted = sumups.Count(x => x.CreatorUserId == user.Id),
                    CountDelayed = sumups.Count(x => x.IsDelayed && x.CreatorUserId == user.Id)
                };

                //查询用户可审批的数量
                string[] deptIds = user.GetAllowDeptIds();
                string[] dutyIds = user.GetAllowDeptIds();
                if (deptIds.NotEmpty() && dutyIds.NotEmpty())
                {
                    item.CountReview = sumups.Count(x
                        => x.CreatorUserId != user.Id
                        && deptIds.Contains(x.CreatorDeptId)
                        && dutyIds.Contains(x.CreatorDutyId));
                }

                item.CountReviewed = reviews
                    .Where(x => x.CreatorUserId == user.Id)
                    .Select(x => x.SumupId)
                    .Distinct()
                    .Count();
                items.Add(item);
            }
            #endregion 
            report.DataResponse = items.ToResponse();

            return report;
        }
        #endregion
    }
}
