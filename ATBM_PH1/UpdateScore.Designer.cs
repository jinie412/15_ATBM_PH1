namespace ATBM_PH1
{
    partial class UpdateScore
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox textBoxMasv;
        private System.Windows.Forms.TextBox textBoxMamm;
        private System.Windows.Forms.TextBox textBoxDiemTH;
        private System.Windows.Forms.TextBox textBoxDiemQT;
        private System.Windows.Forms.TextBox textBoxDiemCK;
        private System.Windows.Forms.TextBox textBoxDiemTK;
        private System.Windows.Forms.Button buttonLuu;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.textBoxMasv = new System.Windows.Forms.TextBox();
            this.textBoxMamm = new System.Windows.Forms.TextBox();
            this.textBoxDiemTH = new System.Windows.Forms.TextBox();
            this.textBoxDiemQT = new System.Windows.Forms.TextBox();
            this.textBoxDiemCK = new System.Windows.Forms.TextBox();
            this.textBoxDiemTK = new System.Windows.Forms.TextBox();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.labelMasv = new System.Windows.Forms.Label();
            this.labelHoten = new System.Windows.Forms.Label();
            this.labelPhai = new System.Windows.Forms.Label();
            this.labTH = new System.Windows.Forms.Label();
            this.labQT = new System.Windows.Forms.Label();
            this.labCK = new System.Windows.Forms.Label();
            this.labDiemTK = new System.Windows.Forms.Label();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.labMamm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxMasv
            // 
            this.textBoxMasv.Location = new System.Drawing.Point(100, 20);
            this.textBoxMasv.Name = "textBoxMasv";
            this.textBoxMasv.Size = new System.Drawing.Size(200, 22);
            this.textBoxMasv.TabIndex = 0;
            // 
            // textBoxMamm
            // 
            this.textBoxMamm.Location = new System.Drawing.Point(100, 60);
            this.textBoxMamm.Name = "textBoxMamm";
            this.textBoxMamm.Size = new System.Drawing.Size(200, 22);
            this.textBoxMamm.TabIndex = 1;
            // 
            // textBoxDiemTH
            // 
            this.textBoxDiemTH.Location = new System.Drawing.Point(100, 108);
            this.textBoxDiemTH.Name = "textBoxDiemTH";
            this.textBoxDiemTH.Size = new System.Drawing.Size(200, 22);
            this.textBoxDiemTH.TabIndex = 4;
            // 
            // textBoxDiemQT
            // 
            this.textBoxDiemQT.Location = new System.Drawing.Point(100, 158);
            this.textBoxDiemQT.Name = "textBoxDiemQT";
            this.textBoxDiemQT.Size = new System.Drawing.Size(200, 22);
            this.textBoxDiemQT.TabIndex = 5;
            // 
            // textBoxDiemCK
            // 
            this.textBoxDiemCK.Location = new System.Drawing.Point(100, 211);
            this.textBoxDiemCK.Name = "textBoxDiemCK";
            this.textBoxDiemCK.Size = new System.Drawing.Size(200, 22);
            this.textBoxDiemCK.TabIndex = 6;
            // 
            // textBoxDiemTK
            // 
            this.textBoxDiemTK.Location = new System.Drawing.Point(100, 260);
            this.textBoxDiemTK.Name = "textBoxDiemTK";
            this.textBoxDiemTK.Size = new System.Drawing.Size(200, 22);
            this.textBoxDiemTK.TabIndex = 7;
            // 
            // buttonLuu
            // 
            this.buttonLuu.Location = new System.Drawing.Point(56, 320);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(100, 30);
            this.buttonLuu.TabIndex = 8;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // labelMasv
            // 
            this.labelMasv.AutoSize = true;
            this.labelMasv.Location = new System.Drawing.Point(21, 26);
            this.labelMasv.Name = "labelMasv";
            this.labelMasv.Size = new System.Drawing.Size(50, 16);
            this.labelMasv.TabIndex = 9;
            this.labelMasv.Text = "Mã SV:";
            // 
            // labelHoten
            // 
            this.labelHoten.AutoSize = true;
            this.labelHoten.Location = new System.Drawing.Point(21, 66);
            this.labelHoten.Name = "labelHoten";
            this.labelHoten.Size = new System.Drawing.Size(0, 16);
            this.labelHoten.TabIndex = 10;
            // 
            // labelPhai
            // 
            this.labelPhai.AutoSize = true;
            this.labelPhai.Location = new System.Drawing.Point(21, 108);
            this.labelPhai.Name = "labelPhai";
            this.labelPhai.Size = new System.Drawing.Size(0, 16);
            this.labelPhai.TabIndex = 11;
            // 
            // labTH
            // 
            this.labTH.AutoSize = true;
            this.labTH.Location = new System.Drawing.Point(21, 114);
            this.labTH.Name = "labTH";
            this.labTH.Size = new System.Drawing.Size(63, 16);
            this.labTH.TabIndex = 13;
            this.labTH.Text = "Điểm TH:";
            // 
            // labQT
            // 
            this.labQT.AutoSize = true;
            this.labQT.Location = new System.Drawing.Point(21, 164);
            this.labQT.Name = "labQT";
            this.labQT.Size = new System.Drawing.Size(63, 16);
            this.labQT.TabIndex = 14;
            this.labQT.Text = "Điểm QT:";
            // 
            // labCK
            // 
            this.labCK.AutoSize = true;
            this.labCK.Location = new System.Drawing.Point(21, 217);
            this.labCK.Name = "labCK";
            this.labCK.Size = new System.Drawing.Size(61, 16);
            this.labCK.TabIndex = 15;
            this.labCK.Text = "Điểm CK:";
            // 
            // labDiemTK
            // 
            this.labDiemTK.AutoSize = true;
            this.labDiemTK.Location = new System.Drawing.Point(21, 266);
            this.labDiemTK.Name = "labDiemTK";
            this.labDiemTK.Size = new System.Drawing.Size(61, 16);
            this.labDiemTK.TabIndex = 16;
            this.labDiemTK.Text = "Điểm TK:";
            // 
            // buttonHuy
            // 
            this.buttonHuy.Location = new System.Drawing.Point(216, 320);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(100, 30);
            this.buttonHuy.TabIndex = 20;
            this.buttonHuy.Text = "Hủy";
            this.buttonHuy.UseVisualStyleBackColor = true;
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // labMamm
            // 
            this.labMamm.AutoSize = true;
            this.labMamm.Location = new System.Drawing.Point(21, 66);
            this.labMamm.Name = "labMamm";
            this.labMamm.Size = new System.Drawing.Size(54, 16);
            this.labMamm.TabIndex = 21;
            this.labMamm.Text = "Mã MM:";
            // 
            // UpdateScore
            // 
            this.ClientSize = new System.Drawing.Size(400, 369);
            this.Controls.Add(this.labMamm);
            this.Controls.Add(this.buttonHuy);
            this.Controls.Add(this.labDiemTK);
            this.Controls.Add(this.labCK);
            this.Controls.Add(this.labQT);
            this.Controls.Add(this.labTH);
            this.Controls.Add(this.labelPhai);
            this.Controls.Add(this.labelHoten);
            this.Controls.Add(this.labelMasv);
            this.Controls.Add(this.textBoxMasv);
            this.Controls.Add(this.textBoxMamm);
            this.Controls.Add(this.textBoxDiemTH);
            this.Controls.Add(this.textBoxDiemQT);
            this.Controls.Add(this.textBoxDiemCK);
            this.Controls.Add(this.textBoxDiemTK);
            this.Controls.Add(this.buttonLuu);
            this.Name = "UpdateScore";
            this.Text = "Thông tin sinh viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMasv;
        private System.Windows.Forms.Label labelHoten;
        private System.Windows.Forms.Label labelPhai;
        private System.Windows.Forms.Label labTH;
        private System.Windows.Forms.Label labQT;
        private System.Windows.Forms.Label labCK;
        private System.Windows.Forms.Label labDiemTK;
        private System.Windows.Forms.Button buttonHuy;
        private System.Windows.Forms.Label labMamm;
    }
}
