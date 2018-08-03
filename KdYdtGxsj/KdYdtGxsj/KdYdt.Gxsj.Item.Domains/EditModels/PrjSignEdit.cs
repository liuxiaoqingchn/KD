using KdCore.Data.Entity;
using KdYdt.Gxsj.Item.Domains.Assist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.EditModels
{
    /// <summary>
    /// 投标报名实体编辑类
    /// </summary>
    public class PrjSignEdit : BaseProjectEdit
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
        public virtual bool IsBond { get; set; }
        /// <summary>
        /// 保证金
        /// </summary>
        [Display(Name = "保证金")]
        public virtual decimal? BondMoney { get; set; }
        #region 投标报名
        /// <summary>
        /// 是否已完成投标
        /// </summary>
        [Display(Name = "是否已完成投标")]
        public virtual bool IsTender { get; set; }
        /// <summary>
        /// 报名开始日期
        /// </summary>
        [Display(Name = "报名开始日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? SignStartData { get; set; }
        /// <summary>
        /// 报名开始日期
        /// </summary>
        [Display(Name = "报名截止日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? SignEndData { get; set; }
        /// <summary>
        /// 投标日期
        /// </summary>
        [Display(Name = "投标日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? SignDate { get; set; }
        /// <summary>
        /// 报名地点
        /// </summary>
        [Display(Name = "报名地点")]
        public virtual string SignAddress { get; set; }
        /// <summary>
        /// 保证金退还日期
        /// </summary>
        [Display(Name = "保证金退还日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? BondReturnDate { get; set; }
        /// <summary>
        /// 资格审查日期
        /// </summary>
        [Display(Name = "资格审查日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? ReviewDate { get; set; }
        /// <summary>
        /// 资审方式
        /// </summary>
        [Display(Name = "资审方式")]
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
        public virtual string DeliUnit { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string Explain { get; set; }
        #endregion
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string BidExplain { get; set; }
        /// <summary>
        /// 经营方式
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "经营方式")]
        public virtual string ManageMode { get; set; }
        /// <summary>
        /// 投标员Id
        /// </summary>
        [Display(Name = "投标员")]
        [MaxLength(50)]
        public virtual string BidManId { get; set; }
        /// <summary>
        /// 投标员名称
        /// </summary>
        [Display(Name = "投标员")]
        [MaxLength(200)]
        public virtual string BidMan { get; set; }
    }
}
