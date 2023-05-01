using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
namespace Analysis_and_Design_Project.Forms
{
    public partial class Invoice : Form
    {
        PhieuDangKy _phieuDangKy;
        List<PhieuDangKyCT> _DSPhieuCT;
        HoSoThanhToan _hoSo;
        PhieuDKSPDV _phieuDKSPDV;
        List<PhieuDKSPDVCT> _phieuDKSPDVCTs;
        public Invoice(PhieuDangKy phieuDangKy, List<PhieuDangKyCT> DSPhieuCT, 
            HoSoThanhToan hoSo, PhieuDKSPDV phieuDKSPDV, List<PhieuDKSPDVCT> phieuDKSPDVCTs) 
        {

            InitializeComponent();
            _phieuDangKy = phieuDangKy;
            _DSPhieuCT = DSPhieuCT;
            _hoSo = hoSo;
            _phieuDKSPDV = phieuDKSPDV;
            _phieuDKSPDVCTs = phieuDKSPDVCTs;
            LoadInv();
        }
        private void LoadInv()
        {
            // DATAGRIDVIEW REGIS FORM
            lblRegisTotal.Text = _phieuDangKy.TONGTIEN.ToString();
            for(int i = 0; i < _DSPhieuCT.Count; i++)
            {
                dtgRegisForm.Rows.Add(_DSPhieuCT[i].STT, _DSPhieuCT[i].LOAIPHONG, _DSPhieuCT[i].SOLUONG, _DSPhieuCT[i].GIATIEN);
            }
            if (_phieuDKSPDVCTs.Count > 0)
            {
                for (int i = 0; i < _phieuDKSPDVCTs.Count; i++)
                {
                    dtgSPDV.Rows.Add(_phieuDKSPDVCTs[i].MASPDV, _phieuDKSPDVCTs[i].SOLUONG, _phieuDKSPDVCTs[i].GIATIEN);
                }
                lblTTSPDV.Text = _phieuDKSPDV.TONGTIEN.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PhieuDangKyBLL phieuDangKyBLL = new PhieuDangKyBLL();
            // Thêm và trả về mã phiếu đăng ký
            string maPhieuDK = phieuDangKyBLL.ThemPhieuDangKy(_phieuDangKy);
            _phieuDKSPDV.MAPHIEUDK = maPhieuDK;
            PhieuDKSPDVBLL phieuDKSPDVBLL = new PhieuDKSPDVBLL();

            // Phiếu đăng ký sử dụng dịch vụ chi tiết
            string maPhieuDKSPDV = string.Empty;
            if (_phieuDKSPDV != null)
                maPhieuDKSPDV = phieuDKSPDVBLL.ThemPhieuDKSPDV(_phieuDKSPDV);
            int count1 = 0;
            if(_phieuDKSPDVCTs.Count > 0)
            {
                do
                {
                    PhieuDKSPDVCT phieu = new PhieuDKSPDVCT();
                    phieu = _phieuDKSPDVCTs[count1];
                    phieu.MAPHIEU = maPhieuDKSPDV;
                    PhieuDangKySPDVCTBLL phieuBLL = new PhieuDangKySPDVCTBLL();
                    int result = phieuBLL.AddDataToPHIEUCHITIETSP_DV(phieu);
                    if (result == 0)
                    {
                        MessageBox.Show("Thêm thất bại!");
                        break;
                    }
                    count1++;
                } while (count1 < _DSPhieuCT.Count);
            }    
            // Thêm mã đăng ký vào các phần tử và lần lượt thêm vào CSDL 
            int count = 0;
            do
            {
                PhieuDangKyCT phieu = new PhieuDangKyCT();
                phieu = _DSPhieuCT[count];
                phieu.MAPHIEUDK = maPhieuDK;
                PhieuDangKyCTBLL phieuBLL = new PhieuDangKyCTBLL();
                int result = phieuBLL.ThemPhieuCT(phieu);
                if (result == 0)
                {
                    MessageBox.Show("Thêm thất bại!");
                    break;
                }
                count++;
            } while (count < _DSPhieuCT.Count);



            MessageBox.Show("Thêm thành công");
        }
    }
}
