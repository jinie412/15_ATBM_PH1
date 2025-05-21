namespace ATBM_PH1
{
    partial class SinhVienForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox textBoxMasv;
        private System.Windows.Forms.TextBox textBoxHoten;
        private System.Windows.Forms.ComboBox comboBoxPhai;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgSinh;
        private System.Windows.Forms.TextBox textBoxDiaChi;
        private System.Windows.Forms.TextBox textBoxDT;
        private System.Windows.Forms.TextBox textBoxTrangThai;
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
            this.textBoxHoten = new System.Windows.Forms.TextBox();
            this.comboBoxPhai = new System.Windows.Forms.ComboBox();
            this.dateTimePickerNgSinh = new System.Windows.Forms.DateTimePicker();
            this.textBoxDiaChi = new System.Windows.Forms.TextBox();
            this.textBoxDT = new System.Windows.Forms.TextBox();
            this.textBoxTrangThai = new System.Windows.Forms.TextBox();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.labelManld = new System.Windows.Forms.Label();
            this.labelHoten = new System.Windows.Forms.Label();
            this.labelPhai = new System.Windows.Forms.Label();
            this.labelNgSinh = new System.Windows.Forms.Label();
            this.labelLuong = new System.Windows.Forms.Label();
            this.labelDT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.comboBoxKhoa = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxMasv
            // 
            this.textBoxMasv.Location = new System.Drawing.Point(100, 20);
            this.textBoxMasv.Name = "textBoxMasv";
            this.textBoxMasv.Size = new System.Drawing.Size(200, 22);
            this.textBoxMasv.TabIndex = 0;
            // 
            // textBoxHoten
            // 
            this.textBoxHoten.Location = new System.Drawing.Point(100, 60);
            this.textBoxHoten.Name = "textBoxHoten";
            this.textBoxHoten.Size = new System.Drawing.Size(200, 22);
            this.textBoxHoten.TabIndex = 1;
            // 
            // comboBoxPhai
            // 
            this.comboBoxPhai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPhai.Location = new System.Drawing.Point(100, 100);
            this.comboBoxPhai.Name = "comboBoxPhai";
            this.comboBoxPhai.Size = new System.Drawing.Size(200, 24);
            this.comboBoxPhai.TabIndex = 2;
            // 
            // dateTimePickerNgSinh
            // 
            this.dateTimePickerNgSinh.Location = new System.Drawing.Point(100, 140);
            this.dateTimePickerNgSinh.Name = "dateTimePickerNgSinh";
            this.dateTimePickerNgSinh.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerNgSinh.TabIndex = 3;
            // 
            // textBoxDiaChi
            // 
            this.textBoxDiaChi.Location = new System.Drawing.Point(100, 180);
            this.textBoxDiaChi.Name = "textBoxDiaChi";
            this.textBoxDiaChi.Size = new System.Drawing.Size(200, 22);
            this.textBoxDiaChi.TabIndex = 4;
            // 
            // textBoxDT
            // 
            this.textBoxDT.Location = new System.Drawing.Point(100, 220);
            this.textBoxDT.Name = "textBoxDT";
            this.textBoxDT.Size = new System.Drawing.Size(200, 22);
            this.textBoxDT.TabIndex = 5;
            // 
            // textBoxTrangThai
            // 
            this.textBoxTrangThai.Location = new System.Drawing.Point(100, 300);
            this.textBoxTrangThai.Name = "textBoxTrangThai";
            this.textBoxTrangThai.Size = new System.Drawing.Size(200, 22);
            this.textBoxTrangThai.TabIndex = 7;
            // 
            // buttonLuu
            // 
            this.buttonLuu.Location = new System.Drawing.Point(85, 340);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(100, 30);
            this.buttonLuu.TabIndex = 8;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // labelManld
            // 
            this.labelManld.AutoSize = true;
            this.labelManld.Location = new System.Drawing.Point(21, 26);
            this.labelManld.Name = "labelManld";
            this.labelManld.Size = new System.Drawing.Size(50, 16);
            this.labelManld.TabIndex = 9;
            this.labelManld.Text = "Mã SV:";
            // 
            // labelHoten
            // 
            this.labelHoten.AutoSize = true;
            this.labelHoten.Location = new System.Drawing.Point(21, 66);
            this.labelHoten.Name = "labelHoten";
            this.labelHoten.Size = new System.Drawing.Size(49, 16);
            this.labelHoten.TabIndex = 10;
            this.labelHoten.Text = "Họ tên:";
            // 
            // labelPhai
            // 
            this.labelPhai.AutoSize = true;
            this.labelPhai.Location = new System.Drawing.Point(21, 108);
            this.labelPhai.Name = "labelPhai";
            this.labelPhai.Size = new System.Drawing.Size(37, 16);
            this.labelPhai.TabIndex = 11;
            this.labelPhai.Text = "Phái:";
            // 
            // labelNgSinh
            // 
            this.labelNgSinh.AutoSize = true;
            this.labelNgSinh.Location = new System.Drawing.Point(21, 146);
            this.labelNgSinh.Name = "labelNgSinh";
            this.labelNgSinh.Size = new System.Drawing.Size(70, 16);
            this.labelNgSinh.TabIndex = 12;
            this.labelNgSinh.Text = "Ngày sinh:";
            // 
            // labelLuong
            // 
            this.labelLuong.AutoSize = true;
            this.labelLuong.Location = new System.Drawing.Point(21, 186);
            this.labelLuong.Name = "labelLuong";
            this.labelLuong.Size = new System.Drawing.Size(50, 16);
            this.labelLuong.TabIndex = 13;
            this.labelLuong.Text = "Địa chỉ:";
            // 
            // labelDT
            // 
            this.labelDT.AutoSize = true;
            this.labelDT.Location = new System.Drawing.Point(21, 226);
            this.labelDT.Name = "labelDT";
            this.labelDT.Size = new System.Drawing.Size(69, 16);
            this.labelDT.TabIndex = 14;
            this.labelDT.Text = "Điện thoại:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Khoa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tình trạng:";
            // 
            // buttonHuy
            // 
            this.buttonHuy.Location = new System.Drawing.Point(210, 340);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(100, 30);
            this.buttonHuy.TabIndex = 20;
            this.buttonHuy.Text = "Hủy";
            this.buttonHuy.UseVisualStyleBackColor = true;
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // comboBoxKhoa
            // 
            this.comboBoxKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKhoa.Location = new System.Drawing.Point(100, 263);
            this.comboBoxKhoa.Name = "comboBoxKhoa";
            this.comboBoxKhoa.Size = new System.Drawing.Size(200, 24);
            this.comboBoxKhoa.TabIndex = 2;
            // 
            // SinhVienForm
            // 
            this.ClientSize = new System.Drawing.Size(390, 400);
            this.Controls.Add(this.buttonHuy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDT);
            this.Controls.Add(this.labelLuong);
            this.Controls.Add(this.labelNgSinh);
            this.Controls.Add(this.labelPhai);
            this.Controls.Add(this.labelHoten);
            this.Controls.Add(this.labelManld);
            this.Controls.Add(this.textBoxMasv);
            this.Controls.Add(this.textBoxHoten);
            this.Controls.Add(this.comboBoxKhoa);
            this.Controls.Add(this.comboBoxPhai);
            this.Controls.Add(this.dateTimePickerNgSinh);
            this.Controls.Add(this.textBoxDiaChi);
            this.Controls.Add(this.textBoxDT);
            this.Controls.Add(this.textBoxTrangThai);
            this.Controls.Add(this.buttonLuu);
            this.Name = "SinhVienForm";
            this.Text = "Thông tin sinh viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelManld;
        private System.Windows.Forms.Label labelHoten;
        private System.Windows.Forms.Label labelPhai;
        private System.Windows.Forms.Label labelNgSinh;
        private System.Windows.Forms.Label labelLuong;
        private System.Windows.Forms.Label labelDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonHuy;
        private System.Windows.Forms.ComboBox comboBoxKhoa;
    }
}
