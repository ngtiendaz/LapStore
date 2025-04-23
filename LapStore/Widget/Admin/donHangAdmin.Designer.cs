namespace LapStore.Widget.Admin
{
    partial class donHangAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dateCreateAt = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtPhuongThuc = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTongTien = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDiaChi = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSdt = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaDh = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvDonHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.madh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuongthuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbb_trangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
            this.cbb_timTheoTT = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKiem.FillColor = System.Drawing.Color.Maroon;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(299, 334);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(80, 36);
            this.btnTimKiem.TabIndex = 59;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Transparent;
            this.btnSua.BorderRadius = 10;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.Maroon;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(817, 334);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(138, 36);
            this.btnSua.TabIndex = 57;
            this.btnSua.Text = "Thay đổi trạng thái";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.txtTimKiem.BorderRadius = 10;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(38, 334);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(255, 36);
            this.txtTimKiem.TabIndex = 55;
            // 
            // dateCreateAt
            // 
            this.dateCreateAt.BackColor = System.Drawing.Color.Transparent;
            this.dateCreateAt.BorderRadius = 8;
            this.dateCreateAt.Checked = true;
            this.dateCreateAt.CustomFormat = "MM/dd/yy";
            this.dateCreateAt.Enabled = false;
            this.dateCreateAt.FillColor = System.Drawing.Color.Maroon;
            this.dateCreateAt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCreateAt.ForeColor = System.Drawing.Color.White;
            this.dateCreateAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCreateAt.Location = new System.Drawing.Point(603, 231);
            this.dateCreateAt.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateCreateAt.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateCreateAt.Name = "dateCreateAt";
            this.dateCreateAt.Size = new System.Drawing.Size(246, 36);
            this.dateCreateAt.TabIndex = 52;
            this.dateCreateAt.Value = new System.DateTime(2025, 3, 15, 23, 49, 4, 161);
            // 
            // txtPhuongThuc
            // 
            this.txtPhuongThuc.BackColor = System.Drawing.Color.Transparent;
            this.txtPhuongThuc.BorderRadius = 8;
            this.txtPhuongThuc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhuongThuc.DefaultText = "";
            this.txtPhuongThuc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhuongThuc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhuongThuc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhuongThuc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhuongThuc.Enabled = false;
            this.txtPhuongThuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhuongThuc.ForeColor = System.Drawing.Color.Black;
            this.txtPhuongThuc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhuongThuc.Location = new System.Drawing.Point(603, 125);
            this.txtPhuongThuc.Name = "txtPhuongThuc";
            this.txtPhuongThuc.PlaceholderText = "";
            this.txtPhuongThuc.SelectedText = "";
            this.txtPhuongThuc.Size = new System.Drawing.Size(246, 36);
            this.txtPhuongThuc.TabIndex = 50;
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.Transparent;
            this.txtTongTien.BorderRadius = 8;
            this.txtTongTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTongTien.DefaultText = "";
            this.txtTongTien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTongTien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTongTien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTongTien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTongTien.Enabled = false;
            this.txtTongTien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTongTien.ForeColor = System.Drawing.Color.Black;
            this.txtTongTien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongTien.Location = new System.Drawing.Point(603, 73);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.PlaceholderText = "";
            this.txtTongTien.SelectedText = "";
            this.txtTongTien.Size = new System.Drawing.Size(246, 36);
            this.txtTongTien.TabIndex = 49;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.Color.Transparent;
            this.txtDiaChi.BorderRadius = 8;
            this.txtDiaChi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiaChi.DefaultText = "";
            this.txtDiaChi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiaChi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiaChi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiaChi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiaChi.Enabled = false;
            this.txtDiaChi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiaChi.ForeColor = System.Drawing.Color.Black;
            this.txtDiaChi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiaChi.Location = new System.Drawing.Point(154, 184);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.PlaceholderText = "";
            this.txtDiaChi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiaChi.SelectedText = "";
            this.txtDiaChi.Size = new System.Drawing.Size(263, 88);
            this.txtDiaChi.TabIndex = 48;
            // 
            // txtSdt
            // 
            this.txtSdt.BackColor = System.Drawing.Color.Transparent;
            this.txtSdt.BorderRadius = 8;
            this.txtSdt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSdt.DefaultText = "";
            this.txtSdt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSdt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSdt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSdt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSdt.Enabled = false;
            this.txtSdt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSdt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSdt.ForeColor = System.Drawing.Color.Black;
            this.txtSdt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSdt.Location = new System.Drawing.Point(154, 125);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.PlaceholderText = "";
            this.txtSdt.SelectedText = "";
            this.txtSdt.Size = new System.Drawing.Size(263, 36);
            this.txtSdt.TabIndex = 46;
            // 
            // txtMaDh
            // 
            this.txtMaDh.BackColor = System.Drawing.Color.Transparent;
            this.txtMaDh.BorderColor = System.Drawing.Color.Black;
            this.txtMaDh.BorderRadius = 8;
            this.txtMaDh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaDh.DefaultText = "";
            this.txtMaDh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaDh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaDh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaDh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaDh.Enabled = false;
            this.txtMaDh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaDh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaDh.ForeColor = System.Drawing.Color.Black;
            this.txtMaDh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaDh.Location = new System.Drawing.Point(154, 73);
            this.txtMaDh.Name = "txtMaDh";
            this.txtMaDh.PlaceholderText = "";
            this.txtMaDh.SelectedText = "";
            this.txtMaDh.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.txtMaDh.Size = new System.Drawing.Size(263, 36);
            this.txtMaDh.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(515, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 44;
            this.label8.Text = "CreateAt:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(515, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 43;
            this.label7.Text = "Trạng thái:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(515, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 33);
            this.label6.TabIndex = 42;
            this.label6.Text = "Phương thức thanh toán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(516, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "Tổng tiền:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "Địa chỉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 38;
            this.label2.Text = "Số điện thoại:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 37;
            this.label1.Text = "Mã đơn hàng:";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(27, 8);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(131, 39);
            this.guna2HtmlLabel1.TabIndex = 36;
            this.guna2HtmlLabel1.Text = "Đơn hàng";
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.AllowUserToAddRows = false;
            this.dgvDonHang.AllowUserToOrderColumns = true;
            this.dgvDonHang.AllowUserToResizeColumns = false;
            this.dgvDonHang.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvDonHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDonHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvDonHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDonHang.ColumnHeadersHeight = 20;
            this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDonHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.madh,
            this.sdt,
            this.diachi,
            this.tongtien,
            this.phuongthuc,
            this.trangthai,
            this.createat});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDonHang.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDonHang.GridColor = System.Drawing.Color.Black;
            this.dgvDonHang.Location = new System.Drawing.Point(3, 385);
            this.dgvDonHang.MultiSelect = false;
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.ReadOnly = true;
            this.dgvDonHang.RowHeadersVisible = false;
            this.dgvDonHang.RowTemplate.Height = 80;
            this.dgvDonHang.Size = new System.Drawing.Size(964, 362);
            this.dgvDonHang.TabIndex = 62;
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
            // madh
            // 
            this.madh.HeaderText = "Mã đơn hàng";
            this.madh.Name = "madh";
            this.madh.ReadOnly = true;
            // 
            // sdt
            // 
            this.sdt.HeaderText = "Số điện thoại";
            this.sdt.Name = "sdt";
            this.sdt.ReadOnly = true;
            // 
            // diachi
            // 
            this.diachi.HeaderText = "Địa chỉ";
            this.diachi.Name = "diachi";
            this.diachi.ReadOnly = true;
            // 
            // tongtien
            // 
            this.tongtien.HeaderText = "Tổng tiền";
            this.tongtien.Name = "tongtien";
            this.tongtien.ReadOnly = true;
            // 
            // phuongthuc
            // 
            this.phuongthuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.phuongthuc.HeaderText = "Phương thức thanh toán";
            this.phuongthuc.Name = "phuongthuc";
            this.phuongthuc.ReadOnly = true;
            this.phuongthuc.Width = 168;
            // 
            // trangthai
            // 
            this.trangthai.HeaderText = "Trạng thái";
            this.trangthai.Name = "trangthai";
            this.trangthai.ReadOnly = true;
            // 
            // createat
            // 
            this.createat.HeaderText = "Create At";
            this.createat.Name = "createat";
            this.createat.ReadOnly = true;
            // 
            // cbb_trangThai
            // 
            this.cbb_trangThai.BackColor = System.Drawing.Color.Transparent;
            this.cbb_trangThai.BorderRadius = 10;
            this.cbb_trangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_trangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_trangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_trangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_trangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_trangThai.ForeColor = System.Drawing.Color.Black;
            this.cbb_trangThai.ItemHeight = 30;
            this.cbb_trangThai.Location = new System.Drawing.Point(603, 184);
            this.cbb_trangThai.Name = "cbb_trangThai";
            this.cbb_trangThai.Size = new System.Drawing.Size(246, 36);
            this.cbb_trangThai.TabIndex = 63;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.Transparent;
            this.btnLoc.BorderRadius = 10;
            this.btnLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoc.FillColor = System.Drawing.Color.Maroon;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(731, 334);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(80, 36);
            this.btnLoc.TabIndex = 65;
            this.btnLoc.Text = "Tìm";
            this.btnLoc.UseTransparentBackground = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cbb_timTheoTT
            // 
            this.cbb_timTheoTT.BackColor = System.Drawing.Color.Transparent;
            this.cbb_timTheoTT.BorderRadius = 10;
            this.cbb_timTheoTT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_timTheoTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_timTheoTT.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_timTheoTT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_timTheoTT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_timTheoTT.ForeColor = System.Drawing.Color.Black;
            this.cbb_timTheoTT.ItemHeight = 30;
            this.cbb_timTheoTT.Location = new System.Drawing.Point(541, 334);
            this.cbb_timTheoTT.Name = "cbb_timTheoTT";
            this.cbb_timTheoTT.Size = new System.Drawing.Size(184, 36);
            this.cbb_timTheoTT.TabIndex = 64;
            // 
            // donHangAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.cbb_timTheoTT);
            this.Controls.Add(this.cbb_trangThai);
            this.Controls.Add(this.dgvDonHang);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.dateCreateAt);
            this.Controls.Add(this.txtPhuongThuc);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtSdt);
            this.Controls.Add(this.txtMaDh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.MaximumSize = new System.Drawing.Size(970, 750);
            this.MinimumSize = new System.Drawing.Size(970, 750);
            this.Name = "donHangAdmin";
            this.Size = new System.Drawing.Size(970, 750);
            this.Load += new System.EventHandler(this.donHangAdmin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.donHangAdmin_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateCreateAt;
        private Guna.UI2.WinForms.Guna2TextBox txtPhuongThuc;
        private Guna.UI2.WinForms.Guna2TextBox txtTongTien;
        private Guna.UI2.WinForms.Guna2TextBox txtDiaChi;
        private Guna.UI2.WinForms.Guna2TextBox txtSdt;
        private Guna.UI2.WinForms.Guna2TextBox txtMaDh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDonHang;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_trangThai;
        private Guna.UI2.WinForms.Guna2Button btnLoc;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_timTheoTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn madh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuongthuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.DataGridViewTextBoxColumn createat;
    }
}
