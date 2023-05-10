namespace tosen2
{
    partial class prtDialog
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
            this.endPrt = new System.Windows.Forms.Button();
            this.prtDeviceList = new System.Windows.Forms.ComboBox();
            this.prtLabel = new System.Windows.Forms.Label();
            this.prtDataList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prrStart = new System.Windows.Forms.Button();
            this.canPrt = new System.Windows.Forms.Button();
            this.prtCntTxt = new System.Windows.Forms.TextBox();
            this.prtInfo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.printPaper = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.prtDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // endPrt
            // 
            this.endPrt.Location = new System.Drawing.Point(888, 508);
            this.endPrt.Margin = new System.Windows.Forms.Padding(5);
            this.endPrt.Name = "endPrt";
            this.endPrt.Size = new System.Drawing.Size(125, 38);
            this.endPrt.TabIndex = 0;
            this.endPrt.Text = "終了";
            this.endPrt.UseVisualStyleBackColor = true;
            this.endPrt.Click += new System.EventHandler(this.endPrt_Click);
            // 
            // prtDeviceList
            // 
            this.prtDeviceList.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.prtDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prtDeviceList.FormattingEnabled = true;
            this.prtDeviceList.Location = new System.Drawing.Point(14, 40);
            this.prtDeviceList.Margin = new System.Windows.Forms.Padding(5);
            this.prtDeviceList.Name = "prtDeviceList";
            this.prtDeviceList.Size = new System.Drawing.Size(414, 28);
            this.prtDeviceList.TabIndex = 1;
            // 
            // prtLabel
            // 
            this.prtLabel.AutoSize = true;
            this.prtLabel.Location = new System.Drawing.Point(14, 16);
            this.prtLabel.Name = "prtLabel";
            this.prtLabel.Size = new System.Drawing.Size(69, 20);
            this.prtLabel.TabIndex = 2;
            this.prtLabel.Text = "プリンタ：";
            // 
            // prtDataList
            // 
            this.prtDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prtDataList.Location = new System.Drawing.Point(14, 95);
            this.prtDataList.Name = "prtDataList";
            this.prtDataList.RowTemplate.Height = 21;
            this.prtDataList.Size = new System.Drawing.Size(982, 209);
            this.prtDataList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "印刷リスト";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "部数：";
            // 
            // prrStart
            // 
            this.prrStart.Location = new System.Drawing.Point(906, 310);
            this.prrStart.Name = "prrStart";
            this.prrStart.Size = new System.Drawing.Size(90, 35);
            this.prrStart.TabIndex = 4;
            this.prrStart.Text = "印刷";
            this.prrStart.UseVisualStyleBackColor = true;
            this.prrStart.Click += new System.EventHandler(this.prrStart_Click);
            // 
            // canPrt
            // 
            this.canPrt.Location = new System.Drawing.Point(812, 310);
            this.canPrt.Name = "canPrt";
            this.canPrt.Size = new System.Drawing.Size(90, 35);
            this.canPrt.TabIndex = 3;
            this.canPrt.Text = "キャンセル";
            this.canPrt.UseVisualStyleBackColor = true;
            this.canPrt.Click += new System.EventHandler(this.canPrt_Click);
            // 
            // prtCntTxt
            // 
            this.prtCntTxt.Location = new System.Drawing.Point(643, 40);
            this.prtCntTxt.Name = "prtCntTxt";
            this.prtCntTxt.Size = new System.Drawing.Size(53, 28);
            this.prtCntTxt.TabIndex = 2;
            // 
            // prtInfo
            // 
            this.prtInfo.BackColor = System.Drawing.SystemColors.Menu;
            this.prtInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.prtInfo.FormattingEnabled = true;
            this.prtInfo.Location = new System.Drawing.Point(717, 40);
            this.prtInfo.Name = "prtInfo";
            this.prtInfo.Size = new System.Drawing.Size(121, 28);
            this.prtInfo.TabIndex = 6;
            this.prtInfo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(713, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "呼称：";
            // 
            // printPaper
            // 
            this.printPaper.BackColor = System.Drawing.SystemColors.Info;
            this.printPaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.printPaper.FormattingEnabled = true;
            this.printPaper.Location = new System.Drawing.Point(438, 40);
            this.printPaper.Margin = new System.Windows.Forms.Padding(5);
            this.printPaper.Name = "printPaper";
            this.printPaper.Size = new System.Drawing.Size(184, 28);
            this.printPaper.TabIndex = 8;
            this.printPaper.SelectedIndexChanged += new System.EventHandler(this.printPaper_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "用紙：";
            // 
            // prtDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 357);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.printPaper);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prtInfo);
            this.Controls.Add(this.prtCntTxt);
            this.Controls.Add(this.canPrt);
            this.Controls.Add(this.prrStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prtDataList);
            this.Controls.Add(this.prtLabel);
            this.Controls.Add(this.prtDeviceList);
            this.Controls.Add(this.endPrt);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "prtDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "印刷";
            ((System.ComponentModel.ISupportInitialize)(this.prtDataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button endPrt;
        private System.Windows.Forms.ComboBox prtDeviceList;
        private System.Windows.Forms.Label prtLabel;
        private System.Windows.Forms.DataGridView prtDataList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button prrStart;
        private System.Windows.Forms.Button canPrt;
        private System.Windows.Forms.TextBox prtCntTxt;
        private System.Windows.Forms.ComboBox prtInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox printPaper;
        private System.Windows.Forms.Label label4;
    }
}