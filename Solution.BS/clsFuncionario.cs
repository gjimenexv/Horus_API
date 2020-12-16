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

        public List<ConsultaFuncionarioResult> ConsultaFuncionario(string IdFuncionario)
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
        public bool CrearFuncionario(int idOficina, string nombreCompleto, string usuario, string contrasena, string correoElectronico, string modificadoPor)
        {
            try
            {
                dc.CrearFuncionario(idOficina, nombreCompleto, usuario, contrasena, correoElectronico, modificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarFuncionario(string IdFuncionario)
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


        public bool ActualizarFuncionario(string IdFuncionario, int idOficina, string nombreCompleto, string usuario, string contrasena, string correoElectronico, string modificadoPor)
        {
            try
            {
                dc.ActualizarFuncionario(IdFuncionario, idOficina, nombreCompleto, usuario, contrasena, correoElectronico, modificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public int ConsultaCorreo(string correoElectronico)
        {
            int existe;
            try
            {
                existe = dc.ConsultaCorreo(correoElectronico);
                return existe;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public bool CrearToken(string token, string correoElectronico, string modificadoPor)
        {
            try
            {
                dc.CrearToken(token, correoElectronico, modificadoPor);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool ActualizarContrasena(string token, string contrasena, string correoElectronico)
        {
            try
            {
                dc.ActualizarContrasena(token, contrasena, correoElectronico);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public int ConsultaToken(string token, string correoElectronico)
        {
            try
            {
                return dc.ConsultaToken(token, correoElectronico);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public string ConsultaRol(string usuario)
        {
            try
            {
                List<ConsultaRolXFuncionarioResult> data = dc.ConsultaRolXFuncionario(usuario).ToList();
                return data[0].Rol.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
