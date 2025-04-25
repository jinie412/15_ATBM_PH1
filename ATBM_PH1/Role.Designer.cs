using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ATBM_PH1
{
    partial class Role
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnUserManagement = new Guna.UI2.WinForms.Guna2Button();
            this.btnRoleManagement = new Guna.UI2.WinForms.Guna2Button();
            this.btnPermissions = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2Button();
            this.btnMaximizeRestore = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnManageRolesTab = new Guna.UI2.WinForms.Guna2Button();
            this.btnGrantPermissionsTab = new Guna.UI2.WinForms.Guna2Button();
            this.btnRevokePermissionsTab = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewPermissionsTab = new Guna.UI2.WinForms.Guna2Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.panelManageRoles = new System.Windows.Forms.Panel();
            this.dataGridViewRoles = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.textRole = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.panelGrantPermissions = new System.Windows.Forms.Panel();
            this.dataGridViewGrantRoles = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelObjectType = new System.Windows.Forms.Label();
            this.comboBoxObjectType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboBoxObjectName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.checkBoxSelect = new Guna.UI2.WinForms.Guna2CheckBox();
            this.checkBoxInsert = new Guna.UI2.WinForms.Guna2CheckBox();
            this.checkBoxUpdate = new Guna.UI2.WinForms.Guna2CheckBox();
            this.checkBoxDelete = new Guna.UI2.WinForms.Guna2CheckBox();
            this.checkBoxWithGrantOption = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnGrantPermission = new Guna.UI2.WinForms.Guna2Button();
            this.panelSelectColumns = new System.Windows.Forms.FlowLayoutPanel();
            this.panelUpdateColumns = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRevokePermissions = new System.Windows.Forms.Panel();
            this.dataGridViewRevokeRoles = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxRevokeSelect = new Guna.UI2.WinForms.Guna2CheckBox();
            this.checkBoxRevokeInsert = new Guna.UI2.WinForms.Guna2CheckBox();
            this.checkBoxRevokeUpdate = new Guna.UI2.WinForms.Guna2CheckBox();
            this.checkBoxRevokeDelete = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnRevoke = new Guna.UI2.WinForms.Guna2Button();
            this.panelViewPermissions = new System.Windows.Forms.Panel();
            this.dataGridViewPermissions = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.panelSidebar.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.panelManageRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).BeginInit();
            this.panelGrantPermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrantRoles)).BeginInit();
            this.panelRevokePermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRevokeRoles)).BeginInit();
            this.panelViewPermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermissions)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.panelSidebar.Controls.Add(this.labelTitle);
            this.panelSidebar.Controls.Add(this.btnUserManagement);
            this.panelSidebar.Controls.Add(this.btnRoleManagement);
            this.panelSidebar.Controls.Add(this.btnPermissions);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(200, 715);
            this.panelSidebar.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(160, 40);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "TEAM 15";
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.FillColor = System.Drawing.Color.Transparent;
            this.btnUserManagement.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnUserManagement.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUserManagement.Location = new System.Drawing.Point(0, 100);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(200, 50);
            this.btnUserManagement.TabIndex = 1;
            this.btnUserManagement.Text = "Quản lý User";
            this.btnUserManagement.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // btnRoleManagement
            // 
            this.btnRoleManagement.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnRoleManagement.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRoleManagement.ForeColor = System.Drawing.Color.White;
            this.btnRoleManagement.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRoleManagement.Location = new System.Drawing.Point(0, 150);
            this.btnRoleManagement.Name = "btnRoleManagement";
            this.btnRoleManagement.Size = new System.Drawing.Size(200, 50);
            this.btnRoleManagement.TabIndex = 2;
            this.btnRoleManagement.Text = "Quản lý ROLE";
            this.btnRoleManagement.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnPermissions
            // 
            this.btnPermissions.FillColor = System.Drawing.Color.Transparent;
            this.btnPermissions.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPermissions.ForeColor = System.Drawing.Color.White;
            this.btnPermissions.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPermissions.Location = new System.Drawing.Point(0, 200);
            this.btnPermissions.Name = "btnPermissions";
            this.btnPermissions.Size = new System.Drawing.Size(200, 50);
            this.btnPermissions.TabIndex = 3;
            this.btnPermissions.Text = "Phân quyền";
            this.btnPermissions.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnLogout
            // 
            this.btnLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.Location = new System.Drawing.Point(0, 250);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 50);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.panelTitleBar.Controls.Add(this.labelFormTitle);
            this.panelTitleBar.Controls.Add(this.btnMinimize);
            this.panelTitleBar.Controls.Add(this.btnMaximizeRestore);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Location = new System.Drawing.Point(200, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1249, 44);
            this.panelTitleBar.TabIndex = 1;
            // 
            // labelFormTitle
            // 
            this.labelFormTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelFormTitle.ForeColor = System.Drawing.Color.White;
            this.labelFormTitle.Location = new System.Drawing.Point(10, 10);
            this.labelFormTitle.Name = "labelFormTitle";
            this.labelFormTitle.Size = new System.Drawing.Size(228, 30);
            this.labelFormTitle.TabIndex = 0;
            this.labelFormTitle.Text = "ROLE MANAGEMENT";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1117, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 40);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "";
            this.btnMinimize.UseTransparentBackground = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximizeRestore
            // 
            this.btnMaximizeRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizeRestore.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximizeRestore.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximizeRestore.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.btnMaximizeRestore.ForeColor = System.Drawing.Color.White;
            this.btnMaximizeRestore.Location = new System.Drawing.Point(1163, 3);
            this.btnMaximizeRestore.Name = "btnMaximizeRestore";
            this.btnMaximizeRestore.Size = new System.Drawing.Size(40, 40);
            this.btnMaximizeRestore.TabIndex = 2;
            this.btnMaximizeRestore.Text = "";
            this.btnMaximizeRestore.UseTransparentBackground = true;
            this.btnMaximizeRestore.Click += new System.EventHandler(this.btnMaximizeRestore_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1209, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "";
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnManageRolesTab
            // 
            this.btnManageRolesTab.FillColor = System.Drawing.Color.White;
            this.btnManageRolesTab.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnManageRolesTab.ForeColor = System.Drawing.Color.Black;
            this.btnManageRolesTab.Location = new System.Drawing.Point(210, 44);
            this.btnManageRolesTab.Name = "btnManageRolesTab";
            this.btnManageRolesTab.Size = new System.Drawing.Size(150, 40);
            this.btnManageRolesTab.TabIndex = 2;
            this.btnManageRolesTab.Text = "Quản Lý Role";
            this.btnManageRolesTab.Click += new System.EventHandler(this.btnManageRolesTab_Click);
            // 
            // btnGrantPermissionsTab
            // 
            this.btnGrantPermissionsTab.FillColor = System.Drawing.Color.Transparent;
            this.btnGrantPermissionsTab.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGrantPermissionsTab.ForeColor = System.Drawing.Color.Black;
            this.btnGrantPermissionsTab.Location = new System.Drawing.Point(360, 44);
            this.btnGrantPermissionsTab.Name = "btnGrantPermissionsTab";
            this.btnGrantPermissionsTab.Size = new System.Drawing.Size(150, 40);
            this.btnGrantPermissionsTab.TabIndex = 3;
            this.btnGrantPermissionsTab.Text = "Cấp Quyền";
            this.btnGrantPermissionsTab.Click += new System.EventHandler(this.btnGrantPermissionsTab_Click);
            // 
            // btnRevokePermissionsTab
            // 
            this.btnRevokePermissionsTab.FillColor = System.Drawing.Color.Transparent;
            this.btnRevokePermissionsTab.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRevokePermissionsTab.ForeColor = System.Drawing.Color.Black;
            this.btnRevokePermissionsTab.Location = new System.Drawing.Point(504, 44);
            this.btnRevokePermissionsTab.Name = "btnRevokePermissionsTab";
            this.btnRevokePermissionsTab.Size = new System.Drawing.Size(150, 40);
            this.btnRevokePermissionsTab.TabIndex = 4;
            this.btnRevokePermissionsTab.Text = "Thu Hồi Quyền";
            this.btnRevokePermissionsTab.Click += new System.EventHandler(this.btnRevokePermissionsTab_Click);
            // 
            // btnViewPermissionsTab
            // 
            this.btnViewPermissionsTab.FillColor = System.Drawing.Color.Transparent;
            this.btnViewPermissionsTab.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewPermissionsTab.ForeColor = System.Drawing.Color.Black;
            this.btnViewPermissionsTab.Location = new System.Drawing.Point(660, 44);
            this.btnViewPermissionsTab.Name = "btnViewPermissionsTab";
            this.btnViewPermissionsTab.Size = new System.Drawing.Size(150, 40);
            this.btnViewPermissionsTab.TabIndex = 5;
            this.btnViewPermissionsTab.Text = "Xem Quyền";
            this.btnViewPermissionsTab.Click += new System.EventHandler(this.btnViewPermissionsTab_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.panelManageRoles);
            this.contentPanel.Controls.Add(this.panelGrantPermissions);
            this.contentPanel.Controls.Add(this.panelRevokePermissions);
            this.contentPanel.Controls.Add(this.panelViewPermissions);
            this.contentPanel.Location = new System.Drawing.Point(210, 84);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1239, 631);
            this.contentPanel.TabIndex = 6;
            // 
            // panelManageRoles
            // 
            this.panelManageRoles.Controls.Add(this.btnEdit);
            this.panelManageRoles.Controls.Add(this.dataGridViewRoles);
            this.panelManageRoles.Controls.Add(this.btnCreate);
            this.panelManageRoles.Controls.Add(this.btnDelete);
            this.panelManageRoles.Controls.Add(this.textRole);
            this.panelManageRoles.Controls.Add(this.btnAddRole);
            this.panelManageRoles.Location = new System.Drawing.Point(0, 0);
            this.panelManageRoles.Name = "panelManageRoles";
            this.panelManageRoles.Size = new System.Drawing.Size(1239, 631);
            this.panelManageRoles.TabIndex = 0;
            // 
            // dataGridViewRoles
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dataGridViewRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            this.dataGridViewRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewRoles.ColumnHeadersHeight = 30;
            this.dataGridViewRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRoles.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewRoles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewRoles.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewRoles.Name = "dataGridViewRoles";
            this.dataGridViewRoles.RowHeadersVisible = false;
            this.dataGridViewRoles.RowHeadersWidth = 51;
            this.dataGridViewRoles.Size = new System.Drawing.Size(800, 400);
            this.dataGridViewRoles.TabIndex = 0;
            this.dataGridViewRoles.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewRoles.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewRoles.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewRoles.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewRoles.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewRoles.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewRoles.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewRoles.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewRoles.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewRoles.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataGridViewRoles.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewRoles.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewRoles.ThemeStyle.HeaderStyle.Height = 30;
            this.dataGridViewRoles.ThemeStyle.ReadOnly = false;
            this.dataGridViewRoles.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewRoles.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewRoles.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataGridViewRoles.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewRoles.ThemeStyle.RowsStyle.Height = 22;
            this.dataGridViewRoles.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewRoles.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên Role";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Quyền Được Cấp";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Mật Khẩu";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // btnCreate
            // 
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(840, 350);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(120, 40);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Tạo mới";
            this.btnCreate.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1107, 350);
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
            this.textRole.Location = new System.Drawing.Point(840, 20);
            this.textRole.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textRole.Name = "textRole";
            this.textRole.PlaceholderText = "Nhập tên Role";
            this.textRole.SelectedText = "";
            this.textRole.Size = new System.Drawing.Size(380, 40);
            this.textRole.TabIndex = 4;
            this.textRole.TextChanged += new System.EventHandler(this.textRole_TextChanged);
            // 
            // btnAddRole
            // 
            this.btnAddRole.BackColor = System.Drawing.Color.Green;
            this.btnAddRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRole.ForeColor = System.Drawing.Color.White;
            this.btnAddRole.Location = new System.Drawing.Point(37, 100);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(100, 40);
            this.btnAddRole.TabIndex = 5;
            this.btnAddRole.Text = "Thêm";
            this.btnAddRole.UseVisualStyleBackColor = false;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // panelGrantPermissions
            // 
            this.panelGrantPermissions.Controls.Add(this.dataGridViewGrantRoles);
            this.panelGrantPermissions.Controls.Add(this.labelObjectType);
            this.panelGrantPermissions.Controls.Add(this.comboBoxObjectType);
            this.panelGrantPermissions.Controls.Add(this.comboBoxObjectName);
            this.panelGrantPermissions.Controls.Add(this.checkBoxSelect);
            this.panelGrantPermissions.Controls.Add(this.checkBoxInsert);
            this.panelGrantPermissions.Controls.Add(this.checkBoxUpdate);
            this.panelGrantPermissions.Controls.Add(this.checkBoxDelete);
            this.panelGrantPermissions.Controls.Add(this.checkBoxWithGrantOption);
            this.panelGrantPermissions.Controls.Add(this.btnGrantPermission);
            this.panelGrantPermissions.Controls.Add(this.panelSelectColumns);
            this.panelGrantPermissions.Controls.Add(this.panelUpdateColumns);
            this.panelGrantPermissions.Location = new System.Drawing.Point(0, 0);
            this.panelGrantPermissions.Name = "panelGrantPermissions";
            this.panelGrantPermissions.Size = new System.Drawing.Size(1239, 631);
            this.panelGrantPermissions.TabIndex = 1;
            this.panelGrantPermissions.Visible = false;
            // 
            // dataGridViewGrantRoles
            // 
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.dataGridViewGrantRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            this.dataGridViewGrantRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewGrantRoles.ColumnHeadersHeight = 30;
            this.dataGridViewGrantRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewGrantRoles.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewGrantRoles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewGrantRoles.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewGrantRoles.Name = "dataGridViewGrantRoles";
            this.dataGridViewGrantRoles.RowHeadersVisible = false;
            this.dataGridViewGrantRoles.RowHeadersWidth = 51;
            this.dataGridViewGrantRoles.Size = new System.Drawing.Size(600, 450);
            this.dataGridViewGrantRoles.TabIndex = 0;
            this.dataGridViewGrantRoles.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewGrantRoles.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewGrantRoles.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewGrantRoles.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewGrantRoles.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewGrantRoles.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewGrantRoles.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewGrantRoles.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewGrantRoles.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewGrantRoles.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataGridViewGrantRoles.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewGrantRoles.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewGrantRoles.ThemeStyle.HeaderStyle.Height = 30;
            this.dataGridViewGrantRoles.ThemeStyle.ReadOnly = false;
            this.dataGridViewGrantRoles.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewGrantRoles.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewGrantRoles.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataGridViewGrantRoles.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewGrantRoles.ThemeStyle.RowsStyle.Height = 22;
            this.dataGridViewGrantRoles.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewGrantRoles.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewGrantRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGrantRoles_CellClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Tên Role";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // labelObjectType
            // 
            this.labelObjectType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelObjectType.Location = new System.Drawing.Point(640, 20);
            this.labelObjectType.Name = "labelObjectType";
            this.labelObjectType.Size = new System.Drawing.Size(100, 30);
            this.labelObjectType.TabIndex = 1;
            this.labelObjectType.Text = "Đối tượng:";
            // 
            // comboBoxObjectType
            // 
            this.comboBoxObjectType.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxObjectType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxObjectType.FocusedColor = System.Drawing.Color.Empty;
            this.comboBoxObjectType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxObjectType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxObjectType.ItemHeight = 30;
            this.comboBoxObjectType.Items.AddRange(new object[] {
            "TABLE",
            "VIEW",
            "PROCEDURE",
            "FUNCTION"});
            this.comboBoxObjectType.Location = new System.Drawing.Point(740, 20);
            this.comboBoxObjectType.Name = "comboBoxObjectType";
            this.comboBoxObjectType.Size = new System.Drawing.Size(200, 36);
            this.comboBoxObjectType.TabIndex = 2;
            this.comboBoxObjectType.SelectedIndexChanged += new System.EventHandler(this.comboBoxObjectType_SelectedIndexChanged);
            // 
            // comboBoxObjectName
            // 
            this.comboBoxObjectName.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxObjectName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxObjectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxObjectName.FocusedColor = System.Drawing.Color.Empty;
            this.comboBoxObjectName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxObjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBoxObjectName.ItemHeight = 30;
            this.comboBoxObjectName.Location = new System.Drawing.Point(740, 60);
            this.comboBoxObjectName.Name = "comboBoxObjectName";
            this.comboBoxObjectName.Size = new System.Drawing.Size(200, 36);
            this.comboBoxObjectName.TabIndex = 3;
            // 
            // checkBoxSelect
            // 
            this.checkBoxSelect.CheckedState.BorderRadius = 0;
            this.checkBoxSelect.CheckedState.BorderThickness = 0;
            this.checkBoxSelect.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxSelect.Location = new System.Drawing.Point(640, 100);
            this.checkBoxSelect.Name = "checkBoxSelect";
            this.checkBoxSelect.Size = new System.Drawing.Size(100, 30);
            this.checkBoxSelect.TabIndex = 4;
            this.checkBoxSelect.Text = "SELECT";
            this.checkBoxSelect.UncheckedState.BorderRadius = 0;
            this.checkBoxSelect.UncheckedState.BorderThickness = 0;
            this.checkBoxSelect.CheckedChanged += new System.EventHandler(this.checkBoxSelect_CheckedChanged);
            // 
            // checkBoxInsert
            // 
            this.checkBoxInsert.CheckedState.BorderRadius = 0;
            this.checkBoxInsert.CheckedState.BorderThickness = 0;
            this.checkBoxInsert.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxInsert.Location = new System.Drawing.Point(640, 140);
            this.checkBoxInsert.Name = "checkBoxInsert";
            this.checkBoxInsert.Size = new System.Drawing.Size(100, 30);
            this.checkBoxInsert.TabIndex = 5;
            this.checkBoxInsert.Text = "INSERT";
            this.checkBoxInsert.UncheckedState.BorderRadius = 0;
            this.checkBoxInsert.UncheckedState.BorderThickness = 0;
            // 
            // checkBoxUpdate
            // 
            this.checkBoxUpdate.CheckedState.BorderRadius = 0;
            this.checkBoxUpdate.CheckedState.BorderThickness = 0;
            this.checkBoxUpdate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxUpdate.Location = new System.Drawing.Point(640, 180);
            this.checkBoxUpdate.Name = "checkBoxUpdate";
            this.checkBoxUpdate.Size = new System.Drawing.Size(100, 30);
            this.checkBoxUpdate.TabIndex = 6;
            this.checkBoxUpdate.Text = "UPDATE";
            this.checkBoxUpdate.UncheckedState.BorderRadius = 0;
            this.checkBoxUpdate.UncheckedState.BorderThickness = 0;
            this.checkBoxUpdate.CheckedChanged += new System.EventHandler(this.checkBoxUpdate_CheckedChanged);
            // 
            // checkBoxDelete
            // 
            this.checkBoxDelete.CheckedState.BorderRadius = 0;
            this.checkBoxDelete.CheckedState.BorderThickness = 0;
            this.checkBoxDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxDelete.Location = new System.Drawing.Point(640, 220);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(100, 30);
            this.checkBoxDelete.TabIndex = 7;
            this.checkBoxDelete.Text = "DELETE";
            this.checkBoxDelete.UncheckedState.BorderRadius = 0;
            this.checkBoxDelete.UncheckedState.BorderThickness = 0;
            // 
            // checkBoxWithGrantOption
            // 
            this.checkBoxWithGrantOption.CheckedState.BorderRadius = 0;
            this.checkBoxWithGrantOption.CheckedState.BorderThickness = 0;
            this.checkBoxWithGrantOption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxWithGrantOption.Location = new System.Drawing.Point(640, 260);
            this.checkBoxWithGrantOption.Name = "checkBoxWithGrantOption";
            this.checkBoxWithGrantOption.Size = new System.Drawing.Size(200, 30);
            this.checkBoxWithGrantOption.TabIndex = 8;
            this.checkBoxWithGrantOption.Text = "WITH GRANT OPTION";
            this.checkBoxWithGrantOption.UncheckedState.BorderRadius = 0;
            this.checkBoxWithGrantOption.UncheckedState.BorderThickness = 0;
            // 
            // btnGrantPermission
            // 
            this.btnGrantPermission.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnGrantPermission.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGrantPermission.ForeColor = System.Drawing.Color.White;
            this.btnGrantPermission.Location = new System.Drawing.Point(640, 300);
            this.btnGrantPermission.Name = "btnGrantPermission";
            this.btnGrantPermission.Size = new System.Drawing.Size(120, 40);
            this.btnGrantPermission.TabIndex = 9;
            this.btnGrantPermission.Text = "Cấp quyền";
            this.btnGrantPermission.Click += new System.EventHandler(this.btnGrantPermission_Click);
            // 
            // panelSelectColumns
            // 
            this.panelSelectColumns.AutoScroll = true;
            this.panelSelectColumns.Location = new System.Drawing.Point(950, 100);
            this.panelSelectColumns.Name = "panelSelectColumns";
            this.panelSelectColumns.Size = new System.Drawing.Size(250, 150);
            this.panelSelectColumns.TabIndex = 10;
            this.panelSelectColumns.Visible = false;
            // 
            // panelUpdateColumns
            // 
            this.panelUpdateColumns.AutoScroll = true;
            this.panelUpdateColumns.Location = new System.Drawing.Point(950, 260);
            this.panelUpdateColumns.Name = "panelUpdateColumns";
            this.panelUpdateColumns.Size = new System.Drawing.Size(250, 150);
            this.panelUpdateColumns.TabIndex = 11;
            this.panelUpdateColumns.Visible = false;
            // 
            // panelRevokePermissions
            // 
            this.panelRevokePermissions.Controls.Add(this.dataGridViewRevokeRoles);
            this.panelRevokePermissions.Controls.Add(this.checkBoxRevokeSelect);
            this.panelRevokePermissions.Controls.Add(this.checkBoxRevokeInsert);
            this.panelRevokePermissions.Controls.Add(this.checkBoxRevokeUpdate);
            this.panelRevokePermissions.Controls.Add(this.checkBoxRevokeDelete);
            this.panelRevokePermissions.Controls.Add(this.btnRevoke);
            this.panelRevokePermissions.Location = new System.Drawing.Point(0, 0);
            this.panelRevokePermissions.Name = "panelRevokePermissions";
            this.panelRevokePermissions.Size = new System.Drawing.Size(1239, 631);
            this.panelRevokePermissions.TabIndex = 2;
            this.panelRevokePermissions.Visible = false;
            // 
            // dataGridViewRevokeRoles
            // 
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            this.dataGridViewRevokeRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            this.dataGridViewRevokeRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewRevokeRoles.ColumnHeadersHeight = 30;
            this.dataGridViewRevokeRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRevokeRoles.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewRevokeRoles.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewRevokeRoles.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewRevokeRoles.Name = "dataGridViewRevokeRoles";
            this.dataGridViewRevokeRoles.RowHeadersVisible = false;
            this.dataGridViewRevokeRoles.RowHeadersWidth = 51;
            this.dataGridViewRevokeRoles.Size = new System.Drawing.Size(600, 450);
            this.dataGridViewRevokeRoles.TabIndex = 0;
            this.dataGridViewRevokeRoles.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewRevokeRoles.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewRevokeRoles.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewRevokeRoles.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewRevokeRoles.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewRevokeRoles.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewRevokeRoles.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewRevokeRoles.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewRevokeRoles.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewRevokeRoles.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataGridViewRevokeRoles.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewRevokeRoles.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewRevokeRoles.ThemeStyle.HeaderStyle.Height = 30;
            this.dataGridViewRevokeRoles.ThemeStyle.ReadOnly = false;
            this.dataGridViewRevokeRoles.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewRevokeRoles.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewRevokeRoles.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataGridViewRevokeRoles.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewRevokeRoles.ThemeStyle.RowsStyle.Height = 22;
            this.dataGridViewRevokeRoles.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewRevokeRoles.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewRevokeRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRevokeRoles_CellClick);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Tên Role";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // checkBoxRevokeSelect
            // 
            this.checkBoxRevokeSelect.CheckedState.BorderRadius = 0;
            this.checkBoxRevokeSelect.CheckedState.BorderThickness = 0;
            this.checkBoxRevokeSelect.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxRevokeSelect.Location = new System.Drawing.Point(640, 100);
            this.checkBoxRevokeSelect.Name = "checkBoxRevokeSelect";
            this.checkBoxRevokeSelect.Size = new System.Drawing.Size(100, 30);
            this.checkBoxRevokeSelect.TabIndex = 1;
            this.checkBoxRevokeSelect.Text = "SELECT";
            this.checkBoxRevokeSelect.UncheckedState.BorderRadius = 0;
            this.checkBoxRevokeSelect.UncheckedState.BorderThickness = 0;
            // 
            // checkBoxRevokeInsert
            // 
            this.checkBoxRevokeInsert.CheckedState.BorderRadius = 0;
            this.checkBoxRevokeInsert.CheckedState.BorderThickness = 0;
            this.checkBoxRevokeInsert.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxRevokeInsert.Location = new System.Drawing.Point(640, 140);
            this.checkBoxRevokeInsert.Name = "checkBoxRevokeInsert";
            this.checkBoxRevokeInsert.Size = new System.Drawing.Size(100, 30);
            this.checkBoxRevokeInsert.TabIndex = 2;
            this.checkBoxRevokeInsert.Text = "INSERT";
            this.checkBoxRevokeInsert.UncheckedState.BorderRadius = 0;
            this.checkBoxRevokeInsert.UncheckedState.BorderThickness = 0;
            // 
            // checkBoxRevokeUpdate
            // 
            this.checkBoxRevokeUpdate.CheckedState.BorderRadius = 0;
            this.checkBoxRevokeUpdate.CheckedState.BorderThickness = 0;
            this.checkBoxRevokeUpdate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxRevokeUpdate.Location = new System.Drawing.Point(640, 180);
            this.checkBoxRevokeUpdate.Name = "checkBoxRevokeUpdate";
            this.checkBoxRevokeUpdate.Size = new System.Drawing.Size(100, 30);
            this.checkBoxRevokeUpdate.TabIndex = 3;
            this.checkBoxRevokeUpdate.Text = "UPDATE";
            this.checkBoxRevokeUpdate.UncheckedState.BorderRadius = 0;
            this.checkBoxRevokeUpdate.UncheckedState.BorderThickness = 0;
            // 
            // checkBoxRevokeDelete
            // 
            this.checkBoxRevokeDelete.CheckedState.BorderRadius = 0;
            this.checkBoxRevokeDelete.CheckedState.BorderThickness = 0;
            this.checkBoxRevokeDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.checkBoxRevokeDelete.Location = new System.Drawing.Point(640, 220);
            this.checkBoxRevokeDelete.Name = "checkBoxRevokeDelete";
            this.checkBoxRevokeDelete.Size = new System.Drawing.Size(100, 30);
            this.checkBoxRevokeDelete.TabIndex = 4;
            this.checkBoxRevokeDelete.Text = "DELETE";
            this.checkBoxRevokeDelete.UncheckedState.BorderRadius = 0;
            this.checkBoxRevokeDelete.UncheckedState.BorderThickness = 0;
            // 
            // btnRevoke
            // 
            this.btnRevoke.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnRevoke.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRevoke.ForeColor = System.Drawing.Color.White;
            this.btnRevoke.Location = new System.Drawing.Point(640, 260);
            this.btnRevoke.Name = "btnRevoke";
            this.btnRevoke.Size = new System.Drawing.Size(120, 40);
            this.btnRevoke.TabIndex = 5;
            this.btnRevoke.Text = "Thu Hồi";
            this.btnRevoke.Click += new System.EventHandler(this.btnRevoke_Click);
            // 
            // panelViewPermissions
            // 
            this.panelViewPermissions.Controls.Add(this.dataGridViewPermissions);
            this.panelViewPermissions.Location = new System.Drawing.Point(0, 0);
            this.panelViewPermissions.Name = "panelViewPermissions";
            this.panelViewPermissions.Size = new System.Drawing.Size(1239, 631);
            this.panelViewPermissions.TabIndex = 3;
            this.panelViewPermissions.Visible = false;
            // 
            // dataGridViewPermissions
            // 
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            this.dataGridViewPermissions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            this.dataGridViewPermissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewPermissions.ColumnHeadersHeight = 30;
            this.dataGridViewPermissions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPermissions.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewPermissions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewPermissions.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewPermissions.Name = "dataGridViewPermissions";
            this.dataGridViewPermissions.RowHeadersVisible = false;
            this.dataGridViewPermissions.RowHeadersWidth = 51;
            this.dataGridViewPermissions.Size = new System.Drawing.Size(800, 450);
            this.dataGridViewPermissions.TabIndex = 0;
            this.dataGridViewPermissions.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewPermissions.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewPermissions.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewPermissions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewPermissions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewPermissions.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewPermissions.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewPermissions.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewPermissions.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewPermissions.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataGridViewPermissions.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewPermissions.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPermissions.ThemeStyle.HeaderStyle.Height = 30;
            this.dataGridViewPermissions.ThemeStyle.ReadOnly = false;
            this.dataGridViewPermissions.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewPermissions.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewPermissions.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dataGridViewPermissions.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewPermissions.ThemeStyle.RowsStyle.Height = 22;
            this.dataGridViewPermissions.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewPermissions.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Tên bảng";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "SELECT";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "INSERT";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "UPDATE";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "DELETE";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // btnEdit
            // 
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(974, 350);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 40);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // Role
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1449, 715);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.btnViewPermissionsTab);
            this.Controls.Add(this.btnRevokePermissionsTab);
            this.Controls.Add(this.btnGrantPermissionsTab);
            this.Controls.Add(this.btnManageRolesTab);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Role";
            this.Text = "Quản Lý Role";
            this.Load += new System.EventHandler(this.Role_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.panelManageRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).EndInit();
            this.panelGrantPermissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrantRoles)).EndInit();
            this.panelRevokePermissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRevokeRoles)).EndInit();
            this.panelViewPermissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermissions)).EndInit();
            this.ResumeLayout(false);

        }

        // Declare Sidebar Components
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Button btnUserManagement;
        private Guna.UI2.WinForms.Guna2Button btnRoleManagement;
        private Guna.UI2.WinForms.Guna2Button btnPermissions;
        private Guna.UI2.WinForms.Guna2Button btnLogout;

        // Declare Title Bar Components
        private System.Windows.Forms.Panel panelTitleBar;
        private Guna.UI2.WinForms.Guna2Button btnMinimize;
        private Guna.UI2.WinForms.Guna2Button btnMaximizeRestore;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label labelFormTitle;
        private System.Windows.Forms.Button btnAddRole;

        // Tab Buttons
        private Guna.UI2.WinForms.Guna2Button btnManageRolesTab;
        private Guna.UI2.WinForms.Guna2Button btnGrantPermissionsTab;
        private Guna.UI2.WinForms.Guna2Button btnRevokePermissionsTab;
        private Guna.UI2.WinForms.Guna2Button btnViewPermissionsTab;

        // Content Panels
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel panelManageRoles;
        private System.Windows.Forms.Panel panelGrantPermissions;
        private System.Windows.Forms.Panel panelRevokePermissions;
        private System.Windows.Forms.Panel panelViewPermissions;

        // Manage Roles Components
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewRoles;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2TextBox textRole;

        // Grant Permissions Components
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewGrantRoles;
        private System.Windows.Forms.Label labelObjectType;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxObjectType;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxObjectName;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxSelect;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxInsert;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxUpdate;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxDelete;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxWithGrantOption;
        private Guna.UI2.WinForms.Guna2Button btnGrantPermission;
        private System.Windows.Forms.FlowLayoutPanel panelSelectColumns;
        private System.Windows.Forms.FlowLayoutPanel panelUpdateColumns;

        // Revoke Permissions Components
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewRevokeRoles;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxRevokeSelect;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxRevokeInsert;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxRevokeUpdate;
        private Guna.UI2.WinForms.Guna2CheckBox checkBoxRevokeDelete;
        private Guna.UI2.WinForms.Guna2Button btnRevoke;

        // View Permissions Components
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewPermissions;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private Guna2Button btnEdit;
    }
}