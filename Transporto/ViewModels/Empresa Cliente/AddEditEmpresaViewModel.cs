using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transporto.Controllers;
using Transporto.Models;

namespace Transporto.ViewModels.EmpresaCliente
{
    public class AddEditEmpresaViewModel
    {

        public Int32? EmpresaId { get; set; }

        [Display(Name = "Ruc: ")]
        [Required]
        public String Ruc { get; set; }



        [Display(Name = "Nombre De La empresa: ")]
        [Required]
        public String NombreEmpresa { get; set; }


        [Display(Name = "Telefono Corporativo: ")]
        [Required]
        public String TelefonoCorporativo { get; set; }



        [Display(Name = "Direccion : ")]
        [Required]
        public String Direccion { get; set; }


        [Display(Name = "Email Corporativo central: ")]
        [Required]
        public String EmailCorporativo { get; set; }

        [Display(Name = "Observaciones: ")]
        [Required]
        public String Observaciones { get; set; }




        [Display(Name = "DNI Contacto: ")]
        [Required]
        public String DniContacto { get; set; }




        [Display(Name = "Nombre Contacto: ")]
        [Required]
        public String NombreContacto { get; set; }


        [Display(Name = "Apellido Contacto: ")]
        [Required]
        public String ApellidoContacto { get; set; }


        [Display(Name = "Celular contacto: ")]
        [Required]
        public String CelularContacto { get; set; }

        [Display(Name = "Email Contacto: ")]
        [Required]
        public String EmailContacto { get; set; }





        public Int32 DistritoId { get; set; }
        public List<Distrito> ListDistrito { get; set; } = new List<Distrito>();



        public void Fill(CargarDatosContext c, int? empresaId)
        {
            this.ListDistrito = c.context.Distrito.ToList();
            var empresa = c.context.EmpresaCliente.Find(empresaId);
            if (empresa != null)
            {
                this.EmpresaId = empresa.IDEmpresaCliente;
                this.Ruc = empresa.Ruc;
                this.NombreEmpresa = empresa.NombreEmpresa;
                this.TelefonoCorporativo = empresa.TelefonoCorporativo;
                this.Direccion = empresa.Direccion;
                this.DistritoId = empresa.IDDistrito;
                this.EmailCorporativo = empresa.EmailCorporativa;
                this.Observaciones = empresa.Observaciones;
                this.DniContacto = empresa.DNIContaco;
                this.NombreContacto = empresa.NombreContacto;
                this.ApellidoContacto = empresa.ApellidoContacto;
                this.CelularContacto = empresa.CelularContacto;
                this.EmailContacto =    empresa.EmailContaco;
               
             

            }
        }


    }
}