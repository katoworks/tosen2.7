namespace tosen2
{
    partial class jarnalPrintForm
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
            this.grpSearch = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grpSrchChk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            this.grpSearch.Location = new System.Drawing.Point(142, 106);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(137, 23);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.Text = "検索";
            this.grpSearch.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(29, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(267, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // grpSrchChk
            // 
            this.grpSrchChk.AutoSize = true;
            this.grpSrchChk.Location = new System.Drawing.Point(13, 8);
            this.grpSrchChk.Name = "grpSrchChk";
            this.grpSrchChk.Size = new System.Drawing.Size(88, 19);
            this.grpSrchChk.TabIndex = 3;
            this.grpSrchChk.Text = "グループ印刷";
            this.grpSrchChk.UseVisualStyleBackColor = true;
            // 
            // jarnalPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 358);
            this.Controls.Add(this.grpSrchChk);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.grpSearch);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "jarnalPrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一覧印刷";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button grpSearch;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox grpSrchChk;
    }
}