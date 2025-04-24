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
    public partial class luotXemAdmin : UserControl
    {
        string MSP = "";
        public luotXemAdmin()
        {
            InitializeComponent();
        }
        public static void LoadComboBoxSapXep(ComboBox comboBox)
        {
            // Danh sách kiểu sắp xếp
            var sapXepList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0, "Lượt xem cao nhất"),
                new KeyValuePair<int, string>(1, "Lượt xem thấp nhất"),
            };

            // Gán dữ liệu vào ComboBox
            comboBox.DataSource = sapXepList;
            comboBox.DisplayMember = "Value"; // Hiển thị tên kiểu sắp xếp
            comboBox.ValueMember = "Key"; // Lấy giá trị số tương ứng
        }

        public void LoadLuotXem(String maSp)
        {
            txt_luotXem.Text = LuotXemController.GetLuotXemBySanPhamId(maSp).ToString();
        }
        private void luotXemAdmin_Load(object sender, EventArgs e)
        {
            LoadComboBoxSapXep(cbb_sapXep);
            LoadingData(0);
            dgvSP.DefaultCellStyle.ForeColor = Color.Black; ;
        }
        public void LoadingData(int sapXep)
        {
            List<SanPham> SanPhams = LuotXemController.GetSanPhamTheoLuotXem(sapXep);
            dgvSP.Rows.Clear();

            foreach (SanPham sp in SanPhams)
            {
                // Khởi tạo ảnh từ đường dẫn (nếu có)
                Image img = null;
                if (!string.IsNullOrEmpty(sp.HinhAnh) && System.IO.File.Exists(sp.HinhAnh))
                {
                    try
                    {
                        using (var bmpTemp = new Bitmap(sp.HinhAnh))
                        {
                            img = new Bitmap(bmpTemp, new Size(80, 80));  // Resize về 80x80
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                    }
                }

                // Thêm hàng mới vào DataGridView
                int rowIndex = dgvSP.Rows.Add(
                    img,                        // Hình ảnh
                    sp.MaSp,                    // Mã sản phẩm
                    sp.MaDm,
                    sp.MaHang, // Mã danh mục
                    sp.TenSp,                   // Tên sản phẩm
                    sp.MoTa,                    // Mô tả
                    sp.GiaNhap,                 // Giá nhập
                    sp.GiaBan,                  // Giá bán
                    sp.SoLuong,                 // Số lượng
                    sp.CreatedAt               // Ngày tạo

                );

                // Lưu đường dẫn vào thuộc tính Tag của ô hình ảnh
                dgvSP.Rows[rowIndex].Cells["HinhAnh"].Tag = sp.HinhAnh;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadingData(cbb_sapXep.SelectedIndex);
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSP.Rows[e.RowIndex];

                // Lấy thông tin từ các ô
                MSP = row.Cells["maSp"].Value?.ToString().Trim();
                LoadLuotXem(MSP);

            }

        }

        private void luotXemAdmin_Paint(object sender, PaintEventArgs e)
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

        private void btn_xuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Chọn nơi lưu file thống kê";
            saveFileDialog.FileName = "SanPham_LuotXem_SapXep.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                XuatExcelController.XuatExcelSanPhamLuotXemTheoThuTu(filePath);
                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
