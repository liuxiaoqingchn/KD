using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    /// <summary>
    /// 项目信息
    /// </summary>
    public class PrjItem : KdEntityCommon
    {
        #region 项目信息

        /// <summary>
        /// 项目编号
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目编号")]
        [KdPickSupply]
        public virtual string PrjCode { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "项目名称")]
        [KdPickSupply]
        [Required]
        public virtual string PrjName { get; set; }
        /// <summary>
        /// 经营方式
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "经营方式")]
        [KdPickSupply]
        public virtual string ManageMode { get; set; }
        /// <summary>
        /// 公告发布时间
        /// </summary>
        [Display(Name = "公告发布时间")]
        public virtual DateTime? NoticTime { get; set; }
        /// <summary>
        /// 建设单位
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "建设单位")]
        [KdPickSupply]
        public virtual string BuildUnit { get; set; }

        /// <summary>
        /// 工程规模/造价
        /// </summary>
        [Display(Name = "工程规模/造价")]
        [KdPickSupply]
        public virtual decimal? EngScale { get; set; }
        /// <summary>
        /// 是否预选招标
        /// </summary>
        [Display(Name = "是否预选招标")]
        public virtual bool IsPrese { get; set; }
        /// <summary>
        /// 是否立项
        /// </summary>
        [Display(Name = "是否立项")]
        public virtual bool IsItem { get; set; }
        /// <summary>
        /// 是否报名
        /// </summary>
        [Display(Name = "是否报名")]
        public virtual bool IsSign { get; set; }
        ///// <summary>
        ///// 是否中标
        ///// </summary>
        //[Display(Name = "是否中标")]
        //public virtual bool? IsBid { get; set; }
        ///// <summary>
        ///// 保证金
        ///// </summary>
        //[Display(Name = "保证金")]
        //public virtual decimal? BondMoney { get; set; }
        /// <summary>
        /// 项目登记人ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目登记人")]
        public virtual string PrjRegId { get; set; }
        /// <summary>
        /// 项目登记人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "项目登记人")]
        public virtual string PrjRegName { get; set; }
        /// <summary>
        /// 项目登记日期
        /// </summary> 
        [Display(Name = "项目登记时间")]
        [DataType(DataType.Date)]
        public virtual DateTime? PrjRegDate { get; set; }
        /// <summary>
        /// 招标方式
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "招标方式")]
        [KdPickSupply]
        public virtual string TenderMthod { get; set; }
        /// <summary>
        /// 采购单位
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "采购单位")]
        public virtual string BuyUnit { get; set; }
        /// <summary>
        /// 招标机构
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "招标机构")]
        [KdPickSupply]
        public virtual string TenderUnit { get; set; }
        /// <summary>
        /// 答疑截止时间
        /// </summary>
        [Display(Name = "答疑截止时间")]
        [DataType(DataType.Date)]
        public virtual DateTime? AnsEndTime { get; set; }
        /// <summary>
        /// 截标日期
        /// </summary>
        [Display(Name = "截标日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? EndBidDate { get; set; }

        /// <summary>
        /// 踏勘日期
        /// </summary>
        [Display(Name = "踏勘日期 ")]
        [DataType(DataType.Date)]
        public virtual DateTime? VisitDate { get; set; }
        /// <summary>
        /// 开标日期
        /// </summary>
        [Display(Name = "开标日期 ")]
        [DataType(DataType.Date)]
        public virtual DateTime? BidOpenDate { get; set; }
        /// <summary>
        /// 资质要求
        /// </summary>
        [MaxLength(500)]
        [Display(Name = "资质要求")]
        [DataType(DataType.MultilineText)]
        public virtual string QualRequis { get; set; }
        /// <summary>
        /// 建造师要求
        /// </summary>
        [MaxLength(500)]
        [Display(Name = "建造师要求")]
        [DataType(DataType.MultilineText)]
        public virtual string MgrRequis { get; set; }
        /// <summary>
        /// 其他投标条件
        /// </summary>
        [MaxLength(500)]
        [Display(Name = "其他投标条件")]
        [DataType(DataType.MultilineText)]
        public virtual string OtherRequis { get; set; }   
        /// <summary>
        /// 公告结束日期
        /// </summary>
        [Display(Name = "公告结束日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? EndDate { get; set; }
        /// <summary>
        /// 项目地址
        /// </summary>
        [Display(Name = "项目地址")]
        [MaxLength(100)]
        public virtual string PrjAddr { get; set; }

        /// <summary>
        /// 一点通数据来源URL
        /// </summary>
        [Display(Name = "一点通数据来源URL")]
        [MaxLength(500)]
        public virtual string InfoUrl { get; set; }
        /// <summary>
        /// 来源一点通
        /// </summary>
        [Display(Name = "来源一点通")]
        public virtual bool IsKdYdt { get; set; }
        /// <summary>
        /// 发布机构
        /// </summary>
        [Display(Name = "发布机构")]
        public virtual string MsgType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string Explain { get; set; }
        #endregion  

        /// <summary>
        /// 获取实体的显示标题
        /// </summary>
        /// <returns></returns>
        public override string GetDataTitle()
        {
            return this.PrjName;
        }
    }
}
