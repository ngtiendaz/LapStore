using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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




    }
}
