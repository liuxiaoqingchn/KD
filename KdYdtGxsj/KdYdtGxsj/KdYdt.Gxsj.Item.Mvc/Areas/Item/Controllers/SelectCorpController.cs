using System.Web.Mvc;
using KdYdt.Gxsj.Item.Domains.Models;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    public class SelectCorpController : ItemBaseController
    {
        public ActionResult SelectCorp()
        {
            return this.DataListView<PrjCorp>();/*x=>x.CropType=="0"*/
        }
    }
}
