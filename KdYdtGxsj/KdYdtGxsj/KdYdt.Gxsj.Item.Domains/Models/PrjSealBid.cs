using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    public class PrjSealBid: KdEntityCommon
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Display(Name = "项目名称")]
        [MaxLength(200)]
        [Required]
        public virtual string PrjName { get; set; }
        /// <summary>
        /// 项目Id
        /// </summary>
        [Display(Name = "项目Id")]
        [MaxLength(50)]
        [Required]
        public virtual string ProjectId { get; set; }
        /// <summary>
        /// 经办日期
        /// </summary>
        [Display(Name = "经办日期")]
        public virtual DateTime? CheckDate { get; set; }
        /// <summary>
        /// 经办人Id
        /// </summary>
        [Display(Name = "经办人")]
        [MaxLength(50)]
        public virtual string CheckPersonId { get; set; }
        /// <summary>
        /// 经办人
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
    }
}
