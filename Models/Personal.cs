using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeFarmacia.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Compras = new HashSet<Compras>();
            Ventas = new HashSet<Ventas>();
        }

        public int IdPersonal { get; set; }
        [Key]
        [Column("IdPersonal")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Nombre de empleado es requerido")]
        [Column("Nombre")]
        [StringLength(100)]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "Primer apellido de empleado es requerido")]
        [Column("PrimerApellido")]
        [StringLength(100)]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "Segundo apellido de empleado es requerido")]
        [Column("SegundoApellido")]
        [StringLength(100)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Dirección de empleado es requerido")]
        [Column("Direccion")]
        [StringLength(100)]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Teléfono de empleado es requerido")]
        [Column("Telefono")]
        [StringLength(20)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Correo electrónico de empleado es requerido")]
        [Column("Email")]
        [StringLength(100)]
        public ICollection<Compras> Compras { get; set; }
        public ICollection<Ventas> Ventas { get; set; }
    }
}
