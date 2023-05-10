namespace tosen2
{
    partial class updateMember
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(updateMember));
            this.InfoEdit = new System.Windows.Forms.Button();
            this.deleteMember = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.srchWord = new System.Windows.Forms.Button();
            this.compaName = new System.Windows.Forms.TextBox();
            this.companyLabel = new System.Windows.Forms.Label();
            this.syozoku = new System.Windows.Forms.Label();
            this.kindList = new System.Windows.Forms.ComboBox();
            this.nameRubi = new System.Windows.Forms.TextBox();
            this.nameRubiLabel = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.selList = new System.Windows.Forms.DataGridView();
            this.addFami = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selList)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoEdit
            // 
            this.InfoEdit.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.InfoEdit.Location = new System.Drawing.Point(534, 438);
            this.InfoEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InfoEdit.Name = "InfoEdit";
            this.InfoEdit.Size = new System.Drawing.Size(136, 36);
            this.InfoEdit.TabIndex = 18;
            this.InfoEdit.Text = "情報変更";
            this.InfoEdit.UseVisualStyleBackColor = true;
            this.InfoEdit.Click += new System.EventHandler(this.famiInfoInput_Click);
            // 
            // deleteMember
            // 
            this.deleteMember.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deleteMember.Location = new System.Drawing.Point(392, 438);
            this.deleteMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteMember.Name = "deleteMember";
            this.deleteMember.Size = new System.Drawing.Size(136, 36);
            this.deleteMember.TabIndex = 17;
            this.deleteMember.Text = "会員削除";
            this.deleteMember.UseVisualStyleBackColor = true;
            this.deleteMember.Click += new System.EventHandler(this.companyInput_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.srchWord);
            this.groupBox1.Controls.Add(this.compaName);
            this.groupBox1.Controls.Add(this.companyLabel);
            this.groupBox1.Controls.Add(this.syozoku);
            this.groupBox1.Controls.Add(this.kindList);
            this.groupBox1.Controls.Add(this.nameRubi);
            this.groupBox1.Controls.Add(this.nameRubiLabel);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 130);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "世帯情報";
            // 
            // srchWord
            // 
            this.srchWord.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.srchWord.Location = new System.Drawing.Point(6, 87);
            this.srchWord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.srchWord.Name = "srchWord";
            this.srchWord.Size = new System.Drawing.Size(136, 36);
            this.srchWord.TabIndex = 17;
            this.srchWord.Text = "検索";
            this.srchWord.UseVisualStyleBackColor = true;
            this.srchWord.Click += new System.EventHandler(this.srchWord_Click);
            // 
            // compaName
            // 
            this.compaName.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.compaName.Location = new System.Drawing.Point(411, 50);
            this.compaName.Name = "compaName";
            this.compaName.Size = new System.Drawing.Size(197, 28);
            this.compaName.TabIndex = 6;
            // 
            // companyLabel
            // 
            this.companyLabel.AutoSize = true;
            this.companyLabel.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.companyLabel.Location = new System.Drawing.Point(408, 24);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(57, 20);
            this.companyLabel.TabIndex = 7;
            this.companyLabel.Text = "会社名";
            // 
            // syozoku
            // 
            this.syozoku.AutoSize = true;
            this.syozoku.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.syozoku.Location = new System.Drawing.Point(610, 25);
            this.syozoku.Name = "syozoku";
            this.syozoku.Size = new System.Drawing.Size(41, 20);
            this.syozoku.TabIndex = 13;
            this.syozoku.Text = "所属";
            // 
            // kindList
            // 
            this.kindList.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kindList.FormattingEnabled = true;
            this.kindList.Location = new System.Drawing.Point(614, 50);
            this.kindList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kindList.Name = "kindList";
            this.kindList.Size = new System.Drawing.Size(163, 28);
            this.kindList.TabIndex = 12;
            // 
            // nameRubi
            // 
            this.nameRubi.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nameRubi.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.nameRubi.Location = new System.Drawing.Point(208, 50);
            this.nameRubi.Name = "nameRubi";
            this.nameRubi.Size = new System.Drawing.Size(197, 28);
            this.nameRubi.TabIndex = 3;
            // 
            // nameRubiLabel
            // 
            this.nameRubiLabel.AutoSize = true;
            this.nameRubiLabel.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nameRubiLabel.Location = new System.Drawing.Point(204, 24);
            this.nameRubiLabel.Name = "nameRubiLabel";
            this.nameRubiLabel.Size = new System.Drawing.Size(87, 20);
            this.nameRubiLabel.TabIndex = 2;
            this.nameRubiLabel.Text = "氏名フリガナ";
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.name.ImeMode = System.Windows.Forms.ImeMode.On;
            this.name.Location = new System.Drawing.Point(5, 50);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(197, 28);
            this.name.TabIndex = 2;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nameLabel.Location = new System.Drawing.Point(5, 25);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "氏名";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(676, 438);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 36);
            this.button2.TabIndex = 16;
            this.button2.Text = "終了";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // selList
            // 
            this.selList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selList.Location = new System.Drawing.Point(12, 160);
            this.selList.Name = "selList";
            this.selList.RowTemplate.Height = 21;
            this.selList.Size = new System.Drawing.Size(801, 256);
            this.selList.TabIndex = 19;
            // 
            // addFami
            // 
            this.addFami.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.addFami.Location = new System.Drawing.Point(250, 438);
            this.addFami.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addFami.Name = "addFami";
            this.addFami.Size = new System.Drawing.Size(136, 36);
            this.addFami.TabIndex = 20;
            this.addFami.Text = "家族情報追加";
            this.addFami.UseVisualStyleBackColor = true;
            this.addFami.Click += new System.EventHandler(this.addFami_Click);
            // 
            // updateMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 483);
            this.Controls.Add(this.addFami);
            this.Controls.Add(this.selList);
            this.Controls.Add(this.InfoEdit);
            this.Controls.Add(this.deleteMember);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "updateMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "メンバー情報変更";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InfoEdit;
        private System.Windows.Forms.Button deleteMember;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox compaName;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.TextBox nameRubi;
        private System.Windows.Forms.Label nameRubiLabel;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label syozoku;
        private System.Windows.Forms.ComboBox kindList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button srchWord;
        private System.Windows.Forms.DataGridView selList;
        private System.Windows.Forms.Button addFami;
    }
}