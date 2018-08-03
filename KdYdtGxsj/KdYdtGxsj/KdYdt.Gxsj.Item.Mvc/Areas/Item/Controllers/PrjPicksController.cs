using System.Web.Mvc;
using KdYdt.Gxsj.Item.Domains.Models;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 弹出选择框
    /// </summary>
    public class PrjPicksController : ItemBaseController
    {
        /// <summary>
        /// 项目信息，未投标
        /// </summary>
        /// <returns></returns>
        public ActionResult PrjItemPick()
        {
            return this.DataListView<PrjItem>();
        }
        /// <summary>
        /// 项目立项
        /// </summary>
        /// <returns></returns>
        public ActionResult PrjPlanPick()
        {
            return this.DataListView<PrjPlan>(x => !x.IsOpen && x.IsSign == false);
        }
        /// <summary>
        /// 企业库
        /// </summary>
        /// <returns></returns>
        public ActionResult PrjCorpPick()
        {
            return this.DataListView<PrjCorp>();
        }
        /// <summary>
        /// 人员库（没有在建工程）
        /// </summary>
        /// <returns></returns>
        public ActionResult PrjPersonPick()
        {
            return this.DataListView<PrjPerson>(x => !x.ISLocking);
        }
        /// <summary>
        /// 有投标报名的项目（已经中标）
        /// </summary>
        /// <returns></returns>
        public ActionResult PrjSignPick()
        {
            return this.DataListView<PrjPlan>(x => x.IsSign);
        }
        /// <summary>
        /// 投标报名的项目
        /// </summary>
        /// <returns></returns>
        public ActionResult PrjIsSignPick()
        {
            return this.DataListView<PrjSign>();
        }
        /// <summary>
        /// 合同选择 结果跟踪的信息 （中标）
        /// </summary>
        /// <returns></returns>
        public ActionResult PrjBidPick()
        {
            return this.DataListView<BidResult>(x=>x.IsBid== "中标");/*&&x.IsOpen!=true*/
        }

        /// <summary>
        /// 项目立项中公开招标的项目(没用到  后期可能会连带弹出框页面一起删除)
        /// </summary>
        /// <returns></returns>
        public ActionResult PrjPlanOpen()
        {
            return this.DataListView<PrjPlan>(x => x.IsOpen);
        }
    }
}
