using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Controller;
using LapStore.Model;

namespace LapStore.Widget.User
{
    public partial class profileUser : UserControl
    {
        string imagePathNew;
        public profileUser()
        {
            InitializeComponent();
            imageUser.BringToFront();
            txt_pass.UseSystemPasswordChar = true;
        }

        private void profileUser_Load(object sender, EventArgs e)
        {
            if (UserController.CurrentUser != null)
            {
                txtTen.Text = UserController.CurrentUser.HoTen;
                txt_tenUser.Text = UserController.CurrentUser.HoTen;
                txt_email.Text = UserController.CurrentUser.Email;
                txt_diaChi.Text = UserController.CurrentUser.DiaChi;
                txt_sdt.Text = UserController.CurrentUser.Sdt;
                txt_pass.Text = UserController.CurrentUser.Pass;
                SetUserImage(UserController.CurrentUser.HinhAnh);
            }
        }
        private void Load1()
        {
            if (UserController.CurrentUser != null)
            {
                txtTen.Text = UserController.CurrentUser.HoTen;
                txt_tenUser.Text = UserController.CurrentUser.HoTen;
                txt_email.Text = UserController.CurrentUser.Email;
                txt_diaChi.Text = UserController.CurrentUser.DiaChi;
                txt_sdt.Text = UserController.CurrentUser.Sdt;
                txt_pass.Text = UserController.CurrentUser.Pass;
                imagePathNew = UserController.CurrentUser.HinhAnh;
                SetUserImage(UserController.CurrentUser.HinhAnh);
               
            }
        }
        private void SetUserImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
            {
                imageUser.ImageLocation = imagePath;
            }
            else
            {
                imageUser.Image = null;
                imageUser.BackColor = Color.Gray; // Nếu không có ảnh, đổi màu PictureBox thành đỏ
            }
        }

        private void background_Paint(object sender, PaintEventArgs e)
        {
            // Lấy kích thước của control
            Rectangle rect = this.ClientRectangle;

            // Tạo brush gradient từ xanh đen (#2C3E50) sang xanh lục nhạt (#4CA1AF)
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                rect,
                ColorTranslator.FromHtml("#DBE6F6"),
                ColorTranslator.FromHtml("#C5796D"),   // Màu 2
                45f))                                  // Góc gradient (90 độ)
            {
                // Vẽ nền với gradient
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txtTen.Enabled = true;
            txt_pass.Enabled = true;
            txt_sdt.Enabled = true;
            txt_email.Enabled = true;
            txt_diaChi.Enabled = true;
            btn_huy.Visible = true;
            btn_suaAnh.Enabled = true;
            btn_luu.Visible = true;
            btn_sua.Visible = false;

          
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txtTen.Enabled = false;
            txt_pass.Enabled = false;
            txt_sdt.Enabled = false;
            txt_email.Enabled = false;
            txt_diaChi.Enabled = false;
            btn_huy.Visible = false;
            btn_suaAnh.Enabled = false;
            btn_luu.Visible = false;
            btn_sua.Visible = true;
            Load1();


        }

        private void btn_suaAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn hình ảnh";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    SetUserImage(ofd.FileName);
                    imagePathNew = ofd.FileName;
                    imageUser.Tag = imagePathNew; // Lưu đường dẫn vào Tag
                }
            }
        }


        private void showPass_Click(object sender, EventArgs e)
        {
            // Đảo trạng thái UseSystemPasswordChar
            txt_pass.UseSystemPasswordChar = !txt_pass.UseSystemPasswordChar;

            // Thay đổi icon trên nút
            if (txt_pass.UseSystemPasswordChar == false)
            {
                showPass.Image = Properties.Resources.icons8_hide_32; // Icon ẩn mật khẩu
            }
            else
            {
                showPass.Image = Properties.Resources.icons8_visibility_32; // Icon hiện mật khẩu
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (!Database.CheckNull(UserController.CurrentUser.Id) ||
                !Database.CheckEmailNull(txt_email.Text, UserController.CurrentUser.Id) ||
                !Database.KiemTraSoDienThoai(txt_sdt.Text))
            {
                return;
            }

            if (string.IsNullOrEmpty(imagePathNew))
            {
                imagePathNew = UserController.CurrentUser.HinhAnh; // Giữ ảnh cũ nếu không thay đổi
            }

            var user = new UserModel
            {
                Id = UserController.CurrentUser.Id,
                HoTen = txtTen.Text,
                Email = txt_email.Text,
                Pass = txt_pass.Text,
                Sdt = txt_sdt.Text,
                DiaChi = txt_diaChi.Text,
                HinhAnh = imagePathNew,
                Check = UserController.CurrentUser.Check
            };

            UserController.UpdateUser(user);

            // 🔥 Load lại dữ liệu của CurrentUser sau khi cập nhật
            UserController.LoadCurrentUser(user.Id);

            MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTen.Enabled = false;
            txt_pass.Enabled = false;
            txt_sdt.Enabled = false;
            txt_email.Enabled = false;
            txt_diaChi.Enabled = false;
            btn_huy.Visible = false;
            btn_suaAnh.Enabled = false;
            btn_luu.Visible = false;
            btn_sua.Visible = true;
            Load1();
        }

        private void btn_yeuThich_Click(object sender, EventArgs e)
        {

        }

        private void btn_maGiamGia_Click(object sender, EventArgs e)
        {

        }
    }
}
