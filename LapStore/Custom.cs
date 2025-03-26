using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LapStore
{
    internal static class Custom
    {
        public static void MakeRoundedPanel(Panel panel, int radius)
        {
            panel.Paint += (sender, e) =>
            {
                Panel pnl = sender as Panel;
                Rectangle rect = pnl.ClientRectangle;
                GraphicsPath path = GetRoundedRectanglePath(rect, radius);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.White, 2)) // Viền đen 2px
                {
                    e.Graphics.DrawPath(pen, path);
                }
                using (SolidBrush brush = new SolidBrush(pnl.BackColor)) // Giữ nguyên màu nền
                {
                    e.Graphics.FillPath(brush, path);
                }
            };
        }

        private static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);

            path.CloseFigure();
            return path;
        }
        public static void ApplyShadow(PictureBox picBox)
        {
            picBox.Paint += (sender, e) =>
            {
                PictureBox pb = sender as PictureBox;
                Rectangle rect = pb.ClientRectangle;

                // Kích thước và màu của bóng
                int shadowSize = 8;
                Color shadowColor = Color.FromArgb(80, 0, 0, 0); // Độ trong suốt 80/255

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddRectangle(rect);
                    using (PathGradientBrush brush = new PathGradientBrush(path))
                    {
                        brush.CenterColor = shadowColor;
                        brush.SurroundColors = new Color[] { Color.Gray };
                        e.Graphics.FillRectangle(brush, rect);
                    }
                }
            };
        }
    }
}
