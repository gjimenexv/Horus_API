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
    }
}