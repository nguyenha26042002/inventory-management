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
    public partial class FormBaoHanh : Form
    {
        public FormBaoHanh()
        {
            InitializeComponent();
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
       

        private void btnphieubaohanh_Click_1(object sender, EventArgs e)
        {
            OpenChilForm(new PhieuBaoHanh());
        }

        private void btndmbaohanh_Click_1(object sender, EventArgs e)
        {
            OpenChilForm(new DanhMucBaoHanh());
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
