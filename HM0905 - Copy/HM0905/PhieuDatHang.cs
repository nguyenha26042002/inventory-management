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
    public partial class PhieuDatHang : Form
    {
        public PhieuDatHang()
        {
            InitializeComponent();
        }
        DataTable tblPDH;
        private void txttiencoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhieuDatHang_Load(object sender, EventArgs e)
        {
            btnthem.Enabled = true;
            btnluu.Enabled = false;
            btnxoa.Enabled = true;
            btnin.Enabled = false;
            txtmaphieu.ReadOnly = true;
            txtmanv.ReadOnly = true;
            txttennv.ReadOnly = true;
            txttenkh.ReadOnly = false;
            txtdiachi.ReadOnly = false;
            txtsdt.ReadOnly = false;
            txttensp.ReadOnly = true;
            txtdvt.ReadOnly = true;
            txtngaytao.ReadOnly = true;
            Functions.FillDataToCombo("SELECT MaKH, TenKH FROM tblKhachHang", cbbmakh, "MaKH", "MaKH");
            cbbmakh.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaSP, TenSP FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaSP,  DVT FROM tblSanPham", cbbmasp, "MaSP", "MaSP");
            cbbmasp.SelectedIndex = -1;
            LoadDataGridView();
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtmaphieu.Text != "")
            {
                LoadInfoHoaDon();
                btnin.Enabled = true;
            }
            LoadDataGridView();
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
            sql = "SELECT  a.MaSP, b.TenSP,b.DVT, a.NgayHen, a.TienCoc, a.GhiChu, a.SLDat  FROM tblChitietPhieuDatHang AS a, tblSanPham AS b WHERE a.MaPhieuDatHang = N'" + txtmaphieu.Text + "' AND a.MaSP=b.MaSP";
            //DataTable data = new DataTable();
            tblPDH = Functions.GetDataToTable(sql);
            dataGridViewPhieuDatHang.DataSource = tblPDH;
            for (int i = 0; i < dataGridViewPhieuDatHang.Rows.Count; i++)
            {
                dataGridViewPhieuDatHang.Rows[i].Cells[0].Value = i + 1;
            }

        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayDat FROM tblPhieuDatHang WHERE MaPhieuDatHang = N'" + txtmaphieu.Text + "'";
            txtngaytao.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT MaKH FROM tblHDBanHang WHERE MaHDBanHang = N'" + txtmaphieu.Text + "'";
            cbbmakh.Text = Functions.GetFieldValues(str);
            str = "SELECT MaSP FROM tblChitietPhieuDatHang WHERE MaPhieuDatHang = N'" + txtmaphieu.Text + "'";
            cbbmasp.Text = Functions.GetFieldValues(str);
            str = "SELECT TienCoc FROM tblChitietPhieuDatHang WHERE MaPhieuDatHang = N'" + txtmaphieu.Text + "'";
            txttiencoc.Text = Functions.GetFieldValues(str);
            str = "SELECT MaNV FROM tblPhieuDatHang WHERE MaPhieuDatHang = N'" + txtmaphieu.Text + "'";
            txtmanv.Text = Functions.GetFieldValues(str);
            str = "SELECT b.TenNV FROM tblPhieuDatHang a , tblNhanVien b WHERE a.MaNV = b.MaNV and MaPhieuDatHang = N'" + txtmaphieu.Text + "'";
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
            LoadInfoHoaDon();
            LoadDataGridView();
            btnxoa.Enabled = true;
            btnluu.Enabled = true;
            btnin.Enabled = true;
        }
        private void ResetValues()
        {
            txtmaphieu.Text = "";
            txtngaytao.Text = DateTime.Now.ToShortDateString();
            txttiencoc.Text = "";
            cbbmasp.Text = "";
            txttensp.Text = "";
            txtsoluong.Text = "";
            txtdvt.Text = "";
        }
        private void ResetValuesHang()
        {
            cbbmasp.Text = "";
            txttensp.Text = "";
            txtsoluong.Text = "";
            txtdvt.Text = "";
            txttiencoc.Text = "";
            txtngayhen.Text = "";
        }
        private void cbbmasp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbmasp.Text == "")
            {
                txttensp.Text = "";
                txtdvt.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenSP FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txttensp.Text = Functions.GetFieldValues(str);
            str = "SELECT DVT FROM tblSanPham WHERE MaSP =N'" + cbbmasp.SelectedValue + "'";
            txtdvt.Text = Functions.GetFieldValues(str);

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

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = true;
            btnin.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmaphieu.Text = Functions.CreateKey("PDH");
            LoadDataGridView();
            LoadThongTinNhanVien();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaPhieuDatHang FROM tblPhieuDatHang WHERE MaPhieuDatHang=N'" + txtmaphieu.Text + "'";
            if (!Functions.checkKeyExit(sql))
            {
                if (txttenkh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttenkh.Focus();
                    return;
                }
                sql = "INSERT INTO tblPhieuDatHang(MaPhieuDatHang, NgayDat, MaNV, MaKH) VALUES (N'" + txtmaphieu.Text.Trim() + "','" +
                        (txtngaytao.Text.Trim()) + "',N'" + txtmanv.Text + "',N'" + cbbmakh.SelectedValue + "')";
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
                MessageBox.Show("Bạn phải nhập số lượng đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Text = "";
                txtsoluong.Focus();
                return;
            }
            if (txttiencoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số tiền đặt cọc của khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttiencoc.Focus();
                return;
            }
            if (txtngayhen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày hẹn lấy hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtngayhen.Focus();
                return;
            }
            sql = "SELECT MaSP FROM tblChitietPhieuDatHang WHERE MaSP=N'" + cbbmasp.SelectedValue + "' AND MaPhieuDatHang= N'" + txtmaphieu.Text.Trim() + "'";
            if (Functions.checkKeyExit(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn hãy chọn mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbbmasp.Focus();
                return;
            }

            sql = "INSERT INTO tblChitietPhieuDatHang(MaPhieuDatHang, MaSP, SLDat, TienCoc, NgayHen, GhiChu) " +
       "VALUES(N'" + txtmaphieu.Text.Trim() + "', N'" + cbbmasp.SelectedValue + "', " + txtsoluong.Text + ", " + txttiencoc.Text + ", '" +
       txtngayhen.Text + "', N'" + txtghichu.Text + "')";

            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValuesHang();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnin.Enabled = true;
            //MessageBox.Show("Lưu thành công", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            //phương thức này cho phép xóa toàn bộ thông tin của hóa đơn
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaSP,SL FROM tblChitietHDBanHang WHERE MaHDBanHang = N'" + txtmaphieu.Text + "'";
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
                sql = "DELETE tblChitietHDBanHang WHERE MaHDBanHang=N'" + txtmaphieu.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE tblHDBanHang WHERE MaHDBanHang=N'" + txtmaphieu.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnxoa.Enabled = false;
                btnin.Enabled = false;
            }
        }

        private void btnin_Click(object sender, EventArgs e)
        {

        }
    }

}
