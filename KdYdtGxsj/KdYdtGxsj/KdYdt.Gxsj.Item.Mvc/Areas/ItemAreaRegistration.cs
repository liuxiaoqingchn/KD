using System.Web.Mvc;
using KdYdt.Gxsj.Item.Domains.Services;
using KdCore.Data.EntityFramework;


namespace KdYdt.Gxsj.Item.Mvc.Areas
{
    public class ItemAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// 全生命管理周期系统区域（Area）注册工具
        /// </summary>
        public override string AreaName { get { return "Item"; } }

        /// <summary>
        /// 使用指定区域的上下文信息在 ASP.NET MVC 应用程序内注册某个区域
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            KdDbContextFactory.DbRegister<PrjDbItemContext>("DbItem");

            context.MapRoute(
                "Item_default",
                "Item/{controller}/{action}/{id}",
                    new { controller = "ItemHome", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
