using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class PhieuDangKyBLL
    {
        public string KiemTraPhieu(PhieuDangKy phieuDangKy)
        {

            if (string.IsNullOrEmpty(phieuDangKy.TENNGUOIDK) || string.IsNullOrEmpty(phieuDangKy.SODT) || string.IsNullOrEmpty(phieuDangKy.EMAIL))
            {
                return "Giá trị tên người đăng ký, số điện thoại và email không hợp lệ";
            }

            if (phieuDangKy.NGAYCHECKIN >= phieuDangKy.NGAYCHECKOUT)
            {
                return "Ngày check-in phải nhỏ hơn ngày check-out";
            }

            return "sucess";
        }

        public string ThemPhieuDangKy(PhieuDangKy phieuDangKy)
        {
            PhieuDangKyAccess phieuDangKyAccess = new PhieuDangKyAccess();
            return phieuDangKyAccess.LuuPhieuDangKy(phieuDangKy);
        }
    }
}
