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
    public partial class danhMuc : UserControl
    {
        string MADANHMUC;
        public danhMuc()
        {
            InitializeComponent();
        }
        public void SetDanhMuc(string maDanhMuc, string tenDanhMuc)
        {
            MADANHMUC = maDanhMuc; // Cập nhật mã danh mục
            txtHienThi.Text = tenDanhMuc;
            LoadDanhSachSanPham(MADANHMUC, 0);
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

        private void LoadDanhSachSanPham(string maDm , int sapXep)
        {
            List<SanPham> dsSanPham = SanPhamController.GetSanPhamTheo(maDm,sapXep);
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

        private void danhMuc_Load(object sender, EventArgs e)
        {
            LoadComboBoxSapXep(cbb_sapXep);
            scroll.AutoScroll = true;
            flowSP.WrapContents = true;
            flowSP.FlowDirection = FlowDirection.LeftToRight;
            LoadDanhSachSanPham(MADANHMUC,0);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            int kieuSapXep = (int)cbb_sapXep.SelectedValue;

            // Gọi lại hàm LoadDanhSachSanPham để cập nhật danh sách sản phẩm
            LoadDanhSachSanPham(MADANHMUC, kieuSapXep);
        }
    }
}
