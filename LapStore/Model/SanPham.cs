using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapStore.Model
{
    public class SanPham
    {
        public string MaSp { get; set; }          // mã sản phẩm (char(10))
        public string MaDm { get; set; }          // mã danh mục (char(10))
        public string TenSp { get; set; }         // tên sản phẩm (nvarchar(255))
        public string HinhAnh { get; set; }       // hình ảnh (nvarchar(max))
        public string MoTa { get; set; }          // mô tả (nvarchar(max))
        public long GiaNhap { get; set; }         // giá nhập (bigint)
        public long GiaBan { get; set; }          // giá bán (bigint)
        public int SoLuong { get; set; }          // số lượng (int)
        public DateTime CreatedAt { get; set; }   // ngày tạo (datetime)
    }
}
