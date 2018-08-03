using System.Web.Mvc;

using KdCore.Data;
using KdCore.Data.EditModels;
using KdCore.Data.Entity;
using KdCore.Web.Mvc;

using KdYdt.Gxsj.Item.Domains.Services;
using System.Collections.Generic;
using KdYdt.Gxsj.Item.Domains.Assist;
using System;

namespace KdYdt.Gxsj.Item.Mvc.Areas
{
    public abstract class ItemBaseController : KdBaseController<PrjDbItemService>
    {
        /// <summary>
        /// 设置页面标签
        /// </summary>
        /// <param name="type"></param>
        protected void BdTabHeader(EnumPaySum enumSum)
        {
            List<SelectListItem> headers = new List<SelectListItem>();
            foreach (EnumPaySum enumPayType in Enum.GetValues(typeof(EnumPaySum)))
            {
                if (enumPayType == EnumPaySum.None) continue;
                SelectListItem item = new SelectListItem
                {
                    Text = enumPayType.ToString(),
                    Selected = enumPayType == enumSum,
                    Value = this.Url.Action("Index", new { paySumType = (int)enumPayType })
                };
                headers.Add(item);
            }
            this.ViewData["TabHeaders"] = headers;
        }
    }

    public abstract class ItemBaseController<TEntity, TEditModel>
        : KdEntityController<PrjDbItemService, TEntity, TEditModel>
        where TEntity : class, IKdEntityModify, IKdEntityFollow, new()
        where TEditModel : KdBaseEdit, new()
    {
        [KdAction("查阅")]
        [HttpGet]
        public override ActionResult Index(string id)
        {
            return base.Index(id);
        }
        [KdAction("查阅")]
        [HttpGet]
        public override ActionResult Edit(string id)
        {
            return base.Edit(id);
        }
        [KdAction("编辑")]
        [HttpPost]
        public override ActionResult Edit(TEditModel editModel)
        {
            return base.Edit(editModel);
        }
        [KdAction("删除")]
        [HttpPost]
        public override ActionResult Delete(string[] ids)
        {
            return base.Delete(ids);
        }

    }
}
