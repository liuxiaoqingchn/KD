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
    public class SupplierEdit : KdBaseEdit
    {

        /// <summary>
        /// 供应商名称
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "供应商名称")]
        [Required]
        [KdSortField(1, true)]
        public virtual string SupName { get; set; }



        /// <summary>
        /// 负责人
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "负责人")]
        public virtual string SupPerson { get; set; }


        /// <summary>
        /// 联系电话
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "联系电话")]
        public virtual string SupTel { get; set; }


        /// <summary>
        /// 负责项目数
        /// </summary>
        [Display(Name = "负责项目数")]
        public virtual string SupProjectCount { get; set; }
        /// <summary>
        /// 累计项目数
        /// </summary>
        [Display(Name = "累计项目数")]
        public virtual string SupProjectSum { get; set; }
        /// <summary>
        /// 累计合同数
        /// </summary>
        [Display(Name = "累计合同数")]
        public virtual string SupCompactSum { get; set; }

        /// <summary>
        /// 履约情况
        /// </summary>
        [Display(Name = "履约情况")]
        [DataType(DataType.MultilineText)]
        public virtual string SupAgreCase { get; set; }

        /// <summary>
        /// 供应商评级
        /// </summary>
        [Display(Name = "供应商评级")]
        public virtual string SupPraiseType { get; set; }

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
            return this.SupName;
        }

    }
}
