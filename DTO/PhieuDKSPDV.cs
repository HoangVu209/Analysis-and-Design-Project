using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDKSPDV
    {
        public string MAPHIEU { get; set; }
        public string MAPHIEUDK { get; set; }
        public int TONGSL { get; set; }
        public double TONGTIEN { get; set; }
        public PhieuDKSPDV()
        {
            MAPHIEU = "";
            MAPHIEUDK = "";
            TONGSL = 0;
            TONGTIEN = 0.0;
        }
    }

}
