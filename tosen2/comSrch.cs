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
    public partial class comSrch : Form
    {
        public comSrch()
        {
            InitializeComponent();

            this.srchWord.Select();
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;

        }

        private string mSarchWord { get; set; }
        private int mSrchMode { set; get; }
        private string mExecSql { set; get; }

        private void dspEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kanaSrch_Click(object sender, EventArgs e)
        {
            this.mSarchWord = this.srchWord.Text;
            this.mSrchMode = 0;

            comDatSrch();
        }

        private void kanSrch_Click(object sender, EventArgs e)
        {
            this.mSarchWord = this.srchWord.Text;
            this.mSrchMode = 1;

            comDatSrch();
        }

        private void cmpName_Click(object sender, EventArgs e)
        {
            this.mSarchWord = this.srchWord.Text;
            this.mSrchMode = 2;

            comDatSrch();
        }
        private void comDatSrch()
        {
            // DataGirdViewの初期化
            this.compData.Rows.Clear();
            this.compData.Columns.Clear();

            dbClass db = new dbClass();

            this.kensu.Text = db.getComOut(ref this.compData, this.mSrchMode, this.srchWord.Text).ToString();
        }
        private int cntCheckPrt()
        {
            int retVal = 0;
            for(int i = 0; i < this.compData.RowCount; i++)
            {
                if (this.compData[0, i].Value == null)
                {
                    continue;
                }

                retVal++;
            }

            return retVal;
        }
        private void prtStart_Click(object sender, EventArgs e)
        {
            int prtCnt = 0;
            int checkCount = cntCheckPrt();
            if (checkCount > 0)
            {
                List<printInfoBeen> prtDat = new List<printInfoBeen>();

                for(int i = 0; i < this.compData.RowCount; i++)
                {
                    if (this.compData[0, i].Value == null || this.compData[0, i].Value.ToString() == "False")
                    {
                        continue;
                    }

                    printInfoBeen tmpPrt = new printInfoBeen();
                    tmpPrt.prtName = this.compData[4, i].Value.ToString();
                    tmpPrt.prtZip = this.compData[6, i].Value.ToString();
                    tmpPrt.prtAddr = this.compData[7, i].Value.ToString();
                    tmpPrt.prtComp = this.compData[3, i].Value.ToString();
                    tmpPrt.prtAteName = this.compData[8, i].Value.ToString();

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
        }

        private void allChk_Click(object sender, EventArgs e)
        {
            int mCnt, mMaxCnt;
            mMaxCnt = this.compData.RowCount;
            for (mCnt = 0; mCnt < mMaxCnt; mCnt++)
            {
                if (this.compData[0, mCnt].Value == null)
                {
                    continue;
                }
                else if ((bool)this.compData[0, mCnt].Value)
                {
                    this.compData.Rows[mCnt].Cells[0].Value = false;
                }
                else
                {
                    this.compData.Rows[mCnt].Cells[0].Value = true;

                }
            }
        }
    }
}
