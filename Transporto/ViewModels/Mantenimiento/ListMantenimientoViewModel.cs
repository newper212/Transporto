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
using System.Data.Entity;
using Transporto.Helpers;

namespace Transporto.ViewModels.Mantenimiento
{
    public class ListMantenimientoViewModel
    {
        public int p { get; set; }
        [Display(Name = "Kilometraje: ")]
        public int Kilometraje { get; set; }
        public IPagedList<Models.Mantenimiento> LstMantenimiento { get; set; }

        public void Fill(CargarDatosContext c, int? numeroPagina)
        {
            this.p = numeroPagina ?? 1; 

            //var query = c.context.Mantenimiento.Include(x => x.Usuario).Include(x => x.Vehiculo).Where(x => x.Vehiculo.Estado == ConstantHelpers.ESTADO.ACTIVO && 
            //                                                                                                x.Usuario.Estado == ConstantHelpers.ESTADO.ACTIVO &&
            //                                                                                                x.Estado == ConstantHelpers.ESTADO.ACTIVO);

            //this.LstMantenimiento = query.OrderBy(x => x.FechaMantenimiento).ToPagedList(p, 10);
                        
        }

    }
}