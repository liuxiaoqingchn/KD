using KdCore;
using KdCore.Data;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;
using System.Collections.Generic;
using System.Web.Mvc;
using KdYdt.Gxsj.Item.Domains.Assist;
using System.Linq;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 合同管理
    /// </summary>
    [KdUnitGroup("合同管理", 190, true)]
    public class PayPactController : ItemBaseController<PayPact, PayPactEdit>
    {
        public override ActionResult Index(string id)
        {
            return base.Index(id);
        }
        [KdAction("编辑")]
        [HttpPost]
        public override ActionResult Edit(PayPactEdit editModel)
        {
            KdDataResult result = this.CheckModelState<PayPact, PayPactEdit>(editModel);
            if (result.Failure)
                return this.DataEntityView(result.Result as PayPact);
            PayPact edit = this.DbService.GetForSave<PayPact, PayPactEdit>(editModel);
            if (edit != null)
            {

                #region   暂时不删
                ////签订合同后，项目立项的进度状态改为  不可编辑
                //PrjPlan prj = this.DbService.ValidGet<PrjPlan>(edit.ProjectId);
                //if (prj != null)
                //{
                //    ////if (edit.IsNewData())
                //    ////{
                //    //prj.PrjStatus = EnumPrjStatus.已完成;
                //    ////}
                //    prj.AllowedEdit = true;
                //    this.DbService.Save(prj);
                //}
                ////签订合同后，投标报名的进度状态改为     不可编辑
                //PrjSign prjsign = this.DbService.ValidGet<PrjSign>(edit.ProjectId);
                //if (prjsign != null)
                //{
                //    ////if (edit.IsNewData())
                //    ////{
                //    //prjsign.PrjStatus = EnumPrjStatus.已完成;
                //    ////}
                //    prjsign.AllowedEdit = true;
                //    this.DbService.Save(prjsign);
                //}
                #endregion
                #region  签订合同后，结果跟踪的进度状态改为  已完成 
                BidResult bidresult = this.DbService.ValidGet<BidResult>(edit.ProjectId);
                PrjPlan plan = this.DbService.ValidQuery<PrjPlan>(x => x.PrjCode == edit.PrjCode && x.PrjName == edit.PrjName).FirstOrDefault();
                PrjSign sgin = this.DbService.ValidQuery<PrjSign>(x => x.PrjCode == edit.PrjCode && x.PrjName == edit.PrjName).FirstOrDefault();
                if (bidresult != null)
                {
                    if (edit.IsNewData())
                    {
                        if (bidresult.IsBid == "中标")
                        {
                            edit.PrjStatus = EnumPrjStatus.已完成且已中标;
                            bidresult.PrjStatus = EnumPrjStatus.已完成且已中标;
                            plan.PrjStatus = EnumPrjStatus.已完成且已中标;
                            sgin.PrjStatus = EnumPrjStatus.已完成且已中标;
                        }
                        else
                        {
                            edit.PrjStatus = EnumPrjStatus.已完成未中标;
                            bidresult.PrjStatus = EnumPrjStatus.已完成未中标;
                            plan.PrjStatus = EnumPrjStatus.已完成未中标;
                            sgin.PrjStatus = EnumPrjStatus.已完成未中标;
                        }
                    }
                    edit.ManageMode = bidresult.ManageMode;
                    edit.IsOpen = bidresult.IsOpen;//不管选择是 或者否  都保存投标结果的  
                }
                this.DbService.Save(bidresult);
                //edit.IsOpen = bidresult.IsOpen;
                #endregion
            }

            this.DbService.Save(edit);
            this.DbService.SaveChanges();
            return this.KdViewResult<PayPact>(result);
        }
    }
}
