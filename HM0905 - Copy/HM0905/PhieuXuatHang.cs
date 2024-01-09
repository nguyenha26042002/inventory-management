using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraLayout.Filtering.Templates;
using System.Globalization;

namespace HM0905
{
    public partial class PhieuXuatHang : Form
    {
        public PhieuXuatHang()
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
        DataTable tblPXK;
        public static string connectionString = "Data Source=LAPTOP-8G5PNNNO\\SQLEXPRESS;Initial Catalog=XeMayHM10;Integrated Security=True";
        private void PhieuXuatHang_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnxoa.Enabled = true;
            btnin.Enabled = false;
            txtmaphieu.ReadOnly = true;
            txtmanv.ReadOnly = true;
            txttennv.ReadOnly = true;
            txtngaytao.ReadOnly = true;
        }
        private void LoadThongTinNhanVien()
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
            }
            else
            {
                // Người dùng chưa đăng nhập, chuyển về trang đăng nhập
                // ...
            }
        }
    
        private void LoadDataGridView()
        {
            // Lấy ngày bắt đầu và ngày kết thúc từ các textbox
            DateTime ngayBatDau = DateTime.Parse(txttimebatdau.Text);
            DateTime ngayKetThuc = DateTime.Parse(txttimeketthuc.Text);
            
            // Tạo câu lệnh SQL để truy vấn dữ liệu
            string sql = "SELECT sp.MaNH, sp.MaSP, sp.TenSP, SUM(cthdbh.SL) AS SLXuat, SUM(cthdbh.ThanhTien) AS TongTien " +
                         "FROM tblSanPham AS sp " +
                         "JOIN tblChitietHDBanHang AS cthdbh ON sp.MaSP = cthdbh.MaSP " +
                         "WHERE cthdbh.NgayBan BETWEEN @NgayBatDau AND @NgayKetThuc " +
                         "GROUP BY sp.MaNH, sp.MaSP, sp.TenSP";

            // Kết nối cơ sở dữ liệu và truy vấn dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Hiển thị dữ liệu lên DataGridView
                dataGridViewPXH.DataSource = dataTable;
                for (int i = 0; i < dataGridViewPXH.Rows.Count; i++)
                {
                    dataGridViewPXH.Rows[i].Cells["STT"].Value = i + 1;
                }

                // Tính tổng doanh thu
                decimal tongDoanhThu = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(row["TongTien"]);
                }
                txttongdoanhthu.Text = tongDoanhThu.ToString();
            }

        }
        private void ResetValues()
        {
            txtmaphieu.Text = "";
            txtngaytao.Text = DateTime.Now.ToShortDateString();
            //txtngaytao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txttimebatdau.Text = "";
            txttimeketthuc.Text = "";
        }
        private void btnloc_Click(object sender, EventArgs e)
        {
            dataGridViewPXH.DataSource = tblPXK;
            for (int i = 0; i < dataGridViewPXH.Rows.Count; i++)
            {
                dataGridViewPXH.Rows[i].Cells["STT"].Value = i + 1;
            }
            LoadDataGridView();
        }
        private int LaySoLuongXuat(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            int soLuongXuat = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(a.SL) FROM tblChitietHDBanHang a join tblSanPham b on a.MaSP = b.MaSP WHERE a.NgayBan BETWEEN @NgayBatDau AND @NgayKetThuc AND b.MaNH = @MaNhomHang";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);

                connection.Open();

                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    soLuongXuat = Convert.ToInt32(result);
                }

                connection.Close();
            }

            return soLuongXuat;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmaphieu.Text = Functions.CreateKey("PXK");
            LoadThongTinNhanVien();
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttimebatdau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimebatdau.Focus();
                return;
            }
            if (txttimeketthuc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimeketthuc.Focus();
                return;
            }

            // Chèn dữ liệu phiếu xuất hàng
            sql = "INSERT INTO tblPhieuXuatHang (MaPhieuXuatHang, MaNV, NgayTao, TimeBatDau, TimeKetThuc, TongDoanhThu) " +
                "VALUES(N'" + txtmaphieu.Text.Trim() + "', N'" + txtmanv.Text.Trim() + "', '" + txtngaytao.Text + "', '" + txttimebatdau.Text + "', '" + txttimeketthuc.Text + "', '" + txttongdoanhthu.Text + "')";
            Functions.RunSql(sql);


            // Chèn dữ liệu chi tiết phiếu xuất hàng từ DataGridView
            for (int i = 0; i < dataGridViewPXH.Rows.Count; i++)
            {
                if (dataGridViewPXH.Rows[i].Cells["MaNH"].Value != null)
                {
                    string maNH1 = dataGridViewPXH.Rows[i].Cells["MaNH"].Value.ToString();
                    // Tiếp tục xử lý mã nhóm hàng
                }
                else
                {
                    MessageBox.Show("Lưu thành công", "Thông báo");
                    return;
                }

                string maNH = dataGridViewPXH.Rows[i].Cells["MaNH"].Value.ToString();
                string maSP = dataGridViewPXH.Rows[i].Cells["MaSP"].Value.ToString();
                string slXuat = dataGridViewPXH.Rows[i].Cells["SLXuat"].Value.ToString();
                string tongTien = dataGridViewPXH.Rows[i].Cells["TongTien"].Value.ToString();



                sql = "INSERT INTO tblChitietPhieuXuatHang (MaPhieuXuatHang, MaNH, MaSP, SLXuat, TongTien) " +
                    "VALUES(N'" + txtmaphieu.Text.Trim() + "', N'" + maNH + "', N'" + maSP + "', '" + slXuat + "', '" + tongTien + "')";
                Functions.RunSql(sql);
            }

            LoadDataGridView();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnin.Enabled = true;
            txtmaphieu.Enabled = false;
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmaphieu.Text))
            {
                MessageBox.Show("Bạn chưa chọn phiếu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xoá phiếu xuất hàng này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maPhieuXuatHang = txtmaphieu.Text.Trim();

                // Xóa phiếu xuất hàng từ cơ sở dữ liệu
                string sqlDeletePhieuXuatHang = "DELETE FROM tblPhieuXuatHang WHERE MaPhieuXuatHang = @MaPhieuXuatHang";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlDeletePhieuXuatHang, connection);
                    command.Parameters.AddWithValue("@MaPhieuXuatHang", maPhieuXuatHang);
                    command.ExecuteNonQuery();
                }

                // Xóa chi tiết phiếu xuất hàng từ cơ sở dữ liệu
                string sqlDeleteChiTietPhieuXuatHang = "DELETE FROM tblChitietPhieuXuatHang WHERE MaPhieuXuatHang = @MaPhieuXuatHang";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlDeleteChiTietPhieuXuatHang, connection);
                    command.Parameters.AddWithValue("@MaPhieuXuatHang", maPhieuXuatHang);
                    command.ExecuteNonQuery();
                }

                // Hiển thị thông báo và làm mới form
                MessageBox.Show("Xoá phiếu xuất hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValues();
                OpenChilForm(new PhieuXuatHang());
            }

        }

        private void btnin_Click(object sender, EventArgs e)
        {

        }
    }
}
