using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using DevExpress.XtraPrinting;

namespace HM0905
{
    public partial class TrangChu : Form
    {
        

        string tentaikhoan = "", matkhau = "", loaitaikhoan = "";
        public TrangChu(string tentaikhoan, string matkhau, string loaitaikhoan)
        {
            InitializeComponent();
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            this.loaitaikhoan = loaitaikhoan;
        }

        private Form currentFormChild;
        private void OpenChilForm(Form chilForm)
        {
            if(currentFormChild!=null)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(currentFormChild !=null)
            {
                currentFormChild.Close();
            }    
        }

        private void btnkho_Click(object sender, EventArgs e)
        {
            if(loaitaikhoan=="Quản lý" ||loaitaikhoan== "Thủ Kho")
            {
                OpenChilForm(new FormKho());
            }    
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này", "Thông báo", MessageBoxButtons.OK);
            }    
          
        }

        private void btnsp_Click(object sender, EventArgs e)
        {
            OpenChilForm(new FormSanPham());
        }

        private void btnhd_Click(object sender, EventArgs e)
        {
            OpenChilForm(new FormHoaDon());
        }

        private void btnbaohanh_Click(object sender, EventArgs e)
        {
            if (loaitaikhoan == "Quản lý" || loaitaikhoan == "Nhân viên bán hàng")
            {
                OpenChilForm(new FormBaoHanh());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnbc_Click(object sender, EventArgs e)
        {
                
            if (loaitaikhoan == "Quản lý" || loaitaikhoan == "Thủ Kho")
            {
                OpenChilForm(new FormBaoCao());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnns_Click(object sender, EventArgs e)
        {
           
            if (loaitaikhoan == "Quản lý")
            {
                OpenChilForm(new FormNhanSu());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnkh_Click(object sender, EventArgs e)
        {
            
            if (loaitaikhoan == "Quản lý" || loaitaikhoan =="Nhân viên bán hàng")
            {
                OpenChilForm(new KhachHang());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này", "Thông báo", MessageBoxButtons.OK);
            }
        }
        public static string LoggedInMaNV { get; set; }
        public static string LoggedInTenNV { get; set; }
        public static string LoggedInChucVu { get; set; }
        public static void SetLoggedInUserInfo(string maNV, string tenNV, string chucVu)
        {
            LoggedInMaNV = maNV;
            LoggedInTenNV = tenNV;
            LoggedInChucVu = chucVu;
        }

        private void panelbody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (!string.IsNullOrEmpty(infonv.LoggedInMaNV))
            {
                // Người dùng đã đăng nhập, lấy thông tin từ SessionData
                string maNV = infonv.LoggedInMaNV;
                string tenNV = infonv.LoggedInTenNV;
                string chucVu = infonv.LoggedInChucVu;

                // Hiển thị thông tin nhân viên lên các textbox
                txtmanv.Text = maNV;
                txttennv.Text = tenNV;
                txtchucvu.Text = chucVu;
            }
            else
            {
                // Người dùng chưa đăng nhập, chuyển về trang đăng nhập
                // ...
            }

        }
        private void btndangxuat_Click(object sender, EventArgs e)
        {
            // Đóng form TrangChu
            this.Close();

            // Mở lại form Đăng nhập
            DangNhap f = new DangNhap();
            f.Show();
        }
    }
}
