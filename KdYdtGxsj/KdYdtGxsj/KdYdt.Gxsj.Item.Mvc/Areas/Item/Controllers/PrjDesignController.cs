using KdCore;
using KdYdt.Gxsj.Item.Domains.Assist;
using KdYdt.Gxsj.Item.Domains.EditModels;
using KdYdt.Gxsj.Item.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 设计标
    /// </summary>
    [KdUnitGroup("设计标", 90, true)]
    public class PrjDesignController : ItemBaseController<PrjBiding, PrjBidingEdit>
    {
        [KdAction("查阅")]
        [HttpGet]
        public override ActionResult Index(string id)
        {
            return this.DataListView<PrjBiding>(x => x.BidingType == EnumBidingType.设计标);
        }
    }
}
