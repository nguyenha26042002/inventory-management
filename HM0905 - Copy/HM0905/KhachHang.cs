using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HM0905
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        DataTable tblKH;
        private void KhachHang_Load(object sender, EventArgs e)
        {
           // btnluu.Enabled = false;
            txtmakh.ReadOnly = true;
           // btnluu.Enabled = true;
           // btnhuy.Enabled = false;
            //LoadDataGridView();
            //ResetValues();
            
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblKhachHang";
            DataTable tblKH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dataGridViewKhachHang.DataSource = tblKH;
            for (int i = 0; i < dataGridViewKhachHang.Rows.Count; i++)
            {
                dataGridViewKhachHang.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void ResetValues()
        {
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            //txtmakh.Text = Functions.CreateKey("KH");
        }
        private void dataGridViewKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenkh.Focus();
                return;
            }
            txtmakh.Text = dataGridViewKhachHang.CurrentRow.Cells["MaKH"].Value.ToString();
            txttenkh.Text = dataGridViewKhachHang.CurrentRow.Cells["TenKH"].Value.ToString();
            txtdiachi.Text = dataGridViewKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtsdt.Text = dataGridViewKhachHang.CurrentRow.Cells["SDT"].Value.ToString();
            txtemail.Text = dataGridViewKhachHang.CurrentRow.Cells["Email"].Value.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnluu.Enabled = true;
            btnhuy.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmakh.Text = Functions.CreateKey("KH");
            txtmakh.Enabled = false;
            txttenkh.Focus();
            LoadDataGridView();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenkh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenkh.Focus();
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdiachi.Focus();
                return;
            }
            if (txtsdt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsdt.Focus();
                return;
            }
            if (txtemail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsdt.Focus();
                return;
            }
            sql = "UPDATE tblKhachHang SET TenKH=N'" + txttenkh.Text.ToString() + "',DiaChi=N'" +
                txtdiachi.Text.ToString() + "',SDT=N'" + txtsdt.Text.ToString() + "',Email='" + txtemail.Text.ToString() + "' WHERE MaKH=N'" + txtmakh.Text + "'";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();
            btnhuy.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá khách hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblKhachHang WHERE MaKH=N'" + txtmakh.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaKH FROM tblKhachHang WHERE MaKH=N'" + txtmakh.Text + "'";
                if (txttenkh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttenkh.Focus();
                    return;
                }
                if (txtdiachi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtdiachi.Focus();
                    return;
                }
                if (txtsdt.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtsdt.Focus();
                    return;
                }
                if (txtemail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtemail.Focus();
                    return;
                }
            //Chèn thêm
            sql = "INSERT INTO tblKhachHang(MaKH, TenKH, DiaChi, SDT, Email) VALUES (N'" + txtmakh.Text +
                "',N'" + txttenkh.Text+ "',N'" + txtdiachi.Text + "','" + txtsdt.Text + "', '" + txtemail.Text + "')";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();
            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnhuy.Enabled = false;
            btnluu.Enabled = true;
            txtmakh.Enabled = false;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {

            ResetValues();
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmakh.Enabled = false;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txttimkiem.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblKhachHang WHERE 1=1";
            if (txttimkiem.Text != "")
                sql += " AND MaKH LIKE N'%" + txttimkiem.Text + "%'";

            tblKH = Functions.GetDataToTable(sql);
            if (tblKH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblKH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewKhachHang.DataSource = tblKH;
            ResetValues();
        }

        private void panelbody_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
