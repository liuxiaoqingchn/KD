using System.Web.Mvc;
using KdCore;
using KdYdt.Gxsj.Item.Domains.Assist;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 封标
    /// </summary>
    [KdUnitGroup("封标上传", 110, true)]
    public class PrjSealController  : ItemBaseController<PrjBiding, PrjBidingEdit>
    {
        [KdAction("查阅")]
        [HttpGet]
        public override ActionResult Index(string id)
        {
            return this.DataListView<PrjBiding>(x => x.BidingType == EnumBidingType.封标);
        }
    }
}
