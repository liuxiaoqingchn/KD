using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Serialization;
using KdCore;
using KdCore.Data;
using KdCore.Data.Entity;

namespace KdYdt.Gxsj.Oa.Domains.Models
{
    /// <summary>
    /// 用户工作总结
    /// </summary>
    public class OaUserSumup : KdEntityCommon
    {
        /// <summary>
        /// 默认模糊查询
        /// </summary>
        /// <param name="word">查询时输入的关键字</param>
        /// <returns></returns>
        public static Expression<Func<OaUserSumup, bool>> GetFuzzyQuery(string word)
        {
            return x
                => x.CreatorUserName.Contains(word)
                || x.CreatorDutyName.Contains(word)
                || x.CreatorDeptName.Contains(word)
                || x.SumupOverall.Contains(word)
                ;
        }

        static OaUserSumup()
        {
            //设置默认模糊查询
            BbUtilEntity.SetFuzzy(GetFuzzyQuery);
        }

        /// <summary>
        /// 日志周期类型
        /// </summary>
        public virtual BbCycleDate SumupPeriod { get; set; }

        /// <summary>
        /// 总结类型
        /// </summary>
        [Display(Name = "总结类型")]
        [MaxLength(50)]
        public virtual string SumupType { get; set; }

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
        [Display(Name = "计划完成情况", ShortName = "完成情况")]
        [DataType(DataType.MultilineText)]
        public virtual string PlanCompletion { get; set; }

        /// <summary>
        /// 总结：存在问题
        /// </summary>
        [Display(Name = "出现的问题及应对措施", ShortName = "存在问题")]
        [DataType(DataType.MultilineText)]
        public virtual string ExistProblems { get; set; }

        /// <summary>
        /// 总结：经验汇总
        /// </summary>
        [Display(Name = "经验汇总")]
        [DataType(DataType.MultilineText)]
        public virtual string SumupExperiences { get; set; }

        /// <summary>
        /// 总结：工作总结
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

        /// <summary>
        /// 是否提交
        /// </summary>
        [Display(Name = "是否提交", ShortName = "提交")]
        public virtual bool IsReported { get; set; }

        /// <summary>
        /// 是否延迟上交
        /// </summary>
        [Display(Name = "是否补交", ShortName = "补交")]
        public virtual bool IsDelayed { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        [Display(Name = "是否审核", ShortName = "审核")]
        public virtual bool IsReviewed { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>
        public virtual List<OaSumupReview> Reviews { get; set; }

        public virtual string ReviewDesc
        {
            get
            {
                if (this.Reviews.IsEmpty())
                    return null;
                return this.Reviews.OrderBy(x => x.CreateTime).Select(x => x.CreateName)
                    .Distinct()
                    .ToJoin("，");
            }
        }

        /// <summary>
        /// 获取当前数据的标题名称，用于生成待办事项等关联数据时使用，或数据删除时提示显示等
        /// </summary>
        /// <returns></returns>
        public override string GetDataTitle()
        {
            return string.Format("{0} {1}", this.StartDate.ToDateCNString(), this.CreateName);
        }
    }
}
