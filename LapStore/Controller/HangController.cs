using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class HangController
    {
        // Hàm load hãng vào ComboBox
        public static void LoadHangToComboBox(ComboBox comboBox)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id, tenHang FROM HANG";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        comboBox.DataSource = dt;
                        comboBox.DisplayMember = "tenHang"; // Hiển thị tên hãng
                        comboBox.ValueMember = "id";         // Value là mã hãng
                    }
                }
            }
        }

        public static List<Hang> GetAllHang()
        {
            List<Hang> hangs = new List<Hang>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM HANG";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hangs.Add(new Hang
                            {
                                Id = reader["id"].ToString(),
                                TenHang = reader["tenHang"].ToString()
                            });
                        }
                    }
                }
            }

            return hangs;
        }

        public static void AddHang(Hang hang)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "INSERT INTO HANG (id, tenHang) VALUES (@id, @tenHang)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", hang.Id);
                    cmd.Parameters.AddWithValue("@tenHang", hang.TenHang);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateHang(Hang hang)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE HANG SET tenHang = @tenHang WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", hang.Id);
                    cmd.Parameters.AddWithValue("@tenHang", hang.TenHang);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteHang(string id)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM HANG WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string GenerateNewMaHang()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT TOP 1 id FROM HANG ORDER BY id DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string lastId = result.ToString(); // VD: "H001"
                        int number = int.Parse(lastId.Substring(1)) + 1;
                        return "H" + number.ToString("D3");
                    }
                    else
                    {
                        return "H001";
                    }
                }
            }
        }
        public static string GetTenHangById(string id)
        {
            using (SqlConnection conn = Database.GetConnection())
            { 

                string query = "SELECT tenHang FROM HANG WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id); // Gắn tham số đúng

                    object result = cmd.ExecuteScalar(); // Lấy 1 giá trị
                    return result != null ? result.ToString() : null;
                }
            }
        }

    }
}
