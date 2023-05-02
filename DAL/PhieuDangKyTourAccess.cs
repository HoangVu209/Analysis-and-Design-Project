using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class PhieuDangKyTourAccess:DatabaseAccess
    {
        public  int ThemDangKyTour(PhieuDangKyTour phieu)
        {
            return ThemDangKyTourDTO(phieu);
        }
    }
}
