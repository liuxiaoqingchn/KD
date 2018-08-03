using KdCore.Data;
using KdCore.Data.EditModels;
using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.EditModels
{
    public class PrjAptitudeEdit : KdBaseEdit
    {


        /// <summary>
        /// 资质证书号
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "资质证书号")]
        [Required]
        [KdSortField(1, true)]
        public virtual string AptitudeID { get; set; }

        /// <summary>
        /// 资质证书名
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "资质证书名")]
        public virtual string AptitudeName { get; set; }

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
        public virtual string CorpName { get; set; }


        /// <summary>
        /// 资质类别
        /// </summary>
        [Display(Name = "资质类别")]
        public virtual string AptitudeType { get; set; }


        /// <summary>
        /// 资质等级
        /// </summary>
        [Display(Name = "资质等级")]
        public virtual string AptitudeClass { get; set; }





        /// <summary>
        /// 有效日期
        /// </summary>
        [Display(Name = "有效日期")]
        public virtual DateTime? CredentialDate { get; set; }



        /// <summary>
        /// 发证日期
        /// </summary>
        [Display(Name = "发证日期")]
        public virtual DateTime? GrantDate { get; set; }

        /// <summary>
        /// 发证机关
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "发证机关")]
        public virtual string OfficeName { get; set; }


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
            return this.AptitudeName;
        }

    }
}
