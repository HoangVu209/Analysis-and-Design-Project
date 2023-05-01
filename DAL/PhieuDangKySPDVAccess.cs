using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class PhieuDangKySPDVAccess:DatabaseAccess
    {
        public string ThemPhieuDKSPDV(PhieuDKSPDV phieu)
        {
            return ThemPhieuDKSPDVDTO(phieu);
        }
    }
}
