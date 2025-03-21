﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Widget;
using LapStore.Widget.User;

namespace LapStore.View
{
    public partial class userHome : Form
    {
        public userHome()
        {
            InitializeComponent();
            trangChuUser uc = new trangChuUser();
            AddUserControl(uc);


        }
        private void AddUserControl(UserControl uc)
        {
            // Xóa các control cũ trong panel
            chuyen.Controls.Clear();

            // Thiết lập lại thuộc tính cuộn
            chuyen.AutoScroll = true;

            // Thiết lập Dock để chiếm toàn bộ không gian
            uc.Dock = DockStyle.Fill;

            // Thêm UserControl vào panel
            chuyen.Controls.Add(uc);

            // Đưa UserControl lên trước
            uc.BringToFront();
        }


        private void logo_Click(object sender, EventArgs e)
        {
            trangChuUser uc = new trangChuUser();
            AddUserControl(uc);

        }

        private void btn_cart_Click(object sender, EventArgs e)
        {
            cartUser uc = new cartUser();
            AddUserControl(uc);

        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            profileUser uc = new profileUser();
            AddUserControl(uc);
        }
    }
}
