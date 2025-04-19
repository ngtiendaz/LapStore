namespace LapStore.View
{
    partial class MaGiamGiaForm
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
            this.listMaGiamGia = new System.Windows.Forms.ListView();
            this.txtHienThi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listMaGiamGia
            // 
            this.listMaGiamGia.HideSelection = false;
            this.listMaGiamGia.Location = new System.Drawing.Point(4, 49);
            this.listMaGiamGia.Name = "listMaGiamGia";
            this.listMaGiamGia.Size = new System.Drawing.Size(498, 378);
            this.listMaGiamGia.TabIndex = 0;
            this.listMaGiamGia.UseCompatibleStateImageBehavior = false;
            // 
            // txtHienThi
            // 
            this.txtHienThi.AutoSize = true;
            this.txtHienThi.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHienThi.ForeColor = System.Drawing.Color.White;
            this.txtHienThi.Location = new System.Drawing.Point(12, 9);
            this.txtHienThi.Name = "txtHienThi";
            this.txtHienThi.Size = new System.Drawing.Size(181, 37);
            this.txtHienThi.TabIndex = 21;
            this.txtHienThi.Text = "Mã giảm giá";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(471, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 37);
            this.label1.TabIndex = 22;
            this.label1.Text = "x";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MaGiamGiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(508, 429);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHienThi);
            this.Controls.Add(this.listMaGiamGia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(508, 429);
            this.MinimumSize = new System.Drawing.Size(508, 429);
            this.Name = "MaGiamGiaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaGiamGia";
            this.Load += new System.EventHandler(this.MaGiamGiaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listMaGiamGia;
        private System.Windows.Forms.Label txtHienThi;
        private System.Windows.Forms.Label label1;
    }
}