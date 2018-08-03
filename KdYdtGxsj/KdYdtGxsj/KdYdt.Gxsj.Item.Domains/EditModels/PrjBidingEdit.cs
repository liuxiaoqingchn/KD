using KdCore.Data.EditModels;
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
    public class PrjBidingEdit : KdBaseEdit
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
        /// <summary>
        /// 投标日期
        /// </summary>
        [Display(Name = "投标日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? SignDate { get; set; }

    }
}
