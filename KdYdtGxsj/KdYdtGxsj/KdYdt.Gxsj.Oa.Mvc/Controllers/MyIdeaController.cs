using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KdCore;
using KdYdt.Gxsj.Oa.Domains.Models;

namespace KdYdt.Gxsj.Oa.Mvc.Controllers
{
    /// <summary>
    /// 快捷意见管理
    /// </summary>
    [KdUnitGroup("快捷意见", 10550)]
    public class MyIdeaController : KdBaseOaController
    {
        [KdAction(EveryUser = true)]
        public ActionResult Index(string id)
        {
            return this.DataListView<OaQuickIdea>(x => x.CreatorUserId == this.CurrUser.Id);
        }

        /// <summary>
        /// 快捷审批意见
        /// </summary>
        /// <returns></returns> 
        [KdAction("编辑", EveryUser = true)]
        public ActionResult Edit(string id)
        {
            OaQuickIdea idea = this.DbService.DbView<OaQuickIdea>(id);
            return this.View(idea);
        }

        /// <summary>
        /// 快捷审批意见
        /// </summary>
        /// <returns></returns> 
        [KdAction("快捷审批意见", EveryUser = true)]
        [HttpPost]
        public ActionResult Edit(OaQuickIdea idea)
        {
            OaQuickIdea dbIdea = this.DbService.DbView<OaQuickIdea>(idea.Id);
            dbIdea.Notes = idea.Notes;
            dbIdea.TagDisabled = idea.TagDisabled;
            dbIdea.SortNum = idea.SortNum;
            this.CurrUser.MarkModifier(dbIdea);
            return this.JsonResult(this.DbService.SaveResult(dbIdea, idea));
        }

        [KdAction("删除", EveryUser = true)]
        [HttpPost]
        public virtual ActionResult Delete(string[] ids)
        {
            return this.JsonDelete<OaQuickIdea>(ids);
        }
    }
}
