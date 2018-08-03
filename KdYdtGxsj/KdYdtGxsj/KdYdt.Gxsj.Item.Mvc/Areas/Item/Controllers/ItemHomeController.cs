using System.Web.Mvc;
using KdCore;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    [KdUnitGroup("项目管理首页", 0)]
    public class ItemHomeController : ItemBaseController
    {
        [KdAction(null, 0, null, EveryOne = true)]
        public ActionResult Index()
        {
            return KdView();
        }
    }
}
