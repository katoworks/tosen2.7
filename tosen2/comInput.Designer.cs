namespace tosen2
{
    partial class comInput
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveAs = new System.Windows.Forms.Button();
            this.comLabel = new System.Windows.Forms.Label();
            this.comName = new System.Windows.Forms.TextBox();
            this.zip1 = new System.Windows.Forms.TextBox();
            this.comZipLabel = new System.Windows.Forms.Label();
            this.comAddr = new System.Windows.Forms.TextBox();
            this.comAddrLabel = new System.Windows.Forms.Label();
            this.comKataLabel = new System.Windows.Forms.Label();
            this.zip2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comKata = new System.Windows.Forms.TextBox();
            this.comShimei = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comShimeiRubi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(361, 341);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(136, 36);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "キャンセル";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveAs
            // 
            this.saveAs.Location = new System.Drawing.Point(219, 341);
            this.saveAs.Name = "saveAs";
            this.saveAs.Size = new System.Drawing.Size(136, 36);
            this.saveAs.TabIndex = 10;
            this.saveAs.Text = "保存";
            this.saveAs.UseVisualStyleBackColor = true;
            this.saveAs.Click += new System.EventHandler(this.saveAs_Click);
            // 
            // comLabel
            // 
            this.comLabel.AutoSize = true;
            this.comLabel.Location = new System.Drawing.Point(24, 19);
            this.comLabel.Name = "comLabel";
            this.comLabel.Size = new System.Drawing.Size(57, 20);
            this.comLabel.TabIndex = 2;
            this.comLabel.Text = "会社名";
            // 
            // comName
            // 
            this.comName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.comName.Location = new System.Drawing.Point(28, 42);
            this.comName.Name = "comName";
            this.comName.Size = new System.Drawing.Size(278, 28);
            this.comName.TabIndex = 1;
            // 
            // zip1
            // 
            this.zip1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.zip1.Location = new System.Drawing.Point(28, 103);
            this.zip1.Name = "zip1";
            this.zip1.Size = new System.Drawing.Size(53, 28);
            this.zip1.TabIndex = 2;
            // 
            // comZipLabel
            // 
            this.comZipLabel.AutoSize = true;
            this.comZipLabel.Location = new System.Drawing.Point(24, 80);
            this.comZipLabel.Name = "comZipLabel";
            this.comZipLabel.Size = new System.Drawing.Size(105, 20);
            this.comZipLabel.TabIndex = 4;
            this.comZipLabel.Text = "会社郵便番号";
            // 
            // comAddr
            // 
            this.comAddr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.comAddr.Location = new System.Drawing.Point(28, 163);
            this.comAddr.Name = "comAddr";
            this.comAddr.Size = new System.Drawing.Size(469, 28);
            this.comAddr.TabIndex = 4;
            // 
            // comAddrLabel
            // 
            this.comAddrLabel.AutoSize = true;
            this.comAddrLabel.Location = new System.Drawing.Point(24, 140);
            this.comAddrLabel.Name = "comAddrLabel";
            this.comAddrLabel.Size = new System.Drawing.Size(73, 20);
            this.comAddrLabel.TabIndex = 6;
            this.comAddrLabel.Text = "会社住所";
            // 
            // comKataLabel
            // 
            this.comKataLabel.AutoSize = true;
            this.comKataLabel.Location = new System.Drawing.Point(24, 201);
            this.comKataLabel.Name = "comKataLabel";
            this.comKataLabel.Size = new System.Drawing.Size(53, 20);
            this.comKataLabel.TabIndex = 8;
            this.comKataLabel.Text = "肩書き";
            // 
            // zip2
            // 
            this.zip2.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.zip2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.zip2.Location = new System.Drawing.Point(106, 103);
            this.zip2.Name = "zip2";
            this.zip2.Size = new System.Drawing.Size(50, 28);
            this.zip2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(86, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "-";
            // 
            // comKata
            // 
            this.comKata.ImeMode = System.Windows.Forms.ImeMode.On;
            this.comKata.Location = new System.Drawing.Point(28, 224);
            this.comKata.Name = "comKata";
            this.comKata.Size = new System.Drawing.Size(174, 28);
            this.comKata.TabIndex = 5;
            // 
            // comShimei
            // 
            this.comShimei.ImeMode = System.Windows.Forms.ImeMode.On;
            this.comShimei.Location = new System.Drawing.Point(28, 282);
            this.comShimei.Name = "comShimei";
            this.comShimei.Size = new System.Drawing.Size(174, 28);
            this.comShimei.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "氏名";
            // 
            // comShimeiRubi
            // 
            this.comShimeiRubi.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.comShimeiRubi.Location = new System.Drawing.Point(232, 282);
            this.comShimeiRubi.Name = "comShimeiRubi";
            this.comShimeiRubi.Size = new System.Drawing.Size(174, 28);
            this.comShimeiRubi.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "氏名カナ";
            // 
            // comInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 389);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comShimeiRubi);
            this.Controls.Add(this.comShimei);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.zip2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comKata);
            this.Controls.Add(this.comKataLabel);
            this.Controls.Add(this.comAddr);
            this.Controls.Add(this.comAddrLabel);
            this.Controls.Add(this.zip1);
            this.Controls.Add(this.comZipLabel);
            this.Controls.Add(this.comName);
            this.Controls.Add(this.comLabel);
            this.Controls.Add(this.saveAs);
            this.Controls.Add(this.cancelBtn);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "comInput";
            this.Text = "会社情報入力";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveAs;
        private System.Windows.Forms.Label comLabel;
        private System.Windows.Forms.TextBox comName;
        private System.Windows.Forms.TextBox zip1;
        private System.Windows.Forms.Label comZipLabel;
        private System.Windows.Forms.TextBox comAddr;
        private System.Windows.Forms.Label comAddrLabel;
        private System.Windows.Forms.Label comKataLabel;
        private System.Windows.Forms.TextBox zip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox comKata;
        private System.Windows.Forms.TextBox comShimei;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox comShimeiRubi;
        private System.Windows.Forms.Label label3;
    }
}