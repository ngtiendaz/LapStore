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

namespace LapStore.Widget.Admin
{
    public partial class danhMucAdmin : UserControl
    {
        private bool isThem = false;
        public danhMucAdmin()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            txt_maDm.Clear();
            txt_tenDm.Clear();
        }
        public void LoadDanhMuc()
        {
            List<DanhMuc> danhMucs = DanhMucController.GetAllDanhMuc();
            dgvDm.Rows.Clear();

            foreach (DanhMuc dm in danhMucs)
            {
                dgvDm.Rows.Add(dm.Id, dm.TenDanhMuc);
            }
        }

        private void danhMucAdmin_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            dgvDm.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void danhMucAdmin_Paint(object sender, PaintEventArgs e)
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

        private void btn_themMoi_Click(object sender, EventArgs e)
        {
            isThem = !isThem;

            if (isThem)
            {
                btn_luu.Enabled = true;
                btn_themMoi.Text = "Hủy";
                ClearForm();
                txt_maDm.Text = DanhMucController.GenerateNewMaDanhMuc();
            }
            else
            {
                btn_luu.Enabled = false;
                btn_themMoi.Text = "Thêm Mới";
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            // Kiểm tra ô trống
            if (string.IsNullOrWhiteSpace(txt_maDm.Text) ||
                string.IsNullOrWhiteSpace(txt_tenDm.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã và tên danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã danh mục đã tồn tại chưa
            if (!Database.KiemTraMaDanhMuc(txt_maDm.Text))
            {
                return;
            }

            var danhMuc = new DanhMuc
            {
                Id = txt_maDm.Text,
                TenDanhMuc = txt_tenDm.Text
            };

            // Thêm danh mục vào database
            DanhMucController.AddDanhMuc(danhMuc);

            MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Làm mới form hoặc load lại dữ liệu
            ClearForm();
            btn_luu.Enabled = false;
            LoadDanhMuc();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã danh mục và tên danh mục không được để trống
            if (string.IsNullOrWhiteSpace(txt_maDm.Text) ||
                string.IsNullOrWhiteSpace(txt_tenDm.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var danhMuc = new DanhMuc
            {
                Id = txt_maDm.Text.Trim(),
                TenDanhMuc = txt_tenDm.Text.Trim()
            };

            try
            {
                DanhMucController.UpdateDanhMuc(danhMuc); // Hàm cập nhật danh mục
                LoadDanhMuc(); // Load lại danh sách danh mục
                MessageBox.Show("Cập nhật danh mục thành công!");
                ClearForm(); // Xóa nội dung form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật danh mục thất bại! Lỗi: " + ex.Message);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Lấy mã danh mục từ TextBox
            string maDanhMuc = txt_maDm.Text;

            // Kiểm tra mã danh mục có rỗng không
            if (string.IsNullOrWhiteSpace(maDanhMuc))
            {
                MessageBox.Show("Vui lòng chọn mã danh mục để xóa!");
                txt_maDm.Focus();
                return;
            }

            // Xác nhận trước khi xóa
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?",
                                         "Xác nhận xóa",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Gọi hàm xóa danh mục
                    DanhMucController.DeleteDanhMuc(maDanhMuc);

                    // Tải lại dữ liệu sau khi xóa
                    LoadDanhMuc(); // hàm load lại danh mục lên DataGridView
                    MessageBox.Show("Xóa danh mục thành công!");
                    ClearForm(); // xóa nội dung form sau khi xóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa danh mục thất bại! Lỗi: " + ex.Message);
                }
            }
        }


        private void dgvDm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDm.Rows[e.RowIndex];

                // Gán dữ liệu từ dòng được chọn vào các textbox
                txt_maDm.Text = row.Cells["id"].Value?.ToString().Trim();
                txt_tenDm.Text = row.Cells["tenDanhMuc"].Value?.ToString().Trim();
            }
        }
    }
}
