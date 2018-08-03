using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KdCore;

namespace KdYdt.Gxsj.Oa.Domains
{
    public static class KdPrjEnumHelper
    {
        public static string GetSumupTypeName(this BbCycleDate period)
        {
            string typeName = null;
            switch (period)
            {
                case BbCycleDate.Year:
                    typeName = "年计划总结";
                    break;
                case BbCycleDate.Month:
                    typeName = "月计划总结";
                    break;
                case BbCycleDate.Week:
                    typeName = "周计划总结";
                    break;
                default:
                    typeName = "工作日志";
                    break;
            }
            return typeName;
        }
    }
}
