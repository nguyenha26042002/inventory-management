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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Controls.Primitives;

namespace HM0905
{
    public partial class HoaDonBaoHanh : Form
    {
        public HoaDonBaoHanh()
        {
            InitializeComponent();
        }
        DataTable tblCTHDBH;

        private void HoaDonBaoHanh_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnxoa.Enabled = true;
            btnin.Enabled = false;
            txtmahoadon.ReadOnly = true;
            txtmanv.ReadOnly = true;
            txttennv.ReadOnly = true;
            txttenkh.ReadOnly = true;
            txttensp.ReadOnly = true;
            txtmasp.ReadOnly = true;
            txttendm.ReadOnly = true;
            txtdongia.ReadOnly = true;
            txtthanhtien.ReadOnly = true;
            txtngaynhap.ReadOnly = true;
            txttongtien.ReadOnly = true;

            Functions.FillDataToCombo("SELECT a.MaPhieuBaoHanh, b.TenKH FROM tblPhieuBaoHanh as a, tblKhachHang as b where a.MaKH = b.MaKH", cbbmaphieubaohanh, "MaPhieuBaoHanh", "MaPhieuBaoHanh");
            cbbmaphieubaohanh.SelectedIndex = -1;

            Functions.FillDataToCombo("SELECT a.MaPhieuBaoHanh, b.MaKH FROM tblPhieuBaoHanh as a, tblKhachHang as b where a.MaKH = b.MaKH", cbbmaphieubaohanh, "MaPhieuBaoHanh", "MaPhieuBaoHanh");
            cbbmaphieubaohanh.SelectedIndex = -1;

            Functions.FillDataToCombo("SELECT MaPhieuBaoHanh, MaSP FROM tblChitietPhieuBaoHanh", cbbmaphieubaohanh, "MaPhieuBaoHanh", "MaPhieuBaoHanh");
            cbbmaphieubaohanh.SelectedIndex = -1;

            Functions.FillDataToCombo("SELECT a.MaPhieuBaoHanh, b.TenSP FROM tblCHitietPhieuBaoHanh as a, tblSanPham as b where a.MaSP = b.MaSP", cbbmaphieubaohanh, "MaPhieuBaoHanh", "MaPhieuBaoHanh");
            cbbmaphieubaohanh.SelectedIndex = -1;

            Functions.FillDataToCombo("SELECT MaPhieuBaoHanh, ThoiHanBH FROM tblChitietPhieuBaoHanh", cbbmaphieubaohanh, "MaPhieuBaoHanh", "MaPhieuBaoHanh");
            cbbmaphieubaohanh.SelectedIndex = -1;

            Functions.FillDataToCombo("SELECT MaDMBaoHanh, TenDMBaoHanh FROM tblDMBaoHanh", cbbmadm, "MaDMBaoHanh", "MaDMBaoHanh");
            cbbmadm.SelectedIndex = -1;

            Functions.FillDataToCombo("SELECT MaDMBaoHanh, DonGia FROM tblDMBaoHanh", cbbmadm, "MaDMBaoHanh", "MaDMBaoHanh");
            cbbmadm.SelectedIndex = -1;

            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT b.MaSP, TenSP, c.MaDMBaoHanh, TenDMBaoHanh, b.ThoiHanBH, c.DonGia, c.SL,c.KhauTru,c.ThanhTien " +
                "from tblSanPham a join tblChitietPhieuBaoHanh b on a.MaSP=b.MaSP " +
                "join tblChitietHDBaoHanh c on b.MaPhieuBaoHanh=c.MaPhieuBaoHanh " +
                "join tblDMBaoHanh d on c.MaDMBaoHanh=d.MaDMBaoHanh " +
                "WHERE c.MaHDBaoHanh = N'" + txtmahoadon.Text + "'";

            tblCTHDBH = Functions.GetDataToTable(sql);
           dataGridViewHDBH.DataSource = tblCTHDBH;
            for (int i = 0; i < dataGridViewHDBH.Rows.Count; i++)
            {
               dataGridViewHDBH.Rows[i].Cells[0].Value = i + 1;
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
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayNhap FROM tblHDBaoHanh WHERE MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
            txtngaynhap.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));

            str = "SELECT b.TenKH FROM tblHDBaoHanh a, tblKhachHang b  WHERE a.MaKH=b.MaKH and MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
            txttenkh.Text = Functions.GetFieldValues(str);

            str = "SELECT b.MaKH FROM tblHDBaoHanh a, tblKhachHang b  WHERE a.MaKH=b.MaKH and MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
            txtmakh.Text = Functions.GetFieldValues(str);

            str = "SELECT TongTien FROM tblHDBaoHanh WHERE MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
            txttongtien.Text = Functions.GetFieldValues(str);

            str = "SELECT MaNV FROM tblHDBaoHanh WHERE MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
            txtmanv.Text = Functions.GetFieldValues(str);

            str = "SELECT b.TenNV FROM tblHDBaoHanh a, tblNhanVien b WHERE a.MaNV = b.MaNV and MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
            txttennv.Text = Functions.GetFieldValues(str);

            str = "SELECT MaPhieuBaoHanh FROM tblChitietHDBaoHanh WHERE  MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
            cbbmaphieubaohanh.Text = Functions.GetFieldValues(str);

            str = "SELECT b.MaSP FROM tblChitietHDBaoHanh a, tblChitietPhieuBaoHanh b  WHERE a.MaSP = b.MaSP and MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
            txtmasp.Text = Functions.GetFieldValues(str);

            str = "SELECT b.TenSP FROM tblChitietHDBaoHanh a, tblSanPham b WHERE a.MaSP=b.MaSP and  MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
            txttensp.Text = Functions.GetFieldValues(str);

            //str = "SELECT b.MaPhieuBaoHanh from tblChitietHDBaoHanh a, tblPhieuBaoHanh b where a.MaPhieuBaoHanh=b.MaPhieuBaoHanh and MaHDBaoHanh = N'" + txtmahoadon.Text + "' ";
            //cbbmaphieubaohanh.Text = Functions.GetFieldValues(str);
        }
        private void ResetValues()
        {
            txtmahoadon.Text = "";
            txtngaynhap.Text = DateTime.Now.ToShortDateString();
            cbbmaphieubaohanh.Text = "";
            txttenkh.Text = "";
            txtmakh.Text = "";
            txttongtien.Text = "";
            txtmasp.Text = "";
            txttensp.Text = "";
            txttendm.Text = "";
            txttimkiem.Text = "";
            txtmanv.Text = "";
            txttennv.Text = "";
            txtthoihanbh.Text = "";
        }
        private void ResetValuesHang()
        {
            cbbmadm.Text = "";
            txtsoluong.Text = "";
            txtkhautru.Text = "0";
            txtthanhtien.Text = "";
            txtdongia.Text = "";
            txttendm.Text = "";
        }
        private void cbbmaphieubaohanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string str;
            if (cbbmaphieubaohanh.Text == "")
            {
                txtmakh.Text = "";
                txttenkh.Text = "";
                txtmasp.Text = "";
                txttensp.Text = "";
                txtthoihanbh.Text = "";
            }

            str = "Select TenKH from tblKhachHang a, tblPhieuBaoHanh b where a.MaKH = b.MaKH and  MaPhieuBaoHanh = N'" + cbbmaphieubaohanh.SelectedValue + "'";
            txttenkh.Text = Functions.GetFieldValues(str);

            str = "Select MaKH from  tblPhieuBaoHanh  where   MaPhieuBaoHanh = N'" + cbbmaphieubaohanh.SelectedValue + "'";
            txtmakh.Text = Functions.GetFieldValues(str);

            str = "Select MaSP from tblChitietPhieuBaoHanh where MaPhieuBaoHanh = N'" + cbbmaphieubaohanh.SelectedValue + "'";
            txtmasp.Text = Functions.GetFieldValues(str);

            str = "Select TenSP from tblSanPham a, tblChitietPhieuBaoHanh b where a.MaSP = b.MaSP and  MaPhieuBaoHanh = N'" + cbbmaphieubaohanh.SelectedValue + "'";
            txttensp.Text = Functions.GetFieldValues(str);

            str = "Select ThoiHanBH from tblChitietPhieuBaoHanh where MaPhieuBaoHanh= N'" + cbbmaphieubaohanh.SelectedValue + "'";
            txtthoihanbh.Text = Functions.GetFieldValues(str);
            
        }
        private void cbbmadm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbmadm.Text == "")
            {
                txttendm.Text = "";
                txtdongia.Text = "";
            }
            str = "Select TenDMBaoHanh from tblDMBaoHanh where MaDMBaoHanh = N'" + cbbmadm.SelectedValue + "'";
            txttendm.Text = Functions.GetFieldValues(str);

            str = "Select DonGia from tblDMBaoHanh where MaDMBaoHanh = N'" + cbbmadm.SelectedValue + "'";
            txtdongia.Text = Functions.GetFieldValues(str);

        }
        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            float tt, sl, dg, kt;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToSingle(txtsoluong.Text);

            if (txtkhautru.Text == "")
                kt = 0;
            else
                kt = Convert.ToSingle(txtkhautru.Text);

            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToSingle(txtdongia.Text);

            tt = sl * dg - sl * dg * kt / 100;
            txtthanhtien.Text = tt.ToString();
        }
        private void txtkhautru_TextChanged(object sender, EventArgs e)
        {
            float tt, sl, dg, kt;
            if (txtsoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToSingle(txtsoluong.Text);

            if (txtkhautru.Text == "")
                kt = 0;
            else
                kt = Convert.ToSingle(txtkhautru.Text);

            if (txtdongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToSingle(txtdongia.Text);

            tt = sl * dg - sl * dg * kt / 100;
            txtthanhtien.Text = tt.ToString();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnin.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmahoadon.Text = Functions.CreateKey("HDBH");
            LoadDataGridView();
            LoadThongTinNhanVien();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            float  tong, Tongmoi;
                
                sql = "INSERT INTO tblHDBaoHanh(MaHDBaoHanh, NgayNhap, MaNV,MaKH, TongTien) " +
                "VALUES (N'" + txtmahoadon.Text.Trim() + "','" +(txtngaynhap.Text.Trim()) + "'," +
                "N'" + txtmanv.Text + "','"+txtmakh.Text+"','" + txttongtien.Text + "')";
                Functions.RunSql(sql);
                LoadDataGridView();
            
            // Lưu thông tin của các mặt hàng
            if (cbbmaphieubaohanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn phiếu bảo hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbmaphieubaohanh.Focus();
                return;
            }
            if ((txtsoluong.Text.Trim().Length == 0) || (txtsoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            if (txtkhautru.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập % khấu trừ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtkhautru.Focus();
                return;
            }
            sql = "SELECT MaDMBaoHanh FROM tblChitietHDBaoHanh WHERE MaDMBaoHanh=N'" + cbbmadm.SelectedValue + "' AND MaHDBaoHanh = N'" + txtmahoadon.Text.Trim() + "'";
            if (Functions.checkKeyExit(sql))
            {
                MessageBox.Show("Mã danh mục bảo hành này đã có, bạn hãy chọn mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbbmadm.Focus();
                return;
            }
            
            sql = "INSERT INTO tblChitietHDBaoHanh(MaHDBaoHanh,MaPhieuBaoHanh,MaDMBaoHanh,SL,DonGia, KhauTru,ThanhTien, MaSP)" +
                " VALUES(N'" + txtmahoadon.Text.Trim() + "',N'" + cbbmaphieubaohanh.SelectedValue + "', N'"+cbbmadm.SelectedValue+"','" + txtsoluong.Text + "' ," + txtdongia.Text + "," +
                "" + txtkhautru.Text + "," + txtthanhtien.Text + ", N'" + txtmasp.Text + "')";
            Functions.RunSql(sql);
            LoadDataGridView();

            // Cập nhật lại tổng tiền cho hóa đơn bảo hành

            tong = Convert.ToSingle(Functions.GetFieldValues("SELECT TongTien FROM tblHDBaoHanh WHERE MaHDBaoHanh = N'" + txtmahoadon.Text + "'"));
            Tongmoi = tong + Convert.ToSingle(txtthanhtien.Text);
            sql = "UPDATE tblHDBaoHanh SET TongTien =" + Tongmoi + " WHERE MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
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
            exRange.Range["C4:E4"].Value = "HÓA ĐƠN BẢO HÀNH";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHDBaoHanh, a.NgayNhap, a.TongTien, b.TenKH, b.DiaChi, b.SDT, c.TenNV " +
                    "FROM tblHDBaoHanh AS a " +
                    "JOIN tblKhachHang AS b ON a.MaKH = b.MaKH " +
                    "JOIN tblNhanVien AS c ON a.MaNV = c.MaNV " +
                    "WHERE a.MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
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
            sql = "SELECT b.TenSP,c.TenDMBaoHanh, a.DonGia, a.SL, a.KhauTru,a.ThanhTien " +
                  "FROM tblChitietHDBaoHanh AS a , tblSanPham AS b, tblDMBaoHanh c WHERE a.MaHDBaoHanh = N'" +
                  txtmahoadon.Text + "' AND a.MaSP = b.MaSP and a.MaDMBaoHanh=c.MaDMBaoHanh";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:G11"].Font.Bold = true;
            exRange.Range["A11:G11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:G11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sản phẩm";
            exRange.Range["C11:C11"].Value = "Tên danh mục bảo hành";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Số lượng";
            exRange.Range["F11:F11"].Value = "Khấu trừ";
            exRange.Range["G11:G11"].Value = "Thành tiền";
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
            exSheet.Name = "Hóa đơn bảo hành";
            exApp.Visible = true;
        }
       
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một  để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimkiem.Focus();
                return;
            }
            txtmahoadon.Text = txttimkiem.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            btnin.Enabled = true;
        }

        private void dataGridViewHDBH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaHangxoa, sql;
            float ThanhTienxoa, SoLuongxoa, tong, tongmoi;
            if (tblCTHDBH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaHangxoa = dataGridViewHDBH.CurrentRow.Cells["MaSP"].Value.ToString();
                SoLuongxoa = Convert.ToSingle(dataGridViewHDBH.CurrentRow.Cells["SL"].Value.ToString());
                ThanhTienxoa = Convert.ToSingle(dataGridViewHDBH.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE tblChitietHDBaoHanh WHERE MaHDBaoHanh=N'" + txtmahoadon.Text + "' AND MaSP = N'" + MaHangxoa + "'";
                Functions.RunSql(sql);
                
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToSingle(Functions.GetFieldValues("SELECT TongTien FROM tblHDBaoHanh WHERE MaHDBaoHanh = N'" + txtmahoadon.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE tblHDBaoHanh SET TongTien =" + tongmoi + " WHERE MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
                Functions.RunSql(sql);
                txttongtien.Text = tongmoi.ToString();
                LoadDataGridView();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            //phương thức này cho phép xóa toàn bộ thông tin của hóa đơn
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaSP,SL FROM tblChitietHDBaoHanh WHERE MaHDBaoHanh = N'" + txtmahoadon.Text + "'";
                DataTable tblHang = Functions.GetDataToTable(sql);
             
                //Xóa chi tiết hóa đơn
                sql = "DELETE tblChitietHDBaoHanh WHERE MaHDBaoHanh=N'" + txtmahoadon.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE tblHDBaoHanh WHERE MaHDBaoHanh=N'" + txtmahoadon.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnxoa.Enabled = false;
                btnin.Enabled = false;
                txtngaynhap.Text = "";
            }
        }
    }
    
}
