using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{
    public class clsCentrodeCostos
    {

        HorusDataContext dc = new HorusDataContext();

        public List<ConsultarCentroCostoResult> ConsultarCentroCosto()
        {
            try
            {
                List<ConsultarCentroCostoResult> data = dc.ConsultarCentroCosto().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaCentroCostoResult> ConsultaCentroCosto(int IdCentroCosto)
        {
            try
            {
                List<ConsultaCentroCostoResult> data = dc.ConsultaCentroCosto(IdCentroCosto).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearCentroCosto(string descripcion,string estado, string modificadoPor)
        {
            try
            {
                dc.CrearCentroCosto(descripcion,Boolean.Parse(estado), modificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarCentroCosto(int IdCentroCosto)
        {
            try
            {
                dc.EliminarCentroCosto(IdCentroCosto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarCentroCosto(int IdCentroCosto, string descripcion, bool estado, string modificadoPor)
        {
            try
            {
                dc.ActualizarCentroCosto(IdCentroCosto, descripcion, estado, modificadoPor);
                return true;
            }
            catch (Exception ex)
            {

               return false;
           }
        }

    }

}




