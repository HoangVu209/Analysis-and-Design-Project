using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class PhieuDangKyCTAccess:DatabaseAccess
    {
        public int ThemPhieuCT(PhieuDangKyCT phieuDangKyCT)
        {
            return ThemPhieuDangKyCTDTO(phieuDangKyCT);
        }
    }
}
