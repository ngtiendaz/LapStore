using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Model;
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
            chuyen.Controls.Clear();
            chuyen.AutoScroll = true;
            uc.Dock = DockStyle.Fill;
            chuyen.Controls.Add(uc);
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

        private void menuUser_Paint(object sender, PaintEventArgs e)
        {
         
        }
        public void ShowDetailSanPham(SanPham sp)
        {
            detailSanPham detailPanel = new detailSanPham(sp);
            AddUserControl(detailPanel);
        }
    }
}
