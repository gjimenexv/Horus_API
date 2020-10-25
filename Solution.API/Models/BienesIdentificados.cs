using System;
using System.Collections.Generic;

namespace Solution.API.Models
{
    public class BienesIdentificados
    {
        public int IdBienIdentificado { get; set; }
        public int? IdTomaInventario { get; set; }
        public DateTime? Fecha { get; set; }
        public string Placa { get; set; }
        public bool? Estado { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? UltimaVez { get; set; }

        public virtual Bien PlacaNavigation { get; set; }
        public virtual TomaInventario TomaInventario { get; set; }
    }
}
