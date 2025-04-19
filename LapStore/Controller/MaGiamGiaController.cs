using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class MaGiamGiaController
    {
        public static List<MaGiamGia> GetAllMaGiamGia()
        {
            List<MaGiamGia> maGiamGias = new List<MaGiamGia>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM MAGIAMGIA";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            maGiamGias.Add(new MaGiamGia
                            {
                                Id = reader["id"].ToString(),
                                TenMa = reader["tenMa"].ToString(),
                                PhanTramGiam = Convert.ToInt32(reader["phanTramGiam"]),
                                SoLuong = Convert.ToInt32(reader["soLuong"]),
                                NgayBatDau = Convert.ToDateTime(reader["ngayBatDau"]),
                                NgayKetThuc = Convert.ToDateTime(reader["ngayKetThuc"]),
                                DieuKienApDung = Convert.ToInt64(reader["dieuKienApDung"])
                            });
                        }
                    }
                }
            }

            return maGiamGias;
        }

        public static void AddMaGiamGia(MaGiamGia maGiamGia)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"INSERT INTO MAGIAMGIA (id, tenMa, phanTramGiam, soLuong, ngayBatDau, ngayKetThuc, dieuKienApDung)
                                 VALUES (@id, @tenMa, @phanTramGiam, @soLuong, @ngayBatDau, @ngayKetThuc, @dieuKienApDung)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", maGiamGia.Id);
                    cmd.Parameters.AddWithValue("@tenMa", maGiamGia.TenMa);
                    cmd.Parameters.AddWithValue("@phanTramGiam", maGiamGia.PhanTramGiam);
                    cmd.Parameters.AddWithValue("@soLuong", maGiamGia.SoLuong);
                    cmd.Parameters.AddWithValue("@ngayBatDau", maGiamGia.NgayBatDau);
                    cmd.Parameters.AddWithValue("@ngayKetThuc", maGiamGia.NgayKetThuc);
                    cmd.Parameters.AddWithValue("@dieuKienApDung", maGiamGia.DieuKienApDung);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateMaGiamGia(MaGiamGia maGiamGia)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"UPDATE MAGIAMGIA 
                                 SET tenMa = @tenMa, phanTramGiam = @phanTramGiam, soLuong = @soLuong,
                                     ngayBatDau = @ngayBatDau, ngayKetThuc = @ngayKetThuc, dieuKienApDung = @dieuKienApDung
                                 WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", maGiamGia.Id);
                    cmd.Parameters.AddWithValue("@tenMa", maGiamGia.TenMa);
                    cmd.Parameters.AddWithValue("@phanTramGiam", maGiamGia.PhanTramGiam);
                    cmd.Parameters.AddWithValue("@soLuong", maGiamGia.SoLuong);
                    cmd.Parameters.AddWithValue("@ngayBatDau", maGiamGia.NgayBatDau);
                    cmd.Parameters.AddWithValue("@ngayKetThuc", maGiamGia.NgayKetThuc);
                    cmd.Parameters.AddWithValue("@dieuKienApDung", maGiamGia.DieuKienApDung);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteMaGiamGia(string id)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM MAGIAMGIA WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string GenerateNewMaGiamGia()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT TOP 1 id FROM MAGIAMGIA ORDER BY id DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string lastId = result.ToString(); // VD: "MGG007"
                        int number = int.Parse(lastId.Substring(3)) + 1;
                        return "MGG" + number.ToString("D3");
                    }
                    else
                    {
                        return "MGG001";
                    }
                }
            }
        }
        public static bool TruSoLuongMaGiamGia(string maGiamGiaId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE MAGIAMGIA SET soLuong = soLuong - 1 WHERE id = @id AND soLuong > 0";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", maGiamGiaId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có ít nhất một dòng bị ảnh hưởng (số lượng đã được trừ)
                }
            }
        }
    }
}
