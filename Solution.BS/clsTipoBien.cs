using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{
    public class clsTipoBien
    {
        HorusDataContext dc = new HorusDataContext();

        public List<ConsultarTipoBienResult> ConsultarTipoBien()
        {
            try
            {
                List<ConsultarTipoBienResult> data = dc.ConsultarTipoBien().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaTipoBienResult> ConsultaTipoBien(int IdTipoBien)
        {
            try
            {
                List<ConsultaTipoBienResult> data = dc.ConsultaTipoBien(IdTipoBien).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearTipoBien(string descripcion, Boolean estado, string modificadoPor)
        {
            try
            {
                dc.CrearTipoBien(descripcion, estado, modificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarTipoBien(int IdTipoBien)
        {
            try
            {
                dc.EliminarTipoBien(IdTipoBien);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool ActualizarTipoBien(int IdTipoBien, string descripcion, Boolean estado, string modificadoPor)
        {
            try
            {
                dc.ActualizarTipoBien(IdTipoBien, descripcion, estado, modificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }



    }
}
