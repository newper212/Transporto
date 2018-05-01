using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Transporto.Controllers;
using Transporto.Models;

namespace Transporto.ViewModels.vehiculo
{
    public class AddEditVehiculoViewModel
    {

        public Int32? VehiculoId { get; set; }


        [Display(Name = "Marca: ")]
        [Required(ErrorMessage = "La Marca es requerida")]
        public String Marca { get; set; }

        [Display(Name = "Modelo: ")]
        [Required]
        public String Modelo { get; set; }

        [Display(Name = "Tipo: ")]
        [Required]
        public String Tipo { get; set; }

        [Display(Name = "Placa: ")]
        [Required]
        public String Placa { get; set; }

        [Display(Name = "Fec Inicio SOAT: ")]
        //[Required]
        public DateTime FechaInicioSOAT { get; set; }


        [Display(Name = "Fec Venc. SOAT: ")]
        //[Required]
        public DateTime FechaVencimientoSOAT { get; set; }




        [Display(Name = "Max Peso de Soporte del Vehiculo: ")]
        [Required]
        public decimal Peso { get; set; }


        [Display(Name = "Volumen: ")]
        [Required]
        public decimal Volumen { get; set; }


        [Display(Name = "FechaInicioRevicionTec: ")]
        //[Required]
        public DateTime FechaInicRevicTecn { get; set; }

        [Display(Name = "FechaCaducidadRevicionTec: ")]
        //[Required]
        public DateTime FechaCaducidadRevicionTec { get; set; }


        [Display(Name = "FechaInicioSeguro: ")]
        //[Required]
        public DateTime FechaInicioSeguro { get; set; }


        [Display(Name = "FechaCaduidadSeguro: ")]
        //[Required]
        public DateTime FechaCaduidadSeguro { get; set; }

        [Display(Name = "NumeroDeHabilitacion: ")]
        [Required]
        public String NumeroDeHabilitacion { get; set; }


        [Display(Name = "FechaIncioCertificado: ")]
        //[Required]
        public DateTime FechaIncioCertificado { get; set; }


        [Display(Name = "FechaCaducidadCertificado: ")]
        //[Required]
        public DateTime FechaCadicidadCertificado { get; set; }

        //[Display(Name = "Estado: ")]
        //[Required]
        //public String Estado { get; set; }

        //public Int32 DistritoId { get; set; } 
        //public List<Distrito> ListDistrito { get; set; } = new List<Distrito>();




        public void Fill(CargarDatosContext c, int? vehiculoId)
        {
            this.VehiculoId = vehiculoId;
            //this.ListDistrito = c.context.Distrito.ToList();

            if (this.VehiculoId.HasValue)
            {
                var vehiculo = c.context.Vehiculo.Find(this.VehiculoId);
                this.Marca =  vehiculo.Marca;
                this.Modelo = vehiculo.Modelo;
                this.Tipo = vehiculo.Tipo;
                this.Placa = vehiculo.Placa;
                this.FechaInicioSOAT = vehiculo.SoatFechaInic;
                this.FechaVencimientoSOAT = vehiculo.SoatFechVenc;
                this.Peso = vehiculo.Peso.Value;
                this.Volumen = vehiculo.Volumen.Value;
                this.FechaInicRevicTecn = vehiculo.FechaDeInicioRevisionTecn.Value;
                this.FechaCaducidadRevicionTec = vehiculo.FechaDeCaducidadReviciTecni.Value;
                this.FechaInicioSeguro = vehiculo.FechaIncioSeguroVehicular.Value;
                this.FechaCaduidadSeguro = vehiculo.FechaCaducidadSeguVehicu.Value;
                this.NumeroDeHabilitacion = vehiculo.NumeroHabilitacion;
                this.FechaIncioCertificado = vehiculo.FechaInicioCertificadoFumiga.Value;
                this.FechaCadicidadCertificado = vehiculo.FechaCaducidadCertificadoFumiga.Value;
                //this.Estado = vehiculo.Estado;

            }
        }




    }
}