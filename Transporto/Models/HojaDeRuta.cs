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
    
    public partial class HojaDeRuta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HojaDeRuta()
        {
            this.Observacion = new HashSet<Observacion>();
        }
    
        public int IDHojaDruta { get; set; }
        public int IDVehiculo { get; set; }
        public string Documento { get; set; }
        public string NumeroDocumento { get; set; }
        public int IDChofer { get; set; }
        public int IDAyudante { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public int IDClienteEmpresa { get; set; }
        public string Direccion { get; set; }
        public int IDDistrito { get; set; }
        public Nullable<decimal> Peso { get; set; }
        public Nullable<decimal> Volumen { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Hora { get; set; }
        public string Estado { get; set; }
    
        public virtual Ayudante Ayudante { get; set; }
        public virtual Chofer Chofer { get; set; }
        public virtual Distrito Distrito { get; set; }
        public virtual EmpresaCliente EmpresaCliente { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Observacion> Observacion { get; set; }
    }
}
