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
        public static (long TongDoanhThu, long TienVon, long LoiNhuan) LayThongKeTheoThang(int thang)
        {
            long tongDoanhThu = 0;
            long tongLoiNhuan = 0;

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            SELECT 
                SUM(TK.doanhThu) AS TongDoanhThu,
                SUM(TK.loiNhuan) AS TongLoiNhuan
            FROM THONGKE TK
            WHERE MONTH(TK.created_at) = @thang
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
                        }
                    }
                }
            }

            long tienVon = tongDoanhThu - tongLoiNhuan;

            return (tongDoanhThu, tienVon, tongLoiNhuan);
        }


    }
}
