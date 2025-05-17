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
    public partial class PDT_momon : Form
    {
        public PDT_momon()
        {
            InitializeComponent();
        }
        public int hocKy = 3;
        public int Nam = 2025;

        public static string thaoTac = "";
        public static string maMM = "";
        public static string dvDangChon = "";
        public static string gvDangChon = "";
        public static string hpDangChon = "";
        public static string khoaDangChon = "";    


        private void Load_DSMM()
        {
            if (MainClass.conn.State == ConnectionState.Closed)
            {
                MainClass.conn.Open();
            }
         
            if (cbHK.SelectedItem != null && cbNam.SelectedItem != null)
            {
                hocKy = Convert.ToInt32(cbHK.SelectedItem.ToString());
                Nam = Convert.ToInt32(cbNam.SelectedItem.ToString());

                if (hocKy == 3 && Nam == 2025)
                {
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThem.Enabled = true;
                }
                else
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThem.Enabled = false;
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn đầy đủ học kỳ và năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_XEMDSMM", MainClass.conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("p_hk", OracleDbType.Int32).Value = hocKy;
            cmd.Parameters.Add("p_nam", OracleDbType.Int32).Value = Nam;

            OracleParameter paramMADV = new OracleParameter("p_madv", OracleDbType.Varchar2);
            if (string.IsNullOrEmpty(dvDangChon))
            {
                paramMADV.Value = DBNull.Value;
            }
            else
            {
                paramMADV.Value = dvDangChon;
            }
            cmd.Parameters.Add(paramMADV);

            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            pdt_mm.DataSource = dt;

        }

        private void PDT_momon_Load(object sender, EventArgs e)
        {
            cbHK.Items.AddRange(new object[] { 1, 2, 3 });
            cbNam.Items.AddRange(new object[] { 2020, 2021, 2022, 2023, 2024, 2025 });

            cbHK.SelectedItem = 3;
            cbNam.SelectedItem = 2025;
            Load_DSMM();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            thaoTac = "Them";
            PDT_Them frm = new PDT_Them();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            Load_DSMM();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (pdt_mm.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maMM = pdt_mm.SelectedRows[0].Cells[0].Value.ToString();

                
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa MAMM: {maMM}?", "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_PDT_XOAMM", MainClass.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = maMM;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Load_DSMM();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa môn mở: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbHK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHK.SelectedItem != null && cbNam.SelectedItem != null)
            {
                Load_DSMM();
               
            }
        }

        private void cbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHK.SelectedItem != null && cbNam.SelectedItem != null)
            {
                Load_DSMM();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            thaoTac = "Sua";
            if (pdt_mm.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            maMM = pdt_mm.SelectedRows[0].Cells[0].Value.ToString();
            hpDangChon = pdt_mm.SelectedRows[0].Cells[1].Value.ToString();
            gvDangChon = pdt_mm.SelectedRows[0].Cells[3].Value.ToString();
            khoaDangChon = pdt_mm.SelectedRows[0].Cells[5].Value.ToString();


            PDT_Them frm = new PDT_Them();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            Load_DSMM();

        }
    }
}
