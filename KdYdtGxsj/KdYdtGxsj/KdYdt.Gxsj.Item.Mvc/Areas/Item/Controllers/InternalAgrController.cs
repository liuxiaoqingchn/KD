using System;
using System.Web.Mvc;

using KdCore;
using KdCore.Office;

using KdYdt.Gxsj.Item.Domains.EditModels;
using KdYdt.Gxsj.Item.Domains.Models;

namespace KdYdt.Gxsj.Item.Mvc.Areas.Item.Controllers
{
    /// <summary>
    /// 内部协议
    /// </summary>
    [KdUnitGroup("内部协议", 190, true)]
    public class InternalAgrController : ItemBaseController<PayPact, PayPactEdit>
    {
        [KdAction("编辑")]
        [HttpPost]
        public override ActionResult Edit(PayPactEdit editModel)
        {
            return base.Edit(editModel);
        }
        private KdWord GetWordTemplate(string templateName)
        {
            return new KdWord(this.GetTemplatePath(templateName));
        }

        /// <summary>
        /// 导出中浦信内部协议信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private string ExportOut(PayPact item)
        {
            string filePath = this.GetReportFileSavePath(string.Format("中浦信内部协议-{0}.docx", item.PrjName), false);
            try
            {
                KdWord word = this.GetWordTemplate("中浦信内部协议模板.docx");
                #region 填充数据 
                word.ResetText("PrjName", item.PrjName);
                word.ResetText("PactSignDate", item.PactSignDate);
                #endregion
                word.SaveTo(filePath);
            }
            catch (Exception e)
            {
                this.Logger.Error(e);
                filePath = null;
            }
            return filePath;
        }
        /// <summary>
        /// 导出内部协议信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [KdAction("导出内部协议")]
        public ActionResult Report(string id)
        {
            PayPact paypact = this.DbService.DbView<PayPact>(id);
            string filePath = this.ExportOut(paypact);
            return this.KdFileDownloadByPath(filePath, string.Format("中浦信内部协议{0}.docx", DateTime.Today.ToDateString()));
        }
        /// <summary>
        /// 导出联合体协议
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private string UnionExportOut(PayPact item)
        {
            string filePath = this.GetReportFileSavePath(string.Format("联合体协议协议-{0}.docx", item.PrjName), false);
            try
            {
                KdWord word = this.GetWordTemplate("联合体协议模板.docx");
                #region 填充数据 
                word.ResetText("PrjName", item.PrjName);
                //word.ResetText("PactSignDate", item.PactSignDate);
                #endregion
                word.SaveTo(filePath);
            }
            catch (Exception e)
            {
                this.Logger.Error(e);
                filePath = null;
            }
            return filePath;
        }
        /// <summary>
        /// 导出联合体协议
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [KdAction("导出联合体协议")]
        public ActionResult UnionReport(string id)
        {
            PayPact paypact = this.DbService.DbView<PayPact>(id);
            string filePath = this.UnionExportOut(paypact);
            return this.KdFileDownloadByPath(filePath, string.Format("联合体协议{0}.docx", DateTime.Today.ToDateString()));
        }
    }
}
