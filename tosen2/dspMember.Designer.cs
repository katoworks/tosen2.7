namespace tosen2
{
    partial class dspMember
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dspMember));
            this.dspEnd = new System.Windows.Forms.Button();
            this.srchWord = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.dataList = new System.Windows.Forms.DataGridView();
            this.kanaSrch = new System.Windows.Forms.Button();
            this.kanSrch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.kensu = new System.Windows.Forms.TextBox();
            this.prtStart = new System.Windows.Forms.Button();
            this.allChk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).BeginInit();
            this.SuspendLayout();
            // 
            // dspEnd
            // 
            this.dspEnd.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dspEnd.Location = new System.Drawing.Point(1220, 522);
            this.dspEnd.Name = "dspEnd";
            this.dspEnd.Size = new System.Drawing.Size(75, 27);
            this.dspEnd.TabIndex = 0;
            this.dspEnd.Text = "終了";
            this.dspEnd.UseVisualStyleBackColor = true;
            this.dspEnd.Click += new System.EventHandler(this.dspEnd_Click);
            // 
            // srchWord
            // 
            this.srchWord.ImeMode = System.Windows.Forms.ImeMode.On;
            this.srchWord.Location = new System.Drawing.Point(12, 36);
            this.srchWord.Name = "srchWord";
            this.srchWord.Size = new System.Drawing.Size(196, 28);
            this.srchWord.TabIndex = 1;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(8, 9);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(73, 20);
            this.searchLabel.TabIndex = 2;
            this.searchLabel.Text = "氏名検索";
            // 
            // dataList
            // 
            this.dataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataList.Location = new System.Drawing.Point(12, 88);
            this.dataList.Name = "dataList";
            this.dataList.RowTemplate.Height = 21;
            this.dataList.Size = new System.Drawing.Size(1283, 420);
            this.dataList.TabIndex = 3;
            // 
            // kanaSrch
            // 
            this.kanaSrch.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kanaSrch.Location = new System.Drawing.Point(214, 36);
            this.kanaSrch.Name = "kanaSrch";
            this.kanaSrch.Size = new System.Drawing.Size(196, 28);
            this.kanaSrch.TabIndex = 2;
            this.kanaSrch.Text = "カナ検索";
            this.kanaSrch.UseVisualStyleBackColor = true;
            this.kanaSrch.Click += new System.EventHandler(this.kanaSrch_Click);
            // 
            // kanSrch
            // 
            this.kanSrch.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kanSrch.Location = new System.Drawing.Point(416, 36);
            this.kanSrch.Name = "kanSrch";
            this.kanSrch.Size = new System.Drawing.Size(196, 28);
            this.kanSrch.TabIndex = 3;
            this.kanSrch.Text = "漢字検索";
            this.kanSrch.UseVisualStyleBackColor = true;
            this.kanSrch.Click += new System.EventHandler(this.kanSrch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1125, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "件数:";
            // 
            // kensu
            // 
            this.kensu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kensu.Location = new System.Drawing.Point(1179, 33);
            this.kensu.Name = "kensu";
            this.kensu.ReadOnly = true;
            this.kensu.Size = new System.Drawing.Size(100, 28);
            this.kensu.TabIndex = 6;
            // 
            // prtStart
            // 
            this.prtStart.Location = new System.Drawing.Point(618, 36);
            this.prtStart.Name = "prtStart";
            this.prtStart.Size = new System.Drawing.Size(196, 28);
            this.prtStart.TabIndex = 7;
            this.prtStart.Text = "印刷";
            this.prtStart.UseVisualStyleBackColor = true;
            this.prtStart.Click += new System.EventHandler(this.prtStart_Click);
            // 
            // allChk
            // 
            this.allChk.Location = new System.Drawing.Point(820, 37);
            this.allChk.Name = "allChk";
            this.allChk.Size = new System.Drawing.Size(196, 27);
            this.allChk.TabIndex = 11;
            this.allChk.Text = "全選択";
            this.allChk.UseVisualStyleBackColor = true;
            this.allChk.Click += new System.EventHandler(this.allChk_Click);
            // 
            // dspMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 561);
            this.Controls.Add(this.allChk);
            this.Controls.Add(this.prtStart);
            this.Controls.Add(this.kensu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kanSrch);
            this.Controls.Add(this.kanaSrch);
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.srchWord);
            this.Controls.Add(this.dspEnd);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "dspMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参照";
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dspEnd;
        private System.Windows.Forms.TextBox srchWord;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.DataGridView dataList;
        private System.Windows.Forms.Button kanaSrch;
        private System.Windows.Forms.Button kanSrch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox kensu;
        private System.Windows.Forms.Button prtStart;
        private System.Windows.Forms.Button allChk;
    }
}