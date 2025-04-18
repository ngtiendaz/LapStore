using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
    }
}
