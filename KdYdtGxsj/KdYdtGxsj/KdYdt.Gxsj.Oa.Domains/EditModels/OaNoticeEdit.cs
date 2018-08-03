using System;
using System.ComponentModel.DataAnnotations;
using KdCore.Data;
using KdCore.Data.EditModels;
using KdCore.Data.Entity;

namespace KdYdt.Gxsj.Oa.Domains.EditModels
{
    /// <summary>
    /// 通知公告
    /// </summary>
    public class OaNoticeEdit : KdBaseEdit
    {
        /// <summary>
        /// 获取或设置禁用状态标识
        /// </summary>
        [Display(Name = "暂停使用")]
        public virtual bool TagDisabled { get; set; }

        /// <summary>
        /// 通知公告分类类别
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "类别")]
        public virtual string Subject { get; set; }
        /// <summary>
        /// 通知公告中心词、关键字
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "关键字")]
        public virtual string HeadWord { get; set; }
        /// <summary>
        /// 公告标题
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "标题")]
        public virtual string NoticeTitle { get; set; }
        /// <summary>
        /// 公告正文
        /// </summary>
        [Display(Name = "正文")]
        public virtual string MainBody { get; set; }

        /// <summary>
        /// 通知范围
        /// </summary>
        [Display(Name = "通知范围")]
        public virtual BbDataLevel NoticeScope { get; set; }
        /// <summary>
        /// 公告开始时间
        /// </summary>
        [Display(Name = "开始时间")]
        public virtual DateTime? StartTime { get; set; }
        /// <summary>
        /// 公告结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        public virtual DateTime? EndTime { get; set; }

        /// <summary>
        /// 通知部门主键
        /// </summary>
        [MaxLength(2000)]
        [Display(Name = "通知部门")]
        public virtual string NoticeDeptIds { get; set; }

        /// <summary>
        /// 通知部门名称
        /// </summary>
        [MaxLength(2000)]
        [Display(Name = "通知部门")]
        public virtual string NoticeDeptNames { get; set; }

        /// <summary>
        /// 获取或设置公告说明
        /// </summary>
        [MaxLength(2000)]
        [Display(Name = "说明")]
        [DataType(DataType.MultilineText)]
        public virtual string Notes { get; set; }
    }
}
