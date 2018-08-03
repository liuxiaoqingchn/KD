using System;
using System.Data.Entity;
using KdCore.Data.EntityFramework;
using KdYdt.Gxsj.Item.Domains.Models;

namespace KdYdt.Gxsj.Item.Domains.Services
{
    public class PrjDbItemContext : KdDbContext
    {
        public PrjDbItemContext() { }

        public PrjDbItemContext(string nameOrConnectString) : base(nameOrConnectString)
        {
        }

        protected override void CreateModel(DbModelBuilder builder)
        {
            builder.Entity<PrjCorp>().HasPrecision(x => x.RegFund, 6);
            builder.Entity<PrjPerson>();

            builder.Entity<PrjPlan>();
            builder.Entity<PrjPlan>().HasPrecision(x => x.EngScale, 6).HasPrecision(x => x.MaterialsCost, 6).HasPrecision(x => x.PrjManagement, 2, 10);
            builder.Entity<PrjItem>();
            builder.Entity<PrjPlan>().HasPrecision(x => x.EngScale, 6).HasPrecision(x => x.BondMoney, 6);
            builder.Entity<PrjSign>();
            builder.Entity<PrjSign>().HasPrecision(x => x.BondMoney, 6).HasPrecision(x => x.BidMoney, 6);
            builder.Entity<PrjBond>();
            builder.Entity<PrjBond>().HasPrecision(x => x.TenderPrice, 6).HasPrecision(x => x.BondMoney, 6);
            builder.Entity<PrjBiding>();
            builder.Entity<PrjSealBid>();
            builder.Entity<PrjTask>();
            builder.Entity<BidDefence>();
            builder.Entity<BidQualCheck>();
            builder.Entity<BidSituation>();
            builder.Entity<BidPresen>();
            builder.Entity<PrjFacility>();
            builder.Entity<PrjPraise>();
            builder.Entity<Supplier>();

            builder.Entity<PrjAttract>();
            builder.Entity<PayPact>();
            builder.Entity<PayPact>().HasPrecision(x => x.BidMoney, 6).HasPrecision(x => x.PactMoney, 6);
            builder.Entity<PaySpend>();
            builder.Entity<PayIncome>();
            builder.Entity<PayBiding>();
            builder.Entity<PayBiding>().HasPrecision(x => x.MainPaperSign, 6).HasPrecision(x => x.MainPaperBond, 6).HasPrecision(x => x.MainPaperBiding, 6).HasPrecision(x => x.MainPaperBidSeals, 6).HasPrecision(x => x.MainPaperOther, 6).HasPrecision(x => x.MainPaperTotal, 6);
            builder.Entity<PayBiding>().HasPrecision(x => x.VicePaperSign, 6).HasPrecision(x => x.VicePaperBond, 6).HasPrecision(x => x.VicePaperBiding, 6).HasPrecision(x => x.VicePaperBidSeals, 6).HasPrecision(x => x.VicePaperOther, 6).HasPrecision(x => x.VicePaperTotal, 6);
            builder.Entity<PayBiding>().HasPrecision(x => x.MainElectrSign, 6).HasPrecision(x => x.MainElectrBond, 6).HasPrecision(x => x.MainElectrBiding, 6).HasPrecision(x => x.MainElectrBidSeals, 6).HasPrecision(x => x.MainElectrOther, 6).HasPrecision(x => x.MainElectrTotal, 6);
            builder.Entity<PayBiding>().HasPrecision(x => x.ViceElectrSign, 6).HasPrecision(x => x.ViceElectrBond, 6).HasPrecision(x => x.ViceElectrBiding, 6).HasPrecision(x => x.ViceElectrBidSeals, 6).HasPrecision(x => x.ViceElectrOther, 6).HasPrecision(x => x.ViceElectrTotal, 6);
            builder.Entity<PayBiding>().HasPrecision(x => x.EngScale, 6).HasPrecision(x => x.TotalMoney, 6);

            builder.Entity<BidWaste>();
            builder.Entity<BidNotice>();
            builder.Entity<BidResult>();
        }
    }
}
