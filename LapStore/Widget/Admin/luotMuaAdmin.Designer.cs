namespace LapStore.Widget.Admin
{
    partial class luotMuaAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDonHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvChiTietDonHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.cbb_thang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_traCuu = new Guna.UI2.WinForms.Guna2Button();
            this.madh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hinhAnh = new System.Windows.Forms.DataGridViewImageColumn();
            this.maSp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.AllowUserToAddRows = false;
            this.dgvDonHang.AllowUserToOrderColumns = true;
            this.dgvDonHang.AllowUserToResizeColumns = false;
            this.dgvDonHang.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDonHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvDonHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDonHang.ColumnHeadersHeight = 20;
            this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDonHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.madh,
            this.maUser,
            this.tongtien,
            this.createat});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDonHang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDonHang.GridColor = System.Drawing.Color.Black;
            this.dgvDonHang.Location = new System.Drawing.Point(0, 175);
            this.dgvDonHang.MultiSelect = false;
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.ReadOnly = true;
            this.dgvDonHang.RowHeadersVisible = false;
            this.dgvDonHang.RowTemplate.Height = 80;
            this.dgvDonHang.Size = new System.Drawing.Size(451, 552);
            this.dgvDonHang.TabIndex = 83;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDonHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDonHang.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dgvDonHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Maroon;
            this.dgvDonHang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDonHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDonHang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDonHang.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvDonHang.ThemeStyle.ReadOnly = true;
            this.dgvDonHang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.Gray;
            this.dgvDonHang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDonHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDonHang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDonHang.ThemeStyle.RowsStyle.Height = 80;
            this.dgvDonHang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvDonHang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDonHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonHang_CellClick);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(27, 6);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(131, 39);
            this.guna2HtmlLabel1.TabIndex = 66;
            this.guna2HtmlLabel1.Text = "Lượt mua";
            // 
            // dgvChiTietDonHang
            // 
            this.dgvChiTietDonHang.AllowUserToAddRows = false;
            this.dgvChiTietDonHang.AllowUserToOrderColumns = true;
            this.dgvChiTietDonHang.AllowUserToResizeColumns = false;
            this.dgvChiTietDonHang.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvChiTietDonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChiTietDonHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvChiTietDonHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvChiTietDonHang.ColumnHeadersHeight = 20;
            this.dgvChiTietDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChiTietDonHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hinhAnh,
            this.maSp,
            this.tenSp});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietDonHang.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChiTietDonHang.GridColor = System.Drawing.Color.Black;
            this.dgvChiTietDonHang.Location = new System.Drawing.Point(518, 175);
            this.dgvChiTietDonHang.MultiSelect = false;
            this.dgvChiTietDonHang.Name = "dgvChiTietDonHang";
            this.dgvChiTietDonHang.ReadOnly = true;
            this.dgvChiTietDonHang.RowHeadersVisible = false;
            this.dgvChiTietDonHang.RowTemplate.Height = 80;
            this.dgvChiTietDonHang.Size = new System.Drawing.Size(449, 552);
            this.dgvChiTietDonHang.TabIndex = 84;
            this.dgvChiTietDonHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTietDonHang.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChiTietDonHang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvChiTietDonHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvChiTietDonHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvChiTietDonHang.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTietDonHang.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dgvChiTietDonHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Maroon;
            this.dgvChiTietDonHang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvChiTietDonHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChiTietDonHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvChiTietDonHang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChiTietDonHang.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvChiTietDonHang.ThemeStyle.ReadOnly = true;
            this.dgvChiTietDonHang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.Gray;
            this.dgvChiTietDonHang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTietDonHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChiTietDonHang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvChiTietDonHang.ThemeStyle.RowsStyle.Height = 80;
            this.dgvChiTietDonHang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvChiTietDonHang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Image = global::LapStore.Properties.Resources.icons8_arrow_32r21;
            this.guna2Button1.ImageSize = new System.Drawing.Size(50, 50);
            this.guna2Button1.Location = new System.Drawing.Point(457, 422);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(55, 45);
            this.guna2Button1.TabIndex = 85;
            this.guna2Button1.UseTransparentBackground = true;
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
            this.cbb_thang.Location = new System.Drawing.Point(111, 73);
            this.cbb_thang.Name = "cbb_thang";
            this.cbb_thang.Size = new System.Drawing.Size(205, 36);
            this.cbb_thang.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 87;
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
            this.btn_traCuu.Location = new System.Drawing.Point(326, 73);
            this.btn_traCuu.Name = "btn_traCuu";
            this.btn_traCuu.Size = new System.Drawing.Size(80, 36);
            this.btn_traCuu.TabIndex = 86;
            this.btn_traCuu.Text = "Tìm";
            this.btn_traCuu.Click += new System.EventHandler(this.btn_traCuu_Click);
            // 
            // madh
            // 
            this.madh.HeaderText = "Mã đơn hàng";
            this.madh.Name = "madh";
            this.madh.ReadOnly = true;
            // 
            // maUser
            // 
            this.maUser.HeaderText = "Mã User";
            this.maUser.Name = "maUser";
            this.maUser.ReadOnly = true;
            // 
            // tongtien
            // 
            this.tongtien.HeaderText = "Tổng tiền";
            this.tongtien.Name = "tongtien";
            this.tongtien.ReadOnly = true;
            // 
            // createat
            // 
            this.createat.HeaderText = "Create At";
            this.createat.Name = "createat";
            this.createat.ReadOnly = true;
            // 
            // hinhAnh
            // 
            this.hinhAnh.HeaderText = "Hình ảnh";
            this.hinhAnh.Name = "hinhAnh";
            this.hinhAnh.ReadOnly = true;
            this.hinhAnh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hinhAnh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // maSp
            // 
            this.maSp.HeaderText = "Mã sản phẩm";
            this.maSp.Name = "maSp";
            this.maSp.ReadOnly = true;
            // 
            // tenSp
            // 
            this.tenSp.HeaderText = "Tên sản phẩm";
            this.tenSp.Name = "tenSp";
            this.tenSp.ReadOnly = true;
            // 
            // luotMuaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.cbb_thang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_traCuu);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.dgvChiTietDonHang);
            this.Controls.Add(this.dgvDonHang);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.MaximumSize = new System.Drawing.Size(970, 750);
            this.MinimumSize = new System.Drawing.Size(970, 750);
            this.Name = "luotMuaAdmin";
            this.Size = new System.Drawing.Size(970, 750);
            this.Load += new System.EventHandler(this.luotMuaAdmin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.luotMuaAdmin_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvDonHang;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTietDonHang;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn madh;
        private System.Windows.Forms.DataGridViewTextBoxColumn maUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.DataGridViewTextBoxColumn createat;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_thang;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_traCuu;
        private System.Windows.Forms.DataGridViewImageColumn hinhAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSp;
    }
}
