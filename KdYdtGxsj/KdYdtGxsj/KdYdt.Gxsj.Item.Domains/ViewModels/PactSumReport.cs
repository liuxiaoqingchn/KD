using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    /// <summary>
    /// 合同汇总
    /// </summary>
    public class PactSumReport 
    {
        /// <summary>
        /// 月份
        /// </summary>
        public virtual int[] Months { get; set; }
        /// <summary>
        /// 跟标人
        /// </summary>
        public virtual string WinBidUnit { get; set; }
        /// <summary>
        /// 经营方式
        /// </summary>
        public virtual string OperationMode { get; set; }
        /// <summary>
        /// 合同数量
        /// </summary>
        public virtual int[] PactNum { get; set; }
        /// <summary>
        /// 合同金额
        /// </summary>
        public virtual decimal[] PactAmount { get; set; }

        /// <summary>
        /// 自营合同数量
        /// </summary>
        public virtual int[] zyPactNum { get; set; }
        /// <summary>
        /// 自营合同金额
        /// </summary>
        public virtual decimal[] zyPactAmount { get; set; }
        /// <summary>
        /// 联营合同数量
        /// </summary>
        public virtual int[] lyPactNum { get; set; }
        /// <summary>
        /// 联营合同金额
        /// </summary>
        public virtual decimal[] lyPactAmount { get; set; }

    }
}
