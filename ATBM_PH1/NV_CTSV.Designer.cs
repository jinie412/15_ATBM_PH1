using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM_PH1
{
    partial class NV_CTSV
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
            this.dataGridViewSinhVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSinhVien)).BeginInit();
            this.contentPanel.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelManageRoles
            // 
            this.panelManageRoles.Controls.Add(this.dataGridViewSinhVien);
            this.panelManageRoles.Controls.Add(this.btnEdit);
            this.panelManageRoles.Controls.Add(this.btnCreate);
            this.panelManageRoles.Controls.Add(this.btnDelete);
            this.panelManageRoles.Controls.Add(this.textRole);
            this.panelManageRoles.Location = new System.Drawing.Point(57, 34);
            this.panelManageRoles.Name = "panelManageRoles";
            this.panelManageRoles.Size = new System.Drawing.Size(1137, 587);
            this.panelManageRoles.TabIndex = 0;
            // 
            // dataGridViewSinhVien
            // 
            this.dataGridViewSinhVien.AllowUserToDeleteRows = false;
            this.dataGridViewSinhVien.AllowUserToResizeColumns = false;
            this.dataGridViewSinhVien.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewSinhVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewSinhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSinhVien.ColumnHeadersHeight = 35;
            this.dataGridViewSinhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stt});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSinhVien.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSinhVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewSinhVien.Location = new System.Drawing.Point(46, 122);
            this.dataGridViewSinhVien.Name = "dataGridViewSinhVien";
            this.dataGridViewSinhVien.RowHeadersVisible = false;
            this.dataGridViewSinhVien.RowHeadersWidth = 51;
            this.dataGridViewSinhVien.Size = new System.Drawing.Size(1021, 445);
            this.dataGridViewSinhVien.TabIndex = 0;
            this.dataGridViewSinhVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewSinhVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewSinhVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewSinhVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewSinhVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewSinhVien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewSinhVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewSinhVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewSinhVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewSinhVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataGridViewSinhVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewSinhVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSinhVien.ThemeStyle.HeaderStyle.Height = 35;
            this.dataGridViewSinhVien.ThemeStyle.ReadOnly = false;
            this.dataGridViewSinhVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewSinhVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewSinhVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataGridViewSinhVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewSinhVien.ThemeStyle.RowsStyle.Height = 22;
            this.dataGridViewSinhVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewSinhVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // stt
            // 
            this.stt.HeaderText = "STT";
            this.stt.MinimumWidth = 6;
            this.stt.Name = "stt";
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
            this.btnCreate.Text = "Thêm mới";
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
            this.textRole.PlaceholderText = "Nhập tên sinh viên";
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
            this.labelFormTitle.Size = new System.Drawing.Size(343, 30);
            this.labelFormTitle.TabIndex = 0;
            this.labelFormTitle.Text = "Nhân viên Công tác sinh viên";
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
            // NV_CTSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1224, 715);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NV_CTSV";
            this.Text = "Quản Lý Role";
            this.Load += new System.EventHandler(this.Role_Load);
            this.panelManageRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSinhVien)).EndInit();
            this.contentPanel.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private Panel panelManageRoles;
        private Guna2DataGridView dataGridViewSinhVien;
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
        private DataGridViewTextBoxColumn stt;

    }
}