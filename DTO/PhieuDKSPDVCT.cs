using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDKSPDVCT
    {
        public string MAPHIEU { get; set; }
        public string MASPDV { get; set; }
        public int SOLUONG { get; set; }
        public double GIATIEN { get; set; }

        public PhieuDKSPDVCT()
        {
            MAPHIEU = "";
            MASPDV = "";
            SOLUONG = 0;
            GIATIEN = 0.0;
        }
    }
   
}
