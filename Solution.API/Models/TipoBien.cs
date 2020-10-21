using System;
using System.Collections.Generic;

namespace Solution.API.Models
{
    public class TipoBien
    {
        public TipoBien()
        {
            Bien = new HashSet<Bien>();
        }

        public int IdTipoBien { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Bien> Bien { get; set; }
    }
}
