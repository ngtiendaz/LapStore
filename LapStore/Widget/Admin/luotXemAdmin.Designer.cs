namespace LapStore.Widget.Admin
{
    partial class luotXemAdmin
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
            this.dgvSP = new Guna.UI2.WinForms.Guna2DataGridView();
            this.hinhAnh = new System.Windows.Forms.DataGridViewImageColumn();
            this.maSp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maDm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
            this.cbb_sapXep = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_luotXem = new System.Windows.Forms.Label();
            this.btn_xuatExcel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSP
            // 
            this.dgvSP.AllowUserToAddRows = false;
            this.dgvSP.AllowUserToOrderColumns = true;
            this.dgvSP.AllowUserToResizeColumns = false;
            this.dgvSP.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvSP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSP.ColumnHeadersHeight = 20;
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hinhAnh,
            this.maSp,
            this.maDm,
            this.maHang,
            this.tenSp,
            this.moTa,
            this.giaNhap,
            this.giaBan,
            this.soLuong,
            this.createAt});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSP.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSP.GridColor = System.Drawing.Color.Black;
            this.dgvSP.Location = new System.Drawing.Point(0, 263);
            this.dgvSP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSP.MultiSelect = false;
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.ReadOnly = true;
            this.dgvSP.RowHeadersVisible = false;
            this.dgvSP.RowTemplate.Height = 80;
            this.dgvSP.Size = new System.Drawing.Size(1293, 630);
            this.dgvSP.TabIndex = 28;
            this.dgvSP.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSP.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSP.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvSP.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSP.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSP.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSP.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dgvSP.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Maroon;
            this.dgvSP.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSP.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSP.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvSP.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSP.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvSP.ThemeStyle.ReadOnly = true;
            this.dgvSP.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.Gray;
            this.dgvSP.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSP.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSP.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvSP.ThemeStyle.RowsStyle.Height = 80;
            this.dgvSP.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvSP.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSP_CellClick);
            // 
            // hinhAnh
            // 
            this.hinhAnh.HeaderText = "Hình ảnh";
            this.hinhAnh.MinimumWidth = 30;
            this.hinhAnh.Name = "hinhAnh";
            this.hinhAnh.ReadOnly = true;
            this.hinhAnh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hinhAnh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // maSp
            // 
            this.maSp.HeaderText = "Mã Sản Phẩm";
            this.maSp.Name = "maSp";
            this.maSp.ReadOnly = true;
            // 
            // maDm
            // 
            this.maDm.HeaderText = "Mã Danh Mục";
            this.maDm.Name = "maDm";
            this.maDm.ReadOnly = true;
            // 
            // maHang
            // 
            this.maHang.HeaderText = "Mã hãng";
            this.maHang.Name = "maHang";
            this.maHang.ReadOnly = true;
            // 
            // tenSp
            // 
            this.tenSp.HeaderText = "Tên Sản Phẩm";
            this.tenSp.Name = "tenSp";
            this.tenSp.ReadOnly = true;
            // 
            // moTa
            // 
            this.moTa.HeaderText = "Mô Tả";
            this.moTa.Name = "moTa";
            this.moTa.ReadOnly = true;
            // 
            // giaNhap
            // 
            this.giaNhap.HeaderText = "Giá Nhập";
            this.giaNhap.Name = "giaNhap";
            this.giaNhap.ReadOnly = true;
            // 
            // giaBan
            // 
            this.giaBan.HeaderText = "Giá Bán";
            this.giaBan.Name = "giaBan";
            this.giaBan.ReadOnly = true;
            // 
            // soLuong
            // 
            this.soLuong.HeaderText = "Số Lượng";
            this.soLuong.Name = "soLuong";
            this.soLuong.ReadOnly = true;
            // 
            // createAt
            // 
            this.createAt.HeaderText = "CreateAt";
            this.createAt.Name = "createAt";
            this.createAt.ReadOnly = true;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(20, 17);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(257, 39);
            this.guna2HtmlLabel1.TabIndex = 62;
            this.guna2HtmlLabel1.Text = "Xếp hạng lượt xem";
            // 
            // btnLoc
            // 
            this.btnLoc.BorderColor = System.Drawing.Color.Transparent;
            this.btnLoc.BorderRadius = 10;
            this.btnLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoc.FillColor = System.Drawing.Color.Maroon;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(407, 113);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(139, 44);
            this.btnLoc.TabIndex = 64;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cbb_sapXep
            // 
            this.cbb_sapXep.BackColor = System.Drawing.Color.Transparent;
            this.cbb_sapXep.BorderRadius = 10;
            this.cbb_sapXep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_sapXep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_sapXep.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_sapXep.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_sapXep.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_sapXep.ForeColor = System.Drawing.Color.Black;
            this.cbb_sapXep.ItemHeight = 30;
            this.cbb_sapXep.Location = new System.Drawing.Point(20, 113);
            this.cbb_sapXep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbb_sapXep.Name = "cbb_sapXep";
            this.cbb_sapXep.Size = new System.Drawing.Size(341, 36);
            this.cbb_sapXep.TabIndex = 63;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(663, 113);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(132, 39);
            this.guna2HtmlLabel2.TabIndex = 65;
            this.guna2HtmlLabel2.Text = "Lượt xem:";
            // 
            // txt_luotXem
            // 
            this.txt_luotXem.AutoSize = true;
            this.txt_luotXem.BackColor = System.Drawing.Color.Transparent;
            this.txt_luotXem.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.txt_luotXem.ForeColor = System.Drawing.Color.White;
            this.txt_luotXem.Location = new System.Drawing.Point(895, 116);
            this.txt_luotXem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt_luotXem.Name = "txt_luotXem";
            this.txt_luotXem.Size = new System.Drawing.Size(33, 37);
            this.txt_luotXem.TabIndex = 66;
            this.txt_luotXem.Text = "0";
            // 
            // btn_xuatExcel
            // 
            this.btn_xuatExcel.BorderColor = System.Drawing.Color.Transparent;
            this.btn_xuatExcel.BorderRadius = 10;
            this.btn_xuatExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xuatExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xuatExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xuatExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xuatExcel.FillColor = System.Drawing.Color.Maroon;
            this.btn_xuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_xuatExcel.ForeColor = System.Drawing.Color.White;
            this.btn_xuatExcel.Location = new System.Drawing.Point(1137, 17);
            this.btn_xuatExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_xuatExcel.Name = "btn_xuatExcel";
            this.btn_xuatExcel.Size = new System.Drawing.Size(139, 44);
            this.btn_xuatExcel.TabIndex = 67;
            this.btn_xuatExcel.Text = "Xuất excel";
            this.btn_xuatExcel.Click += new System.EventHandler(this.btn_xuatExcel_Click);
            // 
            // luotXemAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.btn_xuatExcel);
            this.Controls.Add(this.txt_luotXem);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.cbb_sapXep);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.dgvSP);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1293, 923);
            this.MinimumSize = new System.Drawing.Size(1293, 923);
            this.Name = "luotXemAdmin";
            this.Size = new System.Drawing.Size(1293, 923);
            this.Load += new System.EventHandler(this.luotXemAdmin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.luotXemAdmin_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvSP;
        private System.Windows.Forms.DataGridViewImageColumn hinhAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSp;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDm;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSp;
        private System.Windows.Forms.DataGridViewTextBoxColumn moTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn createAt;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnLoc;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_sapXep;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private System.Windows.Forms.Label txt_luotXem;
        private Guna.UI2.WinForms.Guna2Button btn_xuatExcel;
    }
}
