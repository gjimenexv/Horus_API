using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{
    public class clsTomaInventario
    {
        HorusDataContext dc = new HorusDataContext();

        public List<ConsultarTomaInventarioResult> ConsultarTomaInventario()
        {
            try
            {
                List<ConsultarTomaInventarioResult> data = dc.ConsultarTomaInventario().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaTomaInventarioResult> ConsultaTomaInventario(string IdTomaInventario)
        {
            try
            {
                List<ConsultaTomaInventarioResult> data = dc.ConsultaTomaInventario(Int32.Parse(IdTomaInventario)).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearTomaInventario(string IdFuncionario, int IdCentroCosto, string titulo, string descripcion, DateTime FechaInicio, DateTime FechaFin, bool estado, string ModificadoPor)
        {
            try
            {
                dc.CrearTomaInventario(IdFuncionario, IdCentroCosto, titulo, descripcion, FechaInicio, FechaFin, estado, ModificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarTomaInventario(string IdTomaInventario)
        {
            try
            {
                dc.EliminarTomaInventario(Int32.Parse(IdTomaInventario));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool ActualizarTomaInventario(int IdTomaInventario, string IdFuncionario, int IdCentroCosto, string titulo, string descripcion, DateTime FechaInicio, DateTime FechaFin, bool estado, string ModificadoPor)
        {
            try
            {
                dc.ActualizarTomaInventario(IdTomaInventario, IdFuncionario, IdCentroCosto, titulo, descripcion, FechaInicio, FechaFin, estado, ModificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
