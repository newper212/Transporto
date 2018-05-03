using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transporto.Models;
using Transporto.Controllers;
using System.ComponentModel.DataAnnotations;
using PagedList;
using Transporto.Helpers;
using System.Web.Mvc;

namespace Transporto.ViewModels.vehiculo
{
    public class ListVehiculoViewModel
    {
        public int nElementos { get; set; }

        public Int32 numeroPagina { get; set; }
        public int p { get; set; }

        [Display(Name =  "Marca")]
        public string fMarca { get; set; }

        [Display(Name = "Modelo")]
        public string fModelo { get; set; }

        [Display(Name = "Estado")]
        public string fEstado { get; set; }
        
        //public List<SelectListItem> lstEstado { get; set; }

        public IPagedList<Vehiculo> LstVehiculo { get; set; }

        public void Fill(CargarDatosContext c ,int? numeroPagina, String marca, String modelo)
        {

            this.numeroPagina = numeroPagina ?? 1;
            this.fMarca = marca;
            this.fModelo = modelo;
            //this.fEstado = Estado;

            //lstEstado = new List<SelectListItem>(
            //    new SelectListItem[]
            //    {
            //        new SelectListItem { Text="Activo",Value=ConstantHelpers.ESTADO.ACTIVO},
            //        new SelectListItem { Text="Inactivo",Value=ConstantHelpers.ESTADO.INACTIVO}
            //    }
            //    );

            IQueryable<Vehiculo> queryVehiculo = c.context.Vehiculo.AsQueryable();

            if (!String.IsNullOrEmpty(fMarca))
                queryVehiculo = queryVehiculo.Where(x => x.Marca == fMarca);

            if (!String.IsNullOrEmpty(fModelo))
                queryVehiculo = queryVehiculo.Where(x => x.Modelo == fModelo);

            //if (!String.IsNullOrEmpty(Estado))
            //    queryVehiculo = queryVehiculo.Where(x => x.Estado == fEstado);

            queryVehiculo = queryVehiculo.Where(x=>x.Estado==ConstantHelpers.ESTADO.ACTIVO);

            this.LstVehiculo = queryVehiculo.OrderBy(x => x.Estado).ToPagedList(this.numeroPagina, ConstantHelpers.DEFAULT_PAGE_SIZE);

        }



    }
}