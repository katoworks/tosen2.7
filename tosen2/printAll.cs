using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.VisualBasic;

namespace tosen2
{
    public partial class printAll : Form
    {
        public printAll()
        {
            InitializeComponent();

            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;
            this.prtCntTxt.Text = "1";
            int selPaper = 0;
            int mPaper = 0;

            //ComboBoxの初期化
            this.grpBox.Items.Clear();
            this.prtDeviceList.Items.Clear();
            this.printPaper.Items.Clear();

            // グループ一覧を取得
            dbClass db = new dbClass();
            List<string> gBox = db.getKindList();

            this.grpBox.Items.Add("全て");

            foreach(string mList in gBox)
            {
                this.grpBox.Items.Add(mList);
            }
            this.grpBox.SelectedIndex = 0;

            // 紙の種類選択コンボボックス
            using (doc = new PrintDocument())
            {
                // プリンタの印刷方向設定
                doc.DefaultPageSettings.Landscape = false;
                doc.PrinterSettings.Copies = short.Parse(this.prtCntTxt.Text);

                foreach (PaperSize ps in doc.PrinterSettings.PaperSizes)
                {
                    if (ps.PaperName == "A4")
                    {
                        mPaper = selPaper;
                    }
                    this.printPaper.Items.Add(ps.PaperName);
                    selPaper++;
                }
                this.printPaper.SelectedIndex = mPaper;
            }

            // プリンター選択
            setPrtList();
        }

        PrintDocument doc { set; get; }
        printSetBeen mPrtBeen = new printSetBeen();
        private int mPrnCnt = 0;
        private List<pInfoAllBeen> mListPrtDat = new List<pInfoAllBeen>();
        private string mPaperSize { set; get; }
        
        private void prrStart_Click(object sender, EventArgs e)
        {
            int pr = this.printPaper.SelectedIndex;
            SetDefaultPrinter(this.prtDeviceList.Text);
            this.beforePage = -1;
            using (PrintDocument doc = new PrintDocument())
            {
                // プリンタの印刷方向設定
                doc.DefaultPageSettings.Landscape = false;
                doc.PrinterSettings.Copies = short.Parse(this.prtCntTxt.Text);

                // プリンタの用紙サイズ選択
                foreach (PaperSize ps in doc.PrinterSettings.PaperSizes)
                {
                    // はがき選択
                    string pp = this.printPaper.Text;
                    if ( ps.PaperName == pp)
                    {
                        doc.DefaultPageSettings.PaperSize = ps;
                        this.mPaperSize = ps.PaperName;
                        break;
                    }
                }

                doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

                // 印刷ページカウント
                this.mPrnCnt = 0;

                // 印刷実行
                doc.Print();

                doc.Dispose();
            }
            this.Close();

        }
        public int beforePage { set; get; }

        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            char[] sep = { ',' };
            float ix = 10, iy = 0;
            int mDcnt = this.prtDataList.Rows.Count;
            string mTmpStr = "";

            PrinterResolution pr = new PrinterResolution();
            PrintDocument printDoc = new PrintDocument();

            string mTitle = "印刷グループ:" + this.grpBox.Text + " 住所:" + this.searchAddr.Text + " 氏名:" + this.searchName.Text;

            //ヘッダタイトル
            string header = string.Format("印刷条件[{0}]\n", mTitle);
            //現在行のデータを取得する。
            //コンストラクタにてデータをロードしている

            mTmpStr = header + bufferData(this.mPaperSize, this.prtDataList, mDcnt);
            e.Graphics.DrawString(mTmpStr, new Font("ＭＳ ゴシック", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, ix, iy);
//            e.Graphics.DrawString(mTmpStr, new Font("ＭＳ ゴシック", 9, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, ix, iy + this.mPrnCnt);
//            e.Graphics.DrawString(mTmpStr, new Font("游ゴシック", 10, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, ix, iy + this.mPrnCnt);

            if (this.mPrnCnt < mDcnt)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            printDoc.Dispose();
            
        }

        private string bufferData(string paper, DataGridView dg,int mDcnt)
        {
            pInfoAllBeen dBeen = new pInfoAllBeen();
            string retVal = "";
            int mDatCnt = 0;
            int pageMax = 60;
            int mLnCnt = 0;

            if (paper == "A4")
            {
                pageMax = 80;
            }
            else
            {
                pageMax = 110;
            }

            if (this.mPrnCnt > mDcnt)
            {
                pageMax = pageMax - this.mPrnCnt;
            }

            for (mDatCnt = 0; mDatCnt < pageMax; mDatCnt++) 
            {

                if (mDatCnt + mLnCnt > pageMax)
                {
                    retVal += "――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――\r\n";
                    mLnCnt++;
                    break;
                }

                if (this.mPrnCnt > mDcnt-1)
                {
                    retVal += "――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――\r\n";
                    mLnCnt++;
                    break;
                }

                if (this.beforePage != int.Parse(this.prtDataList.Rows[this.mPrnCnt].Cells[1].Value.ToString()))
                {
                    retVal += "――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――\r\n";
                    this.beforePage = int.Parse(this.prtDataList.Rows[this.mPrnCnt].Cells[1].Value.ToString());
                    mLnCnt++;
                }

                dBeen.pName = this.prtDataList.Rows[this.mPrnCnt].Cells[3].Value.ToString();
                dBeen.pTel = this.prtDataList.Rows[this.mPrnCnt].Cells[5].Value.ToString();
                dBeen.pNameKana = this.prtDataList.Rows[this.mPrnCnt].Cells[4].Value.ToString();
                dBeen.pAddress = this.prtDataList.Rows[this.mPrnCnt].Cells[7].Value.ToString();
                dBeen.pComName = this.prtDataList.Rows[this.mPrnCnt].Cells[8].Value.ToString();
                dBeen.pKata = this.prtDataList.Rows[this.mPrnCnt].Cells[9].Value.ToString();
                int d = this.mPrnCnt + 1;
                string tmp1 = d.ToString() + "          ";
                string tmp2 = Strings.StrConv(dBeen.pName + "          ", VbStrConv.Wide, 0x0411);
//                string tmp3 = dBeen.pTel.Replace("-","") +  "           ";
                string tmp3 = dBeen.pTel +  "              ";
                string tmp4 = Strings.StrConv(dBeen.pNameKana + "          ", VbStrConv.Wide, 0x0411);
                string tmp5 = dBeen.pAddress ;
                string tmp6 = dBeen.pComName ;
                string tmp7 = dBeen.pKata;
                string mTmp = tmp1.Substring(0, 4) + "|";
                mTmp += tmp2.Substring(0, 8) + "|";
                mTmp += tmp3.Substring(0, 13) + "|";
                mTmp += tmp4.Substring(0, 10) + "|";
                mTmp += tmp5 + "\r\n";
//                mTmp += tmp5 + " " + tmp6 + " " + tmp7 + "\r\n";
//                mTmp += tmp5.Substring(0, 30) + "\r\n";
//                mTmp += tmp6.Substring(0, 15) + "\r\n";

                //                retVal += d.ToString() + ":" + dBeen.pName + " " + dBeen.pTel + " " + dBeen.pNameKana + " " + dBeen.pAddress + " " + dBeen.pComName + " " + " " + dBeen.pKata + "\r\n";
                retVal += mTmp;

                this.mPrnCnt++;

            }

            return retVal;
        }

        /// <summary>
        /// 「通常使うプリンタ」に設定する
        /// </summary>
        /// <param name="printerName">プリンタ名</param>
        public void SetDefaultPrinter(string printerName)
        {
            //WshNetworkオブジェクトを作成する
            Type t = Type.GetTypeFromProgID("WScript.Network");
            object wshNetwork = Activator.CreateInstance(t);
            //SetDefaultPrinterメソッドを呼び出す
            try
            {
                t.InvokeMember("SetDefaultPrinter",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null, wshNetwork, new object[] { printerName });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void canPrt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void setPrtList()
        {
            this.prtDeviceList.Items.Clear();

            foreach (string prtName in PrinterSettings.InstalledPrinters)
            {
                this.prtDeviceList.Items.Add(prtName);
            }
            this.prtDeviceList.SelectedIndex = 0;
        }

        private void selGrp_Click(object sender, EventArgs e)
        {
            dbClass db = new dbClass();
            this.prtDataList.Columns.Clear();
            this.prtDataList.Rows.Clear();
            
            this.kensu.Text = db.getGrpOut2(ref this.prtDataList, 0, this.grpBox.SelectedItem.ToString(),searchAddr.Text,searchName.Text).ToString();
            this.kensu.Text = this.prtDataList.RowCount.ToString();
            if (this.kensu.Text != "0")
            {
                this.prrStart.Enabled = true;
            }
        }

        private void allChk_Click(object sender, EventArgs e)
        {
            int mCnt, mMaxCnt;
            mMaxCnt = this.prtDataList.RowCount;
            for (mCnt = 0; mCnt < mMaxCnt; mCnt++)
            {
                if (this.prtDataList[0, mCnt].Value == null)
                {
                    continue;
                }
                else if ((bool)this.prtDataList[0, mCnt].Value)
                {
                    this.prtDataList.Rows[mCnt].Cells[0].Value = false;
                }
                else
                {
                    this.prtDataList.Rows[mCnt].Cells[0].Value = true;

                }
            }

        }
    }
}
