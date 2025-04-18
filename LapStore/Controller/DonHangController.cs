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
        public static string GetTrangThaiDonHang(string maDonHang)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT trangThai FROM DONHANG WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", maDonHang);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
        }
        public static void CapNhatTrangThaiDonHang(string maDonHang, string trangThaiMoi)
        {
            using (SqlConnection conn = Database.GetConnection())
            {

                // Lấy trạng thái hiện tại của đơn hàng
                string getStatusQuery = "SELECT trangThai FROM DONHANG WHERE id = @id";
                using (SqlCommand getCmd = new SqlCommand(getStatusQuery, conn))
                {
                    getCmd.Parameters.AddWithValue("@id", maDonHang);
                    string trangThaiHienTai = getCmd.ExecuteScalar()?.ToString();

                    if (trangThaiHienTai == null)
                    {
                        throw new Exception("Không tìm thấy đơn hàng.");
                    }

                    // Chỉ cho phép yêu cầu hủy khi trạng thái hiện tại là "Chờ thanh toán"
                    if (trangThaiMoi == "Yêu cầu hủy" && trangThaiHienTai != "Chờ thanh toán")
                    {
                        throw new Exception("Chỉ có thể gửi yêu cầu hủy khi đơn hàng đang ở trạng thái 'Chờ thanh toán'.");
                    }

                    // Cập nhật trạng thái nếu hợp lệ
                    string updateQuery = "UPDATE DONHANG SET trangThai = @trangThai WHERE id = @id";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@trangThai", trangThaiMoi);
                        updateCmd.Parameters.AddWithValue("@id", maDonHang);
                        updateCmd.ExecuteNonQuery();
                    }
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

        public static void XuLyDonHangSauKhiTao(string idDonHang)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Lấy chi tiết đơn hàng
                        string queryCT = "SELECT maSp, soLuong, giaBan FROM CHITIETDONHANG WHERE maDonHang = @maDonHang";
                        var sanPhamList = new List<(string maSp, int soLuong, long giaBan)>();

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
                                    sanPhamList.Add((maSp, soLuong, giaBan));
                                }
                            }
                        }

                        // 2. Tạo trước danh sách ID thống kê (duy nhất)
                        var listIdThongKe = ThongKeController.GenerateThongKeIds(sanPhamList.Count);

                        // 3. Xử lý từng sản phẩm
                        for (int i = 0; i < sanPhamList.Count; i++)
                        {
                            var sp = sanPhamList[i];
                            long giaNhap = 0;

                            // Lấy giá nhập
                            using (SqlCommand getGiaNhap = new SqlCommand("SELECT giaNhap FROM SANPHAM WHERE maSp = @maSp", conn, tran))
                            {
                                getGiaNhap.Parameters.AddWithValue("@maSp", sp.maSp);
                                giaNhap = Convert.ToInt64(getGiaNhap.ExecuteScalar());
                            }

                            // Cập nhật tồn kho
                            using (SqlCommand updateSL = new SqlCommand("UPDATE SANPHAM SET soLuong = soLuong - @soLuong WHERE maSp = @maSp", conn, tran))
                            {
                                updateSL.Parameters.AddWithValue("@soLuong", sp.soLuong);
                                updateSL.Parameters.AddWithValue("@maSp", sp.maSp);
                                updateSL.ExecuteNonQuery();
                            }

                            // Thêm vào thống kê
                            using (SqlCommand insertTK = new SqlCommand(@"
                        INSERT INTO THONGKE(id, maDonHang, maSp, soLuong, doanhThu, loiNhuan)
                        VALUES(@id, @maDonHang, @maSp, @soLuong, @doanhThu, @loiNhuan)", conn, tran))
                            {
                                insertTK.Parameters.AddWithValue("@id", listIdThongKe[i]);
                                insertTK.Parameters.AddWithValue("@maDonHang", idDonHang);
                                insertTK.Parameters.AddWithValue("@maSp", sp.maSp);
                                insertTK.Parameters.AddWithValue("@soLuong", sp.soLuong);
                                insertTK.Parameters.AddWithValue("@doanhThu", sp.giaBan * sp.soLuong);
                                insertTK.Parameters.AddWithValue("@loiNhuan", (sp.giaBan - giaNhap) * sp.soLuong);
                                insertTK.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }




        public static void HoanTacDonHangBiHuy(string idDonHang)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Lưu danh sách sản phẩm từ đơn hàng
                        string queryCT = "SELECT maSp, soLuong FROM CHITIETDONHANG WHERE maDonHang = @maDonHang";
                        var sanPhamList = new List<(string maSp, int soLuong)>();

                        using (SqlCommand cmd = new SqlCommand(queryCT, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@maDonHang", idDonHang);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string maSp = reader["maSp"].ToString();
                                    int soLuong = Convert.ToInt32(reader["soLuong"]);
                                    sanPhamList.Add((maSp, soLuong));
                                }
                            }
                        }

                        // 2. Hoàn tác tồn kho và xoá thống kê
                        foreach (var sp in sanPhamList)
                        {
                            // Cộng lại số lượng trong kho
                            using (SqlCommand updateSL = new SqlCommand(
                                "UPDATE SANPHAM SET soLuong = soLuong + @soLuong WHERE maSp = @maSp", conn, tran))
                            {
                                updateSL.Parameters.AddWithValue("@soLuong", sp.soLuong);
                                updateSL.Parameters.AddWithValue("@maSp", sp.maSp);
                                updateSL.ExecuteNonQuery();
                            }

                            // Xóa thống kê tương ứng
                            using (SqlCommand deleteTK = new SqlCommand(
                                "DELETE FROM THONGKE WHERE maDonHang = @maDonHang AND maSp = @maSp", conn, tran))
                            {
                                deleteTK.Parameters.AddWithValue("@maDonHang", idDonHang);
                                deleteTK.Parameters.AddWithValue("@maSp", sp.maSp);
                                deleteTK.ExecuteNonQuery();
                            }
                        }

                        // 3. Cập nhật trạng thái đơn hàng
                        using (SqlCommand update = new SqlCommand(
                            "UPDATE DONHANG SET trangThai = N'Đã hủy' WHERE id = @id", conn, tran))
                        {
                            update.Parameters.AddWithValue("@id", idDonHang);
                            update.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("Lỗi khi hoàn tác đơn hàng bị hủy: " + ex.Message);
                    }
                }
            }
        }


    }
}
