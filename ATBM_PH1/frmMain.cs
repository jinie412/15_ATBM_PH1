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
            MainClass.BlurBackground(phanQuyen, this);
        }

        private void User_Click(object sender, EventArgs e)
        {
            ViewUser newForm = new ViewUser();
            newForm.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(newForm, this);

        }

        private void Role_Click(object sender, EventArgs e)
        {
            Role role = new Role();
            role.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(role, this);
        }

        private void Btn_audit_Click(object sender, EventArgs e)
        {
            audit_.Audit auditForm = new audit_.Audit();
            auditForm.StartPosition = FormStartPosition.CenterScreen;
            MainClass.BlurBackground(auditForm, this);
        }
    }
}
