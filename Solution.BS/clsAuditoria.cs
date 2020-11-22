using Solution.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BS
{
    public class clsAuditoria
    {
        HorusDataContext dc = new HorusDataContext();

        //Capa de negocios en la que se llama el procedimiento almacenado de Consultar de Auditoria para las vistas.
        public List<ConsultarAuditoriaResult> ConsultarAuditoria()
        {
            try
            {
                List<ConsultarAuditoriaResult> data = dc.ConsultarAuditoria().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
