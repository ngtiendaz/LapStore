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
using LapStore.Controller;
using LapStore.Model;

namespace LapStore.Widget.User
{
    public partial class detailSanPham : UserControl
    {
        public event EventHandler OnMuaThanhCong;
        private bool isLiked = false;
        private string MaUser = UserController.CurrentUser.Id;
        private int soLuong = 1;
        long GIA;
        string MSP;
        public detailSanPham(SanPham sp)
        {
            long tietKiem= 5999000;
            InitializeComponent();
            txtMaSP.Text = "Mã SP: "+ sp.MaSp;
            MSP = sp.MaSp;
            txt_TenSP.Text = sp.TenSp;
            txt_soLuongKho.Text = "*Số lượng còn lại trong kho: "+sp.SoLuong;
            txt_giaCu.Text = (sp.GiaBan + tietKiem).ToString("N0") + "đ";
            txtGia.Text = sp.GiaBan.ToString("N0") + "đ";
            GIA = sp.GiaBan;
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
            if (isLiked)
            {
                YeuThichVaLuotXemController.XoaYeuThich(MaUser, MSP);
                isLiked = false;
                SetHeartIcon("icons8-nofavorite-32");
            }
            else
            {
                YeuThichVaLuotXemController.ThemYeuThich(MaUser, MSP);
                isLiked = true;
                SetHeartIcon("icons8-favorite-32");
            }

        }
        private void SetHeartIcon(string resourceName)
        {
            var img = (Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
            if (img != null)
            {
                btn_like.Image = img;
            }
        }

        private void btn_mua_Click(object sender, EventArgs e)
        {
            string MaUser = UserController.CurrentUser.Id;
            string MaSp = MSP;
            int SoLuong = int.Parse(txtSoLuongMua.Text);
            long Gia = GIA;

            if (GioHangController.IsSanPhamTrongGioHang(MaUser, MaSp))
            {
                DialogResult result = MessageBox.Show(
                    "Sản phẩm đã có trong giỏ hàng!\nBạn muốn đi tới giỏ hàng không?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    OnMuaThanhCong?.Invoke(this, EventArgs.Empty); // báo về form cha mở giỏ hàng
                }
                // Nếu No thì không làm gì, tiếp tục mua sắm
            }
            else
            {
                GioHangController.AddToGioHang(MaUser, MaSp, SoLuong, Gia);
                MessageBox.Show("Đã thêm sản phẩm vào giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnMuaThanhCong?.Invoke(this, EventArgs.Empty);
            }
        }

        private void detailSanPham_Load(object sender, EventArgs e)
        {
            isLiked = YeuThichVaLuotXemController.IsSanPhamYeuThich(MaUser, MSP);
            SetHeartIcon(isLiked ? "icons8-favorite-32" : "icons8-nofavorite-32");
            YeuThichVaLuotXemController.TangLuotXem(MSP);
            int luotXem = YeuThichVaLuotXemController.GetSoLuotXem(MSP);
            txt_luotXem.Text = "Lượt xem: "+ luotXem;
        }
    }
}
