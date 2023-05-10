namespace tosen2
{
    partial class mFamiAdd
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
            this.saveFami = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameRubi = new System.Windows.Forms.TextBox();
            this.nameRubiLabel = new System.Windows.Forms.Label();
            this.famiTel = new System.Windows.Forms.TextBox();
            this.companyLabel = new System.Windows.Forms.Label();
            this.syozoku = new System.Windows.Forms.Label();
            this.kindList = new System.Windows.Forms.ComboBox();
            this.canButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveFami
            // 
            this.saveFami.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.saveFami.Location = new System.Drawing.Point(334, 184);
            this.saveFami.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveFami.Name = "saveFami";
            this.saveFami.Size = new System.Drawing.Size(100, 36);
            this.saveFami.TabIndex = 17;
            this.saveFami.Text = "保存";
            this.saveFami.UseVisualStyleBackColor = true;
            this.saveFami.Click += new System.EventHandler(this.button2_Click);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.name.ImeMode = System.Windows.Forms.ImeMode.On;
            this.name.Location = new System.Drawing.Point(16, 44);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(197, 28);
            this.name.TabIndex = 19;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nameLabel.Location = new System.Drawing.Point(12, 21);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 20);
            this.nameLabel.TabIndex = 18;
            this.nameLabel.Text = "氏名";
            // 
            // nameRubi
            // 
            this.nameRubi.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nameRubi.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.nameRubi.Location = new System.Drawing.Point(234, 45);
            this.nameRubi.Name = "nameRubi";
            this.nameRubi.Size = new System.Drawing.Size(197, 28);
            this.nameRubi.TabIndex = 21;
            // 
            // nameRubiLabel
            // 
            this.nameRubiLabel.AutoSize = true;
            this.nameRubiLabel.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.nameRubiLabel.Location = new System.Drawing.Point(230, 22);
            this.nameRubiLabel.Name = "nameRubiLabel";
            this.nameRubiLabel.Size = new System.Drawing.Size(87, 20);
            this.nameRubiLabel.TabIndex = 20;
            this.nameRubiLabel.Text = "氏名フリガナ";
            // 
            // famiTel
            // 
            this.famiTel.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.famiTel.Location = new System.Drawing.Point(16, 117);
            this.famiTel.Name = "famiTel";
            this.famiTel.Size = new System.Drawing.Size(197, 28);
            this.famiTel.TabIndex = 22;
            // 
            // companyLabel
            // 
            this.companyLabel.AutoSize = true;
            this.companyLabel.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.companyLabel.Location = new System.Drawing.Point(12, 92);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(73, 20);
            this.companyLabel.TabIndex = 23;
            this.companyLabel.Text = "電話番号";
            // 
            // syozoku
            // 
            this.syozoku.AutoSize = true;
            this.syozoku.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.syozoku.Location = new System.Drawing.Point(230, 93);
            this.syozoku.Name = "syozoku";
            this.syozoku.Size = new System.Drawing.Size(41, 20);
            this.syozoku.TabIndex = 25;
            this.syozoku.Text = "所属";
            // 
            // kindList
            // 
            this.kindList.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kindList.FormattingEnabled = true;
            this.kindList.Location = new System.Drawing.Point(234, 117);
            this.kindList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kindList.Name = "kindList";
            this.kindList.Size = new System.Drawing.Size(163, 28);
            this.kindList.TabIndex = 24;
            // 
            // canButton
            // 
            this.canButton.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.canButton.Location = new System.Drawing.Point(228, 184);
            this.canButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.canButton.Name = "canButton";
            this.canButton.Size = new System.Drawing.Size(100, 36);
            this.canButton.TabIndex = 26;
            this.canButton.Text = "キャンセル";
            this.canButton.UseVisualStyleBackColor = true;
            this.canButton.Click += new System.EventHandler(this.canButton_Click);
            // 
            // mFamiAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 233);
            this.Controls.Add(this.canButton);
            this.Controls.Add(this.syozoku);
            this.Controls.Add(this.kindList);
            this.Controls.Add(this.famiTel);
            this.Controls.Add(this.companyLabel);
            this.Controls.Add(this.nameRubi);
            this.Controls.Add(this.nameRubiLabel);
            this.Controls.Add(this.name);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.saveFami);
            this.Name = "mFamiAdd";
            this.Text = "家族情報追加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveFami;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameRubi;
        private System.Windows.Forms.Label nameRubiLabel;
        private System.Windows.Forms.TextBox famiTel;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label syozoku;
        private System.Windows.Forms.ComboBox kindList;
        private System.Windows.Forms.Button canButton;
    }
}