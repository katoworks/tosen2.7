namespace tosen2
{
    partial class dataEditMenu
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
            this.edtiData = new System.Windows.Forms.TabControl();
            this.editPrint = new System.Windows.Forms.TabPage();
            this.hagakiPrt = new System.Windows.Forms.Button();
            this.listPrint = new System.Windows.Forms.Button();
            this.groupPrint = new System.Windows.Forms.Button();
            this.kaisyaPrint = new System.Windows.Forms.Button();
            this.simeiPrint = new System.Windows.Forms.Button();
            this.editData = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataChg = new System.Windows.Forms.Button();
            this.dataAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.editExit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.export = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.infomation = new System.Windows.Forms.TextBox();
            this.edtiData.SuspendLayout();
            this.editPrint.SuspendLayout();
            this.editData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtiData
            // 
            this.edtiData.Controls.Add(this.editPrint);
            this.edtiData.Controls.Add(this.editData);
            this.edtiData.Location = new System.Drawing.Point(28, 72);
            this.edtiData.Name = "edtiData";
            this.edtiData.SelectedIndex = 0;
            this.edtiData.Size = new System.Drawing.Size(507, 292);
            this.edtiData.TabIndex = 0;
            // 
            // editPrint
            // 
            this.editPrint.Controls.Add(this.hagakiPrt);
            this.editPrint.Controls.Add(this.listPrint);
            this.editPrint.Controls.Add(this.groupPrint);
            this.editPrint.Controls.Add(this.kaisyaPrint);
            this.editPrint.Controls.Add(this.simeiPrint);
            this.editPrint.Location = new System.Drawing.Point(4, 22);
            this.editPrint.Name = "editPrint";
            this.editPrint.Padding = new System.Windows.Forms.Padding(3);
            this.editPrint.Size = new System.Drawing.Size(499, 266);
            this.editPrint.TabIndex = 0;
            this.editPrint.Text = "印刷";
            this.editPrint.UseVisualStyleBackColor = true;
            // 
            // hagakiPrt
            // 
            this.hagakiPrt.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.hagakiPrt.Location = new System.Drawing.Point(176, 139);
            this.hagakiPrt.Name = "hagakiPrt";
            this.hagakiPrt.Size = new System.Drawing.Size(133, 50);
            this.hagakiPrt.TabIndex = 9;
            this.hagakiPrt.Text = "はがき印刷";
            this.hagakiPrt.UseVisualStyleBackColor = true;
            this.hagakiPrt.Click += new System.EventHandler(this.hagakiPrt_Click);
            // 
            // listPrint
            // 
            this.listPrint.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listPrint.Location = new System.Drawing.Point(24, 142);
            this.listPrint.Name = "listPrint";
            this.listPrint.Size = new System.Drawing.Size(133, 48);
            this.listPrint.TabIndex = 3;
            this.listPrint.Text = "一覧印刷";
            this.listPrint.UseVisualStyleBackColor = true;
            this.listPrint.Click += new System.EventHandler(this.listPrint_Click);
            // 
            // groupPrint
            // 
            this.groupPrint.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupPrint.Location = new System.Drawing.Point(330, 53);
            this.groupPrint.Name = "groupPrint";
            this.groupPrint.Size = new System.Drawing.Size(133, 48);
            this.groupPrint.TabIndex = 2;
            this.groupPrint.Text = "所属印刷";
            this.groupPrint.UseVisualStyleBackColor = true;
            this.groupPrint.Click += new System.EventHandler(this.groupPrint_Click);
            // 
            // kaisyaPrint
            // 
            this.kaisyaPrint.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kaisyaPrint.Location = new System.Drawing.Point(176, 53);
            this.kaisyaPrint.Name = "kaisyaPrint";
            this.kaisyaPrint.Size = new System.Drawing.Size(133, 48);
            this.kaisyaPrint.TabIndex = 1;
            this.kaisyaPrint.Text = "会社印刷";
            this.kaisyaPrint.UseVisualStyleBackColor = true;
            this.kaisyaPrint.Click += new System.EventHandler(this.kaisyaPrint_Click);
            // 
            // simeiPrint
            // 
            this.simeiPrint.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.simeiPrint.Location = new System.Drawing.Point(24, 53);
            this.simeiPrint.Name = "simeiPrint";
            this.simeiPrint.Size = new System.Drawing.Size(133, 48);
            this.simeiPrint.TabIndex = 0;
            this.simeiPrint.Text = "氏名印刷";
            this.simeiPrint.UseVisualStyleBackColor = true;
            this.simeiPrint.Click += new System.EventHandler(this.simeiPrint_Click);
            // 
            // editData
            // 
            this.editData.Controls.Add(this.groupBox2);
            this.editData.Controls.Add(this.groupBox1);
            this.editData.Location = new System.Drawing.Point(4, 22);
            this.editData.Name = "editData";
            this.editData.Padding = new System.Windows.Forms.Padding(3);
            this.editData.Size = new System.Drawing.Size(499, 266);
            this.editData.TabIndex = 1;
            this.editData.Text = "データ編集";
            this.editData.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataChg);
            this.groupBox1.Controls.Add(this.dataAdd);
            this.groupBox1.Location = new System.Drawing.Point(18, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "データ編集";
            // 
            // dataChg
            // 
            this.dataChg.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dataChg.Location = new System.Drawing.Point(232, 31);
            this.dataChg.Name = "dataChg";
            this.dataChg.Size = new System.Drawing.Size(167, 50);
            this.dataChg.TabIndex = 5;
            this.dataChg.Text = "変更";
            this.dataChg.UseVisualStyleBackColor = true;
            this.dataChg.Click += new System.EventHandler(this.dataChg_Click);
            // 
            // dataAdd
            // 
            this.dataAdd.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dataAdd.Location = new System.Drawing.Point(29, 31);
            this.dataAdd.Name = "dataAdd";
            this.dataAdd.Size = new System.Drawing.Size(153, 50);
            this.dataAdd.TabIndex = 4;
            this.dataAdd.Text = "新規追加";
            this.dataAdd.UseVisualStyleBackColor = true;
            this.dataAdd.Click += new System.EventHandler(this.dataAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(155, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "データ印刷・編集";
            // 
            // editExit
            // 
            this.editExit.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.editExit.Location = new System.Drawing.Point(380, 379);
            this.editExit.Name = "editExit";
            this.editExit.Size = new System.Drawing.Size(155, 39);
            this.editExit.TabIndex = 2;
            this.editExit.Text = "編集終了";
            this.editExit.UseVisualStyleBackColor = true;
            this.editExit.Click += new System.EventHandler(this.editExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.infomation);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.export);
            this.groupBox2.Location = new System.Drawing.Point(18, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 107);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "データメンテナンス";
            // 
            // export
            // 
            this.export.Font = new System.Drawing.Font("Meiryo UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.export.Location = new System.Drawing.Point(32, 30);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(153, 50);
            this.export.TabIndex = 0;
            this.export.Text = "データバックアップ";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Infomation";
            // 
            // infomation
            // 
            this.infomation.Enabled = false;
            this.infomation.Location = new System.Drawing.Point(232, 39);
            this.infomation.Name = "infomation";
            this.infomation.Size = new System.Drawing.Size(196, 19);
            this.infomation.TabIndex = 2;
            // 
            // dataEditMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 430);
            this.Controls.Add(this.editExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtiData);
            this.Name = "dataEditMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "データ編集";
            this.edtiData.ResumeLayout(false);
            this.editPrint.ResumeLayout(false);
            this.editData.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl edtiData;
        private System.Windows.Forms.TabPage editPrint;
        private System.Windows.Forms.TabPage editData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editExit;
        private System.Windows.Forms.Button listPrint;
        private System.Windows.Forms.Button groupPrint;
        private System.Windows.Forms.Button kaisyaPrint;
        private System.Windows.Forms.Button simeiPrint;
        private System.Windows.Forms.Button hagakiPrt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button dataAdd;
        private System.Windows.Forms.Button dataChg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.TextBox infomation;
        private System.Windows.Forms.Label label2;
    }
}