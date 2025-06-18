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

namespace ATBM_PH1.PH1
{
    public partial class frm_dtdl : Form
    {
        public frm_dtdl()
        {
            InitializeComponent();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                string sql = "SELECT OWNER, TABLE_NAME, STATUS FROM ALL_TABLES WHERE OWNER = 'PDB_ADMIN'";
                OracleCommand cmd = new OracleCommand(sql, MainClass.conn);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvDL.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu bảng:\n" + ex.Message);
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                string sql = "SELECT OWNER,VIEW_NAME,TEXT_LENGTH,TEXT FROM all_views WHERE owner = 'PDB_ADMIN'";
                OracleCommand cmd = new OracleCommand(sql, MainClass.conn);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvDL.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu view:\n" + ex.Message);
            }
        }
    }
}
