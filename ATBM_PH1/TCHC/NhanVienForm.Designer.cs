using System;

namespace ATBM_PH1
{
    partial class NhanVienForm
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
            this.labelManld = new System.Windows.Forms.Label();
            this.textBoxManld = new System.Windows.Forms.TextBox();
            this.labelHoten = new System.Windows.Forms.Label();
            this.textBoxHoten = new System.Windows.Forms.TextBox();
            this.labelPhai = new System.Windows.Forms.Label();
            this.comboBoxPhai = new System.Windows.Forms.ComboBox();
            this.labelNgSinh = new System.Windows.Forms.Label();
            this.dateTimePickerNgSinh = new System.Windows.Forms.DateTimePicker();
            this.labelLuong = new System.Windows.Forms.Label();
            this.textBoxLuong = new System.Windows.Forms.TextBox();
            this.labelPhuCap = new System.Windows.Forms.Label();
            this.textBoxPhuCap = new System.Windows.Forms.TextBox();
            this.labelDT = new System.Windows.Forms.Label();
            this.textBoxDT = new System.Windows.Forms.TextBox();
            this.labelVaiTro = new System.Windows.Forms.Label();
            this.comboBoxVaiTro = new System.Windows.Forms.ComboBox();
            this.labelMaDV = new System.Windows.Forms.Label();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.comboBoxDV = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelManld
            // 
            this.labelManld.AutoSize = true;
            this.labelManld.Location = new System.Drawing.Point(30, 20);
            this.labelManld.Name = "labelManld";
            this.labelManld.Size = new System.Drawing.Size(58, 16);
            this.labelManld.TabIndex = 0;
            this.labelManld.Text = "Mã NLĐ:";
            // 
            // textBoxManld
            // 
            this.textBoxManld.Location = new System.Drawing.Point(150, 17);
            this.textBoxManld.Name = "textBoxManld";
            this.textBoxManld.Size = new System.Drawing.Size(200, 22);
            this.textBoxManld.TabIndex = 1;
            // 
            // labelHoten
            // 
            this.labelHoten.AutoSize = true;
            this.labelHoten.Location = new System.Drawing.Point(30, 60);
            this.labelHoten.Name = "labelHoten";
            this.labelHoten.Size = new System.Drawing.Size(49, 16);
            this.labelHoten.TabIndex = 2;
            this.labelHoten.Text = "Họ tên:";
            // 
            // textBoxHoten
            // 
            this.textBoxHoten.Location = new System.Drawing.Point(150, 57);
            this.textBoxHoten.Name = "textBoxHoten";
            this.textBoxHoten.Size = new System.Drawing.Size(200, 22);
            this.textBoxHoten.TabIndex = 3;
            // 
            // labelPhai
            // 
            this.labelPhai.AutoSize = true;
            this.labelPhai.Location = new System.Drawing.Point(30, 100);
            this.labelPhai.Name = "labelPhai";
            this.labelPhai.Size = new System.Drawing.Size(37, 16);
            this.labelPhai.TabIndex = 4;
            this.labelPhai.Text = "Phái:";
            // 
            // comboBoxPhai
            // 
            this.comboBoxPhai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPhai.FormattingEnabled = true;
            this.comboBoxPhai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.comboBoxPhai.Location = new System.Drawing.Point(150, 97);
            this.comboBoxPhai.Name = "comboBoxPhai";
            this.comboBoxPhai.Size = new System.Drawing.Size(200, 24);
            this.comboBoxPhai.TabIndex = 5;
            // 
            // labelNgSinh
            // 
            this.labelNgSinh.AutoSize = true;
            this.labelNgSinh.Location = new System.Drawing.Point(30, 140);
            this.labelNgSinh.Name = "labelNgSinh";
            this.labelNgSinh.Size = new System.Drawing.Size(70, 16);
            this.labelNgSinh.TabIndex = 6;
            this.labelNgSinh.Text = "Ngày sinh:";
            // 
            // dateTimePickerNgSinh
            // 
            this.dateTimePickerNgSinh.Location = new System.Drawing.Point(150, 137);
            this.dateTimePickerNgSinh.Name = "dateTimePickerNgSinh";
            this.dateTimePickerNgSinh.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerNgSinh.TabIndex = 7;
            // 
            // labelLuong
            // 
            this.labelLuong.AutoSize = true;
            this.labelLuong.Location = new System.Drawing.Point(30, 180);
            this.labelLuong.Name = "labelLuong";
            this.labelLuong.Size = new System.Drawing.Size(47, 16);
            this.labelLuong.TabIndex = 8;
            this.labelLuong.Text = "Lương:";
            // 
            // textBoxLuong
            // 
            this.textBoxLuong.Location = new System.Drawing.Point(150, 177);
            this.textBoxLuong.Name = "textBoxLuong";
            this.textBoxLuong.Size = new System.Drawing.Size(200, 22);
            this.textBoxLuong.TabIndex = 9;
            // 
            // labelPhuCap
            // 
            this.labelPhuCap.AutoSize = true;
            this.labelPhuCap.Location = new System.Drawing.Point(30, 220);
            this.labelPhuCap.Name = "labelPhuCap";
            this.labelPhuCap.Size = new System.Drawing.Size(59, 16);
            this.labelPhuCap.TabIndex = 10;
            this.labelPhuCap.Text = "Phụ cấp:";
            // 
            // textBoxPhuCap
            // 
            this.textBoxPhuCap.Location = new System.Drawing.Point(150, 217);
            this.textBoxPhuCap.Name = "textBoxPhuCap";
            this.textBoxPhuCap.Size = new System.Drawing.Size(200, 22);
            this.textBoxPhuCap.TabIndex = 11;
            // 
            // labelDT
            // 
            this.labelDT.AutoSize = true;
            this.labelDT.Location = new System.Drawing.Point(30, 260);
            this.labelDT.Name = "labelDT";
            this.labelDT.Size = new System.Drawing.Size(69, 16);
            this.labelDT.TabIndex = 12;
            this.labelDT.Text = "Điện thoại:";
            // 
            // textBoxDT
            // 
            this.textBoxDT.Location = new System.Drawing.Point(150, 257);
            this.textBoxDT.Name = "textBoxDT";
            this.textBoxDT.Size = new System.Drawing.Size(200, 22);
            this.textBoxDT.TabIndex = 13;
            // 
            // labelVaiTro
            // 
            this.labelVaiTro.AutoSize = true;
            this.labelVaiTro.Location = new System.Drawing.Point(30, 300);
            this.labelVaiTro.Name = "labelVaiTro";
            this.labelVaiTro.Size = new System.Drawing.Size(48, 16);
            this.labelVaiTro.TabIndex = 14;
            this.labelVaiTro.Text = "Vai trò:";
            // 
            // comboBoxVaiTro
            // 
            this.comboBoxVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVaiTro.FormattingEnabled = true;
            this.comboBoxVaiTro.Items.AddRange(new object[] {
            "NVCB",
            "GV",
            "NV PĐT",
            "NV PKT",
            "NV TCHC",
            "NV CTSV",
            "TRGĐV"});
            this.comboBoxVaiTro.Location = new System.Drawing.Point(150, 297);
            this.comboBoxVaiTro.Name = "comboBoxVaiTro";
            this.comboBoxVaiTro.Size = new System.Drawing.Size(200, 24);
            this.comboBoxVaiTro.TabIndex = 15;
            // 
            // labelMaDV
            // 
            this.labelMaDV.AutoSize = true;
            this.labelMaDV.Location = new System.Drawing.Point(30, 340);
            this.labelMaDV.Name = "labelMaDV";
            this.labelMaDV.Size = new System.Drawing.Size(68, 16);
            this.labelMaDV.TabIndex = 16;
            this.labelMaDV.Text = "Mã đơn vị:";
            // 
            // buttonLuu
            // 
            this.buttonLuu.Location = new System.Drawing.Point(80, 380);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(100, 30);
            this.buttonLuu.TabIndex = 18;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // buttonHuy
            // 
            this.buttonHuy.Location = new System.Drawing.Point(220, 380);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(100, 30);
            this.buttonHuy.TabIndex = 19;
            this.buttonHuy.Text = "Hủy";
            this.buttonHuy.UseVisualStyleBackColor = true;
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // comboBoxDV
            // 
            this.comboBoxDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDV.FormattingEnabled = true;
            this.comboBoxDV.Items.AddRange(new object[] {
            "NVCB",
            "GV",
            "NV PĐT",
            "NV PKT",
            "NV TCHC",
            "NV CTSV",
            "TRGĐV"});
            this.comboBoxDV.Location = new System.Drawing.Point(150, 337);
            this.comboBoxDV.Name = "comboBoxDV";
            this.comboBoxDV.Size = new System.Drawing.Size(200, 24);
            this.comboBoxDV.TabIndex = 15;
            // 
            // NhanVienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.buttonHuy);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.labelMaDV);
            this.Controls.Add(this.comboBoxDV);
            this.Controls.Add(this.comboBoxVaiTro);
            this.Controls.Add(this.labelVaiTro);
            this.Controls.Add(this.textBoxDT);
            this.Controls.Add(this.labelDT);
            this.Controls.Add(this.textBoxPhuCap);
            this.Controls.Add(this.labelPhuCap);
            this.Controls.Add(this.textBoxLuong);
            this.Controls.Add(this.labelLuong);
            this.Controls.Add(this.dateTimePickerNgSinh);
            this.Controls.Add(this.labelNgSinh);
            this.Controls.Add(this.comboBoxPhai);
            this.Controls.Add(this.labelPhai);
            this.Controls.Add(this.textBoxHoten);
            this.Controls.Add(this.labelHoten);
            this.Controls.Add(this.textBoxManld);
            this.Controls.Add(this.labelManld);
            this.Name = "NhanVienForm";
            this.Text = "Thêm nhân viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelManld;
        private System.Windows.Forms.TextBox textBoxManld;
        private System.Windows.Forms.Label labelHoten;
        private System.Windows.Forms.TextBox textBoxHoten;
        private System.Windows.Forms.Label labelPhai;
        private System.Windows.Forms.ComboBox comboBoxPhai;
        private System.Windows.Forms.Label labelNgSinh;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgSinh;
        private System.Windows.Forms.Label labelLuong;
        private System.Windows.Forms.TextBox textBoxLuong;
        private System.Windows.Forms.Label labelPhuCap;
        private System.Windows.Forms.TextBox textBoxPhuCap;
        private System.Windows.Forms.Label labelDT;
        private System.Windows.Forms.TextBox textBoxDT;
        private System.Windows.Forms.Label labelVaiTro;
        private System.Windows.Forms.ComboBox comboBoxVaiTro;
        private System.Windows.Forms.Label labelMaDV;
        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.Button buttonHuy;
        private System.Windows.Forms.ComboBox comboBoxDV;
    }
}
