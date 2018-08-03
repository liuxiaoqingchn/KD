using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using KdCore;
using KdCore.Data.Dicts;

using KdYdt.Gxsj.Item.Domains.EditModels;
using KdYdt.Gxsj.Item.Domains.Models;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 资格审查
    /// </summary>
    [KdUnitGroup("资格审查", 130, true)]
    public class BidQualCheckController : ItemBaseController<BidQualCheck, BidQualCheckEdit>
    {
        [KdAction("编辑")]
        [HttpPost]
        public override ActionResult Edit(BidQualCheckEdit editModel)
        {
            if (editModel != null)
            {
                List<KdDictItem> items = KdDict.GetDict("QualCheckType").GetTreeNodes();
                KdDictItem item = items.FirstOrDefault(x => x.NodeCode == editModel.QualCheckType.ToString());
                if (item != null)
                    editModel.QualCheckTypeName = item.NodeName;
            }
            return base.Edit(editModel);
        }
    }
}
