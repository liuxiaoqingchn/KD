using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    public class PayIncome : BaseProject
    {

        #region 费用收入
       
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
        /// 其他收入
        /// </summary>
        [Display(Name = "其他收入")]
        public virtual decimal? OthersCost { get; set; }
        /// <summary>
        /// 管理费
        /// </summary>
        [Display(Name = "管理费")]
        public virtual decimal? Management { get; set; }

        /// <summary>
        /// 总计
        /// </summary>
        [Display(Name = "总计")]
        public virtual decimal? TotalCost { get; set; }
        /// <summary>
        /// 项目预计利润
        /// </summary>
        [Display(Name = "项目预计利润")]
        public virtual decimal? ExpectedProfit { get; set; }

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
        /// 费用收入编号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "费用收入编号")]
        public virtual string RevenueId { get; set; }
        /// <summary>
        /// 获取实体的显示标题
        /// </summary>
        /// <returns></returns>
        public override string GetDataTitle()
        {
            return this.PrjName;
        }
    }
}
