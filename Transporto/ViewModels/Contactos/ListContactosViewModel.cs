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

namespace Transporto.ViewModels.Contactos
{
    public class ListContactosViewModel
    {

        public int p { get; set; }
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }
        public IPagedList<Models.Contactos> LstContacto { get; set; }

        public void Fill(CargarDatosContext c, int? numeroPagina)
        {
            this.p = numeroPagina ?? 1;

            var query = c.context.Contactos.Include(x => x.EmpresaCliente).Where(x =>  x.EmpresaCliente.Estado == ConstantHelpers.ESTADO.ACTIVO && x.Estado == ConstantHelpers.ESTADO.ACTIVO);



            this.LstContacto = query.OrderBy(x => x.Nombre).ToPagedList(p, 10);

        }


    }
}