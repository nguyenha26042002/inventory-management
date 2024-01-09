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
    public partial class FormSanPham : Form
    {
        public FormSanPham()
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
        private void FormSanPham_Load(object sender, EventArgs e)
        {

        }

        private void btndssp_Click_1(object sender, EventArgs e)
        {
            OpenChilForm(new SanPham());
        }

        private void btnnhomhang_Click_1(object sender, EventArgs e)
        {
            OpenChilForm(new NhomHang());
        }

        private void btnmodel_Click_1(object sender, EventArgs e)
        {
            OpenChilForm(new Model());
        }

        private void btncolor_Click_1(object sender, EventArgs e)
        {
            OpenChilForm(new Color());
        }
    }
}
