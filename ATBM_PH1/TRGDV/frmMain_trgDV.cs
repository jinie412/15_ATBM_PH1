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
    public partial class frmMain_trgDV : Form
    {
        public static frmMain_trgDV Instance { get; private set; }


        public frmMain_trgDV()
        {
            InitializeComponent();
            Instance = this; 
        }

        private void Staff_Click(object sender, EventArgs e)
        {
            trgdv_dsnv frm = new trgdv_dsnv();
            frm.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(frm, this);
        }

        private void btnTTC_Click(object sender, EventArgs e)
        {
            NVCB nvcb = new NVCB();
            nvcb.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(nvcb, this);
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.StartPosition = FormStartPosition.CenterScreen;
            dangNhap.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
