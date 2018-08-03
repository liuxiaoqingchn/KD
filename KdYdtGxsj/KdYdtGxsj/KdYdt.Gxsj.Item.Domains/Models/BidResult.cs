using System;
using System.ComponentModel.DataAnnotations;
using KdCore.Data.Entity;
using KdYdt.Gxsj.Item.Domains.Assist;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    /// <summary>
    /// 结果跟踪
    /// </summary>
    public class BidResult : BaseProject
    {
        /// <summary>
        /// 项目进行状态
        /// </summary>                                  
        [Display(Name = "项目状态")]
        public virtual EnumPrjStatus PrjStatus { get; set; }
        /// <summary>
        /// 是否为保证金
        /// </summary>
        [Display(Name = "是否为保证金")]
        [KdPickSupply]
        public virtual bool IsBond { get; set; }
        /// <summary>
        /// 保证金
        /// </summary>
        [Display(Name = "保证金")]
        [KdPickSupply]
        public virtual decimal? BondMoney { get; set; }
        /// <summary>
        /// 是否公开招标
        /// </summary>
        [Required]
        [Display(Name = "是否公开招标")]
        [KdPickSupply]
        public virtual bool IsOpen { get; set; }
        /// <summary>
        /// 是否中标
        /// </summary>
        [Display(Name = "是否中标")]
        public virtual string IsBid { get; set; }
        /// <summary>
        /// 中标通知书编号
        /// </summary>
        [Display(Name = "中标通知书编号")]
        [MaxLength(100)]
        [KdPickSupply]
        public virtual string NoticeCode { get; set; }
        /// <summary>
        /// 中标日期
        /// </summary>
        [Display(Name = "中标日期")]
        [DataType(DataType.Date)]
        [KdPickSupply]
        public virtual DateTime? BidDate { get; set; }
        /// <summary>
        /// 中标金额
        /// </summary>
        [Display(Name = "中标金额")]
        [KdPickSupply]
        public virtual decimal? BidMoney { get; set; }
        /// <summary>
        /// 中标单位
        /// </summary>
        [Display(Name = "中标单位")]
        [MaxLength(200)]
        [KdPickSupply]
        public virtual string BidUnit { get; set; }
        /// <summary>
        /// 跟标人ID
        /// </summary>
        [Display(Name = "跟标人")]
        [MaxLength(50)]
        [KdPickSupply]
        public virtual string WithPersonId { get; set; }
        /// <summary>
        /// 跟标人姓名
        /// </summary>
        [Display(Name = "跟标人")]
        [MaxLength(50)]
        [KdPickSupply]
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
        /// <summary>
        /// 定标日期
        /// </summary>
        [Display(Name = "定标日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? ResultDate { get; set; }
        /// <summary>
        /// 报名开始日期
        /// </summary>
        [Display(Name = "报名开始日期")]
        [DataType(DataType.Date)]
        [KdPickSupply]
        public virtual DateTime? SignStartData { get; set; }
        /// <summary>
        /// 报名截止日期
        /// </summary>
        [Display(Name = "报名截止日期")]
        [DataType(DataType.Date)]
        [KdPickSupply]
        public virtual DateTime? SignEndData { get; set; }
        /// <summary>
        /// 投标日期
        /// </summary>
        [Display(Name = "投标日期")]
        [DataType(DataType.Date)]
        [KdPickSupply]
        public virtual DateTime? SignDate { get; set; }
        /// <summary>
        /// 报名地点
        /// </summary>
        [Display(Name = "报名地点")]
        [KdPickSupply]
        public virtual string SignAddress { get; set; }
        /// <summary>
        /// 保证金退还日期
        /// </summary>
        [Display(Name = "保证金退还日期")]
        [DataType(DataType.Date)]
        [KdPickSupply]
        public virtual DateTime? BondReturnDate { get; set; }
        /// <summary>
        /// 资格审查日期
        /// </summary>
        [Display(Name = "资格审查日期")]
        [DataType(DataType.Date)]
        [KdPickSupply]
        public virtual DateTime? ReviewDate { get; set; }
        /// <summary>
        /// 资审方式
        /// </summary>
        [Display(Name = "资审方式")]
        [KdPickSupply]
        public virtual string QualAuditMode { get; set; }
        /// <summary>
        /// 投标人Id
        /// </summary>
        [Display(Name = "投标人")]
        [MaxLength(50)]
        public virtual string DeliId { get; set; }
        /// <summary>
        /// 投标人名称
        /// </summary>
        [Display(Name = "投标人")]
        [MaxLength(200)]
        [KdPickSupply]
        public virtual string DeliUnit { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        [KdPickSupply]
        public virtual string BidExplain { get; set; }
        /// <summary>
        /// 是否已完成投标
        /// </summary>
        [Display(Name = "是否已完成投标")]
        [KdPickSupply]
        public virtual bool IsTender { get; set; }
        /// <summary>
        /// 经营方式
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "经营方式")]
        [KdPickSupply]
        public virtual string ManageMode { get; set; }
        /// <summary>
        /// 项目经理Id
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目经理")]
        [KdPickAccept]
        [KdPickSupply]
        public virtual string PrjPersonId { get; set; }
        /// <summary>
        /// 项目经理姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目经理")]
        [KdPickAccept]
        [KdPickSupply]
        public virtual string PrjPersonName { get; set; }
    }
}
