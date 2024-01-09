namespace HM0905
{
    partial class DanhMucBaoHanh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelbody = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnin = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewDMBH = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDMBaoHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDMBaoHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txttendm = new System.Windows.Forms.TextBox();
            this.txtdongia = new System.Windows.Forms.TextBox();
            this.txtmadm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paneltimkiem = new System.Windows.Forms.Panel();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelbody.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDMBH)).BeginInit();
            this.panel1.SuspendLayout();
            this.paneltimkiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelbody
            // 
            this.panelbody.BackColor = System.Drawing.Color.Snow;
            this.panelbody.Controls.Add(this.panel4);
            this.panelbody.Controls.Add(this.panel2);
            this.panelbody.Controls.Add(this.panel1);
            this.panelbody.Controls.Add(this.paneltimkiem);
            this.panelbody.Controls.Add(this.label1);
            this.panelbody.Location = new System.Drawing.Point(2, 0);
            this.panelbody.Name = "panelbody";
            this.panelbody.Size = new System.Drawing.Size(1097, 623);
            this.panelbody.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnin);
            this.panel4.Controls.Add(this.btnhuy);
            this.panel4.Controls.Add(this.btnluu);
            this.panel4.Controls.Add(this.btnxoa);
            this.panel4.Controls.Add(this.btnsua);
            this.panel4.Controls.Add(this.btnthem);
            this.panel4.Location = new System.Drawing.Point(120, 533);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(839, 71);
            this.panel4.TabIndex = 9;
            // 
            // btnin
            // 
            this.btnin.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnin.ForeColor = System.Drawing.Color.Black;
            this.btnin.Location = new System.Drawing.Point(716, 6);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(111, 62);
            this.btnin.TabIndex = 5;
            this.btnin.Text = "In";
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhuy.ForeColor = System.Drawing.Color.Black;
            this.btnhuy.Location = new System.Drawing.Point(589, 6);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(111, 62);
            this.btnhuy.TabIndex = 4;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnluu
            // 
            this.btnluu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnluu.ForeColor = System.Drawing.Color.Black;
            this.btnluu.Location = new System.Drawing.Point(447, 6);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(111, 62);
            this.btnluu.TabIndex = 3;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.ForeColor = System.Drawing.Color.Black;
            this.btnxoa.Location = new System.Drawing.Point(297, 6);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(111, 62);
            this.btnxoa.TabIndex = 2;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.ForeColor = System.Drawing.Color.Black;
            this.btnsua.Location = new System.Drawing.Point(150, 6);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(111, 62);
            this.btnsua.TabIndex = 1;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthem.ForeColor = System.Drawing.Color.Black;
            this.btnthem.Location = new System.Drawing.Point(6, 6);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(111, 62);
            this.btnthem.TabIndex = 0;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewDMBH);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(92, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(895, 268);
            this.panel2.TabIndex = 4;
            // 
            // dataGridViewDMBH
            // 
            this.dataGridViewDMBH.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDMBH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDMBH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.MaDMBaoHanh,
            this.TenDMBaoHanh,
            this.DonGia,
            this.GhiChu});
            this.dataGridViewDMBH.Location = new System.Drawing.Point(3, 34);
            this.dataGridViewDMBH.Name = "dataGridViewDMBH";
            this.dataGridViewDMBH.RowHeadersWidth = 51;
            this.dataGridViewDMBH.RowTemplate.Height = 24;
            this.dataGridViewDMBH.Size = new System.Drawing.Size(871, 212);
            this.dataGridViewDMBH.TabIndex = 1;
            this.dataGridViewDMBH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDMBH_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "STT";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // MaDMBaoHanh
            // 
            this.MaDMBaoHanh.DataPropertyName = "MaDMBaoHanh";
            this.MaDMBaoHanh.HeaderText = "Mã danh mục";
            this.MaDMBaoHanh.MinimumWidth = 6;
            this.MaDMBaoHanh.Name = "MaDMBaoHanh";
            this.MaDMBaoHanh.Width = 125;
            // 
            // TenDMBaoHanh
            // 
            this.TenDMBaoHanh.DataPropertyName = "TenDMBaoHanh";
            this.TenDMBaoHanh.HeaderText = "Tên danh mục";
            this.TenDMBaoHanh.MinimumWidth = 6;
            this.TenDMBaoHanh.Name = "TenDMBaoHanh";
            this.TenDMBaoHanh.Width = 200;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.MinimumWidth = 6;
            this.DonGia.Name = "DonGia";
            this.DonGia.Width = 125;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.MinimumWidth = 6;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 300;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(23, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Danh mục bảo hành";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtghichu);
            this.panel1.Controls.Add(this.txttendm);
            this.panel1.Controls.Add(this.txtdongia);
            this.panel1.Controls.Add(this.txtmadm);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(92, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 133);
            this.panel1.TabIndex = 3;
            // 
            // txtghichu
            // 
            this.txtghichu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtghichu.ForeColor = System.Drawing.Color.Black;
            this.txtghichu.Location = new System.Drawing.Point(502, 79);
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(361, 44);
            this.txtghichu.TabIndex = 8;
            // 
            // txttendm
            // 
            this.txttendm.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttendm.ForeColor = System.Drawing.Color.Black;
            this.txttendm.Location = new System.Drawing.Point(502, 36);
            this.txttendm.Name = "txttendm";
            this.txttendm.Size = new System.Drawing.Size(361, 27);
            this.txttendm.TabIndex = 7;
            // 
            // txtdongia
            // 
            this.txtdongia.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdongia.ForeColor = System.Drawing.Color.Black;
            this.txtdongia.Location = new System.Drawing.Point(127, 82);
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.Size = new System.Drawing.Size(205, 27);
            this.txtdongia.TabIndex = 6;
            // 
            // txtmadm
            // 
            this.txtmadm.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmadm.ForeColor = System.Drawing.Color.Black;
            this.txtmadm.Location = new System.Drawing.Point(127, 42);
            this.txtmadm.Name = "txtmadm";
            this.txtmadm.Size = new System.Drawing.Size(205, 27);
            this.txtmadm.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(378, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "Ghi chú";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(8, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 19);
            this.label8.TabIndex = 3;
            this.label8.Text = "Đơn giá";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(369, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tên danh mục";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(4, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mã danh mục";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(20, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thông tin danh mục";
            // 
            // paneltimkiem
            // 
            this.paneltimkiem.Controls.Add(this.btntimkiem);
            this.paneltimkiem.Controls.Add(this.txttimkiem);
            this.paneltimkiem.Controls.Add(this.label4);
            this.paneltimkiem.Location = new System.Drawing.Point(92, 45);
            this.paneltimkiem.Name = "paneltimkiem";
            this.paneltimkiem.Size = new System.Drawing.Size(516, 69);
            this.paneltimkiem.TabIndex = 2;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.ForeColor = System.Drawing.Color.Black;
            this.btntimkiem.Location = new System.Drawing.Point(347, 6);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(119, 59);
            this.btntimkiem.TabIndex = 3;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // txttimkiem
            // 
            this.txttimkiem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttimkiem.ForeColor = System.Drawing.Color.Black;
            this.txttimkiem.Location = new System.Drawing.Point(127, 24);
            this.txttimkiem.Multiline = true;
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(205, 28);
            this.txttimkiem.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Từ khóa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(394, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH MỤC BẢO HÀNH";
            // 
            // DanhMucBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1163, 631);
            this.Controls.Add(this.panelbody);
            this.Name = "DanhMucBaoHanh";
            this.Text = "Danh mục bảo hành";
            this.Load += new System.EventHandler(this.DanhMucBaoHanh_Load);
            this.panelbody.ResumeLayout(false);
            this.panelbody.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDMBH)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.paneltimkiem.ResumeLayout(false);
            this.paneltimkiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel paneltimkiem;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewDMBH;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txttendm;
        private System.Windows.Forms.TextBox txtdongia;
        private System.Windows.Forms.TextBox txtmadm;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDMBaoHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDMBaoHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}