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

namespace LapStore.Widget
{
    public partial class itemSanPham : UserControl
    {
        public static Random random = new Random();


        public event Action<SanPham> OnSanPhamClick; // Sự kiện để truyền dữ liệu sản phẩm

        private SanPham sanPham;
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

                txtGiaNhap.Text = value.ToString("N0") + "đ";
            }
        }
        public long SoLuong
        {
            set
            {

                
                    if (value == 0)
                    {
                        txt_trangThai.Text = "Hết hàng";
                        txt_trangThai.ForeColor = Color.Red; // Chữ màu đỏ
                        this.BackColor = Color.LightGray; // Background màu xám
                    }
                    else
                    {
                    txt_trangThai.Text = "Sẵn hàng";
                    txt_trangThai.ForeColor = Color.Green;

                }
                
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

        public itemSanPham(SanPham sp)
        {
            InitializeComponent();
            this.Size = new Size(200, 250); // Đặt kích thước cố định
            this.AutoSize = false;          // Tắt tự động thay đổi kích thước
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            this.sanPham = sp;
            GiaNhap = sp.GiaBan + 5999000;
            MaSp = sp.MaSp;
            TenSp = sp.TenSp;
            GiaBan = sp.GiaBan;
            HinhAnh = sp.HinhAnh;
            SoLuong = sp.SoLuong;

            this.Click += ItemSanPham_Click;
            foreach (Control control in this.Controls)
            {
                control.Click += ItemSanPham_Click;
            }

        }
        private void ItemSanPham_Click(object sender, EventArgs e)
        {
            OnSanPhamClick?.Invoke(sanPham);
        }
    }
}
