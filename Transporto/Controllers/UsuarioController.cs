using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Transporto.Helpers;
using Transporto.Models;
using System.Web.Mvc;
using Transporto.ViewModels.usuario;

namespace Transporto.Controllers
{
    public class UsuarioController : BaseController
    {
        public ActionResult ListUsuario(int? p)
        {
            var model = new ListUsuarioViewModel();
            model.Fill(CargarDatosContext(), p);

            return View(model);
        }

        //get
        public ActionResult AddEditUsuario(int? usuarioId)
        {
            var model = new AddEditUsuarioViewModel();
            model.Fill(CargarDatosContext(), usuarioId);

            return View(model);
        }

        //post
        [HttpPost]
        public ActionResult AddEditUsuario(AddEditUsuarioViewModel model)
        {
            try
            {
                using (var transactionscope = new TransactionScope())
                {
                    var usuario = context.Usuario.Find(model.UsuarioId);
                    if (usuario == null)
                    {
                        usuario = new Usuario();
                        usuario.Estado = ConstantHelpers.ESTADO.ACTIVO;

                        context.Usuario.Add(usuario);

                    }

                    usuario.Codigo = model.Usuario;
                    usuario.Comtrasena = model.Comtrasena;
                    usuario.Nombre = model.Nombre;
                    usuario.Apellido = model.Apellido;
                    usuario.Dni = model.DNI;
                    usuario.Estado = ConstantHelpers.ESTADO.ACTIVO;

                    context.SaveChanges();
                    transactionscope.Complete();
                    PostMessage(MessageType.Success);

                    return RedirectToAction("ListUsuario");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();

            }
        }

        public ActionResult _DeleteUsuario(Int32 usuarioId)
        {
            var model = new _DeleteUsuarioViewModel();
            model.usuarioID = usuarioId;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteUsuario(_DeleteUsuarioViewModel model)
        {
            try
            {
                var usuario = context.Usuario.Find(model.usuarioID);
                usuario.Estado = ConstantHelpers.ESTADO.INACTIVO;
                context.SaveChanges();
                PostMessage(MessageType.Success);
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, ex.Message);
            }

            return RedirectToAction("ListUsuario");
        }
    }
}
