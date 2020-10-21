using System;
using System.Collections.Generic;

namespace Solution.API.Models
{
    public class RolXfuncionario
    {
        public int IdRolXfuncionario { get; set; }
        public int? IdRol { get; set; }
        public string IdFuncionario { get; set; }

        public virtual Funcionario IdFuncionarioNavigation { get; set; }
        public virtual Roles IdRolNavigation { get; set; }
    }
}
