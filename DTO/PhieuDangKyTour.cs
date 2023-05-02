using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDangKyTour
    {
        public string MAPHIEUTOUR { get; set; }
        public int TONGNGUOI { get; set; }
        public int TOSOLUONGTOUR { get; set; }
        public double TONGTIEN { get; set; }
        public int TUTUC { get; set; }
        public string MAPHIEUDK { get; set; }
        public string THOIGIANDK { get; set; }
        public List<DSTGTour> DANHSACHTG { get; set; }
        public List<PhieuDangKyTourCT> PHIEUCT { get; set; }
        public PhieuDangKyTour()
        {
            // Set the default values of the properties.
            MAPHIEUTOUR = "";
            TONGNGUOI = 0;
            TOSOLUONGTOUR = 0;
            TONGTIEN = 0.0;
            TUTUC = 0;
            MAPHIEUDK = "";
            THOIGIANDK = "";
            DANHSACHTG = new List<DSTGTour>();
            PHIEUCT = new List<PhieuDangKyTourCT>();
        }

    }
}
