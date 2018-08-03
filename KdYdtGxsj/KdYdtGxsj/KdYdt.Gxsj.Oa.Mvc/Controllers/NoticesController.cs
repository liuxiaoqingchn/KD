using System.Linq;
using System.Web.Mvc;
using KdCore;
using KdCore.Data;
using KdCore.Data.Tasks;
using KdYdt.Gxsj.Oa.Domains.Models;
using KdYdt.Gxsj.Oa.Domains.EditModels;

namespace KdYdt.Gxsj.Oa.Mvc.Controllers
{
    [KdUnitGroup("通知公告", 40, BbClientType.All)]
    [KdUnitConfig(UseUserTask = BbEnableType.Enable)]
    [KdUnitConfig(TaskIgnoreCount = BbEnableType.Disable, TaskOnlyView = BbEnableType.Disable)]
    public class NoticesController : KdBaseOaController
    {
        protected override void OnDataEntityView<TEntity>(TEntity entity)
        {
            base.OnDataEntityView(entity);

            OaNotice notice = entity as OaNotice;
            if (notice != null)
                this.ViewBag.PageSubTitle = notice.Subject;
        }

        [KdAction(EveryUser = true)]
        public ActionResult Index()
        {
            string taskType = this.UnitGroupTitle ?? "通知公告";
            IQueryable<KdUserTask> query = this.TaskProvider.QueryUserTasks(x => x.TaskType == taskType);
            if (!this.CurrUser.IsInnerAdminUser())
                query = query.Where(x => x.ReceiverId == this.CurrUser.Id);
            KdDataResponse<KdUserTask> model = this.GetDataResponse(query, true);
            return this.KdView(model);
        }

        [KdAction(WorkCodes = "Index")]
        [HttpGet]
        public ActionResult Detail(string id)
        {
            return this.DataEntityView<OaNotice>(id);
        }

        [KdAction]
        public ActionResult Manage()
        {
            if (this.ClientDevice.IsPc)
                return this.DataListView<OaNotice>();
            return this.RedirectIndex();
        }

        [KdAction]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (this.ClientDevice.IsPc)
                return this.DataEntityView<OaNotice>(id);
            return this.RedirectToAction("Detail", new { id });
        }

        /// <summary>
        /// 获取待办事项的选项设置
        /// </summary>
        /// <param name="taskSource"></param>
        /// <returns></returns>
        protected override IKdTaskOption GetTaskOption(IKdEntityKeyId taskSource)
        {
            IKdTaskOption option = base.GetTaskOption(taskSource);
            option.TaskUrl = this.Url.Action("Detail", new { id = option.SourceId });
            return option;
        }

        [KdAction]
        [HttpPost]
        public ActionResult Edit(OaNoticeEdit editModel)
        {
            KdDataResult result = this.CheckModelState<OaNotice, OaNoticeEdit>(editModel);
            if (result.Failure)
                return this.DataEntityView(result.Result as OaNotice);

            if (!string.IsNullOrWhiteSpace(editModel.MainBody))
                editModel.MainBody = this.Server.UrlDecode(editModel.MainBody);

            result = this.DbService.SaveNotice(editModel, this.GetTaskOption(editModel));
            if (result.Failure)
                return this.DataEntityView(result.Result as OaNotice);
            return this.RedirectToAction("Manage");
        }

        [KdAction]
        [HttpPost]
        public virtual ActionResult Delete(string[] ids)
        {
            KdDataResult result = this.DbService.DeleteNotice(ids);
            return this.JsonResult(result);
        }
    }
}
