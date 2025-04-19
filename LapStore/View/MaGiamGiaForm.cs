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
    public partial class MaGiamGiaForm : Form
    {
        private List<MaGiamGia> _danhSachMGG = new List<MaGiamGia>();
        public event EventHandler<MaGiamGia> MaGiamGiaDaChon;
        public MaGiamGiaForm()
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
        }
        private void LoadMaGiamGia()
        {
            _danhSachMGG = MaGiamGiaController.GetAllMaGiamGia();
            listMaGiamGia.Controls.Clear();

            foreach (var mgg in _danhSachMGG)
            {
                var item = new itemMaGiamGia(mgg);
                item.DungNgayClicked += (s, mggId) =>
                {
                    // Khi click "Dùng ngay", tìm mã từ ID
                    var maDuocChon = _danhSachMGG.FirstOrDefault(x => x.Id == mggId);
                    if (maDuocChon != null)
                    {
                        MaGiamGiaDaChon?.Invoke(this, maDuocChon); // 🔁 Truyền mã về form gọi
                        this.Close(); // Đóng form chọn mã
                    }
                };
                listMaGiamGia.Controls.Add(item);
            }
        }

        private void MaGiamGiaForm_Load(object sender, EventArgs e)
        {
            LoadMaGiamGia();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close(); // ✅ Chỉ đóng form hiện tại
        }
    }
}
