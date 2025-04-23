using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Controller;
using LapStore.Model;

namespace LapStore.Widget.Admin
{
    public partial class doanhThuAdmin : UserControl
    {
        public doanhThuAdmin()
        {
            InitializeComponent();
        }

        private void doanhThuAdmin_Load(object sender, EventArgs e)
        {
            Database.LoadThangToComboBox(cbb_thang);
            dgvDoanhThu.DefaultCellStyle.ForeColor = Color.Black;
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
                dgvDoanhThu.Rows.Clear();  // Xóa dữ liệu cũ trong DataGridView

                foreach (var donHang in donHangList)
                {
                    dgvDoanhThu.Rows.Add(
                        donHang.Id,
                        donHang.TongTien.ToString("N0") + "đ",
                        donHang.CreatedAt.ToString("dd/MM/yyyy")
                    );
                }

                // Lấy tổng doanh thu, tiền vốn và lợi nhuận từ bảng THONGKE
                var (tongDoanhThu, tienVon, loiNhuan) = ThongKeController.LayThongKeTheoThang(thang);

                // Hiển thị lên giao diện (giả sử có các Label: lbl_doanhThu, lbl_tienVon, lbl_loiNhuan)
                txt_doanhThu.Text = $"{tongDoanhThu:N0} VND";
                txt_von.Text = $"{tienVon:N0} VND";
                txt_loiNhuan.Text = $"{loiNhuan:N0} VND";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tháng để tra cứu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void doanhThuAdmin_Paint(object sender, PaintEventArgs e)
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
