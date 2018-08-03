using KdCore;
using KdCore.Data;
using KdCore.Web.Mvc;
using KdYdt.Gxsj.Item.Domains.Assist;
using KdYdt.Gxsj.Item.Domains.EditModels;
using KdYdt.Gxsj.Item.Domains.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    [KdUnitGroup("项目立项", 30)]
    public class PrjPlanController : ItemBaseController<PrjPlan, PrjPlanEdit>
    {
        protected override void OnDataView<TEntity>()
        {
            base.OnDataView<TEntity>();
            this.SetSelectList<PrjPlan, bool>(x => x.IsCons, "IsOpen");
        }

        [KdAction("编辑")]
        [HttpPost]
        public override ActionResult Edit(PrjPlanEdit editModel)
        {
            KdDataResult result = this.CheckModelState<PrjPlan, PrjPlanEdit>(editModel);
            if (result.Failure)
                return this.DataEntityView(result.Result as PrjPlan);
            PrjPlan edit = this.DbService.GetForSave<PrjPlan, PrjPlanEdit>(editModel);
            if (edit != null)
            {
                #region 立项时，选择公开招标，信息存到结果跟踪里面（公开招标的项目不需要投标报名）
                if (edit.IsOpen == true)
                {
                    BidResult bidresult = this.DbService.ValidQuery<BidResult>(x => x.ProjectId == edit.Id).FirstOrDefault();
                    if (bidresult == null)
                    {
                        bidresult = new BidResult();
                        bidresult.SetId();
                        bidresult.SaveMode = BbSaveMode.Insert;
                    }
                    else
                    {
                        bidresult.SaveMode = BbSaveMode.Update;
                    }
                    if (edit.IsNewData())
                    {
                        bidresult.PrjStatus = EnumPrjStatus.已立项;
                    }
                    bidresult.ProjectId = edit.Id;
                    bidresult.PrjCode = edit.PrjCode;
                    bidresult.PrjName = edit.PrjName;
                    bidresult.IsOpen = edit.IsOpen;
                    bidresult.ManageMode = edit.ManageMode;
                    this.DbService.Save(bidresult);
                }
                #endregion
                if (edit.IsNewData())
                {
                    edit.PrjStatus = EnumPrjStatus.已立项;
                }
                    //项目状态--已立项  
                    //edit.ProjectId = editModel.ProjectId;
                    //edit.IsOpen = editModel.IsOpen;
                    //edit.IsCons = editModel.IsCons;
                    //edit.PrjCode = editModel.PrjCode;
                }
            this.DbService.Save(edit);
            this.DbService.SaveChanges();
            return this.KdViewResult<PrjPlan>(result);
        }
    }
}