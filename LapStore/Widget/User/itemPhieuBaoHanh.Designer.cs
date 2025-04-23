namespace LapStore.Widget.User
{
    partial class itemPhieuBaoHanh
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_soLuong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_dung = new Guna.UI2.WinForms.Guna2Button();
            this.txt_thoiHan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_gia = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_tenPhieu = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_soLuong
            // 
            this.txt_soLuong.BackColor = System.Drawing.Color.Transparent;
            this.txt_soLuong.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_soLuong.Location = new System.Drawing.Point(395, 61);
            this.txt_soLuong.Name = "txt_soLuong";
            this.txt_soLuong.Size = new System.Drawing.Size(57, 19);
            this.txt_soLuong.TabIndex = 13;
            this.txt_soLuong.Text = "Còn lại: 1";
            this.txt_soLuong.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_dung
            // 
            this.btn_dung.BackColor = System.Drawing.Color.Transparent;
            this.btn_dung.BorderColor = System.Drawing.Color.Maroon;
            this.btn_dung.BorderRadius = 10;
            this.btn_dung.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            this.btn_dung.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_dung.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_dung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_dung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_dung.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_dung.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_dung.ForeColor = System.Drawing.Color.White;
            this.btn_dung.Location = new System.Drawing.Point(395, 21);
            this.btn_dung.Name = "btn_dung";
            this.btn_dung.Size = new System.Drawing.Size(96, 34);
            this.btn_dung.TabIndex = 12;
            this.btn_dung.Text = "Chọn";
            this.btn_dung.UseTransparentBackground = true;
            this.btn_dung.Click += new System.EventHandler(this.btn_dung_Click_1);
            // 
            // txt_thoiHan
            // 
            this.txt_thoiHan.BackColor = System.Drawing.Color.Transparent;
            this.txt_thoiHan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_thoiHan.Location = new System.Drawing.Point(106, 62);
            this.txt_thoiHan.Name = "txt_thoiHan";
            this.txt_thoiHan.Size = new System.Drawing.Size(170, 19);
            this.txt_thoiHan.TabIndex = 11;
            this.txt_thoiHan.Text = "Thời hạn bảo hành: 6 tháng";
            // 
            // txt_gia
            // 
            this.txt_gia.BackColor = System.Drawing.Color.Transparent;
            this.txt_gia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gia.Location = new System.Drawing.Point(106, 37);
            this.txt_gia.Name = "txt_gia";
            this.txt_gia.Size = new System.Drawing.Size(57, 19);
            this.txt_gia.TabIndex = 10;
            this.txt_gia.Text = "300.000đ";
            // 
            // txt_tenPhieu
            // 
            this.txt_tenPhieu.BackColor = System.Drawing.Color.Transparent;
            this.txt_tenPhieu.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenPhieu.Location = new System.Drawing.Point(106, 4);
            this.txt_tenPhieu.Name = "txt_tenPhieu";
            this.txt_tenPhieu.Size = new System.Drawing.Size(189, 27);
            this.txt_tenPhieu.TabIndex = 9;
            this.txt_tenPhieu.Text = "Gói bảo hành 1 đổi 1";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::LapStore.Properties.Resources.OIP;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(9, 4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(91, 93);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 8;
            this.guna2PictureBox1.TabStop = false;
            // 
            // itemPhieuBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txt_soLuong);
            this.Controls.Add(this.btn_dung);
            this.Controls.Add(this.txt_thoiHan);
            this.Controls.Add(this.txt_gia);
            this.Controls.Add(this.txt_tenPhieu);
            this.Controls.Add(this.guna2PictureBox1);
            this.MaximumSize = new System.Drawing.Size(500, 100);
            this.MinimumSize = new System.Drawing.Size(500, 100);
            this.Name = "itemPhieuBaoHanh";
            this.Size = new System.Drawing.Size(500, 100);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel txt_soLuong;
        private Guna.UI2.WinForms.Guna2Button btn_dung;
        private Guna.UI2.WinForms.Guna2HtmlLabel txt_thoiHan;
        private Guna.UI2.WinForms.Guna2HtmlLabel txt_gia;
        private Guna.UI2.WinForms.Guna2HtmlLabel txt_tenPhieu;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
