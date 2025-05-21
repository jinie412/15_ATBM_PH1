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
    public partial class DangKyHP : Form
    {
        public DangKyHP()
        {
            InitializeComponent();
            LoadMonHocDangKy();
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

        private void LoadMonHocDangKy()
        {
            using (OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_GET_MOMON_SV", MainClass.conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Output SYS_REFCURSOR
                cmd.Parameters.Add("p_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gán dữ liệu lên DataGridView
                dgvlistsubject.DataSource = dt;
                originalData = dt;
                LoadComboBoxData();
            }
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            DSHP dshp = new DSHP();
            dshp.StartPosition = FormStartPosition.CenterScreen;
            dshp.ShowDialog();

            // Sau khi form DSHP đóng, load lại dữ liệu
            LoadMonHocDangKy();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvlistsubject.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
                return;
            }

            string mamm = dgvlistsubject.SelectedRows[0].Cells["MAMM"].Value.ToString();

            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa đăng ký môn học này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            try
            {
                using (OracleCommand cmd = new OracleCommand("PDB_ADMIN.SP_DELETE_DANGKY", MainClass.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_mamm", OracleDbType.Varchar2).Value = mamm;
                    var masvParam = new OracleParameter("p_masv", OracleDbType.Varchar2);
                    masvParam.Value = DBNull.Value;
                    cmd.Parameters.Add(masvParam);

                    var deletedCountParam = new OracleParameter("p_deleted_count", OracleDbType.Int32)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(deletedCountParam);

                    cmd.ExecuteNonQuery();

                    int deletedRows = ((OracleDecimal)deletedCountParam.Value).ToInt32();
                    if (deletedRows > 0)
                    {
                        MessageBox.Show("Xóa thành công.");
                        LoadMonHocDangKy();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa. Có thể bạn không có quyền hoặc dòng đã bị thay đổi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }
    }
}
