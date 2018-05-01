using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transporto.Controllers;
using Transporto.Models;

namespace Transporto.ViewModels.Rol
{
    public class AddEditRolUsuarioViewModel
    {

        public Int32? RolId { get; set; }


        [Display(Name = "Rol: ")]
        [Required(ErrorMessage = "El Rol es requerido")]
        public String Rol { get; set; }

        
        public void Fill(CargarDatosContext c, int? RolId)
        {
            this.RolId = RolId;
           

            if (this.RolId.HasValue)
            {
                var Rol = c.context.Rol.Find(this.RolId);
                this.Rol = Rol.Rol1;
          
                

            }
        }




    }
}