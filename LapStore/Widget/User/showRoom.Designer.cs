namespace LapStore.Widget.User
{
    partial class showRoom
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
            this.txtHienThi = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvShowRoom = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenCh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioMoCua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioDongCua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_timKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHienThi
            // 
            this.txtHienThi.AutoSize = true;
            this.txtHienThi.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHienThi.Location = new System.Drawing.Point(81, 15);
            this.txtHienThi.Name = "txtHienThi";
            this.txtHienThi.Size = new System.Drawing.Size(395, 45);
            this.txtHienThi.TabIndex = 22;
            this.txtHienThi.Text = "HỆ THỐNG SHOWROOM";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txt_timKiem);
            this.panel1.Controls.Add(this.guna2PictureBox1);
            this.panel1.Controls.Add(this.dgvShowRoom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(88, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 612);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm cửa hàng gần bạn";
            // 
            // dgvShowRoom
            // 
            this.dgvShowRoom.AllowUserToAddRows = false;
            this.dgvShowRoom.AllowUserToOrderColumns = true;
            this.dgvShowRoom.AllowUserToResizeColumns = false;
            this.dgvShowRoom.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvShowRoom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvShowRoom.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowRoom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShowRoom.ColumnHeadersHeight = 20;
            this.dgvShowRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvShowRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tenCh,
            this.email,
            this.sdt,
            this.diaChi,
            this.gioMoCua,
            this.gioDongCua});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowRoom.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShowRoom.GridColor = System.Drawing.Color.Black;
            this.dgvShowRoom.Location = new System.Drawing.Point(21, 192);
            this.dgvShowRoom.MultiSelect = false;
            this.dgvShowRoom.Name = "dgvShowRoom";
            this.dgvShowRoom.ReadOnly = true;
            this.dgvShowRoom.RowHeadersVisible = false;
            this.dgvShowRoom.RowTemplate.Height = 80;
            this.dgvShowRoom.Size = new System.Drawing.Size(958, 423);
            this.dgvShowRoom.TabIndex = 61;
            this.dgvShowRoom.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvShowRoom.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvShowRoom.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvShowRoom.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvShowRoom.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvShowRoom.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvShowRoom.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dgvShowRoom.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Maroon;
            this.dgvShowRoom.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvShowRoom.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvShowRoom.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvShowRoom.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvShowRoom.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvShowRoom.ThemeStyle.ReadOnly = true;
            this.dgvShowRoom.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.Gray;
            this.dgvShowRoom.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvShowRoom.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvShowRoom.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvShowRoom.ThemeStyle.RowsStyle.Height = 80;
            this.dgvShowRoom.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvShowRoom.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // id
            // 
            this.id.HeaderText = "Mã cửa hàng";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // tenCh
            // 
            this.tenCh.HeaderText = "Tên cửa hàng";
            this.tenCh.Name = "tenCh";
            this.tenCh.ReadOnly = true;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // sdt
            // 
            this.sdt.HeaderText = "Số điện thoại";
            this.sdt.Name = "sdt";
            this.sdt.ReadOnly = true;
            // 
            // diaChi
            // 
            this.diaChi.HeaderText = "Địa chỉ";
            this.diaChi.Name = "diaChi";
            this.diaChi.ReadOnly = true;
            // 
            // gioMoCua
            // 
            this.gioMoCua.HeaderText = "Giờ mở cửa";
            this.gioMoCua.Name = "gioMoCua";
            this.gioMoCua.ReadOnly = true;
            // 
            // gioDongCua
            // 
            this.gioDongCua.HeaderText = "Giờ đóng cửa";
            this.gioDongCua.Name = "gioDongCua";
            this.gioDongCua.ReadOnly = true;
            // 
            // txt_timKiem
            // 
            this.txt_timKiem.BackColor = System.Drawing.Color.Transparent;
            this.txt_timKiem.BorderColor = System.Drawing.Color.Red;
            this.txt_timKiem.BorderRadius = 8;
            this.txt_timKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_timKiem.DefaultText = "";
            this.txt_timKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_timKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_timKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_timKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_timKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_timKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_timKiem.ForeColor = System.Drawing.Color.Black;
            this.txt_timKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_timKiem.Location = new System.Drawing.Point(21, 51);
            this.txt_timKiem.Name = "txt_timKiem";
            this.txt_timKiem.PlaceholderText = "";
            this.txt_timKiem.SelectedText = "";
            this.txt_timKiem.Size = new System.Drawing.Size(367, 36);
            this.txt_timKiem.TabIndex = 63;
            this.txt_timKiem.TextChanged += new System.EventHandler(this.txt_timKiem_TextChanged);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::LapStore.Properties.Resources.Screenshot_2025_04_24_023543;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(475, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(516, 133);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 62;
            this.guna2PictureBox1.TabStop = false;
            // 
            // showRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.txtHienThi);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "showRoom";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.showRoom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtHienThi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvShowRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenCh;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioMoCua;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioDongCua;
        private Guna.UI2.WinForms.Guna2TextBox txt_timKiem;
    }
}
