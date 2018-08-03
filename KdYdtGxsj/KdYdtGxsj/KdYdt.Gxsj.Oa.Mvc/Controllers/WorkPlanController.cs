using System.Web.Mvc;

using KdCore;

using KdYdt.Gxsj.Oa.Domains.Reports;
using KdYdt.Gxsj.Oa.Domains.ViewModels;

namespace KdYdt.Gxsj.Oa.Mvc.Controllers
{
    /// <summary>
    /// 一周计划
    /// </summary>
    [KdUnitGroup("一周计划", 60)]
    public class WorkPlanController : KdBaseOaController
    {
        [KdAction("查阅")]
        public virtual ActionResult Index(int? id)
        {
            OaWorkPlanWeek week = this.DbService.GetWorkPlanWeek(this.CurrUser, id);
            return this.KdView(week);
        }

        [KdAction("填报", EveryUser = true)]
        [HttpPost]
        public virtual ActionResult Edit(string id, string isSubmit, FormCollection form)
        {
            int? index = id.ToInt(-1);
            OaWorkPlanWeek week = this.DbService.SaveWorkPlan(index, form);
            if (isSubmit.ToBool())
                this.DbService.SubmitWorkPlan(index);
            return this.RedirectIndex(new { id });
        }

        [KdAction("汇总统计")]
        [HttpGet]
        public ActionResult Report(string id)
        {
            OaWorkPlanReport report = this.InitDataReport<OaWorkPlanReport>("工作计划安排汇总统计.xls");
            this.DbService.ReportWorkPlan(report, id);
            return this.KdFileReport(report);
        }
    }
}
