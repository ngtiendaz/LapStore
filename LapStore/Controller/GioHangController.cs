using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class GioHangController
    {
        /// <summary>
        /// Thêm sản phẩm vào giỏ hàng.
        /// </summary>
        public static void AddToGioHang(string maUser, string maSp, int soLuong, long gia)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"IF EXISTS (SELECT * FROM GIOHANG WHERE maUser = @maUser AND maSp = @maSp)
                                    UPDATE GIOHANG SET soLuong = soLuong + @soLuong WHERE maUser = @maUser AND maSp = @maSp
                                 ELSE
                                    INSERT INTO GIOHANG(id, maUser, maSp, soLuong, gia) 
                                    VALUES (@id, @maUser, @maSp, @soLuong, @gia)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", GenerateNewId());
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    cmd.Parameters.AddWithValue("@soLuong", soLuong);
                    cmd.Parameters.AddWithValue("@gia", gia);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lấy danh sách sản phẩm trong giỏ hàng của một user.
        /// </summary>
        public static List<GioHang> GetGioHangByUser(string maUser)
        {
            List<GioHang> gioHangList = new List<GioHang>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM GIOHANG WHERE maUser = @maUser";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gioHangList.Add(new GioHang
                            {
                                Id = reader["id"].ToString(),
                                MaUser = reader["maUser"].ToString(),
                                MaSp = reader["maSp"].ToString(),
                                SoLuong = (int)reader["soLuong"],
                                Gia = (long)reader["gia"]
                            });
                        }
                    }
                }
            }

            return gioHangList;
        }

        /// <summary>
        /// Xóa một sản phẩm khỏi giỏ hàng.
        /// </summary>
        public static void RemoveFromGioHang(string maUser, string maSp)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM GIOHANG WHERE maUser = @maUser AND maSp = @maSp";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Xóa toàn bộ giỏ hàng của người dùng.
        /// </summary>
        public static void ClearGioHang(string maUser)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM GIOHANG WHERE maUser = @maUser";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Cập nhật số lượng sản phẩm trong giỏ hàng.
        /// </summary>
        public static void UpdateSoLuong(string maUser, string maSp, int soLuong)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE GIOHANG SET soLuong = @soLuong WHERE maUser = @maUser AND maSp = @maSp";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    cmd.Parameters.AddWithValue("@soLuong", soLuong);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Tạo ID mới cho giỏ hàng.
        /// </summary>
        private static string GenerateNewId()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id FROM GIOHANG";

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

                    existingIds.Sort();

                    int newId = 1;
                    for (int i = 0; i < existingIds.Count; i++)
                    {
                        if (existingIds[i] != newId)
                        {
                            break;
                        }
                        newId++;
                    }

                    return "GH" + newId.ToString("D3");
                }
            }
        }
    }
}
