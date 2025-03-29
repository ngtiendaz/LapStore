using LapStore.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LapStore.Controller
{
    internal class UserController
    {
        public static UserModel CurrentUser { get; private set; }


        public static string Login(string email, string password)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM USERS WHERE email = @Email AND pass = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Nếu có kết quả, tức là đăng nhập thành công
                        {
                            CurrentUser = new UserModel
                            {
                                Id = reader["id"].ToString(),
                                HoTen = reader["hoTen"].ToString(),
                                Email = reader["email"].ToString(),
                                Pass = reader["pass"].ToString(),
                                DiaChi = reader["diaChi"].ToString(),
                                Sdt = reader["sdt"].ToString(),
                                Check = (bool)reader["check"],
                                HinhAnh = reader["hinhAnh"].ToString()
                            };

                            return CurrentUser.Check ? "USER" : "ADMIN";
                        }
                    }
                }
            }
            return "INVALID"; // Sai email hoặc mật khẩu
        }


        public static List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM USERS";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new UserModel
                            {
                                Id = reader["id"].ToString(),
                                HoTen = reader["hoTen"].ToString(),
                                Email = reader["email"].ToString(),
                                Pass = reader["pass"].ToString(),
                                DiaChi = reader["diaChi"].ToString(),
                                Sdt = reader["sdt"].ToString(),
                                Check = (bool)reader["check"],
                                HinhAnh = reader["hinhAnh"].ToString()
                            });
                        }
                    }
                }
            }
            return users;
        }

        // Thêm người dùng mới
        public static void AddUser(UserModel user)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "INSERT INTO USERS(id, hoTen, email, pass, diaChi, sdt,[check], hinhAnh) " +
                               "VALUES (@id, @hoTen, @email, @pass, @diaChi, @sdt, @check, @hinhAnh)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.Parameters.AddWithValue("@hoTen", user.HoTen);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@pass", user.Pass);
                    cmd.Parameters.AddWithValue("@diaChi", user.DiaChi);
                    cmd.Parameters.AddWithValue("@sdt", user.Sdt);
                    cmd.Parameters.AddWithValue("@check", user.Check);
                    cmd.Parameters.AddWithValue("@hinhAnh", user.HinhAnh);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Cập nhật thông tin người dùng
        public static void UpdateUser(UserModel user)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE USERS SET hoTen = @hoTen, email = @email, pass = @pass, diaChi = @diaChi, " +
                               "sdt = @sdt, [check] = @check, hinhAnh = @hinhAnh WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.Parameters.AddWithValue("@hoTen", user.HoTen);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@pass", user.Pass);
                    cmd.Parameters.AddWithValue("@diaChi", user.DiaChi);
                    cmd.Parameters.AddWithValue("@sdt", user.Sdt);
                    cmd.Parameters.AddWithValue("@check", user.Check);
                    cmd.Parameters.AddWithValue("@hinhAnh", user.HinhAnh);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Xóa người dùng
        public static void DeleteUser(string userId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM USERS WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Tạo mã user mới tự động
        public static int GenerateNewMaUser()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT CAST(id AS INT) AS NumericId FROM USERS";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    List<int> existingNumbers = new List<int>();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            existingNumbers.Add(reader.GetInt32(0));
                        }
                    }
                    existingNumbers.Sort();
                    int newNumber = 1;
                    foreach (int num in existingNumbers)
                    {
                        if (num != newNumber)
                        {
                            break;
                        }
                        newNumber++;
                    }
                    return newNumber;
                }
            }
        }
        public static bool Register(string hoTen, string email, string pass)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "INSERT INTO USERS(id, hoTen, email, pass, diaChi, sdt,  [check], hinhAnh) " +
                               "VALUES (@id, @hoTen, @email, @pass, NULL, NULL, 1, NULL)"; // check = 1 là USER

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int newId = GenerateNewMaUser(); // Tạo ID mới tự động

                    cmd.Parameters.AddWithValue("@id", newId);
                    cmd.Parameters.AddWithValue("@hoTen", hoTen);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    int rowsAffected = cmd.ExecuteNonQuery(); // Thực thi truy vấn

                    return rowsAffected > 0; // Trả về true nếu thành công
                }
            }
        }
        public static List<UserModel> SearchUsers(string keyword)
        {
            List<UserModel> users = new List<UserModel>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM USERS WHERE " +
                               "id LIKE @Keyword OR " +
                               "hoTen LIKE @Keyword OR " +
                               "email LIKE @Keyword OR " +
                               "[check] LIKE @Keyword OR " +
                               "sdt LIKE @Keyword";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new UserModel
                            {
                                Id = reader["id"].ToString(),
                                HoTen = reader["hoTen"].ToString(),
                                Email = reader["email"].ToString(),
                                Pass = reader["pass"].ToString(),
                                DiaChi = reader["diaChi"].ToString(),
                                Sdt = reader["sdt"].ToString(),
                                Check = (bool)reader["check"],
                                HinhAnh = reader["hinhAnh"].ToString()
                            });
                        }
                    }
                }
            }
            return users;
        }



    }

}
