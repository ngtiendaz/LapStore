using System;

namespace LapStore.Model
{
    public class MaGiamGia
    {
        public string Id { get; set; }              // Mã giảm giá (VD: MGG001)
        public string TenMa { get; set; }           // Tên mã (VD: GIAM10)
        public int PhanTramGiam { get; set; }       // % Giảm
        public int SoLuong { get; set; }            // Số lượng còn lại có thể dùng
        public DateTime NgayBatDau { get; set; }    // Ngày bắt đầu
        public DateTime NgayKetThuc { get; set; }   // Ngày kết thúc
        public long DieuKienApDung { get; set; }    // Ví dụ: đơn hàng từ 500000

        public MaGiamGia() { }

        public MaGiamGia(string id, string tenMa, int phanTramGiam, int soLuong, DateTime ngayBatDau, DateTime ngayKetThuc, long dieuKienApDung)
        {
            Id = id;
            TenMa = tenMa;
            PhanTramGiam = phanTramGiam;
            SoLuong = soLuong;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            DieuKienApDung = dieuKienApDung;
        }
    }
}
