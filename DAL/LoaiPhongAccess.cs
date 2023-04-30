using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
    public class LoaiPhongAccess:DatabaseAccess
    {
        public DataTable LayLoaiPhong()
        {
            return LayLoaiPhongDTO();
        }
    }
}
