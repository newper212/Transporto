using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Transporto.Models.Entities
{
    public class RevisionTecnica
    {
        public int Placa { get; set; }
        //public int VehiculoID { get; set; }
        //public DateTime FechaInicio { get; set; }
        //public DateTime fechaCaducidad { get; set; }
        public String Estado { get; set; }
    }
}