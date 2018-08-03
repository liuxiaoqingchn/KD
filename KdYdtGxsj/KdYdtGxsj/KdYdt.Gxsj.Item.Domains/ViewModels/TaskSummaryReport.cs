using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    public class TaskSummaryReport : KdEntityCommon
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string Manage { get; set; }
        /// <summary>
        /// 投标数量
        /// </summary>
        public virtual int Bid { get; set; }
        /// <summary>
        /// 保函或保证金
        /// </summary>
        public virtual int Bond { get; set; }
        /// <summary>
        /// 商务标
        /// </summary>
        public virtual int BusinessBid { get; set; }
        /// <summary>
        /// 技术标
        /// </summary>
        public virtual int TechBid { get; set; }
        /// <summary>
        /// 封标
        /// </summary>
        public virtual int SealBid { get; set; }
        /// <summary>
        /// 资信标
        /// </summary>
        public virtual int CreditBid { get; set; }
        /// <summary>
        /// 设计标
        /// </summary>
        public virtual int DesignBid { get; set; }
        /// <summary>
        /// 总计
        /// </summary>
        public virtual int BidSum { get; set; }



    }
}
