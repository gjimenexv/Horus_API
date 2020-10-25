using System;
using System.Collections.Generic;

namespace Solution.API.Models
{
    public class Acceso
    {
        public Acceso()
        {
            AccesosXrol = new HashSet<AccesosXrol>();
        }

        public int IdAcceso { get; set; }
        public string Descripcion { get; set; }
        public string Url { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? UltimaVez { get; set; }

        public virtual ICollection<AccesosXrol> AccesosXrol { get; set; }

    }
}
