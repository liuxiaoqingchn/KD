using KdCore;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;
using KdCore.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 保函或保证金
    /// </summary>
    [KdUnitGroup("保函或保证金", 100, true)]
    public class PrjBondController : ItemBaseController<PrjBond, PrjBondEdit>
    {
        protected override void OnDataView<TEntity>()
        {
            base.OnDataView<TEntity>();
            this.SetSelectList<PrjBond, bool>(x => x.IsBond, "IsOpen");
            this.SetSelectList<PrjBond, bool>(x => x.IsPlay, "IsOpen");
        }
    }
}
