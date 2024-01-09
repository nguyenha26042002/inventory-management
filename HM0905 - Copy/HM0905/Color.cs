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
    public partial class Color : Form
    {
        public Color()
        {
            InitializeComponent();
        }

        public static System.Drawing.Color Red { get; internal set; }

        private void Color_Load(object sender, EventArgs e)
        {
            LoadData();
            txtmacolor.Enabled = false;
            txttencolor.Enabled = false;
            txtmacolor.Text = "";
            txttencolor.Text = "";
        }
        private void LoadData()
        {
            string sql;
            sql = "SELECT * FROM tblMauSac";
            DataTable tblKH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dataGridViewColor.DataSource = tblKH;
            for (int i = 0; i < dataGridViewColor.Rows.Count; i++)
            {
                dataGridViewColor.Rows[i].Cells[0].Value = i + 1;
            }
            dataGridViewColor.Columns[dataGridViewColor.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmacolor.Enabled = true;
            txttencolor.Enabled = true;
            txtmacolor.Text = "";
            txttencolor.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
                string maMS = txtmacolor.Text;
                string tenMS = txttencolor.Text;
                string query = "INSERT INTO tblMauSac (MaMS, TenMS) VALUES (@MaMS, @TenMS)";
                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@MaMS", maMS);
                command.Parameters.AddWithValue("@TenMS", tenMS);
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm màu sắc thành công");
                LoadData();
                txtmacolor.Text = "";
                txttencolor.Text = "";
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtmacolor.Enabled = true;
            txttencolor.Enabled = true;
        }
        private void dataGridViewColor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridViewColor.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string cellValue = cell.Value.ToString();

                // Populate the textboxes
                txtmacolor.Text = dataGridViewColor.Rows[e.RowIndex].Cells["MaMS"].Value.ToString();
                txttencolor.Text = dataGridViewColor.Rows[e.RowIndex].Cells["TenMS"].Value.ToString();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string maMS = txtmacolor.Text;
            string query = "DELETE FROM tblMauSac WHERE MaMS = @MaMS";
            SqlCommand command = new SqlCommand(query, Functions.conn);
            command.Parameters.AddWithValue("@MaMS", maMS);
            command.ExecuteNonQuery();
            MessageBox.Show("Xóa màu sắc thành công");
            LoadData();

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
                 string searchColor = txttencolor.Text;
                string query = "SELECT MaMS, TenMS FROM tblMauSac WHERE TenMS LIKE '%' + @ColorName + '%'";
                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@ColorName", searchColor);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                dataGridViewColor.DataSource = dataTable;
        }
    }
}
