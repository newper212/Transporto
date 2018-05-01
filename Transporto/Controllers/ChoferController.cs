using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Transporto.Helpers;
using Transporto.Models;
using System.Web.Mvc;
using Transporto.ViewModels.Chofer;

namespace Transporto.Controllers
{
    public class ChoferController : BaseController
    {
        public ActionResult ListChofer(int? p)
        {
            var model = new ListChoferViewModel();
            model.Fill(CargarDatosContext(), p);
            return View(model);    
        }

        //get
        public ActionResult AddEditChofer(int? ChoferId)
        {
            var model = new AddEditChoferViewModel();
            model.Fill(CargarDatosContext(), ChoferId);
            return View(model);
        }

        //post
        [HttpPost]
        public ActionResult AddEditChofer(AddEditChoferViewModel model)
        {
            try
            {
                using (var transactionscope = new TransactionScope())
                {
                    var chofer = context.Chofer.Find(model.Choferid);
                    if (chofer == null)
                    {

                        chofer = new Chofer();

                        chofer.Estado = ConstantHelpers.ESTADO.ACTIVO;

                        context.Chofer.Add(chofer);
                    }

                    chofer.NombreChofer = model.NombreChofer;
                    chofer.ApellidosChofer = model.ApellidoChofer;
                    chofer.DNIChofer = model.DNICHOFER;
                    chofer.FuncionChofer = model.FuncionChofer;
                    chofer.NumeroBreveteChofer = model.NumeroBrevete;
                    chofer.FechaDActivacionBrevete = model.FechaActivacionBrevete;
                    chofer.FecchaVencimientoBrevete = model.FechaVencimientoBrevete;
                    chofer.CelularPersonalChofer = model.CelularPersonal;
                    chofer.CelularCorporativoChofer = model.CelularCorporativo;
                    chofer.EmailChofer = model.Email;

                    context.SaveChanges();
                    transactionscope.Complete();
                    PostMessage(MessageType.Success);

                    return RedirectToAction("ListChofer");

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        public ActionResult _DeleteChoferViewModel(Int32 ChoferId)
        {
            var model = new _DeleteChoferViewModel();
            model.ChoferID = ChoferId;
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult DeleteChofer(_DeleteChoferViewModel model)
        {
            try
            {
                var chofer = context.Chofer.Find(model.ChoferID);
                chofer.Estado = ConstantHelpers.ESTADO.INACTIVO;

                context.SaveChanges();
                PostMessage(MessageType.Success);


            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, ex.Message);

            }
            return RedirectToAction("ListChofer");
        }
    }






}
