﻿using System;
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

        public int AutenticarUsuario(string usuario, string contraseña)
        {
            try
            {
                int data = dc.AutenticarUsuario(usuario, contraseña);
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
