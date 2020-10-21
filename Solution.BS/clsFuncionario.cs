using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{

    public class clsFuncionario
    {
        HorusDataContext dc = new HorusDataContext();


        public List<ConsultarFuncionarioResult> ConsultarFuncionario()
        {
            try
            {
                List<ConsultarFuncionarioResult> data = dc.ConsultarFuncionario().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaFuncionarioResult> ConsultaFuncionario(int IdFuncionario)
        {
            try
            {
                List<ConsultaFuncionarioResult> data = dc.ConsultaFuncionario(IdFuncionario).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearFuncionario(int idOficina, string nombreCompleto, string usuario, string contrasena, string correoElectronico)
        {
            try
            {
                dc.CrearFuncionario(idOficina, nombreCompleto, usuario, contrasena, correoElectronico);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarFuncionario(int IdFuncionario)
        {
            try
            {
                dc.EliminarFuncionario(IdFuncionario);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool ActualizarFuncionario(string IdFuncionario, int idOficina, string nombreCompleto, string usuario, string contrasena, string correoElectronico)
        {
            try
            {
                dc.ActualizarFuncionario(int.Parse(IdFuncionario), idOficina, nombreCompleto, usuario, contrasena, correoElectronico);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }

}
