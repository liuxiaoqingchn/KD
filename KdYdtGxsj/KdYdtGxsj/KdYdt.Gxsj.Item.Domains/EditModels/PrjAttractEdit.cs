using KdCore.Data;
using KdCore.Data.EditModels;
using KdCore.Data.Entity;
using KdYdt.Gxsj.Item.Domains.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.EditModels
{
    public class PrjAttractEdit : KdBaseEdit
    {

        /// <summary>
        /// 采购商名称
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "采购商名称")]
        [Required]
        [KdSortField(1, true)]
        public virtual string AttractName { get; set; }
        /// <summary>
        /// 招商平台地址
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "招商平台地址")]
        [Required]
        [KdSortField(1, true)]
        public virtual string AttractUrl { get; set; }


        /// <summary>
        /// 供应商专业类别
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "供应商专业类别")]
        public virtual string AttractType { get; set; }

        /// <summary>
        /// 招商平台账号
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "招商平台账号")]
        public virtual string AttractUnit { get; set; }


        /// <summary>
        /// 招商平台密码
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "招商平台密码")]
        public virtual string AttractPwd { get; set; }


        /// <summary>
        /// 注册人
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "注册人")]
        public virtual string AttRegisterPerson { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "联系人")]
        public virtual string AttractPerson { get; set; }

        /// <summary>
        /// 联系人电话
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "联系人电话")]
        public virtual string AttractTel { get; set; }



        /// <summary>
        /// 业务联系人
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "业务联系人")]
        public virtual string AttBusPerson { get; set; }

        /// <summary>
        /// 业务联系人电话
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "业务联系人电话")]
        public virtual string AttBusTel { get; set; }
        /// <summary>
        /// 业务（项目）名称
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "业务（项目）名称")]
        public virtual string AttBusbusiness { get; set; }


        /// <summary>
        /// 账号创建日期
        /// </summary>
        [Display(Name = "账号创建日期")]
        public virtual DateTime? CreatorDate { get; set; }

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
            return this.AttractName;
        }

    }
}
