
using LapStore;
using LapStore.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LapStore
{
    class SanPhamController
    {
        // Lấy tất cả sản phẩm
        // Lấy danh sách sản phẩm theo mã danh mục
        public static List<SanPham> getSanPhamByMaDm(string maDm)
        {
            List<SanPham> SanPham = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM SANPHAM WHERE maDm = @maDm";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maDm", maDm);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPham.Add(new SanPham
                            {
                                MaSp = reader["maSp"].ToString(),
                                MaDm = reader["maDm"].ToString(),
                                TenSp = reader["tenSp"].ToString(),
                                HinhAnh = reader["hinhAnh"].ToString(),
                                MoTa = reader["moTa"].ToString(),
                                GiaNhap = (long)reader["giaNhap"],
                                GiaBan = (long)reader["giaBan"],
                                SoLuong = (int)reader["soLuong"],
                                CreatedAt = (DateTime)reader["created_at"]
                            });
                        }
                    }
                }
            }

            return SanPham;
        }


        // Thêm sản phẩm
        public static void AddSanPham(SanPham sanPham)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "INSERT INTO SANPHAM(maSp, maDm, tenSp, hinhAnh, moTa, giaNhap, giaBan, soLuong) " +
                               "VALUES (@maSp, @maDm, @tenSp, @hinhAnh, @moTa, @giaNhap, @giaBan, @soLuong)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", sanPham.MaSp);
                    cmd.Parameters.AddWithValue("@maDm", sanPham.MaDm);
                    cmd.Parameters.AddWithValue("@tenSp", sanPham.TenSp);
                    cmd.Parameters.AddWithValue("@hinhAnh", sanPham.HinhAnh);
                    cmd.Parameters.AddWithValue("@moTa", sanPham.MoTa);
                    cmd.Parameters.AddWithValue("@giaNhap", sanPham.GiaNhap);
                    cmd.Parameters.AddWithValue("@giaBan", sanPham.GiaBan);
                    cmd.Parameters.AddWithValue("@soLuong", sanPham.SoLuong);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Cập nhật sản phẩm
        public static void UpdateSanPham(SanPham sanPham)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE SANPHAM SET maDm = @maDm, tenSp = @tenSp, hinhAnh = @hinhAnh, moTa = @moTa, " +
                               "giaNhap = @giaNhap, giaBan = @giaBan, soLuong = @soLuong WHERE maSp = @maSp";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", sanPham.MaSp);
                    cmd.Parameters.AddWithValue("@maDm", sanPham.MaDm);
                    cmd.Parameters.AddWithValue("@tenSp", sanPham.TenSp);
                    cmd.Parameters.AddWithValue("@hinhAnh", sanPham.HinhAnh);
                    cmd.Parameters.AddWithValue("@moTa", sanPham.MoTa);
                    cmd.Parameters.AddWithValue("@giaNhap", sanPham.GiaNhap);
                    cmd.Parameters.AddWithValue("@giaBan", sanPham.GiaBan);
                    cmd.Parameters.AddWithValue("@soLuong", sanPham.SoLuong);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Xóa sản phẩm
        public static void DeleteSanPham(string maSp)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM SANPHAM WHERE maSp = @maSp";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Tìm kiếm sản phẩm
        public static List<SanPham> SearchSanPham(string searchValue)
        {
            List<SanPham> SanPham = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM SANPHAM WHERE maSp LIKE @search OR tenSp LIKE @search OR moTa LIKE @search";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchValue + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPham.Add(new SanPham
                            {
                                MaSp = reader["maSp"].ToString(),
                                MaDm = reader["maDm"].ToString(),
                                TenSp = reader["tenSp"].ToString(),
                                HinhAnh = reader["hinhAnh"].ToString(),
                                MoTa = reader["moTa"].ToString(),
                                GiaNhap = (long)reader["giaNhap"],
                                GiaBan = (long)reader["giaBan"],
                                SoLuong = (int)reader["soLuong"],
                                CreatedAt = (DateTime)reader["created_at"]
                            });
                        }
                    }
                }
            }

            return SanPham;
        }
    }
}
