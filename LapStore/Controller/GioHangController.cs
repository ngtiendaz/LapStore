using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class GioHangController
    {
        // Thêm sản phẩm vào giỏ hàng
        public static bool IsSanPhamTrongGioHang(string maUser, string maSp)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM GIOHANG WHERE maUser = @maUser AND maSp = @maSp";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public static bool AddToGioHang(string maUser, string maSp, int soLuong, long gia)
        {
            if (IsSanPhamTrongGioHang(maUser, maSp))
            {
                return false; // Sản phẩm đã có, không thêm
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"INSERT INTO GIOHANG(id, maUser, maSp, soLuong, gia) 
                         VALUES (@id, @maUser, @maSp, @soLuong, @gia)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", GenerateNewId());
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    cmd.Parameters.AddWithValue("@soLuong", soLuong);
                    cmd.Parameters.AddWithValue("@gia", gia);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public static int LaySoLuongKho(string maSp)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT soLuong FROM SanPham WHERE maSp = @maSp";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int soLuongKho))
                    {
                        return soLuongKho;
                    }
                }
            }
            return 0; // Nếu không tìm thấy sản phẩm hoặc lỗi
        }
        public static void CapNhatSoLuong(string maUser, string maSp, int soLuong)
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


        // Lấy giỏ hàng của người dùng, có thông tin sản phẩm
        public static List<GioHang> GetGioHangByUser(string maUser)
        {
            List<GioHang> gioHangList = new List<GioHang>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
                    SELECT G.id, G.maUser, G.maSp, G.soLuong, G.gia,
                           SP.tenSp, SP.hinhAnh
                    FROM GIOHANG G
                    JOIN SANPHAM SP ON G.maSp = SP.maSp
                    WHERE G.maUser = @maUser";

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
                                SoLuong = Convert.ToInt32(reader["soLuong"]),
                                Gia = Convert.ToInt64(reader["gia"]),
                                TenSp = reader["tenSp"].ToString(),
                                HinhAnh = reader["hinhAnh"].ToString()
                            });
                        }
                    }
                }
            }

            return gioHangList;
        }

        // Xóa 1 sản phẩm khỏi giỏ hàng
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

        // Xóa toàn bộ giỏ hàng
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

        // Cập nhật số lượng sản phẩm
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

        // Tạo ID mới dạng GH001, GH002,...
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
                            break;
                        newId++;
                    }

                    return "GH" + newId.ToString("D3");
                }
            }
        }
        public static void XoaSauKhiMua(string maUser, List<(string MaSp, int SoLuong, long Gia)> spList)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var sp in spList)
                        {
                            string deleteQuery = "DELETE FROM GIOHANG WHERE maUser = @maUser AND maSp = @maSp";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, tran))
                            {
                                deleteCmd.Parameters.AddWithValue("@maUser", maUser);
                                deleteCmd.Parameters.AddWithValue("@maSp", sp.MaSp); // <-- sửa đúng tên thuộc tính
                                deleteCmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("Lỗi khi xóa sản phẩm khỏi giỏ hàng sau khi mua: " + ex.Message);
                    }
                }
            }
        }


    }
}
