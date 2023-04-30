using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using DTO;
using System.Data;

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

        // Tai khoan
        static OracleConnection _conn;
        public static string CheckLoginDTO(TaiKhoan taiKhoan)
        {
            OracleConnection conn = OracleConnectionData.Connect(taiKhoan);
            if (conn == null)
                return "invalid";
            else
            {
                _conn = conn;
                return "sucess";
            }
        }

        // Loai phong
        public static DataTable LayLoaiPhongDTO()
        {
            try
            {
                //string strcon = "TNS_ADMIN=C:/Users/wuuho/Oracle/network/admin;USER ID= HOANGVU ;Password = 1234 ;DATA SOURCE = localhost:1521/XE;PERSIST SECURITY INFO=True";
                //OracleConnection conn = new OracleConnection(strcon);
                string query = "SELECT MALOAI, TENLOAI, SONGUOI, GIATIEN FROM C##SCHEMA_USER.LOAIPHONG";
                OracleDataAdapter sda = new OracleDataAdapter(query, _conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                return dtable;
            }
            catch(Exception)
            {
                return null;
            }
        
        }    

    }
}
