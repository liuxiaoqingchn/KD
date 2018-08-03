using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Transactions;
using KdCore;
using KdCore.Data.EntityFramework;
using KdYdt.Gxsj.Item.Domains.Models;

namespace KdYdt.Gxsj.Item.Domains.Services
{
    public class PrjDbItemService : KdDbService<PrjDbItemContext>
    {

        protected virtual List<PrjCorp> GetAffairsPlans()
        {
            return null;
        }
        protected virtual List<PrjPerson> PersonPlans()
        {
            return null;
        }
    }
}
