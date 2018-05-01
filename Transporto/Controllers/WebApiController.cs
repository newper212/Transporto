using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transporto.Models.Entities;
using Transporto.Models;
using System.Transactions;
using Transporto.Helpers;

namespace Transporto.Controllers
{
    public class WebApiController : BaseController
    {
        // GET: WebApi
        public JsonResult GetProvincia(int DepartamentoId)
        {
            var data = context.Provincia.Where(x => x.DepartamentoId == DepartamentoId)
                .Select(x => new
                {
                    id = x.ProvinciaId,
                    text = x.Nombre
                }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistrito(int ProvinciaId)
        {
            var data = context.Distrito.Where(x => x.ProvinciaId == ProvinciaId)
                .Select(x => new
                {
                    id = x.DistritoId,
                    text = x.Nombre
                }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}