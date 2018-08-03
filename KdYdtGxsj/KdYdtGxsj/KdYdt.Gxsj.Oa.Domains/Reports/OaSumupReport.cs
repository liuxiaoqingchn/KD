using System.ComponentModel.DataAnnotations;

using KdCore;
using KdCore.Data;
using KdCore.Data.Entity;

namespace KdYdt.Gxsj.Oa.Domains.Reports
{
    public class OaSumupReport : KdDataReport<OaSumupReportItem>
    {
        [Display(Name = "统计类型")]
        public virtual BbCycleDate SumupPeriod { get; set; }
    }

    public class OaSumupReportItem : KdEntityBase
    {
        public virtual string RealName { get; set; }

        public virtual string DeptName { get; set; }

        public virtual int CountSubmitted { get; set; }
        public virtual int CountDelayed { get; set; }
        public virtual int CountReview { get; set; }
        public virtual int CountReviewed { get; set; }
    }
}
