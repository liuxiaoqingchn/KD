using System;
using System.Collections.Generic;
using KdCore;
using KdCore.Data;
using KdCore.Data.Users;
using KdYdt.Gxsj.Oa.Domains.Models;

namespace KdYdt.Gxsj.Oa.Domains.Reports
{
    public class OaWorkPlanReport : KdDataReport<OaWorkPlan>
    {
        public virtual List<KdUser> Users { get; set; }

        public OaWorkPlanReport() : base(BbCycleDate.Week) { }
    }
}
