﻿using System;
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
    public partial class BanKeHoachNhapHang : Form
    {
        DataTable tblBKHNH;
        public BanKeHoachNhapHang()
        {
            InitializeComponent();
        }
        private void BanKeHoachNhapHang_Load(object sender, EventArgs e)
        {
            txtmaphieu.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            btnin.Enabled = false;
            txtngaynhap.ReadOnly = true;
            txtmanv.ReadOnly = true;
            txttennv.ReadOnly = true;
            Functions.FillDataToCombo("SELECT MaSP, TenSP FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            LoadDataGridView();
            ResetValues();
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
            string sql;
            sql = "select b.MaSP, TenSP, b.SLDat,b.GhiChu from tblSanPham a join tblChiTietBKHNhapHang b on a.MaSP=b.MaSP where MaBKHNhapHang=N'" + txtmaphieu.Text + "'";
            // DataTable data = new DataTable();
            //Functions.OpenConnection();
            tblBKHNH = Functions.GetDataToTable(sql);
            dataGridViewBKHNhapHang.DataSource = tblBKHNH;
            dataGridViewBKHNhapHang.AllowUserToAddRows = false;
            dataGridViewBKHNhapHang.EditMode = DataGridViewEditMode.EditProgrammatically;
            for (int i = 0; i < dataGridViewBKHNhapHang.Rows.Count; i++)
            {
                dataGridViewBKHNhapHang.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void ResetValues()
        {
            txtmaphieu.Text = "";
            txtngaynhap.Text = DateTime.Now.ToShortDateString();
            cbbmasp.Text = "";
            txttensp.Text = "";
            txtsl.Text = "";
            txtghichu.Text = "";
        }
        private void ResetValuesHang()
        {
            cbbmasp.Text = "";
            txttensp.Text = "";
            txtsl.Text = "";
            txtghichu.Text = "";
        }
        private void dataGridViewBKHNhapHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string maspxoa, sql;
            if (tblBKHNH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                maspxoa = dataGridViewBKHNhapHang.CurrentRow.Cells["MaSP"].Value.ToString();
                sql = "DELETE tblChiTietBKHNhapHang WHERE MaBKHNhapHang=N'" + txtmaphieu.Text + "' AND MaSP = N'" + maspxoa + "'";
                Functions.RunSql(sql);
                LoadDataGridView();
                MessageBox.Show("Bạn đã xóa thành công");
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            ResetValuesHang();
            txtmaphieu.Text = Functions.CreateKey("DSHL");
            LoadDataGridView();
            LoadThongTinNhanVien();
        }

        private void cbbmasp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbmasp.Text == "")
            {
                txttensp.Text = "";
            }
            str = "SELECT TenSP FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txttensp.Text = Functions.GetFieldValues(str);
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaBKHNhapHang FROM tblBKHNhapHang WHERE MaBKHNhapHang=N'" + txtmaphieu.Text + "'";
            if (!Functions.checkKeyExit(sql))
            {

                sql = "INSERT INTO tblBKHNhapHang (MaBKHNhapHang,NgayNhap,MaNV) VALUES(N'"
              + txtmaphieu.Text.Trim() + "',N'" + DateTime.Now.ToShortDateString() + "',N'" + txtmanv.Text.Trim() + "')";
                Functions.RunSql(sql);
                //LoadDataGridView();
            }
            if (cbbmasp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbmasp.Focus();
                return;
            }
            if (txtsl.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsl.Text = "";
                txtsl.Focus();
                return;
            }
            sql = "SELECT MaSP FROM tblChiTietBKHNhapHang WHERE MaSP=N'" + cbbmasp.SelectedValue + "' AND MaBKHNhapHang= N'" + txtmaphieu.Text.Trim() + "'";
            if (Functions.checkKeyExit(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn hãy chọn mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbbmasp.Focus();
                return;
            }

            sql = "INSERT INTO tblChiTietBKHNhapHang  (MaBKHNhapHang,MaSP,SLDat,GhiChu) VALUES(N'" + txtmaphieu.Text.Trim() + "',N'" + cbbmasp.SelectedValue.ToString() + "',N'" + txtsl.Text.Trim() + "',N'" + txtghichu.Text.Trim() + "')";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValuesHang();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnhuy.Enabled = false;
            btnluu.Enabled = true;
            btnin.Enabled = true;
            txtmaphieu.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaSP FROM tblChiTietBKHNhapHang WHERE MaBKHNhapHang= N'" + txtmaphieu.Text + "'";
                //Xóa chi tiết hóa đơn
                sql = "DELETE tblChiTietBKHNhapHang WHERE MaBKHNhapHang=N'" + txtmaphieu.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE tblBKHNhapHang WHERE MaBKHNhapHang =N'" + txtmaphieu.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                ResetValuesHang();
                LoadDataGridView();
                MessageBox.Show("Bạn đã xóa thành công");
                btnxoa.Enabled = false;
                btnin.Enabled = false;
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnluu.Enabled = false;
            txtmaphieu.Enabled = false;
            ResetValuesHang();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinDS, tblThongtinHang;
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
            exRange.Range["A1:E1"].Value = "CÔNG TY TNHH THƯƠNG MẠI VÀ DỊCH VỤ HÙNG MẠNH";

            exRange.Range["A2:E2"].MergeCells = true;
            exRange.Range["A2:E2"].Style.Font.Size = 10;
            exRange.Range["A2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:E2"].Value = "Số 21 đường Chu Văn Thịnh, tổ 1, Phường Tô Hiệu, TP. Sơn La, Sơn La";

            exRange.Range["A3:E3"].MergeCells = true;
            exRange.Range["A3:E3"].Style.Font.Size = 10;
            exRange.Range["A3:E3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:E3"].Value = "Điện thoại: 0212 3855 488";

            exRange.Range["C4:E4"].Font.Size = 16;
            exRange.Range["C4:E4"].Font.Bold = true;
            exRange.Range["C4:E4"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C4:E4"].MergeCells = true;
            exRange.Range["C4:E4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C4:E4"].Value = "BẢN KẾ HOẠCH NHẬP HÀNG";

            // Biểu diễn thông tin chung của danh sách hàng lỗi 
            sql = "SELECT a.MaBKHNhapHang, a.NgayNhap, c.TenNV FROM tblBKHNhapHang AS a JOIN tblNhanVien AS c ON a.MaNV = c.MaNV WHERE a.MaBKHNhapHang = N'" + txtmaphieu.Text + "'";
            tblThongtinDS = Functions.GetDataToTable(sql);
            if (tblThongtinDS.Rows.Count > 0)
            {
                exRange.Range["C6:E6"].Value = tblThongtinDS.Rows[0][0].ToString();
            }
            else
            {
                // Xử lý khi DataTable không có dữ liệu
                // Ví dụ: Ghi log, thông báo lỗi, hoặc thực hiện các hành động khác
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK);
            }

            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã phiếu: ";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinDS.Rows[0][0].ToString();

            exRange.Range["B7:D7"].MergeCells = true;
            exRange.Range["B7:D7"].Style.Font.Size = 10;
            exRange.Range["B7:E7"].MergeCells = true;
            exRange.Range["B7:D7"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["B7:D7"].Value = "Họ tên người giao: CÔNG TY HONDA Việt Nam";

            exRange.Range["B8:E8"].MergeCells = true;
            exRange.Range["B8:E8"].Style.Font.Size = 10;
            exRange.Range["B7:E7"].MergeCells = true;
            exRange.Range["B8:E8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["B8:E8"].Value = "Nhập tại kho: Cửa hàng Hùng Mạnh 3 - Chi Nhánh Sơn La";


            // Tạo bảng danh sách sản phẩm

            sql = "SELECT a.MaSP, TenSP, a.SLDat, a.GhiChu FROM tblChiTietBKHNhapHang AS a , tblSanPham AS b WHERE a.MaBKHNhapHang = N'" +
              txtmaphieu.Text + "' AND a.MaSP = b.MaSP";
            tblThongtinHang = Functions.GetDataToTable(sql);

            // Vẽ tiêu đề bảng danh sách sản phẩm
            exRange.Range["A11:H11"].Font.Bold = true;
            exRange.Range["A11:H11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:H11"].ColumnWidth = 12;
            exRange.Range["A11: A11"].Value = "STT";
            exRange.Range["B11: B11"].Value = "Mã sản phẩm";
            exRange.Range["C11: C11"].Value = "Tên sản phẩm";
            exRange.Range["C11: C11"].ColumnWidth = 20;
            exRange.Range["D11: D11"].Value = "Số lượng đặt";
            exRange.Range["E11: E11"].Value = "Ghi Chú";

            // Điền thông tin sản phẩm
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 4) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                }
            }

            //exRange.Value2 = tblThongtinDS.Rows[0][3].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:H1"].MergeCells = true;
            exRange.Range["A1:H1"].Font.Bold = true;
            exRange.Range["A1:H1"].Font.Italic = true;
            exRange.Range["A1:H1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            // exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());

            exRange = exSheet.Cells[1][hang + 17]; //Ô A1 

            exRange.Range["E1:G1"].MergeCells = true;
            exRange.Range["E1:G1"].Font.Italic = true;
            exRange.Range["E1:G1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinDS.Rows[0][1]);
            exRange.Range["E1:G1"].Value = "Sơn La, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

            exRange.Range["E2:G2"].MergeCells = true;
            exRange.Range["E2:G2"].Font.Italic = true;
            exRange.Range["E2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E2:G2"].Value = "Người lập bản kế hoạch";

            exRange.Range["E6:G6"].MergeCells = true;
            exRange.Range["E6:G6"].Font.Italic = true;
            exRange.Range["E6:G6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E6:G6"].Value = tblThongtinDS.Rows[0]["TenNV"];
            // exSheet.Name = "Phiếu Nhập Hàng";

            exRange.Range["A3:C3"].MergeCells = true;
            exRange.Range["A3:C3"].Font.Italic = true;
            exRange.Range["A3:C3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A:C3"].Value = "Quản lý cửa hàng";
            exApp.Visible = true;
            btnin.Enabled = true;
            btnhuy.Enabled = true;
        }
        private void LoadInfoBC()
        {
            string str;
            str = "SELECT NgayNhap FROM tblBKHNhapHang WHERE MaBKHNhapHang = N'" + txtmaphieu.Text + "'";
            txtngaynhap.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT MaBKHNhapHang FROM tblBKHNhapHang WHERE MaBKHNhapHang = N'" + txtmaphieu.Text + "'";
            txtmaphieu.Text = Functions.GetFieldValues(str);
            str = "SELECT MaSP FROM tblChiTietBKHNhapHang WHERE MaBKHNhapHang = N'" + txtmaphieu.Text + "'";
            cbbmasp.Text = Functions.GetFieldValues(str);
            str = "SELECT SLDat FROM  tblChiTietBKHNhapHang WHERE MaBKHNhapHang = N'" + txtmaphieu.Text + "'";
            txtsl.Text = Functions.GetFieldValues(str);
            str = "SELECT GhiChu FROM tblChiTietBKHNhapHang WHERE MaBKHNhapHang = N'" + txtmaphieu.Text + "'";
            txtghichu.Text = Functions.GetFieldValues(str);
            str = "SELECT MaNV FROM tblBKHNhapHang  WHERE  MaBKHNhapHang= N'" + txtmaphieu.Text + "'";
            txtmanv.Text = Functions.GetFieldValues(str);
            str = "SELECT TenNV FROM  tblNhanVien a join tblBKHNhapHang b on a.MaNV=b.MaNV WHERE MaBKHNhapHang  = N'" + txtmaphieu.Text + "'";
            txttennv.Text = Functions.GetFieldValues(str);
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo",
         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttimkiem.Focus();
                return;
            }
            txtmaphieu.Text = txttimkiem.Text;
            LoadInfoBC();
            LoadDataGridView();
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            btnin.Enabled = true;
        }
    }
}
