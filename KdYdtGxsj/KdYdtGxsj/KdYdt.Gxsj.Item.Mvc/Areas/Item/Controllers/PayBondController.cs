using System.Web.Mvc;
using KdCore;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;
using KdCore.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 保证金管理
    /// </summary>
    [KdUnitGroup("保证金管理", 200, true)]
    public class PayBondController  : ItemBaseController<PrjBond, PrjBondEdit>
    {
        protected override void OnDataView<TEntity>()
        {
            base.OnDataView<TEntity>();
            this.SetSelectList<PrjBond, bool>(x => x.IsReturn, "IsOpen");
            this.SetSelectList<PrjBond, bool>(x => x.IsBond, "IsOpen"); 
        }
        public override ActionResult Index(string id)
        {
            return this.DataListView<PrjBond>(x => x.IsBond);
        }
    }
}
