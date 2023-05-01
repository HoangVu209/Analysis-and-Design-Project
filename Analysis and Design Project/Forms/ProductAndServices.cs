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
using Analysis_and_Design_Project.Properties;

namespace Analysis_and_Design_Project.Forms
{
    public partial class ProductAndServices : Form
    {
        private DataTable DSSPDV;
        private Booking _formBooking;        

        public ProductAndServices()
        {
            
            InitializeComponent();
       
        }
        public ProductAndServices(Booking form)
        {

            InitializeComponent();
            _formBooking = form;

        }

        private void ProductAndServices_Load(object sender, EventArgs e)
        {
            populateItems();
        }
        
        private void populateItems()
        {
            //populate it here
            DanhSachSPDVBLL danhSachBLL = new DanhSachSPDVBLL();
            DSSPDV = danhSachBLL.LayDSSPDV();
            ListProduct[] listItems = new ListProduct[DSSPDV.Rows.Count];
            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListProduct();
                listItems[i].Code = DSSPDV.Rows[i].ItemArray[0].ToString();
                listItems[i].Title = DSSPDV.Rows[i].ItemArray[1].ToString();
                listItems[i].GiaTien = Convert.ToDouble(DSSPDV.Rows[i].ItemArray[2]);
                listItems[i].NumUser = Convert.ToInt32(DSSPDV.Rows[i].ItemArray[3]);
                listItems[i].Description = DSSPDV.Rows[i].ItemArray[4].ToString();
                listItems[i].Quality = DSSPDV.Rows[i].ItemArray[5].ToString();
                listItems[i].ButtonClicked += new EventHandler(UserControl_ButtonClicked);
                if (i == 0)
                    listItems[i].Icon = Resources.travel;
                if(i == 1)
                    listItems[i].Icon = Resources.airport;
                if(i == 2)
                    listItems[i].Icon = Resources.spa;
                if(i == 3)
                    listItems[i].Icon = Resources.car;

                flowLayoutPanel1.Controls.Add(listItems[i]);
            }
        }
        private int SearchDuplicate(string searchValue)
        {
            try
            {
 
                for(int i = 0; i < dtgChoosen.Rows.Count - 1; i++)
                {
                    if (dtgChoosen.Rows[i].Cells[0].Value.ToString() == searchValue)
                    {
                        return i;
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
            ListProduct selectedItem = sender as ListProduct;
            ListProduct choosenRoom = new ListProduct();
            choosenRoom.Code = selectedItem.Code;           
            choosenRoom.NumUser = Convert.ToInt32(selectedItem.UDNumeric.Value);
            choosenRoom.GiaTien = selectedItem.GiaTien * Convert.ToInt32(selectedItem.UDNumeric.Value);
            //currentData.Add(choosenRoom);
            //Check duplicate


            // MessageBox.Show(dtgChoosen.Rows.Count.ToString());
            int result = 0;
            if (dtgChoosen.Rows.Count > 1)
                result = SearchDuplicate(choosenRoom.Code);
            else
                result = -1;
            
            if (result >= 0)
            {
                double total = Convert.ToDouble(lblTotal.Text);
                total = total - Convert.ToDouble(dtgChoosen.Rows[result].Cells[2].Value) + Convert.ToDouble(choosenRoom.GiaTien);
                dtgChoosen.Rows[result].Cells[1].Value = choosenRoom.NumUser;
                dtgChoosen.Rows[result].Cells[2].Value = choosenRoom.GiaTien;
                lblTotal.Text = total.ToString();

            }
            else
            {

                lblTotal.Text = (Convert.ToDouble(lblTotal.Text) + Convert.ToDouble(choosenRoom.GiaTien)).ToString();
                dtgChoosen.Rows.Add(choosenRoom.Code, choosenRoom.NumUser, choosenRoom.GiaTien);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lưu phiếu đang ký sản phẩm dịch vụ
            PhieuDKSPDV phieuDKSPDV = new PhieuDKSPDV();
            int tongSL = 0;
            for(int i = 0; i < dtgChoosen.Rows.Count - 1; i++)
            {
                tongSL += Convert.ToInt32(dtgChoosen.Rows[i].Cells[1].Value);
            }
            phieuDKSPDV.TONGSL = tongSL;
            phieuDKSPDV.TONGTIEN = Convert.ToDouble(lblTotal.Text);

            // Thu nhận danh sách sản phẩm dịch vụ chi tiết
            List<PhieuDKSPDVCT> dKSPDVCTs = new List<PhieuDKSPDVCT>();
            for (int i = 0; i < dtgChoosen.Rows.Count - 1; i++)
            {
                PhieuDKSPDVCT phieu = new PhieuDKSPDVCT();
                phieu.MASPDV = dtgChoosen.Rows[i].Cells[0].Value.ToString();
                phieu.SOLUONG = Convert.ToInt32(dtgChoosen.Rows[i].Cells[1].Value);
                phieu.GIATIEN = Convert.ToDouble(dtgChoosen.Rows[i].Cells[2].Value);
                dKSPDVCTs.Add(phieu);
            }
            _formBooking.PhieuDKSPDV = phieuDKSPDV;
            _formBooking.DKSPDVCTs = dKSPDVCTs;
            this.Hide();
            _formBooking.Show();
            this.Close();
        }
    }
}
