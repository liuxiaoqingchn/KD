using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
   public class BidNoticeEdit: KdEntityBase
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "项目编号")]
        public virtual string PrjCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Display(Name = "项目名称")]
        [MaxLength(200)]
        [Required]
        public virtual string PrjName { get; set; }

        /// <summary>
        /// 保证金编号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "变更编号")]
        public virtual string EnsureId { get; set; }

        #region 项目变更


        /// <summary>
        /// 变更内容
        /// </summary>
        [Display(Name = "变更内容")]
        [MaxLength(600)]
        public virtual string ChangeContent { get; set; }
        /// <summary>
        /// 变更内容
        /// </summary>
        [Display(Name = "变更内容")]
        [MaxLength(600)]
        public virtual string Others { get; set; }
        /// <summary>
        /// 变更前内容
        /// </summary>
        [MaxLength(600)]
        [Display(Name = "变更前内容")]
        [DataType(DataType.MultilineText)]
        public virtual string PreContent { get; set; }
        /// <summary>
        /// 变更后内容
        /// </summary>
        [MaxLength(600)]
        [Display(Name = "变更后内容")]
        [DataType(DataType.MultilineText)]
        public virtual string AfterContent { get; set; }
        /// <summary>
        /// 变更理由
        /// </summary>
        [MaxLength(600)]
        [Display(Name = "变更理由")]
        [DataType(DataType.MultilineText)]
        public virtual string ChangeReason { get; set; }

        /// <summary>
        /// 变更人
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "变更人")]
        public virtual string ChangePerson { get; set; }

        /// <summary>
        /// 变更时间 
        /// </summary>
        [Display(Name = "变更时间")]
        public virtual DateTime? ChangeDate { get; set; }

        [MaxLength(200)]
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string BidNoticeMark { get; set; }
        #endregion
    }
}
