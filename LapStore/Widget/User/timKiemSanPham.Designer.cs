namespace LapStore.Widget.User
{
    partial class timKiemSanPham
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
            this.scroll = new System.Windows.Forms.Panel();
            this.txtHienThi = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoc = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_sapXep = new Guna.UI2.WinForms.Guna2ComboBox();
            this.flowSP = new System.Windows.Forms.FlowLayoutPanel();
            this.scroll.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scroll
            // 
            this.scroll.AutoScroll = true;
            this.scroll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scroll.Controls.Add(this.txtHienThi);
            this.scroll.Controls.Add(this.panel1);
            this.scroll.Controls.Add(this.flowSP);
            this.scroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scroll.Location = new System.Drawing.Point(0, 0);
            this.scroll.Name = "scroll";
            this.scroll.Size = new System.Drawing.Size(1200, 700);
            this.scroll.TabIndex = 4;
            // 
            // txtHienThi
            // 
            this.txtHienThi.AutoSize = true;
            this.txtHienThi.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHienThi.Location = new System.Drawing.Point(90, 22);
            this.txtHienThi.Name = "txtHienThi";
            this.txtHienThi.Size = new System.Drawing.Size(177, 45);
            this.txtHienThi.TabIndex = 20;
            this.txtHienThi.Text = "Tìm kiếm: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnLoc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbb_sapXep);
            this.panel1.Location = new System.Drawing.Point(97, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 113);
            this.panel1.TabIndex = 19;
            // 
            // btnLoc
            // 
            this.btnLoc.BorderRadius = 10;
            this.btnLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoc.FillColor = System.Drawing.Color.Maroon;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(236, 61);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(104, 36);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lọc sản phẩm";
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
            this.cbb_sapXep.Location = new System.Drawing.Point(23, 61);
            this.cbb_sapXep.Name = "cbb_sapXep";
            this.cbb_sapXep.Size = new System.Drawing.Size(191, 36);
            this.cbb_sapXep.TabIndex = 1;
            // 
            // flowSP
            // 
            this.flowSP.BackColor = System.Drawing.Color.Transparent;
            this.flowSP.Location = new System.Drawing.Point(97, 211);
            this.flowSP.Name = "flowSP";
            this.flowSP.Size = new System.Drawing.Size(1050, 1233);
            this.flowSP.TabIndex = 0;
            // 
            // timKiemSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scroll);
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "timKiemSanPham";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.timKiemSanPham_Load);
            this.scroll.ResumeLayout(false);
            this.scroll.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel scroll;
        private System.Windows.Forms.Label txtHienThi;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnLoc;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_sapXep;
        private System.Windows.Forms.FlowLayoutPanel flowSP;
    }
}
