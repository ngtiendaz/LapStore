using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Model;

namespace LapStore.Widget.User
{
    public partial class detailSanPham : UserControl
    {
        private bool isLiked = false;
        private int soLuong = 1;
        public detailSanPham(SanPham sp)
        {
            long tietKiem= 5999000;
            InitializeComponent();
            txtMaSP.Text = "Mã SP: "+ sp.MaSp;
            txt_TenSP.Text = sp.TenSp;
            txt_soLuongKho.Text = "*Số lượng còn lại trong kho: "+sp.SoLuong;
            txt_giaCu.Text = (sp.GiaBan + tietKiem).ToString("N0") + "đ";
            txtGia.Text = sp.GiaBan.ToString("N0") + "đ";
            txt_tietKiem.Text = "Tiết kiệm: "+tietKiem.ToString("N0") + "đ";
            txt_moTa.Text = sp.MoTa;

            try
            {
                imageSP.Image = Image.FromFile(sp.HinhAnh);
                imageSP.SizeMode = PictureBoxSizeMode.StretchImage;
             
            }
            catch
            {
                //imageSP.Image = Properties.Resources.default_image;
            }
            if (sp.SoLuong == 0)
            {
                btn_mua.Text = "Hết hàng";       // Thay đổi chữ
                btn_mua.Enabled = false;         // Vô hiệu hóa nút
              
            }
        }

        private void btn_congSoLuong_Click(object sender, EventArgs e)
        {
            int soLuongKho = int.Parse(txt_soLuongKho.Text.Split(':')[1].Trim()); // Lấy số lượng kho từ label
            if (soLuong < soLuongKho)
            {
                soLuong++;
                txtSoLuongMua.Text = soLuong.ToString();
            }
            else
            {
                MessageBox.Show("Số lượng mua vượt quá số lượng kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btn_truSoLuong_Click(object sender, EventArgs e)
        {
            if (soLuong > 1)
            {
                soLuong--;
                txtSoLuongMua.Text = soLuong.ToString();
            }
        }

        private void btn_like_Click(object sender, EventArgs e)
        {
            isLiked = !isLiked;
            string imageName = isLiked ? "icons8-favorite-32" : "icons8-nofavorite-32";
            SetHeartIcon(imageName);
        }
        private void SetHeartIcon(string resourceName)
        {
            var img = (Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
            if (img != null)
            {
                btn_like.Image = img;
            }
        }
    }
}
