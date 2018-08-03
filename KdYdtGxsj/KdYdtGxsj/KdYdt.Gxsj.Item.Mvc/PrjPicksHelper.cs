using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using KdCore;
using KdCore.Data.Entity;
using KdCore.Web.Mvc;

namespace KdYdt.Gxsj.Item.Mvc
{
    public static class PrjPicksHelper
    {
        /// <summary>
        /// 中标项目选择
        /// </summary>
        public static HtmlString SjPickPrjBidFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, object>> valueExpression, Expression<Func<TModel, object>> textExpression, int maxCount = 1, int colInput = 0, bool? isRequired = null, string labelText = null, object routeValues = null, string onPickGetLoadUrl = null, string onPickSelected = null, object inputAttributes = null, object groupAttributes = null, object fieldAttributes = null, object labelAttributes = null)
        {
            KdPickConfig config = new KdPickConfig()
            {
                PickType = null,
                PickSource = "BidResult",
                PickRange = null,
                QueryActionName = "PrjBidPick",
                QueryControllerName = "PrjPicks",
                QueryAreaName = "Item",
                QueryRouteValues = routeValues.ToRouteValues(),
                IsRequired = isRequired,
                MaxPickCount = maxCount,
                ClientOnPickGetLoadUrl = onPickGetLoadUrl,
                ClientOnPickSelected = onPickSelected,
            };
            int colLabel = 0;
            string btnTooltip = null;
            return helper.BbDlgPickerFor(valueExpression, textExpression, config, colInput, colLabel, btnTooltip, labelText, inputAttributes, groupAttributes, fieldAttributes, labelAttributes);
        }
        /// <summary>
        /// 投标报名的选择项目立项
        /// </summary>
        public static HtmlString SjPickPrjPlanFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, object>> valueExpression, Expression<Func<TModel, object>> textExpression, int maxCount = 1, int colInput = 0, bool? isRequired = null, string labelText = null, object routeValues = null, string onPickGetLoadUrl = null, string onPickSelected = null, object inputAttributes = null, object groupAttributes = null, object fieldAttributes = null, object labelAttributes = null)
        {
            KdPickConfig config = new KdPickConfig()
            {
                PickType = null,
                PickSource = "PrjPlan",
                PickRange = null,
                QueryActionName = "PrjPlanPick",
                QueryControllerName = "PrjPicks",
                QueryAreaName = "Item",
                QueryRouteValues = routeValues.ToRouteValues(),
                IsRequired = isRequired,
                MaxPickCount = maxCount,
                ClientOnPickGetLoadUrl = onPickGetLoadUrl,
                ClientOnPickSelected = onPickSelected,
            };
            int colLabel = 0;
            string btnTooltip = null;
            return helper.BbDlgPickerFor(valueExpression, textExpression, config, colInput, colLabel, btnTooltip, labelText, inputAttributes, groupAttributes, fieldAttributes, labelAttributes);
        }
        /// <summary>
        /// 选择项目
        /// </summary>
        public static HtmlString SjPickPrjFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, object>> valueExpression, Expression<Func<TModel, object>> textExpression, int maxCount = 1, int colInput = 0, bool? isRequired = null, string labelText = null, object routeValues = null, string onPickGetLoadUrl = null, string onPickSelected = null, object inputAttributes = null, object groupAttributes = null, object fieldAttributes = null, object labelAttributes = null)
        {
            KdPickConfig config = new KdPickConfig()
            {
                PickType = null,
                PickSource = "Item",
                PickRange = null,
                QueryActionName = "PrjItemPick",
                QueryControllerName = "PrjPicks",
                QueryAreaName = "Item",
                QueryRouteValues = routeValues.ToRouteValues(),
                IsRequired = isRequired,
                MaxPickCount = maxCount,
                ClientOnPickGetLoadUrl = onPickGetLoadUrl,
                ClientOnPickSelected = onPickSelected,
            };
            int colLabel = 0;
            string btnTooltip = null;
            return helper.BbDlgPickerFor(valueExpression, textExpression, config, colInput, colLabel, btnTooltip, labelText, inputAttributes, groupAttributes, fieldAttributes, labelAttributes);
        }
        /// <summary>
        /// 选择项目经理
        /// </summary>
        public static HtmlString SjPickPrjManFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, object>> valueExpression, Expression<Func<TModel, object>> textExpression, int maxCount = 1, int colInput = 0, bool? isRequired = null, string labelText = null, object routeValues = null, string onPickGetLoadUrl = null, string onPickSelected = null, object inputAttributes = null, object groupAttributes = null, object fieldAttributes = null, object labelAttributes = null)
        {
            KdPickConfig config = new KdPickConfig()
            {
                PickType = null,
                PickSource = "PrjPerson",
                PickRange = null,
                QueryActionName = "PrjPersonPick",
                QueryControllerName = "PrjPicks",
                QueryAreaName = "Item",
                QueryRouteValues = routeValues.ToRouteValues(),
                IsRequired = isRequired,
                MaxPickCount = maxCount,
                ClientOnPickGetLoadUrl = onPickGetLoadUrl,
                ClientOnPickSelected = onPickSelected,
            };
            int colLabel = 0;
            string btnTooltip = null;
            return helper.BbDlgPickerFor(valueExpression, textExpression, config, colInput, colLabel, btnTooltip, labelText, inputAttributes, groupAttributes, fieldAttributes, labelAttributes);
        }
        /// <summary>
        /// 选择企业
        /// </summary>
        public static HtmlString SjPickCorpFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, object>> valueExpression, Expression<Func<TModel, object>> textExpression, int maxCount = 1, int colInput = 0, bool? isRequired = null, string labelText = null, object routeValues = null, string onPickGetLoadUrl = null, string onPickSelected = null, object inputAttributes = null, object groupAttributes = null, object fieldAttributes = null, object labelAttributes = null)
        {
            KdPickConfig config = new KdPickConfig()
            {
                PickType = null,
                PickSource = "PrjCorp",
                PickRange = null,
                QueryActionName = "PrjCorpPick",
                QueryControllerName = "PrjPicks",
                QueryAreaName = "Item",
                QueryRouteValues = routeValues.ToRouteValues(),
                IsRequired = isRequired,
                MaxPickCount = maxCount,
                ClientOnPickGetLoadUrl = onPickGetLoadUrl,
                ClientOnPickSelected = onPickSelected,
            };
            int colLabel = 0;
            string btnTooltip = null;
            return helper.BbDlgPickerFor(valueExpression, textExpression, config, colInput, colLabel, btnTooltip, labelText, inputAttributes, groupAttributes, fieldAttributes, labelAttributes);
        }
    }
}
