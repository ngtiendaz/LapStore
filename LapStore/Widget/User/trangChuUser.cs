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
using LapStore.View;

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
            string folderPath = @"D:\DataC#\slide";
            imagePaths = new List<string>(Directory.GetFiles(folderPath, "*.jpg"));
             imagePaths = new List<string>(Directory.GetFiles(folderPath, "*.jpg").Concat(Directory.GetFiles(folderPath, "*.png")));

            if (imagePaths.Count > 0)
            {
                imageSlide.Image = Image.FromFile(imagePaths[currentIndex]);
            }        
        }
        private void NextSlide()
        {
            currentIndex = (currentIndex + 1) % imagePaths.Count;
            imageSlide.Image = Image.FromFile(imagePaths[currentIndex]);
        }

        private void LoadDanhSachSanPham()
        {
            List<SanPham> dsSanPham = SanPhamController.GetSanPham();
            flowSP.Controls.Clear();

            int itemWidth = flowSP.Width / 4 - 20;
            foreach (var sp in dsSanPham)
            {
                itemSanPham item = new itemSanPham(sp)
                {
                    Width = itemWidth,
                    Height = 380
                };

                item.OnSanPhamClick += ItemSanPham_Click;
                flowSP.Controls.Add(item);
            }
        }
        private void ItemSanPham_Click(SanPham sp)
        {
            userHome userForm = this.FindForm() as userHome;
            if (userForm != null)
            {
                userForm.ShowDetailSanPham(sp);
            }
        }

        private void trangChuUser_Load(object sender, EventArgs e)
        {
            scroll.AutoScroll = true;
            flowSP.WrapContents = true;
            flowSP.FlowDirection = FlowDirection.LeftToRight;
            LoadDanhSachSanPham();
        }

        private void flowSP_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control control in flowSP.Controls)
            {
                control.Width = flowSP.Width / 4 - 20;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextSlide();
        }
    }
}
