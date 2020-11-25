using System;
using System.Collections.Generic;

namespace registration.models
{
    public partial class Transporte
    {
        public int IdTransporte { get; set; }
        public string UsuarioTrans { get; set; }
        public int? IdProducto { get; set; }
        public int? IdVentas { get; set; }
        public string Status { get; set; }
    }
}
