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
    /// 收入汇总
    /// </summary>
    [KdUnitGroup("收入汇总", 190, true)]
    public class IncomeSumReportController : ItemBaseController
    {

        //[KdAction("收入汇总")]
        //public virtual   ActionResult Index(FormCollection form)
        //{
        //    BdTabHeader(EnumPaySum.收入汇总);
        #region
        //string a = form["kpq_RelDate"];
        //string b = form["kpq_RelDate_2"];
        //var querys2 = this.DbService.ValidQuery<PayIncome>(x => x.HandlingData != null);
        //if (!a.IsNullValue())
        //{
        //    DateTime atime = a.ToDateTime();
        //    querys2 = querys2.Where(x => x.HandlingData >= atime);
        //}
        //if (!b.IsNullValue())
        //{
        //    DateTime btime = b.ToDateTime();
        //    querys2 = querys2.Where(x => x.HandlingData <= btime);
        //}
        //List<IncomeSumReport> model = new List<IncomeSumReport>();
        //IncomeSumReport entity = null;
        //IEnumerable<IGrouping<string, PayIncome>> iogroups2 = querys2.GroupBy(x => x.PrjName);
        //foreach (IGrouping<string, PayIncome> item2 in iogroups2)
        //{
        //    var prjs2 = item2.ToList();
        //    PayIncome temp2 = item2.FirstOrDefault();
        //    entity = new IncomeSumReport();
        //    entity.Prj = temp2.PrjName;
        //    entity.BSInc = prjs2.Sum(x => x.BusinessCost) + prjs2.Sum(x => x.TechniqueCost);
        //    entity.ManageInc = prjs2.Sum(x => x.ManagerCost);
        //    entity.MaterialInc = prjs2.Sum(x => x.DataCost);
        //    entity.AdminInc = prjs2.Sum(x => x.Management);
        //    entity.PrjExpInc = prjs2.Sum(x => x.ExpectedProfit);
        //    entity.OtherInc = prjs2.Sum(x => x.OthersCost);
        //    entity.BidSumInc = prjs2.Sum(x => x.BusinessCost) + prjs2.Sum(x => x.TechniqueCost) + prjs2.Sum(x => x.ManagerCost)
        //   + prjs2.Sum(x => x.DataCost) + prjs2.Sum(x => x.Management) + prjs2.Sum(x => x.ExpectedProfit) + prjs2.Sum(x => x.OthersCost);
        //    model.Add(entity);
        //}
        //return this.KdView(model);
        #endregion
        ////}
    }
}
