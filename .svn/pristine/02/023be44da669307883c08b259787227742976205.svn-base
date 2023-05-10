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
    public partial class addMember : Form
    {
        public addMember()
        {
            InitializeComponent();

            this.kindList.DropDownStyle = ComboBoxStyle.DropDownList;
            List<string> kindLine = new List<string>();

            // DBインスタンス生成
            dbClass db = new dbClass();
            kindLine = db.getKindList();
            for(int i = 0; i < kindLine.Count; i++)
            {
                kindList.Items.Add(kindLine[i].ToString());
            }
            // 初期値設定
            kindList.SelectedIndex = 0;

            //各種設定タブの初期設定
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;

            // 内部保存用メンバの初期設定
            mMember = new memberInfoDTO();
            addMember.mFamiry = new List<famiInfoDTO>();
            addMember.mCompany = new List<comInfoDTO>();
            // 家族内の人数
            this.setaiFlg = 0;
            addMember.famiCnt = 0;
        }
        private famiInfoBeen fm = new famiInfoBeen();
        private string comFlg { set; get; }
        public static memberInfoDTO mMember { set; get; }
        public int setaiFlg { set; get; }
        public static List<famiInfoDTO> mFamiry { set; get; }
        public static List<comInfoDTO> mCompany { set; get; }
        public static int famiCnt { set; get; }
        public List<string> selKindDat;
        public basicInfo baseAddr { set; get; }

        private void canAddDat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void famiInput_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void setMemberInfo()
        {

        }

        private void saveAddDat_Click(object sender, EventArgs e)
        {
            baseAddrDAO bs = new baseAddrDAO();
            comTableDAO cm = new comTableDAO();
            famiAddrDAO fm = new famiAddrDAO();

            if (MessageBox.Show("住所録データを保存します。", "データ保存", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                // 基本情報を設定する。
                setMember();
                // 住所基本情報を設定
                try
                {
                    // 基本情報の保存
                    bs.set(mMember);
                    int setai = bs.saveData();

                    if (this.setaiFlg == 0)
                    {
                        // 家族情報
                        famiInfoDTO tmpFm = new famiInfoDTO();
                        tmpFm.setaiNo = setai;
                        tmpFm.famiNo = 0;
                        tmpFm.name = this.name.Text;
                        tmpFm.nameRubi = this.nameRubi.Text;
                        tmpFm.tel = this.tel.Text;
                        tmpFm.syozoku = this.kindList.SelectedIndex;
                        addMember.mFamiry.Add(tmpFm);

                        // 会社情報
                        comInfoDTO tmpCm = new comInfoDTO();
                        tmpCm.comName = this.comName.Text;
                        tmpCm.comShimei = this.name.Text;
                        tmpCm.comShimeiRubi = this.nameRubi.Text;
                        tmpCm.comZip1 = this.zip1.Text;
                        tmpCm.comZip2 = this.zip2.Text;
                        tmpCm.tel = this.tel.Text;
                        tmpCm.comAddress = this.address.Text;
                        tmpCm.comKata = this.comKata.Text;
                        addMember.mCompany.Add(tmpCm);

                        this.setaiFlg = 1;
                    }

                    //家族情報設定
                    fm.setaiNo = setai;
                    fm.set(addMember.mFamiry);

                    // 会社情報の保存
                    cm.set(addMember.mCompany);
                    cm.save(setai);
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    this.Close();
                }

            }
        }

        private void infoDataSave()
        {

        }

        private void setMember()
        {
            mMember.name = this.name.Text;
            mMember.nameRubi = this.nameRubi.Text;
            mMember.address = this.address.Text;
            mMember.zip = this.zip1.Text + "-" + this.zip2.Text;
            mMember.zip1 = this.zip1.Text;
            mMember.zip2 = this.zip2.Text;
            mMember.tel = this.tel.Text;

        }

        private void companyInput_Click(object sender, EventArgs e)
        {
            setMember();
            if (this.setaiFlg == 0)
            {
                famiInfoDTO tmpFm = new famiInfoDTO();
                tmpFm.famiNo = 0;
                tmpFm.name = this.name.Text;
                tmpFm.nameRubi = this.nameRubi.Text;
                tmpFm.tel = this.tel.Text;
                tmpFm.syozoku = this.kindList.SelectedIndex;
                addMember.mFamiry.Add(tmpFm);
                this.setaiFlg = 1;
            }


            comInput comI = new comInput();
            comI.Show();
        }

        private void famiInfoInput_Click(object sender, EventArgs e)
        {
            setMember();
            this.baseAddr = new basicInfo();
            this.baseAddr.setaiNo = 0;
            this.baseAddr.zipCode = this.zip1.Text + this.zip2.Text;
            this.baseAddr.name = this.name.Text;
            this.baseAddr.nameRubi = this.nameRubi.Text;
            this.baseAddr.address = this.address.Text;

            //            FamiryInputForm fm = new FamiryInputForm();
            //            fm.Show();
            famiryInputForm2 fm2 = new famiryInputForm2();
            fm2.baseInfo = new basicInfo();
            fm2.baseInfo = this.baseAddr;
            fm2.reload();
            fm2.Show();
        }

        private void clrButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("入力フィールドをクリアします。", "確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.kindList.SelectedIndex = 0;
                this.zip1.Text = "";
                this.zip2.Text = "";
                this.address.Text = "";
                this.name.Text = "";
                this.nameRubi.Text = "";
                this.tel.Text = "";
            }
        }

        private void infoChg_Click(object sender, EventArgs e)
        {
            famiInfoView fmv = new famiInfoView();
            fmv.Show();
        }
    }
}