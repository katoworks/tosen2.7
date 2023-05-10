namespace tosen2
{
    partial class printAll
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
            this.label4 = new System.Windows.Forms.Label();
            this.printPaper = new System.Windows.Forms.ComboBox();
            this.prtCntTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.prtLabel = new System.Windows.Forms.Label();
            this.prtDeviceList = new System.Windows.Forms.ComboBox();
            this.canPrt = new System.Windows.Forms.Button();
            this.prrStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.prtDataList = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.grpBox = new System.Windows.Forms.ComboBox();
            this.selGrp = new System.Windows.Forms.Button();
            this.kensu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.searchAddr = new System.Windows.Forms.TextBox();
            this.searchName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.allChk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.prtDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "用紙：";
            // 
            // printPaper
            // 
            this.printPaper.BackColor = System.Drawing.SystemColors.Info;
            this.printPaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.printPaper.FormattingEnabled = true;
            this.printPaper.Location = new System.Drawing.Point(470, 33);
            this.printPaper.Margin = new System.Windows.Forms.Padding(5);
            this.printPaper.Name = "printPaper";
            this.printPaper.Size = new System.Drawing.Size(184, 28);
            this.printPaper.TabIndex = 2;
            // 
            // prtCntTxt
            // 
            this.prtCntTxt.Location = new System.Drawing.Point(675, 33);
            this.prtCntTxt.Name = "prtCntTxt";
            this.prtCntTxt.Size = new System.Drawing.Size(53, 28);
            this.prtCntTxt.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(671, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "部数：";
            // 
            // prtLabel
            // 
            this.prtLabel.AutoSize = true;
            this.prtLabel.Location = new System.Drawing.Point(12, 9);
            this.prtLabel.Name = "prtLabel";
            this.prtLabel.Size = new System.Drawing.Size(69, 20);
            this.prtLabel.TabIndex = 12;
            this.prtLabel.Text = "プリンタ：";
            // 
            // prtDeviceList
            // 
            this.prtDeviceList.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.prtDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prtDeviceList.FormattingEnabled = true;
            this.prtDeviceList.Location = new System.Drawing.Point(12, 33);
            this.prtDeviceList.Margin = new System.Windows.Forms.Padding(5);
            this.prtDeviceList.Name = "prtDeviceList";
            this.prtDeviceList.Size = new System.Drawing.Size(448, 28);
            this.prtDeviceList.TabIndex = 1;
            // 
            // canPrt
            // 
            this.canPrt.Location = new System.Drawing.Point(1025, 554);
            this.canPrt.Name = "canPrt";
            this.canPrt.Size = new System.Drawing.Size(90, 35);
            this.canPrt.TabIndex = 9;
            this.canPrt.Text = "戻る";
            this.canPrt.UseVisualStyleBackColor = true;
            this.canPrt.Click += new System.EventHandler(this.canPrt_Click);
            // 
            // prrStart
            // 
            this.prrStart.Enabled = false;
            this.prrStart.Location = new System.Drawing.Point(1009, 157);
            this.prrStart.Name = "prrStart";
            this.prrStart.Size = new System.Drawing.Size(90, 27);
            this.prrStart.TabIndex = 8;
            this.prrStart.Text = "印刷";
            this.prrStart.UseVisualStyleBackColor = true;
            this.prrStart.Click += new System.EventHandler(this.prrStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "印刷リスト：";
            // 
            // prtDataList
            // 
            this.prtDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prtDataList.Location = new System.Drawing.Point(17, 239);
            this.prtDataList.Name = "prtDataList";
            this.prtDataList.RowTemplate.Height = 21;
            this.prtDataList.Size = new System.Drawing.Size(1098, 300);
            this.prtDataList.TabIndex = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(736, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "印刷グループ：";
            // 
            // grpBox
            // 
            this.grpBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grpBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.grpBox.FormattingEnabled = true;
            this.grpBox.Location = new System.Drawing.Point(736, 33);
            this.grpBox.Margin = new System.Windows.Forms.Padding(5);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(184, 28);
            this.grpBox.TabIndex = 3;
            // 
            // selGrp
            // 
            this.selGrp.Location = new System.Drawing.Point(807, 157);
            this.selGrp.Name = "selGrp";
            this.selGrp.Size = new System.Drawing.Size(100, 28);
            this.selGrp.TabIndex = 6;
            this.selGrp.Text = "検索";
            this.selGrp.UseVisualStyleBackColor = true;
            this.selGrp.Click += new System.EventHandler(this.selGrp_Click);
            // 
            // kensu
            // 
            this.kensu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kensu.Location = new System.Drawing.Point(1009, 206);
            this.kensu.Name = "kensu";
            this.kensu.ReadOnly = true;
            this.kensu.Size = new System.Drawing.Size(100, 28);
            this.kensu.TabIndex = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(955, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "件数:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "オプション検索(住所)：";
            // 
            // searchAddr
            // 
            this.searchAddr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.searchAddr.Location = new System.Drawing.Point(12, 93);
            this.searchAddr.Name = "searchAddr";
            this.searchAddr.Size = new System.Drawing.Size(457, 28);
            this.searchAddr.TabIndex = 4;
            // 
            // searchName
            // 
            this.searchName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.searchName.Location = new System.Drawing.Point(13, 157);
            this.searchName.Name = "searchName";
            this.searchName.Size = new System.Drawing.Size(457, 28);
            this.searchName.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "オプション検索(氏名カナ)：";
            // 
            // allChk
            // 
            this.allChk.Location = new System.Drawing.Point(913, 157);
            this.allChk.Name = "allChk";
            this.allChk.Size = new System.Drawing.Size(90, 27);
            this.allChk.TabIndex = 7;
            this.allChk.Text = "全選択";
            this.allChk.UseVisualStyleBackColor = true;
            this.allChk.Click += new System.EventHandler(this.allChk_Click);
            // 
            // printAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 601);
            this.Controls.Add(this.allChk);
            this.Controls.Add(this.searchName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.searchAddr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kensu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.selGrp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prtDataList);
            this.Controls.Add(this.canPrt);
            this.Controls.Add(this.prrStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.printPaper);
            this.Controls.Add(this.prtCntTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prtLabel);
            this.Controls.Add(this.prtDeviceList);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "printAll";
            this.Text = "一覧印刷";
            ((System.ComponentModel.ISupportInitialize)(this.prtDataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox printPaper;
        private System.Windows.Forms.TextBox prtCntTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label prtLabel;
        private System.Windows.Forms.ComboBox prtDeviceList;
        private System.Windows.Forms.Button canPrt;
        private System.Windows.Forms.Button prrStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView prtDataList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox grpBox;
        private System.Windows.Forms.Button selGrp;
        private System.Windows.Forms.TextBox kensu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox searchAddr;
        private System.Windows.Forms.TextBox searchName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button allChk;
    }
}