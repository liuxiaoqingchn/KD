using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KdCore.Data.Entity;

namespace KdYdt.Gxsj.Oa.Domains.Models
{
    /// <summary>
    /// 用户动态总结
    /// </summary>
    public class OaSumupReview : KdEntityCommon
    {
        public virtual string SumupId { get; set; }

        [ForeignKey("SumupId")]
        public virtual OaUserSumup Sumup { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>
        [Display(Name = "审批意见")]
        [DataType(DataType.MultilineText)]
        public virtual string ReviewResult { get; set; }
    }
}
