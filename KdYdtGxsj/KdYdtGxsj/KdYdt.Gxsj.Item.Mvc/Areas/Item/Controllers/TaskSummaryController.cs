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
    /// 任务汇总
    /// </summary>
    [KdUnitGroup("任务汇总", 190, true)]
    public class TaskSummaryController : ItemBaseController
    {
        [KdAction("任务汇总")]
        public virtual ActionResult Index(FormCollection form)
        {
            #region
            string a = form["kpq_RelDate"];
            string b = form["kpq_RelDate_2"];
            var querys = this.DbService.ValidQuery<PrjBiding>(x => x.TaskTime != null);
            #region  
            if (a == null && b == null)
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
                querys = querys.Where(x => x.TaskTime >= beforeMouthOneDay && x.TaskTime <= beforeMouthLastDay);
            }
            #endregion
            if (!a.IsNullValue())
            {
                DateTime atime = a.ToDateTime();
                querys = querys.Where(x => x.TaskTime >= atime);
            }
            if (!b.IsNullValue())
            {
                DateTime btime = b.ToDateTime();
                querys = querys.Where(x => x.TaskTime <= btime);
            }
            List<TaskSummaryReport> model = new List<TaskSummaryReport>();
            IEnumerable<IGrouping<string, PrjBiding>> iogroups = querys.GroupBy(x => x.MakeName);
            TaskSummaryReport entity = null;
            foreach (IGrouping<string, PrjBiding> item in iogroups) 
            {
                var prjs = item.ToList();
                PrjBiding temp = item.FirstOrDefault();
                entity = new TaskSummaryReport();
                entity.Manage = temp.MakeName;
                entity.Bid = prjs.Where(x => x.BidMan == entity.Manage).Count();
                entity.BusinessBid = prjs.Where(x => x.BidingType == EnumBidingType.商务标).Count();
                entity.TechBid = prjs.Where(x => x.BidingType == EnumBidingType.技术标).Count();
                entity.SealBid = prjs.Where(x => x.BidingType == EnumBidingType.封标).Count();
                entity.CreditBid = prjs.Where(x => x.BidingType == EnumBidingType.资信标).Count();
                entity.DesignBid = prjs.Where(x => x.BidingType == EnumBidingType.设计标).Count();
                entity.BidSum = prjs.Count();
                model.Add(entity);
            }
            entity = new TaskSummaryReport
            {
                Manage = "总计",
                Bid=model.Sum(x=>x.Bid),
                BusinessBid = model.Sum(x => x.BusinessBid),
                TechBid = model.Sum(x => x.TechBid),
                SealBid = model.Sum(x => x.SealBid),
                CreditBid = model.Sum(x => x.CreditBid),
                DesignBid = model.Sum(x => x.DesignBid),
                BidSum = model.Sum(x => x.BidSum),

            };
            model.Add(entity);
            return this.KdView(model);
            #endregion
        }
    }
}
