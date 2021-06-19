using System;
using System.Collections.Generic;

namespace SistemaDeFarmacia.Models
{
    public partial class PresentacionMedicamento
    {
        public PresentacionMedicamento()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int IdPresentacionMed { get; set; }
        public string UnidadEnvasado { get; set; }
        public string FormaPresentacion { get; set; }
        public string ConcentracionMgMl { get; set; }
        public string UnidadMedidaPresentacion { get; set; }
        public string Unidades { get; set; }
        public string SubUnidades { get; set; }

        public ICollection<Inventario> Inventario { get; set; }
    }
}
