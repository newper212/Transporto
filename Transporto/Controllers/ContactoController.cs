using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Transporto.Helpers;
using Transporto.Models;
using System.Web.Mvc;
using Transporto.ViewModels.Contactos;

namespace Transporto.Controllers
{
    public class ContactoController : BaseController
    {
        // GET: Contacto


        public ActionResult ListContacto(int? p)
        {
            var model = new ListContactosViewModel();
            model.Fill(CargarDatosContext(), p);
            return View(model);
        }



        public ActionResult AddEditContacto(int? ContactoId)
        {
            var model = new AddContactosViewModel();
            model.Fill(CargarDatosContext(), ContactoId);
            return View(model);
        }
        //post
        [HttpPost]
        public ActionResult AddEditContacto(AddContactosViewModel model)
        {
            try
            {
                using (var transactionscope = new TransactionScope())
                {
                    var Contacto = context.Contactos.Find(model.ContactoId);

                    if (Contacto == null)
                    {
                        Contacto = new Contactos();

                        Contacto.Estado = ConstantHelpers.ESTADO.ACTIVO;

                        context.Contactos.Add(Contacto);
                    }

                    Contacto.Dni = model.DNI;
                    Contacto.Nombre = model.Nombre;
                    Contacto.Apellido = model.Apellido;
                    Contacto.Celular = model.Celular;
                    Contacto.EmailContacto = model.Email;
                    Contacto.IDEmpresa = model.empresaID;
              

                    context.SaveChanges();
                    transactionscope.Complete();

                    PostMessage(MessageType.Success);
                    return RedirectToAction("ListContacto");

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        public ActionResult _DeleteContactoViewModelcs(Int32 ContactoId)
        {
            var model = new _DeleteContatcosViewModel();
            model.ContactoId = ContactoId;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteContacto(_DeleteContatcosViewModel model)
        {
            try
            {
                var contacto = context.Contactos.Find(model.ContactoId);
                contacto.Estado = ConstantHelpers.ESTADO.INACTIVO;

                context.SaveChanges();
                PostMessage(MessageType.Success);

            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, ex.Message);

            }
            return RedirectToAction("ListContacto");
        }

    


}
}