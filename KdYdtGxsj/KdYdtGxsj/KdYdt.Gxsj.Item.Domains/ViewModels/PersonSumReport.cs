using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    public class PersonSumReport : KdEntityCommon
    {
        /// <summary>
        /// 项目经理
        /// </summary>
        public virtual string Manage { get; set; }
        /// <summary>
        /// 未投标项目
        /// </summary>
        public virtual int NotSginPrj { get; set; }
        /// <summary>
        /// 已投标项目
        /// </summary>
        public virtual int IsSginPrj { get; set; }
        /// <summary>
        /// 未中标项目
        /// </summary>
        public virtual int NotBidPrj { get; set; }
        /// <summary>
        /// 已中标项目
        /// </summary>
        public virtual int IsBidPrj { get; set; }
        /// <summary>
        /// 待签合同数量
        /// </summary>
        public virtual int NotPactNum { get; set; }
        /// <summary>
        /// 待签合同金额
        /// </summary>
        public virtual decimal NotPactMoney { get; set; }
        /// <summary>
        /// 已签合同数量
        /// </summary>
        public virtual int IsPactNum { get; set; }
        /// <summary>
        /// 已签合同金额
        /// </summary>
        public virtual decimal? IsPactMoney { get; set; }

    }
}
