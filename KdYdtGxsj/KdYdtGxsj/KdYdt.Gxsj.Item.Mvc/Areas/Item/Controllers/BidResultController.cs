using KdCore;
using KdCore.Data;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;
using System.Web.Mvc;
using KdCore.Web.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using KdYdt.Gxsj.Item.Domains.Assist;
using System.Linq;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 定标结果
    /// </summary>
    [KdUnitGroup("结果跟踪", 170, true)]
    public class BidResultController : ItemBaseController<BidResult, BidResultEdit>
    {
        protected override void OnDataView<TEntity>()
        {
            base.OnDataView<TEntity>();
            this.SetSelectList<PrjSign, bool>(x => x.IsBond, "IsOpen");
            this.SetSelectList<PrjSign, bool>(x => x.IsTender, "IsOpen");
        }
        [KdAction("编辑")]
        [HttpPost]
        public override ActionResult Edit(BidResultEdit editModel)
        {
            KdDataResult result = this.CheckModelState<BidResult, BidResultEdit>(editModel);
            if (result.Failure)
                return this.DataEntityView(result.Result as BidResult);
            BidResult edit = this.DbService.GetForSave<BidResult, BidResultEdit>(editModel);
            if (edit != null)
            {
                //项目中标  结果更新到项目里
                PrjPlan prj = this.DbService.ValidQuery<PrjPlan>(x => x.PrjCode == edit.PrjCode && x.PrjName == edit.PrjName).FirstOrDefault();
                if (prj != null)
                {
                    prj.IsBid = edit.IsBid;
                }
                //当项目中标时 选择的人员库的项目经理之后  将人员库的项目经理的是否有在建工程状态改为"是"
                if (edit.IsBid == "中标")
                {
                    string a = edit.PrjPersonId;
                    string b = edit.PrjPersonName;
                    PrjPerson per = this.DbService.ValidQuery<PrjPerson>(x => x.PersonName == b && x.Id == a).FirstOrDefault();
                    if (per != null)
                    {
                        per.ISLocking = true;
                        this.DbService.Update(per);
                    }
                    if (edit.IsOpen == true)
                    {
                        prj.PrjStatus = EnumPrjStatus.已完成且已中标;
                        edit.PrjStatus = EnumPrjStatus.已完成且已中标;
                    }
                    else
                    {
                        PrjSign sgin = this.DbService.ValidQuery<PrjSign>(x => x.PrjCode == edit.PrjCode && x.PrjName == edit.PrjName).FirstOrDefault();

                        sgin.PrjStatus = EnumPrjStatus.已完成且已中标;
                        prj.PrjStatus = EnumPrjStatus.已完成且已中标;
                        edit.PrjStatus = EnumPrjStatus.已完成且已中标;
                    }
                }
                else
                {
                    if (edit.IsOpen == true)
                    {
                        prj.PrjStatus = EnumPrjStatus.已完成未中标;
                        edit.PrjStatus = EnumPrjStatus.已完成未中标;
                    }
                    else
                    {
                        PrjSign sgin = this.DbService.ValidQuery<PrjSign>(x => x.PrjCode == edit.PrjCode && x.PrjName == edit.PrjName).FirstOrDefault();

                        sgin.PrjStatus = EnumPrjStatus.已完成未中标;
                        prj.PrjStatus = EnumPrjStatus.已完成未中标;
                        edit.PrjStatus = EnumPrjStatus.已完成未中标;
                    }
                }
                //更新项目状态
                if (edit.IsNewData())
                {
                    edit.PrjStatus = EnumPrjStatus.已投标;
                }
                edit.ManageMode = prj.ManageMode;
            }
            this.DbService.Save(edit);
            this.DbService.SaveChanges();
            return this.KdViewResult<BidResult>(result);
        }
    }
}
