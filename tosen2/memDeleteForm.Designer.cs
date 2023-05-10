namespace tosen2
{
    partial class memDeleteForm
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
            this.kanSrch = new System.Windows.Forms.Button();
            this.kanaSrch = new System.Windows.Forms.Button();
            this.dataList = new System.Windows.Forms.DataGridView();
            this.searchLabel = new System.Windows.Forms.Label();
            this.srchWord = new System.Windows.Forms.TextBox();
            this.deleteUser = new System.Windows.Forms.Button();
            this.dspEnd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).BeginInit();
            this.SuspendLayout();
            // 
            // kanSrch
            // 
            this.kanSrch.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kanSrch.Location = new System.Drawing.Point(420, 36);
            this.kanSrch.Name = "kanSrch";
            this.kanSrch.Size = new System.Drawing.Size(196, 28);
            this.kanSrch.TabIndex = 7;
            this.kanSrch.Text = "漢字検索";
            this.kanSrch.UseVisualStyleBackColor = true;
            // 
            // kanaSrch
            // 
            this.kanaSrch.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kanaSrch.Location = new System.Drawing.Point(218, 36);
            this.kanaSrch.Name = "kanaSrch";
            this.kanaSrch.Size = new System.Drawing.Size(196, 28);
            this.kanaSrch.TabIndex = 5;
            this.kanaSrch.Text = "カナ検索";
            this.kanaSrch.UseVisualStyleBackColor = true;
            // 
            // dataList
            // 
            this.dataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataList.Location = new System.Drawing.Point(16, 88);
            this.dataList.Name = "dataList";
            this.dataList.RowTemplate.Height = 21;
            this.dataList.Size = new System.Drawing.Size(1283, 420);
            this.dataList.TabIndex = 8;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(12, 9);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(73, 20);
            this.searchLabel.TabIndex = 6;
            this.searchLabel.Text = "氏名検索";
            // 
            // srchWord
            // 
            this.srchWord.ImeMode = System.Windows.Forms.ImeMode.On;
            this.srchWord.Location = new System.Drawing.Point(16, 36);
            this.srchWord.Name = "srchWord";
            this.srchWord.Size = new System.Drawing.Size(196, 28);
            this.srchWord.TabIndex = 4;
            // 
            // deleteUser
            // 
            this.deleteUser.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deleteUser.Location = new System.Drawing.Point(622, 36);
            this.deleteUser.Name = "deleteUser";
            this.deleteUser.Size = new System.Drawing.Size(196, 28);
            this.deleteUser.TabIndex = 9;
            this.deleteUser.Text = "削除";
            this.deleteUser.UseVisualStyleBackColor = true;
            // 
            // dspEnd
            // 
            this.dspEnd.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dspEnd.Location = new System.Drawing.Point(1224, 522);
            this.dspEnd.Name = "dspEnd";
            this.dspEnd.Size = new System.Drawing.Size(75, 27);
            this.dspEnd.TabIndex = 10;
            this.dspEnd.Text = "終了";
            this.dspEnd.UseVisualStyleBackColor = true;
            this.dspEnd.Click += new System.EventHandler(this.dspEnd_Click);
            // 
            // memDeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 561);
            this.Controls.Add(this.dspEnd);
            this.Controls.Add(this.deleteUser);
            this.Controls.Add(this.kanSrch);
            this.Controls.Add(this.kanaSrch);
            this.Controls.Add(this.dataList);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.srchWord);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "memDeleteForm";
            this.Text = "会員情報削除";
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kanSrch;
        private System.Windows.Forms.Button kanaSrch;
        private System.Windows.Forms.DataGridView dataList;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox srchWord;
        private System.Windows.Forms.Button deleteUser;
        private System.Windows.Forms.Button dspEnd;
    }
}