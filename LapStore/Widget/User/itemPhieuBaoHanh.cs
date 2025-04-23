using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Model;

namespace LapStore.Widget.User
{
    public partial class itemPhieuBaoHanh : UserControl
    {
        private GraphicsPath _roundedPath;
        public event EventHandler<string> ChonClicked;

        private PhieuBaoHanh _phieu;

        public string TenPhieu
        {
            get => txt_tenPhieu.Text;
            set => txt_tenPhieu.Text = value;
        }

        public long Gia
        {
            get => _phieu?.Gia ?? 0;
            set => txt_gia.Text = $"{value:N0}đ";
        }

        public int SoLuong
        {
            get => _phieu?.SoLuong ?? 0;
            set => txt_soLuong.Text = $"Còn lại: {value}";
        }

        public int ThoiHanThang
        {
            get => _phieu?.ThoiHanThang ?? 0;
            set => txt_thoiHan.Text = $"Bảo hành: {value} tháng";
        }

        public itemPhieuBaoHanh(PhieuBaoHanh phieu)
        {
            InitializeComponent();
            _phieu = phieu;

            TenPhieu = phieu.TenPhieu;
            Gia = phieu.Gia;
            SoLuong = phieu.SoLuong;
            ThoiHanThang = phieu.ThoiHanThang;
            UpdateButtonStatus();
            MakeRoundedCorners(10); // Góc bo tròn
        }

   

        private void UpdateButtonStatus()
        {
            if (_phieu.SoLuong <= 0)
                btn_dung.Enabled = false;
            else
                btn_dung.Enabled = true;
        }

        private void itemPhieuBaoHanh_Paint(object sender, PaintEventArgs e)
        {
            if (_roundedPath != null)
            {
                using (Pen borderPen = new Pen(Color.Gray, 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    borderPen.Alignment = PenAlignment.Inset;
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

        private void btn_dung_Click_1(object sender, EventArgs e)
        {
            ChonClicked?.Invoke(this, _phieu.Id);
        }
    }
}
