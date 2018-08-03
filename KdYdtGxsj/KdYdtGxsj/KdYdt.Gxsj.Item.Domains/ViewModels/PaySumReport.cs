using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    /// <summary>
    /// 费用汇总
    /// </summary>
    public class PaySumReport : KdEntityCommon
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public virtual string Prj { get; set; }
        /// <summary>
        /// 标书费
        /// </summary>
        public virtual decimal? BSfee { get; set; }
        /// <summary>
        /// 保函或保证金
        /// </summary>
        public virtual decimal? Bondfee { get; set; }

        /// <summary>
        /// 项目经理配合费
        /// </summary>
        public virtual decimal? Managefee { get; set; }
        /// <summary>
        /// 资料费
        /// </summary>
        public virtual decimal? Materialfee { get; set; }
        /// <summary>
        /// 电子、展板样品费
        /// </summary>
        public virtual decimal? Samplefee { get; set; }
        /// <summary>
        /// 招标代理服务费
        /// </summary>
        public virtual decimal? Bidfee { get; set; }
        /// <summary>
        /// 差旅食宿费
        /// </summary>
        public virtual decimal? Travelfee { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        public virtual decimal? Otherfee { get; set; }
        /// <summary>
        /// 总计
        /// </summary>
        public virtual decimal? BidSumfee { get; set; }
        #region 收入

        /// <summary>
        /// 标书费
        /// </summary>
        public virtual decimal? BSInc { get; set; }
        /// <summary>
        /// 项目经理配合费
        /// </summary>
        public virtual decimal? ManageInc { get; set; }
        /// <summary>
        /// 资料费
        /// </summary>
        public virtual decimal? MaterialInc { get; set; }
        /// <summary>
        /// 管理费
        /// </summary>
        public virtual decimal? AdminInc { get; set; }
        /// <summary>
        /// 项目预计利润
        /// </summary>
        public virtual decimal? PrjExpInc { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        public virtual decimal? OtherInc { get; set; }
        /// <summary>
        /// 总计
        /// </summary>
        public virtual decimal? BidSumInc { get; set; }
        #endregion

        //#region  总计
        ///// <summary>
        ///// 标书费
        ///// </summary>
        //public virtual decimal? BSfeeSum { get; set; }
        ///// <summary>
        ///// 保函或保证金
        ///// </summary>
        //public virtual decimal? BondfeeSum { get; set; }

        ///// <summary>
        ///// 项目经理配合费
        ///// </summary>
        //public virtual decimal? ManagefeeSum { get; set; }
        ///// <summary>
        ///// 资料费
        ///// </summary>
        //public virtual decimal? MaterialfeeSum { get; set; }
        ///// <summary>
        ///// 电子、展板样品费
        ///// </summary>
        //public virtual decimal? SamplefeeSum { get; set; }
        ///// <summary>
        ///// 招标代理服务费
        ///// </summary>
        //public virtual decimal? BidfeeSum { get; set; }
        ///// <summary>
        ///// 差旅食宿费
        ///// </summary>
        //public virtual decimal? TravelfeeSum { get; set; }
        ///// <summary>
        ///// 其他
        ///// </summary>
        //public virtual decimal? OtherfeeSum { get; set; }
        ///// <summary>
        ///// 总计
        ///// </summary>
        //public virtual decimal? BidSumfeeSum { get; set; }
        //#endregion
        //#region 收入总计

        ///// <summary>
        ///// 标书费
        ///// </summary>
        //public virtual decimal? BSIncSum { get; set; }
        ///// <summary>
        ///// 项目经理配合费
        ///// </summary>
        //public virtual decimal? ManageIncSum { get; set; }
        ///// <summary>
        ///// 资料费
        ///// </summary>
        //public virtual decimal? MaterialIncSum { get; set; }
        ///// <summary>
        ///// 管理费
        ///// </summary>
        //public virtual decimal? AdminIncSum { get; set; }
        ///// <summary>
        ///// 项目预计利润
        ///// </summary>
        //public virtual decimal? PrjExpIncSum { get; set; }
        ///// <summary>
        ///// 其他
        ///// </summary>
        //public virtual decimal? OtherIncSum { get; set; }
        ///// <summary>
        ///// 总计
        ///// </summary>
        //public virtual decimal? BidSumIncSum { get; set; }
        //#endregion
    }
}
