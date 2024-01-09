namespace HM0905
{
    partial class FormKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKho));
            this.panelbody = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelleft = new System.Windows.Forms.Panel();
            this.btndangxuat = new FontAwesome.Sharp.IconButton();
            this.btnxuatkho = new FontAwesome.Sharp.IconButton();
            this.btnnhapkho = new FontAwesome.Sharp.IconButton();
            this.btnkiemhang = new FontAwesome.Sharp.IconButton();
            this.panelbody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelleft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelbody
            // 
            this.panelbody.BackColor = System.Drawing.Color.Snow;
            this.panelbody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelbody.Controls.Add(this.pictureBox1);
            this.panelbody.Location = new System.Drawing.Point(249, 0);
            this.panelbody.Name = "panelbody";
            this.panelbody.Size = new System.Drawing.Size(1013, 656);
            this.panelbody.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(164, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 502);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelleft
            // 
            this.panelleft.BackColor = System.Drawing.Color.Brown;
            this.panelleft.Controls.Add(this.btndangxuat);
            this.panelleft.Controls.Add(this.btnxuatkho);
            this.panelleft.Controls.Add(this.btnnhapkho);
            this.panelleft.Controls.Add(this.btnkiemhang);
            this.panelleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelleft.Location = new System.Drawing.Point(0, 0);
            this.panelleft.Name = "panelleft";
            this.panelleft.Size = new System.Drawing.Size(246, 666);
            this.panelleft.TabIndex = 0;
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
            this.btndangxuat.Location = new System.Drawing.Point(25, 554);
            this.btndangxuat.Name = "btndangxuat";
            this.btndangxuat.Size = new System.Drawing.Size(197, 47);
            this.btndangxuat.TabIndex = 8;
            this.btndangxuat.Text = "ĐĂNG XUẤT";
            this.btndangxuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndangxuat.UseVisualStyleBackColor = true;
            this.btndangxuat.Click += new System.EventHandler(this.btndangxuat_Click);
            // 
            // btnxuatkho
            // 
            this.btnxuatkho.FlatAppearance.BorderSize = 0;
            this.btnxuatkho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxuatkho.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxuatkho.ForeColor = System.Drawing.Color.Transparent;
            this.btnxuatkho.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnxuatkho.IconColor = System.Drawing.Color.Black;
            this.btnxuatkho.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnxuatkho.Location = new System.Drawing.Point(0, 252);
            this.btnxuatkho.Name = "btnxuatkho";
            this.btnxuatkho.Size = new System.Drawing.Size(246, 89);
            this.btnxuatkho.TabIndex = 7;
            this.btnxuatkho.Text = "XUẤT KHO";
            this.btnxuatkho.UseVisualStyleBackColor = true;
            this.btnxuatkho.Click += new System.EventHandler(this.btnxuatkho_Click_1);
            // 
            // btnnhapkho
            // 
            this.btnnhapkho.FlatAppearance.BorderSize = 0;
            this.btnnhapkho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnhapkho.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnhapkho.ForeColor = System.Drawing.Color.Transparent;
            this.btnnhapkho.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnnhapkho.IconColor = System.Drawing.Color.Black;
            this.btnnhapkho.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnnhapkho.Location = new System.Drawing.Point(0, 142);
            this.btnnhapkho.Name = "btnnhapkho";
            this.btnnhapkho.Size = new System.Drawing.Size(246, 104);
            this.btnnhapkho.TabIndex = 6;
            this.btnnhapkho.Text = "NHẬP KHO";
            this.btnnhapkho.UseVisualStyleBackColor = true;
            this.btnnhapkho.Click += new System.EventHandler(this.btnnhapkho_Click_1);
            // 
            // btnkiemhang
            // 
            this.btnkiemhang.FlatAppearance.BorderSize = 0;
            this.btnkiemhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnkiemhang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnkiemhang.ForeColor = System.Drawing.Color.Transparent;
            this.btnkiemhang.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnkiemhang.IconColor = System.Drawing.Color.Black;
            this.btnkiemhang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnkiemhang.Location = new System.Drawing.Point(0, 47);
            this.btnkiemhang.Name = "btnkiemhang";
            this.btnkiemhang.Size = new System.Drawing.Size(243, 89);
            this.btnkiemhang.TabIndex = 4;
            this.btnkiemhang.Text = "KIỂM HÀNG";
            this.btnkiemhang.UseVisualStyleBackColor = true;
            this.btnkiemhang.Click += new System.EventHandler(this.btnkiemhang_Click_1);
            // 
            // FormKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1267, 666);
            this.Controls.Add(this.panelleft);
            this.Controls.Add(this.panelbody);
            this.Name = "FormKho";
            this.Text = "Kho";
            this.Load += new System.EventHandler(this.FormKho_Load);
            this.panelbody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelleft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelbody;
        private System.Windows.Forms.Panel panelleft;
        private FontAwesome.Sharp.IconButton btnxuatkho;
        private FontAwesome.Sharp.IconButton btnnhapkho;
        private FontAwesome.Sharp.IconButton btnkiemhang;
        private FontAwesome.Sharp.IconButton btndangxuat;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}