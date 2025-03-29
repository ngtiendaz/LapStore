using System;

namespace LapStore.Model
{
    internal class UserModel
    {
        public string Id { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public bool Check { get; set; }
        public string HinhAnh { get; set; }

        // Constructor
        public UserModel() { }

        public UserModel(string id, string hoTen, string email, string pass, string diaChi, string sdt, bool check, string hinhAnh)
        {
            Id = id;
            HoTen = hoTen;
            Email = email;
            Pass = pass;
            DiaChi = diaChi;
            Sdt = sdt;
            Check = check;
            HinhAnh = hinhAnh;
        }
    }
}
