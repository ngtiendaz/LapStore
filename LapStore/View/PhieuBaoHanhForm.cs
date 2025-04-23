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
using LapStore.Controller;
using LapStore.Model;
using LapStore.Widget.User;

namespace LapStore.View
{
    public partial class PhieuBaoHanhForm : Form
    {
        private GraphicsPath _roundedPath;
        private List<PhieuBaoHanh> _danhSachPBH = new List<PhieuBaoHanh>();
        public event EventHandler<PhieuBaoHanh> PhieuBaoHanhDaChon;
        public PhieuBaoHanhForm()
        {
            InitializeComponent();
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

        private void PhieuBaoHanh_Paint(object sender, PaintEventArgs e)
        {
            if (_roundedPath != null)
            {
                using (Pen borderPen = new Pen(Color.Black, 2)) // Viền đen, dày 2px
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    borderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawPath(borderPen, _roundedPath);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close(); // ✅ Chỉ đóng form hiện tại
        }
        private void LoadPhieuBaoHanh()
        {
            _danhSachPBH = PhieuBaoHanhController.GetAllPhieuBaoHanh();  // Lấy danh sách mã giảm giá từ Controller
            flowPhieuBH.Controls.Clear();  // Xóa các item cũ trước khi thêm mới
            foreach (var pbh in _danhSachPBH)
            {
                var item = new itemPhieuBaoHanh(pbh);
                item.ChonClicked += (s, pbhid) =>
                {
                    var phieuDuocChon = _danhSachPBH.FirstOrDefault(x => x.Id == pbhid);
                    if (phieuDuocChon != null)
                    {
                        PhieuBaoHanhDaChon?.Invoke(this, phieuDuocChon);
                        this.Close();
                    }
                };

                item.Margin = new Padding(0, 5, 0, 5); // 👈 Thêm dòng này để tạo khoảng cách
                flowPhieuBH.Controls.Add(item);
            }
        }

        private void PhieuBaoHanh_Load(object sender, EventArgs e)
        {
            LoadPhieuBaoHanh();
            MakeRoundedCorners(30);
        }
    }
}
