using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM_PH1
{
    partial class NV_PKT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelManageRoles = new System.Windows.Forms.Panel();
            this.dataGridViewDiem = new Guna.UI2.WinForms.Guna2DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kt_masv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kt_mm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kt_dth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kt_dqt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kt_dck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kt_dtk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.textRole = new Guna.UI2.WinForms.Guna2TextBox();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaximizeRestore = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.panelManageRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiem)).BeginInit();
            this.contentPanel.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelManageRoles
            // 
            this.panelManageRoles.Controls.Add(this.dataGridViewDiem);
            this.panelManageRoles.Controls.Add(this.btnEdit);
            this.panelManageRoles.Controls.Add(this.textRole);
            this.panelManageRoles.Location = new System.Drawing.Point(57, 34);
            this.panelManageRoles.Name = "panelManageRoles";
            this.panelManageRoles.Size = new System.Drawing.Size(1137, 587);
            this.panelManageRoles.TabIndex = 0;
            // 
            // dataGridViewDiem
            // 
            this.dataGridViewDiem.AllowUserToAddRows = false;
            this.dataGridViewDiem.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dataGridViewDiem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewDiem.ColumnHeadersHeight = 40;
            this.dataGridViewDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.kt_masv,
            this.kt_mm,
            this.kt_dth,
            this.kt_dqt,
            this.kt_dck,
            this.kt_dtk});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDiem.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewDiem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewDiem.Location = new System.Drawing.Point(46, 140);
            this.dataGridViewDiem.Name = "dataGridViewDiem";
            this.dataGridViewDiem.ReadOnly = true;
            this.dataGridViewDiem.RowHeadersVisible = false;
            this.dataGridViewDiem.RowHeadersWidth = 60;
            this.dataGridViewDiem.RowTemplate.Height = 30;
            this.dataGridViewDiem.Size = new System.Drawing.Size(1056, 408);
            this.dataGridViewDiem.TabIndex = 9;
            this.dataGridViewDiem.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewDiem.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewDiem.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewDiem.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewDiem.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewDiem.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewDiem.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewDiem.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewDiem.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewDiem.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewDiem.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewDiem.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewDiem.ThemeStyle.HeaderStyle.Height = 40;
            this.dataGridViewDiem.ThemeStyle.ReadOnly = true;
            this.dataGridViewDiem.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewDiem.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewDiem.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewDiem.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewDiem.ThemeStyle.RowsStyle.Height = 30;
            this.dataGridViewDiem.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewDiem.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 125;
            // 
            // kt_masv
            // 
            this.kt_masv.DataPropertyName = "MASV";
            this.kt_masv.HeaderText = "Mã SV";
            this.kt_masv.MinimumWidth = 6;
            this.kt_masv.Name = "kt_masv";
            this.kt_masv.ReadOnly = true;
            this.kt_masv.Width = 117;
            // 
            // kt_mm
            // 
            this.kt_mm.DataPropertyName = "MAMM";
            this.kt_mm.HeaderText = "Mã MM";
            this.kt_mm.MinimumWidth = 6;
            this.kt_mm.Name = "kt_mm";
            this.kt_mm.ReadOnly = true;
            this.kt_mm.Width = 118;
            // 
            // kt_dth
            // 
            this.kt_dth.DataPropertyName = "DIEMTH";
            this.kt_dth.HeaderText = "Điểm TH";
            this.kt_dth.MinimumWidth = 6;
            this.kt_dth.Name = "kt_dth";
            this.kt_dth.ReadOnly = true;
            this.kt_dth.Width = 117;
            // 
            // kt_dqt
            // 
            this.kt_dqt.DataPropertyName = "DIEMQT";
            this.kt_dqt.HeaderText = "Điểm QT";
            this.kt_dqt.MinimumWidth = 6;
            this.kt_dqt.Name = "kt_dqt";
            this.kt_dqt.ReadOnly = true;
            this.kt_dqt.Width = 117;
            // 
            // kt_dck
            // 
            this.kt_dck.DataPropertyName = "DIEMCK";
            this.kt_dck.HeaderText = "Điểm CK";
            this.kt_dck.MinimumWidth = 6;
            this.kt_dck.Name = "kt_dck";
            this.kt_dck.ReadOnly = true;
            this.kt_dck.Width = 118;
            // 
            // kt_dtk
            // 
            this.kt_dtk.DataPropertyName = "DIEMTK";
            this.kt_dtk.HeaderText = "Điểm TK";
            this.kt_dtk.MinimumWidth = 6;
            this.kt_dtk.Name = "kt_dtk";
            this.kt_dtk.ReadOnly = true;
            this.kt_dtk.Width = 117;
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 5;
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(52)))), ((int)(((byte)(184)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(46, 53);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 40);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // textRole
            // 
            this.textRole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textRole.DefaultText = "";
            this.textRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textRole.Location = new System.Drawing.Point(661, 53);
            this.textRole.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textRole.Name = "textRole";
            this.textRole.PlaceholderText = "Nhập mã sinh viên";
            this.textRole.SelectedText = "";
            this.textRole.Size = new System.Drawing.Size(406, 40);
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
            this.labelFormTitle.Size = new System.Drawing.Size(575, 30);
            this.labelFormTitle.TabIndex = 0;
            this.labelFormTitle.Text = "Nhân viên Phòng khảo thí";
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
            // NV_PKT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1224, 715);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NV_PKT";
            this.Text = "Quản Lý Role";
            this.Load += new System.EventHandler(this.Role_Load);
            this.panelManageRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiem)).EndInit();
            this.contentPanel.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private Panel panelManageRoles;
        private Guna2Button btnEdit;
        private Guna2TextBox textRole;
        private Panel contentPanel;
        private Guna2Button btnClose;
        private Guna2Button btnMaximizeRestore;
        private Guna2Button btnMinimize;
        private Label labelFormTitle;
        private Panel panelTitleBar;
        private Guna2DataGridView dataGridViewDiem;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn kt_masv;
        private DataGridViewTextBoxColumn kt_mm;
        private DataGridViewTextBoxColumn kt_dth;
        private DataGridViewTextBoxColumn kt_dqt;
        private DataGridViewTextBoxColumn kt_dck;
        private DataGridViewTextBoxColumn kt_dtk;
    }
}