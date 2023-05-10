
namespace tosen2
{
    partial class srchChgMember
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
            this.label1 = new System.Windows.Forms.Label();
            this.kanjiSrch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kanaSrch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addrSrch = new System.Windows.Forms.TextBox();
            this.searchBaseInfo = new System.Windows.Forms.DataGridView();
            this.setaiNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameRubi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chgSrchBtn = new System.Windows.Forms.Button();
            this.baseCnt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.endEdit = new System.Windows.Forms.Button();
            this.delSrchBtn = new System.Windows.Forms.Button();
            this.henkoBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.searchBaseInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "メンバー検索";
            // 
            // kanjiSrch
            // 
            this.kanjiSrch.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kanjiSrch.Location = new System.Drawing.Point(133, 69);
            this.kanjiSrch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kanjiSrch.Name = "kanjiSrch";
            this.kanjiSrch.Size = new System.Drawing.Size(116, 23);
            this.kanjiSrch.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "検索（漢字）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "検索（カナ）";
            // 
            // kanaSrch
            // 
            this.kanaSrch.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.kanaSrch.Location = new System.Drawing.Point(367, 69);
            this.kanaSrch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kanaSrch.Name = "kanaSrch";
            this.kanaSrch.Size = new System.Drawing.Size(116, 23);
            this.kanaSrch.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "検索（住所）";
            // 
            // addrSrch
            // 
            this.addrSrch.ImeMode = System.Windows.Forms.ImeMode.On;
            this.addrSrch.Location = new System.Drawing.Point(607, 69);
            this.addrSrch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addrSrch.Name = "addrSrch";
            this.addrSrch.Size = new System.Drawing.Size(291, 23);
            this.addrSrch.TabIndex = 12;
            // 
            // searchBaseInfo
            // 
            this.searchBaseInfo.AllowUserToAddRows = false;
            this.searchBaseInfo.AllowUserToResizeColumns = false;
            this.searchBaseInfo.AllowUserToResizeRows = false;
            this.searchBaseInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchBaseInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.setaiNo,
            this.name,
            this.nameRubi,
            this.zip,
            this.address,
            this.comName,
            this.kind});
            this.searchBaseInfo.Location = new System.Drawing.Point(41, 111);
            this.searchBaseInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchBaseInfo.Name = "searchBaseInfo";
            this.searchBaseInfo.ReadOnly = true;
            this.searchBaseInfo.RowHeadersVisible = false;
            this.searchBaseInfo.RowTemplate.Height = 21;
            this.searchBaseInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchBaseInfo.Size = new System.Drawing.Size(865, 319);
            this.searchBaseInfo.TabIndex = 14;
            this.searchBaseInfo.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.selEditRun);
            // 
            // setaiNo
            // 
            this.setaiNo.HeaderText = "No";
            this.setaiNo.Name = "setaiNo";
            this.setaiNo.ReadOnly = true;
            this.setaiNo.Width = 50;
            // 
            // name
            // 
            this.name.HeaderText = "氏名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // nameRubi
            // 
            this.nameRubi.HeaderText = "氏名(ｶﾅ)";
            this.nameRubi.Name = "nameRubi";
            this.nameRubi.ReadOnly = true;
            // 
            // zip
            // 
            this.zip.HeaderText = "郵便番号";
            this.zip.Name = "zip";
            this.zip.ReadOnly = true;
            // 
            // address
            // 
            this.address.HeaderText = "住所";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 260;
            // 
            // comName
            // 
            this.comName.HeaderText = "会社名";
            this.comName.Name = "comName";
            this.comName.ReadOnly = true;
            this.comName.Width = 150;
            // 
            // kind
            // 
            this.kind.HeaderText = "所属";
            this.kind.Name = "kind";
            this.kind.ReadOnly = true;
            this.kind.Width = 80;
            // 
            // chgSrchBtn
            // 
            this.chgSrchBtn.Location = new System.Drawing.Point(715, 447);
            this.chgSrchBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chgSrchBtn.Name = "chgSrchBtn";
            this.chgSrchBtn.Size = new System.Drawing.Size(87, 29);
            this.chgSrchBtn.TabIndex = 15;
            this.chgSrchBtn.Text = "検索";
            this.chgSrchBtn.UseVisualStyleBackColor = true;
            this.chgSrchBtn.Click += new System.EventHandler(this.chgSrchBtn_Click);
            // 
            // baseCnt
            // 
            this.baseCnt.AutoSize = true;
            this.baseCnt.Location = new System.Drawing.Point(858, 24);
            this.baseCnt.Name = "baseCnt";
            this.baseCnt.Size = new System.Drawing.Size(12, 15);
            this.baseCnt.TabIndex = 16;
            this.baseCnt.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(805, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = " 件数：";
            // 
            // endEdit
            // 
            this.endEdit.Location = new System.Drawing.Point(808, 447);
            this.endEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.endEdit.Name = "endEdit";
            this.endEdit.Size = new System.Drawing.Size(87, 29);
            this.endEdit.TabIndex = 18;
            this.endEdit.Text = "終了";
            this.endEdit.UseVisualStyleBackColor = true;
            this.endEdit.Click += new System.EventHandler(this.endEdit_Click);
            // 
            // delSrchBtn
            // 
            this.delSrchBtn.Location = new System.Drawing.Point(529, 447);
            this.delSrchBtn.Name = "delSrchBtn";
            this.delSrchBtn.Size = new System.Drawing.Size(87, 29);
            this.delSrchBtn.TabIndex = 19;
            this.delSrchBtn.Text = "削除";
            this.delSrchBtn.UseVisualStyleBackColor = true;
            this.delSrchBtn.Click += new System.EventHandler(this.delSrchBtn_Click);
            // 
            // henkoBtn
            // 
            this.henkoBtn.Location = new System.Drawing.Point(622, 447);
            this.henkoBtn.Name = "henkoBtn";
            this.henkoBtn.Size = new System.Drawing.Size(87, 29);
            this.henkoBtn.TabIndex = 20;
            this.henkoBtn.Text = "変更";
            this.henkoBtn.UseVisualStyleBackColor = true;
            this.henkoBtn.Click += new System.EventHandler(this.henkoBtn_Click);
            // 
            // srchChgMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 500);
            this.Controls.Add(this.henkoBtn);
            this.Controls.Add(this.delSrchBtn);
            this.Controls.Add(this.endEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.baseCnt);
            this.Controls.Add(this.chgSrchBtn);
            this.Controls.Add(this.searchBaseInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addrSrch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kanaSrch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kanjiSrch);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "srchChgMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "srchChgMember";
            this.Load += new System.EventHandler(this.srchChgMember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchBaseInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox kanjiSrch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox kanaSrch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox addrSrch;
        private System.Windows.Forms.DataGridView searchBaseInfo;
        private System.Windows.Forms.Button chgSrchBtn;
        private System.Windows.Forms.Label baseCnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button endEdit;
        private System.Windows.Forms.Button delSrchBtn;
        private System.Windows.Forms.Button henkoBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setaiNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameRubi;
        private System.Windows.Forms.DataGridViewTextBoxColumn zip;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn comName;
        private System.Windows.Forms.DataGridViewTextBoxColumn kind;
    }
}