using System;
using KdCore;

namespace KdYdt.Gxsj.WebManage
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            KdWebAppConfig.Init(this);
        }
    }
}