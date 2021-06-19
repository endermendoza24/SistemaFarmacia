using System;
using System.Collections.Generic;

namespace SistemaDeFarmacia.Models
{
    public partial class DetalleVenta
    {
        public int CodDetalleVenta { get; set; }
        public string Cliente { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public int CodVentas { get; set; }

        public Ventas CodVentasNavigation { get; set; }
    }
}
