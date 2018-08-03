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
    public class PrjPraiseEdit : KdBaseEdit
    {


        /// <summary>
        /// 奖项名称
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "奖项名称")]
        [Required]
        [KdSortField(1, true)]
        public virtual string PraiseName { get; set; }


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
        /// 奖项等级
        /// </summary>
        [Display(Name = "奖项等级")]
        public virtual string PraiseType { get; set; }







        /// <summary>
        /// 获奖时间
        /// </summary>
        [Display(Name = "获奖时间")]
        public virtual DateTime? PraiseDate { get; set; }


        /// <summary>
        /// 获奖工程
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "获奖工程")]
        public virtual string PraiseProject { get; set; }


        /// <summary>
        /// 评奖机关
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "评奖机关")]
        public virtual string PraiseOffice { get; set; }


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
            return this.PraiseName;
        }


    }
}
