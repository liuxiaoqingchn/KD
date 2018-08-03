using System.Web.Mvc;
using KdCore;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 标书费管理
    /// </summary>
    [KdUnitGroup("标书费管理", 210, true)]
    public class PayBidingController : ItemBaseController<PayBiding, PayBidingEdit>
    {
    }
}
