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

namespace LapStore.Widget
{
    public partial class LapTop : UserControl
    {
        string imagePath;
        private bool isThem = false;
        public LapTop()
        {
            InitializeComponent();
  
          
        }
     
        private void ClearForm()
        {
            txtMaSp.Clear();
            txtTenSP.Clear();
            txtMoTa.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            dateCreateAt.Value = DateTime.Now;
            imageSp.Image = null;
            imageSp.BackColor = Color.Red;
            cbb_hang.SelectedIndex = -1; // Đặt lại giá trị ComboBox hãng
            cbb_danhMuc.SelectedIndex = -1; // Đặt lại giá trị ComboBox danh mục
        }

        private void LapTop_Load(object sender, EventArgs e)
        {
            LoadingData();
            dgvSP.DefaultCellStyle.ForeColor = Color.Black;
            DanhMucController.LoadDanhMucToComboBox(cbb_danhMuc);
            HangController.LoadHangToComboBox(cbb_hang);
        }

        private void LapTop_Paint(object sender, PaintEventArgs e)
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
        public void LoadingData()
        {
            List<SanPham> SanPhams = SanPhamController.GetAllSanPham();
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



        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra ô trống
            if (string.IsNullOrWhiteSpace(txtMaSp.Text) ||
                string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(txtMoTa.Text) ||
                string.IsNullOrWhiteSpace(txtGiaNhap.Text) ||
                string.IsNullOrWhiteSpace(txtGiaBan.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                cbb_danhMuc.SelectedIndex < 0 ||
                cbb_hang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sử dụng các hàm kiểm tra hợp lệ
            if (!Database.KiemTraMaSp(txtMaSp.Text) ||
                !Database.KiemTraGia(txtGiaNhap.Text, txtGiaBan.Text) ||
                !Database.KiemTraSoLuong(txtSoLuong.Text))
            {
                return;
            }

            // Lấy đường dẫn ảnh (nếu có)
            imagePath = imageSp.Tag?.ToString() ?? "";

            var sanPham = new SanPham
            {
                MaSp = txtMaSp.Text,
                MaDm = cbb_danhMuc.SelectedValue.ToString(),
                MaHang = cbb_hang.SelectedValue.ToString(),
                TenSp = txtTenSP.Text,
                HinhAnh = imagePath,
                MoTa = txtMoTa.Text,
                GiaNhap = long.Parse(txtGiaNhap.Text),
                GiaBan = long.Parse(txtGiaBan.Text),
                SoLuong = int.Parse(txtSoLuong.Text),
                CreatedAt = DateTime.Now,
            };

            // Thêm sản phẩm
            SanPhamController.AddSanPham(sanPham);
            LoadingData();
            MessageBox.Show("Thêm sản phẩm thành công!");

            ClearForm();
            btnThem.Enabled = false; // Tắt nút Thêm sau khi thêm xong
        }




        private void dgvLapTop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSP.Rows[e.RowIndex];

                // Lấy thông tin từ các ô
                txtMaSp.Text = row.Cells["maSp"].Value?.ToString().Trim();
                cbb_danhMuc.SelectedValue = row.Cells["maDm"].Value?.ToString().Trim();  // Lấy mã danh mục và gán vào ComboBox
                txtTenSP.Text = row.Cells["tenSp"].Value?.ToString().Trim();
                txtMoTa.Text = row.Cells["moTa"].Value?.ToString().Trim();
                txtGiaNhap.Text = row.Cells["giaNhap"].Value?.ToString().Trim();
                txtGiaBan.Text = row.Cells["giaBan"].Value?.ToString().Trim();
                txtSoLuong.Text = row.Cells["soLuong"].Value?.ToString().Trim();
                dateCreateAt.Value = DateTime.Parse(row.Cells["createAt"].Value?.ToString());

                // Lấy mã hãng và gán vào ComboBox hãng
                cbb_hang.SelectedValue = row.Cells["maHang"].Value?.ToString().Trim();  // Lấy mã hãng và gán vào ComboBox

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lấy mã sản phẩm từ TextBox
            string maSp = txtMaSp.Text;

            // Kiểm tra mã sản phẩm có rỗng không
            if (string.IsNullOrWhiteSpace(maSp))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm để xóa!");
                txtMaSp.Focus();
                return;
            }

            // Xác nhận trước khi xóa
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?",
                                         "Xác nhận xóa",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gọi hàm xóa sản phẩm
                    SanPhamController.DeleteSanPham(maSp);

                    // Tải lại dữ liệu sau khi xóa
                    LoadingData();
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa sản phẩm thất bại! Lỗi: " + ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Sử dụng hàm kiểm tra từ lớp Validator
            if (!Database.CheckNull(txtMaSp.Text) ||
                !Database.KiemTraGia(txtGiaNhap.Text, txtGiaBan.Text) ||
                !Database.KiemTraSoLuong(txtSoLuong.Text))
            {
                return;
            }

            // Lấy mã danh mục và mã hãng từ ComboBox
            string maDm = cbb_danhMuc.SelectedValue.ToString();  // Lấy mã danh mục từ ComboBox
            string maHang = cbb_hang.SelectedValue.ToString();   // Lấy mã hãng từ ComboBox

            // Kiểm tra xem có ảnh hay không
            imagePath = imageSp.Tag?.ToString() ?? "";

            var sanPham = new SanPham
            {
                MaSp = txtMaSp.Text,
                MaDm = maDm,                // Gán mã danh mục từ ComboBox
                MaHang = maHang,            // Gán mã hãng từ ComboBox
                TenSp = txtTenSP.Text,
                HinhAnh = imagePath,
                MoTa = txtMoTa.Text,
                GiaNhap = long.Parse(txtGiaNhap.Text),
                GiaBan = long.Parse(txtGiaBan.Text),
                SoLuong = int.Parse(txtSoLuong.Text),
                CreatedAt = DateTime.Now,
            };

            // Gọi hàm cập nhật sản phẩm
            SanPhamController.UpdateSanPham(sanPham);
            LoadingData();
            MessageBox.Show("Cập nhật sản phẩm thành công!");
            ClearForm();
        }


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string maDm = cbb_danhMuc.SelectedValue.ToString();

            List<SanPham> SanPhams = SanPhamController.SearchSanPham(keyword, maDm);
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
                    img,       // Hình ảnh
                    sp.MaSp,   // Mã sản phẩm
                    sp.MaDm,
                    sp.MaHang,
                    sp.TenSp,  // Tên sản phẩm
                    sp.MoTa,   // Mô tả
                    sp.GiaNhap, // Giá nhập
                    sp.GiaBan,  // Giá bán
                    sp.SoLuong, // Số lượng
                    sp.CreatedAt // Ngày tạo
                );

                // Lưu đường dẫn vào thuộc tính Tag của ô hình ảnh
                dgvSP.Rows[rowIndex].Cells["HinhAnh"].Tag = sp.HinhAnh;
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

        private void btn_themMoi_Click(object sender, EventArgs e)
        {
            isThem = !isThem;

            if (isThem)
            {
                btnThem.Enabled = true;
                btn_themMoi.Text = "Hủy";
                ClearForm();
                txtMaSp.Text = SanPhamController.GenerateNewMaSp();
            }
            else
            {
                btnThem.Enabled = false;
                btn_themMoi.Text = "Thêm Mới";
            }
        }
    }
}
