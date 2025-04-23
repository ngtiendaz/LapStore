namespace LapStore.Widget.Admin
{
    partial class doanhThuAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDoanhThu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.maDonHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_traCuu = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbb_thang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_loiNhuan = new System.Windows.Forms.Label();
            this.txt_doanhThu = new System.Windows.Forms.Label();
            this.txt_von = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_xuatE = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToOrderColumns = true;
            this.dgvDoanhThu.AllowUserToResizeColumns = false;
            this.dgvDoanhThu.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDoanhThu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvDoanhThu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDoanhThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDoanhThu.ColumnHeadersHeight = 20;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDoanhThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maDonHang,
            this.tongTien,
            this.thoiGian});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDoanhThu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDoanhThu.GridColor = System.Drawing.Color.Black;
            this.dgvDoanhThu.Location = new System.Drawing.Point(455, 2);
            this.dgvDoanhThu.MultiSelect = false;
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.RowHeadersVisible = false;
            this.dgvDoanhThu.RowTemplate.Height = 80;
            this.dgvDoanhThu.Size = new System.Drawing.Size(512, 747);
            this.dgvDoanhThu.TabIndex = 38;
            this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDoanhThu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDoanhThu.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvDoanhThu.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Maroon;
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDoanhThu.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvDoanhThu.ThemeStyle.ReadOnly = true;
            this.dgvDoanhThu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.Gray;
            this.dgvDoanhThu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDoanhThu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDoanhThu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDoanhThu.ThemeStyle.RowsStyle.Height = 80;
            this.dgvDoanhThu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvDoanhThu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // maDonHang
            // 
            this.maDonHang.HeaderText = "Mã đơn hàng";
            this.maDonHang.Name = "maDonHang";
            this.maDonHang.ReadOnly = true;
            // 
            // tongTien
            // 
            this.tongTien.HeaderText = "Tổng tiền";
            this.tongTien.Name = "tongTien";
            this.tongTien.ReadOnly = true;
            // 
            // thoiGian
            // 
            this.thoiGian.HeaderText = "Thời gian";
            this.thoiGian.Name = "thoiGian";
            this.thoiGian.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Tháng:";
            // 
            // btn_traCuu
            // 
            this.btn_traCuu.BackColor = System.Drawing.Color.Transparent;
            this.btn_traCuu.BorderRadius = 15;
            this.btn_traCuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_traCuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_traCuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_traCuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_traCuu.FillColor = System.Drawing.Color.Maroon;
            this.btn_traCuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_traCuu.ForeColor = System.Drawing.Color.White;
            this.btn_traCuu.Location = new System.Drawing.Point(326, 98);
            this.btn_traCuu.Name = "btn_traCuu";
            this.btn_traCuu.Size = new System.Drawing.Size(80, 36);
            this.btn_traCuu.TabIndex = 40;
            this.btn_traCuu.Text = "Tra cứu";
            this.btn_traCuu.Click += new System.EventHandler(this.btn_traCuu_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 14);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(142, 39);
            this.guna2HtmlLabel1.TabIndex = 39;
            this.guna2HtmlLabel1.Text = "Doanh thu";
            // 
            // cbb_thang
            // 
            this.cbb_thang.BackColor = System.Drawing.Color.Transparent;
            this.cbb_thang.BorderRadius = 10;
            this.cbb_thang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_thang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_thang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_thang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_thang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_thang.ForeColor = System.Drawing.Color.Black;
            this.cbb_thang.ItemHeight = 30;
            this.cbb_thang.Location = new System.Drawing.Point(147, 98);
            this.cbb_thang.Name = "cbb_thang";
            this.cbb_thang.Size = new System.Drawing.Size(134, 36);
            this.cbb_thang.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 51;
            this.label3.Text = "Lợi nhuận:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 442);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 50;
            this.label4.Text = "Doanh thu:";
            // 
            // txt_loiNhuan
            // 
            this.txt_loiNhuan.BackColor = System.Drawing.Color.Transparent;
            this.txt_loiNhuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_loiNhuan.ForeColor = System.Drawing.Color.White;
            this.txt_loiNhuan.Location = new System.Drawing.Point(238, 501);
            this.txt_loiNhuan.Name = "txt_loiNhuan";
            this.txt_loiNhuan.Size = new System.Drawing.Size(168, 15);
            this.txt_loiNhuan.TabIndex = 53;
            this.txt_loiNhuan.Text = "Tháng:";
            this.txt_loiNhuan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_doanhThu
            // 
            this.txt_doanhThu.BackColor = System.Drawing.Color.Transparent;
            this.txt_doanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_doanhThu.ForeColor = System.Drawing.Color.White;
            this.txt_doanhThu.Location = new System.Drawing.Point(211, 442);
            this.txt_doanhThu.Name = "txt_doanhThu";
            this.txt_doanhThu.Size = new System.Drawing.Size(195, 15);
            this.txt_doanhThu.TabIndex = 52;
            this.txt_doanhThu.Text = "Danh mục:";
            this.txt_doanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_von
            // 
            this.txt_von.BackColor = System.Drawing.Color.Transparent;
            this.txt_von.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.txt_von.ForeColor = System.Drawing.Color.White;
            this.txt_von.Location = new System.Drawing.Point(241, 386);
            this.txt_von.Name = "txt_von";
            this.txt_von.Size = new System.Drawing.Size(165, 15);
            this.txt_von.TabIndex = 55;
            this.txt_von.Text = "Tháng:";
            this.txt_von.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(17, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 54;
            this.label8.Text = "Tiền vốn:";
            // 
            // btn_xuatE
            // 
            this.btn_xuatE.BackColor = System.Drawing.Color.Transparent;
            this.btn_xuatE.BorderRadius = 15;
            this.btn_xuatE.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xuatE.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xuatE.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xuatE.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xuatE.FillColor = System.Drawing.Color.Maroon;
            this.btn_xuatE.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_xuatE.ForeColor = System.Drawing.Color.White;
            this.btn_xuatE.Location = new System.Drawing.Point(307, 589);
            this.btn_xuatE.Name = "btn_xuatE";
            this.btn_xuatE.Size = new System.Drawing.Size(102, 37);
            this.btn_xuatE.TabIndex = 56;
            this.btn_xuatE.Text = "Xuất excel";
            // 
            // doanhThuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.btn_xuatE);
            this.Controls.Add(this.txt_von);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_loiNhuan);
            this.Controls.Add(this.txt_doanhThu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbb_thang);
            this.Controls.Add(this.dgvDoanhThu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_traCuu);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.MaximumSize = new System.Drawing.Size(970, 750);
            this.MinimumSize = new System.Drawing.Size(970, 750);
            this.Name = "doanhThuAdmin";
            this.Size = new System.Drawing.Size(970, 750);
            this.Load += new System.EventHandler(this.doanhThuAdmin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.doanhThuAdmin_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvDoanhThu;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_traCuu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_thang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txt_loiNhuan;
        private System.Windows.Forms.Label txt_doanhThu;
        private System.Windows.Forms.Label txt_von;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn thoiGian;
        private Guna.UI2.WinForms.Guna2Button btn_xuatE;
    }
}
