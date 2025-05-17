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
    public partial class NV_PKT : Form
    {
        private bool isDragging = false;
        private Point dragStartPosition;
        private CancellationTokenSource _searchCancellationTokenSource;
        private DataTable _cachedDataTable;

        public NV_PKT()
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiem.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để cập nhật điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy thông tin điểm số từ hàng được chọn
            DataGridViewRow selectedRow = dataGridViewDiem.SelectedRows[0];

            //if (!dataGridViewDiem.Columns.Contains("MASV") || !dataGridViewDiem.Columns.Contains("MAMM") ||
            //    !dataGridViewDiem.Columns.Contains("DIEMTH") || !dataGridViewDiem.Columns.Contains("DIEMQT") ||
            //    !dataGridViewDiem.Columns.Contains("DIEMCK") || !dataGridViewDiem.Columns.Contains("DIEMTK"))
            //{
            //    MessageBox.Show("Dữ liệu điểm số không đầy đủ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            string masv = selectedRow.Cells["kt_masv"].Value?.ToString();
            string mamm = selectedRow.Cells["kt_mm"].Value?.ToString();
            float diemth, diemqt, diemck, diemtk;

            try
            {
                diemth = float.Parse(selectedRow.Cells["kt_dth"].Value?.ToString() ?? "-1");
                diemqt = float.Parse(selectedRow.Cells["kt_dqt"].Value?.ToString() ?? "-1");
                diemck = float.Parse(selectedRow.Cells["kt_dck"].Value?.ToString() ?? "-1");
                diemtk = float.Parse(selectedRow.Cells["kt_dtk"].Value?.ToString() ?? "-1");
            }
            catch
            {
                MessageBox.Show("Dữ liệu điểm số không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mở form chỉnh sửa điểm số với dữ liệu hiện tại
            using (UpdateScore editForm = new UpdateScore(masv, mamm, diemth, diemqt, diemck, diemtk))
            {
                editForm.StartPosition = FormStartPosition.CenterScreen;
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Làm mới danh sách sau khi cập nhật thành công
                    ShowManageContent();
                }
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

                using (OracleCommand cmd = new OracleCommand("pdb_admin.SP_VIEW_DANGKY", MainClass.conn))
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

                        //if (dataGridViewDiem.DataSource != null)
                        //{
                        //    if (dataGridViewDiem.DataSource is DataView view)
                        //    {
                        //        view.Table.Clear();
                        //    }
                        //    else if (dataGridViewDiem.DataSource is DataTable table)
                        //    {
                        //        table.Clear();
                        //    }
                        //    else
                        //    {
                        //        dataGridViewDiem.DataSource = null;
                        //    }
                        //}

                        // Gán dữ liệu mới
                        _cachedDataTable = dt;
                        dataGridViewDiem.DataSource = _cachedDataTable;
                        dataGridViewDiem.Refresh();

                        // Nếu chưa có cột STT, thì thêm vào
                        if (!dataGridViewDiem.Columns.Contains("STT"))
                        {
                            DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                            {
                                Name = "STT",
                                HeaderText = "STT",
                                ReadOnly = true,
                                Width = 50
                            };
                            dataGridViewDiem.Columns.Insert(0, sttColumn);
                        }

                        // Sau khi gán xong, cập nhật STT
                        int stt = 1;
                        foreach (DataGridViewRow row in dataGridViewDiem.Rows)
                        {
                            if (row.IsNewRow) continue;
                            row.Cells["STT"].Value = stt++;
                        }
                    }
                }
            }
            catch (OracleException oraEx)
            {
                string errorMessage = $"Lỗi khi tải dữ liệu bảng điểm: {oraEx.Message}";
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
                string errorMessage = $"Lỗi khi tải bảng điểm: {ex.Message}";
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
                        dataView.RowFilter = $"MASV LIKE '%{searchText}%'";
                    }

                    // Gán lại DataSource
                    dataGridViewDiem.DataSource = dataView;

                    // Thêm lại cột STT nếu cần
                    if (!dataGridViewDiem.Columns.Contains("STT"))
                    {
                        DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                        {
                            Name = "STT",
                            HeaderText = "STT",
                            ReadOnly = true,
                            Width = 50
                        };
                        dataGridViewDiem.Columns.Insert(0, sttColumn);
                    }

                    // Cập nhật lại giá trị STT
                    int stt = 1;
                    foreach (DataGridViewRow row in dataGridViewDiem.Rows)
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
