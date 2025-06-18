using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM_PH1
{
    partial class NV_TCHC
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelManageRoles = new System.Windows.Forms.Panel();
            this.dataGridViewNhanVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tchc_manv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tchc_ht = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tchc_phai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tchc_nsinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tchc_lg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tchc_pc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tchc_vt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tchc_dv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.textRole = new Guna.UI2.WinForms.Guna2TextBox();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaximizeRestore = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.panelManageRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhanVien)).BeginInit();
            this.contentPanel.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelManageRoles
            // 
            this.panelManageRoles.Controls.Add(this.dataGridViewNhanVien);
            this.panelManageRoles.Controls.Add(this.btnEdit);
            this.panelManageRoles.Controls.Add(this.btnCreate);
            this.panelManageRoles.Controls.Add(this.btnDelete);
            this.panelManageRoles.Controls.Add(this.textRole);
            this.panelManageRoles.Location = new System.Drawing.Point(57, 34);
            this.panelManageRoles.Name = "panelManageRoles";
            this.panelManageRoles.Size = new System.Drawing.Size(1137, 587);
            this.panelManageRoles.TabIndex = 0;
            // 
            // dataGridViewNhanVien
            // 
            this.dataGridViewNhanVien.AllowUserToAddRows = false;
            this.dataGridViewNhanVien.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewNhanVien.ColumnHeadersHeight = 40;
            this.dataGridViewNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tchc_manv,
            this.tchc_ht,
            this.tchc_phai,
            this.tchc_nsinh,
            this.tchc_lg,
            this.tchc_pc,
            this.DT,
            this.tchc_vt,
            this.tchc_dv});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewNhanVien.Location = new System.Drawing.Point(46, 136);
            this.dataGridViewNhanVien.Name = "dataGridViewNhanVien";
            this.dataGridViewNhanVien.ReadOnly = true;
            this.dataGridViewNhanVien.RowHeadersVisible = false;
            this.dataGridViewNhanVien.RowHeadersWidth = 60;
            this.dataGridViewNhanVien.RowTemplate.Height = 30;
            this.dataGridViewNhanVien.Size = new System.Drawing.Size(1056, 412);
            this.dataGridViewNhanVien.TabIndex = 8;
            this.dataGridViewNhanVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewNhanVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewNhanVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewNhanVien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewNhanVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewNhanVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewNhanVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewNhanVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewNhanVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewNhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewNhanVien.ThemeStyle.HeaderStyle.Height = 40;
            this.dataGridViewNhanVien.ThemeStyle.ReadOnly = true;
            this.dataGridViewNhanVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewNhanVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewNhanVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewNhanVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewNhanVien.ThemeStyle.RowsStyle.Height = 30;
            this.dataGridViewNhanVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewNhanVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tchc_manv
            // 
            this.tchc_manv.DataPropertyName = "MANLD";
            this.tchc_manv.HeaderText = "Mã NV";
            this.tchc_manv.MinimumWidth = 6;
            this.tchc_manv.Name = "tchc_manv";
            this.tchc_manv.ReadOnly = true;
            this.tchc_manv.Width = 117;
            // 
            // tchc_ht
            // 
            this.tchc_ht.DataPropertyName = "HOTEN";
            this.tchc_ht.HeaderText = "Họ tên";
            this.tchc_ht.MinimumWidth = 6;
            this.tchc_ht.Name = "tchc_ht";
            this.tchc_ht.ReadOnly = true;
            this.tchc_ht.Width = 118;
            // 
            // tchc_phai
            // 
            this.tchc_phai.DataPropertyName = "PHAI";
            this.tchc_phai.HeaderText = "Phái";
            this.tchc_phai.MinimumWidth = 6;
            this.tchc_phai.Name = "tchc_phai";
            this.tchc_phai.ReadOnly = true;
            this.tchc_phai.Width = 117;
            // 
            // tchc_nsinh
            // 
            this.tchc_nsinh.DataPropertyName = "NGSINH";
            this.tchc_nsinh.HeaderText = "Ngày sinh";
            this.tchc_nsinh.MinimumWidth = 6;
            this.tchc_nsinh.Name = "tchc_nsinh";
            this.tchc_nsinh.ReadOnly = true;
            this.tchc_nsinh.Width = 117;
            // 
            // tchc_lg
            // 
            this.tchc_lg.DataPropertyName = "LUONG";
            this.tchc_lg.HeaderText = "Lương";
            this.tchc_lg.MinimumWidth = 6;
            this.tchc_lg.Name = "tchc_lg";
            this.tchc_lg.ReadOnly = true;
            this.tchc_lg.Width = 118;
            // 
            // tchc_pc
            // 
            this.tchc_pc.DataPropertyName = "PHUCAP";
            this.tchc_pc.HeaderText = "Phụ cấp";
            this.tchc_pc.MinimumWidth = 6;
            this.tchc_pc.Name = "tchc_pc";
            this.tchc_pc.ReadOnly = true;
            this.tchc_pc.Width = 117;
            // 
            // DT
            // 
            this.DT.DataPropertyName = "DT";
            this.DT.HeaderText = "DT";
            this.DT.MinimumWidth = 6;
            this.DT.Name = "DT";
            this.DT.ReadOnly = true;
            this.DT.Width = 117;
            // 
            // tchc_vt
            // 
            this.tchc_vt.DataPropertyName = "VAITRO";
            this.tchc_vt.HeaderText = "Vai trò";
            this.tchc_vt.MinimumWidth = 6;
            this.tchc_vt.Name = "tchc_vt";
            this.tchc_vt.ReadOnly = true;
            this.tchc_vt.Width = 118;
            // 
            // tchc_dv
            // 
            this.tchc_dv.DataPropertyName = "MADV";
            this.tchc_dv.HeaderText = "Mã DV";
            this.tchc_dv.MinimumWidth = 6;
            this.tchc_dv.Name = "tchc_dv";
            this.tchc_dv.ReadOnly = true;
            this.tchc_dv.Width = 117;
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 5;
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(52)))), ((int)(((byte)(184)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(179, 53);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 40);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BorderRadius = 5;
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(52)))), ((int)(((byte)(184)))));
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(46, 53);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(120, 40);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Thêm";
            this.btnCreate.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(52)))), ((int)(((byte)(184)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(313, 53);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // textRole
            // 
            this.textRole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textRole.DefaultText = "";
            this.textRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textRole.Location = new System.Drawing.Point(664, 53);
            this.textRole.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textRole.Name = "textRole";
            this.textRole.PlaceholderText = "Nhập tên nhân viên";
            this.textRole.SelectedText = "";
            this.textRole.Size = new System.Drawing.Size(438, 40);
            this.textRole.TabIndex = 4;
            this.textRole.TextChanged += new System.EventHandler(this.textRole_TextChanged);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.panelManageRoles);
            this.contentPanel.Location = new System.Drawing.Point(-3, 50);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1229, 665);
            this.contentPanel.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1150, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "";
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaximizeRestore
            // 
            this.btnMaximizeRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizeRestore.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximizeRestore.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximizeRestore.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.btnMaximizeRestore.ForeColor = System.Drawing.Color.White;
            this.btnMaximizeRestore.Location = new System.Drawing.Point(1088, 6);
            this.btnMaximizeRestore.Name = "btnMaximizeRestore";
            this.btnMaximizeRestore.Size = new System.Drawing.Size(56, 40);
            this.btnMaximizeRestore.TabIndex = 2;
            this.btnMaximizeRestore.Text = "";
            this.btnMaximizeRestore.UseTransparentBackground = true;
            this.btnMaximizeRestore.Click += new System.EventHandler(this.btnMaximizeRestore_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1034, 6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(48, 40);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "";
            this.btnMinimize.UseTransparentBackground = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // labelFormTitle
            // 
            this.labelFormTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormTitle.ForeColor = System.Drawing.Color.White;
            this.labelFormTitle.Location = new System.Drawing.Point(10, 10);
            this.labelFormTitle.Name = "labelFormTitle";
            this.labelFormTitle.Size = new System.Drawing.Size(687, 30);
            this.labelFormTitle.TabIndex = 0;
            this.labelFormTitle.Text = "Nhân viên Tổ chức hành chính";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.panelTitleBar.Controls.Add(this.labelFormTitle);
            this.panelTitleBar.Controls.Add(this.btnMinimize);
            this.panelTitleBar.Controls.Add(this.btnMaximizeRestore);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Location = new System.Drawing.Point(0, -2);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1449, 54);
            this.panelTitleBar.TabIndex = 1;
            // 
            // NV_TCHC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1224, 715);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NV_TCHC";
            this.Text = "Quản Lý Role";
            this.Load += new System.EventHandler(this.Role_Load);
            this.panelManageRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhanVien)).EndInit();
            this.contentPanel.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private Panel panelManageRoles;
        private Guna2Button btnEdit;
        private Guna2Button btnCreate;
        private Guna2Button btnDelete;
        private Guna2TextBox textRole;
        private Panel contentPanel;
        private Guna2Button btnClose;
        private Guna2Button btnMaximizeRestore;
        private Guna2Button btnMinimize;
        private Label labelFormTitle;
        private Panel panelTitleBar;
        private Guna2DataGridView dataGridViewNhanVien;
        private DataGridViewTextBoxColumn tchc_manv;
        private DataGridViewTextBoxColumn tchc_ht;
        private DataGridViewTextBoxColumn tchc_phai;
        private DataGridViewTextBoxColumn tchc_nsinh;
        private DataGridViewTextBoxColumn tchc_lg;
        private DataGridViewTextBoxColumn tchc_pc;
        private DataGridViewTextBoxColumn DT;
        private DataGridViewTextBoxColumn tchc_vt;
        private DataGridViewTextBoxColumn tchc_dv;
    }
}