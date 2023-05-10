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
    public partial class FamiryInputForm : Form
    {
        public FamiryInputForm()
        {
            InitializeComponent();

            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;

            dbClass db = new dbClass();
            grpBox.Items.Clear();

            List<string> gBox = db.getKindList();
            foreach(string mList in gBox)
            {
                this.grpBox.Items.Add(mList);
            }
            this.grpBox.SelectedIndex = 0;

        }
        private int famiNo { set; get; }

        private void canAddDat_Click(object sender, EventArgs e)
        {
            famiInfoDTO tmpFami = new famiInfoDTO();
            
            //データの一時保存
            //addMember.mFamiry[addMember.famiCnt] = new famiInfoDTO();
            addMember.famiCnt++;
            tmpFami.name = this.famiName.Text;
            tmpFami.nameRubi = this.famiNameRubi.Text;
            tmpFami.tel = this.famiTel.Text;
            tmpFami.syozoku = this.grpBox.SelectedIndex;
            addMember.mFamiry.Add(tmpFami);
            comInfoDTO tmpCom = new comInfoDTO();
            tmpCom.famiNo = addMember.famiCnt;
            tmpCom.comName = this.comName.Text;
            tmpCom.comKata = this.comKata.Text;
            tmpCom.tel = this.famiTel.Text;
            tmpCom.comZip1 = addMember.mMember.zip1;
            tmpCom.comZip2 = addMember.mMember.zip2;
            tmpCom.comAddress = addMember.mMember.address;
            tmpCom.comShimei = this.famiName.Text;
            tmpCom.comShimeiRubi = this.famiNameRubi.Text;
            addMember.mCompany.Add(tmpCom);


            DialogResult rst =  MessageBox.Show("続けて入力しますか？", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (rst == DialogResult.Yes)
            {
                this.famiName.Text = "";
                this.famiNameRubi.Text = "";
                this.famiTel.Text = "";
                this.famiName.Focus();
            }
            else
            {
                this.Close();
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
