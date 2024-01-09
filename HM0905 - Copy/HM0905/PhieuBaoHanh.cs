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
namespace HM0905
{
    public partial class PhieuBaoHanh : Form
    {
        DataTable tblPBH;
        public PhieuBaoHanh()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void PhieuBaoHanh_Load(object sender, EventArgs e)
        {
            txtmaphieu.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            btnin.Enabled = false;
            txtngaynhap.ReadOnly = true;
            //txtngaynhap.Text = DateTime.Now.ToShortDateString();
            Functions.FillDataToCombo("SELECT MaKH, TenKH FROM tblKhachHang", cbbmakh, "MaKH", "MaKH");
            cbbmakh.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaKH, DiaChi FROM tblKhachHang", cbbmakh, "MaKH", "MaKH");
            cbbmakh.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaKH, SDT FROM tblKhachHang", cbbmakh, "MaKH", "MaKH");
            cbbmakh.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaSP, TenSP FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
           LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaPhieuBaoHanh,d.MaKH,TenKH,DiaChi,SDT,c.MaSP,TenSP,ThoiHanBH,NgayNhap from tblPhieuBaoHanh a join tblChitietPhieuBaoHanh b on \r\na.MaPhieuBaoHanh=b.MaPhieuBaoHanh join tblSanPham c on b.MaSP=c.MaSP join tblKhachHang d on a.MaKH=d.MaKH";
            //DataTable data = new DataTable();
            //Functions.OpenConnection();
            tblPBH = Functions.GetDataToTable(sql);
            dataGridViewDMBaoHanh.DataSource = tblPBH;
            for (int i = 0; i < dataGridViewDMBaoHanh.Rows.Count; i++)
            {
                dataGridViewDMBaoHanh.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void cbbmakh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbmakh.Text == "")
            {
                txttenkh.Text = "";
                txtdiachi.Text = "";
                txtsdt.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select TenKH from tblKhachHang where MaKH = N'" + cbbmakh.SelectedValue + "'";
            txttenkh.Text = Functions.GetFieldValues(str);
            str = "Select DiaChi from tblKhachHang where MaKH = N'" + cbbmakh.SelectedValue + "'";
            txtdiachi.Text = Functions.GetFieldValues(str);
            str = "Select SDT from tblKhachHang where MaKH= N'" + cbbmakh.SelectedValue + "'";
            txtsdt.Text = Functions.GetFieldValues(str);
        }

        private void cbbmasp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbmasp.Text == "")
            {
                txttensp.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenSP FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txttensp.Text = Functions.GetFieldValues(str);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmaphieu.Text = Functions.CreateKey("PBH");
            // txtmakh.Enabled = false;
            //txtmakh.Focus();
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtmaphieu.Text = "";
            txtngaynhap.Text = DateTime.Now.ToShortDateString();
            cbbmakh.Text = "";
            txttenkh.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
            cbbmasp.Text = "";
            txttensp.Text = "";
            txttimebh.Text = "";
        }

        private void dataGridViewDMBaoHanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphieu.Focus();
                return;
            }
            txtmaphieu.Text = dataGridViewDMBaoHanh.CurrentRow.Cells["MaPhieuBaoHanh"].Value.ToString();
            txtngaynhap.Text = dataGridViewDMBaoHanh.CurrentRow.Cells["TenKH"].Value.ToString();
            cbbmakh.Text = dataGridViewDMBaoHanh.CurrentRow.Cells["MaKH"].Value.ToString();
            txttenkh.Text = dataGridViewDMBaoHanh.CurrentRow.Cells["TenKH"].Value.ToString();
            txtdiachi.Text = dataGridViewDMBaoHanh.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtsdt.Text = dataGridViewDMBaoHanh.CurrentRow.Cells["SDT"].Value.ToString();
            cbbmasp.Text = dataGridViewDMBaoHanh.CurrentRow.Cells["MaSP"].Value.ToString();
            txttensp.Text = dataGridViewDMBaoHanh.CurrentRow.Cells["TenSP"].Value.ToString();
            txttimebh.Text = dataGridViewDMBaoHanh.CurrentRow.Cells["ThoiHanBH"].Value.ToString();
            LoadDataGridView();
            btnin.Enabled = true;
            //ResetValues();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaPhieuBaoHanh FROM tblPhieuBaoHanh WHERE MaPhieuBaoHanh=N'" + txtmaphieu.Text + "'";
            if (cbbmakh.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbmakh.Focus();
                return;
            }
            if (cbbmakh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbmakh.Focus();
                return;
            }
            if (cbbmasp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbmasp.Focus();
                return;
            }
            if (txttimebh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thời hạn bảo hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimebh.Focus();
                return;
            }
            sql = "INSERT INTO tblPhieuBaoHanh (MaPhieuBaoHanh,NgayNhap,MaKH) VALUES(N'"
                + txtmaphieu.Text.Trim() + "',N'" + txtngaynhap.Text.Trim() +
                "',N'" + cbbmakh.SelectedValue.ToString() + "')";
            Functions.RunSql(sql);
            sql = "INSERT INTO tblChitietPhieuBaoHanh (MaPhieuBaoHanh,MaSP,ThoiHanBH) VALUES(N'" + txtmaphieu.Text.Trim() + "',N'" + cbbmasp.SelectedValue.ToString() + "',N'" + txttimebh.Text.Trim() + "')";
            Functions.RunSql(sql);
            LoadDataGridView();
            //ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            txtmaphieu.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblPBH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaphieu.Text == "")
            {
                MessageBox.Show("Bạn phải chọn phiếu cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbbmakh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbmakh.Focus();
                return;
            }
            if (cbbmasp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbmasp.Focus();
                return;
            }
            if (txttimebh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thời hạn bảo hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimebh.Focus();
                return;
            }
            sql = "UPDATE tblPhieuBaoHanh SET MaKH=N'" + cbbmakh.SelectedValue.ToString() + "' WHERE MaPhieuBaoHanh=N'" + txtmaphieu.Text + "'";
            Functions.RunSql(sql);
            sql = "Update tblChitietPhieuBaoHanh set MaSP=N'" + cbbmasp.SelectedValue.ToString() + "',ThoiHanBH=N'" + txttimebh.Text.ToString() + "'WHERE MaPhieuBaoHanh=N'" + txtmaphieu.Text + "'";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();
            btnhuy.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblPBH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaphieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn phiếu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá phiếu bảo hành này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblPhieuBaoHanh WHERE MaPhieuBaoHanh=N'" + txtmaphieu.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmaphieu.Enabled = false;
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinDS;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            // Định dạng font chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["B1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["B1:F3"].Font.Size = 10;
            exRange.Range["B1:F3"].Font.Bold = true;
            exRange.Range["B1:F3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;

            // Vẽ tiêu đề và thông tin công ty
            exRange.Range["B1:F1"].MergeCells = true;
            exRange.Range["B1:F1"].Style.Font.Size = 12;
            exRange.Range["B1:F1"].Style.Font.Bold = true;
            exRange.Range["B1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B1:F1"].Value = "CÔNG TY TNHH THƯƠNG MẠI VÀ DỊCH VỤ HÙNG MẠNH";

            exRange.Range["B2:F2"].MergeCells = true;
            exRange.Range["B2:F2"].Style.Font.Size = 10;
            exRange.Range["B2:F2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B2:F2"].Value = "Số 21 đường Chu Văn Thịnh, tổ 1, Phường Tô Hiệu, TP. Sơn La, Sơn La";

            exRange.Range["B3:F3"].MergeCells = true;
            exRange.Range["B3:F3"].Style.Font.Size = 10;
            exRange.Range["B3:F3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B3:F3"].Value = "Điện thoại: 0212 3855 488";

            exRange.Range["C4:E4"].Font.Size = 16;
            exRange.Range["C4:E4"].Font.Bold = true;
            exRange.Range["C4:E4"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C4:E4"].MergeCells = true;
            exRange.Range["C4:E4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C4:E4"].Value = "PHIẾU BẢO HÀNH";
            // thông tin chung
            sql = "SELECT a.MaPhieuBaoHanh, b.TenKH,  b.DiaChi, b.SDT,b.Email, d.TenSP, a.NgayNhap,c.ThoiHanBH " +
                  "FROM tblPhieuBaoHanh AS a " +
                  "JOIN tblKhachHang AS b ON a.MaKH = b.MaKH " +
                  "JOIN tblChiTietPhieuBaoHanh AS c ON a.MaPhieuBaoHanh = c.MaPhieuBaoHanh " +
                  " join tblSanPham d on c.MaSP=d.MaSP WHERE a.MaPhieuBaoHanh = N'" + txtmaphieu.Text + "'";
            tblThongtinDS = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã phiếu: ";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinDS.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Tên khách hàng: ";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinDS.Rows[0][1].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ: ";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinDS.Rows[0][2].ToString();
            exRange.Range["B9:B9"].Value = " Số Điện thoại: ";
            exRange.Range["C9:D9"].MergeCells = true;
            exRange.Range["C9:D9"].Value = tblThongtinDS.Rows[0][3].ToString();
            exRange.Range["E9:E9"].Value = " Email: ";
            exRange.Range["F9:H9"].MergeCells = true;
            exRange.Range["F9:H9"].Value = tblThongtinDS.Rows[0][4].ToString();
            exRange.Range["B10:B10"].Value = " Tên sản phẩm: ";
            exRange.Range["C10:D10"].MergeCells = true;
            exRange.Range["C10:D10"].Value = tblThongtinDS.Rows[0][5].ToString();
            exRange.Range["E10:E10"].Value = " Ngày mua: ";
            exRange.Range["F10:G10"].MergeCells = true;
            exRange.Range["F10:G10"].Value = tblThongtinDS.Rows[0][6].ToString();
            exRange.Range["B11:B11"].Value = " Thời hạn bảo hành: ";
            exRange.Range["C11:E11"].MergeCells = true;
            exRange.Range["C11:E11"].Value = tblThongtinDS.Rows[0][7].ToString();
            exApp.Visible = true;
            btnin.Enabled = true;
            btnhuy.Enabled = true;
        }
    }
}
