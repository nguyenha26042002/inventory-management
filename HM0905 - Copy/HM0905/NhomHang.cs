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
    public partial class NhomHang : Form
    {
        public NhomHang()
        {
            InitializeComponent();
        }

        private void NhomHang_Load(object sender, EventArgs e)
        {
            txtmanh.Enabled = false;
            txttennh.Enabled = false;
            LoadData();
        }
        private void LoadData()
        {
            string sql;
            sql = "SELECT MaNH, TenNH FROM tblNhomHang";
            DataTable tblKH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dataGridViewNhomHang.DataSource = tblKH;
            for (int i = 0; i < dataGridViewNhomHang.Rows.Count; i++)
            {
                dataGridViewNhomHang.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmanh.Enabled = true;
            txttennh.Enabled = true;
            txtmanh.Text = "";
            txttennh.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
           
                string maNH = txtmanh.Text;
                string tenNH = txttennh.Text;
                string query = "INSERT INTO tblNhomHang (MaNH, TenNH) VALUES (@MaNH, @TenNH)";
                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@MaNH", maNH);
                command.Parameters.AddWithValue("@TenNH", tenNH);
                command.ExecuteNonQuery();
                LoadData();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtmanh.Enabled = true;
            txttennh.Enabled = true;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maNH = txtmanh.Text;
                string query = "DELETE FROM tblNhomHang WHERE MaNH = @MaNH";
                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@MaNH", maNH);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadData();
                    txtmanh.Text = "";
                    txttennh.Text = "";
                }
                else
                {
                    MessageBox.Show("Thất bại. Không xóa được");
                }
        }

        private void dataGridViewNhomHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridViewNhomHang.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string cellValue = cell.Value.ToString();

                // Populate the textboxes
                txtmanh.Text = dataGridViewNhomHang.Rows[e.RowIndex].Cells["MaNH"].Value.ToString();
                txttennh.Text = dataGridViewNhomHang.Rows[e.RowIndex].Cells["TenNH"].Value.ToString();
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string searchQuery = txttimkiem.Text;
                string query = "SELECT MaNH, TenNH FROM tblNhomHang WHERE TenNH LIKE @SearchQuery";
                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewNhomHang.DataSource = dataTable;
        }
    }
}
