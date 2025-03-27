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

namespace LapStore.Widget.User
{
    public partial class profileUser : UserControl
    {
        public profileUser()
        {
            InitializeComponent();
        }

        private void profileUser_Load(object sender, EventArgs e)
        {
            if (UserController.CurrentUser != null)
            {
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
                txt_tenUser.Text = UserController.CurrentUser.HoTen;
                txt_email.Text = UserController.CurrentUser.Email;
                txt_diaChi.Text = UserController.CurrentUser.DiaChi;
                txt_sdt.Text = UserController.CurrentUser.Sdt;
                txt_pass.Text = UserController.CurrentUser.Pass;
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
                imageUser.BackColor = Color.Red; // Nếu không có ảnh, đổi màu PictureBox thành đỏ
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
            txt_pass.Enabled = true;
            txt_sdt.Enabled = true;
            txt_email.Enabled = true;
            txt_diaChi.Enabled = true;
            btn_huy.Visible = true;
            btn_suaAnh.Visible = true;
            btn_luu.Visible = true;
            btn_sua.Visible = false;
          
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_pass.Enabled = false;
            txt_sdt.Enabled = false;
            txt_email.Enabled = false;
            txt_diaChi.Enabled = false;
            btn_huy.Visible = false;
            btn_suaAnh.Visible = false;
            btn_luu.Visible = false;
            btn_sua.Visible = true;
            Load1();
            

        }
    }
}
