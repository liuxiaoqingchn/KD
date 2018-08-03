using KdCore.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdYdt.Gxsj.Item.Domains.ViewModels
{
    public class PrjTender
    {
        public string Id { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Prov { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }   
        /// <summary>
        /// 项目编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 建设单位
        /// </summary>
        public string BuilUnit { get; set; }
        /// <summary>
        /// 招标公告开始时间
        /// </summary>
        public string BeginDate { get; set; }
        /// <summary>
        /// 招标公告截止时间
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// 项目地址
        /// </summary>
        public string ProjectAddr { get; set; }
        /// <summary>
        /// 原网页网址
        /// </summary>
        public string InfoUrl { get; set; }   
        /// <summary>
        /// 工程类别
        /// </summary>
        public string InviteType { get; set; }
        /// <summary>
        /// 发布机构
        /// </summary>
        public string MsgType { get; set; }

    }
}
