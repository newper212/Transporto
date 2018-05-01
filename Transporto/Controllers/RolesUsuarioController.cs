using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Transporto.Helpers;
using Transporto.Models;
using System.Web.Mvc;
using Transporto.ViewModels.RoldeUsuario;


namespace Transporto.Controllers
{
    public class RolesUsuarioController : BaseController
    {

        public ActionResult ListRolUsuario(int? p)
        {
            var model = new ListRoldUsuarioViewModel();
            model.Fill(CargarDatosContext(), p);

            return View(model);
        }

        
        public ActionResult AddEditRolUsuario(int? idRolDusuario)
        {
            var model = new AddEditRolViewModel();
            model.Fill(CargarDatosContext(), idRolDusuario);
            return View(model);
        }

        //post
        [HttpPost]
        public ActionResult AddEditRolUsuario(AddEditRolViewModel model)
        {
            try
            {
                using (var transactionscope = new TransactionScope())
                {
                    var rolusuario = context.RolesDeUsuario.Find(model.IDRolDusuario);

                    if (rolusuario == null)
                    {
                        rolusuario = new RolesDeUsuario();
                        rolusuario.Estado = ConstantHelpers.ESTADO.ACTIVO;
                        context.RolesDeUsuario.Add(rolusuario);
                    }

                    rolusuario.IDUsuario = model.usuarioID;
                    rolusuario.IDRol = model.ROLID;
                 
                    context.SaveChanges();
                    transactionscope.Complete();
                    PostMessage(MessageType.Success);

                    return RedirectToAction("ListRolUsuario");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        public ActionResult _DeleteRolUsuario(Int32 idRolDusuario)
        {
            var model = new _DeleteRoldeUsuarioViewModel();
            model.RolUsuarioID = idRolDusuario;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteRolUsuario(_DeleteRoldeUsuarioViewModel model)
        {
            try
            {
                var rolDUsuairo = context.RolesDeUsuario.Find(model.RolUsuarioID);
                rolDUsuairo.Estado = ConstantHelpers.ESTADO.INACTIVO;
                context.SaveChanges();
                PostMessage(MessageType.Success);
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, ex.Message);
            }

            return RedirectToAction("ListRolUsuario");
        }
    }








}
