using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LapStore.Model;

namespace LapStore.Controller
{
    internal class DanhMucController
    {
        // Hàm load danh mục vào ComboBox
        public static void LoadDanhMucToComboBox(ComboBox comboBox)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id, tenDanhMuc FROM DANHMUC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        comboBox.DataSource = dt;
                        comboBox.DisplayMember = "tenDanhMuc"; // Hiển thị tên danh mục
                        comboBox.ValueMember = "id";           // Value là mã danh mục
                    }
                }
            }
        }
        public static List<DanhMuc> GetAllDanhMuc()
        {
            List<DanhMuc> danhMucs = new List<DanhMuc>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM DANHMUC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhMucs.Add(new DanhMuc
                            {
                                Id = reader["id"].ToString(),
                                TenDanhMuc = reader["tenDanhMuc"].ToString()
                            });
                        }
                    }
                }
            }

            return danhMucs;
        }
        public static void AddDanhMuc(DanhMuc danhMuc)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "INSERT INTO DANHMUC (id, tenDanhMuc) VALUES (@id, @tenDanhMuc)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", danhMuc.Id);
                    cmd.Parameters.AddWithValue("@tenDanhMuc", danhMuc.TenDanhMuc);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateDanhMuc(DanhMuc danhMuc)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE DANHMUC SET tenDanhMuc = @tenDanhMuc WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", danhMuc.Id);
                    cmd.Parameters.AddWithValue("@tenDanhMuc", danhMuc.TenDanhMuc);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteDanhMuc(string id)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "DELETE FROM DANHMUC WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static string GenerateNewMaDanhMuc()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT TOP 1 id FROM DANHMUC ORDER BY id DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string lastId = result.ToString(); // VD: "DM007"
                        int number = int.Parse(lastId.Substring(2)) + 1;
                        return "DM" + number.ToString("D3");
                    }
                    else
                    {
                        return "DM001";
                    }
                }
            }
        }



    }
}
