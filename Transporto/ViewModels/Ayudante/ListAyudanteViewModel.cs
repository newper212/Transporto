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

namespace Transporto.ViewModels.Ayudante
{
    public class ListAyudanteViewModel
    {


        public int p { get; set; }
        [Display(Name = "Nombre Ayudante: ")]
        public String NombreAyudante { get; set; }


        public IPagedList<Models.Ayudante> LstAyudante { get; set; }

        public void Fill(CargarDatosContext c, int? numeroPagina)
        {
            this.p = numeroPagina ?? 1;

            var query = c.context.Ayudante.OrderBy(x => x.NombreAyudante).Where(x => x.Estado == "ACT");
            this.LstAyudante = query.OrderBy(x => x.Estado).ToPagedList(p, 10);
        }









    }
}