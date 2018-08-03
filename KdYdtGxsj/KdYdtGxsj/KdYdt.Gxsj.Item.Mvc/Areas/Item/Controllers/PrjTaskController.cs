using System;
using System.Web.Mvc;
using KdCore;
using KdCore.Data;
using KdCore.Data.Users;
using KdCore.Web.Mvc;
using KdYdt.Gxsj.Item.Domains.Assist;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;
using System.Collections.Generic;
using System.Linq;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 任务安排
    /// </summary>
    [KdUnitGroup("工作安排", 90, true)]
    public class PrjTaskController : ItemBaseController<PrjTask, PrjTaskEdit>
    {
        protected override void OnDataView<TEntity>()
        {
            base.OnDataView<TEntity>();
            this.SetSelectList<PrjTask, bool>(x => x.IsBond, "IsOpen");
        }
        public override ActionResult Index(string id)
        {
            return base.DataListView<PrjTask>();
        }
        [HttpGet]
        public override ActionResult Edit(string id)
        {
            return base.Edit(id);
        }
        [HttpPost]
        [KdAction("编辑")]
        public override ActionResult Edit(PrjTaskEdit editModel)
        {
            KdDataResult result = this.CheckModelState<PrjTask, PrjTaskEdit>(editModel);
            if (result.Failure)
                return this.DataEntityView(result.Result as PrjTask);
            PrjTask entity = this.DbService.GetForSave<PrjTask, PrjTaskEdit>(editModel);
            if (entity == null) return this.DataEntityView(result.Result as PrjTask);

            if (entity.IsLssued)
            {
                #region 任务下达时新增各任务数据
                var userService = this.GetDataService<KdCore.Data.DbServices.KdDbAuthsService>();
                KdUser user = this.Session.GetCurrUser() as KdUser;
                if (user != null)
                {
                    entity.TaskPersonId = user.Id;
                    entity.TaskPersonName = user.RealName;
                    entity.TaskTime = DateTime.Now;
                }
                #region     保存技术标       
                if (!string.IsNullOrWhiteSpace(entity.SkillName))
                {
                    PrjBiding biding = this.DbService
                                      .ValidQuery<PrjBiding>(x => x.PrjTaskId == entity.Id && x.BidingType == EnumBidingType.技术标)
                                      .FirstOrDefault();
                    if (biding == null)
                    {
                        biding = new PrjBiding();
                        biding.SetId();
                        biding.BidManId = entity.BidManId;
                        biding.BidMan = entity.BidMan;
                        biding.SignDate = entity.SignDate;
                        biding.TaskStatus = EnumTaskStatus.未开始;
                    }
                    else
                        biding.SaveMode = BbSaveMode.Update;
                    biding.PrjTaskId = entity.Id;
                    biding.BidingType = EnumBidingType.技术标;
                    biding.ProjectId = entity.ProjectId;
                    biding.PrjCode = entity.PrjCode;
                    biding.PrjName = entity.PrjName;
                    biding.IsSuspend = entity.IsLssued;
                    biding.TaskPersonId = entity.TaskPersonId;
                    biding.TaskPersonName = entity.TaskPersonName;
                    biding.TaskTime = entity.TaskTime;
                    biding.MakeId = entity.SkillId;
                    biding.MakeName = entity.SkillName;
                    biding.PlanTime = entity.SkillTime;
                    biding.BidManId = entity.BidManId;
                    biding.BidMan = entity.BidMan;
                    biding.SignDate = entity.SignDate;
                    if (biding.IsNewData())
                    {
                        KdUser bidingUser = userService.ValidGet<KdUser>(biding.MakeId);
                        if (bidingUser != null)
                        {
                            bidingUser.MarkCreator(biding);
                            bidingUser.MarkModifier(biding);
                        }
                        else
                        {
                            user.MarkCreator(biding);
                            user.MarkModifier(biding);
                        }
                        this.DbService.DbAdd(biding);
                    }
                    else
                    {
                        this.DbService.Save(biding);
                    }
                }
                //else
                //{
                //    return RedirectIndex();
                //}
                #endregion

                #region         保存商务标

                if (!string.IsNullOrWhiteSpace(entity.BusinessName))
                {

                    PrjBiding prjBiding = this.DbService.ValidQuery<PrjBiding>(x => x.PrjTaskId == entity.Id && x.BidingType == EnumBidingType.商务标).FirstOrDefault();
                    if (prjBiding == null)
                    {
                        prjBiding = new PrjBiding();
                        prjBiding.SetId();
                        prjBiding.BidManId = entity.BidManId;
                        prjBiding.BidMan = entity.BidMan;
                        prjBiding.SignDate = entity.SignDate;
                        prjBiding.TaskStatus = EnumTaskStatus.未开始;
                    }
                    else
                        prjBiding.SaveMode = BbSaveMode.Update;
                    prjBiding.PrjTaskId = entity.Id;
                    prjBiding.ProjectId = entity.ProjectId;
                    prjBiding.PrjCode = entity.PrjCode;
                    prjBiding.PrjName = entity.PrjName;
                    prjBiding.BidingType = EnumBidingType.商务标;
                    prjBiding.IsSuspend = entity.IsLssued;
                    prjBiding.TaskPersonId = entity.TaskPersonId;
                    prjBiding.TaskPersonName = entity.TaskPersonName;
                    prjBiding.TaskTime = entity.TaskTime;
                    prjBiding.MakeId = entity.BusinessId;
                    prjBiding.MakeName = entity.BusinessName;
                    prjBiding.PlanTime = entity.BusinessTime;
                    prjBiding.BidManId = entity.BidManId;
                    prjBiding.BidMan = entity.BidMan;
                    prjBiding.SignDate = entity.SignDate;
                    if (prjBiding.IsNewData())
                    {
                        KdUser bidingUser = userService.ValidGet<KdUser>(prjBiding.MakeId);
                        if (bidingUser != null)
                        {
                            bidingUser.MarkCreator(prjBiding);
                            bidingUser.MarkModifier(prjBiding);
                        }
                        else
                        {
                            user.MarkCreator(prjBiding);
                            user.MarkModifier(prjBiding);
                        }
                        this.DbService.DbAdd(prjBiding);
                    }
                    else
                    {
                        this.DbService.Save(prjBiding);
                    }
                }
                #endregion

                #region 保存封标
                if (!string.IsNullOrWhiteSpace(entity.SealName))
                {
                    PrjBiding prj = this.DbService.ValidQuery<PrjBiding>(x => x.PrjTaskId == entity.Id && x.BidingType == EnumBidingType.封标).FirstOrDefault();
                    if (prj == null)
                    {
                        prj = new PrjBiding();
                        prj.SetId();
                        prj.BidManId = entity.BidManId;
                        prj.BidMan = entity.BidMan;
                        prj.SignDate = entity.SignDate;
                        prj.TaskStatus = EnumTaskStatus.未开始;
                    }
                    else
                        prj.SaveMode = BbSaveMode.Update;
                    prj.PrjTaskId = entity.Id;
                    prj.ProjectId = entity.ProjectId;
                    prj.PrjCode = entity.PrjCode;
                    prj.PrjName = entity.PrjName;
                    prj.BidingType = EnumBidingType.封标;
                    prj.IsSuspend = entity.IsLssued;
                    prj.TaskPersonId = entity.TaskPersonId;
                    prj.TaskPersonName = entity.TaskPersonName;
                    prj.TaskTime = entity.TaskTime;
                    prj.MakeId = entity.SealId;
                    prj.MakeName = entity.SealName;
                    prj.PlanTime = entity.SealTime;
                    prj.BidManId = entity.BidManId;
                    prj.BidMan = entity.BidMan;
                    prj.SignDate = entity.SignDate;
                    if (prj.IsNewData())
                    {
                        KdUser bidingUser = userService.ValidGet<KdUser>(prj.MakeId);
                        if (bidingUser != null)
                        {
                            bidingUser.MarkCreator(prj);
                            bidingUser.MarkModifier(prj);
                        }
                        else
                        {
                            user.MarkCreator(prj);
                            user.MarkModifier(prj);
                        }
                        this.DbService.DbAdd(prj);
                    }
                    else
                    {
                        this.DbService.Save(prj);
                    }
                }
                #endregion

                #region 保存资信标
                if (!string.IsNullOrWhiteSpace(entity.CreditName))
                {
                    PrjBiding prjcre = this.DbService.ValidQuery<PrjBiding>(x => x.PrjTaskId == entity.Id && x.BidingType == EnumBidingType.资信标).FirstOrDefault();
                    if (prjcre == null)
                    {
                        prjcre = new PrjBiding();
                        prjcre.SetId();
                        prjcre.BidManId = entity.BidManId;
                        prjcre.BidMan = entity.BidMan;
                        prjcre.SignDate = entity.SignDate;
                        prjcre.TaskStatus = EnumTaskStatus.未开始;
                    }
                    else
                        prjcre.SaveMode = BbSaveMode.Update;
                    prjcre.PrjTaskId = entity.Id;
                    prjcre.ProjectId = entity.ProjectId;
                    prjcre.PrjCode = entity.PrjCode;
                    prjcre.PrjName = entity.PrjName;
                    prjcre.BidingType = EnumBidingType.资信标;
                    prjcre.IsSuspend = entity.IsLssued;
                    prjcre.TaskPersonId = entity.TaskPersonId;
                    prjcre.TaskPersonName = entity.TaskPersonName;
                    prjcre.TaskTime = entity.TaskTime;
                    prjcre.MakeId = entity.CreditId;
                    prjcre.MakeName = entity.CreditName;
                    prjcre.PlanTime = entity.CreditTime;
                    prjcre.BidManId = entity.BidManId;
                    prjcre.BidMan = entity.BidMan;
                    prjcre.SignDate = entity.SignDate;
                    if (prjcre.IsNewData())
                    {
                        KdUser bidingUser = userService.ValidGet<KdUser>(prjcre.MakeId);
                        if (bidingUser != null)
                        {
                            bidingUser.MarkCreator(prjcre);
                            bidingUser.MarkModifier(prjcre);
                        }
                        else
                        {
                            user.MarkCreator(prjcre);
                            user.MarkModifier(prjcre);
                        }
                        this.DbService.DbAdd(prjcre);
                    }
                    else
                    {
                        this.DbService.Save(prjcre);
                    }
                }
                #endregion

                #region 保存设计标
                if (!string.IsNullOrWhiteSpace(entity.CreditName))
                {
                    PrjBiding prjdes = this.DbService.ValidQuery<PrjBiding>(x => x.PrjTaskId == entity.Id && x.BidingType == EnumBidingType.设计标).FirstOrDefault();
                    if (prjdes == null)
                    {
                        prjdes = new PrjBiding();
                        prjdes.SetId();
                        prjdes.BidManId = entity.BidManId;
                        prjdes.BidMan = entity.BidMan;
                        prjdes.SignDate = entity.SignDate;
                        prjdes.TaskStatus = EnumTaskStatus.未开始;
                    }
                    else
                        prjdes.SaveMode = BbSaveMode.Update;
                    prjdes.PrjTaskId = entity.Id;
                    prjdes.ProjectId = entity.ProjectId;
                    prjdes.PrjCode = entity.PrjCode;
                    prjdes.PrjName = entity.PrjName;
                    prjdes.BidingType = EnumBidingType.设计标;
                    prjdes.IsSuspend = entity.IsLssued;
                    prjdes.TaskPersonId = entity.TaskPersonId;
                    prjdes.TaskPersonName = entity.TaskPersonName;
                    prjdes.TaskTime = entity.TaskTime;
                    prjdes.MakeId = entity.DesignId;
                    prjdes.MakeName = entity.DesignName;
                    prjdes.PlanTime = entity.DesignTime;
                    prjdes.BidManId = entity.BidManId;
                    prjdes.BidMan = entity.BidMan;
                    prjdes.SignDate = entity.SignDate;
                    
                    if (prjdes.IsNewData())
                    {
                        KdUser bidingUser = userService.ValidGet<KdUser>(prjdes.MakeId);
                        if (bidingUser != null)
                        {
                            bidingUser.MarkCreator(prjdes);
                            bidingUser.MarkModifier(prjdes);
                        }
                        else
                        {
                            user.MarkCreator(prjdes);
                            user.MarkModifier(prjdes);
                        }
                        this.DbService.DbAdd(prjdes);
                    }
                    else
                    {
                        this.DbService.Save(prjdes);
                    }
                }
                #endregion

                #region 保存保函或保证金
                if (!string.IsNullOrWhiteSpace(entity.LetterName))
                {
                    PrjBond bond = this.DbService.ValidQuery<PrjBond>(x => x.PrjTaskId == entity.Id).FirstOrDefault();
                    if (bond == null)
                    {
                        bond = new PrjBond();
                        bond.SetId();
                        bond.TaskStatus = EnumTaskStatus.未开始;
                    }
                    else
                        bond.SaveMode = BbSaveMode.Update;
                    bond.PrjTaskId = entity.Id;
                    bond.ProjectId = entity.ProjectId;
                    bond.PrjCode = entity.PrjCode;
                    bond.PrjName = entity.PrjName;
                    bond.IsSuspend = entity.IsLssued;
                    bond.TaskPersonId = entity.TaskPersonId;
                    bond.TaskPersonName = entity.TaskPersonName;
                    bond.TaskTime = entity.TaskTime;
                    bond.MakeId = entity.LetterId;
                    bond.MakeName = entity.LetterName;
                    bond.PlanTime = entity.LetterTime;
                    bond.IsBond = entity.IsBond;
                    bond.BondMoney = entity.BondMoney;
                    bond.BondReturnDate = entity.BondReturnDate;

                    if (bond.IsNewData())
                    {
                        KdUser bidingUser = userService.ValidGet<KdUser>(bond.MakeId);
                        if (bidingUser != null)
                        {
                            bidingUser.MarkCreator(bond);
                            bidingUser.MarkModifier(bond);
                        }
                        else
                        {
                            user.MarkCreator(bond);
                            user.MarkModifier(bond);
                        }
                        this.DbService.DbAdd(bond);
                    }
                    else
                    {
                        this.DbService.Save(bond);
                    }
                }
                #endregion

                #endregion
            }
            this.DbService.Save(entity);
            this.DbService.SaveChanges();
            return this.KdViewResult<PrjTask>(result);
        }
        [KdAction("编辑")]
        [HttpPost]
        public virtual ActionResult Lssued(string id)
        {
            PrjTask entity = this.DbService.ValidGet<PrjTask>(id);
            if (entity != null)
            {
                entity.IsLssued = false;

                List<PrjBiding> bidings = this.DbService
                    .ValidQuery<PrjBiding>(x => !x.IsSuspend && x.PrjTaskId == entity.Id)
                    .ToList();
                if (bidings.NotEmpty())
                    this.DbService.UpdateRange(bidings, x => x.IsSuspend = true);

                PrjBond bond = this.DbService.ValidQuery<PrjBond>(x => x.PrjTaskId == entity.Id)
                    .FirstOrDefault();
                if (bond != null)
                {
                    bond.IsSuspend = true;
                    this.DbService.Update(bond);
                }
                this.DbService.Update(entity);
                this.DbService.SaveChanges();
            }
            return this.RedirectToAction("Edit", new { id = entity.Id });
        }
    }
}
