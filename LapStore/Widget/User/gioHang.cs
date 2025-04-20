using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LapStore.Controller;
using LapStore.Model;
using LapStore.View;

namespace LapStore.Widget.User
{
    public partial class gioHang : UserControl
    {
        private List<GioHang> _danhSachSP = new List<GioHang>();
        public event EventHandler<DatHangEventArgs> OnDatHang;
        private MaGiamGia _maGiamGia;
        long TONGTIEN=0;
        public class DatHangEventArgs : EventArgs
        {
            public List<GioHang> SanPhamDaChon { get; set; }
            public long TongTien { get; set; }
            public int TongSoLuong { get; set; }
            public MaGiamGia MaGiamGiaDaChon { get; set; }
        }
        public gioHang()
        {
            InitializeComponent();
        }

        private void LoadDanhSachSanPham()
        {
            _danhSachSP = GioHangController.GetGioHangByUser(UserController.CurrentUser.Id);
            flowSP.Controls.Clear();

            int count = 0; // Reset lại biến đếm mỗi lần load
            int itemWidth = flowSP.Width / 4 - 20;

            foreach (var gh in _danhSachSP)
            {
                var item = new itemSPGioHang(gh);
                item.SoLuongChanged += (sender, e) => CapNhatTongTien();
                item.CheckedChanged += (sender, e) => CapNhatTongTien();
                item.RemoveChanged += (sender, e) =>
                {
                    LoadDanhSachSanPham(); // Load lại danh sách sau khi xóa
                };

                flowSP.Controls.Add(item);
                count++;
            }

            lbCount.Text = $"Tất cả ({count} sản phẩm)";
            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            long tamTinh = 0;
            foreach (var sp in _danhSachSP)
            {
                if (sp.IsChecked)
                    tamTinh += sp.Gia * sp.SoLuong;
            }

            txt_tamTinh.Text = tamTinh.ToString("N0") + "đ";

            long tienGiam = 0;
            long tongTien = tamTinh;

            if (_maGiamGia != null)
            {
                if (tamTinh >= _maGiamGia.DieuKienApDung)
                {
                    tienGiam = tamTinh * _maGiamGia.PhanTramGiam / 100;
                    tongTien = tamTinh - tienGiam;
                    TONGTIEN = tongTien; // Cập nhật TONGTIEN khi có mã giảm giá hợp lệ
                }
                else
                {
                    MessageBox.Show("Giá trị đơn hàng chưa đủ điều kiện áp dụng mã giảm giá.");
                    _maGiamGia = null;
                    txt_maGiamGia.Text = "";
                    TONGTIEN = tamTinh; // Cập nhật TONGTIEN về giá tạm tính khi mã không hợp lệ
                }
            }
            else
            {
                TONGTIEN = tamTinh; // Cập nhật TONGTIEN bằng giá tạm tính khi không có mã giảm giá
            }

            txt_giaGiam.Text = "-" + tienGiam.ToString("N0") + "đ";
            txtTongTien.Text = tongTien.ToString("N0") + "đ";
        }



        private void gioHang_Load(object sender, EventArgs e)
        {
            txt_maGiamGia.ReadOnly = true;
            LoadDanhSachSanPham();
        }

        private void btn_xoaAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tất cả sản phẩm khỏi giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa khỏi database
                GioHangController.ClearGioHang(UserController.CurrentUser.Id);

                // Xóa control khỏi UI (FlowLayoutPanel cha)
                LoadDanhSachSanPham();

            }
        }

        private void btn_datHang_Click(object sender, EventArgs e)
        {
            var spDuocChon = _danhSachSP.Where(sp => sp.IsChecked).ToList();
            if (spDuocChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 sản phẩm để đặt hàng.");
                return;
            }

            long tongTien = TONGTIEN; // Sử dụng giá trị TONGTIEN đã được cập nhật
            int tongSoLuong = spDuocChon.Sum(sp => sp.SoLuong);

            // Gọi sự kiện gửi dữ liệu
            OnDatHang?.Invoke(this, new DatHangEventArgs
            {
                MaGiamGiaDaChon = _maGiamGia, // Vẫn truyền cả mã giảm giá
                SanPhamDaChon = spDuocChon,
                TongTien = tongTien, // Truyền tổng tiền cuối cùng
                TongSoLuong = tongSoLuong
            });
        }

        private void btn_chonMa_Click(object sender, EventArgs e)
        {
            var form = new MaGiamGiaForm();
            form.MaGiamGiaDaChon += (s, mgg) =>
            {
                _maGiamGia = mgg;
                txt_maGiamGia.Text = mgg?.TenMa ?? ""; // Hiển thị tên mã hoặc chuỗi rỗng nếu null
                CapNhatTongTien();
            };
            form.ShowDialog();
        }

        private void txt_maGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_maGiamGia.Text))
            {
                _maGiamGia = null;
                CapNhatTongTien();
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            txt_maGiamGia.Clear();
        }
    }
}
