using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL
{
    public class HoSoThanhToanBLL
    {
        public string CheckEmptyFields(HoSoThanhToan hoSo)
        {
            string errorMessage = "";
            
            if (string.IsNullOrEmpty(hoSo.TenKhachHang))
            {
                errorMessage += "TENKHACHHANG cannot be empty. ";
            }
            if (string.IsNullOrEmpty(hoSo.CMND))
            {
                errorMessage += "CMND cannot be empty. ";
            }
            if (string.IsNullOrEmpty(hoSo.SDT))
            {
                errorMessage += "SDT cannot be empty. ";
            }
            return errorMessage;
        }
    }
    

}
