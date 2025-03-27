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
        private Timer slideTimer;
        private int panelTargetHeight = 370; // Chiều cao tối đa của panelDanhMuc
        private int panelSpeed = 10; // Tốc độ trượt
        public userHome()
        {
            InitializeComponent();
            trangChuUser uc = new trangChuUser();
            AddUserControl(uc);
            InitializePanelEffect();


        }
        private void InitializePanelEffect()
        {
            panelDanhMuc.Height = 0; // Ban đầu ẩn panel
            panelDanhMuc.Visible = false;

            slideTimer = new Timer();
            slideTimer.Interval = 10; // Khoảng thời gian mỗi lần cập nhật
            slideTimer.Tick += SlidePanel;
        }

        private void AddUserControl(UserControl uc)
        {
            foreach (Control ctrl in chuyen.Controls)
            {
                if (ctrl == panelDanhMuc) continue; // Không xoá panel1
                ctrl.Dispose();
            }

            chuyen.Controls.Clear();
            chuyen.Controls.Add(panelDanhMuc); // Giữ lại panel1
            panelDanhMuc.BringToFront(); // Đảm bảo nó luôn ở trên cùng

            chuyen.AutoScroll = true;
            uc.Dock = DockStyle.Fill;
            chuyen.Controls.Add(uc);
            //uc.BringToFront();
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

        private void menu_Click(object sender, EventArgs e)
        {
            //panelDanhMuc.Visible = !panelDanhMuc.Visible;

            //if (panelDanhMuc.Visible)
            //{
            //    panelDanhMuc.BringToFront(); // Đưa panel lên trên tất cả các panel khác
            //}
        }

        private void menu_MouseEnter(object sender, EventArgs e)
        {
            panelDanhMuc.Visible = true;
            slideTimer.Tag = "open"; // Gán trạng thái mở
            slideTimer.Start();
        }

        private void panelDanhMuc_MouseEnter(object sender, EventArgs e)
        {
            panelDanhMuc.Visible = true;
            slideTimer.Tag = "open"; // Giữ panel mở nếu chuột đang ở panel
        }
        private async void HidePanelWithDelay()
        {
            await Task.Delay(300); // Chờ 300ms để tránh flicker

            if (!panelDanhMuc.Bounds.Contains(panelDanhMuc.PointToClient(Cursor.Position)) &&
                !menu.Bounds.Contains(menu.PointToClient(Cursor.Position)))
            {
                slideTimer.Tag = "close"; // Gán trạng thái đóng
                slideTimer.Start();
            }
        }

        private void menu_MouseLeave(object sender, EventArgs e)
        {
            HidePanelWithDelay();
        }

        private void panelDanhMuc_MouseLeave(object sender, EventArgs e)
        {
            HidePanelWithDelay();
        }
        private void SlidePanel(object sender, EventArgs e)
        {
            if (slideTimer.Tag.ToString() == "open")
            {
                if (panelDanhMuc.Height < panelTargetHeight)
                {
                    panelDanhMuc.Height += panelSpeed;
                }
                else
                {
                    slideTimer.Stop();
                }
            }
            else if (slideTimer.Tag.ToString() == "close")
            {
                if (panelDanhMuc.Height > 0)
                {
                    panelDanhMuc.Height -= panelSpeed;
                }
                else
                {
                    slideTimer.Stop();
                    panelDanhMuc.Visible = false;
                }
            }
        }
    }
}
