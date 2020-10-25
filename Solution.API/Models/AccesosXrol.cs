using System;
using System.Collections.Generic;

namespace Solution.API.Models
{
    public class AccesosXrol
    {
        public int IdAccesoXrol { get; set; }
        public int IdAcceso { get; set; }
        public int IdRol { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? UltimaVez { get; set; }

        public virtual Acceso IdAccesoNavigation { get; set; }
        public virtual Roles IdRolNavigation { get; set; }
    }
}
