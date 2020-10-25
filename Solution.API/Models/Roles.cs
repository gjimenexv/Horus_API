using System;
using System.Collections.Generic;

namespace Solution.API.Models
{
    public class Roles
    {
        public Roles()
        {
            AccesosXrol = new HashSet<AccesosXrol>();
            RolXfuncionario = new HashSet<RolXfuncionario>();
        }

        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? UltimaVez { get; set; }

        public virtual ICollection<AccesosXrol> AccesosXrol { get; set; }
        public virtual ICollection<RolXfuncionario> RolXfuncionario { get; set; }
    }
}
