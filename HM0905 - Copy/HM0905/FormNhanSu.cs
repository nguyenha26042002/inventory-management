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
    public partial class FormNhanSu : Form
    {
        public FormNhanSu()
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
        private void FormNhanSu_Load(object sender, EventArgs e)
        {

        }

        private void btnnhanvien_Click_1(object sender, EventArgs e)
        {
            OpenChilForm(new NhanVien());
        }

        private void btnchucvu_Click_1(object sender, EventArgs e)
        {
            OpenChilForm(new ChucVu());
        }

        private void btntaikhoan_Click(object sender, EventArgs e)
        {
            OpenChilForm(new TaiKhoan());
        }
    }
}
