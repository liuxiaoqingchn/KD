using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    public class BidResultEdit : KdEntityBase
    {           
        /// <summary>
        /// 是否中标
        /// </summary>
        [Display(Name = "是否中标")]
        public virtual bool? IsBid { get; set; }
        /// <summary>
        /// 中标通知书编号
        /// </summary>
        [Display(Name = "中标通知书编号")]
        [MaxLength(100)]
        public virtual string NoticeCode { get; set; }
        /// <summary>
        /// 中标日期
        /// </summary>
        [Display(Name = "中标日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? BidDate { get; set; }
        /// <summary>
        /// 中标金额
        /// </summary>
        [Display(Name = "中标金额")]
        public virtual decimal? BidMoney { get; set; }
        /// <summary>
        /// 中标单位
        /// </summary>
        [Display(Name = "中标单位")]
        [MaxLength(200)]
        public virtual string BidUnit { get; set; }
        /// <summary>
        /// 跟标人ID
        /// </summary>
        [Display(Name = "跟标人")]
        [MaxLength(50)]
        public virtual string WithPersonId { get; set; }
        /// <summary>
        /// 跟标人姓名
        /// </summary>
        [Display(Name = "跟标人")]
        [MaxLength(50)]
        public virtual string WithPersonName { get; set; }
        /// <summary>
        /// 通知书领取人ID
        /// </summary>
        [Display(Name = "通知书领取人")]
        [MaxLength(50)]
        public virtual string ReceiveId { get; set; }
        /// <summary>
        /// 通知书领取人姓名
        /// </summary>
        [Display(Name = "通知书领取人")]
        [MaxLength(50)]
        public virtual string ReceiveName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string ResultExplain { get; set; }
    }
}
