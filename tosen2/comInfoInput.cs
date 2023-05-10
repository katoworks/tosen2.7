using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tosen2
{
    public partial class comInfoInput : Form
    {
        public comInfoInput()
        {
            InitializeComponent();
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;
            this.comInfo = false;
        }
        public basicInfo baseInfo { set; get; }
        private famiAddr[] famiInfo { set; get; }
        public cominfo companyInfo { set; get; }
        public Boolean comInfo { set; get; }
        public Boolean modeEnable { set; get; }
        public void reload()
        {
            this.basName.Text = this.baseInfo.name;
            this.basNameRubi.Text = this.baseInfo.nameRubi;
            string mTmpZip = this.baseInfo.zipCode;
            this.zipCode1.Text = mTmpZip.Substring(0, 3);
            this.zipCode2.Text = mTmpZip.Substring(3, 4);
            this.basAddr.Text = this.baseInfo.address;
            if (this.companyInfo is null)
            {
                this.companyInfo = new cominfo();
            }
            else
            {
                this.comName.Text = this.companyInfo.comName;
                this.comTel.Text = this.companyInfo.comTel;
                mTmpZip = this.companyInfo.comZip.Replace("-", "");
                this.comZip1.Text = mTmpZip.Substring(0, 3);
                this.comZip2.Text = mTmpZip.Substring(3, 4);
                this.comAddr.Text = this.companyInfo.comAddr;
            }

            setEnable();
        }
        private void setEnable()
        {
            if (this.modeEnable == true)
            {
                this.comName.Enabled = false;
                this.comTel.Enabled = false;
                this.comZip1.Enabled = false;
                this.comZip2.Enabled = false;
                this.comAddr.Enabled = false;
                this.infoSaveBtn.Visible = false;
            }
            else
            {
                this.comName.Enabled = true;
                this.comTel.Enabled = true;
                this.comZip1.Enabled = true;
                this.comZip2.Enabled = true;
                this.comAddr.Enabled = true;
                this.infoSaveBtn.Visible = true;

            }
        }


            
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult rst = MessageBox.Show("入力データをキャンセルします。", "注意", MessageBoxButtons.OKCancel);
            if (rst == DialogResult.OK)
            {
                this.Close();
            }
        }

        private Boolean check()
        {
            Boolean retVal = false;

            if (this.comName.Text!="" &&
                this.comTel.Text != "" && 
                this.comZip1.Text != "" &&
                this.comZip2.Text != "" && 
                this.comAddr.Text != ""
                )
            {
                retVal = true;
            }

            return retVal;
        }

        private void infoSaveBtn_Click(object sender, EventArgs e)
        {
            if (check())
            {
                //DialogResult rst = MessageBox.Show("登録を行います。問題なければ「OK]を押下してください。", "確認", MessageBoxButtons.OKCancel);
                //if (rst == DialogResult.OK)
                //{
                    this.companyInfo.comName = this.comName.Text;
                    this.companyInfo.comTel = this.comTel.Text;
                    this.companyInfo.comZip = this.comZip1.Text + "-" + this.comZip2.Text;
                    this.companyInfo.comAddr = this.comAddr.Text;
                    this.comInfo = true;
                    this.Close();
                //}
            }
            else
            {
                DialogResult rst = MessageBox.Show("全ての項目にデータを入れてください。", "注意", MessageBoxButtons.OK);
            }

        }
    }
}
