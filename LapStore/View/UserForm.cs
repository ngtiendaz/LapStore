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
            txt_timKiem.Text = string.Empty;

        }

        private void btn_cart_Click(object sender, EventArgs e)
        {
            gioHang uc = new gioHang();
            AddUserControl(uc);

        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            profileUser uc = new profileUser();
            AddUserControl(uc);
        }
        public void ShowDetailSanPham(SanPham sp)
        {
            detailSanPham detailPanel = new detailSanPham(sp);
            AddUserControl(detailPanel);
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

        private void userHome_Load(object sender, EventArgs e)
        {
            MakeRoundedCorners(30);
        }

        private void btn_logOut_Click(object sender, EventArgs e)
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

        private  void btn_timKiem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu ô tìm kiếm rỗng thì không thực hiện tìm kiếm
            if (string.IsNullOrWhiteSpace(txt_timKiem.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            timKiemSanPham uc = new timKiemSanPham();
            uc.SetDanhMuc(txt_timKiem.Text); // Truyền key

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl tìm kiếm
            }
        }


        private void btn_Laptop_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM001","LapTop"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }

        private void btn_ManHinh_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM002", "Màn hình"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }

        private void btn_PC_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM003", "PC"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }

        private void btn_phim_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM004", "Bàn phím"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }

        private void btn_chuot_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM005", "Chuột máy tính"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }

        private void btn_taiNghe_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM006", "Tai nghe"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }

        private void btn_mic_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM007", "Microphone"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }

        private void btn_Loa_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM008", "Loa"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }

        private void btn_webCam_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM009", "Webcam & Camera"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }

        private void btn_game_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM010", "Máy chơi game"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }

        private void btn_phuKien_Click(object sender, EventArgs e)
        {
            danhMuc uc = new danhMuc();
            uc.SetDanhMuc("DM011", "Phụ kiện các loại"); // Truyền mã danh mục

            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.AddUserControl(uc); // Chuyển sang UserControl danhMuc
            }
        }
    }
}
