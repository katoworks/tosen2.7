namespace tosen2
{
    partial class tosen
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tosen));
            this.title_label = new System.Windows.Forms.Label();
            this.configDat = new System.Windows.Forms.Button();
            this.dataPrt = new System.Windows.Forms.Button();
            this.pgEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Meiryo UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.title_label.ForeColor = System.Drawing.Color.Red;
            this.title_label.Location = new System.Drawing.Point(150, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(340, 122);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "当選箱";
            // 
            // configDat
            // 
            this.configDat.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.configDat.Location = new System.Drawing.Point(132, 135);
            this.configDat.Name = "configDat";
            this.configDat.Size = new System.Drawing.Size(369, 62);
            this.configDat.TabIndex = 1;
            this.configDat.Text = "データ編集";
            this.configDat.UseVisualStyleBackColor = true;
            this.configDat.Click += new System.EventHandler(this.configDat_Click);
            // 
            // dataPrt
            // 
            this.dataPrt.Enabled = false;
            this.dataPrt.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dataPrt.Location = new System.Drawing.Point(132, 230);
            this.dataPrt.Name = "dataPrt";
            this.dataPrt.Size = new System.Drawing.Size(369, 62);
            this.dataPrt.TabIndex = 2;
            this.dataPrt.Text = "印刷設定";
            this.dataPrt.UseVisualStyleBackColor = true;
            // 
            // pgEnd
            // 
            this.pgEnd.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pgEnd.Location = new System.Drawing.Point(132, 325);
            this.pgEnd.Name = "pgEnd";
            this.pgEnd.Size = new System.Drawing.Size(369, 62);
            this.pgEnd.TabIndex = 3;
            this.pgEnd.Text = "終了";
            this.pgEnd.UseVisualStyleBackColor = true;
            this.pgEnd.Click += new System.EventHandler(this.pgEnd_Click);
            // 
            // tosen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.pgEnd);
            this.Controls.Add(this.dataPrt);
            this.Controls.Add(this.configDat);
            this.Controls.Add(this.title_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "tosen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "当選箱２";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button configDat;
        private System.Windows.Forms.Button dataPrt;
        private System.Windows.Forms.Button pgEnd;
    }
}

