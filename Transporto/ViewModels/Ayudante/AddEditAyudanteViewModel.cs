using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transporto.Controllers;

namespace Transporto.ViewModels.Ayudante
{
    public class AddEditAyudanteViewModel
    {


        public Int32? IDAyudante { get; set; }

        [Display(Name = "Nombres: ")]
        [Required]
        public String NombreAyudante { get; set; }

        [Display(Name = "Apellidos: ")]
        [Required]
        public String ApellidoAyudante { get; set; }

        [Display(Name = "DNI: ")]
        [Required]
        public String DNIAyudante { get; set; }

        [Display(Name = "Dirección: ")]
        [Required]
        public String DireccionAyudante { get; set; }

        [Display(Name = "Telefono: ")]
        [Required]
        public String TelefonoAyudante { get; set; }

        [Display(Name = "Celular: ")]
        [Required]
        public String CelularAyudante { get; set; }

        





        public void Fill(CargarDatosContext c, int? ayudanteID)
        {
            this.IDAyudante = ayudanteID;

            if (this.IDAyudante.HasValue)
            {
                var Ayudante = c.context.Ayudante.Find(this.IDAyudante.Value);


                this.NombreAyudante = Ayudante.NombreAyudante;
                this.ApellidoAyudante = Ayudante.ApellidoAyudante;
                this.DNIAyudante = Ayudante.DNIAyudante;
                this.DireccionAyudante = Ayudante.DireccionAyudante;
                this.TelefonoAyudante = Ayudante.TelefonoAyudante;
                this.CelularAyudante= Ayudante.CelularAyudante;
              
                

            }
        }




    }
}