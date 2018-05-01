using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transporto.Models.Entities
{
    public class VehiculoAlerta
    {
        public int VehiculoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string Placa { get; set; }
        public string Estado { get; set; }
        public string Alerta { get; set; }
        public string AlertaSOAT { get; set; }
    }
}