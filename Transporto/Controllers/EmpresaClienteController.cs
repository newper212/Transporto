using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Transporto.Helpers;
using Transporto.Models;
using System.Web.Mvc;
using Transporto.ViewModels.EmpresaCliente;

namespace Transporto.Controllers
{
    public class EmpresaClienteController : BaseController
    {
        public ActionResult LstEmpresaCliente(int? p)
        {
            var model = new ListEmpresaViewModel();
            model.Fill(CargarDatosContext(), p);

            return View(model);
        }

        public ActionResult LstContacto(int? p)
        {
            var model = new ListEmpresaViewModel();
            model.Fill(CargarDatosContext(), p);
            return View(model);
        }

        //get
        public ActionResult AddEditEmpresaCliente(int? clienteId)
        {
            var model = new AddEditEmpresaViewModel();
            model.Fill(CargarDatosContext(), clienteId);
            return View(model);
        }

        //post
        [HttpPost]
        public ActionResult AddEditEmpresaCliente(AddEditEmpresaViewModel model)
        {
            try
            {
                using (var transactionscope = new TransactionScope())
                {
                    var empresacliente = context.EmpresaCliente.Find(model.EmpresaId);

                    if (empresacliente == null)
                    {
                        empresacliente = new EmpresaCliente();
                        empresacliente.Estado = ConstantHelpers.ESTADO.ACTIVO;

                        context.EmpresaCliente.Add(empresacliente);
                    }

                    empresacliente.Ruc = model.Ruc;
                    empresacliente.NombreEmpresa = model.NombreEmpresa;
                    empresacliente.TelefonoCorporativo = model.TelefonoCorporativo;
                    empresacliente.Direccion = model.Direccion;
                    empresacliente.IDDistrito = model.DistritoId;
                    empresacliente.EmailCorporativa = model.EmailCorporativo;
                    empresacliente.Observaciones = model.Observaciones;
                    empresacliente.DNIContaco = model.DniContacto;
                    empresacliente.NombreContacto = model.NombreContacto;
                    empresacliente.ApellidoContacto = model.ApellidoContacto;
                    empresacliente.CelularContacto = model.CelularContacto;
                    empresacliente.EmailContaco = model.EmailContacto;
                    

                    context.SaveChanges();
                    transactionscope.Complete();
                    PostMessage(MessageType.Success);

                    return RedirectToAction("LstEmpresaCliente");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult _DeleteEmpresaCliente(Int32 clienteId)
        {
            var model = new _DeleteEmpresaCliente();
            model.EmpresaId = clienteId;

            return PartialView(model);
        }

        public ActionResult DeleteEmpresaCliente(_DeleteEmpresaCliente model)
        {
            try
            {
                var empresacliente = context.EmpresaCliente.Find(model.EmpresaId);

                empresacliente.Estado = ConstantHelpers.ESTADO.INACTIVO;

                context.SaveChanges();
                PostMessage(MessageType.Success);
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, ex.Message);

            }
            return RedirectToAction("LstEmpresaCliente");
        }


    }
}