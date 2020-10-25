using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{
    public class clsAcceso
    {

        HorusDataContext dc = new HorusDataContext();

        public List<ConsultarAccesoResult> ConsultarAcceso()
        {
            try
            {
                List<ConsultarAccesoResult> data = dc.ConsultarAcceso().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaAccesoResult> ConsultaAcceso(int IdAcceso)
        {
            try
            {
                List<ConsultaAccesoResult> data = dc.ConsultaAcceso(IdAcceso).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearAcceso(string descripcion, string url,string modificadoPor)
        {
            try
            {
                dc.CrearAcceso(descripcion, url, modificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarAcceso(int IdAcceso)
        {
            try
            {
                dc.EliminarAcceso(IdAcceso);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarAcceso(int idAcceso, string descripcion, string url, string modificadoPor)
        {
            try
            {
                dc.ActualizarAcceso(idAcceso, descripcion, url, modificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }

}