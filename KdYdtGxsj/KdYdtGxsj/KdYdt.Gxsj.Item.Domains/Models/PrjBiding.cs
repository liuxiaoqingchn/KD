using KdCore.Data.Entity;
using KdYdt.Gxsj.Item.Domains.Assist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    /// <summary>
    /// 标书
    /// </summary>
    public class PrjBiding : BaseProject
    {
        #region 任务信息
        /// <summary>
        /// 任务ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "任务ID")]
        public virtual string PrjTaskId { get; set; }
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

        #endregion
        /// <summary>
        /// 制作人Id
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "制作人")]
        public virtual string MakeId { get; set; }
        /// <summary>
        /// 制作人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "制作人")]
        public virtual string MakeName { get; set; }
        /// <summary>
        /// 计划完成时间
        /// </summary>
        [Display(Name = "计划完成时间")]
        public virtual DateTime? PlanTime { get; set; }
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
        /// 标书类型
        /// </summary>
        [Display(Name = "标书类型")]
        public virtual EnumBidingType BidingType { get; set; }

        /// <summary>
        /// 任务是否暂停，当任务下达撤销修改时，改任务状态将处于暂停状态
        /// </summary>
        [Display(Name ="任务暂停")]
        public virtual bool IsSuspend { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name ="备注")]
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
