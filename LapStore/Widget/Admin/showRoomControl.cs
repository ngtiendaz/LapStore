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
    public partial class showRoomControl : UserControl
    {
        private bool isThem = false;
        public showRoomControl()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            txt_id.Clear();
            txt_tenCuaHang.Clear();
            txt_sdt.Clear();
            txt_email.Clear();
            txt_diaChi.Clear();
            txt_gioMoCua.Clear();
            txt_gioDongCua.Clear();

        }
        public void LoadShowRoom()
        {
            List<ShowRoom> dsShowRoom = ShowRoomController.GetAllShowRoom();
            dgvShowRoom.Rows.Clear();

            foreach (ShowRoom sr in dsShowRoom)
            {
                dgvShowRoom.Rows.Add(
                   sr.Id,
                   sr.TenCuaHang,
                   sr.Email,
                   sr.SoDienThoai,
                   sr.DiaChi,
                   sr.GioMoCua,
                   sr.GioDongCua
                );
            }
        }

        private void showRoomControl_Load(object sender, EventArgs e)
        {
            LoadShowRoom();
            dgvShowRoom.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btn_themMoi_Click(object sender, EventArgs e)
        {
            isThem = !isThem;

            if (isThem)
            {
                btn_luu.Enabled = true;
                btn_themMoi.Text = "Hủy";
                ClearForm();
                txt_id.Text = ShowRoomController.GenerateNewShowRoomId();
            }
            else
            {
                btn_luu.Enabled = false;
                btn_themMoi.Text = "Thêm Mới";
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            // Kiểm tra ô trống
            if (string.IsNullOrWhiteSpace(txt_id.Text) ||
                string.IsNullOrWhiteSpace(txt_tenCuaHang.Text) ||
                string.IsNullOrWhiteSpace(txt_diaChi.Text) ||
                string.IsNullOrWhiteSpace(txt_sdt.Text) ||
                string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_gioMoCua.Text) ||
                string.IsNullOrWhiteSpace(txt_gioDongCua.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin showroom!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng giờ mở/đóng cửa
            if (!TimeSpan.TryParse(txt_gioMoCua.Text, out TimeSpan gioMo) ||
                !TimeSpan.TryParse(txt_gioDongCua.Text, out TimeSpan gioDong))
            {
                MessageBox.Show("Giờ mở cửa và đóng cửa phải đúng định dạng (ví dụ: 08:00)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã đã tồn tại
            if (ShowRoomController.GetAllShowRoom().Any(s => s.Id == txt_id.Text))
            {
                MessageBox.Show("Mã showroom đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng ShowRoom
            var showroom = new ShowRoom
            {
                Id = txt_id.Text.Trim(),
                TenCuaHang = txt_tenCuaHang.Text.Trim(),
                DiaChi = txt_diaChi.Text.Trim(),
                SoDienThoai = txt_sdt.Text.Trim(),
                Email = txt_email.Text.Trim(),
                GioMoCua = gioMo,
                GioDongCua = gioDong
            };

            // Thêm showroom vào database
            ShowRoomController.AddShowRoom(showroom);
            MessageBox.Show("Thêm showroom thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Làm mới
            ClearForm(); // Xóa nội dung các TextBox
            btn_luu.Enabled = false;
            LoadShowRoom(); // Hàm load lại danh sách showroom vào DataGridView

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô thông tin không được để trống
            if (string.IsNullOrWhiteSpace(txt_id.Text) ||
                string.IsNullOrWhiteSpace(txt_tenCuaHang.Text) ||
                string.IsNullOrWhiteSpace(txt_diaChi.Text) ||
                string.IsNullOrWhiteSpace(txt_sdt.Text) ||
                string.IsNullOrWhiteSpace(txt_email.Text) ||
                string.IsNullOrWhiteSpace(txt_gioMoCua.Text) ||
                string.IsNullOrWhiteSpace(txt_gioDongCua.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin showroom!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng giờ mở cửa và đóng cửa
            if (!TimeSpan.TryParse(txt_gioMoCua.Text, out TimeSpan gioMoCua))
            {
                MessageBox.Show("Giờ mở cửa không hợp lệ! Định dạng đúng: HH:mm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TimeSpan.TryParse(txt_gioDongCua.Text, out TimeSpan gioDongCua))
            {
                MessageBox.Show("Giờ đóng cửa không hợp lệ! Định dạng đúng: HH:mm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var showroom = new ShowRoom
                {
                    Id = txt_id.Text.Trim(),
                    TenCuaHang = txt_tenCuaHang.Text.Trim(),
                    DiaChi = txt_diaChi.Text.Trim(),
                    SoDienThoai = txt_sdt.Text.Trim(),
                    Email = txt_email.Text.Trim(),
                    GioMoCua = gioMoCua,
                    GioDongCua = gioDongCua
                };

                ShowRoomController.UpdateShowRoom(showroom);
                LoadShowRoom(); // Hàm load lại danh sách showroom
                MessageBox.Show("Cập nhật showroom thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(); // Hàm xóa trắng form nhập
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật showroom thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   


        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;

            // Kiểm tra mã có rỗng không
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Vui lòng chọn showroom để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_id.Focus();
                return;
            }

            // Xác nhận xóa
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa showroom này?",
                                         "Xác nhận xóa",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ShowRoomController.DeleteShowRoom(id);
                    LoadShowRoom(); // Hàm reload lại dữ liệu
                    MessageBox.Show("Xóa showroom thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(); // Xóa nội dung form sau khi xóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa showroom thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadShowRoom(); // Nếu không nhập gì thì load toàn bộ
                return;
            }

            List<ShowRoom> ketQua = ShowRoomController.TimKiemShowRoom(tuKhoa);
            dgvShowRoom.Rows.Clear();

            foreach (ShowRoom sr in ketQua)
            {
                dgvShowRoom.Rows.Add(
                    sr.Id,
                    sr.TenCuaHang,
                    sr.Email,
                    sr.SoDienThoai,
                    sr.DiaChi,
                    sr.GioMoCua,
                    sr.GioDongCua
                 );
            }
        }

        private void dgvShowRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvShowRoom.Rows[e.RowIndex];

                // Gán dữ liệu từ dòng được chọn vào các textbox
                txt_id.Text = row.Cells["id"].Value?.ToString().Trim();
                txt_tenCuaHang.Text = row.Cells["tenCh"].Value?.ToString().Trim();
                txt_email.Text = row.Cells["email"].Value?.ToString().Trim();
                txt_sdt.Text = row.Cells["sdt"].Value?.ToString().Trim();
                txt_diaChi.Text = row.Cells["diaChi"].Value?.ToString().Trim();
                txt_gioMoCua.Text = row.Cells["gioMoCua"].Value?.ToString().Trim();
                txt_gioDongCua.Text = row.Cells["gioDongCua"].Value?.ToString().Trim();
            }
        }

        private void showRoomControl_Paint(object sender, PaintEventArgs e)
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
    }
}
