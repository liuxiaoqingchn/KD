using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc
{
    public static class PrjHtmlHelper
    {
        public static HtmlString ToIconLight(this HtmlHelper helper, int? lampStatus)
        {
            string icon = null;
            string cssColor = null;
            string tipTitle = null;
            switch (lampStatus)
            {
                default:
                    icon = "certificate";
                    cssColor = "warning";
                    tipTitle = "黄灯(即将超期和未报送)";
                    break;
                case 1:
                    icon = "certificate";
                    cssColor = "success";
                    tipTitle = "绿灯(按时报送)";
                    break;
                case 2:
                    icon = "certificate";
                    cssColor = "danger";
                    tipTitle = "红灯(已超期)";
                    break;
                case 3:
                    icon = "certificate";
                    cssColor = "danger";
                    tipTitle = "红灯(严重超期)";
                    break;
            }
            string html = string.Format("<i class='glyphicon glyphicon-{0} text-{1}' title='{2}'></i>", icon, cssColor, tipTitle);
            return new HtmlString(html);
        }
        /// <summary>
        /// 根据时间亮灯
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="planTime"></param>
        /// <param name="hours"></param>
        /// <param name="LampStatus"></param>
        /// <returns></returns>
        public static HtmlString PlanLamp(this HtmlHelper helper, DateTime? planTime, int yellHours = 72, int redHours = 24, string LampStatus = null)
        {
            string icon = null;
            string cssColor = null;
            string tipTitle = null;
            string fmt = "<i class='glyphicon glyphicon-{0} text-{1}' title='{2}'></i>";
            string html;
            if (planTime != null)//计划完成时间
            {
                DateTime time = DateTime.Now;
                DateTime yellTime = ((DateTime)planTime).AddHours(-yellHours);
                DateTime redTime = ((DateTime)planTime).AddHours(-redHours);
                if (time < yellTime)
                {
                    icon = "certificate";
                    cssColor = "success";
                    tipTitle = "绿灯(正常)";
                }
                else if (time >= yellTime && time < redTime)
                {
                    icon = "certificate";
                    cssColor = "warning";
                    tipTitle = "黄灯(即将超期)";
                }
                else
                {
                    icon = "certificate";
                    cssColor = "danger";
                    tipTitle = "红灯(已超期)";
                }
            }
            if (planTime == null)
            {
                icon = "certificate";
                cssColor = "success";
                tipTitle = "绿灯(正常)";
            }
            html = string.Format(fmt, icon, cssColor, tipTitle);
            return new HtmlString(html);
        }
        public static HtmlString ConversionToPer(this HtmlHelper helper, int molecule, int Denominator)
        {
            string html = null;
            double percent = Convert.ToDouble(molecule) / Convert.ToDouble(Denominator);
            if (Denominator != 0 && molecule != 0)
            {
                html = percent.ToString("0.000%");
            }
            else
            {
                html = "0%";
            }
            return new HtmlString(html);
        }

    }
}
