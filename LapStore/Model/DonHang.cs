using System;

namespace LapStore.Model
{
    internal class DonHang
    {
        public string Id { get; set; }
        public string MaUser { get; set; }
        public string DiaChi { get; set; }
        public long TongTien { get; set; }
        public string PhuongThucThanhToan { get; set; }  // 'Online' hoặc 'Khi nhận hàng'
        public string TrangThai { get; set; } = "Chờ thanh toán";
        public DateTime CreatedAt { get; set; }
        public string Sdt { get; set; }  // Thêm số điện thoại

        // Constructor mặc định
        public DonHang() { }

        // Constructor có tham số (có thêm sdt)
        public DonHang(string id, string maUser, string diaChi, long tongTien, string phuongThucThanhToan, string trangThai, DateTime createdAt, string sdt)
        {
            Id = id;
            MaUser = maUser;
            DiaChi = diaChi;
            TongTien = tongTien;
            PhuongThucThanhToan = phuongThucThanhToan;
        }
    }
}