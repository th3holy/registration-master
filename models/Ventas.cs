using System;
using System.Collections.Generic;

namespace registration.models
{
    public partial class Ventas
    {
        public int IdVentas { get; set; }
        public string NombreComprador { get; set; }
        public string Direccion { get; set; }
        public string Transferencia { get; set; }
        public int? IdProducto { get; set; }
    }
}
