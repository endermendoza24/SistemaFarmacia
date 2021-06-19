using System;
using System.Collections.Generic;

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
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public ICollection<Compras> Compras { get; set; }
        public ICollection<Ventas> Ventas { get; set; }
    }
}
