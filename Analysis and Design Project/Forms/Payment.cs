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
    public partial class Payment : Form
    {
        PhieuDangKy _phieuDangKy;
        List<PhieuDangKyCT> _DSPhieuCT;
        PhieuDKSPDV _phieuDKSPDV;
        List<PhieuDKSPDVCT> _phieuDKSPDVCTs;
        PhieuDangKyTour _phieuDangKyTour;
        public Payment(PhieuDangKy phieuDangKy, List<PhieuDangKyCT> DSPhieuCT
            , PhieuDKSPDV phieuDKSPDV, List<PhieuDKSPDVCT> phieuDKSPDVCTs, PhieuDangKyTour phieuDangKyTour)
        {
            InitializeComponent();
            _phieuDangKy = phieuDangKy;            
            _DSPhieuCT = DSPhieuCT;
            _phieuDKSPDV = phieuDKSPDV;
            _phieuDKSPDVCTs = phieuDKSPDVCTs;
            _phieuDangKyTour = phieuDangKyTour;
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            LoadPhieuDK();
        }
        private void LoadPhieuDK()
        {
            txtName.Text = _phieuDangKy.TENNGUOIDK;
            txtPhone.Text = _phieuDangKy.SODT;
            lblTotal.Text = _phieuDangKy.TONGTIEN.ToString();
            lxtMoneyText.Text = NumberToWords.ConvertToWords(Convert.ToInt32(_phieuDangKy.TONGTIEN));
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            HoSoThanhToan hoSo = new HoSoThanhToan();
            hoSo.TenKhachHang = txtName.Text;
            hoSo.STK = txtCard.Text;
            hoSo.SDT = txtPhone.Text;
            hoSo.PhuongThuc = cbbMethod.SelectedText;
            hoSo.CMND = txtSocialNum.Text;
            HoSoThanhToanBLL hoSoThanhToanBLL = new HoSoThanhToanBLL();
            string result = hoSoThanhToanBLL.CheckEmptyFields(hoSo);
            if(result != "")
            {
                MessageBox.Show(result);
                return;
            }
            this.Hide();
            Invoice formInv = new Invoice(_phieuDangKy, _DSPhieuCT, hoSo, _phieuDKSPDV, _phieuDKSPDVCTs, _phieuDangKyTour);
            formInv.ShowDialog();
            this.Close();
        }
    }


    public static class NumberToWords
        {
            private static readonly string[] ones =
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
            };

            private static readonly string[] teens =
            {
                "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };

            private static readonly string[] tens =
            {
                "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
            };

            private static readonly string[] thousands =
            {
                "", "thousand", "million", "billion"
            };

            public static string ConvertToWords(int number)
            {
                if (number == 0) return ones[0];

                if (number < 0) return "minus " + ConvertToWords(Math.Abs(number));

                string words = "";

                int groupIndex = 0;
                while (number > 0)
                {
                    int group = number % 1000;
                    number /= 1000;

                    if (group > 0)
                    {
                        string groupWords = "";
                        int hundreds = group / 100;
                        int tensAndOnes = group % 100;

                        if (hundreds > 0)
                        {
                            groupWords += ones[hundreds] + " hundred ";

                            if (tensAndOnes > 0)
                                groupWords += "and ";
                        }

                        if (tensAndOnes > 0)
                        {
                            if (tensAndOnes < 10)
                                groupWords += ones[tensAndOnes];
                            else if (tensAndOnes < 20)
                                groupWords += teens[tensAndOnes - 10];
                            else
                            {
                                groupWords += tens[tensAndOnes / 10];

                                if ((tensAndOnes % 10) > 0)
                                    groupWords += "-" + ones[tensAndOnes % 10];
                            }
                        }

                        groupWords += thousands[groupIndex];
                        words = groupWords + " " + words;
                    }

                    groupIndex++;
                }

                return words.Trim();
            }
        }

}
