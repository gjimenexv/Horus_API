using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{
    public class clsAccesosXRol
    {

        HorusDataContext dc = new HorusDataContext();

        public List<ConsultarAccesosXRolResult> ConsultarAccessoXRol()
        {
            try
            {
                List<ConsultarAccesosXRolResult> data = dc.ConsultarAccesosXRol().ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ConsultaAccesosXRolResult> ConsultaAccessoXRol(int IdRol, int IdAccesso)
        {
            try
            {
                List<ConsultaAccesosXRolResult> data = dc.ConsultaAccesosXRol(IdRol,IdAccesso).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool CrearAccessoXRol(int idAcceso,int idRol)
        {
            try
            {
                dc.CrearAccesosXRol(idAcceso, idRol);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EliminarAccessoXRol(int IdAccessoXRol)
        {
            try
            {
                dc.EliminarAccesosXRol(IdAccessoXRol);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarAccessoXRol(int idAccessoXrol, int idAcceso, int idRol)
        {
            try
            {
                dc.ActualizarAccesosXRol(idAccessoXrol, idAcceso, idRol);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }

}




