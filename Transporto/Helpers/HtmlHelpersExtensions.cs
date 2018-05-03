using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Text;

namespace Transporto.Helpers
{
    public static class HtmlHelpersExtensions
    {
        public static MvcHtmlString HelpFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return HelpHelper(html, ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData), ExpressionHelper.GetExpressionText(expression));
        }

        internal static MvcHtmlString HelpHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName)
        {
            string str = metadata.Description ?? "";
            if (string.IsNullOrEmpty(str))
            {
                return MvcHtmlString.Empty;
            }
            TagBuilder builder = new TagBuilder("p");
            builder.Attributes.Add("class", "help-block");
            builder.SetInnerText(str);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString DateTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return DateTextBoxFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString DateTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            var htmlAttributesDict = new RouteValueDictionary(htmlAttributes);

            if (!htmlAttributesDict.ContainsKey("class"))
                htmlAttributesDict.Add("class", "");
            htmlAttributesDict["class"] += " datepicker";

            if (metadata.Model.ToDateTime() == DateTime.MinValue)
                htmlAttributesDict.Add("Value", "");

            return htmlHelper.TextBoxFor(expression, "{0:dd/MM/yyyy}", htmlAttributesDict);

        }

        public static MvcHtmlString ModalEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return ModalEditorFor(html, expression, null, null);
        }

        public static MvcHtmlString ModalEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object additionalViewData)
        {
            return ModalEditorFor(html, expression, null, additionalViewData);
        }

        public static MvcHtmlString ModalEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string templateName)
        {
            return ModalEditorFor(html, expression, templateName, null);
        }

        public static MvcHtmlString ModalEditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string templateName, object additionalViewData)
        {
            if (templateName == null)
                templateName = "Modal/" + (Nullable.GetUnderlyingType(expression.ReturnType) ?? expression.ReturnType).Name;
            else
                templateName = "Modal/" + templateName;

            return html.EditorFor(expression, templateName, additionalViewData);
        }
        public static MvcHtmlString AppendElement(this TagBuilder val, TagBuilder ElementToAppend)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(val.ToString(TagRenderMode.StartTag));
            stringBuilder.Append(ElementToAppend.ToString());
            stringBuilder.Append("&nbsp;" + val.InnerHtml);
            stringBuilder.Append(val.ToString(TagRenderMode.EndTag));

            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }

    public static class BootstrapHtmlHelpers
    {
        public static MvcForm BeginFormBootstrap(this HtmlHelper html)
        {
            RouteData routeData = html.ViewContext.RouteData;
            String controller = routeData.GetRequiredString("controller");
            String action = routeData.GetRequiredString("action");

            return FormExtensions.BeginForm(html, action, controller, FormMethod.Post, new { @class = "form-horizontal" });
        }

        public static MvcHtmlString ValidationMessageBootstrapFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return MvcHtmlString.Create(
                    "<span class=\"help-inline\">" + Environment.NewLine +
                        (ValidationExtensions.ValidationMessageFor(htmlHelper, expression) ?? MvcHtmlString.Empty).ToString() + Environment.NewLine +
                    "</span>"
                    );
        }
    }
}