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
    public partial class hagakiPrn : Form
    {
        public hagakiPrn()
        {
            InitializeComponent();
            //コンボボックスの初期化
            dbClass db = new dbClass();
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;

            this.grpBox.Items.Clear();

            List<string> gBox = db.getKindList();
            foreach (string mList in gBox)
            {
                this.grpBox.Items.Add(mList);
            }
            this.grpBox.SelectedIndex = 0;
        }

        private void goBack_Click(object sender, EventArgs e)
        {

        }

        private void endSelectDat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grpSrchBtn_Click(object sender, EventArgs e)
        {
            dbClass db = new dbClass();
            string srch = this.grpBox.SelectedItem.ToString();
            this.groupData.Columns.Clear();
            this.groupData.Rows.Clear();

            this.kensu.Text = db.getGrpOut(ref this.groupData, 0, this.grpBox.SelectedItem.ToString()).ToString();
        }

        private int cntCheckData()
        {
            int retVal = 0;
            int cnt = 0;

            for (retVal = 0; retVal < this.groupData.RowCount; retVal++)
            {
                if (this.groupData[0, retVal].Value == null)
                {
                    continue;
                }
                cnt++;
            }

            return cnt;
        }
        private void prtStart_Click(object sender, EventArgs e)
        {
            int prtCnt = 0;
            if (cntCheckData() != 0)
            {
                List<printInfoBeen> prtDat = new List<printInfoBeen>();

                for (int i = 0; i < this.groupData.RowCount; i++)
                {
                    if (this.groupData[0, i].Value == null || this.groupData[0, i].Value.ToString() == "False")
                    {
                        continue;
                    }
                    printInfoBeen tmpPrt = new printInfoBeen();
                    tmpPrt.prtName = this.groupData[4, i].Value.ToString();
                    tmpPrt.prtZip = this.groupData[7, i].Value.ToString();
                    tmpPrt.prtAddr = this.groupData[8, i].Value.ToString();
                    tmpPrt.prtComp = this.groupData[6, i].Value.ToString();
                    tmpPrt.prtAteName = this.groupData[9, i].Value.ToString();
                    prtDat.Add(tmpPrt);
                    prtCnt++;
                }

                prtDialog pd = new prtDialog(prtDat);
                if (prtCnt != 0)
                {
                    pd.Show();
                }
                else
                {
                    MessageBox.Show("1件も選択されていません。");
                }
            }
            else
            {
                MessageBox.Show("1件も選択されていません。");
            }
        }

        private void allChk_Click(object sender, EventArgs e)
        {
            int mCnt, mMaxCnt;
            mMaxCnt = this.groupData.RowCount;
            for (mCnt = 0; mCnt < mMaxCnt; mCnt++)
            {
                if (this.groupData[0, mCnt].Value == null)
                {
                    continue;
                }
                else if ((bool)this.groupData[0, mCnt].Value)
                {
                    this.groupData.Rows[mCnt].Cells[0].Value = false;
                }
                else
                {
                    this.groupData.Rows[mCnt].Cells[0].Value = true;

                }
            }
        }

        private void grpSrchBtn_Click_1(object sender, EventArgs e)
        {
            dbClass db = new dbClass();
            string srch = this.grpBox.SelectedItem.ToString();
            this.groupData.Columns.Clear();
            this.groupData.Rows.Clear();

            this.kensu.Text = db.getGrpOut(ref this.groupData, this.grpBox.SelectedItem.ToString()).ToString();
        }

        private void prtStart_Click_1(object sender, EventArgs e)
        {
            int prtCnt = 0;
            if (cntCheckData() != 0)
            {
                List<printInfoBeen> prtDat = new List<printInfoBeen>();

                for (int i = 0; i < this.groupData.RowCount; i++)
                {
                    if (this.groupData[0, i].Value == null || this.groupData[0, i].Value.ToString() == "False")
                    {
                        continue;
                    }
                    printInfoBeen tmpPrt = new printInfoBeen();
                    tmpPrt.prtName = this.groupData[2, i].Value.ToString();
                    tmpPrt.prtZip = this.groupData[3, i].Value.ToString();
                    tmpPrt.prtAddr = this.groupData[4, i].Value.ToString();
                    tmpPrt.prtComp = this.groupData[5, i].Value.ToString();
                    tmpPrt.prtAteName = this.groupData[6, i].Value.ToString();
                    tmpPrt.prtSetaiCnt = long.Parse(this.groupData[7, i].Value.ToString());
                    prtDat.Add(tmpPrt);
                    prtCnt++;
                }

                prtDialog2 pd = new prtDialog2(prtDat);
                if (prtCnt != 0)
                {
                    pd.Show();
                }
                else
                {
                    MessageBox.Show("1件も選択されていません。");
                }
            }
            else
            {
                MessageBox.Show("1件も選択されていません。");
            }
        }

        private void endSelectDat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
