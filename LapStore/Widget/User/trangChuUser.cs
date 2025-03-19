using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Model;

namespace LapStore.Widget
{
    public partial class trangChuUser : UserControl
    {
        private List<string> imagePaths;
        private int currentIndex = 0;
        public trangChuUser()
        {
            InitializeComponent();
            timer1.Start();
            InitializeSlider();

           
        }
        private void InitializeSlider()
        {
            // Lấy tất cả các tệp ảnh từ thư mục D:\Images
            string folderPath = @"D:\DataC#\slide";
            imagePaths = new List<string>(Directory.GetFiles(folderPath, "*.jpg"));

             //Hoặc lấy nhiều định dạng ảnh
             imagePaths = new List<string>(Directory.GetFiles(folderPath, "*.jpg").Concat(Directory.GetFiles(folderPath, "*.png")));

            if (imagePaths.Count > 0)
            {
                imageSlide.Image = Image.FromFile(imagePaths[currentIndex]);
            }

            // Khởi động Timer
            
        }
        private void NextSlide()
        {
            currentIndex = (currentIndex + 1) % imagePaths.Count;
            imageSlide.Image = Image.FromFile(imagePaths[currentIndex]);
        }

        //private void PreviousSlide()
        //{
        //    currentIndex = (currentIndex - 1 + imagePaths.Count) % imagePaths.Count;
        //    imageSlide.Image = Image.FromFile(imagePaths[currentIndex]);
        //}



        private void LoadDanhSachSanPham(string maDm)
        {
            List<SanPham> dsSanPham = SanPhamController.getSanPhamByMaDm(maDm);
            flowSP.Controls.Clear();

            int itemWidth = flowSP.Width / 4 - 20; // 4 cột và trừ đi khoảng cách
            foreach (var sp in dsSanPham)
            {
                itemSanPham item = new itemSanPham
                {
                    MaSp = sp.MaSp,
                    TenSp = sp.TenSp,
                    GiaBan = sp.GiaBan,
                    GiaNhap = sp.GiaBan,
                    HinhAnh = sp.HinhAnh,
                    Width = itemWidth,
                    Height = 380 // Đặt chiều cao phù hợp
                };

                flowSP.Controls.Add(item);
            }
        }



        private void trangChuUser_Load(object sender, EventArgs e)
        {
         
            // Đặt lại AutoScroll khi load trang
    
            scroll.AutoScroll = true;

            // Đảm bảo FlowLayoutPanel vẫn đúng thuộc tính
            flowSP.WrapContents = true;
            flowSP.FlowDirection = FlowDirection.LeftToRight;
           


            LoadDanhSachSanPham("DM001");
        }


      

        private void flowSP_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control control in flowSP.Controls)
            {
                control.Width = flowSP.Width / 4 - 20; // Cập nhật lại width khi thay đổi kích thước
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextSlide();
        }
    }
}
