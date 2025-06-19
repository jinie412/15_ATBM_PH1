namespace ATBM_PH1
{
    partial class OLS_TaoLabel
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
            this.cbCB = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbldv = new System.Windows.Forms.Label();
            this.btnCN = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_CS = new System.Windows.Forms.Label();
            this.txtNoidung = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.checkGV = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.magv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LABEL_TAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstCompart = new System.Windows.Forms.CheckedListBox();
            this.lstGroup = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGV)).BeginInit();
            this.SuspendLayout();
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
            this.cbCB.Location = new System.Drawing.Point(303, 54);
            this.cbCB.Name = "cbCB";
            this.cbCB.Size = new System.Drawing.Size(276, 36);
            this.cbCB.TabIndex = 15;
            // 
            // lbldv
            // 
            this.lbldv.AutoSize = true;
            this.lbldv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldv.Location = new System.Drawing.Point(126, 54);
            this.lbldv.Name = "lbldv";
            this.lbldv.Size = new System.Drawing.Size(130, 28);
            this.lbldv.TabIndex = 16;
            this.lbldv.Text = "Chọn cấp bậc";
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
            this.btnCN.Location = new System.Drawing.Point(610, 688);
            this.btnCN.Name = "btnCN";
            this.btnCN.Size = new System.Drawing.Size(150, 45);
            this.btnCN.TabIndex = 18;
            this.btnCN.Text = "Thêm";
            this.btnCN.Click += new System.EventHandler(this.btnCN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 28);
            this.label1.TabIndex = 16;
            this.label1.Text = "Chọn lĩnh vực hoạt động";
            // 
            // cb_CS
            // 
            this.cb_CS.AutoSize = true;
            this.cb_CS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_CS.Location = new System.Drawing.Point(147, 296);
            this.cb_CS.Name = "cb_CS";
            this.cb_CS.Size = new System.Drawing.Size(109, 28);
            this.cb_CS.TabIndex = 16;
            this.cb_CS.Text = "Chọn cơ sở";
            // 
            // txtNoidung
            // 
            this.txtNoidung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoidung.DefaultText = "";
            this.txtNoidung.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNoidung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNoidung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoidung.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoidung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoidung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNoidung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoidung.Location = new System.Drawing.Point(303, 429);
            this.txtNoidung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNoidung.Name = "txtNoidung";
            this.txtNoidung.PlaceholderText = "";
            this.txtNoidung.SelectedText = "";
            this.txtNoidung.Size = new System.Drawing.Size(276, 191);
            this.txtNoidung.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 28);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nội dung";
            // 
            // dgvGV
            // 
            this.dgvGV.AllowUserToAddRows = false;
            this.dgvGV.AllowUserToDeleteRows = false;
            this.dgvGV.AllowUserToResizeColumns = false;
            this.dgvGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGV.ColumnHeadersHeight = 40;
            this.dgvGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkGV,
            this.magv,
            this.LABEL_TAG});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvGV.Location = new System.Drawing.Point(731, 54);
            this.dgvGV.Name = "dgvGV";
            this.dgvGV.ReadOnly = true;
            this.dgvGV.RowHeadersVisible = false;
            this.dgvGV.RowHeadersWidth = 51;
            this.dgvGV.RowTemplate.Height = 30;
            this.dgvGV.Size = new System.Drawing.Size(588, 566);
            this.dgvGV.TabIndex = 22;
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
            this.magv.DataPropertyName = "LABEL";
            this.magv.HeaderText = "LABEL";
            this.magv.MinimumWidth = 90;
            this.magv.Name = "magv";
            this.magv.ReadOnly = true;
            this.magv.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // lstCompart
            // 
            this.lstCompart.FormattingEnabled = true;
            this.lstCompart.Location = new System.Drawing.Point(303, 151);
            this.lstCompart.Name = "lstCompart";
            this.lstCompart.Size = new System.Drawing.Size(276, 106);
            this.lstCompart.TabIndex = 24;
            // 
            // lstGroup
            // 
            this.lstGroup.FormattingEnabled = true;
            this.lstGroup.Location = new System.Drawing.Point(303, 296);
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.Size = new System.Drawing.Size(276, 89);
            this.lstGroup.TabIndex = 24;
            // 
            // OLS_TaoLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1424, 793);
            this.Controls.Add(this.lstGroup);
            this.Controls.Add(this.lstCompart);
            this.Controls.Add(this.dgvGV);
            this.Controls.Add(this.txtNoidung);
            this.Controls.Add(this.btnCN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_CS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbldv);
            this.Controls.Add(this.cbCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OLS_TaoLabel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDT_Them";
            this.Load += new System.EventHandler(this.PDT_Them_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cbCB;
        private System.Windows.Forms.Label lbldv;
        private Guna.UI2.WinForms.Guna2Button btnCN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cb_CS;
        private Guna.UI2.WinForms.Guna2TextBox txtNoidung;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvGV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn magv;
        private System.Windows.Forms.DataGridViewTextBoxColumn LABEL_TAG;
        private System.Windows.Forms.CheckedListBox lstCompart;
        private System.Windows.Forms.CheckedListBox lstGroup;
    }
}