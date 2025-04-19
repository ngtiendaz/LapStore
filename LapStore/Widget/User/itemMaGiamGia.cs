using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LapStore.Model;

namespace LapStore.Widget.User
{
    public partial class itemMaGiamGia : UserControl
    {
        private GraphicsPath _roundedPath;
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

        public DateTime NgayKetThuc
        {
            get => _maGiamGia?.NgayKetThuc ?? DateTime.Now;
            set => txt_ngayBatDau.Text = $"Từ {_maGiamGia?.NgayBatDau:dd/MM/yyyy} đến {value:dd/MM/yyyy}";
        }

        public itemMaGiamGia(MaGiamGia mgg)
        {
            InitializeComponent();
            _maGiamGia = mgg;

            TenMa = mgg.TenMa;
            SoLuong = mgg.SoLuong;
            PhanTramGiam = mgg.PhanTramGiam;
            NgayBatDau = mgg.NgayBatDau;
            DieuKienApDung = mgg.DieuKienApDung;
            NgayKetThuc = mgg.NgayKetThuc;
            UpdateButtonStatus();
            MakeRoundedCorners(10); // Gọi hàm tạo góc bo tròn

        }
        private void btn_dung_Click(object sender, EventArgs e)
        {
            DungNgayClicked?.Invoke(this, _maGiamGia.Id); // Gửi mã giảm giá về form cha
        }
        private void UpdateButtonStatus()
        {
            // Kiểm tra nếu mã giảm giá đã hết hạn hoặc số lượng = 0
            if (_maGiamGia.NgayKetThuc < DateTime.Now || _maGiamGia.SoLuong <= 0)
            {
                btn_dung.Enabled = false;  // Disable nút "Dùng ngay"
            }
            else
            {
                btn_dung.Enabled = true;  // Enable nút "Dùng ngay"
            }
        }

        private void itemMaGiamGia_Paint(object sender, PaintEventArgs e)
        {
            if (_roundedPath != null)
            {
                using (Pen borderPen = new Pen(Color.Gray, 1)) // Viền đen, dày 2px
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    borderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawPath(borderPen, _roundedPath);
                }
            }
        }
        private void MakeRoundedCorners(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
            _roundedPath = path;
        }
    }
}
