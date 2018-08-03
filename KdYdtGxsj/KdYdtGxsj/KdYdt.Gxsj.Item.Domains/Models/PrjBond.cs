using KdCore.Data.Entity;
using KdYdt.Gxsj.Item.Domains.Assist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    /// <summary>
    /// 保函或保证金
    /// </summary>
    public class PrjBond : BaseProject
    {
        #region 任务信息
        /// <summary>
        /// 任务ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "任务ID")]
        public virtual string PrjTaskId { get; set; }
        /// <summary>
        /// 任务下达时间
        /// </summary>
        [Display(Name = "任务下达时间")]
        public virtual DateTime? TaskTime { get; set; }
        /// <summary>
        /// 任务下达人ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "任务下达人")]
        public virtual string TaskPersonId { get; set; }
        /// <summary>
        /// 任务下达人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "任务下达人")]
        public virtual string TaskPersonName { get; set; }

        #endregion

        #region 任务安排情况
        /// <summary>
        /// 制作人Id
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "制作人")]
        public virtual string MakeId { get; set; }
        /// <summary>
        /// 制作人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "制作人")]
        public virtual string MakeName { get; set; }
        /// <summary>
        /// 计划完成时间
        /// </summary>
        [Display(Name = "计划完成时间")]
        public virtual DateTime? PlanTime { get; set; }
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
        /// 任务是否暂停，当任务下达撤销修改时，改任务状态将处于暂停状态
        /// </summary>
        [Display(Name = "任务暂停")]
        public virtual bool IsSuspend { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public virtual string Explain { get; set; }
        #endregion

        #region 保证金缴纳
        /// <summary>
        /// 是否为保证金
        /// </summary>
        [Display(Name = "是否为保证金")]
        public virtual bool IsBond { get; set; }
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
        /// 投标保证金
        /// </summary>
        [Display(Name = "投标保证金")]
        public virtual decimal? BondMoney { get; set; }
        /// <summary>
        /// 计划退还日期
        /// </summary>
        [Display(Name = "计划退还日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? BondReturnDate { get; set; }
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

        #region 保证金退回
        /// <summary>
        /// 保证金退账银行名称
        /// </summary>
        [Display(Name = "保证金退账银行名称")]
        [MaxLength(100)]
        public virtual string ReturnBankName { get; set; }
        /// <summary>
        /// 保证金退账账户名
        /// </summary>
        [Display(Name = "保证金退账账户名")]
        [MaxLength(100)]
        public virtual string ReturnBankUser { get; set; }
        /// <summary>
        /// 保证金退账账户
        /// </summary>
        [Display(Name = "保证金退账账户")]
        [MaxLength(100)]
        public virtual string ReturnBankAccount { get; set; }

        /// <summary>
        /// 保证金是否已退
        /// </summary>
        [Display(Name = "是否已退")]
        public virtual bool IsReturn { get; set; }

        /// <summary>
        /// 实际退还日期
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "实际退还日期")]
        public virtual DateTime? ReturnDate { get; set; }

        /// <summary>
        /// 服务费
        /// </summary>
        [Display(Name = "服务费")]
        public virtual decimal? ServePrice { get; set; }
        /// <summary>
        /// 退还金额
        /// </summary>
        [Display(Name = "退还金额")]
        public virtual decimal? ReturnMoney { get; set; }


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
