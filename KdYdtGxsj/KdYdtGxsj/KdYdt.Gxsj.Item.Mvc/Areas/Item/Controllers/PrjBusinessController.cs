using System.Web.Mvc;
using KdCore;
using KdYdt.Gxsj.Item.Domains.Assist;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;


namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 商务标
    /// </summary>
    [KdUnitGroup("商务标", 90, true)]
    public class PrjBusinessController : ItemBaseController<PrjBiding, PrjBidingEdit>
    {
        [KdAction("查阅")]
        [HttpGet]
        public override ActionResult Index(string id)
        {
            return this.DataListView<PrjBiding>(x => x.BidingType == EnumBidingType.商务标);
        }
    }
}
