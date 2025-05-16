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
    public partial class trgdv_dsnv : Form
    {
        public trgdv_dsnv()
        {
            InitializeComponent();
        }

        private void trgdv_dsnv_Load(object sender, EventArgs e)
        {
            trgdv_nv.Visible = false;
            trgdv_pc.Visible = false;
        }

        private void btnDSNV_Click(object sender, EventArgs e)
        {
            trgdv_nv.Visible = true;
            trgdv_pc.Visible = false;
            Load_DSNV();


        }

        private void btnDSPC_Click(object sender, EventArgs e)
        {
            trgdv_nv.Visible = false;
            trgdv_pc.Visible = true;
            Load_DSPC();

        }

        private void Load_DSNV()
        {
            if (MainClass.conn.State == ConnectionState.Closed)
            {
                MainClass.conn.Open();
            }

            OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_TRGDV_XEMDSNV", MainClass.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            trgdv_nv.DataSource = dt;

        }

        private void Load_DSPC()
        {
            if (MainClass.conn.State == ConnectionState.Closed)
            {
                MainClass.conn.Open();
            }

            OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_TRGDV_XEMDSPC", MainClass.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            trgdv_pc.DataSource = dt;

        }

    }
}