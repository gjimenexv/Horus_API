using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;


namespace Solution.BS
{
    public class clsBienesIdentificados
    {
        HorusDataContext dc = new HorusDataContext();

        public List<ConsultarBienIdentificadoResult> ConsultarBienIdentificados()
        {
            try
            {
                List<ConsultarBienIdentificadoResult> data = dc.ConsultarBienIdentificado().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultarBienIdentificadoXInventarioResult> ConsultarBienIdentificadosXInventario(int IdTomaInventario)
        {
            try
            {
                List<ConsultarBienIdentificadoXInventarioResult> data = dc.ConsultarBienIdentificadoXInventario(IdTomaInventario).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaBienIdentificadoResult> ConsultaBienIdentificado(int IdBienIdentificado)
        {
            try
            {
                List<ConsultaBienIdentificadoResult> data = dc.ConsultaBienIdentificado(IdBienIdentificado).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearBienIdentificado(int IdTomaInventario, DateTime Fecha, string Placa, bool Estado, string ModificadoPor)
        {
            try
            {
                dc.CrearBienesIdentificados(IdTomaInventario, Fecha, Placa, Estado, ModificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarBienIdentificados(int IdBienIdentificado)
        {
            try
            {
                dc.EliminarBienIdentificado(IdBienIdentificado);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarBienIdentificado(int idBienIdentificado, int idTomaInventario, DateTime Fecha, string Placa, bool Estado, string ModificadoPor)
        {
            try
            {
                dc.ActualizarBienesIdentificados(idBienIdentificado, idTomaInventario, Fecha, Placa, Estado, ModificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
