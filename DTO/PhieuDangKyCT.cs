using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDangKyCT
    {
        public string MAPHIEUDK { set; get; }
        public int STT { set; get; }
        public string LOAIPHONG { set; get; }
        public int SOLUONG { set; get; }
        public decimal GIATIEN { set; get; }
        public PhieuDangKyCT(int stt, string loaiPhong, int soLuong, decimal giaTien)
        {
            this.MAPHIEUDK = string.Empty;
            this.STT = stt;
            this.LOAIPHONG = loaiPhong;
            this.SOLUONG = soLuong;
            this.GIATIEN = giaTien;
        }
        public PhieuDangKyCT()
        {
            this.MAPHIEUDK = string.Empty;
            this.STT = 0;
            this.LOAIPHONG = string.Empty;
            this.SOLUONG = 0;
            this.GIATIEN = 0;
        }
    }
}
