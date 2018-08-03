using System;
using System.ComponentModel.DataAnnotations;
using KdCore;
using KdCore.Data.EditModels;
using KdCore.Data.Entity;

namespace KdYdt.Gxsj.Oa.Domains.EditModels
{
    /// <summary>
    /// 用户动态总结
    /// </summary>
    public class OaSumupEdit : KdBaseEdit
    {
        /// <summary>
        /// 日志周期类型
        /// </summary>
        public virtual BbCycleDate SumupPeriod { get; set; }

        /// <summary>
        /// 总结周期开始日期
        /// </summary>
        [Display(Name = "开始日期")]
        [DataType(DataType.Date)]
        public virtual DateTime StartDate { get; set; }

        /// <summary>
        /// 总结周期结束日期
        /// </summary>
        [Display(Name = "结束日期")]
        [DataType(DataType.Date)]
        public virtual DateTime EndDate { get; set; }

        /// <summary>
        /// 总结：计划完成情况
        /// </summary>
        [Display(Name = "计划完成情况")]
        [DataType(DataType.MultilineText)]
        public virtual string PlanCompletion { get; set; }

        /// <summary>
        /// 总结：存在问题
        /// </summary>
        [Display(Name = "存在问题")]
        [DataType(DataType.MultilineText)]
        public virtual string ExistProblems { get; set; }

        /// <summary>
        /// 总结：经验汇总
        /// </summary>
        [Display(Name = "经验汇总")]
        [DataType(DataType.MultilineText)]
        public virtual string SumupExperiences { get; set; }

        /// <summary>
        /// 总结：总体情况
        /// </summary>
        [Display(Name = "工作总结")]
        [DataType(DataType.MultilineText)]
        public virtual string SumupOverall { get; set; }

        /// <summary>
        /// 计划：下期计划安排
        /// </summary>
        [Display(Name = "工作计划")]
        [DataType(DataType.MultilineText)]
        public virtual string PlanNext { get; set; }
    }
}
