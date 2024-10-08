﻿using System;
using System.Collections.Generic;

namespace Solution.API.Models
{
    public class CentroCosto
    {
        public CentroCosto()
        {
            Bien = new HashSet<Bien>();
            TomaInventario = new HashSet<TomaInventario>();
        }

        public int IdCentroCosto { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? UltimaVez { get; set; }

        public virtual ICollection<Bien> Bien { get; set; }
        public virtual ICollection<TomaInventario> TomaInventario { get; set; }
    }

    public class CentroCostoModelView
    {
        public CentroCostoModelView()
        {
            Bien = new HashSet<Bien>();
            TomaInventario = new HashSet<TomaInventario>();
        }

        public int IdCentroCosto { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? UltimaVez { get; set; }

        public virtual ICollection<Bien> Bien { get; set; }
        public virtual ICollection<TomaInventario> TomaInventario { get; set; }
    }
}
