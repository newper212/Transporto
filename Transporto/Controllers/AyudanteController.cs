using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Transporto.Helpers;
using Transporto.Models;
using System.Web.Mvc;
using Transporto.ViewModels.Ayudante;


namespace Transporto.Controllers
{
    public class AyudanteController : BaseController
    {
        // GET: Ayudante
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListAyudante(int? p)
        {
            var model = new ListAyudanteViewModel();
            model.Fill(CargarDatosContext(), p);
            return View(model);
        }
        //get
        public ActionResult AddEditAyudante(int? idAyudante)
        {
            var model = new AddEditAyudanteViewModel();
            model.Fill(CargarDatosContext(), idAyudante);
            return View(model);
        }
        //post
        [HttpPost]
        public ActionResult AddEditAyudante(AddEditAyudanteViewModel model)
        {
            try
            {
                using (var transactionscope = new TransactionScope())
                {
                    var ayudante = context.Ayudante.Find(model.IDAyudante);


                    if (ayudante == null)
                    {
                        ayudante = new Ayudante();

                        ayudante.Estado = ConstantHelpers.ESTADO.ACTIVO;

                        context.Ayudante.Add(ayudante);

                    }
                    ayudante.NombreAyudante = model.NombreAyudante;
                    ayudante.ApellidoAyudante = model.ApellidoAyudante;
                    ayudante.DNIAyudante = model.DNIAyudante;
                    ayudante.DireccionAyudante = model.DireccionAyudante;
                    ayudante.TelefonoAyudante = model.TelefonoAyudante;
                    ayudante.CelularAyudante = model.CelularAyudante;
                    ayudante.Estado = ConstantHelpers.ESTADO.ACTIVO;

                    context.SaveChanges();
                    transactionscope.Complete();
                    PostMessage(MessageType.Success);
                    return RedirectToAction("ListAyudante");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        public ActionResult _DeleteAyudanteViewModel(int idAyudante)
        {
            var model = new _DeleteAyudanteViewModel();
            model.AyudanteID = idAyudante;
            return PartialView(model);
        }
        public ActionResult DeleteAyudante(_DeleteAyudanteViewModel model)
        {
            try
            {
                var ayudante = context.Ayudante.Find(model.AyudanteID);
                ayudante.Estado = ConstantHelpers.ESTADO.INACTIVO;

                context.SaveChanges();
                PostMessage(MessageType.Success);
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, ex.Message);

            }
            return RedirectToAction("ListAyudante");
        }
    }
}