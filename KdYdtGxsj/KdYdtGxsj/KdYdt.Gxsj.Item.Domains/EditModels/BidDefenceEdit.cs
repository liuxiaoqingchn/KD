using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.EditModels
{
    public class BidDefenceEdit : BaseProjectEdit
    {
        /// <summary>
        /// 答辩日期
        /// </summary>
        [Display(Name = "答辩日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? DefenceDate { get; set; }
        /// <summary>
        /// 会议地点
        /// </summary>
        [Display(Name = "会议地点")]
        [MaxLength(100)]
        public virtual string MeetAddr { get; set; }
        /// <summary>
        /// 经办时间
        /// </summary>
        [Display(Name = "经办时间")]
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
