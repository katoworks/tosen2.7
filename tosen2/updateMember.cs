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
    public partial class updateMember : Form
    {
        public updateMember()
        {
            InitializeComponent();

            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;

            ba = new baseAddrDAO();
            dbClass db = new dbClass();
            List<string> iList = new List<string>();
            iList = db.getKindList();
            foreach(string item in iList)
            {
                this.kindList.Items.Add(item);
            }
//            this.kindList.SelectedIndex = 0;
        }

        private baseAddrDAO ba;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void canAddDat_Click(object sender, EventArgs e)
        {

        }

        private void saveAddDat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void famiInfoInput_Click(object sender, EventArgs e)
        {
            int setaiNo = 0;
            int famiNo = 0;

            if (chkRadio())
            {
                foreach (DataGridViewCell se in this.selList.SelectedCells)
                {
                    setaiNo = int.Parse(this.selList.Rows[se.RowIndex].Cells[1].Value.ToString());
                    famiNo = int.Parse(this.selList.Rows[se.RowIndex].Cells[2].Value.ToString());
                }

                uInfo fm = new uInfo(setaiNo, famiNo);
                memberInfoDTO addrBase = new memberInfoDTO();
                famiInfoDTO famiMem = new famiInfoDTO();

                fm.ShowDialog(this);
                dspSelList();
            }
            else
            {
                MessageBox.Show("変更するユーザーが選択されていません", "注意",MessageBoxButtons.OK);
            }
        }

        private void companyInput_Click(object sender, EventArgs e)
        {
            int setaiNo = 0;
            int famiNo = 0;
            string nm = "";

            if (chkRadio())
            {
                foreach (DataGridViewCell se in this.selList.SelectedCells)
                {
                    setaiNo = int.Parse(this.selList.Rows[se.RowIndex].Cells[1].Value.ToString());
                    famiNo = int.Parse(this.selList.Rows[se.RowIndex].Cells[2].Value.ToString());
                    nm = this.selList.Rows[se.RowIndex].Cells[3].Value.ToString();
                }
                string messageData = string.Format("「{0}」さんのデータを削除します。", nm);
                if (MessageBox.Show(messageData, "削除", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    famiAddrDAO fdao = new famiAddrDAO();
                    comTableDAO cdao = new comTableDAO();

                    fdao.del(setaiNo, famiNo);
                    cdao.del(setaiNo, famiNo);
                    dspSelList();
                }
            }
            else
            {
                MessageBox.Show("変更するユーザーが選択されていません", "注意",MessageBoxButtons.OK);
            }
        }

        private  void dspSelList()
        {
            this.selList.Rows.Clear();
            this.selList.Columns.Clear();

            List<famiryEditBean> infoList = new List<famiryEditBean>();

            infoList = ba.getEditList(this.name.Text, this.nameRubi.Text, this.compaName.Text, kindList.SelectedIndex);
            int rowCnt = 0;

            // DataGridView 初期化

            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            this.selList.Columns.Add(clm);
            this.selList.Columns.Add("", "世帯番号");
            this.selList.Columns.Add("", "家族番号");
            this.selList.Columns.Add("", "氏　　名");
            this.selList.Columns.Add("", "氏名カナ");
            this.selList.Columns.Add("", "郵便番号");
            this.selList.Columns.Add("", "住　　所");
            this.selList.Columns.Add("", "電話番号");
            this.selList.Columns.Add("", "会 社 名");
            this.selList.Columns.Add("", "肩　　書");
            this.selList.Columns.Add("", "所　　属");
            this.selList.ColumnCount = 11;
            this.selList.Columns[0].Width = 50;
            this.selList.Columns[1].Width = 110;
            this.selList.Columns[2].Width = 110;
            this.selList.Columns[3].Width = 200;
            this.selList.Columns[4].Width = 200;
            this.selList.Columns[5].Width = 150;
            this.selList.Columns[6].Width = 600;
            this.selList.Columns[7].Width = 300;
            this.selList.Columns[8].Width = 300;
            this.selList.Columns[9].Width = 300;
            this.selList.Columns[10].Width = 300;
            this.selList.AutoGenerateColumns = true;
            this.selList.AllowUserToAddRows = false;

            //件数分のGirdを追加
            this.selList.Rows.Add(infoList.Count);

            foreach (famiryEditBean iList in infoList)
            {
                this.selList.Rows[rowCnt].Cells[1].Value = iList.setaiNo;
                this.selList.Rows[rowCnt].Cells[2].Value = iList.famiNo;
                this.selList.Rows[rowCnt].Cells[3].Value = iList.name;
                this.selList.Rows[rowCnt].Cells[4].Value = iList.nameRubi;
                this.selList.Rows[rowCnt].Cells[5].Value = iList.zip;
                this.selList.Rows[rowCnt].Cells[6].Value = iList.addr;
                this.selList.Rows[rowCnt].Cells[7].Value = iList.tel;
                this.selList.Rows[rowCnt].Cells[8].Value = iList.comName;
                this.selList.Rows[rowCnt].Cells[9].Value = iList.comKata;
                this.selList.Rows[rowCnt].Cells[10].Value = iList.kind;
                rowCnt++;
            }

        }

        private void srchWord_Click(object sender, EventArgs e)
        {
            this.selList.Rows.Clear();
            this.selList.Columns.Clear();

            List<famiryEditBean> infoList = new List<famiryEditBean>();

            infoList = ba.getEditList(this.name.Text, this.nameRubi.Text, this.compaName.Text, kindList.SelectedIndex);
            if (infoList.Count == 0)
            {
                MessageBox.Show("データが有りません。");
                return;
            }

            int rowCnt = 0;
            
            // DataGridView 初期化
            
            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            this.selList.Columns.Add(clm);
            this.selList.Columns.Add("", "世帯番号");
            this.selList.Columns.Add("", "家族番号");
            this.selList.Columns.Add("", "氏　　名");
            this.selList.Columns.Add("", "氏名カナ");
            this.selList.Columns.Add("", "郵便番号");
            this.selList.Columns.Add("", "住　　所");
            this.selList.Columns.Add("", "電話番号");
            this.selList.Columns.Add("", "会 社 名");
            this.selList.Columns.Add("", "肩　　書");
            this.selList.Columns.Add("", "所　　属");
            this.selList.ColumnCount = 11;
            this.selList.Columns[0].Width = 50;
            this.selList.Columns[1].Width = 110;
            this.selList.Columns[2].Width = 110;
            this.selList.Columns[3].Width = 200;
            this.selList.Columns[4].Width = 200;
            this.selList.Columns[5].Width = 150;
            this.selList.Columns[6].Width = 600;
            this.selList.Columns[7].Width = 300;
            this.selList.Columns[8].Width = 300;
            this.selList.Columns[9].Width = 300;
            this.selList.Columns[10].Width = 300;
            this.selList.AutoGenerateColumns = true;
            this.selList.AllowUserToAddRows = false;

            //件数分のGirdを追加
            this.selList.Rows.Add(infoList.Count);
            
            foreach(famiryEditBean iList in infoList)
            {
                this.selList.Rows[rowCnt].Cells[1].Value = iList.setaiNo;
                this.selList.Rows[rowCnt].Cells[2].Value = iList.famiNo;
                this.selList.Rows[rowCnt].Cells[3].Value = iList.name;
                this.selList.Rows[rowCnt].Cells[4].Value = iList.nameRubi;
                this.selList.Rows[rowCnt].Cells[5].Value = iList.zip;
                this.selList.Rows[rowCnt].Cells[6].Value = iList.addr;
                this.selList.Rows[rowCnt].Cells[7].Value = iList.tel;
                this.selList.Rows[rowCnt].Cells[8].Value = iList.comName;
                this.selList.Rows[rowCnt].Cells[9].Value = iList.comKata;
                this.selList.Rows[rowCnt].Cells[10].Value = iList.kind;
                rowCnt++;
            }
        }

        private void addFami_Click(object sender, EventArgs e)
        {
            if (chkRadio())
            {
                mFamiAdd fa = new mFamiAdd();
                fa.setaiNo = getFamiInfo();
                fa.ShowDialog(this);
                dspSelList();
            }
            else
            {
                MessageBox.Show("変更するユーザーが選択されていません", "注意",MessageBoxButtons.OK);
            }
        }

        private Boolean chkRadio()
        {
            Boolean retVal = false;
            int setaiNo = 0;
            foreach (DataGridViewCell se in this.selList.SelectedCells)
            {
                setaiNo++;
            }

            if (setaiNo != 0)
            {
                retVal = true;
            }

            return retVal;
        }

        private int getFamiInfo()
        {
            int retVal = 0;
            foreach (DataGridViewCell se in this.selList.SelectedCells)
            {
                retVal = int.Parse(this.selList.Rows[se.RowIndex].Cells[1].Value.ToString());
                break;
            }

            return retVal;
        }
    }

}
