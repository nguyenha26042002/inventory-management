using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace HM0905
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChilForm(Form chilForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = chilForm;
            chilForm.TopLevel = false;
            chilForm.FormBorderStyle = FormBorderStyle.None;
            chilForm.Dock = DockStyle.Fill;
            panelbody.Controls.Add(chilForm);
            panelbody.Tag = chilForm;
            chilForm.BringToFront();
            chilForm.Show();
            dataGridViewSanPham.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridViewSanPham.Columns[dataGridViewSanPham.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'quanLyCuaHangDataSet2.KieuMau' table. You can move, or remove it, as needed.
            //this.kieuMauTableAdapter.Fill(this.quanLyCuaHangDataSet2.KieuMau);
            //// TODO: This line of code loads data into the 'quanLyCuaHangDataSet1.MauSac' table. You can move, or remove it, as needed.
            //this.mauSacTableAdapter.Fill(this.quanLyCuaHangDataSet1.MauSac);
            //// TODO: This line of code loads data into the 'quanLyCuaHangDataSet.NhomHang' table. You can move, or remove it, as needed.
            //this.nhomHangTableAdapter.Fill(this.quanLyCuaHangDataSet.NhomHang);
            Functions.FillDataToCombo("SELECT MaNH,  MaNH FROM tblNhomHang", cbbmanh, "MaNH", "MaNH");
            cbbmanh.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaMS,  MaMS FROM tblMauSac", cbbmacolor, "MaMS", "MaMS");
            cbbmacolor.SelectedIndex = -1;
            Functions.FillDataToCombo("SELECT MaKM,  MaKM FROM tblKieuMau", cbbmamodel, "MaKM", "MaKM");
            cbbmamodel.SelectedIndex = -1;
            LoadData();
        }
        private void ResetValues()
        {
            txtmasp.Text = "";
            txttensp.Text = "";
            txtsokhung.Text = "";
            txtsomay.Text = "";
            txtsotem.Text = "";
            cbbmanh.Text = "";
            cbbmamodel.Text = "";
            cbbmacolor.Text = "";
            txtgiaban.Text = "";
            txtgianhap.Text = "";
            txtvat.Text = "";
            txtdvt.Text = "";
            txtsoluong.ReadOnly = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasp.Enabled = true;
            txttensp.Enabled = true;
            txtsokhung.Enabled = true;
            txtsomay.Enabled = true;
            txtsotem.Enabled = true;
            cbbmanh.Enabled = true;
            cbbmamodel.Enabled = true;
            cbbmacolor.Enabled = true;
            txtgiaban.Enabled = true;
            txtsoluong.Enabled = true;
            txtvat.Enabled = true;
            txtdvt.Enabled = true;
            ResetValues();
            LoadData();
        }
        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                // Save the image in JPEG format
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        private void btnthemanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                picsanpham.Image = Image.FromFile(imagePath);
            }
        }
        private void LoadData()
        {
            txttensp.Enabled = true;
            string query = "SELECT * FROM tblSanPham";
            adapter = new SqlDataAdapter(query, Functions.conn);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridViewSanPham.DataSource = dataTable;
        }
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        private void btnluu_Click(object sender, EventArgs e)
        {
           
                string query = "INSERT INTO tblSanPham (MaSP, TenSP, SoKhung, SoMay, SoTem, MaNH, MaKM, MaMS, DGNhap, DGBan, VAT, DVT, Anh, GhiChu) " +
                               "VALUES (@MaSP, @TenSP, @SoKhung, @SoMay, @SoTem, @MaNH, @MaKM, @MaMS, @DGNhap, @DGBan, @VAT, @DVT, @Anh, @GhiChu)";

                using (SqlCommand command = new SqlCommand(query, Functions.conn))
                {
                    command.Parameters.AddWithValue("@MaSP", txtmasp.Text);
                    command.Parameters.AddWithValue("@TenSP", txttensp.Text);
                    command.Parameters.AddWithValue("@SoKhung", txtsokhung.Text);
                    command.Parameters.AddWithValue("@SoMay", txtsomay.Text);
                    command.Parameters.AddWithValue("@SoTem", txtsotem.Text);
                    command.Parameters.AddWithValue("@MaNH", cbbmanh.Text);
                    command.Parameters.AddWithValue("@MaKM", cbbmamodel.Text);
                    command.Parameters.AddWithValue("@MaMS", cbbmacolor.Text);
                    float gianhap;
                    if (float.TryParse(txtgianhap.Text, out gianhap))
                    {
                        command.Parameters.AddWithValue("@DGNhap", gianhap);
                    }
                    else
                    {
                        // Handle the error, show a message, or take appropriate action
                    }

                    float giaban;
                    if (float.TryParse(txtgiaban.Text, out giaban))
                    {
                        command.Parameters.AddWithValue("@DGBan", giaban);
                    }
                    else
                    {
                        // Handle the error, show a message, or take appropriate action
                    }

                    //float soluong;
                    //if (float.TryParse(txtsoluong.Text, out soluong))
                    //{
                    //    command.Parameters.AddWithValue("@SL", soluong);
                    //}
                    //else
                    //{
                    //    // Handle the error, show a message, or take appropriate action
                    //}

                    float vat;
                    if (float.TryParse(txtvat.Text, out vat))
                    {
                        command.Parameters.AddWithValue("@VAT", vat);
                    }
                    else
                    {
                        // Handle the error, show a message, or take appropriate action
                    }
                    command.Parameters.AddWithValue("@DVT", txtdvt.Text);
                    // Convert and save the image as binary data
                    byte[] imageData = ImageToByteArray(picsanpham.Image);
                    command.Parameters.AddWithValue("@Anh", imageData);

                    command.Parameters.AddWithValue("@GhiChu", txtghichu.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm sản phẩm thành công ");
                }
                LoadData();
            }

        private void dataGridViewSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dataGridViewSanPham.Rows[e.RowIndex];

                // Lấy giá trị từ các ô trong dòng
                string maSP = selectedRow.Cells["MaSP"].Value.ToString();
                string tenSP = selectedRow.Cells["TenSP"].Value.ToString();
                string soKhung = selectedRow.Cells["SoKhung"].Value.ToString();
                string soMay = selectedRow.Cells["SoMay"].Value.ToString();
                string soTem = selectedRow.Cells["SoTem"].Value.ToString();
                string maNH = selectedRow.Cells["MaNH"].Value.ToString();
                string maKM = selectedRow.Cells["MaKM"].Value.ToString();
                string maMS = selectedRow.Cells["MaMS"].Value.ToString();
                float dgNhap = float.Parse(selectedRow.Cells["DGNhap"].Value.ToString());
                float dgBan = float.Parse(selectedRow.Cells["DGBan"].Value.ToString());
                int sl = int.Parse(selectedRow.Cells["SL"].Value.ToString());
                float vat;
                if (float.TryParse(selectedRow.Cells["VAT"].Value.ToString(), out vat))
                {
                    // Xử lý khi chuyển đổi thành công
                }
                else
                {
                    // Xử lý khi chuyển đổi không thành công
                }
                string dvt = selectedRow.Cells["ĐVT"].Value.ToString();
                object imageDataObj = selectedRow.Cells["Anh"].Value;
                byte[] imageData = null;

                if (!Convert.IsDBNull(imageDataObj))
                {
                    imageData = (byte[])imageDataObj;
                }
                string ghiChu = selectedRow.Cells["GhiChu"].Value.ToString();
                // Gán giá trị vào các điều khiển
                txtmasp.Text = maSP;
                txttensp.Text = tenSP;
                txtsokhung.Text = soKhung;
                txtsomay.Text = soMay;
                txtsotem.Text = soTem;
                cbbmanh.Text = maNH;
                cbbmamodel.Text = maKM;
                cbbmacolor.Text = maMS;
                txtgianhap.Text = dgNhap.ToString();
                txtgiaban.Text = dgBan.ToString();
                txtsoluong.Text = sl.ToString();
                txtvat.Text = vat.ToString();
                txtdvt.Text = dvt;
                picsanpham.Image = ByteArrayToImage(imageData);
                txtghichu.Text = ghiChu;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtmasp.Enabled = true;
            txttensp.Enabled = true;
            txtsokhung.Enabled = true;
            txtsomay.Enabled = true;
            txtsotem.Enabled = true;
            cbbmanh.Enabled = true;
            cbbmamodel.Enabled = true;
            cbbmacolor.Enabled = true;
            txtgiaban.Enabled = true;
            txtsoluong.Enabled = true;
            txtvat.Enabled = true;
            txtdvt.Enabled = true;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewSanPham.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridViewSanPham.SelectedRows[0].Index;
                string maSP = dataGridViewSanPham.Rows[rowIndex].Cells["MaSP"].Value.ToString();
                string query = "DELETE FROM tblSanPham WHERE MaSP = @MaSP";
                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@MaSP", maSP);
                command.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string searchName = txttimkiem.Text;
                string query = "SELECT * FROM tblSanPham WHERE TenSP LIKE '%' + @SearchName + '%'";
                SqlCommand command = new SqlCommand(query, Functions.conn);
                command.Parameters.AddWithValue("@SearchName", searchName);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

        }

        private void btnhuy_Click_1(object sender, EventArgs e)
        {
            txtmasp.Text = "";
            txtmasp.Text = string.Empty;
            txttensp.Text = string.Empty;
            txtsokhung.Text = string.Empty;
            txtsomay.Text = string.Empty;
            txtsotem.Text = string.Empty;
            cbbmanh.Text = string.Empty;
            cbbmamodel.Text = string.Empty;
            cbbmacolor.Text = string.Empty;
            txtgiaban.Text = string.Empty;
            txtsoluong.Text = string.Empty;
            txtvat.Text = string.Empty;
            txtdvt.Text = string.Empty;
        }

        private void btnin_Click_1(object sender, EventArgs e)
        {
            // Tạo một ứng dụng Excel mới
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            // Tạo một workbook mới
            Excel.Workbook workbook = excelApp.Workbooks.Add();

            // Tạo một worksheet mới
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Đặt tên cho worksheet
            worksheet.Name = "Danh sách sản phẩm";

            // Lấy dữ liệu từ DataGridView
            for (int i = 0; i < dataGridViewSanPham.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewSanPham.Columns.Count; j++)
                {
                    if (dataGridViewSanPham.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 1, j + 1] = dataGridViewSanPham.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 1, j + 1] = string.Empty;
                    }
                }
            }


            // Lưu workbook vào một tệp Excel
            workbook.SaveAs("DanhSachSanPham.xlsx");

            // Đóng workbook và ứng dụng Excel
            //workbook.Close();
            //excelApp.Quit();
        }
    }
}


