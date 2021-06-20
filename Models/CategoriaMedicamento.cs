using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeFarmacia.Models
{
    public partial class CategoriaMedicamento
    {
        public CategoriaMedicamento()
        {
            Medicamentos = new HashSet<Medicamentos>();
        }

        [Key]
        [Column("id_Categoria")]


        public int IdCategoria { get; set; }
        
        public string NombreCategoria { get; set; }
        [Required(ErrorMessage = "Nombre de categoria es requerido")]
        [Column("nombre_Categoria")]
        [StringLength(100)]
        public string DescripcionCategoria { get; set; }
        [Column("Descripcion", TypeName = "text")]
        public ICollection<Medicamentos> Medicamentos { get; set; }
    }
}
