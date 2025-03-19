using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LapStore
{
    public class Database
    {
        private static readonly string connectionString = "Server=DAZAUGUST;Database=projectLap;Trusted_Connection=True;";


        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
        public static bool KiemTraMaSp(string maSp)
        {
            if (string.IsNullOrWhiteSpace(maSp))
            {
                MessageBox.Show("Mã sản phẩm không được để trống!");
                return false;
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

    }
}