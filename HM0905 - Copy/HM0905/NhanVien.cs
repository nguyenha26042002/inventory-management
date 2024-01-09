using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HM0905
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            Functions.FillDataToCombo("SELECT MaCV,  MaCV FROM tblChucVu", cbbmacv, "MaCV", "MaCV");
            cbbmacv.SelectedIndex = -1;
            LoadData();
            ResetValues();
        }
        private void ResetValues()
        {
            txtmanv.Text = "";
            txttennv.Text = "";
            txtgioitinh.Text = "";
            txtngaysinh.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
            txttencv.Text = "";
            cbbmacv.Text = "";
        }
        private void LoadData()
        {
            string sql;
            sql = "SELECT MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, SDT, b.TenCV FROM tblNhanVien a, tblChucVu b where a.MaCV=b.MaCV";
            DataTable tblKH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dataGridViewNhanVien.DataSource = tblKH;
            for (int i = 0; i < dataGridViewNhanVien.Rows.Count; i++)
            {
                dataGridViewNhanVien.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            cbbmacv.Enabled = true;
            ResetValues();
            LoadData();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
                string maNV = txtmanv.Text;
                string tenNV = txttennv.Text;
                string gioiTinh = txtgioitinh.Text;
                string ngaySinh = txtngaysinh.Text;
                string diaChi = txtdiachi.Text;
                int sdt = int.Parse(txtsdt.Text);
                string maCV = cbbmacv.Text;

                string query = "INSERT INTO tblNhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, SDT, MaCV) " +
                               "VALUES (@MaNV, @TenNV, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @MaCV)";

                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@MaNV", maNV);
                command.Parameters.AddWithValue("@TenNV", tenNV);
                command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                command.Parameters.AddWithValue("@DiaChi", diaChi);
                command.Parameters.AddWithValue("@SDT", sdt);
                command.Parameters.AddWithValue("@MaCV", maCV);
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm nhân viên thành công.");
                LoadData();
                ResetValues();

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maNV = txtmanv.Text;
            string query = "DELETE FROM tblNhanVien WHERE MaNV = @MaNV";
            SqlCommand command = new SqlCommand(query, Functions.conn);
            command.Parameters.AddWithValue("@MaNV", maNV);
            command.ExecuteNonQuery();
            MessageBox.Show("Xóa nhân viên thành công.");
            LoadData();
            ResetValues();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtmanv.Enabled = true;
            txttennv.Enabled = true;
            txtgioitinh.Enabled = true;
            txtngaysinh.Enabled = true;
            txtdiachi.Enabled = true;
            txtsdt.Enabled = true;
            cbbmacv.Enabled = true;
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            // Tạo một ứng dụng Excel mới
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Tạo một workbook mới
            Excel.Workbook workbook = excelApp.Workbooks.Add();

            // Tạo một worksheet mới
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Đặt tên cho worksheet
            worksheet.Name = "Danh sách nhân viên";

            // Lấy dữ liệu từ DataGridView
            for (int i = 0; i < dataGridViewNhanVien.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewNhanVien.Columns.Count; j++)
                {
                    if (dataGridViewNhanVien.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 1, j + 1] = dataGridViewNhanVien.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 1, j + 1] = string.Empty;
                    }
                }
            }

            // Lưu workbook vào một tệp Excel
            workbook.SaveAs("DanhSachNhanVien.xlsx");

            // Đóng workbook và ứng dụng Excel
            //workbook.Close();
            //excelApp.Quit();
        }

        private void dataGridViewNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanv.Focus();
                return;
            }
            txtmanv.Text =dataGridViewNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            txttennv.Text = dataGridViewNhanVien.CurrentRow.Cells["TenNV"].Value.ToString();
            txtdiachi.Text = dataGridViewNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtsdt.Text = dataGridViewNhanVien.CurrentRow.Cells["SDT"].Value.ToString();
            txtgioitinh.Text = dataGridViewNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString();
            txtngaysinh.Text = dataGridViewNhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txttencv.Text = dataGridViewNhanVien.CurrentRow.Cells["TenCV"].Value.ToString();
            //cbbmacv.Text = dataGridViewNhanVien.CurrentRow.Cells["MaCV"].Value.ToString();

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string searchName = txttimkiem.Text;
                string query = "SELECT * FROM tblNhanVien WHERE TenNV LIKE '%' + @SearchName + '%'";
                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@SearchName", searchName);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewNhanVien.DataSource = dataTable;
        }
        private void cbbmacv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbmacv.Text == "")
            {
                txttencv.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenCV FROM tblChucVu WHERE MaCV =N'" + cbbmacv.SelectedValue + "'";
            txttencv.Text = Functions.GetFieldValues(str);

        }
    }
}
