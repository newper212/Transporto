﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.Mvc.Ajax;

namespace Transporto.Helpers
{
    public class ModalFormHelpers
    {
        public String ActionName { get; set; }
        public String ControllerName { get; set; }
        public object RouteValues { get; set; }
        public FormMethod Method { get; set; }
        public object HtmlAttributes { get; set; }

        public ModalFormHelpers()
        {
        }

        public ModalFormHelpers(object routeValues)
        {
            RouteValues = routeValues;
            Method = FormMethod.Post;
        }

        public ModalFormHelpers(string actionName, string controllerName)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            Method = FormMethod.Post;
        }

        public ModalFormHelpers(string actionName, string controllerName, FormMethod method)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            Method = method;
        }

        public ModalFormHelpers(string actionName, string controllerName, object routeValues)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
            Method = FormMethod.Post;
        }

        public ModalFormHelpers(string actionName, string controllerName, FormMethod method, object htmlAttributes)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            Method = method;
            HtmlAttributes = htmlAttributes;
        }

        public ModalFormHelpers(string actionName, string controllerName, object routeValues, FormMethod method)
        {

            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
            Method = method;
        }

        public ModalFormHelpers(string actionName, string controllerName, object routeValues, FormMethod method, object htmlAttributes)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
            Method = method;
            HtmlAttributes = htmlAttributes;
        }

        public MvcForm BeginForm(HtmlHelper htmlHelper)
        {
            var dataHelper = ((Transporto.Helpers.AppWebViewPage<dynamic>)htmlHelper.ViewDataContainer).Data;
            var autoTargetParams = dataHelper.CreateAutoTargetAjaxAttributes().ToString();
            var htmlAttributes = new RouteValueDictionary(HtmlAttributes);

            if (!String.IsNullOrWhiteSpace(autoTargetParams))
            {
                foreach (var autoTargetParam in autoTargetParams.Split(' '))
                {
                    if (String.IsNullOrWhiteSpace(autoTargetParam))
                        continue;

                    var attribute = autoTargetParam.Substring(0, autoTargetParam.IndexOf("="));
                    var value = autoTargetParam.Substring(attribute.Length + 2, autoTargetParam.Length - attribute.Length - 3);
                    htmlAttributes[attribute] += value;
                }
                htmlAttributes["data-ajax-success"] = "AutoTargetAjaxCerrarModal";
            }

            return htmlHelper.BeginForm(ActionName, ControllerName, new RouteValueDictionary(RouteValues), Method, htmlAttributes);
        }
    }

    public class ModalAjaxFormHelpers
    {
        public String ActionName { get; set; }
        public String ControllerName { get; set; }
        public object RouteValues { get; set; }
        public AjaxOptions AjaxOptions { get; set; }
        public object HtmlAttributes { get; set; }

        public ModalAjaxFormHelpers(AjaxOptions ajaxOptions)
        {
            AjaxOptions = ajaxOptions;
        }

        public ModalAjaxFormHelpers(object routeValues, AjaxOptions ajaxOptions)
        {
            RouteValues = routeValues;
            AjaxOptions = ajaxOptions;
        }

        public ModalAjaxFormHelpers(string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            AjaxOptions = ajaxOptions;
        }


        public ModalAjaxFormHelpers(string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            RouteValues = routeValues;
            AjaxOptions = ajaxOptions;
        }

        public ModalAjaxFormHelpers(string actionName, string controllerName, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            ActionName = actionName;
            ControllerName = controllerName;
            HtmlAttributes = htmlAttributes;
            AjaxOptions = ajaxOptions;
        }

        public MvcForm BeginForm(AjaxHelper ajaxHelper)
        {
            return ajaxHelper.BeginForm(ActionName, ControllerName, RouteValues, AjaxOptions, HtmlAttributes);
        }
    }
}