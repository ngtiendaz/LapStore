using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LapStore
{
    public class Database
    {
        private static readonly string connectionString = "Server=Daz;Database=projectLapNew;Trusted_Connection=True;";


        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
        public static bool CheckNull(string maSp)
        {
            if (string.IsNullOrWhiteSpace(maSp))
            {
                MessageBox.Show("Mã không được để trống!");
                return false;
            }
            return true;
        }
        public static bool KiemTraMaSp(string maSp)
        {
            if (string.IsNullOrWhiteSpace(maSp))
            {
                MessageBox.Show("Mã sản phẩm không được để trống!");
                return false;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM SANPHAM WHERE maSp = @maSp";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSp", maSp);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại trong hệ thống!");
                        return false;
                    }
                }
            }

            return true;
        }

        // Hàm kiểm tra giá nhập và giá bán
        public static bool KiemTraGia(string giaNhapStr, string giaBanStr)
        {
            if (!long.TryParse(giaNhapStr, out long giaNhap) || giaNhap < 0)
            {
                MessageBox.Show("Giá nhập phải là một số dương!");
                return false;
            }

            if (!long.TryParse(giaBanStr, out long giaBan) || giaBan < 0)
            {
                MessageBox.Show("Giá bán phải là một số dương!");
                return false;
            }

            if (giaNhap >= giaBan)
            {
                MessageBox.Show("Giá nhập phải nhỏ hơn giá bán!");
                return false;
            }

            return true;
        }
        public static bool KiemTraSoLuong(string soLuongStr)
        {
            if (!int.TryParse(soLuongStr, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là một số nguyên dương!");
                return false;
            }
            return true;
        }

        public static bool KiemTraSoDienThoai(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt) || !Regex.IsMatch(sdt, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số!");
                return false;
            }
            return true;
        }

        // Hàm kiểm tra mật khẩu (phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường và số)
        public static bool KiemTraMatKhau(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6 ||
                !Regex.IsMatch(password, @"[a-z]") || // Chứa ít nhất 1 chữ thường
                !Regex.IsMatch(password, @"\d")) // Chứa ít nhất 1 số
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự, bao gồm chữ thường và số!");
                return false;
            }
            return true;
        }

        // Hàm kiểm tra email (định dạng hợp lệ)
        public static bool KiemTraEmail(string email)
        {
            // Kiểm tra email có rỗng không
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email không được để trống!");
                return false;
            }

            // Kiểm tra định dạng email
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng nhập đúng định dạng.");
                return false;
            }

            // Kiểm tra email đã tồn tại trong database chưa
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM USERS WHERE email = @email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Email đã tồn tại! Vui lòng chọn email khác.");
                        return false;
                    }
                }
            }

            return true;
        }
        public static bool CheckEmailNull(string email, string currentUserId = null)
        {
            // Kiểm tra email có rỗng không
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email không được để trống!");
                return false;
            }

            // Kiểm tra định dạng email
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng nhập đúng định dạng.");
                return false;
            }

            // Kiểm tra email đã tồn tại trong database (ngoại trừ tài khoản hiện tại)
            using (SqlConnection conn = Database.GetConnection())
            {
               
                string query = "SELECT COUNT(*) FROM USERS WHERE email = @email AND id != @currentUserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@currentUserId", currentUserId ?? (object)DBNull.Value); // Nếu không có ID thì bỏ qua

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Email đã tồn tại! Vui lòng chọn email khác.");
                        return false;
                    }
                }
            }

            return true;
        }


        public static bool KiemTraIdUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                MessageBox.Show("ID người dùng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM USERS WHERE id = @userId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("ID người dùng đã tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true; // ID hợp lệ (chưa tồn tại)
        }


    }
}