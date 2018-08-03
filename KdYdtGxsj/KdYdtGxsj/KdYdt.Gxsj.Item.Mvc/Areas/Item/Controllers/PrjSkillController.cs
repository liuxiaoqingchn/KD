using System.Web.Mvc;
using KdCore;
using KdYdt.Gxsj.Item.Domains.Assist;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 技术标
    /// </summary>
    [KdUnitGroup("技术标", 80, true)]
    public class PrjSkillController : ItemBaseController<PrjBiding, PrjBidingEdit>
    {
        [KdAction("查阅")]
        [HttpGet]
        public override ActionResult Index(string id)
        {
            return this.DataListView<PrjBiding>(x => x.BidingType == EnumBidingType.技术标);
        }
    }
}
