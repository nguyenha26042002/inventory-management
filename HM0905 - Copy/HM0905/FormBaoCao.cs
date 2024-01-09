using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM0905
{
    public partial class FormBaoCao : Form
    {
        public FormBaoCao()
        {
            InitializeComponent();
        }

        string tentaikhoan = "", matkhau = "", loaitaikhoan = "";
        public FormBaoCao(string tentaikhoan, string matkhau, string loaitaikhoan)
        {
            InitializeComponent();
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            this.loaitaikhoan = loaitaikhoan;
        }
        private Form currentFormChild;
        private void OpenChilForm(Form chilForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = chilForm;
            chilForm.TopLevel = false;
            chilForm.FormBorderStyle = FormBorderStyle.None;
            chilForm.Dock = DockStyle.Fill;
            panelbody.Controls.Add(chilForm);
            panelbody.Tag = chilForm;
            chilForm.BringToFront();
            chilForm.Show();
        }

        private void btndshangloi_Click_1(object sender, EventArgs e)
        {
                OpenChilForm(new DanhSachHangLoi());
        }

        private void btndshangthieu_Click_1(object sender, EventArgs e)
        {
                OpenChilForm(new DanhSachHangThieu());
        }

        private void btnbkhnhaphang_Click_1(object sender, EventArgs e)
        {
                OpenChilForm(new BanKeHoachNhapHang());
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            this.Close();

            // Mở lại form Đăng nhập
            DangNhap f = new DangNhap();
            f.Show();
        }
    }
}
