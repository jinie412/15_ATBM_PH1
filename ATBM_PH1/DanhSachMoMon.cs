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
    public partial class DanhSachMoMon : Form
    {
        public DanhSachMoMon()
        {
            InitializeComponent();
            DanhSachMoMonLoad();

        }

        void DanhSachMoMonLoad()
        {
            // Truy vấn dữ liệu từ view
            OracleCommand cmd = new OracleCommand("SELECT * FROM pdb_admin.V_MOMON_SINHVIEN", MainClass.conn);
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Thêm cột STT sinh tự động
            dt.Columns.Add("STT", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }

            // Map thủ công cột
            dgvlistsubject.Columns.Clear();
            dgvlistsubject.Visible = true;
            dgvlistsubject.AutoGenerateColumns = false;

            // Cột STT
            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.HeaderText = "STT";
            colSTT.DataPropertyName = "STT";
            colSTT.Width = 30;
            dgvlistsubject.Columns.Add(colSTT);

            // Cột MAMM
            DataGridViewTextBoxColumn colMAMM = new DataGridViewTextBoxColumn();
            colMAMM.HeaderText = "Mã MM";
            colMAMM.DataPropertyName = "MAMM";
            colMAMM.Width = 50;
            dgvlistsubject.Columns.Add(colMAMM);

            // Cột MAHP
            DataGridViewTextBoxColumn colMAHP = new DataGridViewTextBoxColumn();
            colMAHP.HeaderText = "Mã HP";
            colMAHP.DataPropertyName = "MAHP";
            colMAHP.Width = 50;
            dgvlistsubject.Columns.Add(colMAHP);

            // Cột TENHP
            DataGridViewTextBoxColumn colTENHP = new DataGridViewTextBoxColumn();
            colTENHP.HeaderText = "Tên HP";
            colTENHP.DataPropertyName = "TENHP";
            colTENHP.Width = 200;
            dgvlistsubject.Columns.Add(colTENHP);

            // Cột MAGV
            DataGridViewTextBoxColumn colMAGV = new DataGridViewTextBoxColumn();
            colMAGV.HeaderText = "Mã GV";
            colMAGV.DataPropertyName = "MAGV";
            colMAGV.Width = 50;
            dgvlistsubject.Columns.Add(colMAGV);

            // Cột HK
            DataGridViewTextBoxColumn colHK = new DataGridViewTextBoxColumn();
            colHK.HeaderText = "HK";
            colHK.DataPropertyName = "HK";
            colHK.Width = 20;
            dgvlistsubject.Columns.Add(colHK);

            // Cột NAM
            DataGridViewTextBoxColumn colNAM = new DataGridViewTextBoxColumn();
            colNAM.HeaderText = "Năm";
            colNAM.DataPropertyName = "NAM";
            colNAM.Width = 30;
            dgvlistsubject.Columns.Add(colNAM);

            // Gán nguồn dữ liệu
            dgvlistsubject.DataSource = dt;
        }
    }
}
