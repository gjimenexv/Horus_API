using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.API.Models
{
    public class Auditoria
    {
        public int IdAuditoria { get; set; }
        public string Tabla { get; set; }
        public string Registro { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        public string IdUsuario { get; set; }
    }
}