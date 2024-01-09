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

namespace HM0905
{
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
        }
       // DataTable tblTK;
        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            btnluu.Enabled = false;
            Load_DataGridView();
            Functions.FillDataToCombo("Select MaNV,TenNV from tblNhanVien", cbbmanv, "MaNV", "MaNV");
            cbbmanv.SelectedIndex = -1;
            Functions.FillDataToCombo("Select MaNV,MaCV from tblNhanVien", cbbmanv, "MaNV", "MaNV");
            cbbmanv.SelectedIndex = -1;
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT a.TenTaiKhoan, b.TenNV, a.MaNV,  a.MatKhau, a.LoaiTaiKhoan, b.MaCV FROM tblTaiKhoan AS a, tblNhanVien AS b WHERE  a.MaNV=b.MaNV";
            DataTable tblTK = new DataTable();
            tblTK = Functions.GetDataToTable(sql);
            dataGridViewTaiKhoan.DataSource = tblTK;
            for (int i = 0; i < dataGridViewTaiKhoan.Rows.Count; i++)
            {
                dataGridViewTaiKhoan.Rows[i].Cells[0].Value = i + 1;
            }

        }
        private void ResetValues()
        {
            txttentaikhoan.Text = "";
            txtmatkhau.Text = "";
            cbbmanv.Text = "";
            txtloaitaikhoan.Text = "";
            txttennv.Text = "";
            txtchucvu.Text = "";
        }
        private void dataGridViewTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ma;
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttentaikhoan.Focus();
                return;
            }
            ma = dataGridViewTaiKhoan.CurrentRow.Cells["MaNV"].Value.ToString();
            cbbmanv.Text = Functions.GetFieldValues("SELECT MaNV FROM tblNhanVien WHERE MaNV = N'" + ma + "'");
           
            txtchucvu.Text = dataGridViewTaiKhoan.CurrentRow.Cells["MaCV"].Value.ToString();
            txttentaikhoan.Text = dataGridViewTaiKhoan.CurrentRow.Cells["TenTaiKhoan"].Value.ToString();
            txttennv.Text = dataGridViewTaiKhoan.CurrentRow.Cells["TenNV"].Value.ToString();
            txtmatkhau.Text = dataGridViewTaiKhoan.CurrentRow.Cells["MatKhau"].Value.ToString();
            txtloaitaikhoan.Text = dataGridViewTaiKhoan.CurrentRow.Cells["LoaiTaiKhoan"].Value.ToString();
            
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = true;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txttentaikhoan.Enabled = true;
            txttentaikhoan.Focus();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttentaikhoan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmatkhau.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmatkhau.Focus();
                return;
            }
            sql = "Update tblTaiKhoan Set MatKhau=N'" + txtmatkhau.Text.ToString() + "',LoaiTaiKhoan='" + txtloaitaikhoan.Text + "'," +
                "MaNV='" + cbbmanv.SelectedValue + "' Where TenTaiKhoan=N'" + txttentaikhoan.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnluu.Enabled = true;
            txttentaikhoan.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttentaikhoan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa tài khoản này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "Delete tblTaiKhoan Where TenTaiKhoan=N'" + txttentaikhoan.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txttentaikhoan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập tên tài khoản ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentaikhoan.Focus();
                return;
            }
            if (txtmatkhau.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmatkhau.Focus();
                return;
            }
            if (txtloaitaikhoan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập loại tài khoản cho tài khoản này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtloaitaikhoan.Focus();
                return;
            }
            if (cbbmanv.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbbmanv.Focus();
                return;
            }
            /*
            sql = "Select TenTaiKhoan FROM tblTaiKhoan Where TenTaiKhoan=N'" + txttentaikhoan.Text.Trim() + "'";
            if (Functions.checkKeyExit(sql))
            {
                MessageBox.Show("Tên tài khoản này này đã tồn tại, bạn phải nhập tên tài khoản khác khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttentaikhoan.Focus();
                txttentaikhoan.Text = "";
                return;
            }
            */
            sql = "Insert into tblTaiKhoan(TenTaiKhoan,MatKhau,LoaiTaiKhoan,MaNV) " +
                "values(N'" + txttentaikhoan.Text + "',N'" + txtmatkhau.Text + "'," +
                "'" + txtloaitaikhoan.Text + "', '" + cbbmanv.SelectedValue + "')";

            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txttentaikhoan.Enabled = false;
        }
        private void cbbmanv_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbbmanv.Text == "")
            {
                txttennv.Text = "";
                txtchucvu.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select TenNV from tblNhanVien where MaNV = N'" + cbbmanv.SelectedValue + "'";
            txttennv.Text = Functions.GetFieldValues(str);
            str = "Select MaCV from tblNhanVien where MaNV = N'" + cbbmanv.SelectedValue + "'";
            txtchucvu.Text = Functions.GetFieldValues(str);
        }

        
    }
}
