using System;
using System.Collections.Generic;

namespace SistemaDeFarmacia.Models
{
    public partial class Compras
    {
        public Compras()
        {
            DetalleCompras = new HashSet<DetalleCompras>();
            Inventario = new HashSet<Inventario>();
        }

        public int CodCompras { get; set; }
        public DateTime FechaCompra { get; set; }
        public double Iva { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public int IdLaboratorio { get; set; }
        public int IdPersonal { get; set; }

        public Laboratorio IdLaboratorioNavigation { get; set; }
        public Personal IdPersonalNavigation { get; set; }
        public ICollection<DetalleCompras> DetalleCompras { get; set; }
        public ICollection<Inventario> Inventario { get; set; }
    }
}
