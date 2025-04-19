using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Controller;
using LapStore.Model;
using LapStore.View;

namespace LapStore.Widget.User
{
    public partial class yeuThich : UserControl
    {
        public yeuThich()
        {
            InitializeComponent();
        }
        private void LoadSanPhamYeuThich()
        {
            // Lấy user hiện tại
            var currentUser = UserController.CurrentUser;
            if (currentUser == null) return;

            List<SanPham> dsSanPham = YeuThichVaLuotXemController.GetSanPhamYeuThichByUser(currentUser.Id);
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

        private void yeuThich_Load(object sender, EventArgs e)
        {
            scroll.AutoScroll = true;
            flowSP.WrapContents = true;
            flowSP.FlowDirection = FlowDirection.LeftToRight;
            LoadSanPhamYeuThich(); // Mặc định ngẫu nhiên
        }
    }
}
