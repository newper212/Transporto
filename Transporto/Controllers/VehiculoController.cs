using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Transporto.Helpers;
using Transporto.Models;
using System.Web.Mvc;
using Transporto.ViewModels.vehiculo;

namespace Transporto.Controllers
{
    public class VehiculoController : BaseController
    {
        public ActionResult ListVehiculo(int? p)
        {
            var model = new ListVehiculoViewModel();
            model.Fill(CargarDatosContext(), p);

            return View(model);
        }

        public ActionResult ListSoat(int? p)
        {
            var model = new ListVehiculoViewModel();
            model.Fill(CargarDatosContext(), p);

            return View(model);
        }

        public ActionResult ListEstadoVehiculo(int? p)
        {
            var model = new ListVehiculoViewModel();
            model.Fill(CargarDatosContext(), p);

            return View(model);
        }


        //get
        public ActionResult AddEditVehiculo(int? VehiculoId)
        {
            var model = new AddEditVehiculoViewModel();
            model.Fill(CargarDatosContext(), VehiculoId);

            return View(model);
        }

        //post
        [HttpPost]
        public ActionResult AddEditVehiculo(AddEditVehiculoViewModel model)
        {
            try
            {
                using (var transactionscope = new TransactionScope())
                {
                    var vehiculo = context.Vehiculo.Find(model.VehiculoId);

                    if (vehiculo == null)
                    {
                        vehiculo = new Vehiculo();
                        vehiculo.Estado = ConstantHelpers.ESTADO.ACTIVO;

                        context.Vehiculo.Add(vehiculo);
                    }

                    vehiculo.Marca = model.Marca;
                    vehiculo.Modelo = model.Modelo;
                    vehiculo.Tipo = model.Tipo;
                    vehiculo.Placa = model.Placa;
                    vehiculo.SoatFechaInic = model.FechaInicioSOAT;
                    vehiculo.SoatFechVenc = model.FechaVencimientoSOAT;
                    vehiculo.Peso = model.Peso;
                    vehiculo.Volumen = model.Volumen;
                    vehiculo.FechaDeInicioRevisionTecn = model.FechaInicRevicTecn;
                    vehiculo.FechaDeCaducidadReviciTecni = model.FechaCaducidadRevicionTec;
                    vehiculo.FechaIncioSeguroVehicular = model.FechaInicioSeguro;
                    vehiculo.FechaCaducidadSeguVehicu = model.FechaCaduidadSeguro;
                    vehiculo.NumeroHabilitacion = model.NumeroDeHabilitacion;
                    vehiculo.FechaInicioCertificadoFumiga = model.FechaIncioCertificado;
                    vehiculo.FechaCaducidadCertificadoFumiga = model.FechaCadicidadCertificado;

                    context.SaveChanges();
                    transactionscope.Complete();

                    PostMessage(MessageType.Success);
                    return RedirectToAction("ListVehiculo");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                TryUpdateModel(model);

                return View(model);
            }
        }

        public ActionResult _DeleteVehiculoViewModelcs(Int32 VehiculoId)
        {
            var model = new _DeleteVehiculoViewModelcs();
            model.VehiculoId = VehiculoId;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult DeleteVehiculo(_DeleteVehiculoViewModelcs model)
        {
            try
            {
                var vehiculo = context.Vehiculo.Find(model.VehiculoId);
                vehiculo.Estado = ConstantHelpers.ESTADO.INACTIVO;

                context.SaveChanges();
                PostMessage(MessageType.Success);

            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, ex.Message);
            }
            return RedirectToAction("ListVehiculo");
        }

    }


}
