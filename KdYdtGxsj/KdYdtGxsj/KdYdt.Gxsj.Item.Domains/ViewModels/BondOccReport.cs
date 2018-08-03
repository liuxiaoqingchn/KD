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
    public class BondOccReport
    {
        /// <summary>
        /// 月份
        /// </summary>
        public virtual int[] Months { get; set; }
        /// <summary>
        /// 占用金额
        /// </summary>
        public virtual decimal[] OccAmount { get; set; }
        /// <summary>
        /// 项目数量
        /// </summary>
        public virtual int[]  OccNums{ get; set; }
    }
}
