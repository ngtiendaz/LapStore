using System;

namespace LapStore.Model
{
    internal class ThongKe
    {
        public string Id { get; set; }
        public string MaDonHang { get; set; }
        public string MaSp { get; set; }
        public int SoLuong { get; set; }
        public long DoanhThu { get; set; }
        public long LoiNhuan { get; set; }
        public DateTime CreatedAt { get; set; }

        // Constructor mặc định
        public ThongKe() { }

        // Constructor có tham số
        public ThongKe(string id, string maDonHang, string maSp, int soLuong, long doanhThu, long loiNhuan, DateTime createdAt)
        {
            Id = id;
            MaDonHang = maDonHang;
            MaSp = maSp;
            SoLuong = soLuong;
            DoanhThu = doanhThu;
            LoiNhuan = loiNhuan;
            CreatedAt = createdAt;
        }
    }
}
