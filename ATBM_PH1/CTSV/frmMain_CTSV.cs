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
    public partial class frmMain_CTSV : Form
    {
        public static frmMain_CTSV Instance { get; private set; }

        public frmMain_CTSV()
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

        private void btnTTSV_Click(object sender, EventArgs e)
        {
            
            NV_CTSV ctsv = new NV_CTSV();
            ctsv.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(ctsv, this);
        
        }
    }
}
