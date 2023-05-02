using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class PhieuDangKyTourBLL
    {
        public int ThemDangKyTour(PhieuDangKyTour phieu)
        {
            PhieuDangKyTourAccess dangKyTourAccess = new PhieuDangKyTourAccess();
            return dangKyTourAccess.ThemDangKyTour(phieu);
        }
    }
}
