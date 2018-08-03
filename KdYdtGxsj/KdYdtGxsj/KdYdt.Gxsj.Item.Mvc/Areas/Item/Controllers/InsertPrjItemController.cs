using KdCore;
using KdCore.Data;
using KdCore.Data.Dicts;
using KdCore.Data.Users;
using KdYdt.Gxsj.Item.Domains.Models;
using KdYdt.Gxsj.Item.Domains.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 保存数据到项目信息
    /// </summary>
    [KdUnitConfig(CheckLogin = BbEnableType.Disable)]
    public class InsertPrjItemController : ItemBaseController
    {
        [KdAction(null, 0, null, EveryOne = true)]
        [HttpPost]
        public string InsertData(string loginUser, string jsons)
        {
            KdUser user = this.GetDataService<KdCore.Data.DbServices.KdDbAuthsService>().ValidSingle<KdUser>(x => x.UserName == loginUser);
            if (user == null) return "请设置项目管理系统一点通数据保存专用账号，再进行数据保存操作。";     
            this.DbService.CurrUser = user;
            int count = 0, dataCount = 0;
            try
            {        
                List<PrjTender> list = JsonConvert.DeserializeObject<List<PrjTender>>(jsons);
                List<KdDictItem> dicts = KdDict.GetItems("TenderMthod");
                dataCount = list.Count;
                foreach (PrjTender item in list)
                {
                    string mthodName = this.GetTenderMthod(item.City);
                    KdDictItem dict = dicts.FirstOrDefault(x => x.NodeName.Contains(mthodName));
                    PrjItem entity = this.DbService.ValidSingle<PrjItem>(x =>
                    x.PrjName == item.ProjectName
                     && x.IsKdYdt 
                     && x.MsgType == item.MsgType
                     && x.InfoUrl == item.InfoUrl);
                    if (entity == null)
                    {
                        entity = new PrjItem();
                        entity.SetId();
                        entity.SaveMode = BbSaveMode.Insert;
                        entity.IsItem = false;
                        entity.IsSign = false;
                        entity.IsPrese = false;
                    }
                    else
                        entity.SaveMode = BbSaveMode.Update;
                    entity.PrjCode = item.Code;
                    entity.PrjName = item.ProjectName;
                    entity.BuildUnit = item.BuilUnit;
                    entity.MsgType = item.MsgType;
                    entity.InfoUrl = item.InfoUrl;
                    entity.IsKdYdt = true;
                    entity.NoticTime = item.BeginDate.TryToDateTime();
                    entity.EndDate = item.EndDate.TryToDateTime();
                    if (dict != null)
                    {
                        entity.TenderMthod = dict.NamePath;
                    }                               
                    this.DbService.Save(entity);
                }
                count = this.DbService.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return "保存数据出现错误，详情请查看日志文件。";
            } 
            return string.Format("选择处理数据 {0} 条，成功保存数据 {1} 条。", dataCount, count);
        }

        public string GetTenderMthod(string city)
        {
            string name = string.Empty;
            if (city.Contains("工程"))
                name = "交易";
            else if (city.Contains("政府"))
                name = "政府";
            else if (city.Contains("社会"))
                name = "社会";
            else
                name = "交易";
            return name;
        }
    }
}
