namespace HM0905
{
    partial class FormHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHoaDon));
            this.panelbody = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelleft = new System.Windows.Forms.Panel();
            this.btndangxuat = new FontAwesome.Sharp.IconButton();
            this.btnhdbaohanh = new FontAwesome.Sharp.IconButton();
            this.btnhdbanhang = new FontAwesome.Sharp.IconButton();
            this.btnphieudathang = new FontAwesome.Sharp.IconButton();
            this.panelbody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelleft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelbody
            // 
            this.panelbody.BackColor = System.Drawing.Color.Snow;
            this.panelbody.Controls.Add(this.pictureBox1);
            this.panelbody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbody.Location = new System.Drawing.Point(246, 0);
            this.panelbody.Name = "panelbody";
            this.panelbody.Size = new System.Drawing.Size(942, 657);
            this.panelbody.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(186, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 502);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelleft
            // 
            this.panelleft.BackColor = System.Drawing.Color.Brown;
            this.panelleft.Controls.Add(this.btnphieudathang);
            this.panelleft.Controls.Add(this.btndangxuat);
            this.panelleft.Controls.Add(this.btnhdbaohanh);
            this.panelleft.Controls.Add(this.btnhdbanhang);
            this.panelleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelleft.Location = new System.Drawing.Point(0, 0);
            this.panelleft.Name = "panelleft";
            this.panelleft.Size = new System.Drawing.Size(246, 657);
            this.panelleft.TabIndex = 4;
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
            this.btndangxuat.Location = new System.Drawing.Point(32, 598);
            this.btndangxuat.Name = "btndangxuat";
            this.btndangxuat.Size = new System.Drawing.Size(192, 47);
            this.btndangxuat.TabIndex = 10;
            this.btndangxuat.Text = "ĐĂNG XUẤT";
            this.btndangxuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndangxuat.UseVisualStyleBackColor = true;
            this.btndangxuat.Click += new System.EventHandler(this.btndangxuat_Click);
            // 
            // btnhdbaohanh
            // 
            this.btnhdbaohanh.FlatAppearance.BorderSize = 0;
            this.btnhdbaohanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhdbaohanh.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhdbaohanh.ForeColor = System.Drawing.Color.Transparent;
            this.btnhdbaohanh.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnhdbaohanh.IconColor = System.Drawing.Color.Black;
            this.btnhdbaohanh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnhdbaohanh.Location = new System.Drawing.Point(0, 133);
            this.btnhdbaohanh.Name = "btnhdbaohanh";
            this.btnhdbaohanh.Size = new System.Drawing.Size(246, 89);
            this.btnhdbaohanh.TabIndex = 5;
            this.btnhdbaohanh.Text = "HÓA ĐƠN BẢO HÀNH";
            this.btnhdbaohanh.UseVisualStyleBackColor = true;
            this.btnhdbaohanh.Click += new System.EventHandler(this.btnhdbaohanh_Click_1);
            // 
            // btnhdbanhang
            // 
            this.btnhdbanhang.FlatAppearance.BorderSize = 0;
            this.btnhdbanhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhdbanhang.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhdbanhang.ForeColor = System.Drawing.Color.Transparent;
            this.btnhdbanhang.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnhdbanhang.IconColor = System.Drawing.Color.Black;
            this.btnhdbanhang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnhdbanhang.Location = new System.Drawing.Point(-12, 38);
            this.btnhdbanhang.Name = "btnhdbanhang";
            this.btnhdbanhang.Size = new System.Drawing.Size(258, 89);
            this.btnhdbanhang.TabIndex = 4;
            this.btnhdbanhang.Text = "HÓA ĐƠN BÁN HÀNG";
            this.btnhdbanhang.UseVisualStyleBackColor = true;
            this.btnhdbanhang.Click += new System.EventHandler(this.btnhdbanhang_Click_1);
            // 
            // btnphieudathang
            // 
            this.btnphieudathang.FlatAppearance.BorderSize = 0;
            this.btnphieudathang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnphieudathang.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnphieudathang.ForeColor = System.Drawing.Color.Transparent;
            this.btnphieudathang.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnphieudathang.IconColor = System.Drawing.Color.Black;
            this.btnphieudathang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnphieudathang.Location = new System.Drawing.Point(0, 209);
            this.btnphieudathang.Name = "btnphieudathang";
            this.btnphieudathang.Size = new System.Drawing.Size(246, 89);
            this.btnphieudathang.TabIndex = 13;
            this.btnphieudathang.Text = "PHIẾU ĐẶT HÀNG";
            this.btnphieudathang.UseVisualStyleBackColor = true;
            this.btnphieudathang.Click += new System.EventHandler(this.btnphieudathang_Click);
            // 
            // FormHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 657);
            this.Controls.Add(this.panelbody);
            this.Controls.Add(this.panelleft);
            this.Name = "FormHoaDon";
            this.Text = "Hóa đơn";
            this.panelbody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelleft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbody;
        private System.Windows.Forms.Panel panelleft;
        private FontAwesome.Sharp.IconButton btnhdbaohanh;
        private FontAwesome.Sharp.IconButton btnhdbanhang;
        private FontAwesome.Sharp.IconButton btndangxuat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnphieudathang;
    }
}