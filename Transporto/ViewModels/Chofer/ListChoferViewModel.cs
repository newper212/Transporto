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
namespace Transporto.ViewModels.Chofer
{
    public class ListChoferViewModel
    {


        public int p { get; set; }
        [Display(Name = "Nombre Chofer: ")]
        public String NombreChofer { get; set; }





        public IPagedList<Models.Chofer> LstChofer { get; set; }

        public void Fill(CargarDatosContext c, int? numeroPagina)
        {
            this.p = numeroPagina ?? 1;

            var query = c.context.Chofer.OrderBy(x => x.NombreChofer).Where(x => x.Estado == "ACT");
            this.LstChofer = query.OrderBy(x => x.Estado).ToPagedList(p, 10);
        }





    }
}