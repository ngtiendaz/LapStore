using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
                        comboBox.ValueMember = "id";        // Value là mã hãng
                    }
                }
            }
        }
    }
}
