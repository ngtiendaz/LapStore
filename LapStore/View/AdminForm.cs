using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Controller;
using LapStore.View;
using LapStore.Widget;
using LapStore.Widget.Admin;

namespace LapStore
{
    public partial class adminHome : Form
    {
        public adminHome()
        {
            InitializeComponent();
            LapTop uc = new LapTop();
            AddUserControl(uc);
        }
        private void MakeRoundedCorners(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }
        private void AddUserControl(UserControl uc)
        {
            // Xóa các control cũ trong panel
            panelChuyen.Controls.Clear();

            // Thiết lập Dock để chiếm toàn bộ không gian
            uc.Dock = DockStyle.Fill;

            // Thêm UserControl vào panel
            panelChuyen.Controls.Add(uc);
            
            uc.BringToFront();
        }
        private void SetUserImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
            {
                imageAdmin.ImageLocation = imagePath;
            }
            else
            {
                imageAdmin.Image = null;
                imageAdmin.BackColor = Color.Gray; // Nếu không có ảnh, đổi màu PictureBox thành đỏ
            }
        }


        private void menu_Paint(object sender, PaintEventArgs e)
        {

            // Lấy kích thước của control
            Rectangle rect = this.ClientRectangle;

            // Tạo brush gradient từ xanh đen (#2C3E50) sang xanh lục nhạt (#4CA1AF)
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                rect,
                ColorTranslator.FromHtml("#190A05"),
                ColorTranslator.FromHtml("#870000"),   // Màu 2
                45f))                                  // Góc gradient (90 độ)
            {
                // Vẽ nền với gradient
                e.Graphics.FillRectangle(brush, rect);
            }

        }

        private void btn_Laptop_Click(object sender, EventArgs e)
        {
            LapTop uc = new LapTop();
            AddUserControl(uc);
        }

        private void btn_ManHinh_Click(object sender, EventArgs e)
        {
            manHinhUserControl uc = new manHinhUserControl();
            AddUserControl(uc);

        }

        private void btn_PC_Click(object sender, EventArgs e)
        {
            pcUserControl uc = new pcUserControl();
            AddUserControl(uc);
        }

        private void btn_phim_Click(object sender, EventArgs e)
        {
            phimUserControl uc = new phimUserControl();
            AddUserControl(uc);
        }

        private void btn_chuot_Click(object sender, EventArgs e)
        {
            chuotUserControl uc = new chuotUserControl();
            AddUserControl(uc);
        }

        private void btn_taiNghe_Click(object sender, EventArgs e)
        {
            taiNgheUserControl uc = new taiNgheUserControl();
            AddUserControl(uc);
        }

        private void btn_mic_Click(object sender, EventArgs e)
        {
            micUserControl uc = new micUserControl();
            AddUserControl(uc);
        }

        private void btn_Loa_Click(object sender, EventArgs e)
        {
            loaUserControl uc = new loaUserControl();
            AddUserControl(uc);
        }

        private void btn_webCam_Click(object sender, EventArgs e)
        {
            webCamUserControl uc = new webCamUserControl();
            AddUserControl(uc);
        }

        private void btn_game_Click(object sender, EventArgs e)
        {
            gameUserControl uc = new gameUserControl();
            AddUserControl(uc);
        }

        private void btn_phuKien_Click(object sender, EventArgs e)
        {
            phuKienUserControl uc = new phuKienUserControl();
            AddUserControl(uc);
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            userUserControl uc = new userUserControl();
            AddUserControl(uc);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            thongKeUserControl uc = new thongKeUserControl();
            AddUserControl(uc);
        }

        private void adminHome_Load(object sender, EventArgs e)
        {
            if (UserController.CurrentUser != null)
            {
                txt_tenAdmin.Text = UserController.CurrentUser.HoTen;
                SetUserImage(UserController.CurrentUser.HinhAnh);
                MakeRoundedCorners(30);
            }
        }

        private void btn_dangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close(); // Đóng form hiện tại
            }
        }

        private void btn_donHang_Click(object sender, EventArgs e)
        {
            donHangAdmin uc = new donHangAdmin();
            AddUserControl(uc);
        }
    }
}
