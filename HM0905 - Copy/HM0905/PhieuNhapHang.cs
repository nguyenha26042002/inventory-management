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
    public partial class PhieuNhapHang : Form
    {
        public PhieuNhapHang()
        {
            InitializeComponent();
        }
        DataTable tblPNH;
        private void PhieuNhapHang_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnxoa.Enabled = false;
            btnin.Enabled = false;
            txtmaphieu.ReadOnly = true;
            txtmanv.ReadOnly = true;
            txttennv.ReadOnly = true;
            txttensp.ReadOnly = true;
            txtdongia.ReadOnly = true;
            txtthanhtien.ReadOnly = true;
            txtdvt.ReadOnly = true;
            txtvat.ReadOnly = true;
            txtsoluong.ReadOnly = false;
            txtngaynhap.ReadOnly = true;
            txttongtien.ReadOnly = true;
            txttongtien.Text = "0";
            Functions.FillDataToCombo("SELECT MaSP, TenSP FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaSP, VAT FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaSP,  DVT FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaSP, DGNhap FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a. MaSP, b.TenSP, b.DVT, b.VAT, a.SLNhap, b.DGNhap,a.ThanhTien FROM tblChitietPhieuNhapHang AS a, tblSanPham AS b WHERE a.MaPhieuNhapHang = N'" + txtmaphieu.Text + "' AND a.MaSP=b.MaSP";
            //DataTable data = new DataTable();
            tblPNH = Functions.GetDataToTable(sql);
            dataGridViewPNH.DataSource = tblPNH;
            for (int i = 0; i < dataGridViewPNH.Rows.Count; i++)
            {
                dataGridViewPNH.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void dataGridViewPNH_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string MaHangxoa, sql;
            float ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblPNH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dataGridViewPNH.CurrentRow.Cells["MaSP"].Value.ToString();
                SoLuongxoa = Convert.ToSingle(dataGridViewPNH.CurrentRow.Cells["SLNhap"].Value.ToString());
                ThanhTienxoa = Convert.ToSingle(dataGridViewPNH.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE tblChitietPhieuNhapHang WHERE MaPhieuNhapHang=N'" + txtmaphieu.Text + "' AND MaSP = N'" + MaHangxoa + "'";
                Functions.RunSql(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToSingle(Functions.GetFieldValues("SELECT SL FROM tblSanPham WHERE MaSP = N'" + MaHangxoa + "'"));
                slcon = sl - SoLuongxoa;
                sql = "UPDATE tblSanPham SET SL =" + slcon + " WHERE MaSP= N'" + MaHangxoa + "'";
                Functions.RunSql(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToSingle(Functions.GetFieldValues("SELECT TongTien FROM tblPhieuNhapHang WHERE MaPhieuNhapHang = N'" + txtmaphieu.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE tblPhieuNhapHang SET TongTien =" + tongmoi + " WHERE MaPhieuNhapHang = N'" + txtmaphieu.Text + "'";
                Functions.RunSql(sql);
                txttongtien.Text = tongmoi.ToString();
                LoadDataGridView();
            }
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
        private void ResetValues()
        {
            txtmaphieu.Text = "";
            //txtngaynhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtngaynhap.Text = DateTime.Now.ToShortDateString();
            txttongtien.Text = "";
            cbbmasp.Text = "";
            txttensp.Text = "";
            txtsoluong.Text = "";
            txtthanhtien.Text = "";
            txtdongia.Text = "";
            txtvat.Text = "";
            txtdvt.Text = "";

        }
        private void ResetValuesHang()
        {
            cbbmasp.Text = "";
            txtsoluong.Text = "";
            txtthanhtien.Text = "0";
            txttensp.Text = "";
            txtdongia.Text = "";
            txtdvt.Text = "";
            txtvat.Text = "";
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {

        }


        private void btnthem_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnin.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmaphieu.Text = Functions.CreateKey("PNH");
            LoadDataGridView();
            LoadThongTinNhanVien();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

            string sql;
            if (tblPNH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaphieu.Text == "")
            {
                MessageBox.Show("Bạn phải chọn phiếu cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbbmasp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbmasp.Focus();
                return;
            }
            sql = "";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();
            btnhuy.Enabled = false;
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            //phương thức này cho phép xóa toàn bộ thông tin của hóa đơn
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaSP,SLNhap FROM tblChitietPhieuNhapHang WHERE MaPhieuNhapHang = N'" + txtmaphieu.Text + "'";
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
                sql = "DELETE tblChitietPhieuNhapHang WHERE MaPhieuNhapHang=N'" + txtmaphieu.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE tblPhieuNhapHang WHERE MaPhieuNhapHang=N'" + txtmaphieu.Text + "'";
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
            sql = "SELECT MaPhieuNhapHang FROM tblPhieuNhapHang WHERE MaPhieuNhapHang=N'" + txtmaphieu.Text + "'";
            if (!Functions.checkKeyExit(sql))
            {
                if (txttennv.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttennv.Focus();
                    return;
                }
                sql = "INSERT INTO tblPhieuNhapHang(MaPhieuNhapHang, NgayNhap, MaNV, TongTien) VALUES (N'" + txtmaphieu.Text.Trim() + "','" +
                        (txtngaynhap.Text.Trim()) + "',N'" + txtmanv.Text + "','" + txttongtien.Text + "')";
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
           
            sql = "SELECT MaSP FROM tblChitietPhieuNhapHang WHERE MaSP=N'" + cbbmasp.SelectedValue + "' AND MaPhieuNhapHang = N'" + txtmaphieu.Text.Trim() + "'";
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
            sql = "INSERT INTO tblChitietPhieuNhapHang(MaPhieuNhapHang,MaSP,DVT, SLNhap,DGNhap, VAT,ThanhTien, NgayNhap" +
                ") VALUES(N'" + txtmaphieu.Text.Trim() + "',N'" + cbbmasp.SelectedValue + "',N'"+ txtdvt.Text +"'," + txtsoluong.Text + "," + txtdongia.Text + "," + txtvat.Text + "," + txtthanhtien.Text + ", '" +txtngaynhap.Text + "')";
            Functions.RunSql(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblSanPham
            SLcon = sl + Convert.ToSingle(txtsoluong.Text);
            sql = "UPDATE tblSanPham SET SL =" + SLcon + " WHERE MaSP= N'" + cbbmasp.SelectedValue + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán

            tong = Convert.ToSingle(Functions.GetFieldValues("SELECT TongTien FROM tblPhieuNhapHang WHERE MaPhieuNhapHang = N'" + txtmaphieu.Text + "'"));
            Tongmoi = tong + Convert.ToSingle(txtthanhtien.Text);
            sql = "UPDATE tblPhieuNhapHang SET TongTien =" + Tongmoi + " WHERE MaPhieuNhapHang = N'" + txtmaphieu.Text + "'";
            Functions.RunSql(sql);
            txttongtien.Text = Tongmoi.ToString();
            ResetValuesHang();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnin.Enabled = true;
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
                txtthanhtien.Text = "";
                txttongtien.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenSP FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txttensp.Text = Functions.GetFieldValues(str);
            str = "SELECT DGNhap FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txtdongia.Text = Functions.GetFieldValues(str);
            str = "SELECT VAT FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txtvat.Text = Functions.GetFieldValues(str);
            str = "SELECT DVT FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txtdvt.Text = Functions.GetFieldValues(str);

        }
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            float tt, sl, dg, vat;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToSingle(txtsoluong.Text);

            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToSingle(txtdongia.Text);
            if (txtvat.Text == "")
                vat = 0;
            else
                vat = Convert.ToSingle(txtvat.Text);

            tt = sl * dg + sl * dg * vat / 100;
            txtthanhtien.Text = tt.ToString();

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
            exRange.Range["C4:E4"].Value = "PHIẾU NHẬP HÀNG";

            // Biểu diễn thông tin chung của phiếu nhập hàng
            sql = "SELECT a.MaPhieuNhapHang, a.NgayNhap, a.TongTien, c.TenNV FROM tblPhieuNhapHang AS a JOIN tblNhanVien AS c ON a.MaNV = c.MaNV WHERE a.MaPhieuNhapHang = N'" + txtmaphieu.Text + "'";
            tblThongtinHD = Functions.GetDataToTable(sql);
            if (tblThongtinHD.Rows.Count > 0)
            {
                exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            }
            else
            {
                // Xử lý khi DataTable không có dữ liệu
                // Ví dụ: Ghi log, thông báo lỗi, hoặc thực hiện các hành động khác
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK);
            }

            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã phiếu:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            
            exRange.Range["B7:D7"].MergeCells = true;
            exRange.Range["B7:D7"].Style.Font.Size = 10;
            exRange.Range["B7:E7"].MergeCells = true;
            exRange.Range["B7:D7"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["B7:D7"].Value = "Họ tên người giao:CÔNG TY HONDA ";

            exRange.Range["B8:E8"].MergeCells = true;
            exRange.Range["B8:E8"].Style.Font.Size = 10;
            exRange.Range["B7:E7"].MergeCells = true;
            exRange.Range["B8:E8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["B8:E8"].Value = "Nhập tại kho: Cửa hàng Hùng Mạnh 3 - Chi Nhánh Sơn La";

          
            // Tạo bảng danh sách sản phẩm

            sql = "SELECT b. MaSP, b.TenSP,b.DVT, a.SLNhap,b.VAT, b.DGNhap, a.ThanhTien " +
              "FROM tblChitietPhieuNhapHang AS a , tblSanPham AS b WHERE a.MaPhieuNhapHang = N'" +
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
            exRange.Range["D11: D11"].Value = "Đơn vị tính";
            exRange.Range["E11: E11"].Value = "Số lượng";
            exRange.Range["F11: F11"].Value = "VAT";
            exRange.Range["G11: G11"].Value = "Đơn giá nhập";
            exRange.Range["H11: H11"].Value = "Thành tiền";

            // Điền thông tin sản phẩm
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 4) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
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
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["E1:G1"].Value = "Sơn La, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

            exRange.Range["E2:G2"].MergeCells = true;
            exRange.Range["E2:G2"].Font.Italic = true;
            exRange.Range["E2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E2:G2"].Value = "Người lập phiếu";

            exRange.Range["E6:G6"].MergeCells = true;
            exRange.Range["E6:G6"].Font.Italic = true;
            exRange.Range["E6:G6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E6:G6"].Value = tblThongtinHD.Rows[0][3];
            // exSheet.Name = "Phiếu Nhập Hàng";

            exRange.Range["A3:C3"].MergeCells = true;
            exRange.Range["A3:C3"].Font.Italic = true;
            exRange.Range["A3:C3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:C3"].Value = "Người giao hàng";
            exApp.Visible = true;
            
        }

        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã phiếu để tìm", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttimkiem.Focus();
                return;
            }
            txtmaphieu.Text = txttimkiem.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            btnin.Enabled = true;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayNhap FROM tblPhieuNhapHang WHERE MaPhieuNhapHang = N'" + txtmaphieu.Text + "'";
            txtngaynhap.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT MaSP FROM tblChitietPhieuNhapHang WHERE MaPhieuNhapHang = N'" + txtmaphieu.Text + "'";
            cbbmasp.Text = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM tblPhieuNhapHang WHERE MaPhieuNhapHang = N'" + txtmaphieu.Text + "'";
            txttongtien.Text = Functions.GetFieldValues(str);
            str = "SELECT MaNV FROM tblPhieuNhapHang WHERE MaPhieuNhapHang = N'" + txtmaphieu.Text + "'";
            txtmanv.Text = Functions.GetFieldValues(str);
            str = "SELECT b.TenNV FROM tblPhieuNhapHang a , tblNhanVien b WHERE a.MaNV = b.MaNV and MaPhieuNhapHang = N'" + txtmaphieu.Text + "'";
            txttennv.Text = Functions.GetFieldValues(str);
        }
    }
}
