using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Transporto.Helpers;
using Transporto.Models;
using System.Web.Mvc;
using Transporto.ViewModels.Rol;

namespace Transporto.Controllers
{
    public class RolController : BaseController
    {
        // GET: Rol
        public ActionResult ListRol(int? p)
        {
            var model = new ListRolViewModel();
            model.Fill(CargarDatosContext(), p);

            return View(model);
        }


        //get
        public ActionResult AddEditRol(int? RolId)
        {
            var model = new AddEditRolUsuarioViewModel();
            model.Fill(CargarDatosContext(), RolId);

            return View(model);
        }

        //post
        [HttpPost]
        public ActionResult AddEditRol(AddEditRolUsuarioViewModel model)
        {
            try
            {
                using (var transactionscope = new TransactionScope())
                {
                    var rol = context.Rol.Find(model.RolId);

                    if (rol == null)
                    {
                        rol = new Rol();
                        rol.Estado = ConstantHelpers.ESTADO.ACTIVO;

                        context.Rol.Add(rol);
                    }

                    rol.Rol1 = model.Rol;
                 

                    context.SaveChanges();
                    transactionscope.Complete();

                    PostMessage(MessageType.Success);
                    return RedirectToAction("ListRol");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TryUpdateModel(model);

                return View(model);
            }
        }

        public ActionResult _DeleteRolViewModelcs(Int32 RolId)
        {
            var model = new _DeleteRolViewModel();
            model.RolID = RolId;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteRol(_DeleteRolViewModel model)
        {
            try
            {
                var rol = context.Rol.Find(model.RolID);
                rol.Estado = ConstantHelpers.ESTADO.INACTIVO;

                context.SaveChanges();
                PostMessage(MessageType.Success);

            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, ex.Message);
            }
            return RedirectToAction("ListRol");
        }

    }
}
