using KdCore;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.EditModels;
using System.Web.Mvc;
using System.Linq;
using System;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    [KdUnitGroup("项目跟踪", 20)]
    public class PrjTrackController : ItemBaseController<PrjPlan, PrjPlanEdit>
    {
        protected override void OnDataEntityView(PrjPlan entity)
        {
            entity.SignItem = this.DbService.ValidQuery<PrjSign>(x => x.ProjectId == entity.Id).FirstOrDefault();
            entity.TaskItem = this.DbService.ValidQuery<PrjTask>(x => x.PrjCode == entity.PrjCode && x.PrjName == entity.PrjName && x.IsLssued==true).FirstOrDefault();
            entity.ResultItem = this.DbService.ValidQuery<BidResult>(x => x.PrjCode == entity.PrjCode && x.PrjName == entity.PrjName&&x.IsBid!=null).FirstOrDefault();
            entity.PactItem = this.DbService.ValidQuery<PayPact>(x => x.PrjCode == entity.PrjCode && x.PrjName == entity.PrjName).FirstOrDefault();
            entity.PrjBidItem= this.DbService.ValidQuery<PrjBiding>(x => x.PrjCode
            == entity.PrjCode && x.PrjName == entity.PrjName)
                .ToList();
            base.OnDataEntityView(entity);
        }
        /// <summary>
        /// 获取默认排序设置
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        protected override string GetSortDefault(Type type, string actionCode)
        {
            return "-ProjectDate;-PrjStatus"; 
        }
    }
}
