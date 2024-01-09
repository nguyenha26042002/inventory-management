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
    public partial class DanhMucBaoHanh : Form
    {
        public DanhMucBaoHanh()
        {
            InitializeComponent();
        }
        DataTable tblDMBH;
        private void DanhMucBaoHanh_Load(object sender, EventArgs e)
        {
            txtmadm.Enabled = true;
            btnluu.Enabled = true;
            btnhuy.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaDMBaoHanh,TenDMBaoHanh,DonGia,GhiChu from tblDMBaoHanh";
            //Functions.OpenConnection();
            tblDMBH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dataGridViewDMBH.DataSource = tblDMBH;
            dataGridViewDMBH.AllowUserToAddRows = false;
           dataGridViewDMBH.EditMode = DataGridViewEditMode.EditProgrammatically;
            for (int i = 0; i < dataGridViewDMBH.Rows.Count; i++)
            {
                dataGridViewDMBH.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void ResetValues()
        {
            txtmadm.Text = "";
            txttendm.Text = "";
            txtdongia.Text = "";
            txtghichu.Text = "";
        }
        private void dataGridViewDMBH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmadm.Focus();
                return;
            }
            txtmadm.Text = dataGridViewDMBH.CurrentRow.Cells["MaDMBaoHanh"].Value.ToString();
            txttendm.Text = dataGridViewDMBH.CurrentRow.Cells["TenDMBaoHanh"].Value.ToString();
            txtdongia.Text =dataGridViewDMBH.CurrentRow.Cells["DonGia"].Value.ToString();
            txtghichu.Text = dataGridViewDMBH.CurrentRow.Cells["GhiChu"].Value.ToString();
            
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues(); //Xoá trắng các textbox
            txtmadm.Enabled = true; //cho phép nhập mới
            txtmadm.Focus();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDMBH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmadm.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttendm.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttendm.Focus();
                return;
            }
            if (txtdongia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdongia.Focus();
                return;
            }
            
            sql = "UPDATE tblDMBaoHanh SET TenDMBaoHanh=N'" + txttendm.Text.Trim().ToString() + "',DonGia=N'" +
                txtdongia.Text.Trim().ToString() + "',GhiChu='" + txtghichu.Text.ToString() +
                "' WHERE MaDMBaoHanh=N'" + txtmadm.Text + "'";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();
            btnhuy.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sql;

            if (txtmadm.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblDMBaoHanh WHERE MaDMBaoHanh=N'" + txtmadm.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmadm.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmadm.Focus();
                return;
            }
            if (txttendm.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttendm.Focus();
                return;
            }
            if (txtdongia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtdongia.Focus();
                return;
            }
           
            //Kiểm tra đã tồn tại mã khách chưa
            sql = "SELECT MaDMBaoHanh FROM tblDMBaoHanh WHERE MaDMBaoHanh=N'" + txtmadm.Text.Trim() + "'";
            if (Functions.checkKeyExit(sql))
            {
                MessageBox.Show("Mã danh mục này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmadm.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO tblDMBaoHanh (MaDMBaoHanh, TenDMBaoHanh, DonGia, GhiChu) VALUES (N'" + txtmadm.Text.Trim() +
                "',N'" + txttendm.Text.Trim() + "',N'" + txtdongia.Text.Trim() + "','" + txtghichu.Text + "')";
            Functions.RunSql(sql);
            LoadDataGridView();
            ResetValues();

            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            txtmadm.Enabled = false;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnhuy.Enabled = false;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            txtmadm.Enabled = false;
        }

        private void btnin_Click(object sender, EventArgs e)
        {

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txttimkiem.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblDMBaoHanh WHERE 1=1";
            if (txttimkiem.Text != "")
                sql += " AND MaDMBaoHanh LIKE N'%" + txttimkiem.Text + "%'";

            tblDMBH = Functions.GetDataToTable(sql);
            if (tblDMBH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblDMBH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewDMBH.DataSource = tblDMBH;
            ResetValues();
        }
    }
}
