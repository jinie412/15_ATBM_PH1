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
    public partial class frmMain_OLS : Form
    {
        public frmMain_OLS()
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

            OLS_TaoLabel frm = new OLS_TaoLabel();
            frm.StartPosition = FormStartPosition.Manual;

            frm.TopLevel = false; // Cho phép nhúng form vào panel
            frm.FormBorderStyle = FormBorderStyle.None; // Ẩn viền
            frm.Dock = DockStyle.Fill; // Tự động lấp đầy panel

            guna2Panel3.Controls.Clear(); // Xóa control cũ nếu có
            guna2Panel3.Controls.Add(frm); // Thêm form vào panel
            frm.Show(); // Hiển thị form

            currentChildForm = frm;

        }


        private void grantUser_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close(); // Đóng form con hiện tại nếu có
            }

            OLS_GanUser frm = new OLS_GanUser();
            frm.StartPosition = FormStartPosition.Manual;
           
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
