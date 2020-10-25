using System;
using System.Collections.Generic;

namespace Solution.API.Models
{
    public class EstadoBien
    {
        public EstadoBien()
        {
            Bien = new HashSet<Bien>();
            HistorialEstado = new HashSet<HistorialEstado>();
        }

        public int IdEstadoBien { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? UltimaVez { get; set; }

        public virtual ICollection<Bien> Bien { get; set; }
        public virtual ICollection<HistorialEstado> HistorialEstado { get; set; }
    }
}
