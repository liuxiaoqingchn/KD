using System;

using KdYdt.Gxsj.Oa.Mvc;

namespace KdYdt.Gxsj.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            KdWebAppConfig.Init(this);
        }
    }
}