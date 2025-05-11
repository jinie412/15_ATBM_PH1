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

namespace ATBM_PH1
{
    public partial class NV_CTSV : Form
    {
        private bool isDragging = false;
        private Point dragStartPosition;
        private CancellationTokenSource _searchCancellationTokenSource;
        private DataTable _cachedDataTable;

        public NV_CTSV()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            SinhVienForm ctsv = new SinhVienForm();
            ctsv.StartPosition = FormStartPosition.CenterScreen;
            if (ctsv.ShowDialog() == DialogResult.OK)
            {
                // Sau khi thêm thành công, làm mới danh sách
                ShowManageRolesContent();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewRoles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy thông tin sinh viên từ hàng được chọn
            DataGridViewRow selectedRow = dataGridViewRoles.SelectedRows[0];

            if (!dataGridViewRoles.Columns.Contains("MASV") || !dataGridViewRoles.Columns.Contains("HOTEN") ||
                !dataGridViewRoles.Columns.Contains("PHAI") || !dataGridViewRoles.Columns.Contains("NGSINH") ||
                !dataGridViewRoles.Columns.Contains("DCHI") || !dataGridViewRoles.Columns.Contains("DT") ||
                !dataGridViewRoles.Columns.Contains("KHOA") || !dataGridViewRoles.Columns.Contains("TINHTRANG"))
            {
                MessageBox.Show("Dữ liệu sinh viên không đầy đủ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string masv = selectedRow.Cells["MASV"].Value?.ToString();
            string hoten = selectedRow.Cells["HOTEN"].Value?.ToString();
            string phai = selectedRow.Cells["PHAI"].Value?.ToString();
            DateTime ngaysinh;
            try
            {
                ngaysinh = Convert.ToDateTime(selectedRow.Cells["NGSINH"].Value);
            }
            catch
            {
                MessageBox.Show("Dữ liệu ngày sinh không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string diachi = selectedRow.Cells["DCHI"].Value?.ToString();
            string dt = selectedRow.Cells["DT"].Value?.ToString();
            string khoa = selectedRow.Cells["KHOA"].Value?.ToString();
            string tinhtrang = selectedRow.Cells["TINHTRANG"].Value?.ToString();

            // Mở form chỉnh sửa với dữ liệu hiện tại
            using (SinhVienForm editForm = new SinhVienForm(masv, hoten, phai, ngaysinh, diachi, dt, khoa, tinhtrang))
            {
                editForm.StartPosition = FormStartPosition.CenterScreen;
                if (editForm.ShowDialog() != DialogResult.OK)
                {
                    return; // Người dùng nhấn Cancel
                }

                // Lấy dữ liệu từ form chỉnh sửa và gọi stored procedure
                try
                {
                    if (MainClass.conn.State == ConnectionState.Closed)
                    {
                        MainClass.conn.Open();
                    }

                    using (OracleCommand cmd = new OracleCommand("SP_UPDATE_SINHVIEN", MainClass.conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số cho stored procedure
                        cmd.Parameters.Add("p_masv", OracleDbType.Varchar2).Value = editForm.MASV;
                        cmd.Parameters.Add("p_hoten", OracleDbType.Varchar2).Value = editForm.HOTEN;
                        cmd.Parameters.Add("p_phai", OracleDbType.Varchar2).Value = editForm.PHAI;
                        cmd.Parameters.Add("p_ngaysinh", OracleDbType.Date).Value = editForm.NGSINH;
                        cmd.Parameters.Add("p_diachi", OracleDbType.Varchar2).Value = editForm.DCHI;
                        cmd.Parameters.Add("p_sdt", OracleDbType.Varchar2).Value = editForm.DT;
                        cmd.Parameters.Add("p_khoa", OracleDbType.Varchar2).Value = editForm.KHOA;
                        cmd.Parameters.Add("p_result", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                        // Thực thi stored procedure
                        cmd.ExecuteNonQuery();

                        // Lấy kết quả từ tham số output
                        string result = cmd.Parameters["p_result"].Value.ToString();
                        MessageBox.Show(result);

                        // Làm mới danh sách bất kể kết quả
                        ShowManageRolesContent();

                        // Nếu cập nhật thành công, làm mới DataGridView
                        if (result.Contains("Cập nhật sinh viên thành công"))
                        {
                            ShowManageRolesContent();
                        }
                    }
                }
                catch (OracleException oraEx)
                {
                    string errorMessage = $"Lỗi khi cập nhật sinh viên: {oraEx.Message}";
                    if (oraEx.Number != 0)
                        errorMessage += $"\nMã lỗi Oracle: {oraEx.Number}";
                    if (oraEx.InnerException != null)
                        errorMessage += $"\nChi tiết: {oraEx.InnerException.Message}";
                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Lỗi khi cập nhật sinh viên: {ex.Message}";
                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
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



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewRoles.CurrentRow == null || dataGridViewRoles.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra sự tồn tại của cột MANLD
            if (!dataGridViewRoles.Columns.Contains("MASV"))
            {
                MessageBox.Show("Không tìm thấy cột Mã SV trong danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Giả sử MANLD nằm trong cột tên "MANLD"
            string manld = dataGridViewRoles.CurrentRow.Cells["MASV"].Value?.ToString();

            if (string.IsNullOrEmpty(manld))
            {
                MessageBox.Show("Không tìm thấy mã sinh viên để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xoá sinh viên với Mã SV: {manld}?",
                                                          "Xác nhận xoá",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                    MainClass.conn.Open();

                using (OracleCommand cmd = new OracleCommand("pdb_admin.SP_DELETE_SINHVIEN", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_manld", OracleDbType.Varchar2).Value = manld;
                    cmd.Parameters.Add("p_result", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    string result = cmd.Parameters["p_result"].Value.ToString();
                    MessageBox.Show(result);

                    // Nếu xoá thành công thì refresh lại danh sách
                    if (result.Contains("Xóa sinh viên thành công."))
                    {
                        ShowManageRolesContent(); // Reload lại danh sách nhân viên
                    }
                }
            }
            catch (OracleException oraEx)
            {
                string errorMessage = $"Lỗi khi xoá sinh viên: {oraEx.Message}";
                if (oraEx.Number != 0)
                    errorMessage += $"\nMã lỗi Oracle: {oraEx.Number}";
                if (oraEx.InnerException != null)
                    errorMessage += $"\nChi tiết: {oraEx.InnerException.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log vào file
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Lỗi khi xoá sinh viên: {ex.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log vào file
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                    MainClass.conn.Close();
            }
        }

        private void ShowManageRolesContent()
        {
            panelManageRoles.Visible = true;

            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("pdb_admin.SP_GET_SINHVIEN", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    var pCursor = new OracleParameter("p_cursor", OracleDbType.RefCursor)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(pCursor);

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dataGridViewRoles.DataSource != null)
                        {
                            if (dataGridViewRoles.DataSource is DataView view)
                            {
                                view.Table.Clear();
                            }
                            else if (dataGridViewRoles.DataSource is DataTable table)
                            {
                                table.Clear();
                            }
                            else
                            {
                                dataGridViewRoles.DataSource = null;
                            }
                        }

                        // Gán dữ liệu mới
                        _cachedDataTable = dt;
                        dataGridViewRoles.DataSource = _cachedDataTable;
                        dataGridViewRoles.Refresh();

                        // Nếu chưa có cột STT, thì thêm vào
                        if (!dataGridViewRoles.Columns.Contains("STT"))
                        {
                            DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                            {
                                Name = "STT",
                                HeaderText = "STT",
                                ReadOnly = true,
                                Width = 50
                            };
                            dataGridViewRoles.Columns.Insert(0, sttColumn);
                        }

                        // Sau khi gán xong, cập nhật STT
                        int stt = 1;
                        foreach (DataGridViewRow row in dataGridViewRoles.Rows)
                        {
                            if (row.IsNewRow) continue;
                            row.Cells["STT"].Value = stt++;
                        }
                    }
                }
            }
            catch (OracleException oraEx)
            {
                string errorMessage = $"Lỗi khi tải sinh viên: {oraEx.Message}";
                if (oraEx.Number != 0)
                    errorMessage += $"\nMã lỗi Oracle: {oraEx.Number}";
                if (oraEx.InnerException != null)
                    errorMessage += $"\nChi tiết: {oraEx.InnerException.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log vào file
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Lỗi khi tải sinh viên: {ex.Message}";
                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log vào file
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            finally
            {
                if (MainClass.conn.State == ConnectionState.Open)
                    MainClass.conn.Close();
            }
        }

        private void textRole_TextChanged(object sender, EventArgs e)
        {
            _searchCancellationTokenSource?.Cancel();
            _searchCancellationTokenSource = new CancellationTokenSource();
            var token = _searchCancellationTokenSource.Token;

            Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(300, token);

                    Invoke(new Action(() =>
                    {
                        PerformSearch(textRole.Text.Trim());
                    }));
                }
                catch (TaskCanceledException)
                {
                    // Bỏ qua nếu tác vụ bị hủy
                }
            }, token);
        }

        private void PerformSearch(string searchText)
        {
            try
            {
                if (_cachedDataTable != null)
                {
                    DataView dataView = new DataView(_cachedDataTable);

                    if (string.IsNullOrEmpty(searchText))
                    {
                        dataView.RowFilter = string.Empty;
                    }
                    else
                    {
                        // Tìm kiếm theo HOTEN hoặc MANLD
                        dataView.RowFilter = $"HOTEN LIKE '%{searchText}%' OR MASV LIKE '%{searchText}%'";
                    }

                    // Gán lại DataSource
                    dataGridViewRoles.DataSource = dataView;

                    // Thêm lại cột STT nếu cần
                    if (!dataGridViewRoles.Columns.Contains("STT"))
                    {
                        DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                        {
                            Name = "STT",
                            HeaderText = "STT",
                            ReadOnly = true,
                            Width = 50
                        };
                        dataGridViewRoles.Columns.Insert(0, sttColumn);
                    }

                    // Cập nhật lại giá trị STT
                    int stt = 1;
                    foreach (DataGridViewRow row in dataGridViewRoles.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            row.Cells["STT"].Value = stt++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log vào file
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: Lỗi khi tìm kiếm sinh viên: {ex.Message}\n");
            }
        }
    }
}
