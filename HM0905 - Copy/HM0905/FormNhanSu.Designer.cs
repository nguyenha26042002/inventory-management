namespace HM0905
{
    partial class FormNhanSu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanSu));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btntaikhoan = new FontAwesome.Sharp.IconButton();
            this.btndangxuat = new FontAwesome.Sharp.IconButton();
            this.btnchucvu = new FontAwesome.Sharp.IconButton();
            this.btnnhanvien = new FontAwesome.Sharp.IconButton();
            this.panelbody = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panelbody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Brown;
            this.panel2.Controls.Add(this.btntaikhoan);
            this.panel2.Controls.Add(this.btndangxuat);
            this.panel2.Controls.Add(this.btnchucvu);
            this.panel2.Controls.Add(this.btnnhanvien);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 663);
            this.panel2.TabIndex = 0;
            // 
            // btntaikhoan
            // 
            this.btntaikhoan.FlatAppearance.BorderSize = 0;
            this.btntaikhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntaikhoan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntaikhoan.ForeColor = System.Drawing.Color.Transparent;
            this.btntaikhoan.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btntaikhoan.IconColor = System.Drawing.Color.Black;
            this.btntaikhoan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btntaikhoan.Location = new System.Drawing.Point(0, 225);
            this.btntaikhoan.Name = "btntaikhoan";
            this.btntaikhoan.Size = new System.Drawing.Size(240, 84);
            this.btntaikhoan.TabIndex = 13;
            this.btntaikhoan.Text = "TÀI KHOẢN";
            this.btntaikhoan.UseVisualStyleBackColor = true;
            this.btntaikhoan.Click += new System.EventHandler(this.btntaikhoan_Click);
            // 
            // btndangxuat
            // 
            this.btndangxuat.FlatAppearance.BorderSize = 0;
            this.btndangxuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndangxuat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangxuat.ForeColor = System.Drawing.Color.Transparent;
            this.btndangxuat.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            this.btndangxuat.IconColor = System.Drawing.Color.White;
            this.btndangxuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndangxuat.IconSize = 30;
            this.btndangxuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndangxuat.Location = new System.Drawing.Point(30, 604);
            this.btndangxuat.Name = "btndangxuat";
            this.btndangxuat.Size = new System.Drawing.Size(183, 47);
            this.btndangxuat.TabIndex = 12;
            this.btndangxuat.Text = "ĐĂNG XUẤT";
            this.btndangxuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndangxuat.UseVisualStyleBackColor = true;
            // 
            // btnchucvu
            // 
            this.btnchucvu.FlatAppearance.BorderSize = 0;
            this.btnchucvu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnchucvu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchucvu.ForeColor = System.Drawing.Color.Transparent;
            this.btnchucvu.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnchucvu.IconColor = System.Drawing.Color.Black;
            this.btnchucvu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnchucvu.Location = new System.Drawing.Point(0, 122);
            this.btnchucvu.Name = "btnchucvu";
            this.btnchucvu.Size = new System.Drawing.Size(240, 97);
            this.btnchucvu.TabIndex = 4;
            this.btnchucvu.Text = "CHỨC VỤ";
            this.btnchucvu.UseVisualStyleBackColor = true;
            this.btnchucvu.Click += new System.EventHandler(this.btnchucvu_Click_1);
            // 
            // btnnhanvien
            // 
            this.btnnhanvien.FlatAppearance.BorderSize = 0;
            this.btnnhanvien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnhanvien.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnhanvien.ForeColor = System.Drawing.Color.Transparent;
            this.btnnhanvien.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnnhanvien.IconColor = System.Drawing.Color.Black;
            this.btnnhanvien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnnhanvien.Location = new System.Drawing.Point(3, 28);
            this.btnnhanvien.Name = "btnnhanvien";
            this.btnnhanvien.Size = new System.Drawing.Size(240, 97);
            this.btnnhanvien.TabIndex = 3;
            this.btnnhanvien.Text = "NHÂN VIÊN";
            this.btnnhanvien.UseVisualStyleBackColor = true;
            this.btnnhanvien.Click += new System.EventHandler(this.btnnhanvien_Click_1);
            // 
            // panelbody
            // 
            this.panelbody.BackColor = System.Drawing.Color.Snow;
            this.panelbody.Controls.Add(this.pictureBox1);
            this.panelbody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbody.Location = new System.Drawing.Point(240, 0);
            this.panelbody.Name = "panelbody";
            this.panelbody.Size = new System.Drawing.Size(906, 663);
            this.panelbody.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(204, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 502);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormNhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1146, 663);
            this.Controls.Add(this.panelbody);
            this.Controls.Add(this.panel2);
            this.Name = "FormNhanSu";
            this.Text = "Nhân sự";
            this.Load += new System.EventHandler(this.FormNhanSu_Load);
            this.panel2.ResumeLayout(false);
            this.panelbody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelbody;
        private FontAwesome.Sharp.IconButton btnchucvu;
        private FontAwesome.Sharp.IconButton btnnhanvien;
        private FontAwesome.Sharp.IconButton btndangxuat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btntaikhoan;
    }
}