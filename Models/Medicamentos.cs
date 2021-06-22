using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeFarmacia.Models
{
    public partial class Medicamentos
    {
        public int CodMedicamentos { get; set; }
        [Key]
        [Column("CodMedicamentos")]
        public string NombreGenerico { get; set; }
        [Required(ErrorMessage = "Nombre genérico es requerido")]
        [StringLength(100)]
        [Column("NombreGenerico")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Estado es requerido")]
        [StringLength(100)]
        [Column("Estado")]
        public string ViaAdministracion { get; set; }
        [Required(ErrorMessage = "Via de administracion es requerido")]
        [StringLength(100)]
        [Column("ViaAdministracion")]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Se reuqiere el código de categoria")]
        [RegularExpression(@"[0-9]")]
        [Column("IdCategoria")]
        public int IdInventario { get; set; }
        [Required(ErrorMessage = "Se reuqiere el código de inventario")]
        [RegularExpression(@"[0-9]")]
        [Column("IdInventario")]
        public CategoriaMedicamento IdCategoriaNavigation { get; set; }
        
        public Inventario IdInventarioNavigation { get; set; }
    }
}
