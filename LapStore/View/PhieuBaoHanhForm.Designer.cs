namespace LapStore.View
{
    partial class PhieuBaoHanhForm
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
            this.flowPhieuBH = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHienThi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowPhieuBH
            // 
            this.flowPhieuBH.AutoScroll = true;
            this.flowPhieuBH.BackColor = System.Drawing.Color.Transparent;
            this.flowPhieuBH.Location = new System.Drawing.Point(19, 50);
            this.flowPhieuBH.Name = "flowPhieuBH";
            this.flowPhieuBH.Size = new System.Drawing.Size(519, 368);
            this.flowPhieuBH.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(507, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 37);
            this.label1.TabIndex = 25;
            this.label1.Text = "x";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtHienThi
            // 
            this.txtHienThi.AutoSize = true;
            this.txtHienThi.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHienThi.ForeColor = System.Drawing.Color.Black;
            this.txtHienThi.Location = new System.Drawing.Point(12, 10);
            this.txtHienThi.Name = "txtHienThi";
            this.txtHienThi.Size = new System.Drawing.Size(266, 37);
            this.txtHienThi.TabIndex = 24;
            this.txtHienThi.Text = "Chọn gói bảo hành";
            // 
            // PhieuBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 429);
            this.Controls.Add(this.flowPhieuBH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHienThi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(550, 429);
            this.Name = "PhieuBaoHanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhieuBaoHanh";
            this.Load += new System.EventHandler(this.PhieuBaoHanh_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PhieuBaoHanh_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPhieuBH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtHienThi;
    }
}