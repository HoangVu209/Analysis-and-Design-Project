using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhSachTour
    {
        public string MATOUR { get; set; }
        public string TEN { get; set; }
        public double GIATIEN { get; set; }
        public int MACONGTY { get; set; }
        public string MOTA { get; set; }
        public DanhSachTour()
        {
            // Set all properties to their default values.
            MATOUR = "";
            TEN = "";
            GIATIEN = 0.0;
            MACONGTY = 0;
            MOTA = "";
        }
    }
}
