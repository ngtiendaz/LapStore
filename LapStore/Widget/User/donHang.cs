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
    public partial class donHang : UserControl
    {
        string MADONHANG;
        public donHang()
        {
            InitializeComponent();
        }
            private void LoadTrangThaiToComboBox()
            {
                cbb_trangThai.Items.Clear();

                        // Giả sử các trạng thái có thể là:
                        var trangThaiList = new List<string>
                {
                    "Chờ thanh toán",
                    "Đang giao",
                    "Giao thành công",
                    "Yêu cầu hủy",
                    "Đã hủy"
                };

                cbb_trangThai.Items.AddRange(trangThaiList.ToArray());
                cbb_trangThai.SelectedIndex = 0; // Chọn mặc định trạng thái đầu
            }

        private void donHang_Load(object sender, EventArgs e)
        {
            LoadTrangThaiToComboBox();
            LoadDonHangTheoTrangThai(cbb_trangThai.Text);
            dgvDonHang.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void LoadDonHangTheoTrangThai(string trangThai)
        {
            var donHangList = DonHangController.GetDonHangTheoTrangThai(trangThai);

            dgvDonHang.Rows.Clear(); // Xóa dữ liệu cũ (nếu bạn không dùng `DataSource`)

            foreach (var dh in donHangList)
            {
                dgvDonHang.Rows.Add(
                    dh.Id,
                    dh.Sdt,
                    dh.DiaChi,
                    dh.TongTien.ToString("N0") + "đ",
                    dh.PhuongThucThanhToan,
                    dh.TrangThai,
                    dh.CreatedAt.ToString("dd/MM/yyyy HH:mm")
                );
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string selectedTrangThai = cbb_trangThai.Text;
            LoadDonHangTheoTrangThai(selectedTrangThai);
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            string maDonHang = MADONHANG;
            string trangThaiMoi = "Yêu cầu hủy";

            if (string.IsNullOrEmpty(maDonHang))
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để gửi yêu cầu hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy trạng thái hiện tại của đơn hàng
            string trangThaiHienTai = DonHangController.GetTrangThaiDonHang(maDonHang);

            if (trangThaiHienTai != "Chờ thanh toán")
            {
                MessageBox.Show("❌ Chỉ có thể hủy khi còn ở trạng thái 'Chờ thanh toán'!", "Không thể hủy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn gửi yêu cầu hủy đơn hàng này không?",
                "Xác nhận hủy đơn hàng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    DonHangController.CapNhatTrangThaiDonHang(maDonHang, trangThaiMoi);
                    MessageBox.Show("✅ Đã gửi yêu cầu hủy cho người bán!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load lại danh sách đơn hàng
                    LoadDonHangTheoTrangThai(cbb_trangThai.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi khi gửi yêu cầu hủy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < dgvDonHang.Rows.Count)
            {
                DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];
                MADONHANG = row.Cells["madh"].Value?.ToString();               // ID
               
            }
        }

        private void btn_xemChiTiet_Click(object sender, EventArgs e)
        {

        }
    }
}
