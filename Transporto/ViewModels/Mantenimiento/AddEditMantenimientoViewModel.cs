using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transporto.Controllers;
using Transporto.Helpers;
using Transporto.Models;

namespace Transporto.ViewModels.Mantenimiento
{
    public class AddEditMantenimientoViewModel
    {


        public Int32? IDMantenimiento { get; set; }

        [Display(Name = "Kilometraje: ")]
        [Required]
        public int Kilometraje { get; set; }

        [Display(Name = "Fecha Mantenmiento: ")]
        //[Required]
        public DateTime FechaMantenimiento { get; set; }

        [Display(Name = "Taller: ")]
        [Required]
        public string Taller { get; set; }

        [Display(Name = "Fecha Mantenimiento Opcional: ")]
        //[Required]
        public DateTime FechaDMantenimientoObcional { get; set; }

        [Display(Name = "Monto: ")]
        [Required]
        //[Range(0.00, 99999999.99)]
        public decimal Monto { get; set; }

        [Display(Name = "Motivo: ")]
        [Required]
        public String Motivo { get; set; }

        //[Display(Name = "Id Usuario: ")]
        //[Required]
        //public int IDUsuario { get; set; }

        //[Display(Name = "Id Vehiculo: ")]
        //[Required]
        //public int IDVehiculo { get; set; }



        public Int32 usuarioID { get; set; }
        public Int32 vehiculoID { get; set; }

        //Par el combobox
        public List<Usuario> ListUsuario { get; set; } = new List<Usuario>();
        public List<Vehiculo> Listvehiculo { get; set; } = new List<Vehiculo>();

        public void Fill(CargarDatosContext c, int? idMantenimiento)
        {
            this.ListUsuario = c.context.Usuario.Where(x => x.Estado == ConstantHelpers.ESTADO.ACTIVO).ToList();
            this.Listvehiculo = c.context.Vehiculo.Where(x => x.Estado == ConstantHelpers.ESTADO.ACTIVO).ToList();

            if (idMantenimiento.HasValue)
            {
                var mantenimiento = c.context.Mantenimiento.Find(idMantenimiento);

                this.IDMantenimiento = mantenimiento.IDMantenimiento;
                this.Kilometraje = mantenimiento.Kilometraje;
                this.FechaMantenimiento = mantenimiento.FechaMantenimiento;
                this.Taller = mantenimiento.Taller;
                this.FechaDMantenimientoObcional = mantenimiento.FechaDMantenimientoObcional.Value;
                this.Monto = mantenimiento.Monto;
                this.Motivo = mantenimiento.Motivo;
                this.usuarioID = mantenimiento.IDUsuario;
                this.vehiculoID = mantenimiento.IDVehiculo;
            
            }
        }






    }
}