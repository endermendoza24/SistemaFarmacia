using System;
using System.Collections.Generic;

namespace SistemaDeFarmacia.Models
{
    public partial class Ventas
    {
        public Ventas()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int CodVentas { get; set; }
        public DateTime FechaVentas { get; set; }
        public double Subtotal { get; set; }
        public double Iva { get; set; }
        public double Total { get; set; }
        public int IdPersonal { get; set; }
        public int IdInventario { get; set; }

        public Inventario IdInventarioNavigation { get; set; }
        public Personal IdPersonalNavigation { get; set; }
        public ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
