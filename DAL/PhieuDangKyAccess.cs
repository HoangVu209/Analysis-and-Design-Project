using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class PhieuDangKyAccess:DatabaseAccess
    {
        public string LuuPhieuDangKy(PhieuDangKy phieuDangKy)
        {
            return LuuPhieuDangKyDTO(phieuDangKy);
        }
    }
}
