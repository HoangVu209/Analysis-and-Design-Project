using Analysis_and_Design_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace Analysis_and_Design_Project.Forms
{
   
    public partial class Booking : Form
    {
            
        private DataTable LoaiPhong;
        public PhieuDKSPDV PhieuDKSPDV;
        public List<PhieuDKSPDVCT> DKSPDVCTs;
        public PhieuDangKyTour phieuDangKyTour;
        public Booking()
        {
            InitializeComponent();
            LoaiPhongBLL loaiPhongBLL = new LoaiPhongBLL();
            try
            {
                LoaiPhong = loaiPhongBLL.LayLoaiPhong();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
            //currentData = dtgChoosen.DataSource as List<ListRooms>;
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            populateItems();
        }
        private void populateItems()
        {
            //populate it here
            int quantity = LoaiPhong.Rows.Count;
            ListRooms[] listItems = new ListRooms[quantity];
            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListRooms();
                listItems[i].MaPhong = LoaiPhong.Rows[i].ItemArray[0].ToString();
                listItems[i].LoaiPhong = LoaiPhong.Rows[i].ItemArray[1].ToString();

                if (i == 0)
                {
                    listItems[i].Icon = Resources._0;
                    listItems[i].BackColor = Color.FromArgb(208, 194, 185);
                }

                else if (i == 1)
                {
                    listItems[i].Icon = Resources._1;
                    listItems[i].BackColor = Color.FromArgb(171, 179, 185);
                }

                else if (i == 2)
                {
                    listItems[i].Icon = Resources._2;
                    listItems[i].BackColor = Color.FromArgb(133, 165, 185);
                }

                else if (i == 3)
                {
                    listItems[i].Icon = Resources._3;
                    listItems[i].BackColor = Color.FromArgb(97, 150, 185);
                }
                
                listItems[i].SoGiuong = Convert.ToInt32(LoaiPhong.Rows[i].ItemArray[2]); 
                listItems[i].GiaTien = Convert.ToDouble(LoaiPhong.Rows[i].ItemArray[3]);
                listItems[i].setUPColor();
                listItems[i].ButtonClicked += new EventHandler(UserControl_ButtonClicked);
                // add to flowlayout
                /* if(flowLayoutPanel1.Controls.Count > 0)
                 {
                     flowLayoutPanel1.Controls.Clear();
                 }
                 else*/
                flowLayoutPanel1.Controls.Add(listItems[i]);
            }    
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }    
        }
        private int SearchDuplicate(string searchValue)
        {
            try
            {
                
                foreach (DataGridViewRow row in dtgChoosen.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchValue))
                    {                
                        return row.Index;
                    }
                }
                return -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
            
        }
        //Event
        private void UserControl_ButtonClicked(object sender, EventArgs e)
        {
            // Do something in response to the button click
            ListRooms selectedItem = sender as ListRooms;
            ListRooms choosenRoom = new ListRooms();
            choosenRoom.MaPhong = selectedItem.MaPhong;
            choosenRoom.LoaiPhong = selectedItem.MaPhong;
            choosenRoom.SoGiuong = Convert.ToInt32(selectedItem.numericUpDown.Value);
            choosenRoom.GiaTien = selectedItem.GiaTien * Convert.ToInt32(selectedItem.numericUpDown.Value);
            //currentData.Add(choosenRoom);
            //Check duplicate

            int result = SearchDuplicate(choosenRoom.LoaiPhong);

            if (result >= 0)
            {
                double total = Convert.ToDouble(lblMoney.Text);
                total = total - Convert.ToDouble(dtgChoosen.Rows[result].Cells[3].Value) + Convert.ToDouble(choosenRoom.GiaTien);
                dtgChoosen.Rows[result].Cells[2].Value = choosenRoom.SoGiuong;
                dtgChoosen.Rows[result].Cells[3].Value = choosenRoom.GiaTien;
                lblMoney.Text = total.ToString();

            }
            else
            {
                lblMoney.Text = (Convert.ToDouble(lblMoney.Text) + Convert.ToDouble(choosenRoom.GiaTien)).ToString();
                dtgChoosen.Rows.Add(null, choosenRoom.LoaiPhong, choosenRoom.SoGiuong, choosenRoom.GiaTien);
            }
        }

        private void dtgChoosen_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dtgChoosen.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Lay thong tin phieu dang ky 
            PhieuDangKy phieuDangKy = new PhieuDangKy();
            PhieuDangKyBLL phieuDangKyBLL = new PhieuDangKyBLL(); 
            phieuDangKy.TENNGUOIDK = txtName.Text;
            phieuDangKy.SODT = txtPhone.Text;
            phieuDangKy.EMAIL = txtEmail.Text;
            phieuDangKy.NGAYCHECKIN = dtpickerCI.Value.Date;
            phieuDangKy.NGAYCHECKOUT = dtpickerCO.Value.Date;
            // tổng phòng
            foreach(DataGridViewRow row in dtgChoosen.Rows)
            {
                phieuDangKy.TONGPHONG += Convert.ToInt32(row.Cells[2].Value);
            }
            phieuDangKy.YEUCAUDB = txtYCDB.Text;
            phieuDangKy.TONGTIEN = Convert.ToDecimal(lblMoney.Text);
            phieuDangKy.NGAYLAP = DateTime.Now;
            phieuDangKy.VANCHUYENHL = Convert.ToInt32(chkBaggage.Checked);

            // Kiểm tra phiếu đăng ký
            string result = phieuDangKyBLL.KiemTraPhieu(phieuDangKy);
            if (result != "sucess")
            {
                MessageBox.Show(result);
                return;
            }
            // Phiếu đăng ký chi tiết
            List<PhieuDangKyCT> DSPhieuCT = new List<PhieuDangKyCT>();
            foreach( DataGridViewRow row in dtgChoosen.Rows)
            {
                PhieuDangKyCT phieuCT = new PhieuDangKyCT();
                phieuCT.STT = Convert.ToInt32(row.Cells[0].Value);
                phieuCT.LOAIPHONG = row.Cells[1].Value.ToString();
                phieuCT.SOLUONG = Convert.ToInt32(row.Cells[2].Value);
                phieuCT.GIATIEN = Convert.ToDecimal(row.Cells[3].Value);
                DSPhieuCT.Add(phieuCT);
            }


            //MessageBox.Show(DSPhieuCT.Count.ToString());
            this.Hide();
            Payment formPay = new Payment(phieuDangKy, DSPhieuCT, PhieuDKSPDV, DKSPDVCTs, phieuDangKyTour);
            formPay.ShowDialog();
            this.Close();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductAndServices form = new ProductAndServices(this);
            form.ShowDialog();
        }

        private void btnTour_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tour form = new Tour(this);
            form.ShowDialog();
        }
    }
}
