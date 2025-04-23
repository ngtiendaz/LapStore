using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class PhieuBaoHanhController
    {
        public static List<PhieuBaoHanh> GetAllPhieuBaoHanh()
        {
            List<PhieuBaoHanh> list = new List<PhieuBaoHanh>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM PHIEUBAOHANH";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PhieuBaoHanh
                            {
                                Id = reader["id"].ToString(),
                                TenPhieu = reader["tenPhieu"].ToString(),
                                Gia = Convert.ToInt64(reader["gia"]),
                                SoLuong = Convert.ToInt32(reader["soLuong"]),
                                ThoiHanThang = Convert.ToInt32(reader["thoiHanThang"])
                            });
                        }
                    }
                }
            }

            return list;
        }

        public static void AddPhieuBaoHanh(PhieuBaoHanh phieu)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"INSERT INTO PHIEUBAOHANH (id, tenPhieu, gia, soLuong, thoiHanThang)
                                 VALUES (@id, @tenPhieu, @gia, @soLuong, @thoiHanThang)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", phieu.Id);
                    cmd.Parameters.AddWithValue("@tenPhieu", phieu.TenPhieu);
                    cmd.Parameters.AddWithValue("@gia", phieu.Gia);
                    cmd.Parameters.AddWithValue("@soLuong", phieu.SoLuong);
                    cmd.Parameters.AddWithValue("@thoiHanThang", phieu.ThoiHanThang);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdatePhieuBaoHanh(PhieuBaoHanh phieu)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"UPDATE PHIEUBAOHANH 
                                 SET tenPhieu = @tenPhieu, gia = @gia, soLuong = @soLuong, thoiHanThang = @thoiHanThang
                                 WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", phieu.Id);
                    cmd.Parameters.AddWithValue("@tenPhieu", phieu.TenPhieu);
                    cmd.Parameters.AddWithValue("@gia", phieu.Gia);
                    cmd.Parameters.AddWithValue("@soLuong", phieu.SoLuong);
                    cmd.Parameters.AddWithValue("@thoiHanThang", phieu.ThoiHanThang);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeletePhieuBaoHanh(string id)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM PHIEUBAOHANH WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string GenerateNewPhieuBaoHanh()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT TOP 1 id FROM PHIEUBAOHANH ORDER BY id DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string lastId = result.ToString(); // VD: "PBH007"
                        int number = int.Parse(lastId.Substring(3)) + 1;
                        return "PBH" + number.ToString("D3");
                    }
                    else
                    {
                        return "PBH001";
                    }
                }
            }
        }

        public static bool TruSoLuongPhieu(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE PHIEUBAOHANH SET soLuong = soLuong - 1 WHERE id = @id AND soLuong > 0";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public static List<PhieuBaoHanh> SearchPhieuBaoHanh(string keyword)
        {
            List<PhieuBaoHanh> result = new List<PhieuBaoHanh>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            SELECT * 
            FROM PHIEUBAOHANH
            WHERE tenPhieu LIKE @keyword OR id LIKE @keyword";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new PhieuBaoHanh
                            {
                                Id = reader["id"].ToString(),
                                TenPhieu = reader["tenPhieu"].ToString(),
                                Gia = Convert.ToInt64(reader["gia"]),
                                SoLuong = Convert.ToInt32(reader["soLuong"]),
                                ThoiHanThang = Convert.ToInt32(reader["thoiHanThang"])
                            });
                        }
                    }
                }
            }

            return result;
        }
        public static void AddChiTietPhieuBaoHanh(string maDonHang, string maPhieu)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                

                // Lấy thời hạn tháng từ bảng PHIEUBAOHANH
                int thoiHanThang = 0;
                string getThoiHanQuery = "SELECT thoiHanThang FROM PHIEUBAOHANH WHERE id = @maPhieu";
                using (SqlCommand cmd = new SqlCommand(getThoiHanQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@maPhieu", maPhieu);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        thoiHanThang = Convert.ToInt32(result);
                    }
                }

                DateTime ngayBatDau = DateTime.Now;
                DateTime ngayKetThuc = ngayBatDau.AddMonths(thoiHanThang);

                string maCTPBH = GenerateNewChiTietPhieuBaoHanh();

                string insertQuery = @"INSERT INTO CT_PHIEUBAOHANH (id, maDonHang, maPhieuBaoHanh, thoiGianBatDau, thoiGianKetThuc)
                               VALUES (@id, @maDonHang, @maPhieu, @thoiGianBatDau, @thoiGianKetThuc)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", maCTPBH);
                    cmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                    cmd.Parameters.AddWithValue("@maPhieu", maPhieu);
                    cmd.Parameters.AddWithValue("@thoiGianBatDau", ngayBatDau);
                    cmd.Parameters.AddWithValue("@thoiGianKetThuc", ngayKetThuc);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private static string GenerateNewChiTietPhieuBaoHanh()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
         
                string query = "SELECT TOP 1 id FROM CT_PHIEUBAOHANH ORDER BY id DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string lastId = result.ToString(); // VD: CTPBH007
                        int number = int.Parse(lastId.Substring(5)) + 1;
                        return "CTPBH" + number.ToString("D3");
                    }
                    else
                    {
                        return "CTPBH001";
                    }
                }
            }
        }
        public static string TraCuuThoiGianBaoHanh(string maDonHang)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                // 1. Kiểm tra trạng thái đơn hàng
                string checkTrangThaiQuery = "SELECT trangThai FROM DONHANG WHERE id = @maDonHang";
                using (SqlCommand cmd = new SqlCommand(checkTrangThaiQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                    object trangThai = cmd.ExecuteScalar();

                    if (trangThai == null)
                        return "Không tìm thấy đơn hàng.";

                    if (trangThai.ToString().Trim().Equals("Đã hủy", StringComparison.OrdinalIgnoreCase))
                        return "Đơn hàng đã được hủy.";
                }

                // 2. Tìm thời gian kết thúc bảo hành
                string query = @"SELECT thoiGianKetThuc 
                         FROM CT_PHIEUBAOHANH 
                         WHERE maDonHang = @maDonHang";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                    object ketThuc = cmd.ExecuteScalar();

                    if (ketThuc != null && ketThuc is DateTime)
                    {
                        DateTime thoiGian = (DateTime)ketThuc;
                        return "Bảo hành đến ngày: " + thoiGian.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        return "Đơn hàng không có phiếu bảo hành.";
                    }
                }
            }
        }



    }
}
