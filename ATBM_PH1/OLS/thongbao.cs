using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
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
    public partial class thongbao : Form
    {
        public thongbao()
        {
            InitializeComponent();
        }

       

        private void Load_TB()
        {
            if (MainClass.conn.State == ConnectionState.Closed)
            {
                MainClass.conn.Open();
            }

            OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_XEMTHONGBAO", MainClass.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ols_tb.DataSource = dt;

            if (!ols_tb.Columns.Contains("STT"))
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    ReadOnly = true,
                    Width = 50
                };
                ols_tb.Columns.Insert(0, sttColumn);
            }

            // Sau khi gán xong, cập nhật STT
            int stt = 1;
            foreach (DataGridViewRow row in ols_tb.Rows)
            {
                if (row.IsNewRow) continue;
                row.Cells["STT"].Value = stt++;
            }

        }

        private void thongbao_Load(object sender, EventArgs e)
        {
            Load_TB();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MainClass.CurrentUser.Username.ToLower().StartsWith("u"))
            {
                Application.Exit();
            }
            
        }

    }
}