namespace LapStore.Widget.Admin
{
    partial class maGiamGiaAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMaGiamGia = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_tenMa = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_id = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_sua = new Guna.UI2.WinForms.Guna2Button();
            this.btn_luu = new Guna.UI2.WinForms.Guna2Button();
            this.btn_themMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btn_xoa = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_phanTramGiam = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_soLuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.date_batDau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.date_ketThuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_giaApDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phanTramGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dieuKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaGiamGia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMaGiamGia
            // 
            this.dgvMaGiamGia.AllowUserToAddRows = false;
            this.dgvMaGiamGia.AllowUserToOrderColumns = true;
            this.dgvMaGiamGia.AllowUserToResizeColumns = false;
            this.dgvMaGiamGia.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.dgvMaGiamGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvMaGiamGia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvMaGiamGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvMaGiamGia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaGiamGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvMaGiamGia.ColumnHeadersHeight = 20;
            this.dgvMaGiamGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvMaGiamGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tenMa,
            this.phanTramGiam,
            this.soLuong,
            this.ngayBatDau,
            this.ngayKetThuc,
            this.dieuKien});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaGiamGia.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvMaGiamGia.GridColor = System.Drawing.Color.Black;
            this.dgvMaGiamGia.Location = new System.Drawing.Point(0, 409);
            this.dgvMaGiamGia.MultiSelect = false;
            this.dgvMaGiamGia.Name = "dgvMaGiamGia";
            this.dgvMaGiamGia.ReadOnly = true;
            this.dgvMaGiamGia.RowHeadersVisible = false;
            this.dgvMaGiamGia.RowTemplate.Height = 80;
            this.dgvMaGiamGia.Size = new System.Drawing.Size(970, 340);
            this.dgvMaGiamGia.TabIndex = 38;
            this.dgvMaGiamGia.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvMaGiamGia.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMaGiamGia.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvMaGiamGia.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvMaGiamGia.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvMaGiamGia.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvMaGiamGia.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dgvMaGiamGia.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Maroon;
            this.dgvMaGiamGia.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMaGiamGia.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMaGiamGia.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvMaGiamGia.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvMaGiamGia.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvMaGiamGia.ThemeStyle.ReadOnly = true;
            this.dgvMaGiamGia.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.Gray;
            this.dgvMaGiamGia.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMaGiamGia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMaGiamGia.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvMaGiamGia.ThemeStyle.RowsStyle.Height = 80;
            this.dgvMaGiamGia.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvMaGiamGia.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMaGiamGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaGiamGia_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Tên mã:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 15);
            this.label2.TabIndex = 46;
            this.label2.Text = "ID:";
            // 
            // txt_tenMa
            // 
            this.txt_tenMa.BackColor = System.Drawing.Color.Transparent;
            this.txt_tenMa.BorderColor = System.Drawing.Color.Black;
            this.txt_tenMa.BorderRadius = 8;
            this.txt_tenMa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_tenMa.DefaultText = "";
            this.txt_tenMa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_tenMa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_tenMa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_tenMa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_tenMa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_tenMa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_tenMa.ForeColor = System.Drawing.Color.Black;
            this.txt_tenMa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_tenMa.Location = new System.Drawing.Point(174, 145);
            this.txt_tenMa.Name = "txt_tenMa";
            this.txt_tenMa.PlaceholderText = "";
            this.txt_tenMa.SelectedText = "";
            this.txt_tenMa.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.txt_tenMa.Size = new System.Drawing.Size(259, 36);
            this.txt_tenMa.TabIndex = 45;
            // 
            // txt_id
            // 
            this.txt_id.BackColor = System.Drawing.Color.Transparent;
            this.txt_id.BorderColor = System.Drawing.Color.Black;
            this.txt_id.BorderRadius = 8;
            this.txt_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_id.DefaultText = "";
            this.txt_id.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_id.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_id.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_id.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_id.Enabled = false;
            this.txt_id.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_id.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_id.ForeColor = System.Drawing.Color.Black;
            this.txt_id.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_id.Location = new System.Drawing.Point(174, 82);
            this.txt_id.Name = "txt_id";
            this.txt_id.PlaceholderText = "";
            this.txt_id.SelectedText = "";
            this.txt_id.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.txt_id.Size = new System.Drawing.Size(259, 36);
            this.txt_id.TabIndex = 44;
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.Color.Transparent;
            this.btn_sua.BorderRadius = 15;
            this.btn_sua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_sua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_sua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_sua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_sua.FillColor = System.Drawing.Color.Maroon;
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_sua.ForeColor = System.Drawing.Color.White;
            this.btn_sua.Location = new System.Drawing.Point(768, 352);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(80, 30);
            this.btn_sua.TabIndex = 43;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.BackColor = System.Drawing.Color.Transparent;
            this.btn_luu.BorderRadius = 15;
            this.btn_luu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_luu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_luu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_luu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_luu.Enabled = false;
            this.btn_luu.FillColor = System.Drawing.Color.Maroon;
            this.btn_luu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_luu.ForeColor = System.Drawing.Color.White;
            this.btn_luu.Location = new System.Drawing.Point(667, 352);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(80, 30);
            this.btn_luu.TabIndex = 42;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_themMoi
            // 
            this.btn_themMoi.BackColor = System.Drawing.Color.Transparent;
            this.btn_themMoi.BorderRadius = 15;
            this.btn_themMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_themMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_themMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_themMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_themMoi.FillColor = System.Drawing.Color.Maroon;
            this.btn_themMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_themMoi.ForeColor = System.Drawing.Color.White;
            this.btn_themMoi.Location = new System.Drawing.Point(561, 352);
            this.btn_themMoi.Name = "btn_themMoi";
            this.btn_themMoi.Size = new System.Drawing.Size(89, 30);
            this.btn_themMoi.TabIndex = 41;
            this.btn_themMoi.Text = "Thêm mới";
            this.btn_themMoi.Click += new System.EventHandler(this.btn_themMoi_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.Transparent;
            this.btn_xoa.BorderRadius = 15;
            this.btn_xoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_xoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_xoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_xoa.FillColor = System.Drawing.Color.Maroon;
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_xoa.ForeColor = System.Drawing.Color.White;
            this.btn_xoa.Location = new System.Drawing.Point(866, 352);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(80, 30);
            this.btn_xoa.TabIndex = 40;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(30, 13);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(167, 39);
            this.guna2HtmlLabel1.TabIndex = 39;
            this.guna2HtmlLabel1.Text = "Mã giảm giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 49;
            this.label3.Text = "Phần trăm giảm:";
            // 
            // txt_phanTramGiam
            // 
            this.txt_phanTramGiam.BackColor = System.Drawing.Color.Transparent;
            this.txt_phanTramGiam.BorderColor = System.Drawing.Color.Black;
            this.txt_phanTramGiam.BorderRadius = 8;
            this.txt_phanTramGiam.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_phanTramGiam.DefaultText = "";
            this.txt_phanTramGiam.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_phanTramGiam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_phanTramGiam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_phanTramGiam.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_phanTramGiam.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_phanTramGiam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_phanTramGiam.ForeColor = System.Drawing.Color.Black;
            this.txt_phanTramGiam.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_phanTramGiam.Location = new System.Drawing.Point(174, 211);
            this.txt_phanTramGiam.Name = "txt_phanTramGiam";
            this.txt_phanTramGiam.PlaceholderText = "";
            this.txt_phanTramGiam.SelectedText = "";
            this.txt_phanTramGiam.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.txt_phanTramGiam.Size = new System.Drawing.Size(259, 36);
            this.txt_phanTramGiam.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(472, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 51;
            this.label4.Text = "Số lượng:";
            // 
            // txt_soLuong
            // 
            this.txt_soLuong.BackColor = System.Drawing.Color.Transparent;
            this.txt_soLuong.BorderColor = System.Drawing.Color.Black;
            this.txt_soLuong.BorderRadius = 8;
            this.txt_soLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_soLuong.DefaultText = "";
            this.txt_soLuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_soLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_soLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_soLuong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_soLuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_soLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_soLuong.ForeColor = System.Drawing.Color.Black;
            this.txt_soLuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_soLuong.Location = new System.Drawing.Point(602, 82);
            this.txt_soLuong.Name = "txt_soLuong";
            this.txt_soLuong.PlaceholderText = "";
            this.txt_soLuong.SelectedText = "";
            this.txt_soLuong.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.txt_soLuong.Size = new System.Drawing.Size(259, 36);
            this.txt_soLuong.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(472, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 53;
            this.label5.Text = "Ngày bắt đầu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(472, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 55;
            this.label6.Text = "Ngày kết thúc:";
            // 
            // date_batDau
            // 
            this.date_batDau.BackColor = System.Drawing.Color.Transparent;
            this.date_batDau.BorderRadius = 8;
            this.date_batDau.Checked = true;
            this.date_batDau.CustomFormat = "MM/dd/yy";
            this.date_batDau.FillColor = System.Drawing.Color.Maroon;
            this.date_batDau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_batDau.ForeColor = System.Drawing.Color.White;
            this.date_batDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_batDau.Location = new System.Drawing.Point(602, 145);
            this.date_batDau.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date_batDau.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date_batDau.Name = "date_batDau";
            this.date_batDau.Size = new System.Drawing.Size(259, 36);
            this.date_batDau.TabIndex = 56;
            this.date_batDau.Value = new System.DateTime(2025, 3, 15, 23, 49, 4, 161);
            // 
            // date_ketThuc
            // 
            this.date_ketThuc.BackColor = System.Drawing.Color.Transparent;
            this.date_ketThuc.BorderRadius = 8;
            this.date_ketThuc.Checked = true;
            this.date_ketThuc.CustomFormat = "MM/dd/yy";
            this.date_ketThuc.FillColor = System.Drawing.Color.Maroon;
            this.date_ketThuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_ketThuc.ForeColor = System.Drawing.Color.White;
            this.date_ketThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_ketThuc.Location = new System.Drawing.Point(602, 211);
            this.date_ketThuc.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date_ketThuc.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date_ketThuc.Name = "date_ketThuc";
            this.date_ketThuc.Size = new System.Drawing.Size(259, 36);
            this.date_ketThuc.TabIndex = 57;
            this.date_ketThuc.Value = new System.DateTime(2025, 3, 15, 23, 49, 4, 161);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(27, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 15);
            this.label7.TabIndex = 59;
            this.label7.Text = "Giá áp dụng (trên):";
            // 
            // txt_giaApDung
            // 
            this.txt_giaApDung.BackColor = System.Drawing.Color.Transparent;
            this.txt_giaApDung.BorderColor = System.Drawing.Color.Black;
            this.txt_giaApDung.BorderRadius = 8;
            this.txt_giaApDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_giaApDung.DefaultText = "";
            this.txt_giaApDung.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_giaApDung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_giaApDung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_giaApDung.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_giaApDung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_giaApDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_giaApDung.ForeColor = System.Drawing.Color.Black;
            this.txt_giaApDung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_giaApDung.Location = new System.Drawing.Point(174, 276);
            this.txt_giaApDung.Name = "txt_giaApDung";
            this.txt_giaApDung.PlaceholderText = "";
            this.txt_giaApDung.SelectedText = "";
            this.txt_giaApDung.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.txt_giaApDung.Size = new System.Drawing.Size(259, 36);
            this.txt_giaApDung.TabIndex = 58;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // tenMa
            // 
            this.tenMa.HeaderText = "Tên mã";
            this.tenMa.Name = "tenMa";
            this.tenMa.ReadOnly = true;
            // 
            // phanTramGiam
            // 
            this.phanTramGiam.HeaderText = "Giảm theo %";
            this.phanTramGiam.Name = "phanTramGiam";
            this.phanTramGiam.ReadOnly = true;
            // 
            // soLuong
            // 
            this.soLuong.HeaderText = "Số lượng";
            this.soLuong.Name = "soLuong";
            this.soLuong.ReadOnly = true;
            // 
            // ngayBatDau
            // 
            this.ngayBatDau.HeaderText = "Ngày áp dụng";
            this.ngayBatDau.Name = "ngayBatDau";
            this.ngayBatDau.ReadOnly = true;
            // 
            // ngayKetThuc
            // 
            this.ngayKetThuc.HeaderText = "Ngày kết thúc";
            this.ngayKetThuc.Name = "ngayKetThuc";
            this.ngayKetThuc.ReadOnly = true;
            // 
            // dieuKien
            // 
            this.dieuKien.HeaderText = "Giá áp dụng";
            this.dieuKien.Name = "dieuKien";
            this.dieuKien.ReadOnly = true;
            // 
            // maGiamGiaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_giaApDung);
            this.Controls.Add(this.date_ketThuc);
            this.Controls.Add(this.date_batDau);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_soLuong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_phanTramGiam);
            this.Controls.Add(this.dgvMaGiamGia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_tenMa);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.btn_themMoi);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.MaximumSize = new System.Drawing.Size(970, 750);
            this.MinimumSize = new System.Drawing.Size(970, 750);
            this.Name = "maGiamGiaAdmin";
            this.Size = new System.Drawing.Size(970, 750);
            this.Load += new System.EventHandler(this.maGiamGiaAdmin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.maGiamGiaAdmin_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaGiamGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvMaGiamGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txt_tenMa;
        private Guna.UI2.WinForms.Guna2TextBox txt_id;
        private Guna.UI2.WinForms.Guna2Button btn_sua;
        private Guna.UI2.WinForms.Guna2Button btn_luu;
        private Guna.UI2.WinForms.Guna2Button btn_themMoi;
        private Guna.UI2.WinForms.Guna2Button btn_xoa;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txt_phanTramGiam;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txt_soLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker date_batDau;
        private Guna.UI2.WinForms.Guna2DateTimePicker date_ketThuc;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txt_giaApDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn phanTramGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dieuKien;
    }
}
