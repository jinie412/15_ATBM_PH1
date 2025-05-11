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
    public partial class frmMain : Form
    {
        public static frmMain Instance { get; private set; }

        public frmMain()
        {
            InitializeComponent();
            Instance = this;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

		private void btnPhanQuyen_Click(object sender, EventArgs e)
		{
			PhanQuyen phanQuyen = new PhanQuyen();
			phanQuyen.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(phanQuyen);
        }

        private void User_Click(object sender, EventArgs e)
        {
            ViewUser newForm = new ViewUser();
            newForm.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(newForm);

        }

        private void Role_Click(object sender, EventArgs e)
        {
            Role role = new Role();
            role.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(role);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.StartPosition = FormStartPosition.CenterScreen;
            dangNhap.Show();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NVCB nvcb = new NVCB();
            nvcb.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(nvcb);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            NV_TCHC tchc = new NV_TCHC();
            tchc.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(tchc);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            NV_CTSV ctsv = new NV_CTSV();
            ctsv.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(ctsv);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            NV_PKT pkt = new NV_PKT();
            pkt.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(pkt);
        }
    }
}
