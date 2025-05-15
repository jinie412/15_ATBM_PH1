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

        private void studentinfo_Click(object sender, EventArgs e)
        {
            // Hiện form tại vị trí mong muốn
            ThongTinChung frm = new ThongTinChung();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(this.Left + 197, this.Top +37); // Tọa độ tùy chỉnh
            frm.Show();
        }


        private void subjectlist_Click(object sender, EventArgs e)
        {
            DanhSachMoMon frm = new DanhSachMoMon();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(this.Left + 197, this.Top + 37); // Tọa độ tùy chỉnh
            frm.Show();
        }

    }
}
