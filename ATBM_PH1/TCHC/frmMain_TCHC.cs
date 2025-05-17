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
    public partial class frmMain_TCHC : Form
    {
        public static frmMain_TCHC Instance { get; private set; }

        public frmMain_TCHC()
        {
            InitializeComponent();
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

        private void btnTTNV_Click(object sender, EventArgs e)
        {
            NV_TCHC tchc = new NV_TCHC();
            tchc.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(tchc, this);
        }
    }
}
