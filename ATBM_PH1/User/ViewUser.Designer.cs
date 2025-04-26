namespace ATBM_PH1
{
    partial class ViewUser
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
            this.InsertUser = new Guna.UI2.WinForms.Guna2Button();
            this.LoadViewUser = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Search = new Guna.UI2.WinForms.Guna2TextBox();
            this.Search_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.CUpdate = new System.Windows.Forms.DataGridViewImageColumn();
            this.CGrant = new System.Windows.Forms.DataGridViewImageColumn();
            this.CDelete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LoadViewUser)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InsertUser
            // 
            this.InsertUser.BackColor = System.Drawing.Color.Transparent;
            this.InsertUser.BorderRadius = 5;
            this.InsertUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.InsertUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.InsertUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.InsertUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.InsertUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(52)))), ((int)(((byte)(184)))));
            this.InsertUser.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertUser.ForeColor = System.Drawing.Color.White;
            this.InsertUser.Location = new System.Drawing.Point(18, 117);
            this.InsertUser.Name = "InsertUser";
            this.InsertUser.Size = new System.Drawing.Size(180, 45);
            this.InsertUser.TabIndex = 1;
            this.InsertUser.Text = "Tạo";
            this.InsertUser.Click += new System.EventHandler(this.InsertUser_Click);
            // 
            // LoadViewUser
            // 
            this.LoadViewUser.AllowUserToAddRows = false;
            this.LoadViewUser.AllowUserToDeleteRows = false;
            this.LoadViewUser.AllowUserToResizeColumns = false;
            this.LoadViewUser.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.LoadViewUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadViewUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.LoadViewUser.ColumnHeadersHeight = 35;
            this.LoadViewUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CUpdate,
            this.CGrant,
            this.CDelete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LoadViewUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.LoadViewUser.GridColor = System.Drawing.Color.Black;
            this.LoadViewUser.Location = new System.Drawing.Point(18, 198);
            this.LoadViewUser.Name = "LoadViewUser";
            this.LoadViewUser.ReadOnly = true;
            this.LoadViewUser.RowHeadersVisible = false;
            this.LoadViewUser.RowHeadersWidth = 60;
            this.LoadViewUser.RowTemplate.Height = 24;
            this.LoadViewUser.Size = new System.Drawing.Size(808, 408);
            this.LoadViewUser.TabIndex = 3;
            this.LoadViewUser.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.LoadViewUser.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.LoadViewUser.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.LoadViewUser.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.LoadViewUser.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.LoadViewUser.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.LoadViewUser.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.LoadViewUser.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.LoadViewUser.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LoadViewUser.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadViewUser.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.LoadViewUser.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.LoadViewUser.ThemeStyle.HeaderStyle.Height = 35;
            this.LoadViewUser.ThemeStyle.ReadOnly = true;
            this.LoadViewUser.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.LoadViewUser.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.LoadViewUser.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadViewUser.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.LoadViewUser.ThemeStyle.RowsStyle.Height = 24;
            this.LoadViewUser.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.LoadViewUser.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Danh sách user";
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox3.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox3.Location = new System.Drawing.Point(681, 15);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox3.TabIndex = 6;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.guna2ControlBox2.Location = new System.Drawing.Point(732, 15);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(783, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 29);
            this.btnExit.TabIndex = 8;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Search
            // 
            this.Search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Search.DefaultText = "";
            this.Search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Search.Location = new System.Drawing.Point(442, 120);
            this.Search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Search.Name = "Search";
            this.Search.PlaceholderText = "";
            this.Search.SelectedText = "";
            this.Search.Size = new System.Drawing.Size(383, 42);
            this.Search.TabIndex = 9;
            this.Search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // Search_label
            // 
            this.Search_label.AutoSize = true;
            this.Search_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_label.Location = new System.Drawing.Point(437, 88);
            this.Search_label.Name = "Search_label";
            this.Search_label.Size = new System.Drawing.Size(100, 28);
            this.Search_label.TabIndex = 10;
            this.Search_label.Text = "Tìm kiếm";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.guna2ControlBox3);
            this.panel1.Controls.Add(this.guna2ControlBox2);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 60);
            this.panel1.TabIndex = 11;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Chỉnh sửa";
            this.dataGridViewImageColumn1.Image = global::ATBM_PH1.Properties.Resources.Icon_Update;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 223;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Xóa";
            this.dataGridViewImageColumn2.Image = global::ATBM_PH1.Properties.Resources.Icon_Bin;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 223;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Xóa";
            this.dataGridViewImageColumn3.Image = global::ATBM_PH1.Properties.Resources.Icon_Bin;
            this.dataGridViewImageColumn3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn3.MinimumWidth = 6;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Width = 312;
            // 
            // CUpdate
            // 
            this.CUpdate.HeaderText = "Chỉnh sửa";
            this.CUpdate.Image = global::ATBM_PH1.Properties.Resources.edit;
            this.CUpdate.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.CUpdate.MinimumWidth = 6;
            this.CUpdate.Name = "CUpdate";
            this.CUpdate.ReadOnly = true;
            this.CUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CGrant
            // 
            this.CGrant.HeaderText = "Cấp quyền";
            this.CGrant.Image = global::ATBM_PH1.Properties.Resources.grant;
            this.CGrant.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.CGrant.MinimumWidth = 6;
            this.CGrant.Name = "CGrant";
            this.CGrant.ReadOnly = true;
            this.CGrant.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CGrant.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CDelete
            // 
            this.CDelete.HeaderText = "Xóa";
            this.CDelete.Image = global::ATBM_PH1.Properties.Resources.trash;
            this.CDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.CDelete.MinimumWidth = 6;
            this.CDelete.Name = "CDelete";
            this.CDelete.ReadOnly = true;
            this.CDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ViewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(858, 634);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Search_label);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.LoadViewUser);
            this.Controls.Add(this.InsertUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewUser";
            this.Text = "frmUser";
            this.Load += new System.EventHandler(this.ViewUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoadViewUser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button InsertUser;
        private Guna.UI2.WinForms.Guna2DataGridView LoadViewUser;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Guna.UI2.WinForms.Guna2TextBox Search;
        private System.Windows.Forms.Label Search_label;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewImageColumn CUpdate;
        private System.Windows.Forms.DataGridViewImageColumn CGrant;
        private System.Windows.Forms.DataGridViewImageColumn CDelete;
    }
}