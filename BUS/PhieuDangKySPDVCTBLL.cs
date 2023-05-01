using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class PhieuDangKySPDVCTBLL
    {
        public int AddDataToPHIEUCHITIETSP_DV(PhieuDKSPDVCT phieu)
        {
            PhieuDangKySPDVCTAccess phieu1 = new PhieuDangKySPDVCTAccess();
            return phieu1.AddDataToPHIEUCHITIETSP_DV(phieu);
        }
    }
}
