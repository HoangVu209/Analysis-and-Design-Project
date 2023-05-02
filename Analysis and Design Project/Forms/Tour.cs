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
using Analysis_and_Design_Project.Properties;

namespace Analysis_and_Design_Project.Forms
{
    public partial class Tour : Form
    {
        Booking _formBooking;
        private PhieuDangKyTour _phieu;
        public Tour()
        {
            
            _phieu = new PhieuDangKyTour();
            InitializeComponent();
        }
        public Tour(Booking form)
        {
           // _formBooking = new Booking();
            _formBooking = form;
            _phieu = new PhieuDangKyTour();
            InitializeComponent();
        }
        private void populateItems()
        {
            // Lấy danh sách tour
            DataTable danhSachTour;
            DanhSachTourBLL danhSachTourBLL = new DanhSachTourBLL();
            danhSachTour = danhSachTourBLL.GetDanhSachTourFromOracle();
            //populate it here
            TourList[] listItems = new TourList[danhSachTour.Rows.Count];
            
            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new TourList();
                listItems[i].maTour = danhSachTour.Rows[i].ItemArray[0].ToString();
                listItems[i].tenTour = danhSachTour.Rows[i].ItemArray[1].ToString();
                listItems[i].giaTien = Convert.ToDouble(danhSachTour.Rows[i].ItemArray[2]);
                listItems[i].congTy = Convert.ToInt32(danhSachTour.Rows[i].ItemArray[3]);
                listItems[i].moTa = danhSachTour.Rows[i].ItemArray[4].ToString();
                flowLayoutPanel1.Controls.Add(listItems[i]);
                if (i == 0)
                    listItems[i].Icon = Resources.nhatrang1;
                if (i == 1)
                    listItems[i].Icon = Resources.danang;
                if (i == 2)
                    listItems[i].Icon = Resources.phuquoc;
                if (i == 3)
                    listItems[i].Icon = Resources.sapa;
                listItems[i].ButtonClicked += new EventHandler(UserControl_ButtonClicked);
            }
            button1.Visible = false;
        }
        private int SearchDuplicate(string searchValue)
        {
            try
            {

                for (int i = 0; i < dtgChoosen.Rows.Count - 1; i++)
                {
                    
                    if (dtgChoosen.Rows[i].Cells[1].Value.ToString() == searchValue)
                    {
                      
                        return 2;
                    }
                }
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;

        }
        private void UserControl_ButtonClicked(object sender, EventArgs e)
        {
            // Do something in response to the button click
            TourList selectedItem = sender as TourList;
            TourList choosenRoom = new TourList();
            // Assign the `MATOUR` attribute.
            choosenRoom.maTour = selectedItem.maTour;

            // Assign the `TEN` attribute.
            choosenRoom.tenTour = selectedItem.tenTour;

            // Assign the `GIATIE` attribute.
            choosenRoom.giaTien = selectedItem.giaTien;

            // Assign the `MACONGTY` attribute.
            choosenRoom.congTy = selectedItem.congTy;

            // Assign the `MOTA` attribute.
            choosenRoom.moTa = selectedItem.moTa;


            //currentData.Add(choosenRoom);
            //Check duplicate
            int result = -1;
            if(dtgChoosen.Rows.Count > 1)
                result = SearchDuplicate(choosenRoom.maTour);

            if (result < 0)
            {
                lblTotal.Text = (Convert.ToDouble(lblTotal.Text) + Convert.ToDouble(choosenRoom.giaTien)).ToString();
                dtgChoosen.Rows.Add(null, choosenRoom.maTour, choosenRoom.congTy, choosenRoom.giaTien);
            }
        }

        private void Tour_Load(object sender, EventArgs e)
        {
            populateItems();
        }

        private void dtgChoosen_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dtgChoosen.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            dtgMember.Rows.Add(null, txtName.Text, txtCMND.Text);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dtgMember.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void chkGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGroup.Checked)
                button1.Visible = true;
            else
                button1.Visible = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            if(dtgChoosen.Rows.Count > 1)
            {
                _phieu.TONGNGUOI = dtgMember.Rows.Count;
                _phieu.TONGNGUOI -= 1;
                _phieu.TOSOLUONGTOUR = dtgChoosen.Rows.Count;
                _phieu.TOSOLUONGTOUR -= 1;
                _phieu.TONGTIEN = Convert.ToDouble(lblTotal.Text);
                _phieu.TUTUC = Convert.ToInt32(!chkShuttle.Checked);
                _phieu.THOIGIANDK = Convert.ToString(dateTimePicker1.Value.Date);


                // danh sach nguoi tham gia
                for(int i = 0; i < dtgMember.Rows.Count - 1; i++)
                {
                    DSTGTour nguoiThamGia = new DSTGTour();
                    nguoiThamGia.STT = Convert.ToInt32(dtgMember.Rows[i].Cells[0].Value);
                    nguoiThamGia.HOTEN = Convert.ToString(dtgMember.Rows[i].Cells[1].Value);
                    nguoiThamGia.CMND = Convert.ToString(dtgMember.Rows[i].Cells[2].Value);

                    // them vaof danh sacsh
                    _phieu.DANHSACHTG.Add(nguoiThamGia);
                }


                //danh sach phieu chi tiet
                for(int i = 0; i < dtgChoosen.Rows.Count - 1; i++)
                {
                    PhieuDangKyTourCT phieuCT = new PhieuDangKyTourCT();
                    phieuCT.MATOUR = Convert.ToString(dtgChoosen.Rows[i].Cells[1].Value);
                    phieuCT.COMPANY = Convert.ToInt32(dtgChoosen.Rows[i].Cells[2].Value);
                    phieuCT.PRICE = Convert.ToDouble(dtgChoosen.Rows[i].Cells[3].Value);

                    //them vao danh sach
                    _phieu.PHIEUCT.Add(phieuCT);
                }
            }
            _formBooking.phieuDangKyTour = _phieu;
            this.Hide();
            _formBooking.Show();
            this.Close();
        }
    }
}
