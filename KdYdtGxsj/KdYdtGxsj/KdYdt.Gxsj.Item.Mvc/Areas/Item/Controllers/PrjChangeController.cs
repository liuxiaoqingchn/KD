using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KdCore;
using KdCore.Data;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    [KdUnitGroup("项目变更", 50)]
    public class PrjChangeController : ItemBaseController<BidNotice, BidNoticeEdit>
    {
        //[KdAction("编辑")]
        //[HttpPost]
        //public ActionResult Edit(string id, BidNoticeEdit editModel)
        //{
        //    BidNotice entity = this.DbService.DbView<BidNotice>(id);
        //    if (entity == null)
        //        return RedirectIndex();

        //    string a = editModel.PrjName;
        //    string b = editModel.PrjCode;
        //    List<BidPrjConfirm> prj = this.DbService.DbQuery<BidPrjConfirm>(x => x.PrjName == a && x.PrjCode == b).ToList();
        //    foreach (BidPrjConfirm item in prj)
        //    {
        //        switch (editModel.ChangeContent)
        //        {
        //            case "项目名称变更":
        //                item.PrjName = editModel.AfterContent;
        //                break;
        //            case "投标属性变更":
        //                item.TenderAttribute = editModel.AfterContent;
        //                break;
        //            case "项目经理变更":
        //            default:
        //                break;
        //        }
        //        this.DbService.Update(item);
        //    }

        //    BidNotice newentity = new BidNotice();
        //    newentity.SetId();
        //    newentity.PrjName = editModel.PrjName;
        //    newentity.ChangeContent = editModel.ChangeContent;
        //    newentity.Others = editModel.Others;
        //    newentity.PreContent = editModel.PreContent;
        //    newentity.AfterContent = editModel.AfterContent;
        //    newentity.ChangeReason = editModel.ChangeReason;
        //    newentity.ChangePerson = editModel.ChangePerson;
        //    newentity.ChangeDate = editModel.ChangeDate;
        //    newentity.BidNoticeMark = editModel.BidNoticeMark;
        //    newentity.SaveMode = BbSaveMode.Insert;
        //    this.DbService.Add(newentity);

        //    this.DbService.SaveChanges();

        //    return this.RedirectIndex();
        //}
    }
}
