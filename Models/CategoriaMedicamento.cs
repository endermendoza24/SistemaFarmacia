using System;
using System.Collections.Generic;

namespace SistemaDeFarmacia.Models
{
    public partial class CategoriaMedicamento
    {
        public CategoriaMedicamento()
        {
            Medicamentos = new HashSet<Medicamentos>();
        }

        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string DescripcionCategoria { get; set; }

        public ICollection<Medicamentos> Medicamentos { get; set; }
    }
}
