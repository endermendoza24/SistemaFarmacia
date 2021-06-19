using System;
using System.Collections.Generic;

namespace SistemaDeFarmacia.Models
{
    public partial class Inventario
    {
        public Inventario()
        {
            Medicamentos = new HashSet<Medicamentos>();
            Ventas = new HashSet<Ventas>();
        }

        public int IdInventario { get; set; }
        public DateTime FechaEntradaInventario { get; set; }
        public string NombreComercial { get; set; }
        public int StockInicial { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
        public int StockActual { get; set; }
        public double PrecioPreventa { get; set; }
        public double CostoPreventa { get; set; }
        public int IdPresentacionMed { get; set; }
        public int IdLaboratorio { get; set; }
        public int IdCompra { get; set; }

        public Compras IdCompraNavigation { get; set; }
        public Laboratorio IdLaboratorioNavigation { get; set; }
        public PresentacionMedicamento IdPresentacionMedNavigation { get; set; }
        public ICollection<Medicamentos> Medicamentos { get; set; }
        public ICollection<Ventas> Ventas { get; set; }
    }
}
