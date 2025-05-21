namespace ATBM_PH1
{
    partial class DSHP
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
            this.btnDangKy = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDSHP = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHP)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDangKy
            // 
            this.btnDangKy.BorderRadius = 5;
            this.btnDangKy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangKy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangKy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangKy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangKy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(782, 583);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(180, 45);
            this.btnDangKy.TabIndex = 29;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // dgvDSHP
            // 
            this.dgvDSHP.AllowUserToAddRows = false;
            this.dgvDSHP.AllowUserToDeleteRows = false;
            this.dgvDSHP.AllowUserToResizeColumns = false;
            this.dgvDSHP.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDSHP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSHP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDSHP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSHP.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSHP.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSHP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDSHP.Location = new System.Drawing.Point(44, 75);
            this.dgvDSHP.Name = "dgvDSHP";
            this.dgvDSHP.RowHeadersVisible = false;
            this.dgvDSHP.RowHeadersWidth = 51;
            this.dgvDSHP.RowTemplate.Height = 26;
            this.dgvDSHP.Size = new System.Drawing.Size(918, 484);
            this.dgvDSHP.TabIndex = 30;
            this.dgvDSHP.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDSHP.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDSHP.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDSHP.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDSHP.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDSHP.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDSHP.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDSHP.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvDSHP.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDSHP.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dgvDSHP.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDSHP.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDSHP.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvDSHP.ThemeStyle.ReadOnly = false;
            this.dgvDSHP.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDSHP.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDSHP.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDSHP.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvDSHP.ThemeStyle.RowsStyle.Height = 26;
            this.dgvDSHP.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDSHP.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox3.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox3.Location = new System.Drawing.Point(796, 22);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox3.TabIndex = 31;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.guna2ControlBox2.Location = new System.Drawing.Point(847, 22);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 32;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.IconColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(898, 22);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 29);
            this.btnExit.TabIndex = 33;
            // 
            // DSHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(985, 663);
            this.Controls.Add(this.guna2ControlBox3);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvDSHP);
            this.Controls.Add(this.btnDangKy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DSHP";
            this.Text = "DSHP";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnDangKy;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDSHP;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
    }
}