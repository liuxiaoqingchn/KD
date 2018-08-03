using KdCore;
using KdCore.Data.DbServices;
using KdCore.Data.EntityFramework;

namespace KdYdt.Gxsj.Oa.Domains
{
    /// <summary>
    /// 项目数据模型配置及系统设置
    /// </summary>
    public static class KdPrjDomainsManager
    {
        /// <summary>
        /// 数据模型初始化
        /// </summary>
        public static void Init()
        {
            KdDbDictsService.Register();
            KdDbAuthsService.Register(null);
            KdDbLogsService.Register("DbLogs");
            KdDbAnnexsService.Register(null);
            KdDbUsersService.Register(null, true);

            KdDbContextFactory.DbRegister<Services.PrjDbOaContext>();
        }
    }
}
