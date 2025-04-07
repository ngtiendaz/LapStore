using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Controller;
using LapStore.Model;
using Microsoft.VisualBasic.ApplicationServices;

namespace LapStore.Widget.User
{
    public partial class thanhToan : UserControl
    {
        public event EventHandler OnBackToGioHang;
        public event EventHandler OnBackToHome;
        private List<GioHang> danhSachSanPham;
        private string maUser;
        private long TONG;
        public thanhToan()
        {
            InitializeComponent();
        }
        public void HienThiThongTin(List<GioHang> danhSach, long tongTien, int soLuong)
        {
            maUser = UserController.CurrentUser.Id;
            danhSachSanPham = danhSach;
            TONG = tongTien;

            txtTongTien.Text = tongTien.ToString("N0") + "đ";
            count.Text = soLuong.ToString() + " sản phẩm";
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            OnBackToGioHang?.Invoke(this, EventArgs.Empty);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            OnBackToGioHang?.Invoke(this, EventArgs.Empty);
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            OnBackToHome?.Invoke(this, EventArgs.Empty);
        }

        private void btn_datHang_Click(object sender, EventArgs e)
        {
            string hoTen = txt_hoTen.Text.Trim();
            string sdt = txt_sdt.Text.Trim();
            string diaChi = txt_diaChi.Text.Trim();
            string phuongThuc = radioOf.Checked ? "Thanh toán khi nhận hàng" : "Chuyển khoản";
            string newId = DonHangController.GenerateNewDonHangId();

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin giao hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var spList = danhSachSanPham
                .Select(sp => (sp.MaSp, sp.SoLuong, sp.Gia))
                .ToList();

            try
            {
                bool donHangOk = DonHangController.TaoDonHang(
                    newId,
                    maUser,
                    diaChi,
                    phuongThuc,
                    sdt,
                    TONG,
                    spList
                );

                if (!donHangOk)
                {
                    MessageBox.Show("❌ Tạo đơn hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ChiTietDonHangController.ThemChiTietDonHang(newId, spList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                GioHangController.XoaSauKhiMua(maUser, spList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá giỏ hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DonHangController.XuLyDonHangSauKhiTao(newId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý tồn kho & thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu đến đây thì mọi thứ đều OK
            MessageBox.Show("🎉 Đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OnBackToHome?.Invoke(this, EventArgs.Empty);
        }



    }
}
