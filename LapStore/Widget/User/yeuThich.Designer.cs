namespace LapStore.Widget.User
{
    partial class yeuThich
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
            this.components = new System.ComponentModel.Container();
            this.scroll = new System.Windows.Forms.Panel();
            this.txtHienThi = new System.Windows.Forms.Label();
            this.flowSP = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.scroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // scroll
            // 
            this.scroll.AutoScroll = true;
            this.scroll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scroll.Controls.Add(this.txtHienThi);
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
            this.txtHienThi.Size = new System.Drawing.Size(322, 45);
            this.txtHienThi.TabIndex = 20;
            this.txtHienThi.Text = "Sản phẩm yêu thích:";
            // 
            // flowSP
            // 
            this.flowSP.BackColor = System.Drawing.Color.Transparent;
            this.flowSP.Location = new System.Drawing.Point(98, 114);
            this.flowSP.Name = "flowSP";
            this.flowSP.Size = new System.Drawing.Size(1050, 1233);
            this.flowSP.TabIndex = 0;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // yeuThich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scroll);
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "yeuThich";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.yeuThich_Load);
            this.scroll.ResumeLayout(false);
            this.scroll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel scroll;
        private System.Windows.Forms.Label txtHienThi;
        private System.Windows.Forms.FlowLayoutPanel flowSP;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}
