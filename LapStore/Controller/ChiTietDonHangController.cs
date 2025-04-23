using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class ChiTietDonHangController
    {
        public static List<string> GenerateChiTietDonHangIds(int count)
        {
            List<string> ids = new List<string>();
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id FROM CHITIETDONHANG";
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
                    int nextId = 1;
                    while (existingIds.Contains(nextId))
                        nextId++;

                    for (int i = 0; i < count; i++)
                    {
                        ids.Add("CTDH" + (nextId + i).ToString("D3"));
                    }
                }
            }
            return ids;
        }


        public static List<ChiTietDonHang> GetByDonHang(string maDonHang)
        {
            List<ChiTietDonHang> list = new List<ChiTietDonHang>();
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM CHITIETDONHANG WHERE maDonHang = @maDonHang";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ChiTietDonHang
                            {
                                Id = reader["id"].ToString(),
                                MaDonHang = reader["maDonHang"].ToString(),
                                MaSp = reader["maSp"].ToString(),
                                SoLuong = Convert.ToInt32(reader["soLuong"]),
                                GiaBan = Convert.ToInt64(reader["giaBan"])
                            });
                        }
                    }
                }
            }
            return list;
        }
        public static List<(string MaSp, int SoLuong, long Gia)> LaySanPhamTuGioHang(
    string maUser, List<string> maSpDuocChon, SqlConnection conn, SqlTransaction tran, out long tongTien)
        {
            var result = new List<(string MaSp, int SoLuong, long Gia)>();
            tongTien = 0;

            foreach (var maSp in maSpDuocChon)
            {
                string query = "SELECT soLuong, gia FROM GIOHANG WHERE maUser = @maUser AND maSp = @maSp";
                using (SqlCommand cmd = new SqlCommand(query, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@maUser", maUser);
                    cmd.Parameters.AddWithValue("@maSp", maSp);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int soLuong = Convert.ToInt32(reader["soLuong"]);
                            long gia = Convert.ToInt64(reader["gia"]);
                            tongTien += gia * soLuong;
                            result.Add((maSp, soLuong, gia));
                        }
                    }
                }
            }

            return result;
        }

        public static void ThemChiTietDonHang(string maDonHang, List<(string MaSp, int SoLuong, long Gia)> spList)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // ✅ Sinh sẵn danh sách ID tương ứng số lượng sản phẩm
                        List<string> idList = GenerateChiTietDonHangIds(spList.Count);

                        for (int i = 0; i < spList.Count; i++)
                        {
                            var sp = spList[i];
                            string idCT = idList[i];

                            string insertCT = @"INSERT INTO CHITIETDONHANG(id, maDonHang, maSp, soLuong, giaBan) 
                                        VALUES(@id, @maDonHang, @maSp, @soLuong, @giaBan)";
                            using (SqlCommand insertCmd = new SqlCommand(insertCT, conn, tran))
                            {
                                insertCmd.Parameters.AddWithValue("@id", idCT);
                                insertCmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                                insertCmd.Parameters.AddWithValue("@maSp", sp.MaSp);
                                insertCmd.Parameters.AddWithValue("@soLuong", sp.SoLuong);
                                insertCmd.Parameters.AddWithValue("@giaBan", sp.Gia);
                                insertCmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("Lỗi khi thêm chi tiết đơn hàng: " + ex.Message);
                    }
                }
            }
        }
        public static List<SanPham> GetSanPhamTrongDonHang(string maDonHang)
        {
            List<SanPham> sanPhamList = new List<SanPham>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"
            SELECT sp.*
            FROM CHITIETDONHANG ct
            JOIN SANPHAM sp ON ct.maSp = sp.maSp
            WHERE ct.maDonHang = @maDonHang";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maDonHang", maDonHang);

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
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                            sanPhamList.Add(sp);
                        }
                    }
                }
            }

            return sanPhamList;
        }




    }
}
