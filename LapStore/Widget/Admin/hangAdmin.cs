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

namespace LapStore.Widget.Admin
{

    public partial class hangAdmin : UserControl
    {

        private bool isThem = false;
        public hangAdmin()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            txt_maHang.Clear();
            txt_tenHang.Clear();
        }
        public void LoadHang()
        {
            List<Hang> hangs = HangController.GetAllHang();
            dgvHang.Rows.Clear();

            foreach (Hang h in hangs)
            {
                dgvHang.Rows.Add(h.Id, h.TenHang);
            }
        }
        private void hangAdmin_Load(object sender, EventArgs e)
        {
            LoadHang();
            dgvHang.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void hangAdmin_Paint(object sender, PaintEventArgs e)
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

        private void btn_themMoi_Click_1(object sender, EventArgs e)
        {
            isThem = !isThem;

            if (isThem)
            {
                btn_luu.Enabled = true;
                btn_themMoi.Text = "Hủy";
                ClearForm();
                txt_maHang.Text = HangController.GenerateNewMaHang();
            }
            else
            {
                btn_luu.Enabled = false;
                btn_themMoi.Text = "Thêm Mới";
            }
        }

        private void btn_luu_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_maHang.Text) ||
                string.IsNullOrWhiteSpace(txt_tenHang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã và tên hãng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã danh mục đã tồn tại chưa
            if (!Database.KiemTraMaHang(txt_maHang.Text))
            {
                return;
            }

            var hang = new Hang
            {
                Id = txt_maHang.Text,
                TenHang = txt_tenHang.Text
            };

            // Thêm danh mục vào database
            HangController.AddHang(hang);

            MessageBox.Show("Thêm hãng hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Làm mới form hoặc load lại dữ liệu
            ClearForm();
            btn_luu.Enabled = false;
            LoadHang();
        }

        private void btn_sua_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra mã danh mục và tên danh mục không được để trống
            if (string.IsNullOrWhiteSpace(txt_maHang.Text) ||
                string.IsNullOrWhiteSpace(txt_tenHang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hãng hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hang = new Hang
            {
                Id = txt_maHang.Text.Trim(),
                TenHang = txt_tenHang.Text.Trim()
            };

            try
            {
                HangController.UpdateHang(hang); // Hàm cập nhật danh mục
                LoadHang(); // Load lại danh sách danh mục
                MessageBox.Show("Cập nhật hãng thành công!");
                ClearForm(); // Xóa nội dung form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật hãng thất bại! Lỗi: " + ex.Message);
            }
        }

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHang.Rows[e.RowIndex];

                // Gán dữ liệu từ dòng được chọn vào các textbox
                txt_maHang.Text = row.Cells["id"].Value?.ToString().Trim();
                txt_tenHang.Text = row.Cells["tenHang"].Value?.ToString().Trim();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Lấy mã danh mục từ TextBox
            string maHang = txt_maHang.Text;

            // Kiểm tra mã danh mục có rỗng không
            if (string.IsNullOrWhiteSpace(maHang))
            {
                MessageBox.Show("Vui lòng chọn mã hãng để xóa!");
                txt_maHang.Focus();
                return;
            }

            // Xác nhận trước khi xóa
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa hãng này?",
                                         "Xác nhận xóa",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gọi hàm xóa danh mục
                    HangController.DeleteHang(maHang);

                    // Tải lại dữ liệu sau khi xóa
                    LoadHang(); // hàm load lại danh mục lên DataGridView
                    MessageBox.Show("Xóa hãng thành công!");
                    ClearForm(); // xóa nội dung form sau khi xóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa hãng thất bại! Lỗi: " + ex.Message);
                }
            }
        }
    }
}
