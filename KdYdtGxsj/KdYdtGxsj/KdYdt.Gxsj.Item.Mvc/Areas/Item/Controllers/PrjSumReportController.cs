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
    /// 项目汇总
    /// </summary>
    [KdUnitGroup("项目汇总", 190, true)]
    public class PrjSumReportController : ItemBaseController
    {
        [KdAction("项目汇总")]
        public virtual ActionResult Index(FormCollection form)
        {
            PrjSumReport view = new PrjSumReport();
            List<int> months = new List<int>();//月份 
            string startDateStr = form["kpq_RelDate"];
            string endDateStr = form["kpq_RelDate_2"];
            DateTime date = DateTime.Now;
            if (string.IsNullOrWhiteSpace(startDateStr) ||
                string.IsNullOrWhiteSpace(endDateStr))
            {
                MonthsItem(view, date.AddMonths(-5), date);
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
        //string[] tenderstr = new[] { "交易中心", "政府采购", "社会招投标" };
        public void MonthsItem(PrjSumReport view, DateTime startDate, DateTime endDate)
        {
            view = new PrjSumReport();
            IQueryable<PrjPlan> prj = this.DbService.ValidQuery<PrjPlan>(x => x.ProjectDate.HasValue
            && x.ProjectDate >= startDate
            && x.ProjectDate <= endDate);

            List<int> months = new List<int>();//月份
            List<int> prjnumjyzx = new List<int>();//立项数量    
            List<int> signnumjyzx = new List<int>();//投标数量
            List<int> winbidnjyzx = new List<int>();//中标数量
            List<decimal> bidmjyzx = new List<decimal>();//中标金额
            List<int> prjnumzfcg = new List<int>();//立项数量    
            List<int> signnumzfcg = new List<int>();//投标数量
            List<int> winbidnzfcg = new List<int>();//中标数量
            List<decimal> bidmzfcg = new List<decimal>();//中标金额
            List<int> prjnumztb = new List<int>();//立项数量    
            List<int> signnumztb = new List<int>();//投标数量
            List<int> winbidnztb = new List<int>();//中标数量
            List<decimal> bidmztb = new List<decimal>();//中标金额
            months = new List<int>();
            for (DateTime i = startDate; i <= endDate; i = i.AddMonths(1))
            {
                string result = string.Format("{0}{1}", i.Year, i.Month.ToString("D2"));
                months.Add(int.Parse(result));

                int bidCountjyzx = 0, bidnumsjyzx = 0, winbidnumsjyzx = 0, bidCountzfcg = 0, bidnumszfcg = 0, winbidnumszfcg = 0, bidCountztb = 0, bidnumsztb = 0, winbidnumsztb = 0;
                decimal? bidMoneyjyzx = 0, bidMoneyzfcg = 0, bidMoneyztb = 0;
                if (i == startDate || i == endDate)
                {
                    DateTime endTime = new DateTime(i.AddMonths(1).Year, i.AddMonths(1).Month, 1);
                    IQueryable<PrjPlan> query = null;
                    if (i == startDate)
                    {
                        query = prj.Where(x => x.ProjectDate.HasValue
                        && x.ProjectDate.Value >= i
                        && x.ProjectDate.Value < endTime);
                    }
                    else
                    {
                        DateTime time = new DateTime(endDate.Year, endDate.Month, 1);
                        query = prj.Where(x => x.ProjectDate.HasValue
                       && x.ProjectDate.Value >= time
                       && x.ProjectDate.Value < endDate);
                    }
                    IQueryable<PrjPlan> Query1 = query.Where(x => x.TenderMthod == "交易中心");
                    IQueryable<PrjPlan> Query2 = query.Where(x => x.TenderMthod == "政府采购");
                    IQueryable<PrjPlan> Query3 = query.Where(x => x.TenderMthod == "社会招投标");
                    bidCountjyzx = Query1.Count();
                    bidnumsjyzx = Query1.Count(x => x.IsSign == true);//投标数量
                    winbidnumsjyzx = Query1.Count(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标);
                    bidMoneyjyzx = Query1.Where(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标).Sum(x => x.EngScale);//金额！
                    bidCountzfcg = Query2.Count();
                    bidnumszfcg = Query2.Count(x => x.IsSign == true);//投标数量
                    winbidnumszfcg = Query2.Count(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标);
                    bidMoneyzfcg = Query2.Where(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标).Sum(x => x.EngScale);//金额！
                    bidCountztb = Query3.Count();
                    bidnumsztb = Query3.Count(x => x.IsSign == true);//投标数量
                    winbidnumsztb = Query3.Count(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标);
                    bidMoneyztb = Query3.Where(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标).Sum(x => x.EngScale);//金额！

                }
                else
                {
                    IQueryable<PrjPlan> query = prj.Where(x => x.ProjectDate.HasValue
                    && x.ProjectDate.Value.Year == i.Year
                    && x.ProjectDate.Value.Month == i.Month);

                    IQueryable<PrjPlan> Query1 = query.Where(x => x.TenderMthod == "交易中心");
                    IQueryable<PrjPlan> Query2 = query.Where(x => x.TenderMthod == "政府采购");
                    IQueryable<PrjPlan> Query3 = query.Where(x => x.TenderMthod == "社会招投标");
                    bidCountjyzx = Query1.Count();
                    bidnumsjyzx = Query1.Count(x => x.IsSign == true);//投标数量
                    winbidnumsjyzx = Query1.Count(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标);
                    bidMoneyjyzx = Query1.Where(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标).Sum(x => x.EngScale);//金额！
                    bidCountzfcg = Query2.Count();
                    bidnumszfcg = Query2.Count(x => x.IsSign == true);//投标数量
                    winbidnumszfcg = Query2.Count(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标);//投标数量
                    bidMoneyzfcg = Query2.Where(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标).Sum(x => x.EngScale);//金额！
                    bidCountztb = Query3.Count();
                    bidnumsztb = Query3.Count(x => x.IsSign == true);//投标数量
                    winbidnumsztb = Query3.Count(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标);//投标数量
                    bidMoneyztb = Query3.Where(x => x.IsSign == true && x.PrjStatus == EnumPrjStatus.已完成且已中标).Sum(x => x.EngScale);//金额！

                }
                prjnumjyzx.Add(bidCountjyzx);
                signnumjyzx.Add(bidnumsjyzx);
                winbidnjyzx.Add(winbidnumsjyzx);
                bidmjyzx.Add(bidMoneyjyzx.HasValue ? bidMoneyjyzx.Value : 0);

                prjnumzfcg.Add(bidCountzfcg);
                signnumzfcg.Add(bidnumszfcg);
                winbidnzfcg.Add(winbidnumszfcg);
                bidmzfcg.Add(bidMoneyzfcg.HasValue ? bidMoneyzfcg.Value : 0);

                prjnumztb.Add(bidCountztb);
                signnumztb.Add(bidnumsztb);
                winbidnztb.Add(winbidnumsztb);
                bidmztb.Add(bidMoneyztb.HasValue ? bidMoneyztb.Value : 0);
            }
            view.Months = months.ToArray();
            view.Bidjyzx = signnumjyzx.ToArray();//投标数量
            view.ItemNumsjyzx = prjnumjyzx.ToArray();//立项数量
            view.WinBidNumsjyzx = winbidnjyzx.ToArray();//中标数量
            view.BidAmountjyzx = bidmjyzx.ToArray();//中标金额

            view.Bidzfcg = signnumzfcg.ToArray();//投标数量
            view.ItemNumszfcg = prjnumzfcg.ToArray();//立项数量
            view.WinBidNumszfcg = winbidnzfcg.ToArray();//中标数量
            view.BidAmountzfcg = bidmzfcg.ToArray();//中标金额

            view.Bidztb = signnumztb.ToArray();//投标数量
            view.ItemNumsztb = prjnumztb.ToArray();//立项数量
            view.WinBidNumsztb = winbidnztb.ToArray();//中标数量
            view.BidAmountztb = bidmztb.ToArray();//中标金额

            ViewBag.monthlength = view.Months.Length;
            ViewBag.months = view.Months;

            ViewBag.ItemNumsjyzx = view.ItemNumsjyzx;
            ViewBag.Bidjyzx = view.Bidjyzx;
            ViewBag.WinBidNumsjyzx = view.WinBidNumsjyzx;
            ViewBag.BidAmountjyzx = view.BidAmountjyzx;

            ViewBag.ItemNumszfcg = view.ItemNumszfcg;
            ViewBag.Bidzfcg = view.Bidzfcg;
            ViewBag.WinBidNumszfcg = view.WinBidNumszfcg;
            ViewBag.BidAmountzfcg = view.BidAmountzfcg;

            ViewBag.ItemNumsztb = view.ItemNumsztb;
            ViewBag.Bidztb = view.Bidztb;
            ViewBag.WinBidNumsztb = view.WinBidNumsztb;
            ViewBag.BidAmountztb = view.BidAmountztb;
        }
    }
}
