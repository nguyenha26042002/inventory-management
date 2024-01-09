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
    public partial class Model : Form
    {
        public Model()
        {
            InitializeComponent();
        }

        private void Model_Load(object sender, EventArgs e)
        {
            txtmamodel.Text = "";
            txttenmodel.Text = "";
            LoadData();
        }
        private void LoadData()
        {
            string sql;
            sql = "SELECT MaKM, TenKM FROM tblKieuMau";
            DataTable tblKH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dataGridViewModel.DataSource = tblKH;
            for (int i = 0; i < dataGridViewModel.Rows.Count; i++)
            {
                dataGridViewModel.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txttenmodel.Enabled = true;
            txtmamodel.Enabled = true;
            txtmamodel.Text = "";
            txtmamodel.Text = "";

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txttenmodel.Enabled = true;
            txtmamodel.Enabled = true;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maKM = txtmamodel.Text;
                string query = "DELETE FROM tblKieuMau WHERE MaKM = @MaKM";
                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@MaKM", maKM);
                command.ExecuteNonQuery();
                LoadData();
            
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            
                string maKM = txtmamodel.Text;
                string tenKM = txttenmodel.Text;

                string query = "INSERT INTO tblKieuMau (MaKM, TenKM) VALUES (@MaKM, @TenKM)";
                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@MaKM", maKM);
                command.Parameters.AddWithValue("@TenKM", tenKM);
                command.ExecuteNonQuery();
                LoadData();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string searchQuery = txttenmodel.Text;
            string query = "SELECT MaKM, TenKM FROM tblKieuMau WHERE TenKM LIKE @SearchQuery";
            SqlCommand command = new SqlCommand(query, Functions.conn);
            command.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridViewModel.DataSource = dataTable;
        }

        private void dataGridViewModel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell =dataGridViewModel.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string cellValue = cell.Value.ToString();

                // Populate the textboxes
                txtmamodel.Text = dataGridViewModel.Rows[e.RowIndex].Cells["MaKM"].Value.ToString();
                txttenmodel.Text = dataGridViewModel.Rows[e.RowIndex].Cells["TenKM"].Value.ToString();
            }
        }
    }
}
