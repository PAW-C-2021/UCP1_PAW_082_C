using System;
using System.Collections.Generic;

#nullable disable

namespace UTS_DataHadir.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Gajians = new HashSet<Gajian>();
            Kehadirans = new HashSet<Kehadiran>();
        }

        public int IdEmp { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Posisi { get; set; }

        public virtual ICollection<Gajian> Gajians { get; set; }
        public virtual ICollection<Kehadiran> Kehadirans { get; set; }
    }
}
