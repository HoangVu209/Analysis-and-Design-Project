using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using DTO;
namespace DAL
{
    // chuoi connect 
    //TNS_ADMIN=C:\Users\wuuho\Oracle\network\admin;USER ID = SYS; DATA SOURCE = localhost:1521/XE;PERSIST SECURITY INFO=True
    
    public class OracleConnectionData
    {
        //Tạo chuỗi kết nối đến cơ sở dữ liệu 
        public static OracleConnection Connect(TaiKhoan taiKhoan)
        {
            try
            {
                string strcon = "TNS_ADMIN=C:/Users/wuuho/Oracle/network/admin;USER ID = " + taiKhoan.TenTaiKhoan + " ;Password = " + taiKhoan.MatKhau + "; DATA SOURCE = localhost:1521/XE;PERSIST SECURITY INFO=True";
                OracleConnection conn = new OracleConnection(strcon);
                return conn;
            }
            catch(Exception)
            {
                return null;
            }
            
        }
    }
    public class DatabaseAccess
    {
        // Database access
        public static string CheckLoginDTO(TaiKhoan taiKhoan)
        {
            OracleConnection conn = OracleConnectionData.Connect(taiKhoan);
            if (conn == null)
                return "invalid";
            else
                return "sucess";
        }
    }
}
