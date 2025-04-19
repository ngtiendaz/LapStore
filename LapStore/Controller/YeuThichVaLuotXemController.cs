using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class YeuThichVaLuotXemController
    {
        public static string GenerateNewYeuThichId()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id FROM YEUTHICH";
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
                                existingIds.Add(numericPart);
                        }
                    }

                    existingIds.Sort();
                    int newId = 1;
                    foreach (var id in existingIds)
                    {
                        if (id != newId) break;
                        newId++;
                    }

                    return "YT" + newId.ToString("D3"); // Kết quả ví dụ: YT001, YT002, ...
                }
            }
        }

        public static bool IsSanPhamYeuThich(string userId, string maSp)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM YEUTHICH WHERE maUser = @maUser AND maSp = @maSp";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maUser", userId);
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static void ThemYeuThich(string maUser, string maSp)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                // Kiểm tra đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM YEUTHICH WHERE maUser = @maUser AND maSp = @maSp";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@maUser", maUser);
                    checkCmd.Parameters.AddWithValue("@maSp", maSp);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                        return; // Đã tồn tại, không thêm nữa
                }

                // Tạo ID mới cho yêu thích
                string id = GenerateNewYeuThichId();

                string query = "INSERT INTO YEUTHICH (id, maUser, maSp) VALUES (@id, @maUser, @maSp)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void XoaYeuThich(string maUser, string maSp)
        {
            using (SqlConnection conn = Database.GetConnection())
            {

                string query = "DELETE FROM YEUTHICH WHERE maUser = @maUser AND maSp = @maSp";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<SanPham> GetSanPhamYeuThichByUser(string maUser)
        {
            List<SanPham> sanPhamList = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            SELECT SP.maSp, SP.maDm, SP.maHang, SP.tenSp, SP.hinhAnh, SP.moTa,
                   SP.giaNhap, SP.giaBan, SP.soLuong, SP.created_at
            FROM SANPHAM SP
            INNER JOIN YEUTHICH YT ON SP.maSp = YT.maSp
            WHERE YT.maUser = @maUser";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maUser", maUser);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sanPhamList.Add(new SanPham
                            {
                                MaSp = reader["maSp"].ToString(),
                                MaDm = reader["maDm"].ToString(),
                                MaHang = reader["maHang"].ToString(),
                                TenSp = reader["tenSp"].ToString(),
                                HinhAnh = reader["hinhAnh"].ToString(),
                                MoTa = reader["moTa"].ToString(),
                                GiaNhap = Convert.ToInt64(reader["giaNhap"]),
                                GiaBan = Convert.ToInt64(reader["giaBan"]),
                                SoLuong = Convert.ToInt32(reader["soLuong"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            });
                        }
                    }
                }
            }

            return sanPhamList;
        }
        public static int GetSoLuotXem(string maSp)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT soLuotXem FROM LUOTXEM WHERE maSp = @maSp";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
        public static void TangLuotXem(string maSp)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            IF EXISTS (SELECT 1 FROM LUOTXEM WHERE maSp = @maSp)
                UPDATE LUOTXEM SET soLuotXem = soLuotXem + 1 WHERE maSp = @maSp
            ELSE
                INSERT INTO LUOTXEM(maSp, soLuotXem) VALUES(@maSp, 1)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
