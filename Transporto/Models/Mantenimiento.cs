//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Transporto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mantenimiento
    {
        public int IDMantenimiento { get; set; }
        public int Kilometraje { get; set; }
        public System.DateTime FechaMantenimiento { get; set; }
        public string Taller { get; set; }
        public Nullable<System.DateTime> FechaDMantenimientoObcional { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
        public int IDUsuario { get; set; }
        public int IDVehiculo { get; set; }
        public string Estado { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
