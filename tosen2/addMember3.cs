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
    public partial class addMember3 : Form
    {
        public addMember3()
        {
            InitializeComponent();

            //各種設定タブの初期設定
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;
            this.kind = new kindInfoDTO();
        }
        public basicInfo baseAddr { set; get; }
        public List<famiAddr> famiDat { set; get; }
        public comInfoInput companyInfo { set; get; }
        private kindInfoDTO kind { set; get; }

        public void reload()
        {
            this.kind.kindDat = this.kind.getList();
            setComboBox(this.baseKind, this.kind.kindDat);
            this.baseKind.SelectedIndex = 0;
        }
        private void infoSaveBtn_Click(object sender, EventArgs e)
        {

        }
        private Boolean chkDat()
        {
            Boolean retVal = false;

            if (this.zipCode1.Text != "" &&
               this.zipCode2.Text != "" &&
               this.basAddr.Text != "" &&
               this.basName.Text != "" &&
               this.basNameRubi.Text != ""
                )
            {
                retVal = true;
            }

            return retVal;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult rst = MessageBox.Show("破棄しますか？データは保存されません。", "確認", MessageBoxButtons.OKCancel);
            if (rst == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void setComboBox(System.Windows.Forms.ComboBox cb, List<kindInfoDTO> kind)
        {
            int mCnt = 0;
            int mMax = kind.Count();
            for (mCnt = 0; mCnt < mMax; mCnt++)
            {
                cb.Items.Add(kind[mCnt].kindName);
            }

        }

        private void famiInputBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
