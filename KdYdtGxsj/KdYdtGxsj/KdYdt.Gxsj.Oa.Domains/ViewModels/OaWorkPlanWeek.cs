using System;
using System.Collections.Generic;
using System.Linq;
using KdCore;
using KdCore.Data;
using KdYdt.Gxsj.Oa.Domains.Models;

namespace KdYdt.Gxsj.Oa.Domains.ViewModels
{
    public class OaWorkPlanWeek : KdDateWeek
    {
        private bool? _isSubmitted;
        /// <summary>
        /// 是否已经提交，提交后不允许再修改或添加删除
        /// </summary>
        public virtual bool IsSubmitted
        {
            get
            {
                if (this._isSubmitted.HasValue)
                    return this._isSubmitted.Value;
                this._isSubmitted = this.WorkPlans.NotEmpty() && this.WorkPlans.Any(x => x.IsCompleted);
                return this._isSubmitted.Value;
            }
        }

        public virtual List<OaWorkPlan> WorkPlans { get; set; }

        public OaWorkPlanWeek() : this(0) { }

        public OaWorkPlanWeek(int? weekIndex) : base(weekIndex) { }

        public virtual bool HasDayPlans(DateTime day)
        {
            if (this.WorkPlans.IsEmpty())
                return false;

            day = day.Date;
            return this.WorkPlans.Exists(x => x.PlanDate.Date == day);
        }

        public virtual int DayPlansCount(DateTime day)
        {
            if (this.WorkPlans.IsEmpty())
                return 0;
            day = day.Date;
            return this.WorkPlans.Count(x => x.PlanDate.Date == day);
        }

        public virtual List<OaWorkPlan> DayPlans(DateTime day, TimeSpan startTime)
        {
            if (this.WorkPlans.IsEmpty())
                return new List<OaWorkPlan>();
            day = day.Date;
            TimeSpan endTime = startTime.Add(KdAppContext.Global.WorkPlanTimeSpan);
            return this.WorkPlans
                .Where(x => x.PlanDate.Date == day && x.StartTime >= startTime && x.StartTime < endTime)
                .OrderBy(x => x.StartTime)
                .ToList();
        }

        public virtual List<OaWorkPlan> InMorning(DateTime day, bool isMorning)
        {
            if (this.WorkPlans.IsEmpty())
                return new List<OaWorkPlan>();
            day = day.Date;
            TimeSpan time = TimeSpan.FromHours(12);
            List<OaWorkPlan> list;
            if (isMorning)
                list = this.WorkPlans.Where(x => x.PlanDate.Date == day && x.StartTime < time).ToList();
            else
                list = this.WorkPlans.Where(x => x.PlanDate.Date == day && x.StartTime >= time).ToList();
            return list.OrderBy(x => x.StartTime).ToList();
        }

        public virtual string GetPlanContent(DateTime day, bool isMorning)
        {
            List<OaWorkPlan> list = this.InMorning(day, isMorning);
            return list.Where(x => !string.IsNullOrWhiteSpace(x.PlanSummary))
                .Select(x => x.PlanSummary)
                .ToJoin("；");
        }
    }
}
