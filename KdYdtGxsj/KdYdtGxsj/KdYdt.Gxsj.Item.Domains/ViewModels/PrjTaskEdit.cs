using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    public class PrjTaskEdit : KdEntityBase
    {
        /// <summary>
        /// 任务是否已确认下达
        /// </summary>
        [Display(Name = "下达")]
        public virtual bool IsLssued { get; set; }
        /// <summary>
        /// 任务下达时间
        /// </summary>
        [Display(Name = "任务下达时间")]
        public virtual DateTime? TaskTime { get; set; }
        /// <summary>
        /// 任务下达人ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "任务下达人ID")]
        public virtual string TaskPersonId { get; set; }
        /// <summary>
        /// 任务下达人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "任务下达人")]
        public virtual string TaskPersonName { get; set; }

        /// <summary>
        /// 保函或保证金制作人ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "保函或保证金制作人")]
        public virtual string LetterId { get; set; }

        /// <summary>
        /// 保函或保证金制作人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "保函或保证金制作人")]
        public virtual string LetterName { get; set; }
        /// <summary>
        /// 保函或保证金计划完成时间
        /// </summary>
        [Display(Name = "计划完成时间")]    
        public virtual DateTime? LetterTime { get; set; }
        /// <summary>
        /// 商务标制作人ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "商务标制作人")]
        public virtual string BusinessId { get; set; }
        /// <summary>
        /// 商务标制作人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "商务标制作人")]
        public virtual string BusinessName { get; set; }

        /// <summary>
        /// 商务标要求完成时间
        /// </summary>         
        [Display(Name = "计划完成时间")]
        public virtual DateTime? BusinessTime { get; set; }

        /// <summary>
        /// 技术标制作人ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "技术标制作人")]
        public virtual string SkillId { get; set; }
        /// <summary>
        /// 技术标制作人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "技术标制作人")]
        public virtual string SkillName { get; set; }

        /// <summary>
        /// 技术标要求完成时间
        /// </summary>
        [Display(Name = "计划完成时间")]
        public virtual DateTime? SkillTime { get; set; }


        /// <summary>
        /// 封标上传人ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "封标上传人")]
        public virtual string SealId { get; set; }
        /// <summary>
        /// 封标上传人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "封标上传人")]
        public virtual string SealName { get; set; }

        /// <summary>
        /// 封标计划上传时间
        /// </summary>
        [Display(Name = "计划上传时间")]
        public virtual DateTime? SealTime { get; set; }
    }
}
