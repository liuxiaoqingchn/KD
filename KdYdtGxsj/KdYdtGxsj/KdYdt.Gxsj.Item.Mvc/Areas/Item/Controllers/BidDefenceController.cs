using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KdCore;
using KdCore.Data;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{ 
    /// <summary>
    /// 答辩情况
    /// </summary>
    [KdUnitGroup("答辩情况", 160,true)]
    public class BidDefenceController: ItemBaseController<BidDefence, BidDefenceEdit>
    {
    }
}
