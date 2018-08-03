using KdCore.Data;
using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    public class PrjPersonEdit : KdEntityBase
    {

        /// <summary>
        /// 人员工号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "人员工号")]
        public virtual string PersonID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "姓名")]
        [Required]
        [KdSortField(1, true)]
        public virtual string PersonName { get; set; }


        /// <summary>
        /// 联系电话
        /// </summary>
        [Display(Name = "联系电话")]
        [MaxLength(50)]
        public virtual string LinkPhone { get; set; }


        /// <summary>
        /// 身份证号
        /// </summary>
        [Display(Name = "身份证号")]
        [MaxLength(50)]
        public virtual string PersonNumberID { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public virtual string PersonSex { get; set; }


        /// <summary>
        /// 证书编号
        /// </summary>
        [Display(Name = "证书编号")]
        [MaxLength(50)]
        public virtual string CredentialID { get; set; }

        /// <summary>
        /// 证书等级
        /// </summary>
        [Display(Name = "证书等级")]
        public virtual string Rank { get; set; }


        /// <summary>
        /// 证书有效日期
        /// </summary>
        [Display(Name = "证书有效日期")]
        public virtual DateTime? CredentialDate { get; set; }

        /// <summary>
        /// 企业编号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "企业编号")]
        public virtual string CorpCode { get; set; }

        /// <summary>
        /// 企业Id
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "企业Id")]
        public virtual string CorpId { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "企业名称")]
        [Required]
        [KdSortField(1, true)]
        public virtual string CorpName { get; set; }
        /// <summary>
        /// 是否有在建工程
        /// </summary> 
        [Display(Name = "是否有在建工程")]
        public virtual bool ISLocking { get; set; }

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
            return this.PersonName;
        }

    }
}
