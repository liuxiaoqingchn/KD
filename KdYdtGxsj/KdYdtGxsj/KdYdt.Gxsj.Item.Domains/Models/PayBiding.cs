using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.Models
{
    /// <summary>
    /// 标书费管理
    /// </summary>
    public class PayBiding : BaseProject
    {
        /// <summary>
        /// 投标方式
        /// </summary>
        [Display(Name = "投标方式")]
        public virtual int? BidMode { get; set; }
        /// <summary>
        /// 投标方式名称
        /// </summary>
        [Display(Name = "投标方式")]
        [MaxLength(100)]
        public virtual string BidModeName { get; set; }
        /// <summary>
        /// 招标机构
        /// </summary>
        [MaxLength(200)]
        [Display(Name ="招标机构")]
        [KdPickAccept]
        public virtual string TenderUnit { get; set; }
        /// <summary>
        /// 工程规模/造价
        /// </summary>
        [Display(Name = "工程造价")]
        [KdPickAccept]
        public virtual decimal? EngScale { get; set; }
        /// <summary>
        /// 目标单位家数
        /// </summary>
        [Display(Name = "目标单位")]
        public virtual int TargetCount { get; set; }
        /// <summary>
        /// 陪标单位家数
        /// </summary>
        [Display(Name = "陪标单位")]
        public virtual int AccompanyCount { get; set; } 
        /// <summary>
        /// 主标单位
        /// </summary>
        [Display(Name = "主标单位")]
        [MaxLength(200)]
        public virtual string MainUnit { get; set; }
        /// <summary>
        /// 副标单位
        /// </summary>
        [Display(Name = "副标单位")]
        [MaxLength(200)]
        public virtual string SecondaryUnit { get; set; }

        /// <summary>
        /// 主标-纸质标-报名费
        /// </summary>
        [Display(Name = "报名费")]
        public virtual decimal? MainPaperSign { get; set; }
        /// <summary>
        /// 主标-纸质标-保证金服务费
        /// </summary>
        [Display(Name = "保证金服务费")]
        public virtual decimal? MainPaperBond { get; set; }
        /// <summary>
        /// 主标-纸质标-标书编制费
        /// </summary>
        [Display(Name = "标书编制费")]
        public virtual decimal? MainPaperBiding { get; set; }
        /// <summary>
        /// 主标-纸质标-开标(封标)费
        /// </summary>
        [Display(Name = "开标(封标)费")]
        public virtual decimal? MainPaperBidSeals { get; set; }
        /// <summary>
        /// 主标-纸质标-其他费用
        /// </summary>
        [Display(Name = "其他")]
        public virtual decimal? MainPaperOther { get; set; }
        /// <summary>
        /// 主标-纸质标-小计
        /// </summary>
        [Display(Name = "小计")]
        public virtual decimal? MainPaperTotal { get; set; }



        /// <summary>
        /// 副标-纸质标-报名费
        /// </summary>
        [Display(Name = "报名费")]
        public virtual decimal? VicePaperSign { get; set; }
        /// <summary>
        /// 副标-纸质标-保证金服务费
        /// </summary>
        [Display(Name = "保证金服务费")]
        public virtual decimal? VicePaperBond { get; set; }
        /// <summary>
        /// 副标-纸质标-标书编制费
        /// </summary>
        [Display(Name = "标书编制费")]
        public virtual decimal? VicePaperBiding { get; set; }
        /// <summary>
        /// 副标-纸质标-开标(封标)费
        /// </summary>
        [Display(Name = "开标(封标)费")]
        public virtual decimal? VicePaperBidSeals { get; set; }
        /// <summary>
        /// 副标-纸质标-其他费用
        /// </summary>
        [Display(Name = "其他")]
        public virtual decimal? VicePaperOther { get; set; }
        /// <summary>
        /// 副标-纸质标-小计
        /// </summary>
        [Display(Name = "小计")]
        public virtual decimal? VicePaperTotal { get; set; }



        /// <summary>
        /// 主标-电子标-报名费
        /// </summary>
        [Display(Name = "报名费")]
        public virtual decimal? MainElectrSign { get; set; }
        /// <summary>
        /// 主标-电子标-保证金服务费
        /// </summary>
        [Display(Name = "保证金服务费")]
        public virtual decimal? MainElectrBond { get; set; }
        /// <summary>
        /// 主标-电子标-标书编制费
        /// </summary>
        [Display(Name = "标书编制费")]
        public virtual decimal? MainElectrBiding { get; set; }
        /// <summary>
        /// 主标-电子标-开标(封标)费
        /// </summary>
        [Display(Name = "开标(封标)费")]
        public virtual decimal? MainElectrBidSeals { get; set; }
        /// <summary>
        /// 主标-电子标-其他费用
        /// </summary>
        [Display(Name = "其他")]
        public virtual decimal? MainElectrOther { get; set; }
        /// <summary>
        /// 主标-电子标-小计
        /// </summary>
        [Display(Name = "小计")]
        public virtual decimal? MainElectrTotal { get; set; }




        /// <summary>
        /// 副标-电子标-报名费
        /// </summary>
        [Display(Name = "报名费")]
        public virtual decimal? ViceElectrSign { get; set; }
        /// <summary>
        /// 副标-电子标-保证金服务费
        /// </summary>
        [Display(Name = "保证金服务费")]
        public virtual decimal? ViceElectrBond { get; set; }
        /// <summary>
        /// 副标-电子标-标书编制费
        /// </summary>
        [Display(Name = "标书编制费")]
        public virtual decimal? ViceElectrBiding { get; set; }
        /// <summary>
        /// 副标-电子标-开标(封标)费
        /// </summary>
        [Display(Name = "开标(封标)费")]
        public virtual decimal? ViceElectrBidSeals { get; set; }
        /// <summary>
        /// 副标-电子标-其他费用
        /// </summary>
        [Display(Name = "其他")]
        public virtual decimal? ViceElectrOther { get; set; }
        /// <summary>
        /// 副标-电子标-小计
        /// </summary>
        [Display(Name = "小计")]
        public virtual decimal? ViceElectrTotal { get; set; }



        /// <summary>
        /// 标书费合计
        /// </summary>
        [Display(Name = "标书费合计")]
        public virtual decimal? TotalMoney { get; set; }
        /// <summary>
        /// 经办人ID
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "经办人")]
        public virtual string HandlingId { get; set; }
        /// <summary>
        /// 经办人姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "经办人")]
        public virtual string HandlingName { get; set; }
        /// <summary>
        /// 经办日期 
        /// </summary>
        [Display(Name = "经办日期")]
        [DataType(DataType.Date)]
        public virtual DateTime? HandlingDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public virtual string Explain { get; set; }
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
