using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LapStore.Controller;
using LapStore.Model;

namespace LapStore.Widget.User
{
    public partial class showRoom : UserControl
    {
        int count=0;
        public showRoom()
        {
            InitializeComponent();
        }
        public void LoadShowRoom()
        {
            List<ShowRoom> dsShowroom = ShowRoomController.GetAllShowRoom();
            dgvShowRoom.Rows.Clear();

            foreach (ShowRoom sr in dsShowroom)
            {
                dgvShowRoom.Rows.Add(
                   sr.Id,
                   sr.TenCuaHang,
                   sr.Email,
                   sr.SoDienThoai,
                   sr.DiaChi,
                   sr.GioMoCua,
                   sr.GioDongCua
                );
            }
        }

        private void txt_timKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txt_timKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadShowRoom(); // Nếu không nhập gì thì load toàn bộ showroom
                return;
            }

            List<ShowRoom> ketQua = ShowRoomController.TimKiemShowRoom(tuKhoa);
            dgvShowRoom.Rows.Clear();

            foreach (ShowRoom sr in ketQua)
            {
                dgvShowRoom.Rows.Add(
                   sr.Id,
                   sr.TenCuaHang,
                   sr.DiaChi,
                   sr.SoDienThoai,
                   sr.Email,
                   sr.GioMoCua,
                   sr.GioDongCua
                );
                count++;
                
            }
        }

        private void showRoom_Load(object sender, EventArgs e)
        {
            dgvShowRoom.DefaultCellStyle.ForeColor = Color.Black;
            LoadShowRoom();
        }
    }
}
