using System;
using System.Collections.Generic;

#nullable disable

namespace UTS_DataHadir.Models
{
    public partial class Gajian
    {
        public int IdGaji { get; set; }
        public int? IdEmp { get; set; }
        public int? IdKehadiran { get; set; }
        public decimal? NominalGaji { get; set; }
        public int? IdKetBayar { get; set; }

        public virtual Employee IdEmpNavigation { get; set; }
        public virtual Kehadiran IdKehadiranNavigation { get; set; }
        public virtual KeteranganPembayaran IdKetBayarNavigation { get; set; }
    }
}
