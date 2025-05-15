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
            cbHocKi.SelectedIndexChanged += FilterData;
            cbNam.SelectedIndexChanged += FilterData;
        }

        private DataTable originalData;
        private void LoadComboBoxData()
        {
            if (originalData == null) return;

            // --- ComboBox Học kỳ ---
            // Lấy distinct HK
            DataTable hkTable = originalData.DefaultView.ToTable(true, "HK");
            // Tạo dòng "Tất cả"
            DataRow dr = hkTable.NewRow();
            dr["HK"] = DBNull.Value;
            hkTable.Rows.InsertAt(dr, 0);

            cbHocKi.DataSource = hkTable;
            cbHocKi.DisplayMember = "HK";
            cbHocKi.ValueMember = "HK";
            cbHocKi.SelectedIndex = 0;

            // Bắt sự kiện Format để hiển thị chữ "Tất cả"
            cbHocKi.Format += (s, e) =>
            {
                if (e.Value == DBNull.Value || e.Value == null)
                    e.Value = "Tất cả";
            };

            // --- ComboBox Năm ---
            DataTable namTable = originalData.DefaultView.ToTable(true, "NAM");
            DataRow dr2 = namTable.NewRow();
            dr2["NAM"] = DBNull.Value;
            namTable.Rows.InsertAt(dr2, 0);

            cbNam.DataSource = namTable;
            cbNam.DisplayMember = "NAM";
            cbNam.ValueMember = "NAM";
            cbNam.SelectedIndex = 0;

            cbNam.Format += (s, e) =>
            {
                if (e.Value == DBNull.Value || e.Value == null)
                    e.Value = "Tất cả";
            };
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
            dgvlistsubject.AutoGenerateColumns = false;

            // Cột STT
            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.HeaderText = "STT";
            colSTT.DataPropertyName = "STT";
            colSTT.Width = 50;
            dgvlistsubject.Columns.Add(colSTT);

            // Cột MAMM
            DataGridViewTextBoxColumn colMAMM = new DataGridViewTextBoxColumn();
            colMAMM.HeaderText = "Mã MM";
            colMAMM.DataPropertyName = "MAMM";
            colMAMM.Width = 90;
            dgvlistsubject.Columns.Add(colMAMM);

            // Cột MAHP
            DataGridViewTextBoxColumn colMAHP = new DataGridViewTextBoxColumn();
            colMAHP.HeaderText = "Mã HP";
            colMAHP.DataPropertyName = "MAHP";
            colMAHP.Width = 90;
            dgvlistsubject.Columns.Add(colMAHP);

            // Cột TENHP
            DataGridViewTextBoxColumn colTENHP = new DataGridViewTextBoxColumn();
            colTENHP.HeaderText = "Tên HP";
            colTENHP.DataPropertyName = "TENHP";
            colTENHP.Width = 212;
            dgvlistsubject.Columns.Add(colTENHP);

            // Cột MAGV
            DataGridViewTextBoxColumn colMAGV = new DataGridViewTextBoxColumn();
            colMAGV.HeaderText = "Mã GV";
            colMAGV.DataPropertyName = "MAGV";
            colMAGV.Width = 90;
            dgvlistsubject.Columns.Add(colMAGV);

            // Cột HK
            DataGridViewTextBoxColumn colHK = new DataGridViewTextBoxColumn();
            colHK.HeaderText = "HK";
            colHK.DataPropertyName = "HK";
            colHK.Width = 50;
            dgvlistsubject.Columns.Add(colHK);

            // Cột NAM
            DataGridViewTextBoxColumn colNAM = new DataGridViewTextBoxColumn();
            colNAM.HeaderText = "Năm";
            colNAM.DataPropertyName = "NAM";
            colNAM.Width = 60;
            dgvlistsubject.Columns.Add(colNAM);

            // Gán nguồn dữ liệu
            dgvlistsubject.DataSource = dt;
            originalData = dt;
            LoadComboBoxData();

        }
        private void FilterData(object sender, EventArgs e)
        {
            if (originalData == null) return;

            string filter = "";

            // Lấy giá trị chọn của Học kỳ
            object selectedHK = cbHocKi.SelectedValue;
            if (selectedHK != null && selectedHK != DBNull.Value)
            {
                if (short.TryParse(selectedHK.ToString(), out short hk))
                {
                    filter += $"HK = {hk}";
                }
            }

            // Lấy giá trị chọn của Năm
            object selectedNam = cbNam.SelectedValue;
            if (selectedNam != null && selectedNam != DBNull.Value)
            {
                if (filter != "") filter += " AND ";

                if (short.TryParse(selectedNam.ToString(), out short nam))
                {
                    filter += $"NAM = {nam}";
                }
            }

            DataView dv = originalData.DefaultView;
            dv.RowFilter = filter;

            DataTable filteredTable = dv.ToTable();

            // Cập nhật lại cột STT (nếu có)
            if (!filteredTable.Columns.Contains("STT"))
                filteredTable.Columns.Add("STT", typeof(int));

            for (int i = 0; i < filteredTable.Rows.Count; i++)
            {
                filteredTable.Rows[i]["STT"] = i + 1;
            }

            dgvlistsubject.DataSource = filteredTable;
        }

    }
}
