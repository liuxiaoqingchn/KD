using System.Web.Mvc;
using KdCore;
using KdCore.Data;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;
using KdCore.Web.Mvc;
using KdYdt.Gxsj.Item.Domains.Assist;
using System.Linq;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    [KdUnitGroup("投标报名", 60, true)]
    public class PrjSignController : ItemBaseController<PrjSign, PrjSignEdit>
    {
        protected override void OnDataView<TEntity>()
        {
            base.OnDataView<TEntity>();
            this.SetSelectList<PrjSign, bool>(x => x.IsBond, "IsOpen");
            this.SetSelectList<PrjSign, bool>(x => x.IsTender, "IsOpen");
        }
        [KdAction("编辑")]
        [HttpPost]
        public override ActionResult Edit(PrjSignEdit editModel)
        {
            KdDataResult result = this.CheckModelState<PrjSign, PrjSignEdit>(editModel);
            if (result.Failure)
                return this.DataEntityView(result.Result as PrjSign);
            PrjSign entity = this.DbService.GetForSave<PrjSign, PrjSignEdit>(editModel);
            if (entity != null)
            {
                PrjPlan prj = this.DbService.ValidGet<PrjPlan>(entity.ProjectId);
                if (prj != null)
                {
                    //投标报名为true，不能再次投标报名；
                    prj.IsSign = true;
                    if (entity.IsNewData())
                    {
                        prj.PrjStatus = EnumPrjStatus.已投标;
                    }
                    this.DbService.Save(prj);

                    entity.DeliId = prj.DeliId;
                    entity.DeliUnit = prj.DeliUnit;
                    entity.PrjPersonId = prj.PrjPersonId;
                    entity.PrjPersonName = prj.PrjPersonName;
                    entity.ManageMode = prj.ManageMode;
                    entity.IsOpen = prj.IsOpen;
                }
                #region 投标报名后，数据存到任务安排里面
                PrjTask task = this.DbService.ValidQuery<PrjTask>(x => x.PrjCode == entity.PrjCode && x.PrjName == entity.PrjName).FirstOrDefault();
                if (task == null)
                {
                    task = new PrjTask();
                    task.SetId();
                    task.SaveMode = BbSaveMode.Insert;
                }
                else 
                    task.SaveMode = BbSaveMode.Update;
                    task.IsBond = entity.IsBond;
                    task.BondMoney = entity.BondMoney;
                    task.BondReturnDate = entity.BondReturnDate;
                    task.ProjectId = entity.Id;
                    task.PrjCode = entity.PrjCode;
                    task.PrjName = entity.PrjName;
                    task.BidManId = entity.BidManId;
                    task.BidMan = entity.BidMan;
                    task.SignDate = entity.SignDate;
                    this.DbService.Save(task);
                #endregion
                #region  投标报名后，数据同时存到结果跟踪里面（分为公开招标和非公开招标） 非公开   报名信息存进结果跟踪里
                BidResult bidresult = this.DbService.ValidQuery<BidResult>(x => x.ProjectId == entity.Id)
                    .FirstOrDefault();
                if (bidresult == null)
                {
                    bidresult = new BidResult();
                    bidresult.SetId();
                    bidresult.SaveMode = BbSaveMode.Insert;
                }
                else
                    bidresult.SaveMode = BbSaveMode.Update;
                if (entity.IsNewData())
                {
                    bidresult.PrjStatus = EnumPrjStatus.已投标;
                    entity.PrjStatus = EnumPrjStatus.已投标;
                }
                //把报名信息存到结果跟踪里面
                bidresult.ProjectId = entity.Id;
                bidresult.PrjName = entity.PrjName;
                bidresult.PrjCode = entity.PrjCode;
                bidresult.ManageMode = entity.ManageMode;
                bidresult.IsBond = entity.IsBond;
                bidresult.BondMoney = entity.BondMoney;
                bidresult.BondReturnDate = entity.BondReturnDate;
                bidresult.DeliId = entity.DeliId;
                bidresult.DeliUnit = entity.DeliUnit;
                bidresult.QualAuditMode = entity.QualAuditMode;
                bidresult.ReviewDate = entity.ReviewDate;
                bidresult.SignAddress = entity.SignAddress;
                bidresult.SignEndData = entity.SignEndData;
                bidresult.SignDate = entity.SignDate;
                bidresult.SignStartData = entity.SignStartData;
                bidresult.ResultDate = entity.ResultDate;
                bidresult.BidExplain = entity.BidExplain;
                bidresult.PrjPersonId = entity.PrjPersonId;
                bidresult.PrjPersonName = entity.PrjPersonName;
                this.DbService.Save(bidresult);
                #endregion
            }
            this.DbService.Save(entity);
            this.DbService.SaveChanges();
            return this.KdViewResult<PrjSign>(result);
        }
    }
}
