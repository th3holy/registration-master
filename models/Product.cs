using System;
using System.Collections.Generic;

namespace registration.models
{
    public partial class Product
    {
        public int CodProducto { get; set; }
        public string TipoFruta { get; set; }
        public string Calidad { get; set; }
        public string Status { get; set; }
        public int? Cantidad { get; set; }
        public string IdUser { get; set; }
        public decimal? Valor { get; set; }
    }
}
