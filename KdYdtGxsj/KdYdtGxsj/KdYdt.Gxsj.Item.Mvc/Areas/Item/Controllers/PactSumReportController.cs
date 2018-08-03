using KdCore;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 合同汇总
    /// </summary>
    [KdUnitGroup("合同汇总", 190, true)]
    public class PactSumReportController : ItemBaseController
    {
        [KdAction("合同汇总")]
        public virtual ActionResult Index(FormCollection form)
        {
            PactSumReport view = new PactSumReport();
            List<int> months = new List<int>();//月份 
            string startDateStr = form["kpq_RelDate"];
            string endDateStr = form["kpq_RelDate_2"];
            DateTime date = DateTime.Now;
            if (string.IsNullOrWhiteSpace(startDateStr) ||
                string.IsNullOrWhiteSpace(endDateStr))
            {
                MonthsItem(view, date.AddMonths(-11), date);

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
        public void MonthsItem(PactSumReport view, DateTime startDate, DateTime endDate)
        {

            view = new PactSumReport();
            IQueryable<PayPact> payPacts = this.DbService.ValidQuery<PayPact>(x => x.PactSignDate.HasValue
            && x.PactSignDate >= startDate
            && x.PactSignDate <= endDate);

            List<int> zypactnum = new List<int>();//自营合同数量
            List<decimal> zypactm = new List<decimal>();//自营合同金额
            List<int> lypactnum = new List<int>();//联营合同数量
            List<decimal> lypactm = new List<decimal>();//联营合同金额
            List<int> pactnum = new List<int>();//合同数量
            List<decimal> pactm = new List<decimal>();//合同金额
            List<int> months = new List<int>();//月份

            months = new List<int>();
            for (DateTime i = startDate; i <= endDate; i = i.AddMonths(1))
            {
                string result = string.Format("{0}{1}", i.Year, i.Month.ToString("D2"));
                months.Add(int.Parse(result));
                int pactCount = 0, manageCount1 = 0, manageCount2 = 0;
                decimal? pactMoney = 0, manageMoney1 = 0, manageMoney2 = 0;
                if (i == startDate || i == endDate)
                {
                    DateTime endTime = new DateTime(i.AddMonths(1).Year, i.AddMonths(1).Month, 1);
                    IQueryable<PayPact> query = null;
                    if (i == startDate)
                    {
                        query = payPacts.Where(x => x.PactSignDate.HasValue
                        && x.PactSignDate.Value >= i
                        && x.PactSignDate.Value < endTime);
                    }
                    else
                    {
                        DateTime time = new DateTime(endDate.Year, endDate.Month, 1);
                        query = payPacts.Where(x => x.PactSignDate.HasValue
                       && x.PactSignDate.Value >= time
                       && x.PactSignDate.Value < endDate);
                    }

                    pactCount = query.Count();
                    pactMoney = query.Sum(x => x.PactMoney);

                    IQueryable<PayPact> manageQuery1 = query.Where(x => x.ManageMode == "自营");
                    IQueryable<PayPact> manageQuery2 = query.Where(x => x.ManageMode == "联营");

                    manageCount1 = manageQuery1.Count();
                    manageCount2 = manageQuery2.Count();
                    manageMoney1 = manageQuery1.Sum(x => x.PactMoney);
                    manageMoney2 = manageQuery2.Sum(x => x.PactMoney);
                }
                else
                {
                    IQueryable<PayPact> query = payPacts.Where(x => x.PactSignDate.HasValue
                    && x.PactSignDate.Value.Year == i.Year
                    && x.PactSignDate.Value.Month == i.Month);

                    pactCount = query.Count();
                    pactMoney = query.Sum(x => x.PactMoney);

                    IQueryable<PayPact> manageQuery1 = query.Where(x => x.ManageMode == "自营");
                    IQueryable<PayPact> manageQuery2 = query.Where(x => x.ManageMode == "联营");

                    manageCount1 = manageQuery1.Count();
                    manageCount2 = manageQuery2.Count();
                    manageMoney1 = manageQuery1.Sum(x => x.PactMoney);
                    manageMoney2 = manageQuery2.Sum(x => x.PactMoney);
                }
                pactnum.Add(pactCount);
                pactm.Add(pactMoney.HasValue ? pactMoney.Value : 0);

                zypactnum.Add(manageCount1);
                zypactm.Add(manageMoney1.HasValue ? manageMoney1.Value : 0);
                lypactnum.Add(manageCount2);
                lypactm.Add(manageMoney2.HasValue ? manageMoney2.Value : 0);


            }


            view.Months = months.ToArray();
            view.PactNum = pactnum.ToArray();
            view.PactAmount = pactm.ToArray();
            view.zyPactNum = zypactnum.ToArray();
            view.zyPactAmount = zypactm.ToArray();
            view.lyPactNum = lypactnum.ToArray();
            view.lyPactAmount = lypactm.ToArray();

            ViewBag.months = view.Months;
            ViewBag.monthlength = view.Months.Length;
            ViewBag.pactnum = view.PactNum;
            ViewBag.pactm = view.PactAmount;
            ViewBag.zypactnum = view.zyPactNum;
            ViewBag.zypactm = view.zyPactAmount;
            ViewBag.lypactnum = view.lyPactNum;
            ViewBag.lypactm = view.lyPactAmount;

            List<PayPact> pactlist = this.DbService.ValidQuery<PayPact>(x => x.PactSignDate.HasValue
            && x.PactSignDate >= startDate
            && x.PactSignDate <= endDate).ToList();

            ViewBag.Total = "合计";
            ViewBag.pactnumtotal = pactlist.Count();
            ViewBag.pactmtotal = pactlist.Sum(x=>x.PactMoney);
            ViewBag.zypactnumtotal = pactlist.Where(x => x.ManageMode == "自营").Count();
            ViewBag.zypactmtotal = pactlist.Where(x => x.ManageMode == "自营").Sum(x => x.PactMoney);
            ViewBag.lypactnumtotal = pactlist.Where(x => x.ManageMode == "联营").Count(); ;
            ViewBag.lypactmtotal = pactlist.Where(x => x.ManageMode == "联营").Sum(x => x.PactMoney);
        }
    }
}
