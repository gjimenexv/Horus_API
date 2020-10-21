using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{

    public class clsEstadoBien
    {
        HorusDataContext dc = new HorusDataContext();


        public List<ConsultarEstadoBienResult> ConsultarEstadoBien()
        {
            try
            {
                List<ConsultarEstadoBienResult> data = dc.ConsultarEstadoBien().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaEstadoBienResult> ConsultaEstadoBien(int IdEstadoBien)
        {
            try
            {
                List<ConsultaEstadoBienResult> data = dc.ConsultaEstadoBien(IdEstadoBien).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearEstadoBien(string descripcion, bool estado)
        {
            try
            {
                dc.CrearEstadoBien (descripcion, estado);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarEstadoBien(int IdEstadoBien)
        {
            try
            {
                dc.EliminarEstadoBien(IdEstadoBien);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarEstadoBien(int IdEstadoBien, string descripcion, bool estado)
        {
            try
            {
                dc.ActualizarEstadoBien(IdEstadoBien, descripcion, estado);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }

}
