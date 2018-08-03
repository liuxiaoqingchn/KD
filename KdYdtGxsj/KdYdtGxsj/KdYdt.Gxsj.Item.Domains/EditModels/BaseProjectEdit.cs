using System.ComponentModel.DataAnnotations;

using KdCore.Data.EditModels;

namespace KdYdt.Gxsj.Item.Domains.EditModels
{
    public class BaseProjectEdit : KdBaseEdit
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目ID")]
        public virtual string ProjectId { get; set; }
        /// <summary>
        /// 立项编号
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "立项编号")]
        public virtual string PrjCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目名称")]
        public virtual string PrjName { get; set; }
    }
}
