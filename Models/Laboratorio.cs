using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeFarmacia.Models
{
    public partial class Laboratorio
    {
        public Laboratorio()
        {
            Compras = new HashSet<Compras>();
            Inventario = new HashSet<Inventario>();
        }

        public int IdLaboratorio { get; set; }
        [Key]
        [Column("IdLaboratorio")]
        public string NombreLaboratorio { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre del labortaorio")]
        [StringLength(100)]
        [Column("NombreLaboratorio")]
        public string TelefonoLaboratorio { get; set; }
        [Required(ErrorMessage = "Ingrese un teléfono válido")] 
        [RegularExpression(@)]
        public string Direccion { get; set; }
        public string EmailLab { get; set; }
        public string PoliticasDeVencimiento { get; set; }

        public ICollection<Compras> Compras { get; set; }
        public ICollection<Inventario> Inventario { get; set; }
    }
}
