namespace HM0905
{
    partial class FormSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSanPham));
            this.panelbody = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelleft = new System.Windows.Forms.Panel();
            this.btndangxuat = new FontAwesome.Sharp.IconButton();
            this.btncolor = new FontAwesome.Sharp.IconButton();
            this.btnmodel = new FontAwesome.Sharp.IconButton();
            this.btnnhomhang = new FontAwesome.Sharp.IconButton();
            this.btndssp = new FontAwesome.Sharp.IconButton();
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
            this.panelbody.Location = new System.Drawing.Point(0, 0);
            this.panelbody.Name = "panelbody";
            this.panelbody.Size = new System.Drawing.Size(1188, 671);
            this.panelbody.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(465, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 502);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelleft
            // 
            this.panelleft.BackColor = System.Drawing.Color.Brown;
            this.panelleft.Controls.Add(this.btndangxuat);
            this.panelleft.Controls.Add(this.btncolor);
            this.panelleft.Controls.Add(this.btnmodel);
            this.panelleft.Controls.Add(this.btnnhomhang);
            this.panelleft.Controls.Add(this.btndssp);
            this.panelleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelleft.Location = new System.Drawing.Point(0, 0);
            this.panelleft.Name = "panelleft";
            this.panelleft.Size = new System.Drawing.Size(248, 671);
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
            this.btndangxuat.Location = new System.Drawing.Point(30, 586);
            this.btndangxuat.Name = "btndangxuat";
            this.btndangxuat.Size = new System.Drawing.Size(184, 47);
            this.btndangxuat.TabIndex = 9;
            this.btndangxuat.Text = "ĐĂNG XUẤT";
            this.btndangxuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndangxuat.UseVisualStyleBackColor = true;
            // 
            // btncolor
            // 
            this.btncolor.BackColor = System.Drawing.Color.Brown;
            this.btncolor.FlatAppearance.BorderSize = 0;
            this.btncolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncolor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncolor.ForeColor = System.Drawing.Color.Transparent;
            this.btncolor.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btncolor.IconColor = System.Drawing.Color.Black;
            this.btncolor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncolor.Location = new System.Drawing.Point(5, 289);
            this.btncolor.Name = "btncolor";
            this.btncolor.Size = new System.Drawing.Size(243, 82);
            this.btncolor.TabIndex = 8;
            this.btncolor.Text = "MÀU SẮC";
            this.btncolor.UseVisualStyleBackColor = false;
            this.btncolor.Click += new System.EventHandler(this.btncolor_Click_1);
            // 
            // btnmodel
            // 
            this.btnmodel.BackColor = System.Drawing.Color.Brown;
            this.btnmodel.FlatAppearance.BorderSize = 0;
            this.btnmodel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmodel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmodel.ForeColor = System.Drawing.Color.Transparent;
            this.btnmodel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnmodel.IconColor = System.Drawing.Color.Black;
            this.btnmodel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnmodel.Location = new System.Drawing.Point(2, 201);
            this.btnmodel.Name = "btnmodel";
            this.btnmodel.Size = new System.Drawing.Size(243, 82);
            this.btnmodel.TabIndex = 7;
            this.btnmodel.Text = "KIỂU MẪU";
            this.btnmodel.UseVisualStyleBackColor = false;
            this.btnmodel.Click += new System.EventHandler(this.btnmodel_Click_1);
            // 
            // btnnhomhang
            // 
            this.btnnhomhang.BackColor = System.Drawing.Color.Brown;
            this.btnnhomhang.FlatAppearance.BorderSize = 0;
            this.btnnhomhang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnhomhang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnhomhang.ForeColor = System.Drawing.Color.Transparent;
            this.btnnhomhang.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnnhomhang.IconColor = System.Drawing.Color.Black;
            this.btnnhomhang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnnhomhang.Location = new System.Drawing.Point(3, 113);
            this.btnnhomhang.Name = "btnnhomhang";
            this.btnnhomhang.Size = new System.Drawing.Size(243, 82);
            this.btnnhomhang.TabIndex = 6;
            this.btnnhomhang.Text = "NHÓM HÀNG";
            this.btnnhomhang.UseVisualStyleBackColor = false;
            this.btnnhomhang.Click += new System.EventHandler(this.btnnhomhang_Click_1);
            // 
            // btndssp
            // 
            this.btndssp.BackColor = System.Drawing.Color.Brown;
            this.btndssp.FlatAppearance.BorderSize = 0;
            this.btndssp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndssp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndssp.ForeColor = System.Drawing.Color.Transparent;
            this.btndssp.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btndssp.IconColor = System.Drawing.Color.Black;
            this.btndssp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndssp.Location = new System.Drawing.Point(5, 25);
            this.btndssp.Name = "btndssp";
            this.btndssp.Size = new System.Drawing.Size(243, 82);
            this.btndssp.TabIndex = 5;
            this.btndssp.Text = " SẢN PHẨM";
            this.btndssp.UseVisualStyleBackColor = false;
            this.btndssp.Click += new System.EventHandler(this.btndssp_Click_1);
            // 
            // FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 671);
            this.Controls.Add(this.panelleft);
            this.Controls.Add(this.panelbody);
            this.Name = "FormSanPham";
            this.Text = "Sản phẩm";
            this.Load += new System.EventHandler(this.FormSanPham_Load);
            this.panelbody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelleft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelleft;
        private System.Windows.Forms.Panel panelbody;
        private FontAwesome.Sharp.IconButton btncolor;
        private FontAwesome.Sharp.IconButton btnmodel;
        private FontAwesome.Sharp.IconButton btnnhomhang;
        private FontAwesome.Sharp.IconButton btndssp;
        private FontAwesome.Sharp.IconButton btndangxuat;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}