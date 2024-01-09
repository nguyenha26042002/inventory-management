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
    public partial class HoaDonBanHang : Form
    {
        public HoaDonBanHang()
        {
            InitializeComponent();
        }
        DataTable tblCTHDB;
        private void HoaDonBanHang_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnxoa.Enabled = true;
            btnin.Enabled = false;
            txtmahd.ReadOnly = true;
            txtmanv.ReadOnly = true;
            txttennv.ReadOnly = true;
            txttenkh.ReadOnly = false;
            txtdiachi.ReadOnly = false;
            txtsdt.ReadOnly = false;
            txttensp.ReadOnly = true;
            txtdongia.ReadOnly = true;
            txtthanhtien.ReadOnly = true;
            txtdvt.ReadOnly = true;
            txtvat.ReadOnly = true;
            txtngayban.ReadOnly = true;
            txttongtien.ReadOnly = true;
            txtgiamgia.Text = "0";
            txttongtien.Text = "0";
            Functions.FillDataToCombo("SELECT MaKH, TenKH FROM tblKhachHang", cbbmakh, "MaKH", "MaKH");
            cbbmakh.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaSP, TenSP FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaSP, VAT FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaSP,  DVT FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaSP, DGBan FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            LoadDataGridView();
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm

            if (txtmahd.Text != "")
            {
                LoadInfoHoaDon();
                btnin.Enabled = true;
            }
            //LoadDataGridView();
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
            sql = "SELECT  b.MaSP, b.TenSP,b.DVT,  b.VAT, a.SL, b.DGBan, a.GiamGia,a.ThanhTien FROM tblChitietHDBanHang AS a, tblSanPham AS b WHERE a.MaHDBanHang = N'" + txtmahd.Text + "' AND a.MaSP=b.MaSP";
            tblCTHDB = Functions.GetDataToTable(sql);
            dataGridViewHDBanHang.DataSource = tblCTHDB;
            for (int i = 0; i < dataGridViewHDBanHang.Rows.Count; i++)
            {
                dataGridViewHDBanHang.Rows[i].Cells[0].Value = i + 1;
            }

        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM tblHDBanHang WHERE MaHDBanHang = N'" + txtmahd.Text + "'";
            txtngayban.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT MaKH FROM tblHDBanHang WHERE MaHDBanHang = N'" + txtmahd.Text + "'";
            cbbmakh.Text = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM tblHDBanHang WHERE MaHDBanHang = N'" + txtmahd.Text + "'";
            txttongtien.Text = Functions.GetFieldValues(str);
            str = "SELECT MaNV FROM tblHDBanHang WHERE MaHDBanHang = N'" + txtmahd.Text + "'";
            txtmanv.Text = Functions.GetFieldValues(str);
            str = "SELECT b.TenNV FROM tblHDBanHang a , tblNhanVien b WHERE a.MaNV = b.MaNV and MaHDBanHang = N'" + txtmahd.Text + "'";
            txttennv.Text = Functions.GetFieldValues(str);
        }

        private void ResetValues()
        {
            txtmahd.Text = "";
            txtngayban.Text = DateTime.Now.ToShortDateString();
            cbbmakh.Text = "";
            txttenkh.Text = "";
            txttongtien.Text = "";
            cbbmasp.Text = "";
            txttensp.Text = "";
            txtsoluong.Text = "";
            txtgiamgia.Text = "0";
            txtthanhtien.Text = "";
            txtdongia.Text = "";
            txtvat.Text = "";
            txtdvt.Text = "";

        }
        private void ResetValuesHang()
        {
            txtmahd.Text = "";
           // cbbmakh.Text = "";
           // txttenkh.Text = "";
            //txttongtien.Text = "";
            cbbmasp.Text = "";
            txttensp.Text = "";
            txtsoluong.Text = "";
            txtgiamgia.Text = "0";
            txtthanhtien.Text = "";
            txtdongia.Text = "";
            txtvat.Text = "";
            txtdvt.Text = "";
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
                txtdongia.Text = "";
                txtsoluong.Text = "";
                txtvat.Text = "";
                txtdvt.Text = "";
                txtgiamgia.Text = "";
                txtthanhtien.Text = "";
                txttongtien.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenSP FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txttensp.Text = Functions.GetFieldValues(str);
            str = "SELECT DGBan FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txtdongia.Text = Functions.GetFieldValues(str);
            str = "SELECT VAT FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txtvat.Text = Functions.GetFieldValues(str);
            str = "SELECT DVT FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txtdvt.Text = Functions.GetFieldValues(str);

        }
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            float tt, sl, dg, gg, vat;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToSingle(txtsoluong.Text);

            if (txtgiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToSingle(txtgiamgia.Text);

            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToSingle(txtdongia.Text);
            if (txtvat.Text == "")
                vat = 0;
            else
                vat = Convert.ToSingle(txtvat.Text);

            tt = sl * dg - sl * dg * gg / 100 + sl * dg * vat / 100;
            txtthanhtien.Text = tt.ToString();
        }
        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            float tt, sl, dg, gg, vat;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToSingle(txtsoluong.Text);

            if (txtgiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToSingle(txtgiamgia.Text);

            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToSingle(txtdongia.Text);
            if (txtvat.Text == "")
                vat = 0;
            else
                vat = Convert.ToSingle(txtvat.Text);

            tt = sl * dg - sl * dg * gg / 100 + sl * dg * vat / 100;
            txtthanhtien.Text = tt.ToString();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToSingle(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimkiem.Focus();
                return;
            }
            txtmahd.Text = txttimkiem.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            btnin.Enabled = true;
        }

        private void btnthem_Click_1(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnin.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmahd.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
            LoadThongTinNhanVien();
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            //phương thức này cho phép xóa toàn bộ thông tin của hóa đơn
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaSP,SL FROM tblChitietHDBanHang WHERE MaHDBanHang = N'" + txtmahd.Text + "'";
                DataTable tblHang = Functions.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT SL FROM tblSanPham WHERE MaSP = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE tblSanPham SET SL =" + slcon + " WHERE MaSP= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    Functions.RunSql(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE tblChitietHDBanHang WHERE MaHDBanHang=N'" + txtmahd.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE tblHDBanHang WHERE MaHDBanHang=N'" + txtmahd.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnxoa.Enabled = false;
                btnin.Enabled = false;
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            float sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHDBanHang FROM tblHDBanHang WHERE MaHDBanHang=N'" + txtmahd.Text + "'";
            if (!Functions.checkKeyExit(sql))
            {
                if (txttenkh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttenkh.Focus();
                    return;
                }
                sql = "INSERT INTO tblHDBanHang(MaHDBanHang, NgayBan, MaNV, MaKH, TongTien) VALUES (N'" + txtmahd.Text.Trim() + "','" +
                        (txtngayban.Text.Trim()) + "',N'" + txtmanv.Text + "',N'" + cbbmakh.SelectedValue + "','" + txttongtien.Text + "')";
                Functions.RunSql(sql);
                LoadDataGridView();
            }
            // Lưu thông tin của các mặt hàng
            if (cbbmasp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbmasp.Focus();
                return;
            }
            if ((txtsoluong.Text.Trim().Length == 0) || (txtsoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            if (txtgiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtgiamgia.Focus();
                return;
            }
            sql = "SELECT MaSP FROM tblChitietHDBanHang WHERE MaSP=N'" + cbbmasp.SelectedValue + "' AND MaHDBanHang = N'" + txtmahd.Text.Trim() + "'";
            if (Functions.checkKeyExit(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn hãy chọn mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbbmasp.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToSingle(Functions.GetFieldValues("SELECT SL FROM tblSanPham WHERE MaSP = N'" + cbbmasp.SelectedValue + "'"));
            if (Convert.ToSingle(txtsoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblChitietHDBanHang(MaHDBanHang,MaSP,DVT, VAT,SL,DGBan, GiamGia,ThanhTien, NgayBan) VALUES(N'" + txtmahd.Text.Trim() + "',N'" + cbbmasp.SelectedValue + "',N'" + txtdvt.Text + "','" + txtvat.Text + "' ," + txtsoluong.Text + "," + txtdongia.Text + "," + txtgiamgia.Text + "," + txtthanhtien.Text + ", N'" + txtngayban.Text + "')";
            Functions.RunSql(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblSanPham
            SLcon = sl - Convert.ToSingle(txtsoluong.Text);
            sql = "UPDATE tblSanPham SET SL =" + SLcon + " WHERE MaSP= N'" + cbbmasp.SelectedValue + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán

            tong = Convert.ToSingle(Functions.GetFieldValues("SELECT TongTien FROM tblHDBanHang WHERE MaHDBanHang = N'" + txtmahd.Text + "'"));
            Tongmoi = tong + Convert.ToSingle(txtthanhtien.Text);
            sql = "UPDATE tblHDBanHang SET TongTien =" + Tongmoi + " WHERE MaHDBanHang = N'" + txtmahd.Text + "'";
            Functions.RunSql(sql);
            txttongtien.Text = Tongmoi.ToString();
            ResetValuesHang();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnin.Enabled = true;
            //MessageBox.Show("Lưu thành công", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information );
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
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:E3"].Font.Size = 10;
            exRange.Range["A1:E3"].Font.Bold = true;
            exRange.Range["A1:E3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:E1"].MergeCells = true;
            exRange.Range["A1:E1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:E1"].Value = "CÔNG TY TINH THƯƠNG MẠI VÀ DỊCH VỤ HÙNG MẠNH";
            exRange.Range["A2:E2"].MergeCells = true;
            exRange.Range["A2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:E2"].Value = " Số 21 đường Chu Văn Thịnh, tổ 1, Phường Tô Hiệu, TP. Sơn La, Sơn La";
            exRange.Range["A3:E3"].MergeCells = true;
            exRange.Range["A3:E3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:E3"].Value = "Điện thoại: 0222210318 091257";
            exRange.Range["C4:E4"].Font.Size = 16;
            exRange.Range["C4:E4"].Font.Bold = true;
            exRange.Range["C4:E4"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C4:E4"].MergeCells = true;
            exRange.Range["C4:E4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C4:E4"].Value = "HÓA ĐƠN BÁN HÀNG";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHDBanHang, a.NgayBan, a.TongTien, b.TenKH, b.DiaChi, b.SDT, c.TenNV " +
                    "FROM tblHDBanHang AS a " +
                    "JOIN tblKhachHang AS b ON a.MaKH = b.MaKH " +
                    "JOIN tblNhanVien AS c ON a.MaNV = c.MaNV " +
                    "WHERE a.MaHDBanHang = N'" + txtmahd.Text + "'";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = " Số Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSP,b.DVT, b.VAT, a.SL, b.DGBan, a.GiamGia, a.ThanhTien " +
                  "FROM tblChitietHDBanHang AS a , tblSanPham AS b WHERE a.MaHDBanHang = N'" +
                  txtmahd.Text + "' AND a.MaSP = b.MaSP";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sản phẩm";
            exRange.Range["C11:C11"].Value = "DVT";
            exRange.Range["D11:D11"].Value = "VAT";
            exRange.Range["E11:E11"].Value = "Số lượng";
            exRange.Range["F11:F11"].Value = "Đơn giá";
            exRange.Range["G11:G11"].Value = "Giảm giá";
            exRange.Range["H11:H11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 2) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                    if (cot == 5) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            // exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Sơn La, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn bán hàng";
            exApp.Visible = true;
        }

        private void dataGridViewHDBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string MaHangxoa = dataGridViewHDBanHang.CurrentRow.Cells["MaSP"].Value.ToString();

                if (!float.TryParse(dataGridViewHDBanHang.CurrentRow.Cells["SL"].Value.ToString(), out float SoLuongxoa))
                {
                    MessageBox.Show("Giá trị số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!float.TryParse(dataGridViewHDBanHang.CurrentRow.Cells["ThanhTien"].Value.ToString(), out float ThanhTienxoa))
                {
                    MessageBox.Show("Giá trị thành tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sql = "DELETE tblChitietHDBanHang WHERE MaHDBanHang=N'" + txtmahd.Text + "' AND MaSP = N'" + MaHangxoa + "'";
                Functions.RunSql(sql);

                float sl = Convert.ToSingle(Functions.GetFieldValues("SELECT SL FROM tblSanPham WHERE MaSP = N'" + MaHangxoa + "'"));
                float slcon = sl + SoLuongxoa;
                sql = "UPDATE tblSanPham SET SL = " + slcon + " WHERE MaSP = N'" + MaHangxoa + "'";
                Functions.RunSql(sql);

                float tong = Convert.ToSingle(Functions.GetFieldValues("SELECT TongTien FROM tblHDBanHang WHERE MaHDBanHang = N'" + txtmahd.Text + "'"));
                float tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE tblHDBanHang SET TongTien = " + tongmoi + " WHERE MaHDBanHang = N'" + txtmahd.Text + "'";
                Functions.RunSql(sql);

                txttongtien.Text = tongmoi.ToString();
                LoadDataGridView();
            }
        }

        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttimkiem.Focus();
                return;
            }
            txtmahd.Text = txttimkiem.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            btnin.Enabled = true;
        }

    }
}

