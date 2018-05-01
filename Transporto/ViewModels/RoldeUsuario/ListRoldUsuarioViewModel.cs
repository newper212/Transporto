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
namespace Transporto.ViewModels.RoldeUsuario
{
    public class ListRoldUsuarioViewModel
    {

        public int p { get; set; }
        [Display(Name = "Rol: ")]
        public int Rol { get; set; }
        public IPagedList<Models.RolesDeUsuario> LstRolDusuario { get; set; }

        public void Fill(CargarDatosContext c, int? numeroPagina)
        {
            this.p = numeroPagina ?? 1;

            var query = c.context.RolesDeUsuario.Include(x => x.Usuario).Include(x => x.Rol).Where(x => x.Rol.Estado == ConstantHelpers.ESTADO.ACTIVO &&
                                                                                                            x.Usuario.Estado == ConstantHelpers.ESTADO.ACTIVO &&
                                                                                                            x.Estado == ConstantHelpers.ESTADO.ACTIVO);

            this.LstRolDusuario = query.OrderBy(x => x.IDRol).ToPagedList(p, 10);

        }






    }
}