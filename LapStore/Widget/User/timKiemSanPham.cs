using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Model;
using LapStore.View;

namespace LapStore.Widget.User
{
    public partial class timKiemSanPham : UserControl
    {
        string key;
        int count=0;
        public timKiemSanPham()
        {
            InitializeComponent();
        }
        public void SetDanhMuc(string Key)
        {
            key = Key; // Cập nhật từ khóa tìm kiếm
            LoadDanhSachSanPham(Key, 0);
            if(count<1)
            {
                txtHienThi.Text = "Không tìm thấy kết quả phù hợp.";
            }
            else
            {
                txtHienThi.Text = "Tìm kiếm " + Key + " có " + count + " kết quả phù hợp.";
            }
        }
        public static void LoadComboBoxSapXep(ComboBox comboBox)
        {
            // Danh sách kiểu sắp xếp
            var sapXepList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0, "Ngẫu nhiên"),
                new KeyValuePair<int, string>(1, "Giá tăng dần"),
                new KeyValuePair<int, string>(2, "Giá giảm dần"),
                new KeyValuePair<int, string>(3, "Tên A-Z"),
                new KeyValuePair<int, string>(4, "Mới nhất"),
            };

            // Gán dữ liệu vào ComboBox
            comboBox.DataSource = sapXepList;
            comboBox.DisplayMember = "Value"; // Hiển thị tên kiểu sắp xếp
            comboBox.ValueMember = "Key"; // Lấy giá trị số tương ứng
        }

        private void LoadDanhSachSanPham(string Key, int sapXep)
        {
            List<SanPham> dsSanPham = SanPhamController.SearchSanPham(Key,null ,sapXep);
            flowSP.Controls.Clear();

            int itemWidth = flowSP.Width / 4 - 20;
            foreach (var sp in dsSanPham)
            {
                itemSanPham item = new itemSanPham(sp)
                {
                    Width = itemWidth,
                    Height = 380
                };

                item.OnSanPhamClick += ItemSanPham_Click;
                flowSP.Controls.Add(item);
                count++;
            }
        }
        private void ItemSanPham_Click(SanPham sp)
        {
            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.ShowDetailSanPham(sp);
            }
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            int kieuSapXep = (int)cbb_sapXep.SelectedValue;

            // Gọi lại hàm LoadDanhSachSanPham để cập nhật danh sách sản phẩm
            LoadDanhSachSanPham(key, kieuSapXep);
        }

        private void timKiemSanPham_Load(object sender, EventArgs e)
        {

            LoadComboBoxSapXep(cbb_sapXep);
            scroll.AutoScroll = true;
            flowSP.WrapContents = true;
            flowSP.FlowDirection = FlowDirection.LeftToRight;
            LoadDanhSachSanPham(key, 0);
        }
    }
}
