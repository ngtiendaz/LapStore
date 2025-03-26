namespace LapStore.View
{
    partial class userHome
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
            this.menuUser = new Guna.UI2.WinForms.Guna2Panel();
            this.panelChuyen = new System.Windows.Forms.Panel();
            this.btn_timKiem = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btn_logOut = new Guna.UI2.WinForms.Guna2Button();
            this.txt_timKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.logo = new Guna.UI2.WinForms.Guna2Button();
            this.btn_profile = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cart = new Guna.UI2.WinForms.Guna2Button();
            this.menu = new Guna.UI2.WinForms.Guna2Button();
            this.chuyen = new System.Windows.Forms.Panel();
            this.menuUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuUser
            // 
            this.menuUser.BackColor = System.Drawing.Color.White;
            this.menuUser.Controls.Add(this.panelChuyen);
            this.menuUser.Controls.Add(this.btn_timKiem);
            this.menuUser.Controls.Add(this.btn_logOut);
            this.menuUser.Controls.Add(this.txt_timKiem);
            this.menuUser.Controls.Add(this.logo);
            this.menuUser.Controls.Add(this.btn_profile);
            this.menuUser.Controls.Add(this.btn_cart);
            this.menuUser.Controls.Add(this.menu);
            this.menuUser.Location = new System.Drawing.Point(-1, 0);
            this.menuUser.MaximumSize = new System.Drawing.Size(1200, 50);
            this.menuUser.MinimumSize = new System.Drawing.Size(1200, 50);
            this.menuUser.Name = "menuUser";
            this.menuUser.Size = new System.Drawing.Size(1200, 50);
            this.menuUser.TabIndex = 0;
            this.menuUser.Paint += new System.Windows.Forms.PaintEventHandler(this.menuUser_Paint);
            // 
            // panelChuyen
            // 
            this.panelChuyen.Location = new System.Drawing.Point(0, 52);
            this.panelChuyen.MaximumSize = new System.Drawing.Size(1200, 700);
            this.panelChuyen.MinimumSize = new System.Drawing.Size(1200, 700);
            this.panelChuyen.Name = "panelChuyen";
            this.panelChuyen.Size = new System.Drawing.Size(1200, 700);
            this.panelChuyen.TabIndex = 1;
            // 
            // btn_timKiem
            // 
            this.btn_timKiem.BackColor = System.Drawing.Color.Transparent;
            this.btn_timKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_timKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_timKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_timKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_timKiem.FillColor = System.Drawing.Color.Brown;
            this.btn_timKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_timKiem.ForeColor = System.Drawing.Color.Transparent;
            this.btn_timKiem.Image = global::LapStore.Properties.Resources.icons8_find_32;
            this.btn_timKiem.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_timKiem.Location = new System.Drawing.Point(761, 6);
            this.btn_timKiem.Name = "btn_timKiem";
            this.btn_timKiem.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn_timKiem.Size = new System.Drawing.Size(40, 40);
            this.btn_timKiem.TabIndex = 7;
            // 
            // btn_logOut
            // 
            this.btn_logOut.BackColor = System.Drawing.Color.Transparent;
            this.btn_logOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_logOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_logOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_logOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_logOut.FillColor = System.Drawing.Color.Transparent;
            this.btn_logOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_logOut.ForeColor = System.Drawing.Color.Transparent;
            this.btn_logOut.Image = global::LapStore.Properties.Resources.icons8_sign_out_32black;
            this.btn_logOut.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_logOut.Location = new System.Drawing.Point(1109, 2);
            this.btn_logOut.Name = "btn_logOut";
            this.btn_logOut.Size = new System.Drawing.Size(64, 45);
            this.btn_logOut.TabIndex = 6;
            // 
            // txt_timKiem
            // 
            this.txt_timKiem.BackColor = System.Drawing.Color.Transparent;
            this.txt_timKiem.BorderColor = System.Drawing.Color.Red;
            this.txt_timKiem.BorderRadius = 20;
            this.txt_timKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_timKiem.DefaultText = "";
            this.txt_timKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_timKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_timKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_timKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_timKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_timKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_timKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_timKiem.Location = new System.Drawing.Point(342, 5);
            this.txt_timKiem.Name = "txt_timKiem";
            this.txt_timKiem.PlaceholderText = "";
            this.txt_timKiem.SelectedText = "";
            this.txt_timKiem.Size = new System.Drawing.Size(413, 41);
            this.txt_timKiem.TabIndex = 5;
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.logo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.logo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.logo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.logo.FillColor = System.Drawing.Color.Transparent;
            this.logo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.logo.ForeColor = System.Drawing.Color.White;
            this.logo.Image = global::LapStore.Properties.Resources.favicon_hacom_2024;
            this.logo.ImageSize = new System.Drawing.Size(100, 100);
            this.logo.Location = new System.Drawing.Point(83, 3);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(129, 43);
            this.logo.TabIndex = 4;
            this.logo.Click += new System.EventHandler(this.logo_Click);
            // 
            // btn_profile
            // 
            this.btn_profile.BackColor = System.Drawing.Color.Transparent;
            this.btn_profile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_profile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_profile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_profile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_profile.FillColor = System.Drawing.Color.Transparent;
            this.btn_profile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_profile.ForeColor = System.Drawing.Color.Transparent;
            this.btn_profile.Image = global::LapStore.Properties.Resources.icons8_user_32black;
            this.btn_profile.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_profile.Location = new System.Drawing.Point(1040, 2);
            this.btn_profile.Name = "btn_profile";
            this.btn_profile.Size = new System.Drawing.Size(64, 45);
            this.btn_profile.TabIndex = 2;
            this.btn_profile.Click += new System.EventHandler(this.btn_profile_Click);
            // 
            // btn_cart
            // 
            this.btn_cart.BackColor = System.Drawing.Color.Transparent;
            this.btn_cart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cart.FillColor = System.Drawing.Color.Transparent;
            this.btn_cart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_cart.ForeColor = System.Drawing.Color.White;
            this.btn_cart.Image = global::LapStore.Properties.Resources.icons8_shopping_cart_32black;
            this.btn_cart.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_cart.Location = new System.Drawing.Point(970, 2);
            this.btn_cart.Name = "btn_cart";
            this.btn_cart.Size = new System.Drawing.Size(64, 45);
            this.btn_cart.TabIndex = 1;
            this.btn_cart.Click += new System.EventHandler(this.btn_cart_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.menu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.menu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.menu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.menu.FillColor = System.Drawing.Color.Transparent;
            this.menu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menu.ForeColor = System.Drawing.Color.White;
            this.menu.Image = global::LapStore.Properties.Resources.icons8_menu_32;
            this.menu.ImageSize = new System.Drawing.Size(30, 30);
            this.menu.Location = new System.Drawing.Point(13, 3);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(64, 45);
            this.menu.TabIndex = 0;
            // 
            // chuyen
            // 
            this.chuyen.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chuyen.Location = new System.Drawing.Point(-1, 56);
            this.chuyen.MaximumSize = new System.Drawing.Size(1200, 700);
            this.chuyen.MinimumSize = new System.Drawing.Size(1200, 700);
            this.chuyen.Name = "chuyen";
            this.chuyen.Size = new System.Drawing.Size(1200, 700);
            this.chuyen.TabIndex = 1;
            // 
            // userHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.chuyen);
            this.Controls.Add(this.menuUser);
            this.MaximumSize = new System.Drawing.Size(1200, 750);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "userHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.menuUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel menuUser;
        private Guna.UI2.WinForms.Guna2Button btn_profile;
        private Guna.UI2.WinForms.Guna2Button btn_cart;
        private Guna.UI2.WinForms.Guna2Button menu;
        private Guna.UI2.WinForms.Guna2Button logo;
        private Guna.UI2.WinForms.Guna2TextBox txt_timKiem;
        private Guna.UI2.WinForms.Guna2Button btn_logOut;
        private Guna.UI2.WinForms.Guna2CircleButton btn_timKiem;
        private System.Windows.Forms.Panel panelChuyen;
        private System.Windows.Forms.Panel chuyen;
    }
}