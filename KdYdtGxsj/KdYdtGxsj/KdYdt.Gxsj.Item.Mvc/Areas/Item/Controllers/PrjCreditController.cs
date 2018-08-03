using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KdYdt.Gxsj.Item.Domains.Assist;
using KdYdt.Gxsj.Item.Domains.EditModels;
using KdYdt.Gxsj.Item.Domains.Models;
using System.Web.Mvc;
using KdCore;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 资信标
    /// </summary>
    [KdUnitGroup("资信标", 90, true)]
    public class PrjCreditController : ItemBaseController<PrjBiding, PrjBidingEdit>
    {
        [KdAction("查阅")]
        [HttpGet]
        public override ActionResult Index(string id)
        {
            return this.DataListView<PrjBiding>(x => x.BidingType == EnumBidingType.资信标);
        }
    }
}
