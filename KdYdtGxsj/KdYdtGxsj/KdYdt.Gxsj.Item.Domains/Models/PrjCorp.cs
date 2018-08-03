using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KdCore.Data;
using KdCore.Data.Entity;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    /// <summary>
    /// 企业库
    /// </summary>
    public class PrjCorp : KdEntityCommon
    {
        /// <summary>
        /// 组织机构代码
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "组织机构代码")]
        [KdPickSupply]
        public virtual string CorpCode { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "企业名称")]
        [KdPickSupply]
        [Required]
        [KdSortField(1, true)]
        public virtual string CorpName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [Display(Name = "联系人")]
        [MaxLength(50)]
        public virtual string LinkMan { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "联系电话")]
        [MaxLength(50)]
        public virtual string LinkPhone { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [Display(Name = "手机")]
        [MaxLength(50)]
        public virtual string Mobile { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        [Display(Name = "传真")]
        [MaxLength(50)]
        public virtual string Fax { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "Email")]
        [MaxLength(100)]
        public virtual string Email { get; set; }
        /// <summary>
        /// 法人
        /// </summary>
        [Display(Name = "法人")]
        [MaxLength(50)]
        public virtual string LegalPerson { get; set; }
        /// <summary>
        /// 法人身份证
        /// </summary>
        [Display(Name = "法人身份证")]
        [MaxLength(50)]
        public virtual string LegalIdCard { get; set; }
        /// <summary>
        /// 注册资金(万元)
        /// </summary>
        [Display(Name = "注册资金(万元)")]
        public virtual decimal? RegFund { get; set; }
        /// <summary>
        /// 企业网址
        /// </summary>
        [Display(Name = "企业网址")]
        public virtual string CorpWebSite { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        [Display(Name = "注册日期")]
        public virtual DateTime? RegDate { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        [Display(Name = "注册地址")]
        public virtual string RegAddress { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string Remark { get; set; }
        /// <summary>
        /// 获取实体的显示标题
        /// </summary>
        /// <returns></returns>
        public override string GetDataTitle()
        {
            return this.CorpName;
        }

        public List<PrjPerson> Persons { get; set; }
        public List<PrjAptitude> Aptitudes { get; set; }
        public List<PrjFacility> Facilitys { get; set; }
        public List<PrjPraise> Praises { get; set; }
    }
}
