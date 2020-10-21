using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{
    public class clsHistorialEstado
    {

        HorusDataContext dc = new HorusDataContext();

        //public List<ConsultarHistorialEstadoResult> ConsultarHistorialEstado()
        //{
        //    try
        //    {
        //        List<ConsultarHistorialEstadoResult> data = dc.ConsultarHistorialEstado().ToList();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        public List<ConsultaHistorialEstadoXPlacaResult> ConsultaHistorialEstado(string Placa)
        {
            try
            {
                List<ConsultaHistorialEstadoXPlacaResult> data = dc.ConsultaHistorialEstadoXPlaca(Placa).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearHistorialEstado(string placa, string idFuncionario, DateTime? fechaHasta, int? idEstadoBien)
        {
            try
            {
                dc.CrearHistorialEstado(placa, idFuncionario, fechaHasta, idEstadoBien);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //public bool EliminarHistorialEstado(int IdHistorialEstado)
        //{
        //    try
        //    {
        //        dc.EliminarHistorialEstado(IdHistorialEstado);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool ActualizarHistorialEstado(int idHistorialEstado, string descripcion, string url)
        //{
        //    try
        //    {
        //        dc.ActualizarHistorialEstado(idHistorialEstado, descripcion, url);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        return false;
        //    }
        //}

    }

}