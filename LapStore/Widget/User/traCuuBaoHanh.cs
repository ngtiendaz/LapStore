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

namespace LapStore.Widget.User
{
    public partial class traCuuBaoHanh : UserControl
    {
        public traCuuBaoHanh()
        {
            InitializeComponent();
        }

        private void btn_traCuu_Click(object sender, EventArgs e)
        {
            string ketQua = PhieuBaoHanhController.TraCuuThoiGianBaoHanh(txt_traCuu.Text);
            txt_hetHan.Text = ketQua;
        }
    }
}
