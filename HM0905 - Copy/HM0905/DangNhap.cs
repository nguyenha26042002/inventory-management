using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM0905
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        PhanQuyen con = new PhanQuyen();
        public static SqlConnection Conn;
        private void DangNhap_Load(object sender, EventArgs e)
        {
            Functions.OpenConnection();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string LoggedInMaNV { get; private set; }
        public static string LoggedInTenNV { get; private set; }
        public static string LoggedInChucVu { get; private set; }
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            //string sql = "Select * From tblTaiKhoan where TenTaiKhoan='" + txttaikhoan.Text + "' and MatKhau='" + txtmatkhau.Text + "'";
            string sql = "SELECT tk.*, nv.MaNV, nv.TenNV, nv.MaCV " +
             "FROM tblTaiKhoan AS tk " +
             "JOIN tblNhanVien AS nv ON tk.MaNV = nv.MaNV " +
             "WHERE tk.TenTaiKhoan = '" + txttaikhoan.Text + "' AND tk.MatKhau = '" + txtmatkhau.Text + "'";

            DataTable dt = new DataTable();
            dt = con.GetData(sql);
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Đăng nhập thành công", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Lấy thông tin nhân viên từ kết quả truy vấn
                string maNV = dt.Rows[0]["MANV"].ToString();
                string tenNV = dt.Rows[0]["TenNV"].ToString();
                string chucVu = dt.Rows[0]["LoaitaiKhoan"].ToString();

                // Gán thông tin đăng nhập vào SessionData
                infonv.LoggedInMaNV = maNV;
                infonv.LoggedInTenNV = tenNV;
                infonv.LoggedInChucVu = chucVu;

                TrangChu f = new TrangChu(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                this.Hide();
                f.ShowDialog();
                this.Show();

                TrangChu.SetLoggedInUserInfo(maNV, tenNV, chucVu);
                // Gán giá trị cho biến
                LoggedInMaNV = maNV;
                LoggedInTenNV = tenNV;
                LoggedInChucVu = chucVu;
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnhienthimatkhau_Click(object sender, EventArgs e)
        {
            if (txtmatkhau.PasswordChar == '*')
            {
                txtmatkhau.PasswordChar = '\0'; // Hiển thị dạng ban đầu (plain text)
            }
            else
            {
                txtmatkhau.PasswordChar = '*'; // Hiển thị dạng "*"
            }
        }
    }
    
}

