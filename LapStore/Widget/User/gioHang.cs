using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LapStore.Controller;
using LapStore.Model;

namespace LapStore.Widget.User
{
    public partial class gioHang : UserControl
    {
        private List<GioHang> _danhSachSP = new List<GioHang>();
        public event EventHandler<DatHangEventArgs> OnDatHang;

        public class DatHangEventArgs : EventArgs
        {
            public List<GioHang> SanPhamDaChon { get; set; }
            public long TongTien { get; set; }
            public int TongSoLuong { get; set; }
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
                if (sp.IsChecked) // Chỉ tính nếu được check
                    tamTinh += sp.Gia * sp.SoLuong;
            }

            txt_tamTinh.Text = tamTinh.ToString("N0") + "đ";
            txtTongTien.Text = tamTinh.ToString("N0") + "đ";
        }

        private void gioHang_Load(object sender, EventArgs e)
        {
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

            long tongTien = spDuocChon.Sum(sp => sp.Gia * sp.SoLuong);
            int tongSoLuong = spDuocChon.Sum(sp => sp.SoLuong);

            // Gọi sự kiện gửi dữ liệu
            OnDatHang?.Invoke(this, new DatHangEventArgs
            {
                SanPhamDaChon = spDuocChon,
                TongTien = tongTien,
                TongSoLuong = tongSoLuong
            });
        }
    }
}
