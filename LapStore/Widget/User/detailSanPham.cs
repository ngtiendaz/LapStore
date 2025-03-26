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
        private string heartEmptyPath = @"D:\DataC#\icon\false.png";
        private string heartFilledPath = @"D:\Icons\true.png";
        public detailSanPham(SanPham sp)
        {
            long tietKiem= 5999000;
            InitializeComponent();
            txtMaSP.Text = "Mã SP: "+ sp.MaSp;
            txt_TenSP.Text = sp.TenSp;
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
        }

        private void btn_congSoLuong_Click(object sender, EventArgs e)
        {
            soLuong++;
            txtSoLuong.Text = soLuong.ToString();
        }

        private void btn_truSoLuong_Click(object sender, EventArgs e)
        {
            if (soLuong > 1)
            {
                soLuong--;
                txtSoLuong.Text = soLuong.ToString();
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
