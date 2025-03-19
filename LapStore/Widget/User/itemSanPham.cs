using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapStore.Widget
{
    public partial class itemSanPham : UserControl
    {
        private static Random random = new Random();
        public string MaSp
        {
            get => txtMaSp.Text;
            set => txtMaSp.Text ="Mã:"+value.Trim();
        }

        public string TenSp
        {
            get => txtTenSp.Text;
            set => txtTenSp.Text = value;
        }

        public long GiaBan
        {
            set => txtGiaBan.Text = value.ToString("N0") + "đ";
        }
        public long GiaNhap
        {
            set
            {
                // Random từ 1,000,000 đến 2,000,000
                long randomGia = random.Next(1_000_000, 2_000_001);
                txtGiaNhap.Text = (value + randomGia).ToString("N0") + "đ";
            }
        }


        public string HinhAnh
        {
            set
            {
                try
                {
                    imageSp.Image = Image.FromFile(value);
                    imageSp.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo ảnh co giãn theo khung
                }
                catch
                {
                    imageSp.Image = Properties.Resources.daz; // Ảnh mặc định nếu lỗi
                    imageSp.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        public itemSanPham()
        {
            InitializeComponent();
            this.Size = new Size(200, 250); // Đặt kích thước cố định
            this.AutoSize = false;          // Tắt tự động thay đổi kích thước
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }
    }
}
