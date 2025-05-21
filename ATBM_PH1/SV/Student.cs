using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }
        Form currentChildForm = null;

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void studentinfo_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close(); // Đóng form con hiện tại nếu có
            }

            ThongTinChung frm = new ThongTinChung();
            frm.StartPosition = FormStartPosition.Manual;
            // frm.Location = new Point(this.Left + 197, this.Top + 37);
         
            //currentChildForm = frm; // Gán form hiện tại vào biến

            //frm.Show();
            //MainClass.BlurBackground(frm, this);

            frm.TopLevel = false; // Cho phép nhúng form vào panel
            frm.FormBorderStyle = FormBorderStyle.None; // Ẩn viền
            frm.Dock = DockStyle.Fill; // Tự động lấp đầy panel

            guna2Panel3.Controls.Clear(); // Xóa control cũ nếu có
            guna2Panel3.Controls.Add(frm); // Thêm form vào panel
            frm.Show(); // Hiển thị form

            currentChildForm = frm;

        }


        private void subjectlist_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close(); // Đóng form con hiện tại nếu có
            }

            DanhSachMoMon frm = new DanhSachMoMon();
            frm.StartPosition = FormStartPosition.Manual;
            //frm.Location = new Point(this.Left + 197, this.Top + 37);

            //currentChildForm = frm;

            //frm.Show();
            //MainClass.BlurBackground(frm, this);
            frm.TopLevel = false; // Cho phép nhúng form vào panel
            frm.FormBorderStyle = FormBorderStyle.None; // Ẩn viền
            frm.Dock = DockStyle.Fill; // Tự động lấp đầy panel

            guna2Panel3.Controls.Clear(); // Xóa control cũ nếu có
            guna2Panel3.Controls.Add(frm); // Thêm form vào panel
            frm.Show(); // Hiển thị form

            currentChildForm = frm;
        }

        private void registersubject_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close(); // Đóng form con hiện tại nếu có
            }

            DangKyHP frm = new DangKyHP();
            frm.StartPosition = FormStartPosition.Manual;
            //frm.Location = new Point(this.Left + 197, this.Top + 37);

            //currentChildForm = frm;

            //frm.Show();
            // MainClass.BlurBackground(frm, this);

            frm.TopLevel = false; // Cho phép nhúng form vào panel
            frm.FormBorderStyle = FormBorderStyle.None; // Ẩn viền
            frm.Dock = DockStyle.Fill; // Tự động lấp đầy panel

            guna2Panel3.Controls.Clear(); // Xóa control cũ nếu có
            guna2Panel3.Controls.Add(frm); // Thêm form vào panel
            frm.Show(); // Hiển thị form

            currentChildForm = frm;
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.StartPosition = FormStartPosition.CenterScreen;
            dangNhap.Show();
            this.Close();
        }
    }
}
