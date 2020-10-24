using System;
using System.Collections.Generic;

namespace registration.models
{
    public partial class Contrato
    {
        public int IdContratos { get; set; }
        public string IdUser { get; set; }
        public string Run { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaInicioContrato { get; set; }
        public DateTime? FechaVencimientoContrato { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
