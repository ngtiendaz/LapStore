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
    public partial class maGiamGiaAdmin : UserControl
    {
        private bool isThem = false;
        public maGiamGiaAdmin()
        {
            InitializeComponent();
        }

        private void maGiamGiaAdmin_Load(object sender, EventArgs e)
        {
            LoadMaGiamGia();
            dgvMaGiamGia.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void ClearForm()
        {
            txt_id.Clear();
            txt_tenMa.Clear();
            txt_soLuong.Clear();
            txt_phanTramGiam.Clear();
            txt_giaApDung.Clear();
            date_batDau.Value = DateTime.Now;
            date_ketThuc.Value = DateTime.Now;
        }

        private void maGiamGiaAdmin_Paint(object sender, PaintEventArgs e)
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
        public void LoadMaGiamGia()
        {
            List<MaGiamGia> dsMaGiamGia = MaGiamGiaController.GetAllMaGiamGia();
            dgvMaGiamGia.Rows.Clear();

            foreach (MaGiamGia mgg in dsMaGiamGia)
            {
                dgvMaGiamGia.Rows.Add(
                    mgg.Id,
                    mgg.TenMa,
                    mgg.PhanTramGiam,
                    mgg.SoLuong,
                    mgg.NgayBatDau.ToString("dd/MM/yyyy"),
                    mgg.NgayKetThuc.ToString("dd/MM/yyyy"),
                    mgg.DieuKienApDung
                );
            }
        }

        private void dgvMaGiamGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMaGiamGia.Rows[e.RowIndex];

                // Gán dữ liệu từ dòng được chọn vào các textbox
                txt_id.Text = row.Cells["id"].Value?.ToString().Trim();
                txt_tenMa.Text = row.Cells["tenMa"].Value?.ToString().Trim();
                txt_phanTramGiam.Text = row.Cells["phanTramGiam"].Value?.ToString().Trim();
                txt_soLuong.Text = row.Cells["soLuong"].Value?.ToString().Trim();
                date_batDau.Value = DateTime.Parse(row.Cells["ngayBatDau"].Value?.ToString());
                date_ketThuc.Value = DateTime.Parse(row.Cells["ngayKetThuc"].Value?.ToString());
                txt_giaApDung.Text = row.Cells["dieuKien"].Value?.ToString().Trim();
            }
        }

        private void btn_themMoi_Click(object sender, EventArgs e)
        {
            isThem = !isThem;

            if (isThem)
            {
                btn_luu.Enabled = true;
                btn_themMoi.Text = "Hủy";
                ClearForm();
                txt_id.Text = MaGiamGiaController.GenerateNewMaGiamGia();
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
                string.IsNullOrWhiteSpace(txt_tenMa.Text) ||
                string.IsNullOrWhiteSpace(txt_phanTramGiam.Text) ||
                string.IsNullOrWhiteSpace(txt_soLuong.Text) ||
                string.IsNullOrWhiteSpace(txt_giaApDung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã giảm giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra hợp lệ số
            if (!int.TryParse(txt_phanTramGiam.Text, out int phanTram) || phanTram <= 0 || phanTram > 100)
            {
                MessageBox.Show("Phần trăm giảm không hợp lệ! (1 - 100)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt_soLuong.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(txt_giaApDung.Text, out long dieuKien) || dieuKien < 0)
            {
                MessageBox.Show("Điều kiện áp dụng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ngày tháng
            if (date_batDau.Value >= date_ketThuc.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã đã tồn tại chưa
            if (!Database.KiemTraMaGiamGia(txt_id.Text)) // Bạn cần có hàm kiểm tra này
            {
                return;
            }

            // Tạo đối tượng
            var maGiamGia = new MaGiamGia
            {
                Id = txt_id.Text,
                TenMa = txt_tenMa.Text,
                PhanTramGiam = phanTram,
                SoLuong = soLuong,
                NgayBatDau = date_batDau.Value,
                NgayKetThuc = date_ketThuc.Value,
                DieuKienApDung = dieuKien
            };

            // Thêm vào database
            MaGiamGiaController.AddMaGiamGia(maGiamGia);
            MessageBox.Show("Thêm mã giảm giá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Làm mới
            ClearForm();
            btn_luu.Enabled = false;
            LoadMaGiamGia(); // Hàm load lại dữ liệu DataGridView
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô thông tin không được để trống
            if (string.IsNullOrWhiteSpace(txt_id.Text) ||
                string.IsNullOrWhiteSpace(txt_tenMa.Text) ||
                string.IsNullOrWhiteSpace(txt_phanTramGiam.Text) ||
                string.IsNullOrWhiteSpace(txt_soLuong.Text) ||
                string.IsNullOrWhiteSpace(txt_giaApDung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã giảm giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng và giá trị hợp lệ
            if (!int.TryParse(txt_phanTramGiam.Text, out int phanTram) || phanTram <= 0 || phanTram > 100)
            {
                MessageBox.Show("Phần trăm giảm phải là số nguyên từ 1 đến 100!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt_soLuong.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(txt_giaApDung.Text, out long dieuKien) || dieuKien < 0)
            {
                MessageBox.Show("Điều kiện áp dụng phải là số không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (date_batDau.Value >= date_ketThuc.Value)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var maGiamGia = new MaGiamGia
                {
                    Id = txt_id.Text.Trim(),
                    TenMa = txt_tenMa.Text.Trim(),
                    PhanTramGiam = phanTram,
                    SoLuong = soLuong,
                    NgayBatDau = date_batDau.Value,
                    NgayKetThuc = date_ketThuc.Value,
                    DieuKienApDung = dieuKien
                };

                MaGiamGiaController.UpdateMaGiamGia(maGiamGia);
                LoadMaGiamGia();
                MessageBox.Show("Cập nhật mã giảm giá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật mã giảm giá thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Lấy mã giảm giá từ TextBox
            string maGiamGia = txt_id.Text;

            // Kiểm tra mã giảm giá có rỗng không
            if (string.IsNullOrWhiteSpace(maGiamGia))
            {
                MessageBox.Show("Vui lòng chọn mã giảm giá để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_id.Focus();
                return;
            }

            // Xác nhận trước khi xóa
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa mã giảm giá này?",
                                         "Xác nhận xóa",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gọi hàm xóa mã giảm giá
                    MaGiamGiaController.DeleteMaGiamGia(maGiamGia);

                    // Tải lại dữ liệu sau khi xóa
                    LoadMaGiamGia(); // Hàm load lại mã giảm giá lên DataGridView
                    MessageBox.Show("Xóa mã giảm giá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(); // Xóa nội dung form sau khi xóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa mã giảm giá thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadMaGiamGia(); // Nếu không nhập gì thì load lại toàn bộ
                return;
            }

            List<MaGiamGia> ketQua = MaGiamGiaController.SearchMaGiamGia(keyword);
            dgvMaGiamGia.Rows.Clear();

            foreach (MaGiamGia mgg in ketQua)
            {
                dgvMaGiamGia.Rows.Add(
                    mgg.Id,
                    mgg.TenMa,
                    mgg.PhanTramGiam,
                    mgg.SoLuong,
                    mgg.NgayBatDau.ToString("dd/MM/yyyy"),
                    mgg.NgayKetThuc.ToString("dd/MM/yyyy"),
                    mgg.DieuKienApDung
                );
            }

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy mã giảm giá phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

