using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KdCore.Data;
using KdCore.Data.Entity;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    public class PrjRegister : KdEntityCommon
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Display(Name = "项目名称")]
        [MaxLength(200)]
        [Required]
        public virtual string PrjName { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目编号")]
        public virtual string PrjCode { get; set; }
    }
}
