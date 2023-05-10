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
    public partial class famiryInputForm2 : Form
    {
        public famiryInputForm2()
        {
            InitializeComponent();
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;
            this.famiFlg = false;
        }

        public basicInfo baseInfo { set; get; }
        public List<famiAddr> famiInfo { set; get; }
        public cominfo companyInfo { set; get; }
        private kindInfoDTO kind { set; get; }
        private List<kindInfoDTO> kindList { set; get; }
        private Boolean baseDatFlg { set; get; }
        public Boolean comInfo { set; get; }
        public Boolean famiFlg { set; get; }

        public Boolean comVisual { set; get; }
        private Boolean nextFlg { set; get; }
        public Boolean modeEnable { set; get; }

        public void reload()
        {
            this.basName.Text = this.baseInfo.name;
            this.basNameRubi.Text = this.baseInfo.nameRubi;
            string mTmpZip = this.baseInfo.zipCode.Replace("-", "");
            this.zipCode1.Text = mTmpZip.Substring(0, 3);
            this.zipCode2.Text = mTmpZip.Substring(3, 4);
            this.basAddr.Text = this.baseInfo.address;
            this.kind = new kindInfoDTO();
            this.kind.refresh();
            setComboBox(this.grpBox, this.kind.kindDat);
            setComboBox(this.baseKind, this.kind.kindDat);
            setComboBox(this.famiryNameList, this.famiInfo);
            this.comVisual = this.famiInfo[0].conpnyFlg;
            this.famiComInfo.Checked = this.famiInfo[0].conpnyFlg;
            this.nextFlg = false;
            if (this.famiInfo.Count < 1)
            {
                this.famiDel.Enabled = true;
            }

            if (this.companyInfo is null)
            {
                this.famiComInfo.Enabled = false;
            }
            else 
            {
                this.famiComInfo.Enabled = true;
            }
            this.grpBox.SelectedIndex = 0;
            this.baseKind.SelectedIndex = this.famiInfo[0].kind;
            this.baseTel.Text = this.famiInfo[0].tel;
            if (this.famiInfo.Count() == 0)
            {
                this.baseDatFlg = false;
            }
            else
            {
                this.baseDatFlg = true;
            }

            //読み取り専用設定
            setMode();

            famiDisp();
        }

        private void setMode()
        {
            if (this.modeEnable == true)
            {
                this.famiComInfo.Enabled = false;
                this.famiName.Enabled = false;
                this.famiNameRubi.Enabled = false;
                this.famiTel.Enabled = false;
                this.grpBox.Enabled = false;
                this.katagaki.Enabled = false;
                this.nextInfo.Visible = false;
                this.famiDel.Visible = false;
                this.canAddDat.Visible = false; 
                this.canAddDat.Text = "削除";
            }
            else
            {
                this.famiComInfo.Enabled = true;
                this.famiName.Enabled = true;
                this.famiNameRubi.Enabled = true;
                this.famiTel.Enabled = true;
                this.grpBox.Enabled = true;
                this.katagaki.Enabled = true;
                this.nextInfo.Visible = true;
                this.famiDel.Visible = true;
                this.famiDel.Enabled = true;
                this.canAddDat.Visible = true; 
                this.canAddDat.Text = "保存";
            }
        }

        private void famiDisp()
        {
            Boolean mFlg = false;

            foreach(famiAddr mFm in this.famiInfo)
            {
                //this.famiryNameList.Items.Add(mFm.name);
                if (mFm.conpnyFlg == true)
                {
                    mFlg = true;
                }
                else
                {
                    mFlg = false;
                }
            }
            if (mFlg == true) 
            {
                this.famiComInfo.Checked = true;
            }
            this.famiName.Text = this.baseInfo.name;
            this.famiNameRubi.Text = this.baseInfo.nameRubi;
            this.famiTel.Text = this.famiInfo[0].tel;
            this.grpBox.SelectedIndex = this.famiInfo[0].kind;
            this.katagaki.Text = this.famiInfo[0].katagaki;
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setBaseInfo()
        {
            this.basName.Text = this.baseInfo.name;
            this.basNameRubi.Text = this.baseInfo.nameRubi;
            string mTmpZip = this.baseInfo.zipCode.Replace("-", "");
            this.zipCode1.Text = mTmpZip.Substring(0, 3);
            this.zipCode2.Text = mTmpZip.Substring(3, 4);
            this.basAddr.Text = this.baseInfo.address;
        }

        private void setComboBox(System.Windows.Forms.ComboBox cb, List<kindInfoDTO> kind)
        {
            int mCnt = 0;
            int mMax = kind.Count();
            cb.Items.Clear();
            for (mCnt = 0; mCnt < mMax; mCnt++)
            {
                if (kind[mCnt].kindName != "全て")
                {
                    cb.Items.Add(kind[mCnt].kindName);
                }
            }
            cb.SelectedIndex = 0;
        }
        private void setComboBox(System.Windows.Forms.ComboBox cb,List<famiAddr> famiryList)
        {
            int mCnt = 0;
            int mMax = famiryList.Count();

            cb.Items.Clear();
            for (mCnt = 0; mCnt < mMax; mCnt++)
            {
                cb.Items.Add(famiryList[mCnt].name);
            }
        }
        private Boolean check()
        {
            Boolean retVal = false;

            if(this.famiName.Text!="" &&
                this.famiNameRubi.Text!="" &&
                this.famiTel.Text!="" &&
                this.grpBox.Text!=""
                )
            {
                retVal = true;
            }

            return retVal;
        }

        private void textChange(object sender, EventArgs e)
        {
        }

        private void ketDownEve(object sender, KeyEventArgs e)
        {
        }

        private void selCOmName(object sender, EventArgs e)
        {
        }

        private void canAddDat_Click(object sender, EventArgs e)
        {
            if (check())
            {
                if (this.famiInfo.Count() != 0)
                {
                    DialogResult rst = MessageBox.Show("データを保存します。", "確認", MessageBoxButtons.OKCancel);
                    if (rst == DialogResult.OK)
                    {
                        baseDatUpdate();
                        this.famiFlg = true;

                        this.Close();
                    }
                }
            }
            else
            {
                DialogResult rst = MessageBox.Show("必要項目が入力されていません。", "注意", MessageBoxButtons.OK);
            }
        }
        private void famiUpdate()
        {
            if (check())
            {
                if (this.famiInfo.Count() != 0)
                {
                    DialogResult rst = MessageBox.Show("データを保存します。", "確認", MessageBoxButtons.OKCancel);
                    if (rst == DialogResult.OK)
                    {
                        baseDatAdd();
                        famiDatAdd();
                        this.famiFlg = true;

                        this.Close();
                    }
                }
            }
            else
            {
                DialogResult rst = MessageBox.Show("必要項目が入力されていません。", "注意", MessageBoxButtons.OK);
            }
        }

        private void clear()
        {
            this.famiName.ResetText();
            this.famiNameRubi.ResetText();
            this.famiTel.ResetText();
            this.grpBox.SelectedIndex = 0;
            this.katagaki.ResetText();
        }

        private void nextInfo_Click(object sender, EventArgs e)
        {
            this.nextFlg = true;
            if (this.check())
            {
                //基礎情報追加
                baseDatAdd();

                //家族情報追加
                //famiDatAdd();

                this.clear();
                this.famiryNameList.Text = "";
                this.famiryNameList.SelectedIndex = -1;
            }
            else
            {
                DialogResult rst = MessageBox.Show("必要項目が入力されていません。", "注意", MessageBoxButtons.OK);
            }

            // 次に行くときは削除ボタンをオフにする。
            this.famiDel.Enabled = false;
            this.famiName.Focus();
            this.famiComInfo.Checked = false;
//
//            if (this.famiryNameList.Items.Count > 1)
//            {
//                this.famiDel.Enabled = true;
//            }
//            else if (this.famiryNameList.Items.Count <= 1) 
//            {
//                this.famiDel.Enabled = false;
//            }
        }
        private void baseDatAdd()
        {
            // １回目以降は登録しない。
            if (this.baseDatFlg == false)
            {
                // 基本情報を追加する。
                famiAddr fm = new famiAddr();
                fm.name = this.basName.Text;
                fm.nameRubi = this.basNameRubi.Text;
                fm.tel = this.baseTel.Text;
                fm.kind = this.kind.find(this.baseKind.Text);
                famiInfo.Add(fm);
                this.baseDatFlg = true;
            }
        }
        private void baseDatUpdate()
        {
            int selList = 0;
            if (this.famiryNameList.SelectedIndex == -1 && this.famiInfo.Count == 1) 
            {
                baseDatAdd();
                famiDatAdd();
                this.famiFlg = true;
            }
            else
            {
                //変更時
                selList = this.famiryNameList.SelectedIndex;
                if (selList == -1)
                {
                    if (selList != this.famiInfo.Count)
                    {
                        selList = this.famiInfo.Count;
                    }

                    if (this.famiInfo == null)
                    {
                        famiAddr tmpFM = new famiAddr();
                        tmpFM.name = this.famiName.Text;
                        tmpFM.nameRubi = this.famiNameRubi.Text;
                        tmpFM.tel = this.famiTel.Text;
                        tmpFM.kind = this.kind.find(this.grpBox.Text);
                        tmpFM.conpnyFlg = this.famiComInfo.Checked;
                        tmpFM.katagaki = this.katagaki.Text;
                        this.famiInfo.Add(tmpFM);
                    }
                    else if (this.nextFlg == true)
                    {
                        famiAddr tmpAddr = new famiAddr();
                        tmpAddr.name = this.famiName.Text;
                        tmpAddr.nameRubi = this.famiNameRubi.Text;
                        tmpAddr.tel = this.famiTel.Text;
                        tmpAddr.kind = this.kind.find(this.grpBox.Text);
                        tmpAddr.conpnyFlg = this.famiComInfo.Checked;
                        tmpAddr.katagaki = this.katagaki.Text;
                        this.famiInfo.Add(tmpAddr);
                        this.nextFlg = false;

                    }
                    else if (this.famiryNameList.SelectedIndex == -1)
                    {
                        this.famiInfo[0].name = this.famiName.Text;
                        this.famiInfo[0].nameRubi = this.famiNameRubi.Text;
                        this.famiInfo[0].tel = this.famiTel.Text;
                        this.famiInfo[0].kind = this.kind.find(this.grpBox.Text);
                        this.famiInfo[0].conpnyFlg = this.famiComInfo.Checked;
                        this.famiInfo[0].katagaki = this.katagaki.Text;
                    }
                    else
                    {
                        famiAddr tmpAddr = new famiAddr();
                        tmpAddr.name = this.famiName.Text;
                        tmpAddr.nameRubi = this.famiNameRubi.Text;
                        tmpAddr.tel = this.famiTel.Text;
                        tmpAddr.kind = this.kind.find(this.grpBox.Text);
                        tmpAddr.conpnyFlg = this.famiComInfo.Checked;
                        tmpAddr.katagaki = this.katagaki.Text;
                        this.famiInfo.Add(tmpAddr);
                    }
                }
                else
                {
                    this.famiInfo[selList].name = this.famiName.Text;
                    this.famiInfo[selList].nameRubi = this.famiNameRubi.Text;
                    this.famiInfo[selList].tel = this.famiTel.Text;
                    this.famiInfo[selList].kind = this.kind.find(this.grpBox.Text);
                    this.famiInfo[selList].conpnyFlg = this.famiComInfo.Checked;
                    this.famiInfo[selList].katagaki = this.katagaki.Text;
                }
                    
                // 世帯主の変更があった場合は名前と名前ルビを変更する。
                if (this.famiryNameList.SelectedIndex == 0)
                {
                    this.baseInfo.name= this.famiName.Text;
                    this.baseInfo.nameRubi = this.famiNameRubi.Text;
                }
            }
        }

        private Boolean famiDatAdd()
        {
            Boolean retVal = false;
            
            if (check())
            {
                int mCnt = 0;
                if (this.famiryNameList.SelectedIndex == -1)
                {
                    mCnt = this.famiryNameList.Items.Count;

                    //家族情報追加
                    famiAddr fm = new famiAddr();
                    fm.name = this.famiName.Text;
                    fm.nameRubi = this.famiNameRubi.Text;
                    fm.tel = this.famiTel.Text;
                    fm.kind = this.kind.find(this.grpBox.Text);
                    fm.conpnyFlg = this.famiComInfo.Checked;
                    fm.katagaki = this.katagaki.Text;
                    famiInfo.Add(fm);
                    this.famiryNameList.Items.Add(fm.name);
                }
                else
                {
                    mCnt = this.famiryNameList.SelectedIndex;
                    this.famiInfo[mCnt].name = this.famiName.Text;
                    this.famiInfo[mCnt].nameRubi = this.famiNameRubi.Text;
                    this.famiInfo[mCnt].tel = this.famiTel.Text;
                    this.famiInfo[mCnt].conpnyFlg = this.famiComInfo.Checked;
                    this.famiInfo[mCnt].katagaki = this.katagaki.Text;
                }
                retVal = true;
            }

            return retVal;
        }

        private Boolean famiDatUpd()
        {
            Boolean retVal = false;
            if (check())
            {
                famiInfo[this.famiryNameList.SelectedIndex].name = this.famiName.Text;
                famiInfo[this.famiryNameList.SelectedIndex].nameRubi = this.famiNameRubi.Text;
                famiInfo[this.famiryNameList.SelectedIndex].tel = this.famiTel.Text;
                famiInfo[this.famiryNameList.SelectedIndex].kind = this.kind.find(this.grpBox.Text);
                famiInfo[this.famiryNameList.SelectedIndex].katagaki = this.katagaki.Text;
                famiInfo[this.famiryNameList.SelectedIndex].conpnyFlg = this.famiComInfo.Checked;
            }

            return retVal;
        }

        /// <summary>
        ///  名前を選択されたら呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectNameList(object sender, EventArgs e)
        {
            clearIndex();

            if (this.famiryNameList.SelectedIndex != -1)
            {
                this.famiDel.Enabled = true;
                int mCnt = 0;
                mCnt = this.famiryNameList.SelectedIndex;
                this.famiName.Text = this.famiInfo[mCnt].name;
                this.famiNameRubi.Text = this.famiInfo[mCnt].nameRubi;
                this.famiTel.Text = this.famiInfo[mCnt].tel;
                
                this.grpBox.Text = this.kind.find(this.famiInfo[mCnt].kind);
                this.katagaki.Text = this.famiInfo[mCnt].katagaki;
                this.famiComInfo.Checked = this.famiInfo[mCnt].conpnyFlg;
            }

        }

        private void setDisp()
        {
            int mCnt = 0;
            //mCnt = this.famiryNameList.SelectedIndex;
            this.famiName.Text = this.famiInfo[mCnt].name;
            this.famiNameRubi.Text = this.famiInfo[mCnt].nameRubi;
            this.famiTel.Text = this.famiInfo[mCnt].tel;
            
            this.grpBox.Text = this.kind.find(this.famiInfo[mCnt].kind);
            this.katagaki.Text = this.famiInfo[mCnt].katagaki;
            this.famiComInfo.Checked = this.famiInfo[mCnt].conpnyFlg;

        }
        private void clearIndex()
        {
            this.famiName.Text = "";
            this.famiNameRubi.Text = "";
            this.famiTel.Text = "";
            this.katagaki.Text = "";
        }

        private void conpanyCheck(object sender, EventArgs e)
        {
            if (this.famiComInfo.Checked)
            {
                this.katagaki.Visible = true;
                this.kataLabel.Visible = true;
            }
            else
            {
                this.katagaki.Visible = false;
                this.kataLabel.Visible = false;
            }
        }

        private void famiDel_Click(object sender, EventArgs e)
        {
            if (this.famiryNameList.SelectedIndex != -1)
            {
                if (this.famiryNameList.Items.Count == 1)
                {
                    DialogResult ng = MessageBox.Show("一人しか登録されていないため削除できません。", "アラート", MessageBoxButtons.OK);

                }
                else if (this.famiryNameList.SelectedIndex == 0)
                {
                    DialogResult ng = MessageBox.Show("世帯主の為削除できません。", "アラート", MessageBoxButtons.OK);
                }
                else
                {
                    DialogResult rst = MessageBox.Show("表示されているメンバーが削除されます。よろしいですか？", "注意", MessageBoxButtons.OKCancel);
                    if (rst == DialogResult.OK)
                    {
                        this.famiInfo.RemoveAt(this.famiryNameList.SelectedIndex);

                        clearIndex();
                        int mCnt = 0;
                        this.famiName.Text = this.famiInfo[mCnt].name;
                        this.famiNameRubi.Text = this.famiInfo[mCnt].nameRubi;
                        this.famiTel.Text = this.famiInfo[mCnt].tel;

                        this.grpBox.Text = this.kind.find(this.famiInfo[mCnt].kind);
                        this.katagaki.Text = this.famiInfo[mCnt].katagaki;
                        this.famiComInfo.Checked = this.famiInfo[mCnt].conpnyFlg;

                        // 家族リストボックスからも除外
                        int tmpCnt1 = this.famiryNameList.SelectedIndex;
                        this.famiryNameList.Items.RemoveAt(tmpCnt1);
                        this.famiryNameList.SelectedIndex = 0;
                        this.famiryNameList.Text = "";
                        clearIndex();

                        setDisp();

                    }
                }
            }
            else
            {
                DialogResult ng = MessageBox.Show("世帯主の為削除できません。", "アラート", MessageBoxButtons.OK);
            }
        }
    }
}
