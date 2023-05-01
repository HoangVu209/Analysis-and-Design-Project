using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class PhieuDangKyCTBLL
    {
        public int ThemPhieuCT(PhieuDangKyCT phieuDangKyCT)
        {
            PhieuDangKyCTAccess phieuDangKyCTAccess = new PhieuDangKyCTAccess();
            return phieuDangKyCTAccess.ThemPhieuCT(phieuDangKyCT);
        }
    }
}
