
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
        public static List<SanPham> GetSanPhamTheo(string maDanhMuc = "", int kieuSapXep = 0)
        {
            List<SanPham> sanPhamList = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                // Xây dựng điều kiện WHERE (nếu có mã danh mục)
                string whereClause = string.IsNullOrEmpty(maDanhMuc) ? "" : "WHERE maDm = @maDanhMuc";

                // Xây dựng chuỗi ORDER BY theo kiểu sắp xếp
                string orderBy;
                switch (kieuSapXep)
                {
                    case 1:
                        orderBy = "ORDER BY giaBan ASC"; // Giá tăng dần
                        break;
                    case 2:
                        orderBy = "ORDER BY giaBan DESC"; // Giá giảm dần
                        break;
                    case 3:
                        orderBy = "ORDER BY tenSp ASC"; // Theo chữ cái A-Z
                        break;
                    case 4:
                        orderBy = "ORDER BY created_at DESC"; // Sản phẩm mới nhất
                        break;
                    default:
                        orderBy = "ORDER BY NEWID()"; // Lấy ngẫu nhiên nếu không truyền tham số
                        break;
                }

                // Xây dựng câu lệnh SQL
                string query = $"SELECT * FROM SANPHAM {whereClause} {orderBy}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(maDanhMuc)) // Nếu có mã danh mục, thêm tham số vào câu lệnh
                    {
                        cmd.Parameters.AddWithValue("@maDanhMuc", maDanhMuc);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sanPhamList.Add(new SanPham
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

            return sanPhamList;
        }



        // Lấy tất cả sản phẩm
        public static List<SanPham> GetAllSanPham()
        {
            List<SanPham> sanPhamList = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM SANPHAM";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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
                                GiaNhap = (long)reader["giaNhap"],
                                GiaBan = (long)reader["giaBan"],
                                SoLuong = (int)reader["soLuong"],
                                CreatedAt = (DateTime)reader["created_at"]
                            });
                        }
                    }
                }
            }

            return sanPhamList;
        }
        // Thêm sản phẩm
        public static void AddSanPham(SanPham sanPham)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "INSERT INTO SANPHAM(maSp, maDm, maHang, tenSp, hinhAnh, moTa, giaNhap, giaBan, soLuong) " +
                               "VALUES (@maSp, @maDm, @maHang, @tenSp, @hinhAnh, @moTa, @giaNhap, @giaBan, @soLuong)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", sanPham.MaSp);
                    cmd.Parameters.AddWithValue("@maDm", sanPham.MaDm);
                    cmd.Parameters.AddWithValue("@maHang", sanPham.MaHang);
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
                string query = "UPDATE SANPHAM SET maDm = @maDm, maHang = @maHang, tenSp = @tenSp, hinhAnh = @hinhAnh, " +
                               "moTa = @moTa, giaNhap = @giaNhap, giaBan = @giaBan, soLuong = @soLuong WHERE maSp = @maSp";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", sanPham.MaSp);
                    cmd.Parameters.AddWithValue("@maDm", sanPham.MaDm);
                    cmd.Parameters.AddWithValue("@maHang", sanPham.MaHang);
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
        public static List<SanPham> SearchSanPham(string searchValue, string maDm = "", int kieuSapXep = -1)
        {
            List<SanPham> SanPhams = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                // Danh sách điều kiện WHERE
                List<string> conditions = new List<string>();

                if (!string.IsNullOrEmpty(maDm))
                {
                    conditions.Add("maDm = @maDm");
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    conditions.Add("(maSp LIKE @search OR tenSp LIKE @search OR moTa LIKE @search OR tenSp LIKE @search)");
                }

                // Xây dựng WHERE từ điều kiện
                string whereClause = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";

                // Xây dựng chuỗi ORDER BY theo kiểu sắp xếp
                string orderBy = "";
                switch (kieuSapXep)
                {
                    case 1:
                        orderBy = "ORDER BY giaBan ASC"; // Giá tăng dần
                        break;
                    case 2:
                        orderBy = "ORDER BY giaBan DESC"; // Giá giảm dần
                        break;
                    case 3:
                        orderBy = "ORDER BY tenSp ASC"; // Theo chữ cái A-Z
                        break;
                    case 4:
                        orderBy = "ORDER BY created_at DESC"; // Sản phẩm mới nhất
                        break;
                    default:
                        orderBy = ""; // Không sắp xếp nếu không có kiểu sắp xếp
                        break;
                }

                // Xây dựng câu truy vấn SQL
                string query = $"SELECT * FROM SANPHAM {whereClause} {orderBy}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(maDm))
                    {
                        cmd.Parameters.AddWithValue("@maDm", maDm);
                    }
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchValue + "%");
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhams.Add(new SanPham
                            {
                                MaSp = reader["maSp"].ToString(),
                                MaDm = reader["maDm"].ToString(),
                                MaHang = reader["mahang"].ToString(),
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

            return SanPhams;
        }


        // Tạo mã sản phẩm mới tự động
        public static string GenerateNewMaSp()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT maSp FROM SANPHAM";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    List<int> existingNumbers = new List<int>();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maSp = reader["maSp"].ToString();
                            string numberPart = new string(maSp.SkipWhile(c => !char.IsDigit(c)).ToArray());

                            if (int.TryParse(numberPart, out int numericPart))
                            {
                                existingNumbers.Add(numericPart);
                            }
                        }
                    }

                    // Sắp xếp danh sách số
                    existingNumbers.Sort();

                    // Tìm số bị thiếu trong dãy
                    int newNumber = 1;
                    for (int i = 0; i < existingNumbers.Count; i++)
                    {
                        if (existingNumbers[i] != newNumber)
                        {
                            break;
                        }
                        newNumber++;
                    }

                    // Trả về mã mới với định dạng SP###
                    return "SP" + newNumber.ToString("D3");
                }
            }
        }


    }
}
