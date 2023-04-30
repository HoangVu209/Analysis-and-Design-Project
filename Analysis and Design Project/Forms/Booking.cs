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

        //Event
        private void UserControl_ButtonClicked(object sender, EventArgs e)
        {
            // Do something in response to the button click
            ListRooms selectedItem = sender as ListRooms;
            ListRooms choosenRoom = new ListRooms();
            choosenRoom.LoaiPhong = selectedItem.LoaiPhong;
            choosenRoom.SoGiuong = Convert.ToInt32(selectedItem.numericUpDown.Value);
            choosenRoom.GiaTien = selectedItem.GiaTien * Convert.ToInt32(selectedItem.numericUpDown.Value);
            //currentData.Add(choosenRoom);
            
            dtgChoosen.Rows.Add(null,choosenRoom.LoaiPhong, choosenRoom.SoGiuong, choosenRoom.GiaTien);
            

        }

        private void dtgChoosen_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dtgChoosen.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        //private List<ListRooms> currentData;
    }
}
