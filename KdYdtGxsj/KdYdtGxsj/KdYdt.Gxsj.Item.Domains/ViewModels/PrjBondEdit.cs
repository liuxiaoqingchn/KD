using KdCore.Data.Entity;
using KdYdt.Gxsj.Item.Domains.Assist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    /// <summary>
    /// 保函或保证金编辑类
    /// </summary>
    public class PrjBondEdit : KdEntityBase
    {
        #region 任务安排情况                            
        /// <summary>
        /// 实际完成时间
        /// </summary>
        [Display(Name = "实际完成时间")]
        public virtual DateTime? ActualTime { get; set; }
        /// <summary>
        /// 当前制作进度
        /// </summary>                                  
        [Display(Name = "进度")]
        public virtual EnumTaskStatus TaskStatus { get; set; }       
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public virtual string Explain { get; set; }
        #endregion

        #region 保证金                     
        /// <summary>
        /// 招标控制价
        /// </summary>
        [Display(Name = "招标控制价")]
        public virtual decimal? TenderPrice { get; set; }

        /// <summary>
        /// 投标截止日期 
        /// </summary>
        [Display(Name = "投标截止日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? BidEndDate { get; set; }    
        /// <summary>
        /// 截止日期 
        /// </summary>
        [Display(Name = "截止日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// 保证金出账银行名称
        /// </summary>
        [Display(Name = "保证金出账银行名称")]
        [MaxLength(100)]
        public virtual string OutBankName { get; set; }
        /// <summary>
        /// 保证金出账账户名
        /// </summary>
        [Display(Name = "保证金出账账户名")]
        [MaxLength(100)]
        public virtual string OutBankUser { get; set; }
        /// <summary>
        /// 保证金出账账户
        /// </summary>
        [Display(Name = "保证金出账账户")]
        [MaxLength(100)]
        public virtual string OutBankAccount { get; set; }
        /// <summary>
        /// 保证金收款银行名称
        /// </summary>
        [Display(Name = "保证金收款银行名称")]
        [MaxLength(100)]
        public virtual string CollectBankName { get; set; }
        /// <summary>
        /// 保证金收款账户名
        /// </summary>
        [Display(Name = "保证金收款账户名")]
        [MaxLength(100)]
        public virtual string CollectBankUser { get; set; }
        /// <summary>
        /// 保证金收款账户
        /// </summary>
        [Display(Name = "保证金收款账户")]
        [MaxLength(100)]
        public virtual string CollectBankAccount { get; set; }
        /// <summary>
        /// 是否已转账
        /// </summary>     
        [Display(Name = "是否已转账")]
        public virtual bool IsPlay { get; set; }

        /// <summary>
        /// 转账时间 
        /// </summary>
        [Display(Name = "转账时间")]
        public virtual DateTime? PlayTime { get; set; }
        /// <summary>
        /// 经办人ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "经办人")]
        public virtual string PlayPersonId { get; set; }
        /// <summary>
        /// 经办人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "经办人")]
        public virtual string PlayPersonName { get; set; }

        /// <summary>
        /// 填单日期 
        /// </summary>
        [Display(Name = "填单日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? FillDate { get; set; }
        /// <summary>
        /// 制表日期 
        /// </summary>
        [Display(Name = "制表日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? TableDate { get; set; }

        #endregion
    }
}
