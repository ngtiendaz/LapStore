using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LapStore.Controller
{
    internal class ThongKeController
    {
        public static List<string> GenerateThongKeIds(int soLuong)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id FROM THONGKE";
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

                    int startId = (existingIds.Count > 0 ? existingIds.Max() : 0) + 1;
                    return Enumerable.Range(startId, soLuong)
                                     .Select(i => $"TK{i:D3}")
                                     .ToList();
                }
            }
        }

    }
}
