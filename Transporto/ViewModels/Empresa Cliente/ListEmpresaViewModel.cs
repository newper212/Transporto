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

namespace Transporto.ViewModels.EmpresaCliente
{
    public class ListEmpresaViewModel
    {
        public int p { get; set; }

        [Display(Name = "Ruc")]
        public string Ruc{ get; set; }




        public IPagedList<Models.EmpresaCliente> LstEmpresa { get; set; }

        public void Fill(CargarDatosContext c, int? numeroPagina)
        {
            this.p = numeroPagina ?? 1;

            var query = c.context.EmpresaCliente.Include(x => x.Distrito).OrderBy(x => x.Ruc).Where(x => x.Estado == "ACT");
            this.LstEmpresa = query.OrderBy(x => x.Estado).ToPagedList(p, 10);
        }





    }
}