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


namespace Transporto.ViewModels.usuario
{
    public class ListUsuarioViewModel
    {
        public int p { get; set; }


        [Display(Name = "Usuario: ")]
        public String NombreComleto { get; set; }


        public IPagedList<Models.Usuario> LstUsuario { get; set; }

        public void Fill(CargarDatosContext c, int? numeroPagina)
        {
            this.p = numeroPagina ?? 1;

            var query = c.context.Usuario.OrderBy(x => x.Apellido).Where(x => x.Estado == "ACT");
            this.LstUsuario = query.OrderBy(x => x.Estado).ToPagedList(p, 10);
        }




    }
}