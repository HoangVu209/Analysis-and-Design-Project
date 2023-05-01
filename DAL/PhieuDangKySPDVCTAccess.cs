using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class PhieuDangKySPDVCTAccess:DatabaseAccess
    {
        public int AddDataToPHIEUCHITIETSP_DV(PhieuDKSPDVCT phieu)
        {
            return AddDataToPHIEUCHITIETSP_DVDTO(phieu);
        }
    }
}
