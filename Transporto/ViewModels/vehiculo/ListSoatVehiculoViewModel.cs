using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transporto.Controllers;
using Transporto.Models;

namespace Transporto.ViewModels.vehiculo
{
    public class ListSoatVehiculoViewModel
    {

        public Int32? vehiculoId { get; set; }

        public Int32? SoatId { get; set; }

        public string numeroSoat { get; set; }

        public DateTime fechaEmision { get; set; }

        public DateTime fechaCaducidad { get; set; }


        public void Fill(CargarDatosContext context, Int32? _vehiculoId, Int32? _soatId)
        {

            this.vehiculoId = _vehiculoId;
            this.SoatId = _soatId;

            IQueryable<Soat> querySoat = context.context.Soat.AsQueryable();

            if (_vehiculoId.HasValue)
            {
                var soat = context.context.Soat.Find(_vehiculoId);
                this.vehiculoId = soat.VehiculoId;
                this.SoatId = soat.SoatId;
                this.numeroSoat = soat.Numero;
                this.fechaEmision = soat.FechaEmision;
                this.fechaCaducidad = soat.FechaCaducidad;



            }





        }
    }
}