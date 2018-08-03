using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    /// <summary>
    /// 资格审查
    /// </summary>
    public class BidQualCheck : BaseProject
    {
        /// <summary>
        /// 审查日期
        /// </summary>
        [Display(Name = "审查日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? QualDate { get; set; }
        /// <summary>
        /// 审查方法
        /// </summary>
        [Display(Name = "审查方法")]     
        public virtual int? QualCheckType { get; set; }
        /// <summary>
        /// 审查方法
        /// </summary>
        [Display(Name = "审查方法")]    
        [MaxLength(50)]
        public virtual string QualCheckTypeName { get; set; }
        /// <summary>
        /// 经办日期
        /// </summary>
        [Display(Name = "经办日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? CheckDate { get; set; }
        /// <summary>
        /// 经办人Id
        /// </summary>
        [Display(Name = "经办人")]
        [MaxLength(50)]
        public virtual string CheckPersonId { get; set; }
        /// <summary>
        /// 经办人姓名
        /// </summary>
        [Display(Name = "经办人")]
        [MaxLength(50)]
        public virtual string CheckPersonName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public virtual string Explain { get; set; }
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
