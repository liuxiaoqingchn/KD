using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using KdCore;
using KdCore.Data;
using KdCore.Data.Tasks;

namespace KdYdt.Gxsj.Oa.Domains.Models
{
    /// <summary>
    /// 通知公告
    /// </summary>
    public class OaNotice : KdEntityTasks
    {
        /// <summary>
        /// 默认模糊查询
        /// </summary>
        /// <param name="word">查询时输入的关键字</param>
        /// <returns></returns>
        public static Expression<Func<OaNotice, bool>> GetFuzzyQuery(string word)
        {
            return x
                => x.HeadWord.Contains(word)
                || x.MainBody.Contains(word)
                || x.NoticeTitle.Contains(word)
                || x.Notes.Contains(word)
                || x.Subject.Contains(word)
                ;
        }

        static OaNotice()
        {
            //设置默认模糊查询
            BbUtilEntity.SetFuzzy(GetFuzzyQuery);
        }

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
        [Required]
        [MaxLength(200)]
        [Display(Name = "公告标题")]
        public virtual string NoticeTitle { get; set; }
        /// <summary>
        /// 公告正文
        /// </summary>
        [Display(Name = "正文")]
        [DataType(DataType.Html)]
        public virtual string MainBody { get; set; }

        /// <summary>
        /// 通知范围
        /// </summary>
        [Display(Name = "通知范围")]
        public virtual BbDataLevel NoticeScope { get; set; }

        /// <summary>
        /// 公告开始时间
        /// </summary>
        [DataType(DataType.DateTime)]
        [Display(Name = "开始时间")]
        public virtual DateTime? StartTime { get; set; }

        /// <summary>
        /// 公告结束时间
        /// </summary>
        [DataType(DataType.DateTime)]
        [Display(Name = "结束时间")]
        public virtual DateTime? EndTime { get; set; }

        /// <summary>
        /// 通知部门主键
        /// </summary>
        [Display(Name = "通知部门")]
        public virtual string NoticeDeptIds { get; set; }

        /// <summary>
        /// 通知部门名称
        /// </summary>
        [Display(Name = "通知部门")]
        public virtual string NoticeDeptNames { get; set; }

        /// <summary>
        /// 获取实体的显示标题
        /// </summary>
        public override string GetDataTitle()
        {
            return this.NoticeTitle;
        }

        /// <summary>
        /// 设置待办事项其他参数值
        /// </summary>
        /// <param name="userTask"></param>
        public override void SetTaskValue(KdUserTask userTask)
        {
            base.SetTaskValue(userTask);
            userTask.ItemName = this.Subject;
        }
    }
}
