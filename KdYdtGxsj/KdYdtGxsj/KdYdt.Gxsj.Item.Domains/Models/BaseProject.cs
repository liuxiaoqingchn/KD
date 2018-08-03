using System.ComponentModel.DataAnnotations;

using KdCore.Data.Entity;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    public class BaseProject : KdEntityCommon
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目ID")]
        [KdPickSupply]
        [KdPickAccept("Id")]
        //[KdPickAccept]
        public virtual string ProjectId { get; set; }
        /// <summary>
        /// 立项编号
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "立项编号")]
        [KdPickSupply]
        [KdPickAccept]
        public virtual string PrjCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [MaxLength(50)]   
        [Display(Name = "项目名称")]
        [Required]
        [KdPickSupply]
        [KdPickAccept]
        public virtual string PrjName { get; set; }
    }
}
