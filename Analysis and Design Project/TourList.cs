using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analysis_and_Design_Project
{
    public partial class TourList : UserControl
    {
        public TourList()
        {
            InitializeComponent();
        }

        string _tenTour;
        public string tenTour
        {
            get { return _tenTour; }
            set { _tenTour = value; lblName.Text = value; }
        }
        public string maTour { get; set; }
      
        private int _congTy;
        public int congTy
        {
            get { return _congTy; }
            set { _congTy = value; lblCompany.Text = value.ToString(); }
        }

        double _giaTien;
        public double giaTien
        {
            get { return _giaTien; }
            set { _giaTien = value; lblPrice.Text = value.ToString(); }
        }

        string _moTa;
        public string moTa
        {
            get { return _moTa; }
            set { _moTa = value; txtDes.Text = value; }
        }
        Image _icon;
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = value; }
        }

        public event EventHandler ButtonClicked;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ButtonClicked(this, EventArgs.Empty);
        }
    }
}
