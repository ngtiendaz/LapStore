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
    public partial class luotMuaAdmin : UserControl
    {
        string MDH;
        public luotMuaAdmin()
        {
            InitializeComponent();
        }


        private void luotMuaAdmin_Paint(object sender, PaintEventArgs e)
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

        private void luotMuaAdmin_Load(object sender, EventArgs e)
        {
            Database.LoadThangToComboBox(cbb_thang);
            dgvChiTietDonHang.DefaultCellStyle.ForeColor = Color.Black;
            dgvDonHang.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void btn_traCuu_Click(object sender, EventArgs e)
        {
            // Lấy tháng từ ComboBox
            if (cbb_thang.SelectedValue != null)
            {
                int thang = Convert.ToInt32(cbb_thang.SelectedValue);

                // Lấy danh sách đơn hàng theo tháng
                List<DonHang> donHangList = DonHangController.GetDonHangTheoThang(thang);

                // Hiển thị danh sách đơn hàng trong DataGridView
                dgvDonHang.Rows.Clear();  // Xóa dữ liệu cũ trong DataGridView

                foreach (var donHang in donHangList)
                {
                    dgvDonHang.Rows.Add(
                        donHang.Id,
                        donHang.MaUser,
                        donHang.TongTien.ToString("N0") + "đ",
                        donHang.CreatedAt.ToString("dd/MM/yyyy")
                    );
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tháng để tra cứu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonHang.Rows[e.RowIndex];

                // Lấy thông tin từ các ô
                MDH = row.Cells["madh"].Value?.ToString().Trim();
                LoadSanPhamTrongDonHang(MDH);

            }
        }
        public void LoadSanPhamTrongDonHang(string maDonHang)
        {
            List<SanPham> SanPhams = ChiTietDonHangController.GetSanPhamTrongDonHang(maDonHang);  // Đổi hàm lấy theo đơn hàng
            dgvChiTietDonHang.Rows.Clear();

            foreach (SanPham sp in SanPhams)
            {
                // Load ảnh nếu có
                Image img = null;
                if (!string.IsNullOrEmpty(sp.HinhAnh) && System.IO.File.Exists(sp.HinhAnh))
                {
                    try
                    {
                        using (var bmpTemp = new Bitmap(sp.HinhAnh))
                        {
                            img = new Bitmap(bmpTemp, new Size(80, 80));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                    }
                }

                int rowIndex = dgvChiTietDonHang.Rows.Add(
                    img,
                    sp.MaSp,
                    sp.TenSp

                );

                dgvChiTietDonHang.Rows[rowIndex].Cells["HinhAnh"].Tag = sp.HinhAnh;
            }
        }

    }
}
