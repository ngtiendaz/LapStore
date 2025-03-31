using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Forms;

namespace LapStore.View
{
    public partial class QuangCao : Form
    {
        private SoundPlayer player;

        public QuangCao()
        {
            InitializeComponent();
        }

        private void QuangCao_Load(object sender, EventArgs e)
        {
            MakeRoundedCorners(30);
            PlaySound(@"D:\DataC#\image\videoplayback.wav"); // Thay đường dẫn file nhạc ở đây
        }

        public void PlaySound(string filePath)
        {
            try
            {
                player = new SoundPlayer(filePath);
                player.Play(); // Phát nhạc không chặn luồng chính
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phát nhạc: " + ex.Message);
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
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            if (player != null)
            {
                player.Stop(); // Dừng nhạc khi thoát
            }
            this.Close(); // Đóng form
        }
    }
}
