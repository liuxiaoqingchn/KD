using System.Web;
using System.Web.Http;
using System.Web.Routing;
using KdCore;
using KdCore.Data.DbServices;
using KdCore.Web.Mvc;
using KdCore.Web.Resource;
using KdWeb.Common;

namespace KdYdt.Gxsj.WebManage
{
    /// <summary>
    /// Web 应用程序配置管理
    /// </summary>
    public static class KdWebAppConfig
    {
        /// <summary>
        /// 应用程序初始化
        /// </summary>
        /// <param name="application"></param>
        public static void Init(HttpApplication application)
        {
            KdBaseContext.IsModuleManage = true;

            //KdDomainsManager.Init();
            KdDbDictsService.Register();
            KdDbAuthsService.Register(null);
            KdDbLogsService.DbRegister("DbLogs");
            KdDbAnnexsService.Register(null);
            KdDbUsersService.Register(null, false);

            KdWebContext.InitAppContext(application);
            KdWebContext.RegisterAssembly<KdWebResource>();
            KdWebContext.RegisterAssembly<KdWebKdResource>();
            KdWebContext.RegisterAssembly<KdViewsCommon>();
            KdWebContext.RegisterAssembly(typeof(KdWebUserExts));
        }
    }
}