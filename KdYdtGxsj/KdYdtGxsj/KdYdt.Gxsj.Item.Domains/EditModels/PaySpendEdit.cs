using KdCore.Data.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace KdYdt.Gxsj.Item.Domains.EditModels
{
    public class PaySpendEdit: BaseProjectEdit
    {
        #region 费用支出               


        /// <summary>
        /// 技术标书费
        /// </summary>
        [Display(Name = "技术标书费")]
        public virtual decimal? TechniqueCost { get; set; }
        /// <summary>
        /// 商务标书费
        /// </summary>
        [Display(Name = "商务标书费")]
        public virtual decimal? BusinessCost { get; set; }

        /// <summary>
        /// 资料费
        /// </summary>
        [Display(Name = "资料费")]
        public virtual decimal? DataCost { get; set; }

        /// <summary>
        /// 项目经理配合费
        /// </summary>
        [Display(Name = "项目经理配合费")]
        public virtual decimal? ManagerCost { get; set; }

        /// <summary>
        /// 保函费用
        /// </summary>
        [Display(Name = "保函费用")]
        public virtual decimal? LetterCost { get; set; }

        /// <summary>
        /// 保证金占用费
        /// </summary>
        [Display(Name = "保证金占用费")]
        public virtual decimal? MarginCost { get; set; }

        /// <summary>
        /// 纸质标书制作费
        /// </summary>
        [Display(Name = "纸质标书制作费")]
        public virtual decimal? PaperCost { get; set; }

        /// <summary>
        /// 电子、展板样品费
        /// </summary>
        [Display(Name = "电子、展板样品费")]
        public virtual decimal? ElectronCost { get; set; }

        /// <summary>
        /// 差率食宿费
        /// </summary>
        [Display(Name = "差率食宿费")]
        public virtual decimal? FoodCost { get; set; }

        /// <summary>
        /// 招标代理服务费
        /// </summary>
        [Display(Name = "招标代理服务费")]
        public virtual decimal? AgentCost { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [Display(Name = "其他费用")]
        public virtual decimal? OthersCost { get; set; }

        /// <summary>
        /// 总计
        /// </summary>
        [Display(Name = "总计")]
        public virtual decimal? TotalCost { get; set; }

        /// <summary>
        /// 经办人ID
        /// </summary>
        [Display(Name = "经办人")]
        [MaxLength(200)]
        public virtual string HandlingId { get; set; }
        /// <summary>
        /// 经办人姓名
        /// </summary>
        [Display(Name = "经办人")]
        [MaxLength(200)]
        public virtual string HandlingName { get; set; }
        /// <summary>
        /// 经办日期
        /// </summary>
        [Display(Name = "经办日期")]
        [Required]
        public virtual DateTime? HandlingData { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string Explain { get; set; }
        #endregion

        /// <summary>
        /// 费用支出编号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "费用支出编号")]
        public virtual string DisId { get; set; }          
    }
}
