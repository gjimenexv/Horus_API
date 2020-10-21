using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{

    public class clsBien
    {
        HorusDataContext dc = new HorusDataContext();


        public List<ConsultarBienResult> ConsultarBien()
        {
            try
            {
                List<ConsultarBienResult> data = dc.ConsultarBien().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaBienResult> ConsultaBien(string Placa)
        {
            try
            {
                List<ConsultaBienResult> data = dc.ConsultaBien(Placa).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearBien(string placa, string descripcion, DateTime fechaIngreso, decimal valorInicial, int garantia, string observaciones, bool entregadoBienes, int idTipoDepreciacion, int idCentroCosto, int idEstadoBien, string idFuncionario, int idTipoBien)
        {
            try
            {
                dc.CrearBien(placa, descripcion, fechaIngreso, valorInicial, garantia, observaciones, entregadoBienes, idTipoDepreciacion, idCentroCosto, idEstadoBien, int.Parse(idFuncionario), idTipoBien);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarBien(string Placa)
        {
            try
            {
                dc.EliminarBien(Placa);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarBien(string placa, string descripcion, DateTime fechaIngreso, decimal valorInicial, int garantia, string observaciones, bool entregadoBienes, int idTipoDepreciacion, int idCentroCosto, int idEstadoBien, string idFuncionario, int idTipoBien)
        {
            try
            {
                dc.ActualizarBien(placa, descripcion, fechaIngreso, valorInicial, garantia, observaciones, entregadoBienes, idTipoDepreciacion, idCentroCosto, idEstadoBien, int.Parse(idFuncionario), idTipoBien);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }

}
