using System;
using System.Collections.Generic;

#nullable disable

namespace UTS_DataHadir.Models
{
    public partial class Statushadir
    {
        public Statushadir()
        {
            Kehadirans = new HashSet<Kehadiran>();
        }

        public int IdStatus { get; set; }
        public string Keterangan { get; set; }

        public virtual ICollection<Kehadiran> Kehadirans { get; set; }
    }
}
