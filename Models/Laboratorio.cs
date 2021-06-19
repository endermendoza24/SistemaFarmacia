using System;
using System.Collections.Generic;

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
        public string NombreLaboratorio { get; set; }
        public string TelefonoLaboratorio { get; set; }
        public string Direccion { get; set; }
        public string EmailLab { get; set; }
        public string PoliticasDeVencimiento { get; set; }

        public ICollection<Compras> Compras { get; set; }
        public ICollection<Inventario> Inventario { get; set; }
    }
}
