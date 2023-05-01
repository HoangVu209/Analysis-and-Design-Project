using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhSachSPDV
    {
        string MASPDV { get; set; }
        string TEN { get; set; }
        decimal GIATIEN { get; set; }
        int SONGUOIDUNG { get; set; }
        string MOTA { get; set; }
        int DANHGIA { get; set; }

        public DanhSachSPDV()
        {
            // Khởi tạo các thuộc tính với giá trị mặc định
            MASPDV = "";
            TEN = "";
            GIATIEN = 0;
            SONGUOIDUNG = 0;
            MOTA = "";
            DANHGIA = 0;
        }
    }
}
