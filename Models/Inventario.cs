using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        [Key]
        [Column("IdInventario")]

        public DateTime FechaEntradaInventario { get; set; }
        [Required(ErrorMessage = "Debe incluir la fecha en el formato adecuado")]
        //[RegularExpression(@"([0][1-9]|[1][0-9|][2][0-9]|[3][0-1])\/([0][1-9]|[1][0-2])\/[1-2][0-9][0-9][0-9]")]
        public string NombreComercial { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre comercial del medicamento")]
        [Column("NombreComercial")]
        [StringLength(100)]
        public int StockInicial { get; set; }
        [Required(ErrorMessage = "Ingrese el formato correcto de número entero")]
        [RegularExpression(@"^\d+$")]
        [Column("StockInicial")]
        public int Entradas { get; set; }
        [Required(ErrorMessage = "Ingrese el formato correcto de número entero")]
        [RegularExpression(@"^\d+$")]
        [Column("Entradas")]
        public int Salidas { get; set; }
        [Required(ErrorMessage = "Ingrese el formato correcto de número entero")]
        [RegularExpression(@"^\d+$")]
        [Column("Salidas")]
        public int StockActual { get; set; }
        [Required(ErrorMessage = "Ingrese el formato correcto de número entero")]
        [RegularExpression(@"^\d+$")]
        [Column("StockActual")]

        public double PrecioPreventa { get; set; }
        [Required(ErrorMessage = "Ingrese un formato de moneda válido")]
        [RegularExpression(@"^-?(([1-9]\d*)|0)(.0*[1-9](0*[1-9])*)?$")]
        [Column("PrecioPreventa")]
        public double CostoPreventa { get; set; }
        [Required(ErrorMessage = "Ingrese un formato de moneda válido")]
        [RegularExpression(@"^-?(([1-9]\d*)|0)(.0*[1-9](0*[1-9])*)?$")]
        [Column("CostoPreventa")]
        public int IdPresentacionMed { get; set; }
        
        [Required(ErrorMessage = "Debe Ingresar este elemento")]
        [RegularExpression(@"^\d+$")]
        [Column("IdPresentacion")]
        public int IdLaboratorio { get; set; }

        [Required(ErrorMessage = "Debe Ingresar este elemento")]
        [RegularExpression(@"^\d+$")]
        [Column("IdLaboratorio")]
        public int IdCompra { get; set; }

        [Required(ErrorMessage = "Debe Ingresar este elemento")]
        [RegularExpression(@"^\d+$")]
        [Column("IdCompra")]
        public Compras IdCompraNavigation { get; set; }
        public Laboratorio IdLaboratorioNavigation { get; set; }
        public PresentacionMedicamento IdPresentacionMedNavigation { get; set; }
        public ICollection<Medicamentos> Medicamentos { get; set; }
        public ICollection<Ventas> Ventas { get; set; }
    }
}
