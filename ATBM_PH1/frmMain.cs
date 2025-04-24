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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

		private void btnPhanQuyen_Click(object sender, EventArgs e)
		{
			CapQuyen_CSDL main = new CapQuyen_CSDL();
			main.Show();
			this.Hide();
		}

        private void User_Click(object sender, EventArgs e)
        {
            ViewUser newForm = new ViewUser();
            this.Hide();
            newForm.Show();

        }
    }
}
