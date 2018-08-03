using KdCore;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KdCore.Web.Mvc;
using KdCore.Data;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    [KdUnitGroup("项目信息", 30, true)]
    public class PrjItemController : ItemBaseController<PrjItem, PrjItemEdit>
    {
        protected override void OnDataView<TEntity>()
        {
            base.OnDataView<TEntity>();
            this.SetSelectList<PrjItem, bool>(x => x.IsPrese, "IsOpen");
        }
        [KdAction("查阅")]
        [HttpGet]
        public override ActionResult Index(string id)
        {
            List<PrjItem> items = new List<PrjItem>();
            return base.Index(id);
        }
        [KdAction("查阅")]
        [HttpGet]
        public override ActionResult Edit(string id)
        {
            return base.Edit(id);
        }
        [KdAction("编辑")]
        [HttpPost]
        public override ActionResult Edit(PrjItemEdit editModel)
        {
            return base.Edit(editModel);
        }
    }
}
