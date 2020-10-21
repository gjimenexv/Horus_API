using Solution.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BS
{
    public class clsRol
    {
        HorusDataContext dc = new HorusDataContext();

        public List<ConsultarRolResult> ConsultarRol()
        {

            try
            {
                List<ConsultarRolResult> data = dc.ConsultarRol().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaRolResult> ConsultaRol(int IdRol)
        {
            try
            {
                List<ConsultaRolResult> data = dc.ConsultaRol(IdRol).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //TODO: To define where the ConsultarRolXFuncionario is going to be used
        //public List<ConsultarRolXFuncionarioResult> ConsultarRolXFuncionario(int IdFuncionario)
        //{
        //    try
        //    {
        //        List<ConsultarRolXFuncionarioResult> data = dc.ConsultarRolXFuncionario(IdFuncionario).ToList();
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
        public bool CrearRol(string descripcion)
        {
            try
            {
                dc.CrearRol(descripcion);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarRol(int IdRol)
        {
            try
            {
                dc.EliminarRol(IdRol);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool ActualizarRoles(int IdRol, string descripcion)
        {
            try
            {
                dc.ActualizarRol(IdRol, descripcion);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}
