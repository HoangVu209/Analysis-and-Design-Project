using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDangKy
    {
        public string MAPHIEUDK { get; set; }
        public string TENNGUOIDK { get; set; }
        public string SODT { get; set; }
        public string EMAIL { get; set; }
        public DateTime NGAYCHECKIN { get; set; }
        public DateTime NGAYCHECKOUT { get; set; }
        public int TONGPHONG { get; set; }
        public string YEUCAUDB { get; set; }
        public decimal TONGTIEN { get; set; }
        public decimal DATHANHTOAN { get; set; }
        public DateTime NGAYLAP { get; set; }
        public int VANCHUYENHL { get; set; }
        public PhieuDangKy(string tenNguoiDK, string soDT, string email, DateTime ngayCheckin, DateTime ngayCheckout, int tongPhong, string yeuCauDB, decimal tongTien, decimal daThanhToan, DateTime ngayLap, int vanChuyenHL)
        {
            MAPHIEUDK = string.Empty;
            TENNGUOIDK = tenNguoiDK;
            SODT = soDT;
            EMAIL = email;
            NGAYCHECKIN = ngayCheckin;
            NGAYCHECKOUT = ngayCheckout;
            TONGPHONG = tongPhong;
            YEUCAUDB = yeuCauDB;
            TONGTIEN = tongTien;
            DATHANHTOAN = daThanhToan;
            NGAYLAP = ngayLap;
            VANCHUYENHL = vanChuyenHL;
        }
        public PhieuDangKy()
        {
            MAPHIEUDK = "";
            TENNGUOIDK = "";
            SODT = "";
            EMAIL = "";
            NGAYCHECKIN = DateTime.MinValue;
            NGAYCHECKOUT = DateTime.MinValue;
            TONGPHONG = 0;
            YEUCAUDB = "";
            TONGTIEN = 0;
            DATHANHTOAN = 0;
            NGAYLAP = DateTime.MinValue;
            VANCHUYENHL = 0;
        }
    }
}
