using System;
using System.Drawing;
using System.Windows.Forms;
using LapStore.Model;

namespace LapStore.Widget.User
{
    public partial class itemMaGiamGia : UserControl
    {
        public event EventHandler<string> DungNgayClicked;

        private MaGiamGia _maGiamGia;

        public string TenMa
        {
            get => txt_tenMa.Text;
            set => txt_tenMa.Text = value;
        }
        public long DieuKienApDung
        {
            get => _maGiamGia?.DieuKienApDung ?? 0;
            set => txt_dieuKien.Text = $"Áp dụng cho đơn từ {value:N0}đ";
        }

        public int PhanTramGiam
        {
            get => _maGiamGia?.PhanTramGiam ?? 0;
            set => txt_giaGiam.Text = $"-{value}%";
        }

        public int SoLuong
        {
            get => _maGiamGia?.SoLuong ?? 0;
            set => txt_soLuong.Text = $"Còn lại: {value}";
        }

        public DateTime NgayBatDau
        {
            get => _maGiamGia?.NgayBatDau ?? DateTime.Now;
            set => txt_ngayBatDau.Text = $"Từ {value:dd/MM/yyyy} đến {_maGiamGia?.NgayKetThuc:dd/MM/yyyy}";
        }

        //public DateTime NgayKetThuc
        //{
        //    //get => _maGiamGia?.NgayKetThuc ?? DateTime.Now;
        //    //set => txt_ngayKetThuc.Text = $"Từ {_maGiamGia?.NgayBatDau:dd/MM/yyyy} đến {value:dd/MM/yyyy}";
        //}

        public itemMaGiamGia(MaGiamGia mgg)
        {
            InitializeComponent();
            _maGiamGia = mgg;

            TenMa = mgg.TenMa;
            SoLuong = mgg.SoLuong;
            PhanTramGiam = mgg.PhanTramGiam;
            NgayBatDau = mgg.NgayBatDau;
            DieuKienApDung = mgg.DieuKienApDung;
            // NgayKetThuc = mgg.NgayKetThuc;
        }
        private void btn_dung_Click(object sender, EventArgs e)
        {
            DungNgayClicked?.Invoke(this, _maGiamGia.Id); // Gửi mã giảm giá về form cha
        }
    }
}
