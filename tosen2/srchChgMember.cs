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
    public partial class srchChgMember : Form
    {
        public srchChgMember()
        {
            InitializeComponent();

            //各種設定タブの初期設定
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        
        //定数宣言
        const int KANJI = 0b0001;
        const int KANA =  0b0010;
        const int ADDR =  0b0100;
        public List<chgSrchDTO> mDat { set; get; }
        private dbAccDAO mDB { set; get; }


        private void chgSrchBtn_Click(object sender, EventArgs e)
        {
            if (this.kanjiSrch.Text.Length ==0 &&
                this.kanaSrch.Text.Length==0 &&
                this.addrSrch.Text.Length ==0)

            {
                DialogResult rst = MessageBox.Show("検索キーを入力してください。", "注意", MessageBoxButtons.OK);

            }
            else
            {
                // 初期設定
                this.searchBaseInfo.Rows.Clear();
                //this.searchBaseInfo.Columns.Clear();

                // 結果置き場
                mDat = new List<chgSrchDTO>();
                mDB = new dbAccDAO();
                mDat = mDB.Get(this.kanjiSrch.Text, this.kanaSrch.Text, this.addrSrch.Text);
                foreach (chgSrchDTO mTmp in mDat)
                {
                    this.searchBaseInfo.Rows.Add(
                        mTmp.setaiNo.ToString(),
                        mTmp.name.ToString(),
                        mTmp.nameRubi.ToString(),
                        mTmp.zip1 + "-" + mTmp.zip2,
                        mTmp.address,
                        mTmp.comName,
                        mTmp.kindName
                        );
                }
                this.baseCnt.Text = mDat.Count.ToString();
            }
        }
        /// <summary>
        /// 検索キーの取り合わせ
        /// return 
        /// </summary>
        /// <returns></returns>
        private int cmpSrch()
        {
            int retVal = 0;

            if (this.kanjiSrch.Text != "")
            {
                retVal = KANJI;
            }
            if (this.kanjiSrch.Text != "")
            {
                retVal &= KANA;
            }
            if (this.addrSrch.Text != "")
            {
                retVal &= ADDR;
            }

            return retVal;
        }

        private void srchChgMember_Load(object sender, EventArgs e)
        {
            
        }

        private void endEdit_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void selEditRun(object sender, DataGridViewCellEventArgs e)
        {
            basicInfo basInfo = new basicInfo();
            List<famiAddr> famInfo = new List<famiAddr>();
            comInfoInput comInfo = new comInfoInput();
            dbAccDAO tmpDB = new dbAccDAO();
            List<chgSrchDTO> rdData = new List<chgSrchDTO>();

            rdData = tmpDB.getFami(int.Parse(this.searchBaseInfo.Rows[e.RowIndex].Cells[0].Value.ToString()));

            string msg = string.Format("「{0}」さんの変更を行います、", rdData[0].name);
            DialogResult rst = MessageBox.Show(msg, "確認", MessageBoxButtons.OKCancel);
            if (rst == DialogResult.OK)
            {
                chgMember chg = new chgMember();
                chg.baseAddr = tmpDB.basInfo;
                chg.famiDat = tmpDB.famiInfo;
                if(tmpDB.cominfoData!= null)
                {
                    chg.companyInfo = new comInfoInput();
                    chg.companyInfo.companyInfo = tmpDB.cominfoData;
                }

                chg.Reload();
                chg.ShowDialog();
            }

        }

        private void delSrchBtn_Click(object sender, EventArgs e)
        {
            if (this.searchBaseInfo.Rows.Count > 1)
            {

                basicInfo basInfo = new basicInfo();
                List<famiAddr> famInfo = new List<famiAddr>();
                comInfoInput comInfo = new comInfoInput();
                dbAccDAO tmpDB = new dbAccDAO();
                List<chgSrchDTO> rdData = new List<chgSrchDTO>();
                int mCnt = this.searchBaseInfo.CurrentCell.RowIndex;

                rdData = tmpDB.getFami(int.Parse(this.searchBaseInfo.Rows[mCnt].Cells[0].Value.ToString()));

                string msg = string.Format("「{0}」さんの削除を行います、確認画面で問題なければ削除してください。", rdData[0].name);
                DialogResult rst = MessageBox.Show(msg, "確認", MessageBoxButtons.OKCancel);
                if (rst == DialogResult.OK)
                {
                    delMember del = new delMember();
                    del.baseAddr = tmpDB.basInfo;
                    del.famiDat = tmpDB.famiInfo;
                    if (tmpDB.cominfoData != null)
                    {
                        del.companyInfo = new comInfoInput();
                        del.companyInfo.companyInfo = tmpDB.cominfoData;
                    }

                    del.Reload();
                    del.ShowDialog();

                    // 初期設定
                    this.searchBaseInfo.Rows.Clear();

                    // 結果置き場
                    mDat = new List<chgSrchDTO>();
                    mDB = new dbAccDAO();
                    mDat = mDB.Get(this.kanjiSrch.Text, this.kanaSrch.Text, this.addrSrch.Text);
                    foreach (chgSrchDTO mTmp in mDat)
                    {
                        this.searchBaseInfo.Rows.Add(
                            mTmp.setaiNo.ToString(),
                            mTmp.name.ToString(),
                            mTmp.nameRubi.ToString(),
                            mTmp.zip1 + "-" + mTmp.zip2,
                            mTmp.address,
                            mTmp.comName,
                            mTmp.kindName
                            );
                    }
                    this.baseCnt.Text = mDat.Count.ToString();
                }
            }
            else
            {
                DialogResult rst = MessageBox.Show("検索されていません", "注意", MessageBoxButtons.OK);
            }
        }

        private void henkoBtn_Click(object sender, EventArgs e)
        {
            if (this.searchBaseInfo.Rows.Count > 1)
            {
                basicInfo basInfo = new basicInfo();
                List<famiAddr> famInfo = new List<famiAddr>();
                comInfoInput comInfo = new comInfoInput();
                dbAccDAO tmpDB = new dbAccDAO();
                List<chgSrchDTO> rdData = new List<chgSrchDTO>();
                int mCnt = this.searchBaseInfo.CurrentCell.RowIndex;

                rdData = tmpDB.getFami(int.Parse(this.searchBaseInfo.Rows[mCnt].Cells[0].Value.ToString()));

                string msg = string.Format("「{0}」さんの変更を行います、", rdData[0].name);
                DialogResult rst = MessageBox.Show(msg, "確認", MessageBoxButtons.OKCancel);
                if (rst == DialogResult.OK)
                {
                    chgMember chg = new chgMember();
                    chg.baseAddr = tmpDB.basInfo;
                    chg.famiDat = tmpDB.famiInfo;
                    if (tmpDB.cominfoData != null)
                    {
                        chg.companyInfo = new comInfoInput();
                        chg.companyInfo.companyInfo = tmpDB.cominfoData;
                    }

                    chg.Reload();
                    chg.ShowDialog();
                }
            }
            else
            {
                DialogResult rst = MessageBox.Show("検索されていません", "注意", MessageBoxButtons.OK);
            }
        }
    }
}
