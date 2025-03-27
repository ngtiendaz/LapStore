using System;

namespace LapStore.Model
{
    internal class GioHang
    {
        public string Id { get; set; }       // Mã giỏ hàng
        public string MaUser { get; set; }   // Mã người dùng
        public string MaSp { get; set; }     // Mã sản phẩm
        public int SoLuong { get; set; }     // Số lượng sản phẩm
        public long Gia { get; set; }        // Giá sản phẩm

        public GioHang() { }

        public GioHang(string id, string maUser, string maSp, int soLuong, long gia)
        {
            Id = id;
            MaUser = maUser;
            MaSp = maSp;
            SoLuong = soLuong;
            Gia = gia;
        }
    }
}
