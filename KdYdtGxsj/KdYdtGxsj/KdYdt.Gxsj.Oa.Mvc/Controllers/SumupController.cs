using System.Collections.Generic;
using System.Web.Mvc;

using KdCore;
using KdCore.Data;

using KdYdt.Gxsj.Oa.Domains;
using KdYdt.Gxsj.Oa.Domains.EditModels;
using KdYdt.Gxsj.Oa.Domains.Models;
using KdYdt.Gxsj.Oa.Domains.Reports;

namespace KdYdt.Gxsj.Oa.Mvc.Controllers
{
    /// <summary>
    /// 工作日志总结
    /// </summary>
    [KdUnitGroup("工作日志总结", 80, true)]
    public class SumupController : KdBaseOaController
    {
        protected SelectListItem CreateTabItem(BbCycleDate select, BbCycleDate item, string actionName = "Index")
        {
            return new SelectListItem
            {
                Text = item.GetSumupTypeName(),
                Value = this.Url.Action(actionName, new { id = item }),
                Selected = select == item
            };
        }

        protected virtual IList<SelectListItem> BuildTabHeader(BbCycleDate period, string actionName = "Index")
        {
            this.ViewBag.Period = period;
            this.ViewBag.PageTitle = period.GetSumupTypeName();

            List<SelectListItem> headers = new List<SelectListItem>
            {
                this.CreateTabItem(period, BbCycleDate.Day,actionName),
                this.CreateTabItem(period, BbCycleDate.Week,actionName),
                this.CreateTabItem(period, BbCycleDate.Month,actionName),
                this.CreateTabItem(period, BbCycleDate.Year,actionName)
            };
            this.SetTabHeaders(headers);
            return headers;
        }

        [KdAction("查阅")]
        public ActionResult Index(string id)
        {
            BbCycleDate period = id.ToEnum(BbCycleDate.Day);
            BuildTabHeader(period);
            return this.DataListView<OaUserSumup>(x => x.SumupPeriod == period);
        }

        [KdAction("编辑", ViewCodes = "Index")]
        [HttpGet]
        public ActionResult Edit(string id, string period)
        {
            BbCycleDate sumupPeriod = period.ToEnum(BbCycleDate.Day);
            OaUserSumup entity = this.DbService.GetUserSumup(id, sumupPeriod);
            if (entity == null)//没有数据时判断是否跳转到新增，或者是新增模式直接初始化数据
            {
                if (string.IsNullOrWhiteSpace(id))
                {  //新增模式
                    entity = this.DbService.CreateUserSumup(sumupPeriod);
                    return this.DataEntityView(entity);
                }
                else
                {
                    return this.RedirectToAction("Edit", new { id = string.Empty, period });
                }
            }
            else if (entity.Id != id)
            {
                //如果是访问的新增，但已存在当前数据，进行跳转，避免页面路径不正导致其他的错误
                return this.RedirectToAction("Edit", new { id = entity.Id, period });
            }

            //验证当前主体数据的权限
            this.AuthEntityCurrent(entity);
            //非本人或已提交的强制不允许再进行编辑
            entity.SetAuthMode(entity.CreatorUserId == this.CurrUserId && !entity.IsReported);
            return this.DataEntityView(entity);
        }

        [KdAction("编辑")]
        [HttpPost]
        public ActionResult Edit(OaSumupEdit edit, bool isReported)
        {
            KdDataResult result = this.CheckModelState<OaUserSumup, OaSumupEdit>(edit);
            if (result.Success)
                result = this.DbService.SaveResult(edit, isReported);
            return this.RedirectResult<OaUserSumup>(result);
        }

        [KdAction("删除")]
        [HttpPost]
        public virtual ActionResult Delete(string[] ids)
        {
            //只能删除尚未提交和本人的数据
            KdDataResult result = this.DbService.DeleteResult<OaUserSumup>(x => !x.IsReported && x.CreatorUserId == this.CurrUserId, ids);
            return this.JsonResult(result);
        }

        [KdAction("强制删除")]
        [HttpPost]
        public virtual ActionResult DeleteEnforce(string[] ids)
        {
            return this.JsonDelete<OaUserSumup>(ids);
        }

        [KdAction("审批")]
        public virtual ActionResult Review(string id)
        {
            return this.DataEntityView<OaSumupReview>(id);
        }

        [KdAction("审批")]
        [HttpPost]
        public ActionResult Review(string id, string reviewResult)
        {
            KdDataResult result = this.DbService.ReviewUserSumup(id, reviewResult);
            return this.JsonResult(result);
        }

        [KdAction("统计")]
        public ActionResult Report(string id)
        {
            BbCycleDate period = id.ToEnum(BbCycleDate.Day);
            BuildTabHeader(period, "Report");

            OaSumupReport report = this.InitDataReport<OaSumupReport>();
            if (period == BbCycleDate.None || period >= BbCycleDate.Day)
                period = BbCycleDate.Day;
            report.SumupPeriod = period;

            this.DbService.GetSumpReport(report, 0);

            this.PageTitle = report.ReportTitle;
            return this.KdView(report);
        }
    }
}
