using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using LapStore.Model;
using LapStore.Controller;
using System.Linq;

namespace LapStore.Widget
{
    public partial class thongKeUserControl : UserControl
    {
        public thongKeUserControl()
        {
            InitializeComponent();
            LoadThongKe();
        }

        private void LoadThongKe()
        {
            int thang = DateTime.Now.Month;

            // Fetch and handle tuple values
            (long tongDoanhThu, long tienVon, long loiNhuan,long tongGiamGia, long tongBaoHanh) = ThongKeController.LayThongKeTheoThang(thang);

            LoadDoanhThuChart(tongDoanhThu);
            LoadTopSanPhamChart();
            LoadSanPhamDaBanHet();
        }

        private void LoadSanPhamDaBanHet()
        {
            List<SanPham> sanPhams = ThongKeController.getSanPhamDaBanHet(); // Đổi sang ThongKeController
            dgvSP.Rows.Clear();

            foreach (SanPham sp in sanPhams)
            {
                // Khởi tạo ảnh từ đường dẫn (nếu có)
                Image img = null;
                if (!string.IsNullOrEmpty(sp.HinhAnh) && System.IO.File.Exists(sp.HinhAnh))
                {
                    try
                    {
                        using (var bmpTemp = new Bitmap(sp.HinhAnh))
                        {
                            img = new Bitmap(bmpTemp, new Size(80, 80));  // Resize về 80x80
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                    }
                }

                // Thêm hàng mới vào DataGridView
                int rowIndex = dgvSP.Rows.Add(
                    img,             // Hình ảnh
                    sp.MaSp,         // Mã sản phẩm
                    sp.MaDm,         // Mã danh mục
                    sp.TenSp,        // Tên sản phẩm
                    sp.MoTa,         // Mô tả
                    sp.GiaNhap,      // Giá nhập
                    sp.GiaBan,       // Giá bán
                    sp.SoLuong,      // Số lượng
                    sp.CreatedAt     // Ngày tạo
                );

                // Lưu đường dẫn vào thuộc tính Tag của ô hình ảnh
                dgvSP.Rows[rowIndex].Cells["HinhAnh"].Tag = sp.HinhAnh;
            }
        }
        private void LoadDoanhThuChart(long tongDoanhThu)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas.Clear();
            chartDoanhThu.Titles.Clear();

            // Tạo dữ liệu doanh thu theo tháng
            Dictionary<string, long> doanhThuTheoThang = new Dictionary<string, long>();

            for (int thang = 1; thang <= 12; thang++)
            {
                var thongKe = ThongKeController.LayThongKeTheoThang(thang);
                doanhThuTheoThang.Add($"Tháng {thang}", thongKe.TongDoanhThu);
            }

            // Cấu hình ChartArea
            ChartArea chartArea = new ChartArea
            {
                AxisX =
        {
            Title = "",
            TitleFont = new Font("Arial", 12, FontStyle.Bold),
            TitleForeColor = Color.White,
            LabelStyle = { ForeColor = Color.White },
            MajorGrid =
            {
                LineColor = Color.FromArgb(200, 255, 255, 255), // Vạch nền trắng nhạt
                LineDashStyle = ChartDashStyle.Dash // Kiểu gạch ngang
            }
        },
                AxisY =
        {
            Title = "Doanh thu (VND)",
            TitleFont = new Font("Arial", 12, FontStyle.Bold),
            TitleForeColor = Color.White,
            LabelStyle = { ForeColor = Color.White, Format = "N0" },
            MajorGrid =
            {
                LineColor = Color.FromArgb(200, 255, 255, 255), // Vạch nền trắng nhạt
                LineDashStyle = ChartDashStyle.Dash
            }
        },
                BackGradientStyle = GradientStyle.TopBottom,
                BackColor = Color.FromArgb(30, 30, 60),
                BackSecondaryColor = Color.FromArgb(50, 50, 100),
                Area3DStyle =
        {
            Enable3D = false // Tắt 3D để làm phẳng biểu đồ
        }
            };
            chartDoanhThu.ChartAreas.Add(chartArea);

            // Tạo Series cho biểu đồ dạng spline area
            Series series = new Series("Doanh thu theo tháng")
            {
                ChartType = SeriesChartType.SplineArea,
                Color = Color.FromArgb(128, 135, 206),
                BackGradientStyle = GradientStyle.LeftRight,
                BackSecondaryColor = Color.FromArgb(255, 99, 132),
                BorderWidth = 2,
                IsValueShownAsLabel = false,
                Font = new Font("Arial", 10, FontStyle.Bold),
                LabelForeColor = Color.White,
                MarkerStyle = MarkerStyle.None
            };

            foreach (var item in doanhThuTheoThang)
            {
                series.Points.AddXY(item.Key, item.Value);
            }
            chartDoanhThu.Series.Add(series);

            // Thêm tiêu đề
            Title title = new Title("Doanh thu theo tháng")
            {
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.White,
                ShadowColor = Color.Black,
                ShadowOffset = 2,
                Alignment = ContentAlignment.TopCenter
            };
            chartDoanhThu.Titles.Add(title);

            // Thêm chú thích
            Legend legend = new Legend
            {
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Docking = Docking.Top
            };
            chartDoanhThu.Legends.Add(legend);
        }
        private void LoadTopSanPhamChart()
        {
            chartTopSanPham.Series.Clear();
            chartTopSanPham.ChartAreas.Clear();
            chartTopSanPham.Titles.Clear();
            chartTopSanPham.Legends.Clear();

            // Đặt màu nền bên ngoài của biểu đồ
            chartTopSanPham.BackColor = Color.FromArgb(24, 28, 63);

            // Lấy dữ liệu top 5 sản phẩm từ ThongKeController
            List<(string TenSp, int TongBan)> topProducts = ThongKeController.GetTop5SanPham();

            // Cấu hình ChartArea với hiệu ứng 3D
            ChartArea chartArea = new ChartArea
            {
                BackColor = Color.FromArgb(30, 30, 60),
                BackSecondaryColor = Color.FromArgb(50, 50, 100),
                BackGradientStyle = GradientStyle.TopBottom,
                InnerPlotPosition = new ElementPosition(10, 10, 80, 80),
                Position = new ElementPosition(0, 0, 100, 100),
                Area3DStyle =
        {
            Enable3D = true,
            Inclination = 45,
            Rotation = 30
        }
            };

            chartTopSanPham.ChartAreas.Add(chartArea);

            // Cấu hình Series
            Series series = new Series("Top 5 sản phẩm")
            {
                ChartType = SeriesChartType.Doughnut,
                BorderWidth = 2,
                BorderColor = Color.Black,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            // Hiển thị nhãn bên trong các phần của biểu đồ
            series["PieLabelStyle"] = "Inside";
            series["DoughnutRadius"] = "60";
            series["CollectedLabel"] = "Khác";

            // Cấu hình Legend
            Legend legend = new Legend
            {
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Arial", 7, FontStyle.Regular),
                Docking = Docking.Bottom,
                LegendStyle = LegendStyle.Column,
                TableStyle = LegendTableStyle.Wide
            };
            chartTopSanPham.Legends.Add(legend);

            // Danh sách màu sắc cho từng phần của biểu đồ
            Color[] colors = { Color.MediumPurple, Color.CornflowerBlue, Color.Orchid, Color.Salmon, Color.Gold };

            // Tổng số lượng để tính phần trăm
            int total = topProducts.Sum(p => p.TongBan);
            int index = 0;

            foreach (var product in topProducts)
            {
                string truncatedName = product.TenSp.Length > 40 ? product.TenSp.Substring(0, 20) + "..." : product.TenSp;
                DataPoint point = new DataPoint
                {
                    Label = $"{(product.TongBan / (double)total * 100):F1}%",
                    LegendText = truncatedName,
                    Color = colors[index % colors.Length],
                    LabelForeColor = Color.White
                };

                point.SetValueXY(product.TenSp, product.TongBan);
                series.Points.Add(point);
                index++;
            }

            chartTopSanPham.Series.Add(series);

            // Thêm tiêu đề
            Title title = new Title
            {
                Text = "Sản phẩm bán chạy nhất",
                Docking = Docking.Top,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Position = new ElementPosition(10, 2, 80, 10)
            };

            chartTopSanPham.Titles.Add(title);

            
        }

        private void thongKeUserControl_Paint(object sender, PaintEventArgs e)
        {
            // Lấy kích thước của control
            Rectangle rect = this.ClientRectangle;

            // Tạo brush gradient từ xanh đen (#2C3E50) sang xanh lục nhạt (#4CA1AF)
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                rect,
                ColorTranslator.FromHtml("#000000"),
                ColorTranslator.FromHtml("#434343"),   // Màu 2
                45f))                                  // Góc gradient (90 độ)
            {
                // Vẽ nền với gradient
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void btn_xuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Top 5 sản phẩm bán chạy nhất 2025";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                XuatExcelController.XuatExcelTop5SanPham(filePath);
            }
        }
    }
}