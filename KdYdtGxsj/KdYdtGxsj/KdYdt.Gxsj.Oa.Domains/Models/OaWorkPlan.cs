using System;
using System.ComponentModel.DataAnnotations;
using KdCore.Data.Entity;

namespace KdYdt.Gxsj.Oa.Domains.Models
{
    /// <summary>
    /// 工作计划安排数据保存实体
    /// </summary>
    public class OaWorkPlan : KdEntityCommon
    {
        /// <summary>
        /// 计划安排日期
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "计划日期", ShortName = "日期")]
        public virtual DateTime PlanDate { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Display(Name = "开始时间", ShortName = "开始")]
        public virtual TimeSpan StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Display(Name = "结束时间", ShortName = "结束")]
        public virtual TimeSpan EndTime { get; set; }

        /// <summary>
        /// 计划安排标题
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "计划事项", ShortName = "事项")]
        public virtual string PlanName { get; set; }

        /// <summary>
        /// 计划地点
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "计划地点", ShortName = "地点")]
        public virtual string PlanPlace { get; set; }

        /// <summary>
        /// 内容摘要
        /// </summary>
        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "详细内容", ShortName = "详细")]
        public virtual string PlanSummary { get; set; }

        /// <summary>
        /// 计划分组名称
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "分类")]
        public virtual string PlanGroup { get; set; }

        /// <summary>
        /// 计划时段用户忙碌状态
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "个人状态")]
        public virtual string TimeStatus { get; set; }

        /// <summary>
        /// 参与用户主键
        /// </summary>
        [MaxLength(50 * 40)]
        [Display(Name = "参与人")]
        public virtual string InvolvedUserIds { get; set; }
        /// <summary>
        /// 参与用户姓名
        /// </summary>
        [MaxLength(30 * 40)]
        [Display(Name = "参与人")]
        public virtual string InvolvedUserNames { get; set; }

        /// <summary>
        /// 参与部门主键
        /// </summary>
        [MaxLength(50 * 40)]
        [Display(Name = "参与部门")]
        public virtual string InvolvedDeptIds { get; set; }
        /// <summary>
        /// 参与部门名称
        /// </summary>
        [MaxLength(30 * 40)]
        [Display(Name = "参与部门")]
        public virtual string InvolvedDeptNames { get; set; }

        /// <summary>
        /// 参与单位主键
        /// </summary>
        [MaxLength(50 * 20)]
        [Display(Name = "参与单位")]
        public virtual string InvolvedCorpIds { get; set; }
        /// <summary>
        /// 参与单位名称
        /// </summary>
        [MaxLength(30 * 20)]
        [Display(Name = "参与单位")]
        public virtual string InvolvedCorpNames { get; set; }

        /// <summary>
        /// 其他参与人员姓名
        /// </summary>
        [MaxLength(30 * 40)]
        [Display(Name = "其他人员")]
        public virtual string OtherPersonNames { get; set; }
        /// <summary>
        /// 其他参与部门名称
        /// </summary>
        [MaxLength(30 * 20)]
        [Display(Name = "其他部门")]
        public virtual string OtherDeptNames { get; set; }
        /// <summary>
        /// 其他参与单位名称
        /// </summary>
        [MaxLength(30 * 20)]
        [Display(Name = "其他单位")]
        public virtual string OtherCorpNames { get; set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        [Display(Name = "已完成", ShortName = "完成")]
        public virtual bool IsCompleted { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        [Display(Name = "完成时间")]
        public virtual DateTime? CompleteTime { get; set; }

        /// <summary>
        /// 完成情况
        /// </summary>
        [Display(Name = "完成情况")]
        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        public virtual string CompleteStatus { get; set; }

        /// <summary>
        /// 获取当前数据的标题名称，用于生成待办事项等关联数据时使用，或数据删除时提示显示等
        /// </summary>
        /// <returns></returns>
        public override string GetDataTitle()
        {
            return this.PlanName ?? this.PlanSummary;
        }
    }
}
