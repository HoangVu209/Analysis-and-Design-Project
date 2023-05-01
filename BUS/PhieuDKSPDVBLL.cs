using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class PhieuDKSPDVBLL
    {
        public string ThemPhieuDKSPDV(PhieuDKSPDV phieu)
        {
            PhieuDangKySPDVAccess phieu1 = new PhieuDangKySPDVAccess();
            return phieu1.ThemPhieuDKSPDV(phieu);
        }
    }
}
