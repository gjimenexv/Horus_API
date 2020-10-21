using System;
using System.Collections.Generic;

namespace Solution.API.Models
{
    public class Oficina
    {
        public Oficina()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdOficina { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}
