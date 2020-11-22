using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{
    public static class clsBitacora
    {
        //Se registran la bitacora por medio de este metodo. 
        public static bool RegistrarBitacora(int idUsuario, string controlador,string accion, string error, int tipo, DateTime fecha)
        {
            try
            {
                HorusDataContext dc = new HorusDataContext();
                dc.RegistrarBitacora(idUsuario, controlador, accion, error, tipo, fecha);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        //Capa de negocios en la que se llama el procedimiento almacenado de Consultar de Auditoria para las vistas.
        public static List<ConsultarBitacoraResult> ConsultarBitacora()
        {
            try
            {
                HorusDataContext dc = new HorusDataContext();
                List<ConsultarBitacoraResult> data = dc.ConsultarBitacora().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}