using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{
    public class clsOficina
    {
        HorusDataContext dc = new HorusDataContext();

        public List<ConsultarOficinaResult> ConsultarOficina()
        {

            try
            {
                List<ConsultarOficinaResult> data = dc.ConsultarOficina().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaOficinaResult> ConsultaOficina(int IdOficina)
        {
            try
            {
                List<ConsultaOficinaResult> data = dc.ConsultaOficina(IdOficina).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearOficina(string descripcion, Boolean estado)
        {
            try
            {
                dc.CrearOficina(descripcion, estado);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarOficina(int IdOficina)
        {
            try
            {
                dc.EliminarOficina(IdOficina);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool ActualizarOficina(int IdOficina, string descripcion, Boolean estado)
        {
            try
            {
                dc.ActualizarOficina(IdOficina, descripcion, estado);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}
