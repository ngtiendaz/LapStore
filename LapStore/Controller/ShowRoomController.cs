using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class ShowRoomController
    {
        public static List<ShowRoom> GetAllShowRoom()
        {
            List<ShowRoom> list = new List<ShowRoom>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM HETHONGCUAHANG";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ShowRoom
                            {
                                Id = reader["id"].ToString(),
                                TenCuaHang = reader["tenCuaHang"].ToString(),
                                DiaChi = reader["diaChi"].ToString(),
                                SoDienThoai = reader["soDienThoai"].ToString(),
                                Email = reader["email"].ToString(),
                                GioMoCua = (TimeSpan)reader["gioMoCua"],
                                GioDongCua = (TimeSpan)reader["gioDongCua"]
                            });
                        }
                    }
                }
            }

            return list;
        }

        public static void AddShowRoom(ShowRoom showRoom)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"INSERT INTO HETHONGCUAHANG (id, tenCuaHang, diaChi, soDienThoai, email, gioMoCua, gioDongCua)
                                 VALUES (@id, @tenCuaHang, @diaChi, @soDienThoai, @email, @gioMoCua, @gioDongCua)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", showRoom.Id);
                    cmd.Parameters.AddWithValue("@tenCuaHang", showRoom.TenCuaHang);
                    cmd.Parameters.AddWithValue("@diaChi", showRoom.DiaChi);
                    cmd.Parameters.AddWithValue("@soDienThoai", showRoom.SoDienThoai);
                    cmd.Parameters.AddWithValue("@email", showRoom.Email);
                    cmd.Parameters.AddWithValue("@gioMoCua", showRoom.GioMoCua);
                    cmd.Parameters.AddWithValue("@gioDongCua", showRoom.GioDongCua);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateShowRoom(ShowRoom showRoom)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"UPDATE HETHONGCUAHANG 
                                 SET tenCuaHang = @tenCuaHang, diaChi = @diaChi, soDienThoai = @soDienThoai,
                                     email = @email, gioMoCua = @gioMoCua, gioDongCua = @gioDongCua
                                 WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", showRoom.Id);
                    cmd.Parameters.AddWithValue("@tenCuaHang", showRoom.TenCuaHang);
                    cmd.Parameters.AddWithValue("@diaChi", showRoom.DiaChi);
                    cmd.Parameters.AddWithValue("@soDienThoai", showRoom.SoDienThoai);
                    cmd.Parameters.AddWithValue("@email", showRoom.Email);
                    cmd.Parameters.AddWithValue("@gioMoCua", showRoom.GioMoCua);
                    cmd.Parameters.AddWithValue("@gioDongCua", showRoom.GioDongCua);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteShowRoom(string id)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM HETHONGCUAHANG WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string GenerateNewShowRoomId()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT TOP 1 id FROM HETHONGCUAHANG ORDER BY id DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string lastId = result.ToString(); // VD: "SR007"
                        int number = int.Parse(lastId.Substring(2)) + 1;
                        return "SR" + number.ToString("D3");
                    }
                    else
                    {
                        return "SR001";
                    }
                }
            }
        }
        public static List<ShowRoom> TimKiemShowRoom(string keyword)
        {
            List<ShowRoom> list = new List<ShowRoom>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = @"SELECT * FROM HETHONGCUAHANG 
                         WHERE tenCuaHang LIKE @keyword OR diaChi LIKE @keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ShowRoom
                            {
                                Id = reader["id"].ToString(),
                                TenCuaHang = reader["tenCuaHang"].ToString(),
                                DiaChi = reader["diaChi"].ToString(),
                                SoDienThoai = reader["soDienThoai"].ToString(),
                                Email = reader["email"].ToString(),
                                GioMoCua = (TimeSpan)reader["gioMoCua"],
                                GioDongCua = (TimeSpan)reader["gioDongCua"]
                            });
                        }
                    }
                }
            }

            return list;
        }

    }
}
