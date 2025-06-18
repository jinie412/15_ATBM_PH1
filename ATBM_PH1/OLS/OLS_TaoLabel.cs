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
    public partial class OLS_TaoLabel : Form
    {
        public OLS_TaoLabel()
        {
            InitializeComponent();
          
        }
        public string dvDangChon = "";
        public string gvDangChon = "";
        public string hpDangChon = "";

        private void PDT_Them_Load(object sender, EventArgs e)
        {

            Load_Level();  
            Load_Comp();
            Load_Grp();
            ShowLabel();

        }

        public static string lbldangchon = "";



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

                // Kiểm tra có dòng nào trong dgvGV được chọn hay không
                bool anyChecked = false;
                foreach (DataGridViewRow row in dgvGV.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["checkGV"].Value) == true)
                    {
                        anyChecked = true;
                        break;
                    }
                }

                if (anyChecked)
                {
                    // Nếu có dòng được chọn, thực hiện thêm thông báo cho từng dòng
                    foreach (DataGridViewRow row in dgvGV.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["checkGV"].Value) != true) continue;

                        string selectedLabelTag = row.Cells["LABEL_TAG"].Value.ToString();  // Giả sử cột tên "LABEL_TAG"

                        // Lấy ID mới
                        int newId = 0;
                        string getIdQuery = "SELECT NVL(MAX(ID), 0) + 1 FROM pdb_admin.thongbao";
                        using (OracleCommand getIdCmd = new OracleCommand(getIdQuery, MainClass.conn))
                        {
                            object result = getIdCmd.ExecuteScalar();
                            newId = Convert.ToInt32(result);
                        }

                        // Insert thông báo
                        string insertQuery = @"
                    INSERT INTO pdb_admin.thongbao (ID, NOIDUNG, LABEL)
                    VALUES (:id, :noidung, :label)";
                        using (OracleCommand insertCmd = new OracleCommand(insertQuery, MainClass.conn))
                        {
                            insertCmd.Parameters.Add(":id", OracleDbType.Int32).Value = newId;
                            insertCmd.Parameters.Add(":noidung", OracleDbType.Varchar2).Value = txtNoidung.Text;
                            insertCmd.Parameters.Add(":label", OracleDbType.Int32).Value = Convert.ToInt32(selectedLabelTag);
                            insertCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Đã thêm thông báo cho các label được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Nếu không chọn hàng nào → xử lý tạo label như hiện tại

                    string levelName = ((DataRowView)cbCB.SelectedItem)["SHORT_NAME"].ToString();

                    string compPart;
                    if (Convert.ToInt32(cbLV.SelectedValue) == -1)
                    {
                        string compQuery = @"
                    SELECT SHORT_NAME 
                    FROM ALL_SA_COMPARTMENTS 
                    WHERE POLICY_NAME = 'OLS_NOTIFY_POLICY'
                    ORDER BY COMP_NUM";
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

                    string groupPart;
                    if (Convert.ToInt32(cbCS.SelectedValue) == -1)
                    {
                        string groupQuery = @"
                    SELECT SHORT_NAME 
                    FROM ALL_SA_GROUPS 
                    WHERE POLICY_NAME = 'OLS_NOTIFY_POLICY'
                    ORDER BY GROUP_NUM";
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

                    string label = $"{levelName}:{compPart}:{groupPart}";

                    string labelTag = "";
                    int baseTag = 2000;
                    bool tagExists = true; // Kiểm tra số tag đó đã tồn tại chưa.

                    while (tagExists)
                    {
                        string checkQuery = @"
                    SELECT COUNT(*) FROM ALL_SA_LABELS 
                    WHERE POLICY_NAME = 'OLS_NOTIFY_POLICY' 
                      AND LABEL_TAG = :labelTag";

                        using (OracleCommand checkCmd = new OracleCommand(checkQuery, MainClass.conn))
                        {
                            checkCmd.Parameters.Add(":labelTag", OracleDbType.Varchar2).Value = baseTag.ToString();
                            object count = checkCmd.ExecuteScalar();
                            tagExists = Convert.ToInt32(count) > 0;
                        }

                        if (!tagExists)
                        {
                            labelTag = baseTag.ToString();
                        }
                        else
                        {
                            baseTag++;
                        }
                    }

                    using (OracleCommand cmd = new OracleCommand("PROC_CREATE_LABEL", MainClass.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("p_policy_name", OracleDbType.Varchar2).Value = "OLS_NOTIFY_POLICY";
                        cmd.Parameters.Add("p_label_tag", OracleDbType.Varchar2).Value = labelTag;
                        cmd.Parameters.Add("p_label_value", OracleDbType.Varchar2).Value = label;
                        cmd.Parameters.Add("p_text", OracleDbType.Varchar2).Value = txtNoidung.Text;
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Tạo label mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //private void dgvGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == dgvGV.Columns["checkGV"].Index && e.RowIndex >= 0)
        //    {
        //        // Đặt tất cả các checkbox về false
        //        foreach (DataGridViewRow row in dgvGV.Rows)
        //        {
        //            row.Cells["checkGV"].Value = false;
        //        }

        //        // Chỉ bật checkbox của dòng được click
        //        dgvGV.Rows[e.RowIndex].Cells["checkGV"].Value = true;
        //        //// Gán mã HP được chọn
        //        //lbldangchon = dgvGV.Rows[e.RowIndex].Cells["magv"].Value?.ToString() ?? "";
        //    }
        //}

        private void dgvGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvGV.Columns["checkGV"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dgvGV.Rows[e.RowIndex];

                // Lấy trạng thái hiện tại của checkbox dòng được click
                bool currentlyChecked = Convert.ToBoolean(clickedRow.Cells["checkGV"].Value ?? false);

                // Bỏ chọn tất cả checkbox
                foreach (DataGridViewRow row in dgvGV.Rows)
                {
                    row.Cells["checkGV"].Value = false;
                }

                // Nếu dòng đang click chưa được chọn → chọn
                // Nếu đã được chọn → toggle bỏ chọn (không làm gì thêm)
                if (!currentlyChecked)
                {
                    clickedRow.Cells["checkGV"].Value = true;
                }

                // (Tùy chọn) Cập nhật mã GV nếu cần:
                // lbldangchon = clickedRow.Cells["magv"].Value?.ToString() ?? "";
                // else lbldangchon = "";  // nếu bạn muốn xóa khi bỏ chọn
            }
        }


        private void ShowLabel()
        {
            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                string query = @"
            SELECT LABEL, LABEL_TAG
            FROM all_sa_labels
            ";  

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
                string errorMessage = $"Lỗi khi tải label: {oraEx.Message}";
                if (oraEx.Number != 0)
                    errorMessage += $"\nMã lỗi Oracle: {oraEx.Number}";
                if (oraEx.InnerException != null)
                    errorMessage += $"\nChi tiết: {oraEx.InnerException.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Lỗi khi tải label: {ex.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
        }




    }
}
