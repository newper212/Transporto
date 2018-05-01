using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Transporto.Helpers;
using Transporto.Models;
using System.Web.Mvc;
using Transporto.ViewModels.Mantenimiento;

namespace Transporto.Controllers
{
    public class MantenimientoController : BaseController
    {
        public ActionResult ListMantenimiento(int? p)
        {
            var model = new ListMantenimientoViewModel();
            model.Fill(CargarDatosContext(), p);
            return View(model);
        }

        //get
        public ActionResult AddEditMantenimiento(int? idMantenimiento)
        {
            var model = new AddEditMantenimientoViewModel();
            model.Fill(CargarDatosContext(), idMantenimiento);
            return View(model);
        }

        //post
        [HttpPost]
        public ActionResult AddEditMantenimiento(AddEditMantenimientoViewModel model)
        {
            try
            {
                using (var transactionscope = new TransactionScope())
                {
                    var mantenimiento = context.Mantenimiento.Find(model.IDMantenimiento);

                    if (mantenimiento == null)
                    {
                        mantenimiento = new Mantenimiento();
                        mantenimiento.Estado = ConstantHelpers.ESTADO.ACTIVO;
                        context.Mantenimiento.Add(mantenimiento);
                    }

                    mantenimiento.Kilometraje = model.Kilometraje;
                    mantenimiento.FechaMantenimiento = model.FechaMantenimiento;
                    mantenimiento.Taller = model.Taller;
                    mantenimiento.FechaDMantenimientoObcional = model.FechaDMantenimientoObcional;
                    mantenimiento.Monto = model.Monto;
                    mantenimiento.Motivo = model.Motivo;
                    mantenimiento.IDUsuario = model.usuarioID;
                    mantenimiento.IDVehiculo = model.vehiculoID;

                    context.SaveChanges();
                    transactionscope.Complete();
                    PostMessage(MessageType.Success);

                    return RedirectToAction("ListMantenimiento");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        public ActionResult _Deletemantenimiento(Int32 idMantenimiento)
        {
            var model = new _DeleteMantenimientoViewModel();
            model.matenimientoID = idMantenimiento;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteMantenimiento(_DeleteMantenimientoViewModel model)
        {
            try
            {
                var mantenimiento = context.Mantenimiento.Find(model.matenimientoID);
                mantenimiento.Estado = ConstantHelpers.ESTADO.INACTIVO;
                context.SaveChanges();
                PostMessage(MessageType.Success);
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, ex.Message);
            }

            return RedirectToAction("ListMantenimiento");
        }
    }
}
