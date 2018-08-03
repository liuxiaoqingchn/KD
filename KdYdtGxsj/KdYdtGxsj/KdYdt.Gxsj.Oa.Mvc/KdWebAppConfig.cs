using System;
using System.Web;
using KdCore;
using KdCore.Web.Mvc;
using KdCore.Web.Resource;
using KdWeb.Common;
using KdYdt.Gxsj.Oa.Domains;

namespace KdYdt.Gxsj.Oa.Mvc
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
            KdBaseContext.IsModuleFunction = true;

            KdBaseContext.Config.UseUserTheme = true;

            KdPrjDomainsManager.Init();

            KdWebContext.InitAppContext(application);
            KdWebContext.RegisterAssembly<KdWebResource>();
            KdWebContext.RegisterAssembly<KdWebKdResource>();
            KdWebContext.RegisterAssembly<KdViewsCommon>();

            KdWebUserExts.RegisterUserPm();
            KdWebContext.Func_ProcessLeftMenuTagA = KdWebUserExts.ProcessLeftMenuTagA;
        }
    }
}