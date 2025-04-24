using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ClosedXML.Excel;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class ThongKeController
    {
        public static List<string> GenerateThongKeIds(int soLuong)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id FROM THONGKE";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    List<int> existingIds = new List<int>();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["id"].ToString();
                            string numberPart = new string(id.SkipWhile(c => !char.IsDigit(c)).ToArray());

                            if (int.TryParse(numberPart, out int numericPart))
                            {
                                existingIds.Add(numericPart);
                            }
                        }
                    }

                    int startId = (existingIds.Count > 0 ? existingIds.Max() : 0) + 1;
                    return Enumerable.Range(startId, soLuong)
                                     .Select(i => $"TK{i:D3}")
                                     .ToList();
                }
            }
        }
        public static (long TongDoanhThu, long TienVon, long LoiNhuan, long TongTienGiam, long TongTienBaoHanh) LayThongKeTheoThang(int thang)
        {
            long tongDoanhThu = 0;
            long tongLoiNhuan = 0;
            long tongTienGiam = 0;
            long tongTienBaoHanh = 0;

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                SELECT
                    SUM(DH.tongTien) AS TongDoanhThu,
                    SUM(DH.tongTien - TK.loiNhuan) AS TongTienVon, -- Assuming loiNhuan in THONGKE is the profit
                    SUM(TK.loiNhuan) AS TongLoiNhuan,
                    SUM(ISNULL(MGD.soTienGiam, 0)) AS TongTienGiam,
                    SUM(ISNULL(PB_CT.giaBaoHanh, 0)) AS TongTienBaoHanh
                FROM DONHANG DH
                LEFT JOIN (
                    SELECT
                        maDonHang,
                        SUM(loiNhuan) AS loiNhuan
                    FROM THONGKE
                    GROUP BY maDonHang
                ) TK ON DH.id = TK.maDonHang
                LEFT JOIN MAGIAMGIA_DONHANG MGD ON DH.id = MGD.maDonHang
                LEFT JOIN (
                    SELECT
                        CT_PBH.maDonHang,
                        SUM(PBH.gia) AS giaBaoHanh
                    FROM CT_PHIEUBAOHANH CT_PBH
                    JOIN PHIEUBAOHANH PBH ON CT_PBH.maPhieuBaoHanh = PBH.id
                    GROUP BY CT_PBH.maDonHang
                ) PB_CT ON DH.id = PB_CT.maDonHang
                WHERE MONTH(DH.created_at) = @thang
                  AND DH.trangThai != N'Đã hủy';
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@thang", thang);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tongDoanhThu = reader["TongDoanhThu"] != DBNull.Value ? Convert.ToInt64(reader["TongDoanhThu"]) : 0;
                            tongLoiNhuan = reader["TongLoiNhuan"] != DBNull.Value ? Convert.ToInt64(reader["TongLoiNhuan"]) : 0;
                            tongTienGiam = reader["TongTienGiam"] != DBNull.Value ? Convert.ToInt64(reader["TongTienGiam"]) : 0;
                            tongTienBaoHanh = reader["TongTienBaoHanh"] != DBNull.Value ? Convert.ToInt64(reader["TongTienBaoHanh"]) : 0;
                        }
                    }
                }
            }

            long tienVon = tongDoanhThu - tongLoiNhuan;

            return (tongDoanhThu, tienVon, tongLoiNhuan, tongTienGiam, tongTienBaoHanh);
        }



        public static (long DoanhThu, long TienVon, long LoiNhuan, long TienBaoHanh) LayThongKeTheoDonHang(string maDonHang)
        {
            long doanhThu = 0;
            long loiNhuan = 0;
            long tienBaoHanh = 0;

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                SELECT
                    SUM(TK.doanhThu) AS DoanhThu,
                    SUM(TK.loiNhuan) AS LoiNhuan,
                    ISNULL((SELECT PB.gia
                            FROM CT_PHIEUBAOHANH CT_INNER
                            JOIN PHIEUBAOHANH PB ON CT_INNER.maPhieuBaoHanh = PB.id
                            WHERE CT_INNER.maDonHang = @maDonHang), 0) AS TienBaoHanh
                FROM THONGKE TK
                JOIN DONHANG DH ON TK.maDonHang = DH.id
                WHERE TK.maDonHang = @maDonHang
                  AND DH.trangThai != N'Đã hủy';
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maDonHang", maDonHang);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            doanhThu = reader["DoanhThu"] != DBNull.Value ? Convert.ToInt64(reader["DoanhThu"]) : 0;
                            loiNhuan = reader["LoiNhuan"] != DBNull.Value ? Convert.ToInt64(reader["LoiNhuan"]) : 0;
                            tienBaoHanh = reader["TienBaoHanh"] != DBNull.Value ? Convert.ToInt64(reader["TienBaoHanh"]) : 0;
                        }
                    }
                }
            }

            long tienVon = doanhThu - loiNhuan;

            return (doanhThu, tienVon, loiNhuan, tienBaoHanh);
        }
        public static List<SanPham> getSanPhamDaBanHet()
        {
            List<SanPham> danhSachSanPham = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            SELECT maSp, maDm, tenSp, hinhAnh, moTa, giaNhap, giaBan, soLuong, created_at
            FROM SANPHAM
            WHERE soLuong = 0
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSachSanPham.Add(new SanPham
                            {
                                MaSp = reader["maSp"].ToString(),
                                MaDm = reader["maDm"].ToString(),
                                TenSp = reader["tenSp"].ToString(),
                                HinhAnh = reader["hinhAnh"] != DBNull.Value ? reader["hinhAnh"].ToString() : null,
                                MoTa = reader["moTa"] != DBNull.Value ? reader["moTa"].ToString() : null,
                                GiaNhap = Convert.ToInt64(reader["giaNhap"]),
                                GiaBan = Convert.ToInt64(reader["giaBan"]),
                                SoLuong = Convert.ToInt32(reader["soLuong"]),
                                CreatedAt = reader["created_at"] != DBNull.Value ? Convert.ToDateTime(reader["created_at"]) : DateTime.MinValue
                            });
                        }
                    }
                }
            }

            return danhSachSanPham;
        }

        public static List<(string TenSp, int TongBan)> GetTop5SanPham()
        {
            List<(string TenSp, int TongBan)> topSanPham = new List<(string TenSp, int TongBan)>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            SELECT TOP 5 
                SP.tenSp, SUM(TK.soLuong) AS TongBan
            FROM SANPHAM SP
            INNER JOIN THONGKE TK ON SP.maSp = TK.maSp
            GROUP BY SP.tenSp
            ORDER BY SUM(TK.soLuong) DESC
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tenSp = reader["tenSp"].ToString();
                            int tongBan = reader["TongBan"] != DBNull.Value ? Convert.ToInt32(reader["TongBan"]) : 0;

                            topSanPham.Add((tenSp, tongBan));
                        }
                    }
                }
            }

            return topSanPham;
        }



public static void XuatThongKeDonHangRaExcel(string maDonHang, string filePath)
    {
        var thongKe = LayThongKeTheoDonHangExcel(maDonHang);

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

        public static ThongKeDonHangModel LayThongKeTheoDonHangExcel(string maDonHang)
        {
            var result = new ThongKeDonHangModel();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            SELECT
                SUM(TK.doanhThu) AS DoanhThu,
                SUM(TK.loiNhuan) AS LoiNhuan,
                ISNULL((SELECT PBH.gia
                        FROM CT_PHIEUBAOHANH CT
                        JOIN PHIEUBAOHANH PBH ON CT.maPhieuBaoHanh = PBH.id
                        WHERE CT.maDonHang = @maDonHang), 0) AS TienBaoHanh,
                ND.hoTen AS TenKhachHang,
                DH.phuongThucThanhToan
            FROM THONGKE TK
            JOIN DONHANG DH ON TK.maDonHang = DH.id
            JOIN USERS ND ON DH.maUser = ND.id
            WHERE TK.maDonHang = @maDonHang
            AND DH.trangThai != N'Đã hủy'
            GROUP BY ND.hoTen, DH.phuongThucThanhToan;
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maDonHang", maDonHang);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.DoanhThu = reader["DoanhThu"] != DBNull.Value ? Convert.ToInt64(reader["DoanhThu"]) : 0;
                            result.LoiNhuan = reader["LoiNhuan"] != DBNull.Value ? Convert.ToInt64(reader["LoiNhuan"]) : 0;
                            result.TienBaoHanh = reader["TienBaoHanh"] != DBNull.Value ? Convert.ToInt64(reader["TienBaoHanh"]) : 0;
                            result.TenKhachHang = reader["TenKhachHang"]?.ToString();
                            result.PhuongThucThanhToan = reader["phuongThucThanhToan"]?.ToString();
                        }
                    }
                }
            }

            // Tính Tiền Vốn
            result.TienVon = result.DoanhThu - result.LoiNhuan;

            return result;
        }




    }
}
