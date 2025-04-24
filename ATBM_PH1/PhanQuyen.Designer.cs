namespace ATBM_PH1
{
    partial class PhanQuyen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGrant = new Guna.UI2.WinForms.Guna2Button();
            this.btnRevoke = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label1 = new System.Windows.Forms.Label();
            this.tablePrivs = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.colPrivs = new Guna.UI2.WinForms.Guna2DataGridView();
            this.checkCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colGrantee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSchema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPriv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrantable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGrantee = new Guna.UI2.WinForms.Guna2TextBox();
            this.rolePrivs = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblSelected = new System.Windows.Forms.Label();
            this.checkTab = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabGrantee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPriv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabGrantable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.checkRole = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.roleGrantee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tablePrivs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colPrivs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolePrivs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrant
            // 
            this.btnGrant.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGrant.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGrant.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGrant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGrant.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGrant.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrant.ForeColor = System.Drawing.Color.Black;
            this.btnGrant.Location = new System.Drawing.Point(877, 65);
            this.btnGrant.Name = "btnGrant";
            this.btnGrant.Size = new System.Drawing.Size(110, 45);
            this.btnGrant.TabIndex = 1;
            this.btnGrant.Text = "Cấp quyền";
            // 
            // btnRevoke
            // 
            this.btnRevoke.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRevoke.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRevoke.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRevoke.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRevoke.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRevoke.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevoke.ForeColor = System.Drawing.Color.Black;
            this.btnRevoke.Location = new System.Drawing.Point(1008, 65);
            this.btnRevoke.Name = "btnRevoke";
            this.btnRevoke.Size = new System.Drawing.Size(110, 45);
            this.btnRevoke.TabIndex = 1;
            this.btnRevoke.Text = "Thu hồi";
            this.btnRevoke.Click += new System.EventHandler(this.btnRevoke_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(33, 44);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1085, 14);
            this.guna2Separator1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Phân quyền";
            // 
            // tablePrivs
            // 
            this.tablePrivs.AllowUserToAddRows = false;
            this.tablePrivs.AllowUserToDeleteRows = false;
            this.tablePrivs.AllowUserToResizeColumns = false;
            this.tablePrivs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.tablePrivs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablePrivs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tablePrivs.ColumnHeadersHeight = 40;
            this.tablePrivs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkTab,
            this.tabGrantee,
            this.tabOwner,
            this.tabTable,
            this.tabPriv,
            this.tabGrantable,
            this.tabType});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablePrivs.DefaultCellStyle = dataGridViewCellStyle3;
            this.tablePrivs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablePrivs.Location = new System.Drawing.Point(33, 176);
            this.tablePrivs.Name = "tablePrivs";
            this.tablePrivs.ReadOnly = true;
            this.tablePrivs.RowHeadersVisible = false;
            this.tablePrivs.RowHeadersWidth = 51;
            this.tablePrivs.RowTemplate.Height = 24;
            this.tablePrivs.Size = new System.Drawing.Size(819, 170);
            this.tablePrivs.TabIndex = 5;
            this.tablePrivs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tablePrivs.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tablePrivs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tablePrivs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tablePrivs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tablePrivs.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tablePrivs.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablePrivs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.tablePrivs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tablePrivs.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablePrivs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.tablePrivs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tablePrivs.ThemeStyle.HeaderStyle.Height = 40;
            this.tablePrivs.ThemeStyle.ReadOnly = true;
            this.tablePrivs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tablePrivs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tablePrivs.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablePrivs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablePrivs.ThemeStyle.RowsStyle.Height = 24;
            this.tablePrivs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablePrivs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tablePrivs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablePrivs_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(873, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Role của user";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cột";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1082, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(36, 29);
            this.guna2ControlBox1.TabIndex = 7;
            // 
            // colPrivs
            // 
            this.colPrivs.AllowUserToAddRows = false;
            this.colPrivs.AllowUserToDeleteRows = false;
            this.colPrivs.AllowUserToResizeColumns = false;
            this.colPrivs.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.colPrivs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colPrivs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.colPrivs.ColumnHeadersHeight = 40;
            this.colPrivs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkCol,
            this.colGrantee,
            this.colSchema,
            this.colTable,
            this.colCol,
            this.colPriv,
            this.colGrantable});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colPrivs.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPrivs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.colPrivs.Location = new System.Drawing.Point(33, 401);
            this.colPrivs.Name = "colPrivs";
            this.colPrivs.ReadOnly = true;
            this.colPrivs.RowHeadersVisible = false;
            this.colPrivs.RowHeadersWidth = 51;
            this.colPrivs.RowTemplate.Height = 24;
            this.colPrivs.Size = new System.Drawing.Size(819, 170);
            this.colPrivs.TabIndex = 5;
            this.colPrivs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.colPrivs.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.colPrivs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.colPrivs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.colPrivs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.colPrivs.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.colPrivs.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.colPrivs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.colPrivs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.colPrivs.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPrivs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.colPrivs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.colPrivs.ThemeStyle.HeaderStyle.Height = 40;
            this.colPrivs.ThemeStyle.ReadOnly = true;
            this.colPrivs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.colPrivs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.colPrivs.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPrivs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.colPrivs.ThemeStyle.RowsStyle.Height = 24;
            this.colPrivs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.colPrivs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.colPrivs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.colPrivs_CellContentClick);
            // 
            // checkCol
            // 
            this.checkCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.checkCol.FillWeight = 40F;
            this.checkCol.HeaderText = "";
            this.checkCol.MinimumWidth = 40;
            this.checkCol.Name = "checkCol";
            this.checkCol.ReadOnly = true;
            this.checkCol.Width = 40;
            // 
            // colGrantee
            // 
            this.colGrantee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colGrantee.DataPropertyName = "GRANTEE";
            this.colGrantee.HeaderText = "GRANTEE";
            this.colGrantee.MinimumWidth = 100;
            this.colGrantee.Name = "colGrantee";
            this.colGrantee.ReadOnly = true;
            this.colGrantee.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colGrantee.Width = 125;
            // 
            // colSchema
            // 
            this.colSchema.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSchema.DataPropertyName = "TABLE_SCHEMA";
            this.colSchema.FillWeight = 125F;
            this.colSchema.HeaderText = "TABLE_SCHEMA";
            this.colSchema.MinimumWidth = 125;
            this.colSchema.Name = "colSchema";
            this.colSchema.ReadOnly = true;
            this.colSchema.Width = 125;
            // 
            // colTable
            // 
            this.colTable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTable.DataPropertyName = "TABLE_NAME";
            this.colTable.FillWeight = 125F;
            this.colTable.HeaderText = "TABLE_NAME";
            this.colTable.MinimumWidth = 125;
            this.colTable.Name = "colTable";
            this.colTable.ReadOnly = true;
            this.colTable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTable.Width = 125;
            // 
            // colCol
            // 
            this.colCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCol.DataPropertyName = "COLUMN_NAME";
            this.colCol.FillWeight = 125F;
            this.colCol.HeaderText = "COLUMN";
            this.colCol.MinimumWidth = 125;
            this.colCol.Name = "colCol";
            this.colCol.ReadOnly = true;
            this.colCol.Width = 125;
            // 
            // colPriv
            // 
            this.colPriv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPriv.DataPropertyName = "PRIVILEGE";
            this.colPriv.FillWeight = 90F;
            this.colPriv.HeaderText = "PRIVILEGE";
            this.colPriv.MinimumWidth = 90;
            this.colPriv.Name = "colPriv";
            this.colPriv.ReadOnly = true;
            this.colPriv.Width = 90;
            // 
            // colGrantable
            // 
            this.colGrantable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGrantable.DataPropertyName = "GRANTABLE";
            this.colGrantable.FillWeight = 80F;
            this.colGrantable.HeaderText = "GRANTABLE";
            this.colGrantable.MinimumWidth = 80;
            this.colGrantable.Name = "colGrantable";
            this.colGrantable.ReadOnly = true;
            // 
            // txtGrantee
            // 
            this.txtGrantee.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGrantee.DefaultText = "";
            this.txtGrantee.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGrantee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGrantee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGrantee.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGrantee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGrantee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGrantee.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGrantee.IconRight = global::ATBM_PH1.Properties.Resources.search;
            this.txtGrantee.Location = new System.Drawing.Point(33, 65);
            this.txtGrantee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGrantee.Name = "txtGrantee";
            this.txtGrantee.PlaceholderText = "Tìm kiếm";
            this.txtGrantee.SelectedText = "";
            this.txtGrantee.Size = new System.Drawing.Size(229, 45);
            this.txtGrantee.TabIndex = 2;
            this.txtGrantee.IconRightClick += new System.EventHandler(this.txtGrantee_IconRightClick);
            // 
            // rolePrivs
            // 
            this.rolePrivs.AllowUserToAddRows = false;
            this.rolePrivs.AllowUserToDeleteRows = false;
            this.rolePrivs.AllowUserToResizeColumns = false;
            this.rolePrivs.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.rolePrivs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rolePrivs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.rolePrivs.ColumnHeadersHeight = 40;
            this.rolePrivs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkRole,
            this.roleGrantee,
            this.dgvRole});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rolePrivs.DefaultCellStyle = dataGridViewCellStyle9;
            this.rolePrivs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.rolePrivs.Location = new System.Drawing.Point(877, 176);
            this.rolePrivs.Name = "rolePrivs";
            this.rolePrivs.ReadOnly = true;
            this.rolePrivs.RowHeadersVisible = false;
            this.rolePrivs.RowHeadersWidth = 51;
            this.rolePrivs.RowTemplate.Height = 24;
            this.rolePrivs.Size = new System.Drawing.Size(241, 395);
            this.rolePrivs.TabIndex = 5;
            this.rolePrivs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.rolePrivs.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.rolePrivs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.rolePrivs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.rolePrivs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.rolePrivs.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.rolePrivs.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.rolePrivs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.rolePrivs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.rolePrivs.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolePrivs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.rolePrivs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.rolePrivs.ThemeStyle.HeaderStyle.Height = 40;
            this.rolePrivs.ThemeStyle.ReadOnly = true;
            this.rolePrivs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.rolePrivs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.rolePrivs.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolePrivs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.rolePrivs.ThemeStyle.RowsStyle.Height = 24;
            this.rolePrivs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.rolePrivs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.rolePrivs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rolePrivs_CellContentClick);
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.Location = new System.Drawing.Point(301, 85);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(57, 25);
            this.lblSelected.TabIndex = 8;
            this.lblSelected.Text = "User";
            this.lblSelected.Visible = false;
            // 
            // checkTab
            // 
            this.checkTab.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.checkTab.FillWeight = 30F;
            this.checkTab.HeaderText = "";
            this.checkTab.MinimumWidth = 30;
            this.checkTab.Name = "checkTab";
            this.checkTab.ReadOnly = true;
            this.checkTab.Width = 30;
            // 
            // tabGrantee
            // 
            this.tabGrantee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tabGrantee.DataPropertyName = "GRANTEE";
            this.tabGrantee.HeaderText = "GRANTEE";
            this.tabGrantee.MinimumWidth = 90;
            this.tabGrantee.Name = "tabGrantee";
            this.tabGrantee.ReadOnly = true;
            this.tabGrantee.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tabGrantee.Width = 90;
            // 
            // tabOwner
            // 
            this.tabOwner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tabOwner.DataPropertyName = "OWNER";
            this.tabOwner.FillWeight = 80F;
            this.tabOwner.HeaderText = "OWNER";
            this.tabOwner.MinimumWidth = 80;
            this.tabOwner.Name = "tabOwner";
            this.tabOwner.ReadOnly = true;
            this.tabOwner.Width = 80;
            // 
            // tabTable
            // 
            this.tabTable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tabTable.DataPropertyName = "TABLE_NAME";
            this.tabTable.FillWeight = 125F;
            this.tabTable.HeaderText = "TABLE_NAME";
            this.tabTable.MinimumWidth = 150;
            this.tabTable.Name = "tabTable";
            this.tabTable.ReadOnly = true;
            this.tabTable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.tabTable.Width = 150;
            // 
            // tabPriv
            // 
            this.tabPriv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tabPriv.DataPropertyName = "PRIVILEGE";
            this.tabPriv.FillWeight = 80F;
            this.tabPriv.HeaderText = "PRIVILEGE";
            this.tabPriv.MinimumWidth = 80;
            this.tabPriv.Name = "tabPriv";
            this.tabPriv.ReadOnly = true;
            this.tabPriv.Width = 80;
            // 
            // tabGrantable
            // 
            this.tabGrantable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tabGrantable.DataPropertyName = "GRANTABLE";
            this.tabGrantable.FillWeight = 90F;
            this.tabGrantable.HeaderText = "GRANTABLE";
            this.tabGrantable.MinimumWidth = 90;
            this.tabGrantable.Name = "tabGrantable";
            this.tabGrantable.ReadOnly = true;
            this.tabGrantable.Width = 90;
            // 
            // tabType
            // 
            this.tabType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tabType.DataPropertyName = "TYPE";
            this.tabType.HeaderText = "TYPE";
            this.tabType.MinimumWidth = 100;
            this.tabType.Name = "tabType";
            this.tabType.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bảng / View";
            // 
            // checkRole
            // 
            this.checkRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.checkRole.FillWeight = 25F;
            this.checkRole.HeaderText = "";
            this.checkRole.MinimumWidth = 25;
            this.checkRole.Name = "checkRole";
            this.checkRole.ReadOnly = true;
            this.checkRole.Width = 25;
            // 
            // roleGrantee
            // 
            this.roleGrantee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.roleGrantee.DataPropertyName = "GRANTEE";
            this.roleGrantee.FillWeight = 80F;
            this.roleGrantee.HeaderText = "GRANTEE";
            this.roleGrantee.MinimumWidth = 80;
            this.roleGrantee.Name = "roleGrantee";
            this.roleGrantee.ReadOnly = true;
            this.roleGrantee.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.roleGrantee.Width = 80;
            // 
            // dgvRole
            // 
            this.dgvRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvRole.DataPropertyName = "GRANTED_ROLE";
            this.dgvRole.HeaderText = "ROLE";
            this.dgvRole.MinimumWidth = 100;
            this.dgvRole.Name = "dgvRole";
            this.dgvRole.ReadOnly = true;
            // 
            // PhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 619);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.colPrivs);
            this.Controls.Add(this.rolePrivs);
            this.Controls.Add(this.tablePrivs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.txtGrantee);
            this.Controls.Add(this.btnRevoke);
            this.Controls.Add(this.btnGrant);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PhanQuyen";
            this.Text = "PhanQuyen";
            ((System.ComponentModel.ISupportInitialize)(this.tablePrivs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colPrivs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolePrivs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnGrant;
        private Guna.UI2.WinForms.Guna2Button btnRevoke;
        private Guna.UI2.WinForms.Guna2TextBox txtGrantee;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView tablePrivs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DataGridView colPrivs;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrantee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSchema;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPriv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrantable;
        private Guna.UI2.WinForms.Guna2DataGridView rolePrivs;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkTab;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabGrantee;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabPriv;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabGrantable;
        private System.Windows.Forms.DataGridViewTextBoxColumn tabType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleGrantee;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRole;
    }
}