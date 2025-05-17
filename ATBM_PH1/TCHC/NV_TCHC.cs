using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ATBM_PH1
{
    public partial class NV_TCHC : Form
    {
        private bool isDragging = false;
        private Point dragStartPosition;
        private CancellationTokenSource _searchCancellationTokenSource;
        private DataTable _cachedDataTable;

        public NV_TCHC()
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

                // Show Manage content by default
                ShowManageContent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Role_Load(object sender, EventArgs e)
        {
#if DEBUG
            ShowManageContent();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NhanVienForm tchc = new NhanVienForm();
            tchc.StartPosition = FormStartPosition.CenterScreen;
            if (tchc.ShowDialog() == DialogResult.OK)
            {
                // Sau khi thêm thành công, làm mới danh sách
                ShowManageContent();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy thông tin nhân viên từ hàng được chọn
            DataGridViewRow selectedRow = dataGridViewNhanVien.SelectedRows[0];

            string manld = selectedRow.Cells["tchc_manv"].Value?.ToString();
            string hoten = selectedRow.Cells["tchc_ht"].Value?.ToString();
            string phai = selectedRow.Cells["tchc_phai"].Value?.ToString();
            DateTime ngsinh;
            try
            {
                ngsinh = Convert.ToDateTime(selectedRow.Cells["tchc_nsinh"].Value);
            }
            catch
            {
                MessageBox.Show("Dữ liệu ngày sinh không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal luong;
            try
            {
                luong = Convert.ToDecimal(selectedRow.Cells["tchc_lg"].Value);
            }
            catch
            {
                MessageBox.Show("Dữ liệu lương không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal phucap;
            try
            {
                phucap = Convert.ToDecimal(selectedRow.Cells["tchc_pc"].Value);
            }
            catch
            {
                MessageBox.Show("Dữ liệu phụ cấp không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dt = selectedRow.Cells["DT"].Value?.ToString();
            string vaitro = selectedRow.Cells["tchc_vt"].Value?.ToString();
            string madv = selectedRow.Cells["tchc_dv"].Value?.ToString();

            // Mở form chỉnh sửa với dữ liệu hiện tại
            using (NhanVienForm editForm = new NhanVienForm(manld, hoten, phai, ngsinh, luong, phucap, dt, vaitro, madv))
            {
                editForm.StartPosition = FormStartPosition.CenterScreen;
                if (editForm.ShowDialog() != DialogResult.OK)
                {
                    return; // Người dùng nhấn Cancel
                }
                else{
                    ShowManageContent();
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewNhanVien.CurrentRow == null || dataGridViewNhanVien.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra sự tồn tại của cột MANLD
            if (!dataGridViewNhanVien.Columns.Contains("tchc_manv"))
            {
                MessageBox.Show("Không tìm thấy cột Mã NLĐ trong danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Giả sử MANLD nằm trong cột tên "MANLD"
            string manld = dataGridViewNhanVien.CurrentRow.Cells["tchc_manv"].Value?.ToString();

            if (string.IsNullOrEmpty(manld))
            {
                MessageBox.Show("Không tìm thấy mã nhân viên để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xoá nhân viên với Mã NLĐ: {manld}?",
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

                using (OracleCommand cmd = new OracleCommand("pdb_admin.SP_DELETE_NHANVIEN", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_manld", OracleDbType.Varchar2).Value = manld;
                    cmd.Parameters.Add("p_result", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    string result = cmd.Parameters["p_result"].Value.ToString();
                    MessageBox.Show(result);

                    // Nếu xoá thành công thì refresh lại danh sách
                    if (result.Contains("Xoá nhân viên thành công"))
                    {
                        ShowManageContent(); // Reload lại danh sách nhân viên
                    }
                }
            }
            catch (OracleException oraEx)
            {
                string errorMessage = $"Lỗi khi xoá nhân viên: {oraEx.Message}";
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
                string errorMessage = $"Lỗi khi xoá nhân viên: {ex.Message}";
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

        private void ShowManageContent()
        {
            panelManageRoles.Visible = true;

            try
            {
                if (MainClass.conn.State == ConnectionState.Closed)
                {
                    MainClass.conn.Open();
                }

                using (OracleCommand cmd = new OracleCommand("pdb_admin.SP_GET_NHANVIEN", MainClass.conn))
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

                        // Gán dữ liệu mới
                        _cachedDataTable = dt;
                        dataGridViewNhanVien.DataSource = _cachedDataTable;

                        // Nếu chưa có cột STT, thì thêm vào
                        if (!dataGridViewNhanVien.Columns.Contains("STT"))
                        {
                            DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                            {
                                Name = "STT",
                                HeaderText = "STT",
                                ReadOnly = true,
                                Width = 50
                            };
                            dataGridViewNhanVien.Columns.Insert(0, sttColumn);
                        }

                        // Sau khi gán xong, cập nhật STT
                        int stt = 1;
                        foreach (DataGridViewRow row in dataGridViewNhanVien.Rows)
                        {
                            if (row.IsNewRow) continue;
                            row.Cells["STT"].Value = stt++;
                        }
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
                // Ghi log vào file
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: {errorMessage}\n");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Lỗi khi tải nhân viên: {ex.Message}";
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
                        dataView.RowFilter = $"HOTEN LIKE '%{searchText}%' OR MANLD LIKE '%{searchText}%'";
                    }

                    // Gán lại DataSource
                    dataGridViewNhanVien.DataSource = dataView;

                    // Thêm lại cột STT nếu cần
                    if (!dataGridViewNhanVien.Columns.Contains("STT"))
                    {
                        DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                        {
                            Name = "STT",
                            HeaderText = "STT",
                            ReadOnly = true,
                            Width = 50
                        };
                        dataGridViewNhanVien.Columns.Insert(0, sttColumn);
                    }

                    // Cập nhật lại giá trị STT
                    int stt = 1;
                    foreach (DataGridViewRow row in dataGridViewNhanVien.Rows)
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
                MessageBox.Show($"Lỗi khi tìm kiếm nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log vào file
                System.IO.File.AppendAllText("error_log.txt", $"{DateTime.Now}: Lỗi khi tìm kiếm nhân viên: {ex.Message}\n");
            }
        }
    }
}