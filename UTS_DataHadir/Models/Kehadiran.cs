using System;
using System.Collections.Generic;

#nullable disable

namespace UTS_DataHadir.Models
{
    public partial class Kehadiran
    {
        public Kehadiran()
        {
            Gajians = new HashSet<Gajian>();
        }

        public int IdKehadiran { get; set; }
        public int? IdEmp { get; set; }
        public int? IdStatus { get; set; }
        public DateTime? TanggalHadir { get; set; }

        public virtual Employee IdEmpNavigation { get; set; }
        public virtual Statushadir IdStatusNavigation { get; set; }
        public virtual ICollection<Gajian> Gajians { get; set; }
    }
}
