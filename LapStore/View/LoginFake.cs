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

namespace LapStore.View
{
    public partial class LoginFake : Form
    {
        public LoginFake()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string role = UserController.Login(txt_email.Text, txt_pass.Text);

            if (role == "USER")
            {
                MessageBox.Show("Đăng nhập thành công! Chuyển đến User Form.");
                userHome userForm = new userHome();
                userForm.Show();
                this.Hide();
            }
            else if (role == "ADMIN")
            {
                MessageBox.Show("Đăng nhập thành công! Chuyển đến Admin Form.");
                adminHome adminForm = new adminHome();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
