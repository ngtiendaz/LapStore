using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LapStore.Controller
{
    internal class ThongKeController
    {
        public static string GenerateNewThongKeId()
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string query = "SELECT id FROM THONGKE";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    List<int> existingIds = new List<int>();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["id"].ToString();
                            // Bỏ tiền tố 'TK', chỉ lấy phần số
                            string numberPart = new string(id.SkipWhile(c => !char.IsDigit(c)).ToArray());

                            if (int.TryParse(numberPart, out int numericPart))
                            {
                                existingIds.Add(numericPart);
                            }
                        }
                    }

                    int newIdNumber = (existingIds.Count > 0 ? existingIds.Max() : 0) + 1;
                    return $"TK{newIdNumber:D3}"; // Format: TK001, TK002, ...
                }
            }
        }
    }
}
