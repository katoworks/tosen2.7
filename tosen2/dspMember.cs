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
    public partial class dspMember : Form
    {
        public dspMember()
        {
            InitializeComponent();

            this.srchWord.Select();

            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;

        }

        private void dspEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private string mSarchWord { get; set; }
        private int mSrchMode { set; get; }
        private string mExecSql { set; get; }

        private void kanaSrch_Click(object sender, EventArgs e)
        {
            this.mSarchWord = this.srchWord.Text;
            this.mSrchMode = 0;

            this.srchMember();
        }

        private void kanSrch_Click(object sender, EventArgs e)
        {
            this.mSarchWord = this.srchWord.Text;
            this.mSrchMode = 1;

            this.srchMember();
        }

        private void srchMember()
        {
            this.dataList.Columns.Clear();
            this.dataList.Rows.Clear();
            
            dbClass db = new dbClass();
            List<setaiInfoBeen> mList = new List<setaiInfoBeen>();
            DataGridView mDt = new DataGridView();

            //DataGridViewに列を追加する。
            this.kensu.Text = db.getSetaiOut(ref this.dataList, this.mSrchMode, this.srchWord.Text).ToString();

            int c = this.dataList.ColumnCount;
        }
        private int cntCheckData()
        {
            int retVal = 0;
            int cnt = 0;

            for(retVal = 0; retVal < this.dataList.RowCount; retVal++)
            {
                if (this.dataList[0, retVal].Value == null)
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

                for (int i = 0; i < this.dataList.RowCount; i++)
                {
                    if (this.dataList[0, i].Value == null || this.dataList[0, i].Value.ToString() == "False")
                    {
                        continue;
                    }
                    printInfoBeen tmpPrt = new printInfoBeen();
                    tmpPrt.prtName = this.dataList[3, i].Value.ToString();
                    tmpPrt.prtZip = this.dataList[5, i].Value.ToString();
                    tmpPrt.prtAddr = this.dataList[6, i].Value.ToString();
                    tmpPrt.prtComp = this.dataList[7, i].Value.ToString();
                    tmpPrt.prtAteName = this.dataList[8, i].Value.ToString();
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
            mMaxCnt = this.dataList.RowCount;
            for (mCnt = 0; mCnt < mMaxCnt; mCnt++)
            {
                if (this.dataList[0, mCnt].Value == null)
                {
                    continue;
                }
                else if ((bool)this.dataList[0, mCnt].Value)
                {
                    this.dataList.Rows[mCnt].Cells[0].Value = false;
                }
                else
                {
                    this.dataList.Rows[mCnt].Cells[0].Value = true;

                }
            }
        }
    }
}
