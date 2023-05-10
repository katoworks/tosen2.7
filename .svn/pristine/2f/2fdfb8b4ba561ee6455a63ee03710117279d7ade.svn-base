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
    public partial class chgMember : Form
    {
        public chgMember()
        {
            InitializeComponent();
            //各種設定タブの初期設定
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;
            this.kind = new kindInfoDTO();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.kindList = new List<kindInfoDTO>();
            this.kindList = this.kind.getList();
            int mCnt = this.kindList.Count();
            for (int i = 0; i < mCnt; i++)
            {
                string mStr = this.kindList[i].kindName;
                if (mStr != "全て")
                {
                    this.baseKind.Items.Add(mStr);
                }
            }
            this.baseKind.SelectedIndex = 0;
        }
        public basicInfo baseAddr { set; get; }
        public List<famiAddr> famiDat { set; get; }
        public comInfoInput companyInfo { set; get; }
        public cominfo comInfo { set; get; }
        private famiryInputForm2 fami2 { set; get; }
        private Boolean comFlg { set; get; }
        private Boolean famiFlg { set; get; }
        private kindInfoDTO kind { set; get; }
        private List<kindInfoDTO> kindList { set; get; }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult rst = MessageBox.Show("破棄しますか？データは保存されません。", "確認", MessageBoxButtons.OKCancel);
            if (rst == DialogResult.OK)
            {
                this.Hide();
            }
        }

        private void cimInfoBtn_Click(object sender, EventArgs e)
        {
            if (chkDat())
            {
                if (companyInfo is null)
                {
                    companyInfo = new comInfoInput();
                }
                if (this.baseAddr is null)
                {
                    this.baseAddr = new basicInfo();
                }

                this.baseAddr.zipCode = this.zipCode1.Text + this.zipCode2.Text;
                this.baseAddr.address = this.basAddr.Text;
                this.baseAddr.name = this.basName.Text;
                this.baseAddr.nameRubi = this.basNameRubi.Text;
                this.companyInfo.baseInfo = this.baseAddr;
                this.companyInfo.modeEnable = false;
                this.companyInfo.reload();
                this.companyInfo.ShowDialog();

                if (this.companyInfo.companyInfo != null)
                {
                    this.comInfo = this.companyInfo.companyInfo;
                }
            }
            else
            {
                DialogResult rst = MessageBox.Show("登録するデータはすべて必須項目です。", "警告", MessageBoxButtons.OK);
            }
        }

        public void Reload()
        {
            this.zipCode1.Text = this.baseAddr.zipCode.Substring(0, 3);
            this.zipCode2.Text = this.baseAddr.zipCode.Substring(4, 4);
            this.basAddr.Text = this.baseAddr.address;
            this.basName.Text = this.baseAddr.name;
            this.basNameRubi.Text = this.baseAddr.nameRubi;
            this.baseTel.Text = this.famiDat[0].tel;
            this.baseKind.SelectedIndex = this.famiDat[0].kind;
            int mFamiCnt = this.famiDat.Count();
            if (this.famiDat != null)
            {
                this.fami2 = new famiryInputForm2();

                this.fami2.famiInfo = this.famiDat;
                this.fami2.famiFlg = false;
            }
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
        private void chkCompanyObj()
        {
            if (this.companyInfo is null)
            {
                //this.fami2.companyInfo = new cominfo();
            }
            else
            {
                this.fami2.companyInfo = new cominfo();
                this.fami2.companyInfo.comName = this.companyInfo.companyInfo.comName;
                this.fami2.companyInfo.comAddr = this.companyInfo.companyInfo.comAddr;
                this.fami2.companyInfo.comZip = this.companyInfo.companyInfo.comZip;
                this.fami2.companyInfo.comAddr = this.companyInfo.companyInfo.comAddr;
            }
        }

        private void famiInputBtn_Click(object sender, EventArgs e)
        {
            if (this.baseAddr is null)
            {
                this.baseAddr = new basicInfo();
            }

            if (this.fami2 != null)
            {

                famiryInputForm2 tmpFm2 = new famiryInputForm2();
                tmpFm2.famiInfo = this.fami2.famiInfo;
                this.fami2 = new famiryInputForm2();
                this.fami2.famiInfo = tmpFm2.famiInfo;
                chkCompanyObj();

                this.baseAddr.zipCode = this.zipCode1.Text + this.zipCode2.Text;
                this.baseAddr.address = this.basAddr.Text;
                this.baseAddr.name = this.basName.Text;
                this.baseAddr.nameRubi = this.basNameRubi.Text;
                this.fami2.baseInfo = this.baseAddr;
                this.fami2.famiInfo[0].kind = this.kind.find(this.baseKind.Text);
            }
            else
            {
                this.fami2 = new famiryInputForm2();
                chkCompanyObj();

                this.baseAddr.zipCode = this.zipCode1.Text + this.zipCode2.Text;
                this.baseAddr.address = this.basAddr.Text;
                this.baseAddr.name = this.basName.Text;
                this.baseAddr.nameRubi = this.basNameRubi.Text;
                famiDat = new List<famiAddr>();
                famiAddr fDat = new famiAddr();
                fDat.name = this.basName.Text;
                fDat.nameRubi = this.basNameRubi.Text;
                fDat.tel = this.baseTel.Text;
                fDat.kind = this.kind.find(this.baseKind.Text);
                famiDat = new List<famiAddr>();
                famiDat.Add(fDat);
                this.fami2.famiInfo = new List<famiAddr>();
                this.fami2.famiInfo = this.famiDat;
                this.fami2.baseInfo = this.baseAddr;
                if (this.companyInfo != null)
                {
                    if (this.companyInfo.comInfo == true)
                    {
                        this.fami2.comInfo = true;
                    }
                }
            }
            if (chkDat())
            {
                this.fami2.modeEnable = false;
                this.fami2.reload();
                this.fami2.ShowDialog();

                // 家族情報が変更されていた場合にこちらのメンバを変更する。
                this.basName.Text = this.fami2.famiInfo[0].name;
                this.basNameRubi.Text = this.fami2.famiInfo[0].nameRubi;
                this.baseKind.Text = this.kind.find(this.fami2.famiInfo[0].kind);
                this.famiDat = this.fami2.famiInfo;
            }
            else
            {
                DialogResult rst = MessageBox.Show("登録するデータはすべて必須項目です。", "警告", MessageBoxButtons.OK);
            }
        }
        private string Chg(string line)
        {
            string retVal = "";

            retVal = line.Replace("－", "-");
            retVal = line.Replace("ー", "-");
            retVal = line.Replace("―", "-");
            retVal = line.Replace("－", "-");

            return retVal;
        }

        private void saveData()
        {
            baseAddrDAO baseDao = new baseAddrDAO();
            famiAddrDAO famiDao = new famiAddrDAO();
            comTableDAO comDat = new comTableDAO();
            memberInfoDTO baseBeen = new memberInfoDTO();
            List<famiInfoBeen> famiBeen = new List<famiInfoBeen>();
            List<comInfoDTO> comBeen = new List<comInfoDTO>();
            int setaiNo = 0;
            int mFamiCnt = 0;

            // 基本情報テーブルInsert
            baseBeen.name = this.basName.Text;
            baseBeen.nameRubi = this.basNameRubi.Text;
            baseBeen.zip1 = this.zipCode1.Text;
            baseBeen.zip2 = this.zipCode2.Text;
            baseBeen.tel = this.baseTel.Text;
            baseBeen.address = Chg(this.basAddr.Text);
            baseDao.set(baseBeen);
            setaiNo = baseAddr.setaiNo;
            baseDao.Del(setaiNo);
            baseDao.saveData(setaiNo);

            // 家族情報
            mFamiCnt = 0;
            foreach (famiAddr mVar in famiDat)
            {
                famiInfoBeen mDao = new famiInfoBeen();
                mDao.setaiNo = setaiNo;
                mDao.famiNo = mFamiCnt;
                mDao.name = mVar.name;
                mDao.nameRubi = mVar.nameRubi;
                mDao.tel = mVar.tel;
                mDao.kind = mVar.kind;
                famiBeen.Add(mDao);
                mFamiCnt++;
            }
            famiDao.Del(setaiNo);
            famiDao.Add(famiBeen);

            if (this.companyInfo != null)
            {
                // 会社情報
                for (int mCnt = 0; mCnt < famiDat.Count; mCnt++)
                {
                    comInfoDTO mDat = new comInfoDTO();
                    if (famiDat[mCnt].conpnyFlg == true)
                    {
                        mDat.setaiNo = setaiNo;
                        mDat.famiNo = mCnt;
                        mDat.comName = this.companyInfo.companyInfo.comName;
                        mDat.comAddress = Chg(this.companyInfo.companyInfo.comAddr);
                        mDat.tel = this.companyInfo.companyInfo.comTel;
                        mDat.comZip1 = this.companyInfo.companyInfo.comZip.Substring(0, 3);
                        mDat.comZip2 = this.companyInfo.companyInfo.comZip.Substring(4, 4);
                        mDat.comShimei = this.famiDat[mCnt].name;
                        mDat.comShimeiRubi = this.famiDat[mCnt].nameRubi;
                        mDat.comKata = this.famiDat[mCnt].katagaki;
                        comBeen.Add(mDat);
                    }
                }
                comDat.Del(setaiNo);
                comDat.Add(comBeen);

            }
        }

        private void infoSaveBtn_Click(object sender, EventArgs e)
        {
            //基本情報が入力されているか（必須チェック 
            if (check())
            {
                if (this.fami2 is null)
                {
                    this.famiDat = new List<famiAddr>();
                    famiAddr fDat = new famiAddr();
                    fDat.name = this.basName.Text;
                    fDat.nameRubi = this.basNameRubi.Text;
                    fDat.tel = this.baseTel.Text;
                    fDat.kind = this.kind.find(this.baseKind.Text);
                    famiDat.Add(fDat);
                }
                else
                {
                    // 家族情報が入力された場合はデータを作る。
                    if (this.fami2.famiFlg == true)
                    {
                        //登録用のメンバに移動
                        this.famiDat = this.fami2.famiInfo;
                    }
                    // 家族情報がない場合はエラー（実質自分がカウントされていない場合は自分を保存する。
                    else if (this.fami2.famiInfo == null)
                    {
                        famiDat = new List<famiAddr>();
                        famiAddr fDat = new famiAddr();
                        fDat.name = this.basName.Text;
                        fDat.nameRubi = this.basNameRubi.Text;
                        fDat.tel = this.baseTel.Text;
                        fDat.kind = this.kind.find(this.baseKind.Text);
                        famiDat.Add(fDat);
                    }
                    else
                    {
                        famiDat[0].name = this.basName.Text;
                        famiDat[0].nameRubi = this.basNameRubi.Text;
                        famiDat[0].tel = this.baseTel.Text;
                        famiDat[0].kind = this.baseKind.SelectedIndex;

                    }
                }
            }

            DialogResult rst = MessageBox.Show("データを保存します。よろしければ「OK」を押下してください。", "データ保存", MessageBoxButtons.OKCancel);
            if (rst == DialogResult.OK)
            {
                saveData();

                this.Close();
            }
        }

        private void setFamiDat(famiAddr line)
        {

        }

        private Boolean check()
        {
            Boolean retVal = false;

            if (this.zipCode1.Text != "" &&
                this.zipCode2.Text != "" &&
                this.basAddr.Text != "" &&
                this.basName.Text != "" &&
                this.basNameRubi.Text != "" &&
                this.baseTel.Text != "" &&
                this.baseKind.Text != "")
            {
                retVal = true;
            }

            return retVal;
        }

        private Boolean checkCom()
        {
            Boolean retVal = false;

            //会社名が入っていない場合は登録なしとする。
            if (this.companyInfo.companyInfo.comName != "")
            {
                this.comFlg = true;
                retVal = true;
            }
            else
            {
                this.comFlg = false;
            }

            return retVal;
        }

        private Boolean checkFami()
        {
            Boolean retVal = false;
            if (this.fami2.famiInfo.Count() > 0)
            {
                retVal = true;
                this.famiFlg = true;
            }
            else
            {
                this.famiFlg = false;
            }

            return retVal;
        }
    }
}
