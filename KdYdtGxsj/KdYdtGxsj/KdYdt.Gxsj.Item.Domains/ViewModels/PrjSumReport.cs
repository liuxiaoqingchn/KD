using KdCore.Data;
using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    /// <summary>
    /// 项目汇总
    /// </summary>
    public class PrjSumReport
    {
        /// <summary>
        /// 月份
        /// </summary>
        public virtual int[] Months { get; set; }
        /// <summary>
        /// 招标方式
        /// </summary>
        public virtual string Tender { get; set; }
        /// <summary>
        /// 立项数量
        /// </summary>
        public virtual int[] ItemNumsjyzx { get; set; }
        /// <summary>
        /// 投标数量
        /// </summary>
        public virtual int[] Bidjyzx { get; set; }
        /// <summary>
        /// 中标数量
        /// </summary>
        public virtual int[] WinBidNumsjyzx { get; set; }
        /// <summary>
        /// 中标金额
        /// </summary>
        public virtual decimal[] BidAmountjyzx { get; set; }
        /// <summary>
        /// 立项数量
        /// </summary>
        public virtual int[] ItemNumszfcg { get; set; }
        /// <summary>
        /// 投标数量
        /// </summary>
        public virtual int[] Bidzfcg { get; set; }
        /// <summary>
        /// 中标数量
        /// </summary>
        public virtual int[] WinBidNumszfcg { get; set; }
        /// <summary>
        /// 中标金额
        /// </summary>
        public virtual decimal[] BidAmountzfcg { get; set; }
        /// <summary>
        /// 立项数量
        /// </summary>
        public virtual int[] ItemNumsztb { get; set; }
        /// <summary>
        /// 投标数量
        /// </summary>
        public virtual int[] Bidztb { get; set; }
        /// <summary>
        /// 中标数量
        /// </summary>
        public virtual int[] WinBidNumsztb { get; set; }
        /// <summary>
        /// 中标金额
        /// </summary>
        public virtual decimal[] BidAmountztb { get; set; }
        ///// <summary>
        ///// 中标总金额
        ///// </summary>
        //public virtual decimal[] BidTotalAmount { get; set; }
        ///// <summary>
        ///// 立项总量
        ///// </summary>
        //public virtual int[] ItemSums { get; set; }
        ///// <summary>
        ///// 投标总量
        ///// </summary>
        //public virtual int[] BidSums { get; set; }
        ///// <summary>
        ///// 中标总量
        ///// </summary>
        //public virtual int[] WinBidSums { get; set; }
    }
}
