using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transporto.Controllers;
using Transporto.Models;
using Transporto.Helpers;
namespace Transporto.ViewModels.Contactos
{
    public class AddContactosViewModel
    {

        public Int32? ContactoId { get; set; }

        [Display(Name = "DNI: ")]
        [Required]
        public String DNI { get; set; }

        [Display(Name = "Nombre: ")]
        [Required]
        public String Nombre { get; set; }

        [Display(Name = "Apellido: ")]
        [Required]
        public String Apellido { get; set; }



        [Display(Name = "Celular: ")]
        [Required]
        public String Celular { get; set; }


        [Display(Name = "Email: ")]
        [Required]
        public String Email { get; set; }




        public Int32 empresaID { get; set; }
     

        //Par el combobox
        public List<Models.EmpresaCliente> ListEmpresaCliente { get; set; } = new List<Models.EmpresaCliente>();
      

        public void Fill(CargarDatosContext c, int? idContacto)
        {
            this.ListEmpresaCliente = c.context.EmpresaCliente.Where(x => x.Estado == ConstantHelpers.ESTADO.ACTIVO).ToList();
         

            if (idContacto.HasValue)
            {
                var contacto = c.context.Contactos.Find(idContacto);

                this.DNI = contacto.Dni;
                this.Nombre = contacto.Nombre;
                this.Apellido = contacto.Apellido;
                this.Celular = contacto.Celular;
                this.Email = contacto.EmailContacto;
                this.empresaID = contacto.IDEmpresa;
            

            }
        }









    }
}