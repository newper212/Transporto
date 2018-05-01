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

namespace Transporto.ViewModels.Rol
{
    public class ListRolViewModel
    {



        public int p { get; set; }
        [Display(Name = "Rol :")]
        public string rol1{ get; set; }




        public IPagedList<Models.Rol> LstRol { get; set; }

        public void Fill(CargarDatosContext c, int? numeroPagina)
        {
            this.p = numeroPagina ?? 1;

            var query = c.context.Rol.OrderBy(x => x.Rol1).Where(x => x.Estado == "ACT");
            this.LstRol = query.OrderBy(x => x.Estado).ToPagedList(p, 10);
        }






    }
}