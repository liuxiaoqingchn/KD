using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KdYdt.Gxsj.Item.Domains.EditModels
{
    public class PayPactEdit : BaseProjectEdit
    {
        /// <summary>
        /// 是否公开招标
        /// </summary>
        [Display(Name = "是否公开招标")]
        public virtual bool IsOpen { get; set; }
        /// <summary>
        /// 投标报名ID
        /// </summary>
        [Display(Name = "投标报名")]
        [MaxLength(50)]

        public virtual string PrjSignId { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        [Display(Name = "合同编号")]
        [MaxLength(80)]
        [Required]
        public virtual string PactCode { get; set; }
        /// <summary>
        /// 合同名称
        /// </summary>
        [Display(Name = "合同名称")]
        [MaxLength(80)]
        public virtual string PactName { get; set; }
        /// <summary>
        /// 发包单位
        /// </summary>
        [Display(Name = "发包单位")]
        [MaxLength(200)]
        public virtual string AwardUnit { get; set; }
        /// <summary>
        /// 中标日期
        /// </summary>
        [Display(Name = "中标单位")]
        [MaxLength(200)]
        public virtual string BidUnit { get; set; }
        /// <summary>
        /// 中标金额(万元)
        /// </summary>
        [Display(Name = "中标金额(万元)")]

        public virtual decimal? BidMoney { get; set; }
        /// <summary>
        /// 合同造价(万元)
        /// </summary>
        [Display(Name = "合同造价(万元)")]
        [Required]
        public virtual decimal? PactMoney { get; set; }
        /// <summary>
        /// 中标日期
        /// </summary>
        [Display(Name = "中标日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? BidDate { get; set; }
        /// <summary>
        /// 开工日期
        /// </summary>
        [Display(Name = "开工日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? StartsDate { get; set; }
        /// <summary>
        /// 竣工日期
        /// </summary>
        [Display(Name = "竣工日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? FinishDate { get; set; }
        /// <summary>
        /// 合同签订日期
        /// </summary>
        [Display(Name = "合同签订日期")]
        [DataType(DataType.Date)]
        [Required]
        public virtual DateTime? PactSignDate { get; set; }
        /// <summary>
        /// 经办人Id
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "经办人")]
        public virtual string PactPersonId { get; set; }
        /// <summary>
        /// 经办人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "经办人")]
        public virtual string PactPersonName { get; set; }
        /// <summary>
        /// 经办时间
        /// </summary>
        [Display(Name = "经办时间")]
        public virtual DateTime? PactDate { get; set; }
        /// <summary>
        /// 项目负责人Id
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目负责人")]
        public virtual string PrjPersonId { get; set; }
        /// <summary>
        /// 项目负责人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目负责人")]
        public virtual string PrjPersonName { get; set; }
        /// <summary>
        /// 项目负责人所在企业ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目负责人所在企业")]
        public virtual string PrjCorpId { get; set; }
        /// <summary>
        /// 项目负责人所在企业名称
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "项目负责人所在企业")]
        public virtual string PrjCorpName { get; set; }
        /// <summary>
        /// 合同备案回执号
        /// </summary>
        [Display(Name = "合同备案回执号")]
        [MaxLength(200)]
        public virtual string PactRecordNo { get; set; }
        /// <summary>
        /// 中标通知书编号
        /// </summary>
        [Display(Name = "中标通知书编号")]
        [MaxLength(100)]
        public virtual string NoticeCode { get; set; }
        /// <summary>
        /// 项目工期
        /// </summary>    
        [Display(Name = "项目工期")]
        public virtual int? PrjDay { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string Explain { get; set; }

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
        /// 经营方式
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "经营方式")]
        public virtual string ManageMode { get; set; }
    }
}
