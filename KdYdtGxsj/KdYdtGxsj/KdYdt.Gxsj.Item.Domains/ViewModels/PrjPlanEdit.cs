using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    /// <summary>
    /// 项目立项编辑实体类
    /// </summary>
    public class PrjPlanEdit : KdEntityBase
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "项目编号")]
        [Required]
        public virtual string PrjCode { get; set; }
        /// <summary>
        /// 是否公开招标
        /// </summary>
        [Required]
        [Display(Name = "是否公开招标")]
        public virtual bool IsOpen { get; set; }
        /// <summary>
        /// 项目ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目ID")]
        [Required]
        public virtual string ProjectId { get; set; }
        #region 项目信息
        /// <summary>
        /// 立项编号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "立项编号")]
        [Required]                 
        public virtual string PrjNumber { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Display(Name = "项目名称")]
        [MaxLength(200)]
        [Required]
        public virtual string PrjName { get; set; }

        /// <summary>
        /// 发包（建设）方
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "发包（建设）方")]
        public virtual string BuildUnit { get; set; }
        /// <summary>
        /// 工程造价
        /// </summary>
        [Display(Name = "工程造价")]
        public virtual decimal? EngScale { get; set; }
        /// <summary>
        /// 招标方式
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "招标方式")]
        public virtual string TenderMthod { get; set; }
        /// <summary>
        /// 经营方式
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "经营方式")]
        public virtual string ManageMode { get; set; }
        /// <summary>
        /// 性质
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "性质")]
        public virtual string PrjNature { get; set; }
        /// <summary>
        /// 是否报建
        /// </summary>
        [Display(Name = "是否报建")]
        public virtual bool IsCons { get; set; }
        /// <summary>
        /// 工程招标机构
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "工程招标机构")]
        public virtual string TenderUnit { get; set; }
        /// <summary>
        /// 项目经理Id
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目经理")]
        public virtual string PrjPersonId { get; set; }
        /// <summary>
        /// 项目经理姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目经理")]
        public virtual string PrjPersonName { get; set; }
        /// <summary>
        /// 项目经理所在企业ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目经理所在企业ID")]
        public virtual string PrjCorpId { get; set; }
        /// <summary>
        /// 项目经理所在企业名称
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "项目经理所在企业名称")]
        public virtual string PrjCorpName { get; set; }

        /// <summary>
        /// 资料费
        /// </summary>
        [Display(Name = "资料费")]
        public virtual decimal? MaterialsCost { get; set; }
        /// <summary>
        /// 立项人ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "立项人")]
        public virtual string PrjPeopleId { get; set; }
        /// <summary>
        /// 立项人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "立项人")]
        public virtual string PrjPeopleName { get; set; }
        /// <summary>
        /// 企业管理费率
        /// </summary> 
        [Display(Name = "企业管理费率")]
        public virtual decimal? PrjManagement { get; set; }
        /// <summary>
        /// 立项日期
        /// </summary>
        [Display(Name = "立项日期")]
        [DataType(DataType.DateTime)]
        public virtual DateTime? ProjectDate { get; set; }

        #endregion

        #region 项目负责人信息
        /// <summary>
        /// 姓名ID
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "姓名")]
        public virtual string PrjLeaderId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "姓名")]
        public virtual string PrjLeaderName { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        [Display(Name = "身份证号码")]
        [MaxLength(50)]
        public virtual string PrjIdCard { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Display(Name = "手机号码")]
        [MaxLength(50)]
        public virtual string PrjMobile { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Display(Name = "电子邮箱")]
        [MaxLength(100)]
        public virtual string PrjEmail { get; set; }
        /// <summary>
        /// 委托人
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "委托人")]
        public virtual string PrincipalName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [Display(Name = "身份证号")]
        [MaxLength(50)]
        public virtual string PrincipalIdCard { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Display(Name = "手机号码")]
        [MaxLength(50)]
        public virtual string PrincipalMobile { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string Explain { get; set; }


        #endregion
    }
}
