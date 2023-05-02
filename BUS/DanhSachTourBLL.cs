using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
namespace BLL
{
    public class DanhSachTourBLL
    {
        public DataTable GetDanhSachTourFromOracle()
        {
            DanhSachTourAccess danhSachTourAccess = new DanhSachTourAccess();
            return danhSachTourAccess.GetDanhSachTourFromOracle();
        }
    }
}
