using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ATBM_PH1
{
    public partial class NVCB: Form
    {

        private bool isDragging = false;
        private Point dragStartPosition;
        private DataTable _cachedDataTable;


        public NVCB()
        {
            try
            {
                InitializeComponent();

                // Enable dragging on the title bar
                panelTitleBar.MouseDown += new MouseEventHandler(panelTitleBar_MouseDown);
                panelTitleBar.MouseMove += new MouseEventHandler(panelTitleBar_MouseMove);
                panelTitleBar.MouseUp += new MouseEventHandler(panelTitleBar_MouseUp);
                labelFormTitle.MouseDown += new MouseEventHandler(panelTitleBar_MouseDown);
                labelFormTitle.MouseMove += new MouseEventHandler(panelTitleBar_MouseMove);
                labelFormTitle.MouseUp += new MouseEventHandler(panelTitleBar_MouseUp);

                // Show Manage Roles content by default
                ShowManageRolesContent();
                SetupDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}");
            }
        }

        private void Role_Load(object sender, EventArgs e)
        {
#if DEBUG
            ShowManageRolesContent();
#endif
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPosition = new Point(e.X, e.Y);
            }
        }

        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(new Point(e.X, e.Y));
                Location = new Point(p.X - dragStartPosition.X, p.Y - dragStartPosition.Y);
            }
        }

        private void panelTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizeRestore_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximizeRestore.Text = "❐";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximizeRestore.Text = "□";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa số điện thoại.");
                return;
            }

            var selectedRow = dataGridViewRoles.SelectedRows[0];
            string columnName = "DT";

            // Kiểm tra cột DT trong dataGridViewRoles.Columns
            if (!dataGridViewRoles.Columns.Contains(columnName) && dataGridViewRoles.Columns.Contains("dt"))
            {
                columnName = "dt"; // Sử dụng "dt" nếu tìm thấy
            }
            else if (!dataGridViewRoles.Columns.Contains(columnName))
            {
                MessageBox.Show("Cột DT không tồn tại trong dữ liệu. Vui lòng kiểm tra dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy giá trị hiện tại của DT
            object cellValue = selectedRow.Cells[columnName].Value;
            string currentDT = (cellValue == null || cellValue == DBNull.Value) ? "" : cellValue.ToString();

            // Hiển thị form nhập số điện thoại mới
            using (UpdatePhoneForm phoneForm = new UpdatePhoneForm(currentDT))
            {
                phoneForm.StartPosition = FormStartPosition.CenterScreen;
                if (phoneForm.ShowDialog() != DialogResult.OK)
                {
                    return; // Người dùng nhấn Cancel
                }

                string newDT = phoneForm.NewPhoneNumber;

                // Gọi stored procedure để cập nhật số điện thoại
                try
                {
                    if (MainClass.conn.State == ConnectionState.Closed)
                    {
                        MainClass.conn.Open();
                    }

                    using (OracleCommand cmd = new OracleCommand("pdb_admin.SP_UPDATE_DT_NVCB", MainClass.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số cho stored procedure
                        cmd.Parameters.Add("p_new_dt", OracleDbType.Varchar2).Value = newDT;
                        cmd.Parameters.Add("p_result", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                        // Thực thi stored procedure
                        cmd.ExecuteNonQuery();

                        // Lấy kết quả từ tham số output
                        string result = cmd.Parameters["p_result"].Value.ToString();
                        MessageBox.Show(result);

                        // Nếu cập nhật thành công, làm mới DataGridView
                        if (result.Contains("thành công"))
                        {
                            ShowManageRolesContent();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật số điện thoại: " + ex.Message);
                }
                finally
                {
                    if (MainClass.conn.State == ConnectionState.Open)
                    {
                        MainClass.conn.Close();
                    }
                }
            }
        }


        private void ShowManageRolesContent()
        {
            panelManageRoles.Visible = true;

            try
            {
                // Kiểm tra trạng thái kết nối trước khi thực hiện truy vấn
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                // Tiếp tục gọi thủ tục SP_GET_NVCB_EDIT
                using (OracleCommand cmd = new OracleCommand("pdb_admin.SP_GET_NVCB_EDIT", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        _cachedDataTable = dt;
                        dataGridViewRoles.DataSource = _cachedDataTable;

                        if (dataGridViewRoles.Columns.Contains("DT"))
                        {
                            dataGridViewRoles.Columns["DT"].ReadOnly = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                    MainClass.conn.Close();
            }
        }

        private void SetupDataGridViewColumns()
        {
            dataGridViewRoles.AutoGenerateColumns = false;
            dataGridViewRoles.Columns.Clear();

            dataGridViewRoles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "MANLD", DataPropertyName = "MANLD" });
            dataGridViewRoles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "HOTEN", DataPropertyName = "HOTEN" });
            dataGridViewRoles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "PHAI", DataPropertyName = "PHAI" });
            dataGridViewRoles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NGSINH", DataPropertyName = "NGSINH" });
            dataGridViewRoles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "LUONG", DataPropertyName = "LUONG" });
            dataGridViewRoles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "PHUCAP", DataPropertyName = "PHUCAP" });
            var dtColumn = new DataGridViewTextBoxColumn
            {
                Name = "DT",                 
                HeaderText = "DT",
                DataPropertyName = "DT"
            };
            dataGridViewRoles.Columns.Add(dtColumn);

            dataGridViewRoles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "VAITRO", DataPropertyName = "VAITRO" });
            dataGridViewRoles.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "MADV", DataPropertyName = "MADV" });
        }


    }
}
