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
using LapStore.Widget.User;
using Microsoft.VisualBasic.ApplicationServices;

namespace LapStore.Widget
{
    public partial class userUserControl : UserControl
    {
        string imagePath;
        public userUserControl()
        {
            InitializeComponent();
           
        }
        private void ClearForm()
        {
            txtId.Clear();
            txtTen.Clear();
            txtEmail.Clear();
            txtPass.Clear();
            txtDiaChi.Clear();
            txt_sdt.Clear();
            cbb_role.SelectedValue = 1;
            imageSp.Image = null;
            imageSp.BackColor = Color.Red;
        }


        private void LoadComboBoxRole()
        {
            Dictionary<int, string> roles = new Dictionary<int, string>
    {
        { 1, "USER" },  // USER = 1
        { 0, "ADMIN" }  // ADMIN = 0
    };

            cbb_role.DataSource = new BindingSource(roles, null);
            cbb_role.DisplayMember = "Value"; // Hiển thị "USER" hoặc "ADMIN"
            cbb_role.ValueMember = "Key"; // Giá trị thực tế 1 hoặc 0
        }



        public void LoadingData()
        {
            List<UserModel> users = UserController.GetAllUsers();
            dgvUser.Rows.Clear();

            foreach (UserModel user in users)
            {
                // Khởi tạo ảnh từ đường dẫn (nếu có)
                Image img = null;
                if (!string.IsNullOrEmpty(user.HinhAnh) && System.IO.File.Exists(user.HinhAnh))
                {
                    try
                    {
                        using (var bmpTemp = new Bitmap(user.HinhAnh))
                        {
                            img = new Bitmap(bmpTemp, new Size(80, 80)); // Resize ảnh về 80x80
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                    }
                }

                // Thêm hàng mới vào DataGridView
                int rowIndex = dgvUser.Rows.Add(
                    img,             // Hình ảnh
                    user.Id,         // ID người dùng
                    user.HoTen,      // Họ tên
                    user.Email,      // Email
                    user.Pass,
                    user.Sdt,
                    user.DiaChi,     // Địa chỉ

                    user.Check ? "USER" : "ADMIN" // Phân quyền (Check = 1 là USER, 0 là ADMIN)
                );

                // Lưu đường dẫn ảnh vào thuộc tính Tag
                dgvUser.Rows[rowIndex].Cells["HinhAnh"].Tag = user.HinhAnh;
            }
        }

        private void userUserControl_Paint(object sender, PaintEventArgs e)
        {
            // Lấy kích thước của control
            Rectangle rect = this.ClientRectangle;

            // Tạo brush gradient từ xanh đen (#2C3E50) sang xanh lục nhạt (#4CA1AF)
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                rect,
                ColorTranslator.FromHtml("#000000"),
                ColorTranslator.FromHtml("#434343"),   // Màu 2
                45f))                                  // Góc gradient (90 độ)
            {
                // Vẽ nền với gradient
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void userUserControl_Load(object sender, EventArgs e)
        {
            LoadingData();
            LoadComboBoxRole();
            dgvUser.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUser.Rows[e.RowIndex];

                // Lấy thông tin từ các ô
                txtId.Text = row.Cells["id"].Value?.ToString().Trim();
                txtTen.Text = row.Cells["ten"].Value?.ToString().Trim();
                txtEmail.Text = row.Cells["email"].Value?.ToString().Trim();
                txtPass.Text = row.Cells["pass"].Value?.ToString().Trim();
                txt_sdt.Text = row.Cells["sdt"].Value?.ToString().Trim();
                txtDiaChi.Text = row.Cells["diachi"].Value?.ToString().Trim();
                string roleText = row.Cells["role"].Value?.ToString().Trim();
                cbb_role.SelectedValue = roleText == "USER" ? 1 : 0; // USER -> 1, ADMIN -> 0

                // Hiển thị hình ảnh lên PictureBox
                try
                {
                    imagePath = row.Cells["HinhAnh"].Tag?.ToString();
                    if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                    {
                        using (var bmpTemp = new Bitmap(imagePath))
                        {
                            imageSp.Image = new Bitmap(bmpTemp);
                            imageSp.Tag = imagePath;
                        }
                        imageSp.BackColor = Color.Transparent; // Không có màu nền khi có ảnh
                    }
                    else
                    {
                        imageSp.Image = null;
                        imageSp.BackColor = Color.Red; // Đặt màu nền đỏ khi không có ảnh
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị hình ảnh: " + ex.Message);
                    imageSp.Image = null;
                    imageSp.BackColor = Color.Red; // Đặt màu nền đỏ khi xảy ra lỗi
                }
            }
        }

        private void btn_newID_Click(object sender, EventArgs e)
        {
            txtId.Text = UserController.GenerateNewMaUser().ToString();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            List<UserModel> ketQua = UserController.SearchUsers(keyword);
            dgvUser.Rows.Clear();
            foreach (UserModel user in ketQua)
            {
                // Khởi tạo ảnh từ đường dẫn (nếu có)
                Image img = null;
                if (!string.IsNullOrEmpty(user.HinhAnh) && System.IO.File.Exists(user.HinhAnh))
                {
                    try
                    {
                        using (var bmpTemp = new Bitmap(user.HinhAnh))
                        {
                            img = new Bitmap(bmpTemp, new Size(80, 80)); // Resize ảnh về 80x80
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                    }
                }

                // Thêm hàng mới vào DataGridView
                int rowIndex = dgvUser.Rows.Add(
                    img,             // Hình ảnh
                    user.Id,         // ID người dùng
                    user.HoTen,      // Họ tên
                    user.Email,      // Email
                    user.Pass,
                    user.Sdt,
                    user.DiaChi,     // Địa chỉ

                    user.Check ? "USER" : "ADMIN" // Phân quyền (Check = 1 là USER, 0 là ADMIN)
                );

                // Lưu đường dẫn ảnh vào thuộc tính Tag
                dgvUser.Rows[rowIndex].Cells["HinhAnh"].Tag = user.HinhAnh;
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập vào
            if (!Database.KiemTraIdUser(txtId.Text) ||
                !Database.KiemTraEmail(txtEmail.Text) ||
                !Database.KiemTraMatKhau(txtPass.Text) ||
                !Database.KiemTraSoDienThoai(txt_sdt.Text))
            {
                return; // Dừng nếu có lỗi
            }

            // Kiểm tra xem có ảnh hay không
            imagePath = imageSp.Tag?.ToString() ?? "";

            // Tạo đối tượng UserModel để lưu vào database
            var user = new UserModel
            {
                Id = txtId.Text,
                HoTen = txtTen.Text,
                Email = txtEmail.Text,
                Pass = txtPass.Text,
                Sdt = txt_sdt.Text,
                DiaChi = txtDiaChi.Text,
                HinhAnh = imagePath,
                Check = Convert.ToInt32(cbb_role.SelectedValue) == 1 // Chọn USER thì lưu 1, ADMIN thì lưu 0
            };

            // Gọi hàm thêm user
            UserController.AddUser(user);
            LoadingData(); // Load lại danh sách user
            MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm(); // Xóa nội dung trên form sau khi thêm thành công


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Sử dụng hàm kiểm tra từ lớp Database
            if (!Database.CheckNull(txtId.Text) ||
                !Database.CheckEmailNull(txtEmail.Text,txtId.Text) ||
                !Database.KiemTraSoDienThoai(txt_sdt.Text))
            {
                return;
            }

            // Kiểm tra xem có ảnh đại diện hay không
            imagePath = imageSp.Tag?.ToString() ?? "";
            

            var user = new UserModel
            {

                Id = txtId.Text,
                HoTen = txtTen.Text,
                Email = txtEmail.Text,
                Pass = txtPass.Text,
                Sdt = txt_sdt.Text,
                DiaChi = txtDiaChi.Text,
                HinhAnh = imagePath,
                Check = Convert.ToInt32(cbb_role.SelectedValue) == 1 // Chọn USER thì lưu 1, ADMIN thì lưu 0
            };

            // Gọi hàm cập nhật thông tin người dùng
            UserController.UpdateUser(user);
            LoadingData();
            MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy ID người dùng từ TextBox
            string userId = txtId.Text;

            // Kiểm tra ID người dùng có rỗng không
            if (string.IsNullOrWhiteSpace(userId))
            {
                MessageBox.Show("Vui lòng nhập ID người dùng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return;
            }

            // Xác nhận trước khi xóa
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?",
                                         "Xác nhận xóa",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gọi hàm xóa user
                    UserController.DeleteUser(userId);

                    // Tải lại dữ liệu sau khi xóa
                    LoadingData();
                    MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa người dùng thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_taiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn hình ảnh";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị hình ảnh lên PictureBox
                    imageSp.Image = new Bitmap(ofd.FileName);
                    imageSp.Tag = ofd.FileName; // Lưu đường dẫn vào Tag
                }
            }
        }
    }
}
