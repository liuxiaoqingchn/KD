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
    /// 废标项目
    /// </summary>
    public class BidWaste : BaseProject
    {
        /// <summary>
        /// 跟标人ID
        /// </summary>
        [Display(Name = "跟标人")]
        [MaxLength(50)]
        public virtual string WithPersonId { get; set; }
        /// <summary>
        /// 跟标人姓名
        /// </summary>
        [Display(Name = "跟标人")]
        [MaxLength(50)]
        public virtual string WithPersonName { get; set; }
        /// <summary>
        /// 投标人Id
        /// </summary>
        [Display(Name = "投标人")]
        [MaxLength(50)]
        public virtual string DeliId { get; set; }
        /// <summary>
        /// 投标人名称
        /// </summary>
        [Display(Name = "投标人")]
        [MaxLength(200)]
        public virtual string DeliUnit { get; set; }
        /// <summary>
        /// 投标日期
        /// </summary>
        [Display(Name = "投标日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? SignDate { get; set; }
        /// <summary>
        /// 报名地点
        /// </summary>
        [Display(Name = "报名地点")]
        public virtual string SignAddress { get; set; }
        /// <summary>
        ///废标日期
        /// </summary>
        [Display(Name = "废标日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? WasteData { get; set; }

        /// <summary>
        /// 废标原因
        /// </summary>
        [Display(Name = "废标原因")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000)]
        public virtual string WasteReason { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "备注")]
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
