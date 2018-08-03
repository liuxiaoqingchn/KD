using KdCore;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;
using KdCore.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    [KdUnitGroup("人员库", 10)]
    public class PersonController : ItemBaseController<PrjPerson, PrjPersonEdit>
    {
        protected override void OnDataView<TEntity>()
        {
            base.OnDataView<TEntity>();
            this.SetSelectList<PrjPerson, bool>(x => x.ISLocking, "IsOpen");
        }

    }
}
