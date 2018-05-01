using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transporto.Controllers;

namespace Transporto.ViewModels.usuario
{
    public class AddEditUsuarioViewModel
    {


        public Int32? UsuarioId { get; set; }

        [Display(Name = "Usuario: ")]
        [Required]
        public String Usuario { get; set; }

        [Display(Name = " Nueva Comtraseña de 4 Digitos: ")]
        [Required]
        public String Comtrasena { get; set; }

        [Display(Name = "Nombre: ")]
        [Required]
        public String Nombre { get; set; }

        [Display(Name = "Apellido: ")]
        [Required]
        public String Apellido { get; set; }

        [Display(Name = "DNI: ")]
        [Required]
        public String DNI{ get; set; }

      

        public AddEditUsuarioViewModel()
        {
        }
        public void Fill(CargarDatosContext dataContext, Int32? usuarioId)
        {
            this.UsuarioId = usuarioId;


            if (this.UsuarioId.HasValue)
            {
                var usuario = dataContext.context.Usuario.Find(this.UsuarioId);

                this.Usuario = usuario.Codigo;
                this.Comtrasena = usuario.Comtrasena;
                this.Nombre= usuario.Nombre;
                this.Apellido = usuario.Apellido;
                this.DNI = usuario.Dni;
              

            }
        }



    }
}