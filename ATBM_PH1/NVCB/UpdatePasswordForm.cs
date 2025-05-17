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
    public partial class UpdatePasswordForm : Form
    {
        public UpdatePasswordForm()
        {
            InitializeComponent();
        }

        public string NewPassword { get; private set; }

        public UpdatePasswordForm(string roleName)
        {
            InitializeComponent();
            //lblPrompt.Text = $"Nhập mật khẩu mới cho vai trò {roleName}:"; // lblPrompt là tên của Label
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống.");
                return;
            }

            NewPassword = textPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdatePasswordForm_Load(object sender, EventArgs e)
        {
            // Khởi tạo nếu cần
            
        }
    }
}
