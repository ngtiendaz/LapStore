using ClosedXML.Excel;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using LapStore.Model;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;

namespace LapStore.Controller
{
    internal class XuatExcelController
    {
        public static void XuatExcelSanPhamLuotXemTheoThuTu(string filePath)
        {
            // Tạo một bảng dữ liệu DataTable để chứa kết quả truy vấn
            // ...
            System.Data.DataTable dt = new System.Data.DataTable();
            // ...
            dt.Columns.Add("Mã Sản Phẩm", typeof(string));
            dt.Columns.Add("Tên Sản Phẩm", typeof(string));
            dt.Columns.Add("Giá Bán", typeof(long));
            dt.Columns.Add("Số Lượt Xem", typeof(int));

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            SELECT sp.maSp, sp.tenSp, sp.giaBan, lx.soLuotXem
            FROM SANPHAM sp
            LEFT JOIN LUOTXEM lx ON sp.maSp = lx.maSp";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow row = dt.NewRow();
                            row["Mã Sản Phẩm"] = reader["maSp"];
                            row["Tên Sản Phẩm"] = reader["tenSp"];
                            row["Giá Bán"] = reader["giaBan"];
                            row["Số Lượt Xem"] = reader["soLuotXem"] != DBNull.Value ? Convert.ToInt32(reader["soLuotXem"]) : 0;
                            dt.Rows.Add(row);
                        }
                    }
                }
            }

            // Sắp xếp dữ liệu theo số lượt xem giảm dần
            var sortedRows = dt.AsEnumerable()
                               .OrderByDescending(row => row.Field<int>("Số Lượt Xem"))
                               .ToList();

            System.Data.DataTable sortedDataTable = sortedRows.CopyToDataTable();

            // Tạo và lưu file Excel
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sản Phẩm Lượt Xem");

                // Thêm dòng tiêu đề dài 4 ô ở trên cùng
                worksheet.Cell(1, 1).Value = "Thống Kê Lượt Xem";
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(1, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                worksheet.Range("A1:D1").Merge();  // Merge 4 cells in the first row

                // Đặt tên cột cho các thông tin sản phẩm
                worksheet.Cell(2, 1).Value = "Mã Sản Phẩm";
                worksheet.Cell(2, 2).Value = "Tên Sản Phẩm";
                worksheet.Cell(2, 3).Value = "Giá Bán";
                worksheet.Cell(2, 4).Value = "Số Lượt Xem";

                // Chèn dữ liệu từ DataTable vào Excel
                worksheet.Cell(3, 1).InsertData(sortedDataTable.AsEnumerable());

                // Lưu file Excel
                workbook.SaveAs(filePath);
            }

            Console.WriteLine("Xuất Excel thành công!");
        }

        public static void XuatThongKeDonHangRaExcel(string maDonHang, string filePath)
        {
            var thongKe = ThongKeController.LayThongKeTheoDonHangExcel(maDonHang);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("ThongKeDonHang");

                // Header
                worksheet.Cell("A1").Value = "Mã Đơn Hàng";
                worksheet.Cell("B1").Value = "Tên Khách Hàng";
                worksheet.Cell("C1").Value = "Phương Thức Thanh Toán";
                worksheet.Cell("D1").Value = "Doanh Thu";
                worksheet.Cell("E1").Value = "Tiền Vốn";
                worksheet.Cell("F1").Value = "Lợi Nhuận";
                worksheet.Cell("G1").Value = "Tiền Bảo Hành";

                // Data
                worksheet.Cell("A2").Value = maDonHang;
                worksheet.Cell("B2").Value = thongKe.TenKhachHang;
                worksheet.Cell("C2").Value = thongKe.PhuongThucThanhToan;
                worksheet.Cell("D2").Value = thongKe.DoanhThu;
                worksheet.Cell("E2").Value = thongKe.TienVon;
                worksheet.Cell("F2").Value = thongKe.LoiNhuan;
                worksheet.Cell("G2").Value = thongKe.TienBaoHanh;

                // Format tự điều chỉnh độ rộng
                worksheet.Columns().AdjustToContents();

                // Lưu file
                workbook.SaveAs(filePath);
            }
        }
        public static void XuatExcelShowRoom(string filePath)
        {
      
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Mã", typeof(string));
            dt.Columns.Add("Tên Cửa Hàng", typeof(string));
            dt.Columns.Add("Địa Chỉ", typeof(string));
            dt.Columns.Add("Số Điện Thoại", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Giờ Mở Cửa", typeof(string));
            dt.Columns.Add("Giờ Đóng Cửa", typeof(string));

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM HETHONGCUAHANG";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow row = dt.NewRow();
                            row["Mã"] = reader["id"].ToString();
                            row["Tên Cửa Hàng"] = reader["tenCuaHang"].ToString();
                            row["Địa Chỉ"] = reader["diaChi"].ToString();
                            row["Số Điện Thoại"] = reader["soDienThoai"].ToString();
                            row["Email"] = reader["email"].ToString();
                            row["Giờ Mở Cửa"] = ((TimeSpan)reader["gioMoCua"]).ToString(@"hh\:mm");
                            row["Giờ Đóng Cửa"] = ((TimeSpan)reader["gioDongCua"]).ToString(@"hh\:mm");
                            dt.Rows.Add(row);
                        }
                    }
                }
            }

            // Xuất dữ liệu ra file Excel
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Danh Sách Showroom");

                // Tiêu đề
                worksheet.Cell(1, 1).Value = "Danh Sách Showroom";
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Font.FontSize = 14;
                worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Range("A1:G1").Merge();

                // Tên các cột
                worksheet.Cell(2, 1).InsertTable(dt);

                workbook.SaveAs(filePath);
            }

            Console.WriteLine("Xuất Excel showroom thành công!");
        }

public static void XuatExcelTatCaSanPham(string filePath)
    {
            System.Data.DataTable dt = new System.Data.DataTable();
        dt.Columns.Add("Mã Sản Phẩm", typeof(string));
        dt.Columns.Add("Mã Danh Mục", typeof(string));
        dt.Columns.Add("Mã Hãng", typeof(string));
        dt.Columns.Add("Tên Sản Phẩm", typeof(string));
        dt.Columns.Add("Giá Nhập", typeof(long));
        dt.Columns.Add("Giá Bán", typeof(long));
        dt.Columns.Add("Số Lượng", typeof(int));
        dt.Columns.Add("Ngày Tạo", typeof(DateTime));
        dt.Columns.Add("Mô Tả", typeof(string));
        dt.Columns.Add("Hình Ảnh", typeof(string));

        using (SqlConnection conn = Database.GetConnection())
        {
            string query = "SELECT * FROM SANPHAM";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DataRow row = dt.NewRow();
                        row["Mã Sản Phẩm"] = reader["maSp"].ToString();
                        row["Mã Danh Mục"] = reader["maDm"].ToString();
                        row["Mã Hãng"] = reader["maHang"].ToString();
                        row["Tên Sản Phẩm"] = reader["tenSp"].ToString();
                        row["Giá Nhập"] = (long)reader["giaNhap"];
                        row["Giá Bán"] = (long)reader["giaBan"];
                        row["Số Lượng"] = (int)reader["soLuong"];
                        row["Ngày Tạo"] = (DateTime)reader["created_at"];
                        row["Mô Tả"] = reader["moTa"].ToString();
                        row["Hình Ảnh"] = reader["hinhAnh"].ToString();
                        dt.Rows.Add(row);
                    }
                }
            }
        }

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Danh Sách Sản Phẩm");

            // Dòng tiêu đề chung
            worksheet.Range("A1:J1").Merge().Value = "THỐNG KÊ TẤT CẢ SẢN PHẨM";
            worksheet.Range("A1:J1").Style.Font.Bold = true;
            worksheet.Range("A1:J1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Header các cột
            worksheet.Cell(2, 1).InsertTable(dt);

            // Auto fit các cột
            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
        }

        Console.WriteLine("Xuất Excel sản phẩm thành công!");
    }

        public static void XuatExcelDonHangTheoTrangThai(string filePath, string trangThai, string idUser = "")
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Mã Đơn Hàng", typeof(string));
            dt.Columns.Add("Mã Người Dùng", typeof(string));
            dt.Columns.Add("Địa Chỉ", typeof(string));
            dt.Columns.Add("Tổng Tiền", typeof(long));
            dt.Columns.Add("Phương Thức Thanh Toán", typeof(string));
            dt.Columns.Add("Trạng Thái", typeof(string));
            dt.Columns.Add("Ngày Tạo", typeof(DateTime));
            dt.Columns.Add("SĐT", typeof(string));

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM DONHANG WHERE trangThai = @trangThai";
                if (!string.IsNullOrEmpty(idUser))
                {
                    query += " AND maUser = @idUser";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@trangThai", trangThai);
                    if (!string.IsNullOrEmpty(idUser))
                    {
                        cmd.Parameters.AddWithValue("@idUser", idUser);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow row = dt.NewRow();
                            row["Mã Đơn Hàng"] = reader["id"].ToString();
                            row["Mã Người Dùng"] = reader["maUser"].ToString();
                            row["Địa Chỉ"] = reader["diaChi"].ToString();
                            row["Tổng Tiền"] = Convert.ToInt64(reader["tongTien"]);
                            row["Phương Thức Thanh Toán"] = reader["phuongThucThanhToan"].ToString();
                            row["Trạng Thái"] = reader["trangThai"].ToString();
                            row["Ngày Tạo"] = Convert.ToDateTime(reader["created_at"]);
                            row["SĐT"] = reader["sdt"].ToString();
                            dt.Rows.Add(row);
                        }
                    }
                }
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Đơn Hàng");

                // Dòng tiêu đề lớn
                worksheet.Range("A1:H1").Merge().Value = $"DANH SÁCH ĐƠN HÀNG - TRẠNG THÁI: {trangThai.ToUpper()}";
                worksheet.Range("A1:H1").Style.Font.Bold = true;
                worksheet.Range("A1:H1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Header + dữ liệu
                worksheet.Cell(2, 1).InsertTable(dt);

                // Định dạng cột "Ngày Tạo" theo dạng dd/MM/yyyy
                worksheet.Column("G").Style.DateFormat.Format = "dd/MM/yyyy";

                // Tự động điều chỉnh kích thước cột
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }

            Console.WriteLine("Xuất Excel đơn hàng thành công!");
        }
        public static void XuatExcelTop5SanPham(string filePath)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Tên Sản Phẩm", typeof(string));
            dt.Columns.Add("Tổng Bán", typeof(int));

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            SELECT TOP 5 
                SP.tenSp, SUM(TK.soLuong) AS TongBan
            FROM SANPHAM SP
            INNER JOIN THONGKE TK ON SP.maSp = TK.maSp
            GROUP BY SP.tenSp
            ORDER BY SUM(TK.soLuong) DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow row = dt.NewRow();
                            row["Tên Sản Phẩm"] = reader["tenSp"].ToString();
                            row["Tổng Bán"] = reader["TongBan"] != DBNull.Value ? Convert.ToInt32(reader["TongBan"]) : 0;
                            dt.Rows.Add(row);
                        }
                    }
                }
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Top 5 Bán Chạy");

                // Dòng tiêu đề lớn
                worksheet.Range("A1:B1").Merge().Value = "TOP 5 SẢN PHẨM BÁN CHẠY NHẤT";
                worksheet.Range("A1:B1").Style.Font.Bold = true;
                worksheet.Range("A1:B1").Style.Font.FontSize = 14;
                worksheet.Range("A1:B1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Chèn dữ liệu bắt đầu từ dòng 2
                worksheet.Cell(2, 1).InsertTable(dt);

                // Tự động điều chỉnh cột
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }

            Console.WriteLine("Xuất Excel Top 5 sản phẩm thành công!");
        }
        public static void XuatHoaDonChiTietExcel(string maDonHang, string filePath)
        {
            DonHang donHang = GetDonHangById(maDonHang);
            List<(string MaSp, int SoLuong, long GiaBan, long ThanhTien)> chiTietList = GetChiTietDonHang(maDonHang);
            string tenNguoiDung = GetTenNguoiDung(donHang?.MaUser);

            if (donHang == null)
            {
                System.Windows.Forms.MessageBox.Show($"Không tìm thấy đơn hàng có mã: {maDonHang}");
                return;
            }

            if (chiTietList == null || chiTietList.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show($"Không có chi tiết sản phẩm cho đơn hàng: {maDonHang}");
                return;
            }

            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Mã sản phẩm", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Giá bán", typeof(long));
            dt.Columns.Add("Thành tiền", typeof(long));

            foreach (var item in chiTietList)
            {
                dt.Rows.Add(item.MaSp, item.SoLuong, item.GiaBan, item.ThanhTien);
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add($"Hóa đơn {maDonHang}");

                // Tiêu đề hóa đơn
                worksheet.Range("A1:D1").Merge().Value = "HÓA ĐƠN ĐƠN HÀNG";
                worksheet.Range("A1:D1").Style.Font.Bold = true;
                worksheet.Range("A1:D1").Style.Font.FontSize = 16;
                worksheet.Range("A1:D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Thông tin đơn hàng
                worksheet.Cell(3, 1).Value = "Mã đơn hàng:";
                worksheet.Cell(3, 2).Value = donHang.Id;

                worksheet.Cell(4, 1).Value = "Tên người dùng:";
                worksheet.Cell(4, 2).Value = tenNguoiDung;

                worksheet.Range("B5:D5").Merge().Value = donHang.DiaChi;
                worksheet.Cell(5, 1).Value = "Địa chỉ:";

                worksheet.Cell(6, 1).Value = "SĐT:";
                worksheet.Cell(6, 2).Value = donHang.Sdt;

                worksheet.Cell(7, 1).Value = "Tổng tiền:";
                worksheet.Cell(7, 2).Value = donHang.TongTien;

                worksheet.Cell(8, 1).Value = "Phương thức thanh toán:";
                worksheet.Cell(8, 2).Value = donHang.PhuongThucThanhToan;

                worksheet.Cell(9, 1).Value = "Ngày đặt hàng:";
                worksheet.Cell(9, 2).Value = donHang.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");

                // Header bảng chi tiết
                worksheet.Cell(11, 1).Value = "Mã sản phẩm";
                worksheet.Cell(11, 2).Value = "Số lượng";
                worksheet.Cell(11, 3).Value = "Giá bán";
                worksheet.Cell(11, 4).Value = "Thành tiền";

                worksheet.Range("A11:D11").Style.Font.Bold = true;
                worksheet.Range("A11:D11").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Đổ dữ liệu chi tiết
                worksheet.Cell(12, 1).InsertTable(dt);

                // Tự động điều chỉnh độ rộng cột
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
                System.Windows.Forms.MessageBox.Show($"Đã xuất hóa đơn ra file: {filePath}");
            }
        }

        public static DonHang GetDonHangById(string id)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM DONHANG WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DonHang
                            {
                                Id = reader["id"].ToString(),
                                MaUser = reader["maUser"].ToString(),
                                DiaChi = reader["diaChi"].ToString(),
                                TongTien = Convert.ToInt64(reader["tongTien"]),
                                PhuongThucThanhToan = reader["phuongThucThanhToan"].ToString(),
                                TrangThai = reader["trangThai"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                Sdt = reader["sdt"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public static string GetTenNguoiDung(string maUser)
        {
            if (string.IsNullOrEmpty(maUser)) return "";
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT hoTen FROM USERS WHERE id = @maUser";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
        }

        // Hàm lấy chi tiết đơn hàng (đã có)
        public static List<(string MaSp, int SoLuong, long GiaBan, long ThanhTien)> GetChiTietDonHang(string maDonHang)
        {
            List<(string MaSp, int SoLuong, long GiaBan, long ThanhTien)> chiTietList = new List<(string, int, long, long)>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                    SELECT maSp, soLuong, giaBan
                    FROM CHITIETDONHANG
                    WHERE maDonHang = @maDonHang";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maDonHang", maDonHang);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maSp = reader["maSp"].ToString();
                            int soLuong = Convert.ToInt32(reader["soLuong"]);
                            long giaBan = Convert.ToInt64(reader["giaBan"]);
                            long thanhTien = soLuong * giaBan;
                            chiTietList.Add((maSp, soLuong, giaBan, thanhTien));
                        }
                    }
                }
            }

            return chiTietList;
        }

    }
}
