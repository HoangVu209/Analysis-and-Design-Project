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
    public partial class ListProduct : UserControl
    {
        public ListProduct()
        {
            InitializeComponent();
        }

        private NumericUpDown _UDNumeric;
        public NumericUpDown UDNumeric
        {
            get { return numericUpDown1; }
            set { numericUpDown1 = value; _UDNumeric = value; }
        }

        private string _Ten;
        public string Ten
        {
            get
            {
                return _Ten;
            }
            set
            {
                _Ten = value;
                lblCode.Text = value;
            }
        }

        private double _GiaTien;
        public double GiaTien
        {
            get
            {
                return _GiaTien;
            }
            set
            {
                _GiaTien = value;
                lblPrice.Text = value.ToString();
            }
        }

        private string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                lblTitile.Text = value;
            }
        }

        private int _NumUser;
        public int NumUser
        {
            get
            {
                return _NumUser;
            }
            set
            {
                _NumUser = value;
                lblNumUsers.Text = value.ToString();
            }
        }
        private string _Code;
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                _Code = value;
                lblCode.Text = value;
            }
        }


        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
                txtDes.Text = value;
            }
        }

        private string _Quality;
        public string Quality
        {
            get
            {
                return _Quality;
            }
            set
            {
                _Quality = value;
                lblQuality.Text = value;
            }
        }

        private Image _icon;

        public Image Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                pictureBox1.Image = value;
            }
        }


        private Button _Add;
        public Button Add
        {
            get
            {
                return _Add;
            }
            set
            {
                _Add = value;
                button1 = value;
            }
        }
        // event
        public event EventHandler ButtonClicked;
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.ButtonClicked(this, EventArgs.Empty);
        }
    }
}
