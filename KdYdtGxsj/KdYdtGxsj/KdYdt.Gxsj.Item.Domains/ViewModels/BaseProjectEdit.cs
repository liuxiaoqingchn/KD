using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    public class BaseProjectEdit : KdEntityBase
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目ID")]
        public virtual string ProjectId { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目编号")]
        [Required]
        public virtual string PrjCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目名称")]
        public virtual string PrjName { get; set; }
    }
}
