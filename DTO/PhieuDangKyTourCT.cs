using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDangKyTourCT
    {
        public string MAPHIEUTOUR { get; set; }
        public string MATOUR { get; set; }
        public string CODE { get; set; }
        public int COMPANY { get; set; }
        
        public double PRICE { get; set; }
    public PhieuDangKyTourCT()
        {
            MAPHIEUTOUR = "";
            MATOUR = "";
            CODE = "";
            COMPANY = 0;
            PRICE = 0.0;
        }
    }
}
