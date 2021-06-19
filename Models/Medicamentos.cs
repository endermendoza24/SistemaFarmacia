using System;
using System.Collections.Generic;

namespace SistemaDeFarmacia.Models
{
    public partial class Medicamentos
    {
        public int CodMedicamentos { get; set; }
        public string NombreGenerico { get; set; }
        public string Estado { get; set; }
        public string ViaAdministracion { get; set; }
        public int IdCategoria { get; set; }
        public int IdInventario { get; set; }

        public CategoriaMedicamento IdCategoriaNavigation { get; set; }
        public Inventario IdInventarioNavigation { get; set; }
    }
}
