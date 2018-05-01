using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transporto.Controllers;
using Transporto.Helpers;
using Transporto.Models;

namespace Transporto.ViewModels.RoldeUsuario
{
    public class AddEditRolViewModel
    {



        public Int32? IDRolDusuario { get; set; }

        [Display(Name = "Rol: ")]
        [Required]
        public String Rol { get; set; }




        public Int32 usuarioID { get; set; }

        public Int32 ROLID { get; set; }
        //Par el combobox
        public List<Usuario> ListUsuario { get; set; } = new List<Usuario>();

        public List<Models.Rol> List1RoL { get; set; } = new List<Models.Rol>();
        public void Fill(CargarDatosContext c, int? idRolDusuario)
        {
            this.ListUsuario = c.context.Usuario.Where(x => x.Estado == ConstantHelpers.ESTADO.ACTIVO).ToList();
            this.List1RoL = c.context.Rol.Where(x => x.Estado == ConstantHelpers.ESTADO.ACTIVO).ToList();

            if (idRolDusuario.HasValue)
            {
                var RoldUsuario = c.context.RolesDeUsuario.Find(idRolDusuario);


                this.usuarioID = RoldUsuario.IDUsuario;
                this.ROLID = RoldUsuario.IDRol;
                
          

            }
        }




    }
}