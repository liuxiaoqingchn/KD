using KdCore.Data.Entity;
using KdYdt.Gxsj.Item.Domains.Assist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    public class PrjBidingEdit : KdEntityBase
    {
        /// <summary>
        /// 实际完成时间
        /// </summary>
        [Display(Name = "实际完成时间")]
        public virtual DateTime? ActualTime { get; set; }
        /// <summary>
        /// 当前制作进度
        /// </summary>                
        [Display(Name = "进度")]
        public virtual EnumTaskStatus TaskStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public virtual string Explain { get; set; }
    }
}
