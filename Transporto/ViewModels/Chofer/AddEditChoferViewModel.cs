using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transporto.Controllers;
using Transporto.Models;

namespace Transporto.ViewModels.Chofer
{
    public class AddEditChoferViewModel
    {

        public Int32? Choferid { get; set; }

        [Display(Name = "Nombres: ")]
        [Required]
        public String NombreChofer { get; set; }

        [Display(Name = "Apellido: ")]
        [Required]
        public String ApellidoChofer { get; set; }


        [Display(Name = "DNI: ")]
        [Required]
        public String DNICHOFER { get; set; }



        [Display(Name = "Funcion CHOFER: ")]
        [Required]
        public String FuncionChofer { get; set; }


        [Display(Name = "Numero de Brevete: ")]
        [Required]
        public String NumeroBrevete { get; set; }


        [Display(Name = "Fecha de Activacion Brevete: ")]
        //[Required]
        public DateTime FechaActivacionBrevete { get; set; }


        [Display(Name = "Fecha de Vencimiento Brevete: ")]
        //[Required]
        public DateTime FechaVencimientoBrevete { get; set; }



        [Display(Name = "Celular Personal :")]
        [Required]
        public String CelularPersonal { get; set; }



        [Display(Name = "Celular Corporativo: ")]
        [Required]
        public String CelularCorporativo { get; set; }



        [Display(Name = "Email : ")]
        [Required]
        public String Email { get; set; }

        public void Fill(CargarDatosContext c, int? choferId)
        {

            this.Choferid = choferId;
            if (this.Choferid.HasValue)
            {
                //this.Choferid = choferId;
                var chofer = c.context.Chofer.Find(this.Choferid);
                this.NombreChofer = chofer.NombreChofer;
                this.ApellidoChofer = chofer.ApellidosChofer;
                this.DNICHOFER = chofer.DNIChofer;
                this.FuncionChofer = chofer.FuncionChofer;
                this.NumeroBrevete = chofer.NumeroBreveteChofer;
                this.FechaActivacionBrevete = chofer.FechaDActivacionBrevete;
                this.FechaVencimientoBrevete = chofer.FecchaVencimientoBrevete;
                this.CelularPersonal = chofer.CelularPersonalChofer;
                this.CelularCorporativo = chofer.CelularCorporativoChofer;
                this.Email = chofer.EmailChofer;
            }
        }









    }
}