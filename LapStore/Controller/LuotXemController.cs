using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LapStore.Model; 

namespace LapStore.Controller
{
    internal class LuotXemController
    {
        public static int GetLuotXemBySanPhamId(string maSp)
        {
            int luotXem = 0;

            using (SqlConnection conn = Database.GetConnection())
            {
                //  Use a JOIN to get luotXem from the LUOTXEM table.
                string query = "SELECT lx.soLuotXem FROM LUOTXEM lx WHERE lx.maSp = @maSp";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        luotXem = Convert.ToInt32(result);
                    }
                }
            }

            return luotXem;
        }

        public static List<SanPham> GetSanPhamTheoLuotXem(int sapXep)
        {
            List<SanPham> list = new List<SanPham>();
            using (SqlConnection conn = Database.GetConnection())
            {
                string orderBy = (sapXep == 0) ? "DESC" : "ASC";
                // Join SANPHAM and LUOTXEM tables to get the view count.
                string query = $"SELECT sp.*, lx.soLuotXem FROM SANPHAM sp LEFT JOIN LUOTXEM lx ON sp.maSp = lx.maSp ORDER BY lx.soLuotXem {orderBy}";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPham sp = new SanPham
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
                                CreatedAt = Convert.ToDateTime(reader["created_at"]), // Corrected column name
                            };
                            list.Add(sp);
                        }
                    }
                }
            }
            return list;
        }


    }
}
