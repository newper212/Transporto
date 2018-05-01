using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Transporto.Models;
//using BIT.Tools;
//using BIT.Tools.Functions;
using Transporto.Controllers;
using System.ComponentModel.DataAnnotations;
using PagedList;

namespace Transporto.ViewModels.vehiculo
{
    public class ListVehiculoViewModel
    {

        public int p { get; set; }
        [Display(Name =  "Marca")]
        public string Marca { get; set; }

     


        //public List<Models.Vehiculo> LstVehiculo { get; set; }

        public IPagedList<Models.Vehiculo> LstVehiculo { get; set; }

        public void Fill(CargarDatosContext c ,int? numeroPagina)
        {
            this.p = numeroPagina ?? 1;

            var query = c.context.Vehiculo.OrderBy(x => x.Marca).Where(x => x.Estado == "ACT");
            this.LstVehiculo = query.OrderBy(x => x.Estado).ToPagedList(p, 10);
        }



    }
}