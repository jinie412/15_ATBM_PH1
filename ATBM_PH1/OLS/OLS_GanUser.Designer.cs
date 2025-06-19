namespace ATBM_PH1
{
    partial class OLS_GanUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCN = new Guna.UI2.WinForms.Guna2Button();
            this.dgvGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.checkGV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.magv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvlabel = new Guna.UI2.WinForms.Guna2DataGridView();
            this.checklb = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LABEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LABEL_TAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGan = new Guna.UI2.WinForms.Guna2Button();
            this.dgvnv = new Guna.UI2.WinForms.Guna2DataGridView();
            this.checknv = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.manv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstGroup = new System.Windows.Forms.CheckedListBox();
            this.lstCompart = new System.Windows.Forms.CheckedListBox();
            this.cb_CS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldv = new System.Windows.Forms.Label();
            this.cbCB = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvnv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCN
            // 
            this.btnCN.BorderRadius = 5;
            this.btnCN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(52)))), ((int)(((byte)(184)))));
            this.btnCN.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCN.ForeColor = System.Drawing.Color.White;
            this.btnCN.Location = new System.Drawing.Point(669, 373);
            this.btnCN.Name = "btnCN";
            this.btnCN.Size = new System.Drawing.Size(150, 45);
            this.btnCN.TabIndex = 18;
            this.btnCN.Text = "Thêm";
            this.btnCN.Click += new System.EventHandler(this.btnCN_Click);
            // 
            // dgvGV
            // 
            this.dgvGV.AllowUserToAddRows = false;
            this.dgvGV.AllowUserToDeleteRows = false;
            this.dgvGV.AllowUserToResizeColumns = false;
            this.dgvGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvGV.ColumnHeadersHeight = 40;
            this.dgvGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkGV,
            this.magv,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGV.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvGV.Location = new System.Drawing.Point(850, 63);
            this.dgvGV.Name = "dgvGV";
            this.dgvGV.ReadOnly = true;
            this.dgvGV.RowHeadersVisible = false;
            this.dgvGV.RowHeadersWidth = 51;
            this.dgvGV.RowTemplate.Height = 30;
            this.dgvGV.Size = new System.Drawing.Size(554, 316);
            this.dgvGV.TabIndex = 20;
            this.dgvGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.dgvGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGV.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvGV.ThemeStyle.ReadOnly = true;
            this.dgvGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvGV.ThemeStyle.RowsStyle.Height = 30;
            this.dgvGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGV_CellContentClick);
            // 
            // checkGV
            // 
            this.checkGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.checkGV.FillWeight = 35F;
            this.checkGV.HeaderText = "";
            this.checkGV.MinimumWidth = 35;
            this.checkGV.Name = "checkGV";
            this.checkGV.ReadOnly = true;
            this.checkGV.Width = 35;
            // 
            // magv
            // 
            this.magv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.magv.DataPropertyName = "MANLD";
            this.magv.HeaderText = "Mã NV";
            this.magv.MinimumWidth = 90;
            this.magv.Name = "magv";
            this.magv.ReadOnly = true;
            this.magv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "HOTEN";
            this.dataGridViewTextBoxColumn2.FillWeight = 80F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Họ tên";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dgvlabel
            // 
            this.dgvlabel.AllowUserToAddRows = false;
            this.dgvlabel.AllowUserToDeleteRows = false;
            this.dgvlabel.AllowUserToResizeColumns = false;
            this.dgvlabel.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvlabel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlabel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvlabel.ColumnHeadersHeight = 40;
            this.dgvlabel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checklb,
            this.LABEL,
            this.LABEL_TAG});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvlabel.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvlabel.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvlabel.Location = new System.Drawing.Point(45, 466);
            this.dgvlabel.Name = "dgvlabel";
            this.dgvlabel.ReadOnly = true;
            this.dgvlabel.RowHeadersVisible = false;
            this.dgvlabel.RowHeadersWidth = 51;
            this.dgvlabel.RowTemplate.Height = 30;
            this.dgvlabel.Size = new System.Drawing.Size(533, 316);
            this.dgvlabel.TabIndex = 23;
            this.dgvlabel.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvlabel.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvlabel.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvlabel.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvlabel.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvlabel.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvlabel.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvlabel.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.dgvlabel.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvlabel.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvlabel.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvlabel.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvlabel.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvlabel.ThemeStyle.ReadOnly = true;
            this.dgvlabel.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvlabel.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvlabel.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvlabel.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvlabel.ThemeStyle.RowsStyle.Height = 30;
            this.dgvlabel.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvlabel.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvlabel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlabel_CellContentClick);
            // 
            // checklb
            // 
            this.checklb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.checklb.FillWeight = 35F;
            this.checklb.HeaderText = "";
            this.checklb.MinimumWidth = 35;
            this.checklb.Name = "checklb";
            this.checklb.ReadOnly = true;
            this.checklb.Width = 35;
            // 
            // LABEL
            // 
            this.LABEL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LABEL.DataPropertyName = "LABEL";
            this.LABEL.HeaderText = "LABEL";
            this.LABEL.MinimumWidth = 90;
            this.LABEL.Name = "LABEL";
            this.LABEL.ReadOnly = true;
            this.LABEL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // LABEL_TAG
            // 
            this.LABEL_TAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LABEL_TAG.DataPropertyName = "LABEL_TAG";
            this.LABEL_TAG.FillWeight = 80F;
            this.LABEL_TAG.HeaderText = "LABEL_TAG";
            this.LABEL_TAG.MinimumWidth = 80;
            this.LABEL_TAG.Name = "LABEL_TAG";
            this.LABEL_TAG.ReadOnly = true;
            // 
            // btnGan
            // 
            this.btnGan.BorderRadius = 5;
            this.btnGan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(52)))), ((int)(((byte)(184)))));
            this.btnGan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGan.ForeColor = System.Drawing.Color.White;
            this.btnGan.Location = new System.Drawing.Point(685, 874);
            this.btnGan.Name = "btnGan";
            this.btnGan.Size = new System.Drawing.Size(150, 45);
            this.btnGan.TabIndex = 18;
            this.btnGan.Text = "Gán";
            this.btnGan.Click += new System.EventHandler(this.btnGan_Click);
            // 
            // dgvnv
            // 
            this.dgvnv.AllowUserToAddRows = false;
            this.dgvnv.AllowUserToDeleteRows = false;
            this.dgvnv.AllowUserToResizeColumns = false;
            this.dgvnv.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.dgvnv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvnv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvnv.ColumnHeadersHeight = 40;
            this.dgvnv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checknv,
            this.manv,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvnv.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvnv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvnv.Location = new System.Drawing.Point(850, 466);
            this.dgvnv.Name = "dgvnv";
            this.dgvnv.ReadOnly = true;
            this.dgvnv.RowHeadersVisible = false;
            this.dgvnv.RowHeadersWidth = 51;
            this.dgvnv.RowTemplate.Height = 30;
            this.dgvnv.Size = new System.Drawing.Size(554, 316);
            this.dgvnv.TabIndex = 20;
            this.dgvnv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvnv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvnv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvnv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvnv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvnv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvnv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvnv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.dgvnv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvnv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvnv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvnv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvnv.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvnv.ThemeStyle.ReadOnly = true;
            this.dgvnv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvnv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvnv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvnv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvnv.ThemeStyle.RowsStyle.Height = 30;
            this.dgvnv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvnv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvnv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvnv_CellContentClick);
            // 
            // checknv
            // 
            this.checknv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.checknv.FillWeight = 35F;
            this.checknv.HeaderText = "";
            this.checknv.MinimumWidth = 35;
            this.checknv.Name = "checknv";
            this.checknv.ReadOnly = true;
            this.checknv.Width = 35;
            // 
            // manv
            // 
            this.manv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.manv.DataPropertyName = "MANLD";
            this.manv.HeaderText = "Mã NV";
            this.manv.MinimumWidth = 90;
            this.manv.Name = "manv";
            this.manv.ReadOnly = true;
            this.manv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "HOTEN";
            this.dataGridViewTextBoxColumn4.FillWeight = 80F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Họ tên";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // lstGroup
            // 
            this.lstGroup.FormattingEnabled = true;
            this.lstGroup.Location = new System.Drawing.Point(302, 305);
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.Size = new System.Drawing.Size(276, 89);
            this.lstGroup.TabIndex = 29;
            // 
            // lstCompart
            // 
            this.lstCompart.FormattingEnabled = true;
            this.lstCompart.Location = new System.Drawing.Point(302, 160);
            this.lstCompart.Name = "lstCompart";
            this.lstCompart.Size = new System.Drawing.Size(276, 106);
            this.lstCompart.TabIndex = 30;
            // 
            // cb_CS
            // 
            this.cb_CS.AutoSize = true;
            this.cb_CS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_CS.Location = new System.Drawing.Point(146, 305);
            this.cb_CS.Name = "cb_CS";
            this.cb_CS.Size = new System.Drawing.Size(109, 28);
            this.cb_CS.TabIndex = 26;
            this.cb_CS.Text = "Chọn cơ sở";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 28);
            this.label1.TabIndex = 27;
            this.label1.Text = "Chọn lĩnh vực hoạt động";
            // 
            // lbldv
            // 
            this.lbldv.AutoSize = true;
            this.lbldv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldv.Location = new System.Drawing.Point(125, 63);
            this.lbldv.Name = "lbldv";
            this.lbldv.Size = new System.Drawing.Size(130, 28);
            this.lbldv.TabIndex = 28;
            this.lbldv.Text = "Chọn cấp bậc";
            // 
            // cbCB
            // 
            this.cbCB.BackColor = System.Drawing.Color.Transparent;
            this.cbCB.BorderRadius = 3;
            this.cbCB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCB.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCB.ItemHeight = 30;
            this.cbCB.Location = new System.Drawing.Point(302, 63);
            this.cbCB.Name = "cbCB";
            this.cbCB.Size = new System.Drawing.Size(276, 36);
            this.cbCB.TabIndex = 25;
            // 
            // OLS_GanUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1942, 1100);
            this.Controls.Add(this.lstGroup);
            this.Controls.Add(this.lstCompart);
            this.Controls.Add(this.cb_CS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbldv);
            this.Controls.Add(this.cbCB);
            this.Controls.Add(this.dgvlabel);
            this.Controls.Add(this.dgvnv);
            this.Controls.Add(this.dgvGV);
            this.Controls.Add(this.btnGan);
            this.Controls.Add(this.btnCN);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OLS_GanUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDT_Them";
            this.Load += new System.EventHandler(this.PDT_Them_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvnv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnCN;
        private Guna.UI2.WinForms.Guna2DataGridView dgvGV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn magv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvlabel;
        private Guna.UI2.WinForms.Guna2Button btnGan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvnv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checknv;
        private System.Windows.Forms.DataGridViewTextBoxColumn manv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checklb;
        private System.Windows.Forms.DataGridViewTextBoxColumn LABEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn LABEL_TAG;
        private System.Windows.Forms.CheckedListBox lstGroup;
        private System.Windows.Forms.CheckedListBox lstCompart;
        private System.Windows.Forms.Label cb_CS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldv;
        private Guna.UI2.WinForms.Guna2ComboBox cbCB;
    }
}