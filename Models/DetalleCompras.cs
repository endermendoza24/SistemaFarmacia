using System;
using System.Collections.Generic;

namespace SistemaDeFarmacia.Models
{
    public partial class DetalleCompras
    {
        public int IdDetalleCompra { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
        public double Descuento { get; set; }
        public int CodCompras { get; set; }

        public Compras CodComprasNavigation { get; set; }
    }
}
