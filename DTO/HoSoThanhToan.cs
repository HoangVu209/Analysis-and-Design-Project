using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoSoThanhToan
    {
        public string MaHoSo { get; set; }
        public string TenKhachHang { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string STK { get; set; }
        public string MaPhieuDK { get; set; }

        public string PhuongThuc { get; set; }

        public HoSoThanhToan(string maHoSo, string tenKhachHang, string cmnd, string sdt, string stk, string maPhieuDK, string phuongThuc)
        {
            MaHoSo = maHoSo;
            TenKhachHang = tenKhachHang;
            CMND = cmnd;
            SDT = sdt;
            STK = stk;
            MaPhieuDK = maPhieuDK;
            PhuongThuc = phuongThuc;
        }
        public HoSoThanhToan()
        {
            MaHoSo = "";
            TenKhachHang = "";
            CMND = "";
            SDT = "";
            STK = "";
            MaPhieuDK = "";
            PhuongThuc = "";
        }
    }
}
