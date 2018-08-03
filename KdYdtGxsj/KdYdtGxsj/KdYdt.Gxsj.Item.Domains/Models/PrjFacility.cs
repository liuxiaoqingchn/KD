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
    /// <summary>
    /// 机械设备库
    /// </summary>
    public class PrjFacility : KdEntityCommon
    {
        

        /// <summary>
        /// 设备名称
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "设备名称")]
        [Required]
        [KdSortField(1, true)]
        public virtual string FacilityName { get; set; }


        /// <summary>
        /// 企业编号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "企业编号")]
        public virtual string CorpCode { get; set; }

        /// <summary>
        /// 企业Id
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "企业Id")]
        public virtual string CorpId { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "企业名称")]
        public virtual string CorpName { get; set; }

        /// <summary>
        /// 设备数量
        /// </summary>
        [Display(Name = "设备数量")]
        public virtual string FacilitySum { get; set; }

        
        /// <summary>
        /// 设备规格
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "设备规格")]
        public virtual string FacilitySpec{ get; set; }

        

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string Remark { get; set; }
        /// <summary>
        /// 获取实体的显示标题
        /// </summary>
        /// <returns></returns>
        public override string GetDataTitle()
        {
            return this.FacilityName;
        }


    }
}
