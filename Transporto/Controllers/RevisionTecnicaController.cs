using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Transporto.Filters;
using Transporto.Helpers;
using Transporto.Models;
using Transporto.ViewModels.RevisionTecnica;

namespace Transporto.Controllers
{
    public class RevisionTecnicaController : BaseController
    {
        public ActionResult ListRevisionTecnica(Int32? p, string Placa)
        {
            var viewModel = new ListRevisionTecnicaModel();
            viewModel.Fill(CargarDatosContext(), p, Placa);

            return View(viewModel);
        }
    }
}