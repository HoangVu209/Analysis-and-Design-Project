using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; 
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Analysis_and_Design_Project
{
    public partial class ListRooms : UserControl
    {

/*
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
      );*/
        public ListRooms()
        {
            InitializeComponent();

            //Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height,10, 10));
        }
        Color oldColor;
        // Khai báo thuộc tính
        #region Properties
        [Category("Custom Props")]
        private string _loaiPhong;
        public string LoaiPhong
        {
            get
            {
                return _loaiPhong;
            }
            set
            {
                _loaiPhong = value;
                lblLoaiPhong.Text = value;
            }
        }

        [Category("Custom Props")]
        private int _soGiuong;
        public int SoGiuong
        {
            get { return _soGiuong; }
            set
            {
                _soGiuong = value;
                lblsoGiuong.Text = value.ToString();
            }
        }

        [Category("Custom Props")]

        private double _giaTien;
        public double GiaTien
        {
            get { return _giaTien; }
            set
            {
                _giaTien = value;
                lblgiaTien.Text = value.ToString();
            }
        }


        [Category("Custom Props")]
        private Image _icon;
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = value; }
        }

        private NumericUpDown _numericUpDown;
        public NumericUpDown numericUpDown
        {
            get { return duNum; }
            set { _numericUpDown = value; duNum = value; }
        }

        public void setUPColor()
        {
            duNum.BackColor = this.BackColor;
            btnAdd.BackColor = this.BackColor;
        }

        #endregion

        private void ListRooms_MouseEnter(object sender, EventArgs e)
        {
            oldColor = this.BackColor;
            duNum.BackColor = Color.Silver;
            btnAdd.BackColor = Color.Silver;
            this.BackColor = Color.Silver;
        }

        private void ListRooms_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = oldColor;
            duNum.BackColor = oldColor;
            btnAdd.BackColor = oldColor;
        }
        public event EventHandler ButtonClicked;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ButtonClicked(this, EventArgs.Empty);
        }

        // event
       
    }
}
