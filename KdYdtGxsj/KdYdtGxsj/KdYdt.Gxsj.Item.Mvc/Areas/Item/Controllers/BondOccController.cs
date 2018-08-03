using KdCore;
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
    /// 保证金占用
    /// </summary>
    [KdUnitGroup("保证金占用", 190, true)]
    public class BondOccController : ItemBaseController
    {
        [KdAction("保证金占用")]
        public virtual ActionResult Index(FormCollection form)
        {
            BondOccReport view = new BondOccReport();
            List<int> months = new List<int>();//月份 
            string startDateStr = form["kpq_RelDate"];
            string endDateStr = form["kpq_RelDate_2"];
            DateTime date = DateTime.Now;
            if (string.IsNullOrWhiteSpace(startDateStr) ||
                string.IsNullOrWhiteSpace(endDateStr))
            {
                MonthsItem(view, date.AddMonths(-12), date);
                return KdView(view);
            }
            else
            {
                DateTime beginDate = date, endDate = date;
                if (!string.IsNullOrWhiteSpace(startDateStr))
                    beginDate = startDateStr.ToDateTime();
                if (!string.IsNullOrWhiteSpace(endDateStr))
                    endDate = endDateStr.ToDateTime();
                if (beginDate > date)
                {
                    this.ViewData.MsgError("起始日期超出现有时间，请重新输入");
                    return KdView(view);
                }
                if (endDate > date)
                {
                    this.ViewData.MsgError("截止日期超出现有时间，请重新输入");
                    return KdView(view);
                }
                MonthsItem(view, beginDate, endDate);
            }

            return this.KdView(view);
        }
        public void MonthsItem(BondOccReport view, DateTime startDate, DateTime endDate)
        {
            view = new BondOccReport();
            IQueryable<PrjBond> prjbond = this.DbService.ValidQuery<PrjBond>(x => x.TaskTime.HasValue
         && x.TaskTime >= startDate
         && x.TaskTime <= endDate
         && x.IsBond == true);

            List<decimal> occm = new List<decimal>();//占用金额
            List<int> occn = new List<int>();//合同数量
            List<int> months = new List<int>();//月份
            months = new List<int>();
            for (DateTime i = startDate; i <= endDate; i = i.AddMonths(1))
            {
                //occm.Add(Convert.ToDecimal(prjbond.Where(x => x.ActualTime == null && x.TaskTime.Value.Month == item && x.IsBond == true)
                //.Sum(x => x.BondMoney)));

                string result = string.Format("{0}{1}", i.Year, i.Month.ToString("D2"));
                months.Add(int.Parse(result));
                int occCount = 0/*, occCountsum = 0*/;
                decimal? occMoney = 0/*, occMoneysum = 0*/;
                if (i == startDate || i == endDate)
                {
                    DateTime endTime = new DateTime(i.AddMonths(1).Year, i.AddMonths(1).Month, 1);
                    IQueryable<PrjBond> query = null;
                    if (i == startDate)
                    {
                        query = prjbond.Where(x => x.TaskTime.HasValue
                        && x.TaskTime.Value >= i
                        && x.TaskTime.Value < endTime
                        && x.IsBond == true);
                    }
                    else
                    {
                        DateTime time = new DateTime(endDate.Year, endDate.Month, 1);
                        query = prjbond.Where(x => x.TaskTime.HasValue
                       && x.TaskTime.Value >= time
                       && x.TaskTime.Value < endDate
                       && x.IsBond == true);
                    }

                    occCount = query.Count();
                    occMoney = query.Sum(x => x.BondMoney);

                    //IQueryable<PrjBond> manageQuery1 = query.Where(x => x.ManageMode == "自营");
                    //IQueryable<PrjBond> manageQuery2 = query.Where(x => x.ManageMode == "联营");

                    //manageCount1 = manageQuery1.Count();
                    //manageCount2 = manageQuery2.Count();
                    //manageMoney1 = manageQuery1.Sum(x => x.PactMoney);
                    //manageMoney2 = manageQuery2.Sum(x => x.PactMoney);
                }
                else
                {
                    IQueryable<PrjBond> query = prjbond.Where(x => x.TaskTime.HasValue
                    && x.TaskTime.Value.Year == i.Year
                    && x.TaskTime.Value.Month == i.Month);

                    occCount = query.Count();
                    occMoney = query.Sum(x => x.BondMoney);

                    //IQueryable<PrjBond> manageQuery1 = query.Where(x => x.ManageMode == "自营");
                    //IQueryable<PrjBond> manageQuery2 = query.Where(x => x.ManageMode == "联营");

                    //manageCount1 = manageQuery1.Count();
                    //manageCount2 = manageQuery2.Count();
                    //manageMoney1 = manageQuery1.Sum(x => x.PactMoney);
                    //manageMoney2 = manageQuery2.Sum(x => x.PactMoney);
                }
                occn.Add(occCount);
                occm.Add(occMoney.HasValue ? occMoney.Value : 0);

                //zypactnum.Add(manageCount1);
                //zypactm.Add(manageMoney1.HasValue ? manageMoney1.Value : 0);
                //lypactnum.Add(manageCount2);
                //lypactm.Add(manageMoney2.HasValue ? manageMoney2.Value : 0);
            }

            view.Months = months.ToArray();
            view.OccAmount = occm.ToArray();
            view.OccNums = occn.ToArray();

            ViewBag.months = view.Months;
            ViewBag.monthlength = view.Months.Length;
            ViewBag.occm = view.OccAmount;
            ViewBag.occn = view.OccNums;

            List<PrjBond> prjbondlist = this.DbService.ValidQuery<PrjBond>(x => x.TaskTime.HasValue
     && x.TaskTime >= startDate
     && x.TaskTime <= endDate
     && x.IsBond == true).ToList();
            ViewBag.Total = "合计";
            ViewBag.occmtotal = prjbondlist.Sum(x=>x.BondMoney);
            ViewBag.occntotal = prjbondlist.Count();
        }
    }
}
