using System;
using System.ComponentModel.DataAnnotations;
using KdCore.Data;
using KdCore.Data.Entity;

namespace KdYdt.Gxsj.Oa.Domains.Models
{
    /// <summary>
    ///  快捷审批意见 ，映射表 'OaQuickIdea'。
    /// </summary>
    [Serializable]
    public class OaQuickIdea : KdEntityCommon
    {
        static OaQuickIdea()
        {
            //设置默认模糊查询
            BbUtilEntity.SetDefaultSortString<OaQuickIdea>("SortNum");
        }

        /// <summary>
        /// 快捷审批意见
        /// </summary>
        [Display(Name = "审批意见")]
        public override string Notes
        {
            get { return base.Notes; }
            set { base.Notes = value; }
        }

        /// <summary>
        /// 获取实体的显示标题
        /// </summary>
        public override string GetDataTitle()
        {
            return this.Notes;
        }
    }
}
