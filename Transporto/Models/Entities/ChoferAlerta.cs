using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transporto.Models.Entities
{
    public class ChoferAlerta
    {
        public int ChoferId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string NumeroBrevete { get; set; }
        public DateTime? FechaActivacionBrevete { get; set; }
        public DateTime? FechaVencimientoBrevete { get; set; }
        public string CelularPersonal { get; set; }
        public string CelularCorporativo { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string AlertaBrevete { get; set; }
    }
}