using System;

namespace LapStore.Model
{
    internal class DonHang
    {
        public string Id { get; set; }
        public string MaUser { get; set; }
        public long TongTien { get; set; }
        public DateTime CreatedAt { get; set; }

        // Constructor mặc định
        public DonHang() { }

        // Constructor có tham số
        public DonHang(string id, string maUser, long tongTien, DateTime createdAt)
        {
            Id = id;
            MaUser = maUser;
            TongTien = tongTien;
            CreatedAt = createdAt;
        }
    }
}
