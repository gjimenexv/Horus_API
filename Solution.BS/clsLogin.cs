using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL;

namespace Solution.BS
{
    public class clsLogin
    {
        HorusDataContext dc = new HorusDataContext();

        public List<AutenticarUsuarioResult> AutenticarUsuario(string usuario, string contraseña)
        {
            try
            {
                List<AutenticarUsuarioResult> data = dc.AutenticarUsuario(usuario, contraseña).ToList();
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
