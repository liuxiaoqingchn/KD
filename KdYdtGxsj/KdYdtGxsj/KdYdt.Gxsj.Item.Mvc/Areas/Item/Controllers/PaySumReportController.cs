using KdCore;
using KdYdt.Gxsj.Item.Domains.Assist;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 费用汇总
    /// </summary>
    [KdUnitGroup("费用汇总", 190, true)]
    public class PaySumReportController : ItemBaseController
    {

        [KdAction("查阅")]
        public virtual ActionResult Index(int? paySumType, FormCollection form, DateTime? kpq_RelDate, DateTime? kpq_RelDate_2)
        {
            paySumType = !paySumType.HasValue ? 1 : paySumType.Value;
            ViewBag.EnumPaySumType = paySumType;
            EnumPaySum enumPaySum = (EnumPaySum)paySumType;
            BdTabHeader(enumPaySum);
            #region 
            string a = form["kpq_RelDate"];
            string b = form["kpq_RelDate_2"];
            if ( a== null && b == null)
            {
                int year = DateTime.Now.Year;//当前年  
                int mouth = DateTime.Now.Month;//当前月  

                int beforeYear = 0;
                int beforeMouth = 0;
                if (mouth <= 1)//如果当前月是一月，那么年份就要减1  
                {
                    beforeYear = year - 1;
                    beforeMouth = 12;//上个月  
                }
                else
                {
                    beforeYear = year;
                    beforeMouth = mouth - 1;//上个月  
                }
                DateTime? beforeMouthOneDay = Convert.ToDateTime(beforeYear + "年" + beforeMouth + "月" + 1 + "日");
                DateTime? beforeMouthLastDay = Convert.ToDateTime(beforeYear + "年" + beforeMouth + "月" + DateTime.DaysInMonth(year, beforeMouth) + "日");
                return (enumPaySum == EnumPaySum.支出汇总) ?
              GetPaySpendView(beforeMouthOneDay, beforeMouthLastDay) : GetPayIncomeView(beforeMouthOneDay, beforeMouthLastDay);
            }
            #endregion
            else
            {
                return (enumPaySum == EnumPaySum.支出汇总) ?
                         GetPaySpendView(kpq_RelDate, kpq_RelDate_2) : GetPayIncomeView(kpq_RelDate, kpq_RelDate_2);
            }
        }
        /// <summary>
        /// 收入汇总
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        private ActionResult GetPayIncomeView(DateTime? startDate, DateTime? endDate)
        {
            var querys2 = this.DbService.ValidQuery<PayIncome>(x => x.HandlingData != null);
            if (startDate.HasValue)
            {
                DateTime atime = startDate.Value;
                querys2 = querys2.Where(x => x.HandlingData >= atime);
            }
            if (endDate.HasValue)
            {
                DateTime btime = endDate.Value;
                querys2 = querys2.Where(x => x.HandlingData <= btime);
            }
            List<PaySumReport> model = new List<PaySumReport>();
            PaySumReport entity = null;
            IEnumerable<IGrouping<string, PayIncome>> iogroups2 = querys2.GroupBy(x => x.PrjName);
            foreach (IGrouping<string, PayIncome> item2 in iogroups2)
            {
                var prjs2 = item2.ToList();
                PayIncome temp2 = item2.FirstOrDefault();
                entity = new PaySumReport();
                entity.Prj = temp2.PrjName;
                entity.BSInc = prjs2.Sum(x => x.BusinessCost) + prjs2.Sum(x => x.TechniqueCost);
                entity.ManageInc = prjs2.Sum(x => x.ManagerCost);
                entity.MaterialInc = prjs2.Sum(x => x.DataCost);
                entity.AdminInc = prjs2.Sum(x => x.Management);
                entity.PrjExpInc = prjs2.Sum(x => x.ExpectedProfit);
                entity.OtherInc = prjs2.Sum(x => x.OthersCost);
                entity.BidSumInc = prjs2.Sum(x => x.BusinessCost) + prjs2.Sum(x => x.TechniqueCost) + prjs2.Sum(x => x.ManagerCost)
               + prjs2.Sum(x => x.DataCost) + prjs2.Sum(x => x.Management) + prjs2.Sum(x => x.ExpectedProfit) + prjs2.Sum(x => x.OthersCost);
                model.Add(entity);
            }
            entity = new PaySumReport
            {
                Prj = "总计",
                BSInc = model.Sum(x => x.BSInc),
                ManageInc = model.Sum(x => x.ManageInc),
                MaterialInc = model.Sum(x => x.MaterialInc),
                AdminInc = model.Sum(x => x.AdminInc),
                PrjExpInc = model.Sum(x => x.PrjExpInc),
                OtherInc = model.Sum(x => x.OtherInc),
                BidSumInc = model.Sum(x => x.BidSumInc),

            };
            model.Add(entity);
            return this.KdView(model);
        }
        /// <summary>
        /// 支出汇总
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        private ActionResult GetPaySpendView(DateTime? startDate, DateTime? endDate)
        {
            var querys = this.DbService.ValidQuery<PaySpend>(x => x.HandlingData != null);
            if (startDate.HasValue)
            {
                DateTime atime = startDate.Value;
                querys = querys.Where(x => x.HandlingData >= atime);
            }
            if (endDate.HasValue)
            {
                DateTime btime = endDate.Value;
                querys = querys.Where(x => x.HandlingData <= btime);
            }
            List<PaySumReport> model = new List<PaySumReport>();
            IEnumerable<IGrouping<string, PaySpend>> iogroups = querys.GroupBy(x => x.PrjName);
            PaySumReport entity = null;
            foreach (IGrouping<string, PaySpend> item in iogroups)
            {
                var prjs = item.ToList();
                PaySpend temp = item.FirstOrDefault();
                entity = new PaySumReport();
                entity.Prj = temp.PrjName;
                entity.BSfee = prjs.Sum(x => x.BusinessCost) + prjs.Sum(x => x.TechniqueCost) + prjs.Sum(x => x.PaperCost);
                entity.Bondfee = prjs.Sum(x => x.LetterCost) + prjs.Sum(x => x.MarginCost);
                entity.Managefee = prjs.Sum(x => x.ManagerCost);
                entity.Materialfee = prjs.Sum(x => x.DataCost);
                entity.Samplefee = prjs.Sum(x => x.ElectronCost);
                entity.Bidfee = prjs.Sum(x => x.AgentCost);
                entity.Travelfee = prjs.Sum(x => x.FoodCost);
                entity.Otherfee = prjs.Sum(x => x.OthersCost);
                entity.BidSumfee = prjs.Sum(x => x.OthersCost) + prjs.Sum(x => x.FoodCost) + prjs.Sum(x => x.AgentCost)
                    + prjs.Sum(x => x.ElectronCost) + prjs.Sum(x => x.DataCost) + prjs.Sum(x => x.ManagerCost) + prjs.Sum(x => x.LetterCost)
                    + prjs.Sum(x => x.MarginCost) + prjs.Sum(x => x.BusinessCost) + prjs.Sum(x => x.TechniqueCost) + prjs.Sum(x => x.PaperCost);
                model.Add(entity);
            }
            entity = new PaySumReport
            {
                Prj = "总计",
                BSfee = model.Sum(x => x.BSfee),
                Bondfee = model.Sum(x => x.Bondfee),
                Managefee = model.Sum(x => x.Managefee),
                Materialfee = model.Sum(x => x.Materialfee),
                Samplefee = model.Sum(x => x.Samplefee),
                Bidfee = model.Sum(x => x.Bidfee),
                Travelfee = model.Sum(x => x.Travelfee),
                Otherfee = model.Sum(x => x.Otherfee),
                BidSumfee = model.Sum(x => x.BidSumfee),
            };
            model.Add(entity);
            return this.KdView(model);
        }
    }
}
