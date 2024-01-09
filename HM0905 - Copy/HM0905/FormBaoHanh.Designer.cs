namespace HM0905
{
    partial class FormBaoHanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaoHanh));
            this.panelbody = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelleft = new System.Windows.Forms.Panel();
            this.btndangxuat = new FontAwesome.Sharp.IconButton();
            this.btndmbaohanh = new FontAwesome.Sharp.IconButton();
            this.btnphieubaohanh = new FontAwesome.Sharp.IconButton();
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
            this.panelbody.Size = new System.Drawing.Size(947, 634);
            this.panelbody.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(152, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 502);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelleft
            // 
            this.panelleft.BackColor = System.Drawing.Color.Brown;
            this.panelleft.Controls.Add(this.btndangxuat);
            this.panelleft.Controls.Add(this.btndmbaohanh);
            this.panelleft.Controls.Add(this.btnphieubaohanh);
            this.panelleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelleft.Location = new System.Drawing.Point(0, 0);
            this.panelleft.Name = "panelleft";
            this.panelleft.Size = new System.Drawing.Size(246, 634);
            this.panelleft.TabIndex = 6;
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
            this.btndangxuat.Location = new System.Drawing.Point(36, 575);
            this.btndangxuat.Name = "btndangxuat";
            this.btndangxuat.Size = new System.Drawing.Size(186, 47);
            this.btndangxuat.TabIndex = 11;
            this.btndangxuat.Text = "ĐĂNG XUẤT";
            this.btndangxuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndangxuat.UseVisualStyleBackColor = true;
            this.btndangxuat.Click += new System.EventHandler(this.btndangxuat_Click);
            // 
            // btndmbaohanh
            // 
            this.btndmbaohanh.FlatAppearance.BorderSize = 0;
            this.btndmbaohanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndmbaohanh.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndmbaohanh.ForeColor = System.Drawing.Color.Transparent;
            this.btndmbaohanh.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btndmbaohanh.IconColor = System.Drawing.Color.Black;
            this.btndmbaohanh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndmbaohanh.Location = new System.Drawing.Point(0, 150);
            this.btndmbaohanh.Name = "btndmbaohanh";
            this.btndmbaohanh.Size = new System.Drawing.Size(253, 89);
            this.btndmbaohanh.TabIndex = 5;
            this.btndmbaohanh.Text = "DANH MỤC BẢO HÀNH";
            this.btndmbaohanh.UseVisualStyleBackColor = true;
            this.btndmbaohanh.Click += new System.EventHandler(this.btndmbaohanh_Click_1);
            // 
            // btnphieubaohanh
            // 
            this.btnphieubaohanh.FlatAppearance.BorderSize = 0;
            this.btnphieubaohanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnphieubaohanh.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnphieubaohanh.ForeColor = System.Drawing.Color.Transparent;
            this.btnphieubaohanh.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnphieubaohanh.IconColor = System.Drawing.Color.Black;
            this.btnphieubaohanh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnphieubaohanh.Location = new System.Drawing.Point(0, 44);
            this.btnphieubaohanh.Name = "btnphieubaohanh";
            this.btnphieubaohanh.Size = new System.Drawing.Size(253, 89);
            this.btnphieubaohanh.TabIndex = 4;
            this.btnphieubaohanh.Text = "PHIẾU BẢO HÀNH";
            this.btnphieubaohanh.UseVisualStyleBackColor = true;
            this.btnphieubaohanh.Click += new System.EventHandler(this.btnphieubaohanh_Click_1);
            // 
            // FormBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 634);
            this.Controls.Add(this.panelbody);
            this.Controls.Add(this.panelleft);
            this.Name = "FormBaoHanh";
            this.Text = "Bảo hành";
            this.panelbody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelleft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbody;
        private System.Windows.Forms.Panel panelleft;
        private FontAwesome.Sharp.IconButton btndmbaohanh;
        private FontAwesome.Sharp.IconButton btnphieubaohanh;
        private FontAwesome.Sharp.IconButton btndangxuat;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}