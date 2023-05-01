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
            catch (Exception)
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
            catch (Exception)
            {
                return null;
            }

        }

        // Phiếu đăng ký 
        // Thực hiện tạo và lưu phiếu đăng ký
        public static string LuuPhieuDangKyDTO(PhieuDangKy phieuDangKy)
        {
            OracleTransaction transaction = null;
            string newMaPhieuDK = string.Empty;
            try
            {
                _conn.Open();
                transaction = _conn.BeginTransaction();
                // Tạo command để gọi procedure tạo mã phiếu đăng ký mới
                OracleCommand cmdCreateNewMaPhieuDK = new OracleCommand("SYS.CreateNewMaPhieuDK", _conn);
                cmdCreateNewMaPhieuDK.CommandType = CommandType.StoredProcedure;

                // Tạo parameter để lưu mã phiếu đăng ký mới
                OracleParameter paramNewMaPhieuDK = new OracleParameter();
                paramNewMaPhieuDK.Direction = ParameterDirection.Output;
                paramNewMaPhieuDK.OracleDbType = OracleDbType.Varchar2;
                paramNewMaPhieuDK.Size = 10;
                cmdCreateNewMaPhieuDK.Parameters.Add(paramNewMaPhieuDK);

                // Thực thi command để tạo mã phiếu đăng ký mới
                cmdCreateNewMaPhieuDK.ExecuteNonQuery();

                // Lấy mã phiếu đăng ký mới từ parameter
                newMaPhieuDK = paramNewMaPhieuDK.Value.ToString();
                
                // Tạo command để thêm thông tin vào bảng phiếu đăng ký
                OracleCommand cmdInsertPhieuDangKy = new OracleCommand("INSERT INTO C##SCHEMA_USER.PHIEUDANGKY(MAPHIEUDK, TENNGUOIDK, SODT, EMAIL, NGAYCHECKIN, NGAYCHECKOUT, TONGPHONG, YEUCAUDB, TONGTIEN, DATHANHTOAN, NGAYLAP, VANCHUYENHL) " +
                                                      "VALUES (:maPhieuDK, :tenNguoiDK, :soDT, :email, :ngayCheckin, :ngayCheckout, :tongPhong, :yeuCauDB, :tongTien, :daThanhToan, :ngayLap, :vanChuyenHL)", _conn);

                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("maPhieuDK", newMaPhieuDK));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("tenNguoiDK", phieuDangKy.TENNGUOIDK));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("soDT", phieuDangKy.SODT));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("email", phieuDangKy.EMAIL));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("ngayCheckin", phieuDangKy.NGAYCHECKIN.ToString()));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("ngayCheckout", phieuDangKy.NGAYCHECKOUT.ToString()));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("tongPhong", Convert.ToInt32(phieuDangKy.TONGPHONG)));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("yeuCauDB", phieuDangKy.YEUCAUDB));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("tongTien", Convert.ToDecimal(phieuDangKy.TONGTIEN)));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("daThanhToan", Convert.ToDecimal(phieuDangKy.DATHANHTOAN)));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("ngayLap", DateTime.Now.Date.ToString()));
                cmdInsertPhieuDangKy.Parameters.Add(new OracleParameter("vanChuyenHL", Convert.ToInt32(phieuDangKy.VANCHUYENHL)));

                // Thực thi command để thêm thông tin vào bảng phiếu đăng ký
                cmdInsertPhieuDangKy.ExecuteNonQuery();

                // Commit transaction nếu không có lỗi xảy ra
                transaction.Commit();

                Console.WriteLine("Thêm thông tin phiếu đăng ký thành công!");
                return newMaPhieuDK;
            }

            catch (Exception ex)
            {
                // Rollback transaction nếu có lỗi xảy ra
                transaction.Rollback();
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                _conn.Close();
            }
            return newMaPhieuDK;
        }
        //PhieuDangKyChiTiet
        public static int ThemPhieuDangKyCTDTO(PhieuDangKyCT phieuDangKyCT)
        {
            try
            {
                _conn.Open();
                using (OracleCommand cmdInsertPhieuDangKyCT = new OracleCommand("INSERT INTO C##SCHEMA_USER.PHIEUDANGKYCT(MAPHIEUDK, STT, LOAIPHONG, SOLUONG, GIATIEN) " +
                                                          "VALUES (:maPhieuDK, :sTT, :loaiPhong, :soLuong, :giaTien)", _conn))
                {
                    cmdInsertPhieuDangKyCT.Parameters.Add(new OracleParameter("maPhieuDK", phieuDangKyCT.MAPHIEUDK));
                    cmdInsertPhieuDangKyCT.Parameters.Add(new OracleParameter("sTT", phieuDangKyCT.STT));
                    cmdInsertPhieuDangKyCT.Parameters.Add(new OracleParameter("loaiPhong", phieuDangKyCT.LOAIPHONG));
                    cmdInsertPhieuDangKyCT.Parameters.Add(new OracleParameter("soLuong", phieuDangKyCT.SOLUONG));
                    cmdInsertPhieuDangKyCT.Parameters.Add(new OracleParameter("giaTien", Convert.ToDecimal(phieuDangKyCT.GIATIEN)));
                    cmdInsertPhieuDangKyCT.ExecuteNonQuery();
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                _conn.Close();
            }

        }

        // DANH SACH SAN PHAM DICH VU
        public static DataTable DanhSachSPDVDTO()
        {
            try
            {
                string query = "SELECT MASPDV, TEN, GIATIEN, SONGUOIDUNG, MOTA, DANHGIA FROM C##SCHEMA_USER.DSSANPHAM_DV";
                OracleDataAdapter sda = new OracleDataAdapter(query, _conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }


        // PHIẾU ĐĂNG KÝ SẢN PHẨM DỊCH VỤ
        public static string ThemPhieuDKSPDVDTO(PhieuDKSPDV phieu)
        {
            _conn.Open();
            string maPhieu = string.Empty;
            using (OracleCommand cmd = new OracleCommand("SYS.GENERATE_PHIEU_ID", _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter outParam = new OracleParameter("OUT_ID", OracleDbType.Varchar2, 20);
                outParam.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outParam);

                using (OracleTransaction txn = _conn.BeginTransaction())
                {
                    try
                    {
                        cmd.Transaction = txn;
                        cmd.ExecuteNonQuery();

                        maPhieu = outParam.Value.ToString();

                        // Thêm mã phiếu vào bảng cơ sở dữ liệu
                        using (OracleCommand cmdInsert = new OracleCommand("INSERT INTO C##SCHEMA_USER.PHIEUDKSPDV (MAPHIEU, MAPHIEUDK, TONGSL, TONGTIEN) VALUES (:MAPHIEU, :MAPHIEUDK, :TONGSL, :TONGTIEN)", _conn))
                        {
                            cmdInsert.Transaction = txn;
                            cmdInsert.Parameters.Add(":MAPHIEU", OracleDbType.Varchar2, 20).Value = maPhieu;
                            cmdInsert.Parameters.Add(":MAPHIEUDK", OracleDbType.Varchar2, 20).Value = phieu.MAPHIEUDK;
                            cmdInsert.Parameters.Add(":TONGSL", OracleDbType.Int32).Value = phieu.TONGSL;
                            cmdInsert.Parameters.Add(":TONGTIEN", OracleDbType.Decimal).Value = Convert.ToDecimal(phieu.TONGTIEN);
                            cmdInsert.ExecuteNonQuery();
                        }

                        txn.Commit();

                        _conn.Close();
                        return maPhieu;
                    }
                    catch (Exception ex)
                    {
                        txn.Rollback();
                        _conn.Close();
                        throw ex;
                    }
                }

            }

        }
        // PHIẾU ĐĂNG KÝ SẢN PHẨM DỊCH VỤ CHI TIẾT
        public int AddDataToPHIEUCHITIETSP_DVDTO(PhieuDKSPDVCT phieu)
        {
            try
            {
                _conn.Open();
                string sql = "INSERT INTO C##SCHEMA_USER.PHIEUCHITIETSP_DV(MAPHIEU, MASPDV, SOLUONG, GIATIEN) VALUES(:MAPHIEU, :MASPDV, :SOLUONG, :GIATIEN)";

                using (OracleCommand cmdInsert = new OracleCommand(sql, _conn))
                {
                    cmdInsert.Parameters.Add(":MAPHIEU", OracleDbType.Varchar2, 4).Value = phieu.MAPHIEU;
                    cmdInsert.Parameters.Add(":MASPDV", OracleDbType.Varchar2, 4).Value = phieu.MASPDV;
                    cmdInsert.Parameters.Add(":SOLUONG", OracleDbType.Int32).Value = phieu.SOLUONG;
                    cmdInsert.Parameters.Add(":GIATIEN", OracleDbType.Decimal).Value = Convert.ToDecimal(phieu.GIATIEN);

                    cmdInsert.ExecuteNonQuery();
                }
                return 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                _conn.Close();
            }
        }


    }
}




