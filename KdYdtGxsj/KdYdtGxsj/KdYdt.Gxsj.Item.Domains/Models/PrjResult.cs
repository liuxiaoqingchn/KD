using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    public class PrjResult : KdEntityCommon
    {
        /// <summary>
        /// 中标通知书编号
        /// </summary>
        [Display(Name = "中标通知书编号")]
        public virtual string NoticeNum { get; set; }
        /// <summary>
        ///发放日期
        /// </summary>
        [Display(Name = "发放日期")]
        public virtual DateTime? IssuanceDate { get; set; }
        /// <summary>
        /// 中标金额
        /// </summary>
        [Display(Name = "中标金额")]
        public virtual decimal? BidAmount { get; set; }
        /// <summary>
        /// 中标单位
        /// </summary>
        [Display(Name = "中标单位")]
        public virtual string WinBidUnit { get; set; }
        /// <summary>
        /// 跟踪人
        /// </summary>
        [Display(Name = "跟踪人")]
        public virtual string Tracer { get; set; }
        /// <summary>
        /// 领取人
        /// </summary>
        [Display(Name = "领取人")]
        public virtual string Claim { get; set; }
        /// <summary>
        /// 是否中标
        /// </summary>
        [Display(Name = "是否中标")]
        public virtual string  IsBid { get; set; }
    }
}
