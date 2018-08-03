using System;
using System.Data.Entity;
using KdCore.Data.EntityFramework;
using KdYdt.Gxsj.Oa.Domains.Models;

namespace KdYdt.Gxsj.Oa.Domains.Services
{
    public class PrjDbOaContext : KdDbContext
    {
        public PrjDbOaContext() { }

        public PrjDbOaContext(string nameOrConnectString) : base(nameOrConnectString) { }

        protected override void CreateModel(DbModelBuilder builder)
        {
            builder.Entity<OaNotice>();
            builder.Entity<OaWorkPlan>();
            builder.Entity<OaQuickIdea>();
            builder.Entity<OaUserSumup>();
        }
    }
}
