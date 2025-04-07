using System;
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

namespace LapStore.Widget.User
{
    public partial class itemSPGioHang : UserControl
    {
        public event EventHandler SoLuongChanged;
        public event EventHandler RemoveChanged;
        public event EventHandler CheckedChanged;
        private GioHang gioHang;
        private int _soLuong;
        private long _giaBan;
        public string MaSp
        {
            get => txtMaSp.Text;
            set => txtMaSp.Text = value.Trim(); // Ví dụ: "SP001"
        }
        public bool IsChecked
        {
            get => check.Checked;
            set => check.Checked = value;
        }

        public string TenSp
        {
            get => txtTenSp.Text;
            set => txtTenSp.Text = value; // Ví dụ: "Vỏ Case Asus ROG Hyperion..."
        }

        public long GiaBan
        {
            get => _giaBan;
            set
            {
                _giaBan = value;
                txt_giaTien.Text = value.ToString("N0") + "đ";
                CapNhatThanhTien(); // gọi hàm tính thành tiền
            }
        }

        public int SoLuong
        {
            get => _soLuong;
            set
            {
                _soLuong = value;
                txtSoLuongMua.Text = value.ToString();
                CapNhatThanhTien(); // gọi hàm tính thành tiền
            }
        }

        public long ThanhTien
        {
            get => long.Parse(txtTongTien.Text.Replace(".", "").Replace("đ", "").Trim());
            private set => txtTongTien.Text = value.ToString("N0") + "đ";
        }
        private void CapNhatThanhTien()
        {
            long thanhTien = _giaBan * _soLuong;
            txtTongTien.Text = thanhTien.ToString("N0") + "đ";
        }

        public string HinhAnh
        {
            set
            {
                try
                {
                    imageSP.Image = Image.FromFile(value);
                    imageSP.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    imageSP.Image = Properties.Resources.daz;
                    imageSP.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        public itemSPGioHang(GioHang gh)
        {
            InitializeComponent();
            this.gioHang = gh;

            MaSp = gh.MaSp;
            TenSp = gh.TenSp;
            GiaBan = gh.Gia;
            SoLuong = gh.SoLuong;
            HinhAnh = gh.HinhAnh;
            ThanhTien = gh.ThanhTien;


        }
        private void btn_Tang_Click(object sender, EventArgs e)
        {
            int soLuongKho = GioHangController.LaySoLuongKho(MaSp);
            if (SoLuong < soLuongKho)
            {
                SoLuong++;
                gioHang.SoLuong = SoLuong;

                // Cập nhật DB
                GioHangController.CapNhatSoLuong(UserController.CurrentUser.Id, MaSp, SoLuong);

                OnSoLuongChanged();
            }
            else
            {
                MessageBox.Show("Không thể vượt quá số lượng tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Giam_Click(object sender, EventArgs e)
        {

            if (SoLuong > 1)
            {
                SoLuong--;
                gioHang.SoLuong = SoLuong;

                // Cập nhật DB
                GioHangController.CapNhatSoLuong(UserController.CurrentUser.Id, MaSp, SoLuong);

                OnSoLuongChanged();
            }
        }
        protected virtual void OnSoLuongChanged()
        {
            SoLuongChanged?.Invoke(this, EventArgs.Empty);
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            gioHang.IsChecked = check.Checked;
            OnCheckedChanged(); // Kích hoạt sự kiện
            CapNhatThanhTien(); // Cập nhật UI nếu cần
        }
        protected virtual void OnCheckedChanged()
        {
            CheckedChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này khỏi giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa khỏi database
                GioHangController.RemoveFromGioHang(UserController.CurrentUser.Id, MaSp);

                // Xóa control khỏi UI (FlowLayoutPanel cha)
                this.Parent.Controls.Remove(this);

                // Có thể kích hoạt sự kiện để Panel giỏ hàng tính lại tổng tiền (nếu có)
                OnRemoveChanged();
                CapNhatThanhTien();
            }
        }
        protected virtual void OnRemoveChanged()
        {
            RemoveChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
