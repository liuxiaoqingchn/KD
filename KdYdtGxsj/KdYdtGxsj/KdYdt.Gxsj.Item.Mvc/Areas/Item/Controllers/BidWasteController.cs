using System.Web.Mvc;
using KdCore;
using KdCore.Data;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 废标项目
    /// </summary>
    [KdUnitGroup("废标项目", 180, true)]
    public class BidWasteController : ItemBaseController<BidWaste, BidWasteEdit>
    {
    }
}
