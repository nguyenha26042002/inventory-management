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
using System.Data.Sql;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace HM0905
{
    public partial class PhieuKiemHang : Form
    {
        public PhieuKiemHang()
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
        DataTable tblPKH;
        public static string connectionString = "Data Source=LAPTOP-8G5PNNNO\\SQLEXPRESS;Initial Catalog=XeMayHM10;Integrated Security=True";

        private void PhieuKiemHang_Load(object sender, EventArgs e)
        {
            txtmaphieu.ReadOnly = true;
            txtngaykiem.ReadOnly = true;
            txtluongnhap.ReadOnly = true;
            txtluongxuat.ReadOnly = true;
            txtluonton.ReadOnly = true;
            txtmanv.ReadOnly = true;
            txttennv.ReadOnly = true;
            btnluu.Enabled = false;
            btnxoa.Enabled = false;
            btnin.Enabled = false;
            Functions.FillDataToCombo("SELECT MaNH, TenNH FROM tblNhomHang", cbbnhomhang, "MaNH", "MaNH");
            cbbnhomhang.SelectedIndex = -1;
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
                DateTime ngayBatDau = DateTime.Parse(txttimebatdau.Text);
                DateTime ngayKetThuc = DateTime.Parse(txttimeketthuc.Text);
                string maNhomHang = cbbnhomhang.Text;

                string sql = "SELECT sp.MaSP, sp.TenSP, sp.MaNH, " +
                             "ISNULL(cpn.SLNhap, 0) AS SLNhap, " +
                             "ISNULL(cthdb.SLXuat, 0) AS SLXuat, " +
                             "(ISNULL(cpn.SLNhap, 0) - ISNULL(cthdb.SLXuat, 0)) AS SLTon " +
                             "FROM tblSanPham sp " +
                             "LEFT JOIN " +
                             "(SELECT MaSP, SUM(SLNhap) AS SLNhap FROM tblChitietPhieuNhapHang WHERE NgayNhap BETWEEN @NgayBatDau AND @NgayKetThuc GROUP BY MaSP) cpn " +
                             "ON sp.MaSP = cpn.MaSP " +
                             "LEFT JOIN " +
                             "(SELECT MaSP, SUM(SL) AS SLXuat FROM tblChitietHDBanHang WHERE NgayBan BETWEEN @NgayBatDau AND @NgayKetThuc GROUP BY MaSP) cthdb " +
                             "ON sp.MaSP = cthdb.MaSP " +
                             "WHERE sp.MaNH = @MaNhomHang";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                    command.Parameters.AddWithValue("@MaNhomHang", maNhomHang);

                    connection.Open();

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    dataGridViewPhieuKiemHang.DataSource = dataTable;
                    for (int i = 0; i < dataGridViewPhieuKiemHang.Rows.Count; i++)
                    {
                        dataGridViewPhieuKiemHang.Rows[i].Cells[0].Value = i + 1;
                    }
                    connection.Close();
                }
                btnluu.Enabled = true;
        }
        private void ResetValues()
        {
            txtmaphieu.Text = "";
            //txtngaykiem.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtngaykiem.Text = DateTime.Now.ToShortDateString();
            cbbnhomhang.Text = "";
            txttimebatdau.Text = "";
            txttimeketthuc.Text = "";
            txtluongnhap.Text = "";
            txtluongxuat.Text = "";
            txtluonton.Text = "";
        }
        private void btnloc_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = DateTime.Parse(txttimebatdau.Text);
            DateTime ngayKetThuc = DateTime.Parse(txttimeketthuc.Text);
            //DateTime ngayBatDau = DateTime.ParseExact(txttimebatdau.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime ngayKetThuc = DateTime.ParseExact(txttimeketthuc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string maNhomHang = cbbnhomhang.Text;

            // Lấy dữ liệu số lượng nhập, số lượng xuất, số lượng tồn từ cơ sở dữ liệu
            int soLuongNhap = LaySoLuongNhap(ngayBatDau, ngayKetThuc, maNhomHang);
            int soLuongXuat = LaySoLuongXuat(ngayBatDau, ngayKetThuc, maNhomHang);
            int soLuongTon = soLuongNhap - soLuongXuat;

            // Hiển thị dữ liệu trên các textbox
            txtluongnhap.Text = soLuongNhap.ToString();
            txtluongxuat.Text = soLuongXuat.ToString();
            txtluonton.Text = soLuongTon.ToString();
            LoadDataGridView();

        }
        private int LaySoLuongNhap(DateTime ngayBatDau, DateTime ngayKetThuc, string maNhomHang)
        {
            int soLuongNhap = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(a.SLNhap) FROM tblChitietPhieuNhapHang a JOIN tblSanPham b ON a.MaSP = b.MaSP WHERE a.NgayNhap BETWEEN @NgayBatDau AND @NgayKetThuc AND b.MaNH = @MaNhomHang";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                command.Parameters.AddWithValue("@MaNhomHang", maNhomHang);

                connection.Open();

                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    soLuongNhap = Convert.ToInt32(result);
                }

                connection.Close();
            }

            return soLuongNhap;
        }
        private int LaySoLuongXuat(DateTime ngayBatDau, DateTime ngayKetThuc, string maNhomHang)
        {
            int soLuongXuat = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(a.SL) FROM tblChitietHDBanHang a join tblSanPham b on a.MaSP = b.MaSP WHERE a.NgayBan BETWEEN @NgayBatDau AND @NgayKetThuc AND b.MaNH = @MaNhomHang";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                command.Parameters.AddWithValue("@MaNhomHang", maNhomHang);

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
            txtmaphieu.Text = Functions.CreateKey("PKH");
            //LoadDataGridView();
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
            if (cbbnhomhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chịn nhóm hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbnhomhang.Focus();
                return;
            }

            //Chèn dữ liệu
            sql = "select * from tblPhieuKiemHang where MaPhieuKiemHang=N'" + txtmaphieu.Text.Trim() + "'";
            DataTable dt = new DataTable();
            dt = Functions.GetDataToTable(sql);
            if (dt.Rows.Count > 0)
            {
                sql = "INSERT INTO tblChitietPhieuKiemHang (MaPhieuKiemHang,MaNH,MaSP,SLNhap, SLXuat, SlTon) " +
                   "VALUES(N'" + txtmaphieu.Text.Trim() + "',N'" + cbbnhomhang.SelectedValue.ToString() + "',N'" + dataGridViewPhieuKiemHang.CurrentRow.Cells["MaSP"].Value.ToString() + "','" + txtluongnhap.Text.Trim() + "', '" + txtluongxuat.Text.Trim() + "', '" + txtluonton.Text.Trim() + "')";
                Functions.RunSql(sql);
            }
            else
            {
                sql = "INSERT INTO tblPhieuKiemHang (MaPhieuKiemHang,MaNV,NgayNhap,TimeBatDau, TimeKetThuc) " +
                "VALUES(N'" + txtmaphieu.Text.Trim() + "',N'" + txtmanv.Text.Trim() + "','" + txtngaykiem.Text + "', '" + txttimebatdau.Text + "', '" + txttimeketthuc.Text + "')";
                Functions.RunSql(sql);

                sql = "INSERT INTO tblChitietPhieuKiemHang (MaPhieuKiemHang,MaNH,MaSP,SLNhap, SLXuat, SlTon) " +
                   "VALUES(N'" + txtmaphieu.Text.Trim() + "',N'" + cbbnhomhang.SelectedValue.ToString() + "',N'" + dataGridViewPhieuKiemHang.CurrentRow.Cells["MaSP"].Value.ToString() + "','" + txtluongnhap.Text.Trim() + "', '" + txtluongxuat.Text.Trim() + "', '" + txtluonton.Text.Trim() + "')";
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
                string maPhieuKiemHang = txtmaphieu.Text.Trim();

                // Xóa phiếu xuất hàng từ cơ sở dữ liệu
                string sqlDeletePhieuXuatHang = "DELETE FROM tblPhieuKiemHang WHERE MaPhieuKiemHang = @MaPhieuKiemHang";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlDeletePhieuXuatHang, connection);
                    command.Parameters.AddWithValue("@MaPhieuKiemHang", maPhieuKiemHang);
                    command.ExecuteNonQuery();
                }

                // Xóa chi tiết phiếu xuất hàng từ cơ sở dữ liệu
                string sqlDeleteChiTietPhieuXuatHang = "DELETE FROM tblChitietPhieuKiemHang WHERE MaPhieuKiemHang = @MaPhieuKiemHang";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlDeleteChiTietPhieuXuatHang, connection);
                    command.Parameters.AddWithValue("@MaPhieuKiemHang", maPhieuKiemHang);
                    command.ExecuteNonQuery();
                }

                // Hiển thị thông báo và làm mới form
                MessageBox.Show("Xoá phiếu kiểm hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValues();
                OpenChilForm(new PhieuKiemHang());
            }
        }
        private void btnin_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            // Định dạng font chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:E3"].Font.Size = 10;
            exRange.Range["A1:E3"].Font.Bold = true;
            exRange.Range["A1:E3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;

            // Vẽ tiêu đề và thông tin công ty
            exRange.Range["A1:E1"].MergeCells = true;
            exRange.Range["A1:E1"].Style.Font.Size = 12;
            exRange.Range["A1:E1"].Style.Font.Bold = true;
            exRange.Range["A1:E1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:E1"].Value = "CÔNG TY TINH THƯƠNG MẠI VÀ DỊCH VỤ HÙNG MẠNH";

            exRange.Range["A2:E2"].MergeCells = true;
            exRange.Range["A2:E2"].Style.Font.Size = 10;
            exRange.Range["A2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:E2"].Value = "Số 21 đường Chu Văn Thịnh, tổ 1, Phường Tô Hiệu, TP. Sơn La, Sơn La";

            exRange.Range["A3:E3"].MergeCells = true;
            exRange.Range["A3:E3"].Style.Font.Size = 10;
            exRange.Range["A3:E3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:E3"].Value = "Điện thoại: 0222210318 091257";

            exRange.Range["C4:E4"].Font.Size = 16;
            exRange.Range["C4:E4"].Font.Bold = true;
            exRange.Range["C4:E4"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C4:E4"].MergeCells = true;
            exRange.Range["C4:E4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C4:E4"].Value = "PHIẾU KIỂM HÀNG";

            // Biểu diễn thông tin chung của phiếu nhập hàng
            sql = "SELECT a.MaPhieuKiemHang, a.NgayNhap, a.TimeBatDau, a.TimeKetThuc, c.MaNV, c.TenNV " +
      "FROM tblPhieuKiemHang AS a JOIN tblNhanVien AS c ON a.MaNV = c.MaNV " +
      "WHERE a.MaPhieuKiemHang = N'" + txtmaphieu.Text + "'";
            tblThongtinHD = Functions.GetDataToTable(sql);

            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã phiếu:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();

            exRange.Range["B7:B7"].Value = "Ngày kiểm:";
            exRange.Range["C7:D7"].MergeCells = true;
            exRange.Range["C7:D7"].Value = tblThongtinHD.Rows[0]["NgayNhap"].ToString();

            exRange.Range["B8:B8"].Value = "Ngày bắt dầu:";
            exRange.Range["C8:D8"].MergeCells = true;
            exRange.Range["C8:D8"].Value = tblThongtinHD.Rows[0]["TimeBatDau"].ToString();

            exRange.Range["B9:B9"].Value = "Ngày kết thúc:";
            exRange.Range["C9:D9"].MergeCells = true;
            exRange.Range["C9:D9"].Value = tblThongtinHD.Rows[0]["TimeKetThuc"].ToString();

            exRange.Range["B10:B10"].Value = "Mã Người Kiểm:";
            exRange.Range["C10:D10"].MergeCells = true;
            exRange.Range["C10:D10"].Value = tblThongtinHD.Rows[0]["MaNV"].ToString();

            exRange.Range["B11:B11"].Value = "Tên Người Kiểm:";
            exRange.Range["C11:D11"].MergeCells = true;
            exRange.Range["C11:D11"].Value = tblThongtinHD.Rows[0]["TenNV"].ToString();

            // Tạo bảng danh sách sản phẩm

            sql = "SELECT a. MaNH, b.MaSP , b.TenSP, a.SLNhap, a.SlXuat, a.SLTon " +
              "FROM tblChitietPhieuKiemHang AS a , tblSanPham AS b WHERE a.MaPhieuKiemHang = N'" +
              txtmaphieu.Text + "' AND a.MaSP = b.MaSP";
            tblThongtinHang = Functions.GetDataToTable(sql);

            // Vẽ tiêu đề bảng danh sách sản phẩm
            exRange.Range["A13:H13"].Font.Bold = true;
            exRange.Range["A13:H13"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C13:H13"].ColumnWidth = 12;
            exRange.Range["A13: A13"].Value = "STT";
            exRange.Range["B13: B13"].Value = "Mã nhóm hàng";
            exRange.Range["C13: C13"].Value = "Mã sản phẩm";
            //exRange.Range["C11: C11"].ColumnWidth = 20;
            exRange.Range["D13: D13"].Value = "Tên sản phẩm";
            exRange.Range["E13: E13"].Value = "Số lượng nhập";
            exRange.Range["F13: F13"].Value = "Số lượng xuất";
            exRange.Range["G13: G13"].Value = "Số lượng tồn";
            //exRange.Range["H11: H11"].Value = "Thành tiền";

            // Điền thông tin sản phẩm
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 14] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 14] = tblThongtinHang.Rows[hang][cot].ToString();
                   // if (cot == 4) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            //exRange = exSheet.Cells[cot][hang + 14];
            //exRange.Font.Bold = true;
            //exRange.Value2 = "Tổng tiền:";
            //exRange = exSheet.Cells[cot + 1][hang + 14];
            //exRange.Font.Bold = true;

            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 17]; //Ô A1 
            exRange.Range["A1:H1"].MergeCells = true;
            exRange.Range["A1:H1"].Font.Bold = true;
            exRange.Range["A1:H1"].Font.Italic = true;
            exRange.Range["A1:H1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            // exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());

            exRange = exSheet.Cells[1][hang + 17]; //Ô A1 

            exRange.Range["E1:G1"].MergeCells = true;
            exRange.Range["E1:G1"].Font.Italic = true;
            exRange.Range["E1:G1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["E1:G1"].Value = "Sơn La, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

            exRange.Range["E2:G2"].MergeCells = true;
            exRange.Range["E2:G2"].Font.Italic = true;
            exRange.Range["E2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E2:G2"].Value = "Người lập phiếu";

            exRange.Range["E6:G6"].MergeCells = true;
            exRange.Range["E6:G6"].Font.Italic = true;
            exRange.Range["E6:G6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E6:G6"].Value = tblThongtinHD.Rows[0]["TenNV"];
            // exSheet.Name = "Phiếu Nhập Hàng";

            exApp.Visible = true;

        }
    }
}
