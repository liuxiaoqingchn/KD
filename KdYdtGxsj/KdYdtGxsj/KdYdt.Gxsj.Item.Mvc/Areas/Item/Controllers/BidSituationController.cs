using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KdCore;
using KdCore.Data;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    [KdUnitGroup("开标情况", 140, true)]
    public class BidSituationController : ItemBaseController<BidSituation, BidSituationEdit>
    {
    }
}
