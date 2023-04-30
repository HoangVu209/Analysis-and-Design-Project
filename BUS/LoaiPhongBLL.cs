using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;
namespace BLL
{
    public class LoaiPhongBLL
    {
        public DataTable LayLoaiPhong()
        {
            LoaiPhongAccess loaiPhong = new LoaiPhongAccess();
            return loaiPhong.LayLoaiPhong();
        }    
    }
}
