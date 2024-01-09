using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM0905
{
    public partial class ChucVu : Form
    {
        public ChucVu()
        {
            InitializeComponent();
        }

        private void ChucVu_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetValues();
        }
        private void ResetValues()
        {
            txtmachucvu.Text = "";
            txttencv.Text = "";
        }
        private void LoadData()
        {
            string sql;
            sql = "SELECT * from tblChucVu";
            DataTable tblKH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dataGridViewChucVu.DataSource = tblKH;
            for (int i = 0; i < dataGridViewChucVu.Rows.Count; i++)
            {
                dataGridViewChucVu.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadData();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
                string maCV = txtmachucvu.Text;
                string tenCV = txttencv.Text;

                string insertQuery = "INSERT INTO tblChucVu (MaCV, TenCV) VALUES (@MaCV, @TenCV)";
                    SqlCommand command = new SqlCommand(insertQuery, Functions.conn);
                    command.Parameters.AddWithValue("@MaCV", maCV);
                    command.Parameters.AddWithValue("@TenCV", tenCV);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Lưu thành công");
                            ResetValues();
                        }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maCV = txtmachucvu.Text;

            string deleteQuery = "DELETE FROM tblChucVu WHERE MaCV = @MaCV";

            SqlCommand command = new SqlCommand(deleteQuery, Functions.conn);
            command.Parameters.AddWithValue("@MaCV", maCV);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Xóa thành công.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Thất bại. KHông xóa được.");
            }
        }

        private void dataGridViewChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewChucVu.Rows[e.RowIndex];

                // Retrieve the values from the selected row
                string maCV = row.Cells["MaCV"].Value.ToString();
                string tenCV = row.Cells["TenCV"].Value.ToString();

                // Update the UI with the selected values
                txtmachucvu.Text = maCV;
                txttencv.Text = tenCV;
            }
        }
    }
}
