using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    /// <summary>
    /// 收入汇总
    /// </summary>
    public class IncomeSumReport : KdEntityCommon
    {
        #region 收入
        /// <summary>
        /// 项目名称
        /// </summary>
        public virtual string Prj { get; set; }
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
    }
}
