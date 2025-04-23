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
    public partial class baoHanhAdmin : UserControl
    {
        private bool isThem = false;
        public baoHanhAdmin()
        {
            InitializeComponent();
        }
        public void LoadPhieuBaoHanh()
        {
            List<PhieuBaoHanh> dsPhieuBaoHanh = PhieuBaoHanhController.GetAllPhieuBaoHanh();
            dgvPhieuBaohanh.Rows.Clear();

            foreach (PhieuBaoHanh pbh in dsPhieuBaoHanh)
            {
                dgvPhieuBaohanh.Rows.Add(
                   pbh.Id,
                   pbh.TenPhieu,
                   pbh.Gia,
                   pbh.SoLuong,
                   pbh.ThoiHanThang
                );
            }
        }
        private void ClearForm()
        {
            txt_id.Clear();
            txt_tenPhieu.Clear();
            txt_soLuong.Clear();
            txt_thoiHan.Clear();
            txt_gia.Clear();
            
        }

        private void baoHanhAdmin_Load(object sender, EventArgs e)
        {
            LoadPhieuBaoHanh();
            dgvPhieuBaohanh.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dgvPhieuBaohanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuBaohanh.Rows[e.RowIndex];

                // Gán dữ liệu từ dòng được chọn vào các textbox
                txt_id.Text = row.Cells["id"].Value?.ToString().Trim();
                txt_tenPhieu.Text = row.Cells["tenPhieu"].Value?.ToString().Trim();
                txt_gia.Text = row.Cells["gia"].Value?.ToString().Trim();
                txt_soLuong.Text = row.Cells["soLuong"].Value?.ToString().Trim();
                txt_thoiHan.Text = row.Cells["thoiHan"].Value?.ToString().Trim();
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
                txt_id.Text = PhieuBaoHanhController.GenerateNewPhieuBaoHanh();
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
                string.IsNullOrWhiteSpace(txt_tenPhieu.Text) ||
                string.IsNullOrWhiteSpace(txt_gia.Text) ||
                string.IsNullOrWhiteSpace(txt_soLuong.Text) ||
                string.IsNullOrWhiteSpace(txt_thoiHan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phiếu bảo hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra hợp lệ số
            if (!long.TryParse(txt_gia.Text, out long gia) || gia < 0)
            {
                MessageBox.Show("Giá trị không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt_soLuong.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt_thoiHan.Text, out int thoiHan) || thoiHan < 0)
            {
                MessageBox.Show("Thời hạn (tháng) phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã đã tồn tại (tùy bạn muốn thêm mới hay cập nhật thì xử lý khác nhau)
            // Ở đây ví dụ mặc định là thêm mới nên nếu mã đã tồn tại thì thông báo lỗi
            if (PhieuBaoHanhController.GetAllPhieuBaoHanh().Any(p => p.Id == txt_id.Text))
            {
                MessageBox.Show("Mã phiếu bảo hành đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng
            var phieu = new PhieuBaoHanh
            {
                Id = txt_id.Text,
                TenPhieu = txt_tenPhieu.Text,
                Gia = gia,
                SoLuong = soLuong,
                ThoiHanThang = thoiHan
            };

            // Thêm vào database
            PhieuBaoHanhController.AddPhieuBaoHanh(phieu);
            MessageBox.Show("Thêm phiếu bảo hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Làm mới
            ClearForm(); // Hàm xóa nội dung textbox
            btn_luu.Enabled = false;
            LoadPhieuBaoHanh(); // Hàm load lại dữ liệu DataGridView
        }



        private void btn_sua_Click(object sender, EventArgs e)
        {
        
            // Kiểm tra các ô thông tin không được để trống
            if (string.IsNullOrWhiteSpace(txt_id.Text) ||
                string.IsNullOrWhiteSpace(txt_tenPhieu.Text) ||
                string.IsNullOrWhiteSpace(txt_gia.Text) ||
                string.IsNullOrWhiteSpace(txt_soLuong.Text) ||
                string.IsNullOrWhiteSpace(txt_thoiHan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phiếu bảo hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng và giá trị hợp lệ
            if (!long.TryParse(txt_gia.Text, out long gia) || gia < 0)
            {
                MessageBox.Show("Giá trị không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt_soLuong.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt_thoiHan.Text, out int thoiHan) || thoiHan < 0)
            {
                MessageBox.Show("Thời hạn (tháng) phải là số nguyên không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var phieu = new PhieuBaoHanh
                {
                    Id = txt_id.Text.Trim(),
                    TenPhieu = txt_tenPhieu.Text.Trim(),
                    Gia = gia,
                    SoLuong = soLuong,
                    ThoiHanThang = thoiHan
                };

                PhieuBaoHanhController.UpdatePhieuBaoHanh(phieu);
                LoadPhieuBaoHanh();
                MessageBox.Show("Cập nhật phiếu bảo hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật phiếu bảo hành thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string maPhieu = txt_id.Text;

            // Kiểm tra mã có rỗng không
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                MessageBox.Show("Vui lòng chọn phiếu bảo hành để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_id.Focus();
                return;
            }

            // Xác nhận xóa
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu bảo hành này?",
                                         "Xác nhận xóa",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    PhieuBaoHanhController.DeletePhieuBaoHanh(maPhieu);
                    LoadPhieuBaoHanh(); // Hàm reload lại dữ liệu
                    MessageBox.Show("Xóa phiếu bảo hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm(); // Xóa nội dung form sau khi xóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa phiếu bảo hành thất bại! Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadPhieuBaoHanh(); // Nếu không nhập gì thì load toàn bộ
                return;
            }

            List<PhieuBaoHanh> ketQua = PhieuBaoHanhController.SearchPhieuBaoHanh(tuKhoa);
            dgvPhieuBaohanh.Rows.Clear();

            foreach (PhieuBaoHanh pbh in ketQua)
            {
                dgvPhieuBaohanh.Rows.Add(
                    pbh.Id,
                    pbh.TenPhieu,
                    pbh.Gia,
                    pbh.SoLuong,
                    pbh.ThoiHanThang
                );
            }

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phiếu bảo hành phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void baoHanhAdmin_Paint(object sender, PaintEventArgs e)
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
