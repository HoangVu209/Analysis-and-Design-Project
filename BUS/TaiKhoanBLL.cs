using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanAccess taiKhoanAccess = new TaiKhoanAccess();
        public string checkLogin(TaiKhoan taiKhoan)
        {
            //Kiểm tra nghiệp vụ
            if(taiKhoan.TenTaiKhoan == "")
            {
                return "req_taikhoan";
            }    
            if(taiKhoan.MatKhau == "")
            {
                return "req_matkhau";
            }
            string info = taiKhoanAccess.CheckLogin(taiKhoan);
            return info;
        }
    }
}
