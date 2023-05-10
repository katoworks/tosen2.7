using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tosen2
{
    public partial class prtDialog2 : Form
    {
        public prtDialog2(List<printInfoBeen> mData)
        {
            InitializeComponent();

            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;
            this.prtCntTxt.Text = "1";
            this.mListPrtDat = mData;

            // 印刷時につける呼称
            this.prtInfo.Items.Clear();
            this.prtInfo.Items.Add("個人のみ");
            this.prtInfo.Items.Add("ご一同様");
            this.prtInfo.Items.Add("ご家族様");
            this.prtInfo.SelectedIndex = 1;

            // 印刷する用紙の一覧
            setCombo();
 
            // インストールされているプリンターの一覧取得
            setPrtList();

            // DataGridViewにデータを入れる
            setPrtData();

        }
        private string listFileName = @".\conf\list.txt";
        private printInfoBeen tmpPrt = new printInfoBeen();
        private List<printInfoBeen> mListPrtDat = new List<printInfoBeen>();
        private List<string> prtName { get; set; }
        private List<string> fileName { get; set; }
        List<string> mConfFile = new List<string>();
        printSetBeen mPrtBeen = new printSetBeen();
        private int mPrnCnt = 0;
        private int mPrnMax = 0;
        private void setCombo()
        {
            // Splitのセパレータ
            char[] sep = { ',' };
            string mLineBuff;

            //ComboBoxの初期化
            this.printPaper.Items.Add(new object());
            this.printPaper.Items.Clear();

            // ファイルの読み込み
            System.IO.StreamReader sr = new System.IO.StreamReader(listFileName, Encoding.GetEncoding("shift_jis"));

            while ((mLineBuff = sr.ReadLine()) != null)
            {
                var mTmpSpl = mLineBuff.Split(sep);
                this.printPaper.Items.Add(mTmpSpl[0]);
                this.mConfFile.Add(mLineBuff);
            }
            sr.Close();

            this.printPaper.SelectedIndex = 1;
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
        public void setPrtData()
        {
            this.prtDataList.Rows.Clear();
            this.prtDataList.Columns.Clear();

            // インストールされているプリンターの一覧取得
            setPrtList();

            // 印刷リストの一覧をDataGridViewを入れる
            this.prtDataList.Columns.Add("", "氏名");
            this.prtDataList.Columns.Add("", "郵便番号");
            this.prtDataList.Columns.Add("", "住所");
            this.prtDataList.Columns.Add("", "会社名");
            this.prtDataList.Columns.Add("", "役職");
            this.prtDataList.Columns.Add("", "件数");
            this.prtDataList.ColumnCount = 6;
            this.prtDataList.Columns[0].Width = 200;
            this.prtDataList.Columns[1].Width = 100;
            this.prtDataList.Columns[2].Width = 300;
            this.prtDataList.Columns[3].Width = 200;
            this.prtDataList.Columns[4].Width = 100;
            this.prtDataList.Columns[5].Width = 50;
            this.prtDataList.Rows.Add(this.mListPrtDat.Count);

            this.mPrnMax = this.mListPrtDat.Count;

            for (int cnt = 0; cnt < this.mListPrtDat.Count; cnt++)
            {
                this.prtDataList.Rows[cnt].Cells[0].Value = this.mListPrtDat[cnt].prtName.ToString();
                this.prtDataList.Rows[cnt].Cells[1].Value = this.mListPrtDat[cnt].prtZip.ToString();
                this.prtDataList.Rows[cnt].Cells[2].Value = this.mListPrtDat[cnt].prtAddr.ToString();
                if (this.mListPrtDat[cnt].prtComp != null)
                {
                    this.prtDataList.Rows[cnt].Cells[3].Value = this.mListPrtDat[cnt].prtComp.ToString();
                }

                if (this.mListPrtDat[cnt].prtAteName != null)
                {
                    this.prtDataList.Rows[cnt].Cells[4].Value = this.mListPrtDat[cnt].prtAteName.ToString();
                }
                this.prtDataList.Rows[cnt].Cells[5].Value = this.mListPrtDat[cnt].prtSetaiCnt.ToString();
            }
        }

        private void printPaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            char[] sep = { ',' };

            int selCnt = this.printPaper.SelectedIndex;
            var mSelFile = this.mConfFile[selCnt];
            var mLoadFile = mSelFile.Split(sep);

            mPrtBeen.fileLoad(mLoadFile[1]);

            // パラメタ設定
            mPrtBeen.fileName = mLoadFile[1];

        }

        private void canPrt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void SetDefaultPrinter(string printerName)
        {
            //WshNetworkオブジェクトを作成する
            Type t = Type.GetTypeFromProgID("WScript.Network");
            object wshNetwork = Activator.CreateInstance(t);
            //SetDefaultPrinterメソッドを呼び出す
            t.InvokeMember("SetDefaultPrinter",
                System.Reflection.BindingFlags.InvokeMethod,
                null, wshNetwork, new object[] { printerName });
        }


        private void prrStart_Click(object sender, EventArgs e)
        {
            int pr = this.printPaper.SelectedIndex;
            SetDefaultPrinter( this.prtDeviceList.Text);
            using (PrintDocument doc = new PrintDocument())
            {
                // プリンタの印刷方向設定
                doc.DefaultPageSettings.Landscape = false;
                doc.PrinterSettings.Copies = short.Parse(this.prtCntTxt.Text);

                // プリンタの用紙サイズ選択
                foreach (PaperSize ps in doc.PrinterSettings.PaperSizes)
                {
                    // はがき選択
                    if (this.mPrtBeen.cardSize == "hagaki" && ps.Kind == PaperKind.JapanesePostcard)
                    {
                        doc.DefaultPageSettings.PaperSize = ps;
                        break;
                    }
                    // 封筒選択
                    if (this.mPrtBeen.cardSize == "futo" && ps.Kind == PaperKind.JapaneseEnvelopeChouNumber3)
                    {
                        doc.DefaultPageSettings.PaperSize = ps;
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
         private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string atena = "";
            char[] sep = { ',' };

            PrinterResolution pr = new PrinterResolution();
            PrintDocument printDoc = new PrintDocument();
            dataBeen dBeen = new dataBeen();

            //現在行のデータを取得する。
            //コンストラクタにてデータをロードしている

            dBeen.memName = this.mListPrtDat[this.mPrnCnt].prtName.ToString();
            dBeen.zipCode = this.mListPrtDat[this.mPrnCnt].prtZip.ToString();
            dBeen.memAddr = this.mListPrtDat[this.mPrnCnt].prtAddr.ToString();
            dBeen.setaiCnt = this.mListPrtDat[this.mPrnCnt].prtSetaiCnt;
            //if (this.mListPrtDat[this.mPrnCnt].prtComp != null)
            //{
            //    dBeen.memAddr = this.mListPrtDat[this.mPrnCnt].prtComp.ToString();
            //}
            //else
            //{
            //   dBeen.memAddr = "";
            //}
            dBeen.memCompny = this.mListPrtDat[this.mPrnCnt].prtComp.ToString();

            if (this.mListPrtDat[this.mPrnCnt].prtAteName != null)
            {
                dBeen.memComYaku = this.mListPrtDat[this.mPrnCnt].prtAteName.ToString();
            }
            else
            {
                dBeen.memComYaku = "";
            }

            for (int i = 0; i < printDoc.PrinterSettings.PrinterResolutions.Count; i++)
            {
                pr = printDoc.PrinterSettings.PrinterResolutions[i];
                if (pr.Kind.ToString() == "high")
                {
                    break;
                }
            }

            // 印刷領域設定
            Size sz = new Size(350, 515);
            Point pt = new Point(10, 35);
            Rectangle rect = new Rectangle(pt, sz);
            StringFormat sf = new StringFormat();

            // 初期設定
            string mTmpAddFont = mPrtBeen.addfont;
            int mTmpAddFontSize = mPrtBeen.addfontsize;
            int mTmpNameX = mPrtBeen.namex;
            int mTmpNameY = mPrtBeen.namey;
            string mTmpNameFont = mPrtBeen.namefont;
            int mTmpNameFontSize = mPrtBeen.namefontsize;

            // 郵便番号印刷
            zipPrint(dBeen.zipCode, e);
            // 住所印刷
            if ( mPrtBeen.adddrection == 1)
            {
                sf.FormatFlags = StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft;
            }
            else
            {
                sf.FormatFlags = 0;
            }

            int flg = 0;
            if (mPrtBeen.adddrection == 1)
            {
                flg = 1;
            }
//            e.Graphics.DrawString(IntCrLf(chgNum(dBeen.memAddr, flg)), new Font(mTmpAddFont, mTmpAddFontSize, FontStyle.Bold, GraphicsUnit.Point),
//               Brushes.Black, mPrtBeen.addx, mPrtBeen.addy, sf);
            e.Graphics.DrawString(chkLenCrLf(chgNum(dBeen.memAddr, flg),20), new Font(mTmpAddFont, mTmpAddFontSize, FontStyle.Bold, GraphicsUnit.Point),
               Brushes.Black, mPrtBeen.addx, mPrtBeen.addy, sf);

            switch (this.prtInfo.SelectedIndex)
            {
                case 0:
                    atena = " 様";
                    break;
                case 1:
                    if (dBeen.setaiCnt > 1)
                    {
                        atena = "様\nご一同様";
                    }
                    else
                    {
                        atena = " 様";
                    }
                    break;
                case 2:
                    if (dBeen.setaiCnt > 1)
                    {
                        atena = "様\nご家族様";
                    }
                    else
                    {
                        atena = " 様";
                    }
                    break;
                default:
                    atena = " 様";
                    break;
            }
            string mTmpName = chkLenCrLf( dBeen.memCompny) + "\n" + dBeen.memComYaku + "\n" + dBeen.memName;
            e.Graphics.DrawString(mTmpName + "　" + atena, new Font(mTmpNameFont, mTmpNameFontSize, FontStyle.Bold, GraphicsUnit.Point),
              Brushes.Black, mPrtBeen.namex, mPrtBeen.namey, sf);

            this.mPrnCnt++;
            //　次のページ印刷チェック
            if (this.mPrnCnt < this.mPrnMax)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            printDoc.Dispose();
        }

        private string chkLenCrLf(string str)
        {
            int mStrLen = 0;
            string retVal = "";

            mStrLen = str.Length;
            if (mStrLen > 9)
            {
                retVal = str.Substring(0, 9) + "\n" + str.Substring(9, str.Length - 9);
            }
            else
            {
                retVal = str;
            }

            return retVal;
        }
        private string chkLenCrLf(string str,int len)
        { 
            int mStrLen = 0;
            string retVal = "";

            mStrLen = str.Length;
            if (mStrLen > len)
            {
                retVal = str.Substring(0, len) + "\n" + str.Substring(len, str.Length - len);
            }
            else
            {
                retVal = str;
            }

            return retVal;
        }
        private string IntCrLf(string line)
        {
            int addrMax = 20;
            var tmpLine = "";
            int noCR = 0;

            if (line.Length > addrMax)
            {
                for (var i = 0; i < line.Length; i++)
                {
                    var tmp = line.Substring(i, 1);
                    if (checkNumAddr(tmp) == true && noCR == 0)
                    {
                        tmp = "\n" + tmp;
                        noCR = 1;
                    }
                    tmpLine += tmp;
                }
            }
            else
            {
                tmpLine = line;
            }

            return tmpLine;
        }

       private void zipPrint(string zipCode, PrintPageEventArgs e)
        {
            if (zipCode == "-")
            {

            }
            else
            {
                // パディング値 20 pixel
                int padding = mPrtBeen.zippdding1;
                long x, y;

                x = mPrtBeen.zipx;
                y = mPrtBeen.zipy;
                int mTmpFontSize = mPrtBeen.zipfontsize;

                for (int i = 0; i < 3; i++)
                {
                    e.Graphics.DrawString(zipCode.Substring(i, 1), new Font("@ＭＳ　ゴシック", mTmpFontSize, FontStyle.Bold, GraphicsUnit.Point),
                        Brushes.Black, x, y);
                    x += padding;
                }

                padding = mPrtBeen.zippdding2;
                // 書き出し位置調整:
                x += 2;

                for (int i = 4; i < 8; i++)
                {
                    e.Graphics.DrawString(zipCode.Substring(i, 1), new Font("@ＭＳ　ゴシック", mTmpFontSize, FontStyle.Bold, GraphicsUnit.Point),
                        Brushes.Black, x, y);
                    x += padding;
                }
            }
        }

        private string chgNum(string line, int tate)
        {
            string retVal = "";
            var mTmp = "";

            for (var i = 0; i < line.Length; i++)
            {
                mTmp = line.Substring(i, 1);
                switch (mTmp)
                {
                    case "0":
                    case "０":
                        mTmp = "０";
                        break;
                    case "1":
                    case "１":
                        mTmp = "１";
                        break;
                    case "2":
                    case "２":
                        mTmp = "２";
                        break;
                    case "3":
                    case "３":
                        mTmp = "３";
                        break;
                    case "4":
                    case "４":
                        mTmp = "４";
                        break;
                    case "5":
                    case "５":
                        mTmp = "５";
                        break;
                    case "6":
                    case "６":
                        mTmp = "６";
                        break;
                    case "7":
                    case "７":
                        mTmp = "７";
                        break;
                    case "8":
                    case "８":
                        mTmp = "８";
                        break;
                    case "9":
                    case "９":
                        mTmp = "９";
                        break;
                }

                // ハイフンを縦印刷の時だけ変換する。
                if (tate == 1 && (mTmp == "-" || mTmp == "ー" || mTmp == "―"))
                {
                    mTmp = "━";
                }
                retVal += mTmp;
            }
            return retVal;
        }
        private Boolean checkNumAddr(string line)
        {
            Boolean fl = false;

            switch (line)
            {
                case "0":
                case "０":
                    fl = true;
                    break;
                case "1":
                case "１":
                case "一":
                    fl = true;
                    break;
                case "2":
                case "２":
                case "二":
                    fl = true;
                    break;
                case "3":
                case "３":
                case "三":
                    fl = true;
                    break;
                case "4":
                case "４":
                case "四":
                    fl = true;
                    break;
                case "5":
                case "５":
                case "五":
                    fl = true;
                    break;
                case "6":
                case "６":
                case "六":
                    fl = true;
                    break;
                case "7":
                case "７":
                case "七":
                    fl = true;
                    break;
                case "8":
                case "８":
                case "八":
                    fl = true;
                    break;
                case "9":
                case "９":
                case "九":
                    fl = true;
                    break;
            }

            return fl;
        }



   }
}
