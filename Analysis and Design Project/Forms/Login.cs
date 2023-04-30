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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;  
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
            taiKhoan.TenTaiKhoan = textBox1.Text;
            taiKhoan.MatKhau = textBox2.Text;

            string result = taiKhoanBLL.checkLogin(taiKhoan);
            switch(result)
            {
                case "req_taikhoan":
                    MessageBox.Show("Tài khoản không được để trống!");
                    return;

                case "req_matkhau":
                    MessageBox.Show("Mật khẩu không được để trống!");
                    return;

                case "invalid":
                    MessageBox.Show("Tài khoản không tồn tại hoặc mật khẩu không đúng!");
                    return;

            }
            try
            {
                this.Hide();
                Booking form = new Booking();
                form.ShowDialog();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
