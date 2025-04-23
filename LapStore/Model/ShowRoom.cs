using System;

namespace LapStore.Model
{
    internal class ShowRoom
    {
        public string Id { get; set; }
        public string TenCuaHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public TimeSpan GioMoCua { get; set; }
        public TimeSpan GioDongCua { get; set; }
    }
}
