using System.Web.Mvc;
using KdCore;
using KdCore.Web.Controllers;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.Services;

namespace KdYdt.Gxsj.Item.Mvc.Controllers
{
    /// <summary>
    /// 政务安排
    /// </summary>
    [KdUnitGroup("企业库", 10)]
    public class CorpControllers : KdBaseController<PrjDbItemService>
    {

        [KdAction("查阅")]
        public ActionResult Index()
        {
            return this.DataListView<PrjCorp>();
        }

    }
}
