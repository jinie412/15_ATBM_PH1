using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class frmMain_PDT : Form
    {
        public static frmMain_PDT Instance { get; private set; }

        public frmMain_PDT()
        {
            InitializeComponent();
            Instance = this;
            //if (MainClass.Role == "PDT")
            //{
            //    panel_PDT pdtControl = new panel_PDT(); // tạo instance
            //    pdtControl.Dock = DockStyle.Fill;       // cho vừa khít menuPanel (tùy bạn)

            //    menuPanel.Controls.Clear();             // xoá các control cũ nếu có
            //    menuPanel.Controls.Add(pdtControl);     // thêm UserControl vào panel
            //}
        }

   

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

		

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.StartPosition = FormStartPosition.CenterScreen;
            dangNhap.Show();
            this.Close();
        }

        private void Momon_Click(object sender, EventArgs e)
        {
            PDT_momon frm = new PDT_momon();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            this.Close();
        }

        private void btnDKHP_Click(object sender, EventArgs e)
        {
            PDT_Dangky frm = new PDT_Dangky();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            this.Close();
        }
    }
}
