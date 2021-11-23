using System;
using System.Collections.Generic;

#nullable disable

namespace UTS_DataHadir.Models
{
    public partial class KeteranganPembayaran
    {
        public KeteranganPembayaran()
        {
            Gajians = new HashSet<Gajian>();
        }

        public int IdKetBayar { get; set; }
        public string KetBayar { get; set; }

        public virtual ICollection<Gajian> Gajians { get; set; }
    }
}
