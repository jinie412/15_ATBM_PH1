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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ATBM_PH1
{
    public partial class frmMain_GV : Form
    {
        public static frmMain_GV Instance { get; private set; }
        private string username;

        public frmMain_GV(string username)
        {
            InitializeComponent();
            this.username = username;
            Instance = this;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.StartPosition = FormStartPosition.CenterScreen;
            dangNhap.Show();
            this.Close();
        }

        private void btnTTC_Click(object sender, EventArgs e)
        {
            NVCB nvcb = new NVCB();
            nvcb.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(nvcb, this);

        }

        private void btnSVK_Click(object sender, EventArgs e)
        {

            DSSV dSSV = new DSSV(username);

            dSSV.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(dSSV, this);
        
        }

        private void User_Click(object sender, EventArgs e)
        {
            GV newGV = new GV(username);
            newGV.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(newGV, this);
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            thongbao frm = new thongbao();
            frm.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(frm, this);
        }
    }
}

