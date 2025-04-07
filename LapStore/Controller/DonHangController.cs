using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class DonHangController
    {
        public static string GenerateNewDonHangId()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id FROM DONHANG";
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

                    return "DH" + newId.ToString("D3");
                }
            }
        }

        public static bool TaoDonHang(string idDonHang, string maUser, string diaChi, string phuongThuc, string sdt, long tongTien, List<(string MaSp, int SoLuong, long Gia)> spList)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert đơn hàng
                        string insertDonHang = @"
                            INSERT INTO DONHANG(id, maUser, diaChi, tongTien, phuongThucThanhToan, trangThai, created_at, sdt)
                            VALUES (@id, @maUser, @diaChi, @tongTien, @phuongThuc, N'Chờ thanh toán', GETDATE(), @sdt)";
                        using (SqlCommand cmd = new SqlCommand(insertDonHang, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", idDonHang);
                            cmd.Parameters.AddWithValue("@maUser", maUser);
                            cmd.Parameters.AddWithValue("@diaChi", diaChi);
                            cmd.Parameters.AddWithValue("@tongTien", tongTien);
                            cmd.Parameters.AddWithValue("@phuongThuc", phuongThuc);
                            cmd.Parameters.AddWithValue("@sdt", sdt);
                            cmd.ExecuteNonQuery();
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi DB: " + ex.Message);
                        return false;
                    }
                }
            }
        }




        public static void CapNhatThongTinDonHang(string idDonHang, string diaChiMoi, string phuongThucMoi, string sdtMoi)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"UPDATE DONHANG SET diaChi = @diaChi, phuongThucThanhToan = @pttt, sdt = @sdt WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@diaChi", diaChiMoi);
                    cmd.Parameters.AddWithValue("@pttt", phuongThucMoi);
                    cmd.Parameters.AddWithValue("@sdt", sdtMoi);
                    cmd.Parameters.AddWithValue("@id", idDonHang);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool HuyDonHang(string idDonHang)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM DONHANG WHERE id = @id AND trangThai = N'Chờ thanh toán'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idDonHang);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<DonHang> GetDonHangTheoTrangThai(string trangThai)
        {
            List<DonHang> list = new List<DonHang>();
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM DONHANG WHERE trangThai = @trangThai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@trangThai", trangThai);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new DonHang
                            {
                                Id = reader["id"].ToString(),
                                MaUser = reader["maUser"].ToString(),
                                DiaChi = reader["diaChi"].ToString(),
                                TongTien = Convert.ToInt64(reader["tongTien"]),
                                PhuongThucThanhToan = reader["phuongThucThanhToan"].ToString(),
                                TrangThai = reader["trangThai"].ToString(),
                                CreatedAt = Convert.ToDateTime(reader["created_at"]),
                                Sdt = reader["sdt"].ToString()
                            });
                        }
                    }
                }
            }

            return list;
        }

        public static void XuLyGiaoThanhCong(string idDonHang)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string queryCT = "SELECT maSp, soLuong, giaBan FROM CHITIETDONHANG WHERE maDonHang = @maDonHang";
                        using (SqlCommand cmd = new SqlCommand(queryCT, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@maDonHang", idDonHang);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string maSp = reader["maSp"].ToString();
                                    int soLuong = Convert.ToInt32(reader["soLuong"]);
                                    long giaBan = Convert.ToInt64(reader["giaBan"]);
                                    long giaNhap = 0;

                                    reader.Close();
                                    using (SqlCommand getGiaNhap = new SqlCommand("SELECT giaNhap FROM SANPHAM WHERE maSp = @maSp", conn, tran))
                                    {
                                        getGiaNhap.Parameters.AddWithValue("@maSp", maSp);
                                        giaNhap = Convert.ToInt64(getGiaNhap.ExecuteScalar());
                                    }

                                    using (SqlCommand updateSL = new SqlCommand("UPDATE SANPHAM SET soLuong = soLuong - @soLuong WHERE maSp = @maSp", conn, tran))
                                    {
                                        updateSL.Parameters.AddWithValue("@soLuong", soLuong);
                                        updateSL.Parameters.AddWithValue("@maSp", maSp);
                                        updateSL.ExecuteNonQuery();
                                    }

                                    string idTK = ThongKeController.GenerateNewThongKeId();
                                    using (SqlCommand insertTK = new SqlCommand(@"
                                        INSERT INTO THONGKE(id, maDonHang, maSp, soLuong, doanhThu, loiNhuan)
                                        VALUES(@id, @maDonHang, @maSp, @soLuong, @doanhThu, @loiNhuan)", conn, tran))
                                    {
                                        insertTK.Parameters.AddWithValue("@id", idTK);
                                        insertTK.Parameters.AddWithValue("@maDonHang", idDonHang);
                                        insertTK.Parameters.AddWithValue("@maSp", maSp);
                                        insertTK.Parameters.AddWithValue("@soLuong", soLuong);
                                        insertTK.Parameters.AddWithValue("@doanhThu", giaBan * soLuong);
                                        insertTK.Parameters.AddWithValue("@loiNhuan", (giaBan - giaNhap) * soLuong);
                                        insertTK.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand("UPDATE DONHANG SET trangThai = N'Giao thành công' WHERE id = @id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", idDonHang);
                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                    }
                }
            }
        }
    }
}
