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
    /// 建造师汇总
    /// </summary>
    [KdUnitGroup("建造师汇总", 190, true)]
    public class PersonSummaryController : ItemBaseController
    {
        [KdAction("建造师汇总")]
        public virtual ActionResult Index(FormCollection form)
        {
            #region
            string a = form["kpq_RelDate"];
            string b = form["kpq_RelDate_2"];
            var querys = this.DbService.ValidQuery<PrjPlan>(x => x.ProjectDate != null && x.PrjPersonName != null);
            if (!a.IsNullValue())
            {
                DateTime atime = a.ToDateTime();
                querys = querys.Where(x => x.ProjectDate >= atime);
            }
            if (!b.IsNullValue())
            {
                DateTime btime = b.ToDateTime();
                querys = querys.Where(x => x.ProjectDate <= btime);
            }
            List<PersonSumReport> model = new List<PersonSumReport>();
            IEnumerable<IGrouping<string, PrjPlan>> iogroups = querys.GroupBy(x => x.PrjPersonName);
            PersonSumReport entity = null;
            foreach (IGrouping<string, PrjPlan> item in iogroups)
            {
                var prjs = item.ToList();
                PrjPlan temp = item.FirstOrDefault();
                entity = new PersonSumReport();
                entity.Manage = temp.PrjPersonName;
                entity.NotSginPrj = prjs.Count(x => x.PrjStatus == EnumPrjStatus.已立项);//已立项，未投标项目
                entity.IsSginPrj = prjs.Count(x => x.IsSign == true);//已投标项目
                entity.IsBidPrj = prjs.Count(x => x.IsBid == "中标");
                entity.NotBidPrj = prjs.Count(x => x.IsBid != "中标");
                entity.NotPactNum = prjs.Count(x => x.PrjStatus == EnumPrjStatus.已投标 && x.IsBid != "中标");
                entity.IsPactNum = prjs.Count(x => x.PrjStatus == EnumPrjStatus.已完成且已中标);
                entity.IsPactMoney = prjs.Where(x => x.PrjStatus == EnumPrjStatus.已完成且已中标).Sum(x => x.EngScale);
                model.Add(entity);
            }
            return this.KdView(model);
            #endregion
        }
    }
}
