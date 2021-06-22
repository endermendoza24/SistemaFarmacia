using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeFarmacia.Models
{
    public partial class PresentacionMedicamento
    {
        public PresentacionMedicamento()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int IdPresentacionMed { get; set; }
        [Key]
        [Column("IdPresentacionMed")]
        public string UnidadEnvasado { get; set; }
        [Required(ErrorMessage = "Se requiere ingrese la unidad de envasado")]
        [StringLength(100)]
        [Column("UnidadEnvasado")]
        public string FormaPresentacion { get; set; }
        [Required(ErrorMessage = "Se requiere ingrese la forma de presentacion del medicamento")]
        [StringLength(100)]
        [Column("FormaPresentacion")]
        public string ConcentracionMgMl { get; set; }
        [Required(ErrorMessage = "Ingrese la concentración correcta de mg/ml")]
        [StringLength(100)]
        [Column("ConcentracionMgMl")]
        public string UnidadMedidaPresentacion { get; set; }
        [Required(ErrorMessage = "Ingrese la unidad de medida de la presentación")]
        [StringLength(100)]
        [Column("UnidadMedidaPresentacion")]
        public string Unidades { get; set; }
        [Required(ErrorMessage = "Ingresa las unidades")]
        [StringLength(100)]
        [Column("Unidades")]
        public string SubUnidades { get; set; }
        [Required(ErrorMessage = "Ingresa las unidades de medicamento")]
        [StringLength(100)]
        [Column("SubUnidades")]
        public ICollection<Inventario> Inventario { get; set; }
    }
}
