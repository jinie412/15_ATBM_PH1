using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class OLS_GanUser : Form
    {
        public OLS_GanUser()
        {
            InitializeComponent();
          
        }
        public string dvDangChon = "";
        public string nvDangChon = "";
        public string hpDangChon = "";

        private void PDT_Them_Load(object sender, EventArgs e)
        {

            Load_Level();  
            Load_Comp();
            Load_Grp();
            ShowManageContent();

        }



        private void Load_Level()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                string query = @"
            SELECT LEVEL_NUM, SHORT_NAME, LONG_NAME
            FROM ALL_SA_LEVELS
            WHERE POLICY_NAME = 'OLS_NOTIFY_POLICY'
            ORDER BY LEVEL_NUM";

                using (OracleCommand cmd = new OracleCommand(query, MainClass.conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        cbCB.DataSource = dt;
                        cbCB.DisplayMember = "SHORT_NAME";    // Hoặc "SHORT_NAME" tùy bạn muốn hiển thị gì
                        cbCB.ValueMember = "LEVEL_NUM";      // Giá trị ngầm khi chọn
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách cấp độ bảo mật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_Comp()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                string query = @"
            SELECT COMP_NUM, SHORT_NAME, LONG_NAME
            FROM ALL_SA_COMPARTMENTS
            WHERE POLICY_NAME = 'OLS_NOTIFY_POLICY'
            ORDER BY COMP_NUM";

                using (OracleCommand cmd = new OracleCommand(query, MainClass.conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Thêm dòng "ALL" vào đầu
                        DataRow allRow = dt.NewRow();
                        allRow["COMP_NUM"] = -1;
                        allRow["SHORT_NAME"] = "ALL";
                        allRow["LONG_NAME"] = "ALL";
                        dt.Rows.InsertAt(allRow, 0);

                        cbLV.DataSource = dt;
                        cbLV.DisplayMember = "SHORT_NAME";
                        cbLV.ValueMember = "COMP_NUM";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách COMPARTMENT: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Load_Grp()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                string query = @"
            SELECT GROUP_NUM, SHORT_NAME, LONG_NAME
            FROM ALL_SA_GROUPS
            WHERE POLICY_NAME = 'OLS_NOTIFY_POLICY'
            ORDER BY GROUP_NUM";

                using (OracleCommand cmd = new OracleCommand(query, MainClass.conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        // Thêm dòng "ALL" vào đầu
                        DataRow allRow = dt.NewRow();
                        allRow["GROUP_NUM"] = -1;
                        allRow["SHORT_NAME"] = "ALL";
                        allRow["LONG_NAME"] = "ALL";
                        dt.Rows.InsertAt(allRow, 0);

                        cbCS.DataSource = dt;
                        cbCS.DisplayMember = "SHORT_NAME";
                        cbCS.ValueMember = "GROUP_NUM";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách GROUP: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnCN_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                // Lấy LEVEL
                string levelName = ((DataRowView)cbCB.SelectedItem)["SHORT_NAME"].ToString();

                // --------- Xử lý COMPARTMENT ----------
                string compPart;
                if (Convert.ToInt32(cbLV.SelectedValue) == -1)
                {
                    string compQuery = @"
                SELECT SHORT_NAME 
                FROM ALL_SA_COMPARTMENTS 
                WHERE POLICY_NAME = 'OLS_NOTIFY_POLICY'
                ORDER BY COMPARTMENT";
                    OracleCommand compCmd = new OracleCommand(compQuery, MainClass.conn);
                    OracleDataReader compReader = compCmd.ExecuteReader();
                    List<string> compList = new List<string>();
                    while (compReader.Read())
                    {
                        compList.Add(compReader.GetString(0));
                    }
                    compReader.Close();
                    compPart = string.Join(",", compList);
                }
                else
                {
                    compPart = ((DataRowView)cbLV.SelectedItem)["SHORT_NAME"].ToString();
                }

                // --------- Xử lý GROUP ----------
                string groupPart;
                if (Convert.ToInt32(cbCS.SelectedValue) == -1)
                {
                    string groupQuery = @"
                SELECT SHORT_NAME 
                FROM ALL_SA_GROUPS 
                WHERE POLICY_NAME = 'OLS_NOTIFY_POLICY'
                ORDER BY GROUP";
                    OracleCommand groupCmd = new OracleCommand(groupQuery, MainClass.conn);
                    OracleDataReader groupReader = groupCmd.ExecuteReader();
                    List<string> groupList = new List<string>();
                    while (groupReader.Read())
                    {
                        groupList.Add(groupReader.GetString(0));
                    }
                    groupReader.Close();
                    groupPart = string.Join(",", groupList);
                }
                else
                {
                    groupPart = ((DataRowView)cbCS.SelectedItem)["SHORT_NAME"].ToString();
                }

                // --------- Tạo label tag theo định dạng LEVEL:COMP:GROUP ---------
                string label = $"{levelName}:{compPart}:{groupPart}";

                // --------- Tạo label_id duy nhất ---------


                using (OracleCommand cmd = new OracleCommand("SA_USER_ADMIN.SET_USER_LABELS", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("policy_name", OracleDbType.Varchar2).Value = "OLS_NOTIFY_POLICY";
                    cmd.Parameters.Add("user_name", OracleDbType.Varchar2).Value = nvDangChon;
                    cmd.Parameters.Add("label", OracleDbType.Varchar2).Value = label;

                    cmd.ExecuteNonQuery();
                }


                MessageBox.Show("Gán label thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gán label: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        private void dgvGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvGV.Columns["checkGV"].Index && e.RowIndex >= 0)
            {
                // Đặt tất cả các checkbox về false
                foreach (DataGridViewRow row in dgvGV.Rows)
                {
                    row.Cells["checkGV"].Value = false;
                }

                // Chỉ bật checkbox của dòng được click
                dgvGV.Rows[e.RowIndex].Cells["checkGV"].Value = true;
                // Gán mã HP được chọn
                nvDangChon = dgvGV.Rows[e.RowIndex].Cells["magv"].Value?.ToString() ?? "";
            }
        }

        private void ShowManageContent()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open(); 
                }

                string query = @"
            SELECT manld, hoten
            FROM pdb_admin.nhanvien
            FETCH FIRST 30 ROWS ONLY";  // Nếu dùng Oracle 12c+

                using (OracleCommand cmd = new OracleCommand(query, MainClass.conn))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Gán vào DataGridView
                        dgvGV.DataSource = dt;

                       
                    }
                }
            }
            catch (OracleException oraEx)
            {
                string errorMessage = $"Lỗi khi tải nhân viên: {oraEx.Message}";
                if (oraEx.Number != 0)
                    errorMessage += $"\nMã lỗi Oracle: {oraEx.Number}";
                if (oraEx.InnerException != null)
                    errorMessage += $"\nChi tiết: {oraEx.InnerException.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Lỗi khi tải nhân viên: {ex.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
        }

    }
}
