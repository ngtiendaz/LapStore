using System;

namespace LapStore.Model
{
    public class GioHang
    {
        public bool IsChecked { get; set; } = true;
        public string Id { get; set; }        // Mã giỏ hàng
        public string MaUser { get; set; }    // Mã người dùng
        public string MaSp { get; set; }      // Mã sản phẩm
        public string TenSp { get; set; }     // Tên sản phẩm
        public string HinhAnh { get; set; }   // Đường dẫn ảnh
        public int SoLuong { get; set; }      // Số lượng
        public long Gia { get; set; }         // Giá 1 sản phẩm
        public long ThanhTien => Gia * SoLuong; // Tính tự động

        public GioHang() { }

        public GioHang(string id, string maUser, string maSp, string tenSp, string hinhAnh, int soLuong, long gia)
        {
            Id = id;
            MaUser = maUser;
            MaSp = maSp;
            TenSp = tenSp;
            HinhAnh = hinhAnh;
            SoLuong = soLuong;
            Gia = gia;
        }
    }
}
