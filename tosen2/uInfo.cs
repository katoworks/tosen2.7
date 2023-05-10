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
    public partial class uInfo : Form
    {
        public uInfo(int mSetaiNo,int mFamiNo)
        {
            InitializeComponent();

            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;

            this.setaiNo = mSetaiNo;
            this.famiNo = mFamiNo;

            // Beanの生成
            se = new setaiInfoBeen();
            fa = new famiInfoBeen();
            cm = new companyInfoBeen();

            ba = new baseAddrDAO();
            fdao = new famiAddrDAO();
            cdao = new comTableDAO();
            
            se = ba.getInfo(setaiNo);
            setSetaiData();

            dbClass db = new dbClass();
            List<string> kindList = db.getKindList();

            foreach(string st in kindList)
            {
                this.famiKind.Items.Add(st);
            }
            this.famiKind.SelectedIndex = 0;
            fa = fdao.getInfo(setaiNo, famiNo);
            setFamiData();
            if (cdao.chkData(setaiNo, famiNo))
            {
                cm = cdao.getInfo(setaiNo, famiNo);
                setComData();
            }

        }
        private void setComData()
        {
            this.comName.Text = this.cm.comanyName;
            this.comKata.Text = this.cm.comKata;
            this.comTel.Text = this.cm.comTel;
            this.comAddr.Text = this.cm.comAddr;
            char[] sp = new char[] { '-' };
            if (this.cm.comZip != "-")
            {
                var zip = this.cm.comZip.Split(sp);
                this.comZip1.Text = zip[0];
                this.comZip2.Text = zip[1];
            }
        }

        private void setFamiData()
        {
            this.famiName.Text = this.fa.name;
            this.famiNameRubi.Text = this.fa.nameRubi;
            this.tel.Text = this.fa.tel;
            this.famiKind.SelectedIndex = this.fa.kind;
        }

        private void setSetaiData()
        {
            char[] sp = new char[] { '-' };
            var zip = this.se.zipCode.Split(sp);
            this.zip1.Text = zip[0];
            this.zip2.Text = zip[1];
            this.addr.Text = this.se.address;
            this.name.Text = this.se.name;
            this.nameRubi.Text = this.se.nameRubi;
        }

        private baseAddrDAO ba;
        private famiAddrDAO fdao;
        private comTableDAO cdao;

        private setaiInfoBeen se;
        private famiInfoBeen fa;
        private companyInfoBeen cm;

        private int setaiNo;
        private int famiNo;

        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("データを保存します。", "データ保存", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                setUpdateData();

                ba.add(se);
                fdao.setaiNo = this.setaiNo;
                fdao.famiNo = this.famiNo;
                fdao.add(fa);
                cdao.add(cm);
            }

            this.Close();
        }

        private void setUpdateData()
        {
            se.setaiNo = this.setaiNo;
            // 基本情報
            se.zipCode = this.zip1.Text + "-" + this.zip2.Text;
            se.address = this.addr.Text;
            se.name = this.name.Text;
            se.nameRubi = this.nameRubi.Text;

            // 家族情報
            fa.setaiNo = this.setaiNo;
            fa.famiNo = this.famiNo;
            fa.name = this.famiName.Text;
            fa.nameRubi = this.famiNameRubi.Text;
            fa.tel = this.tel.Text;
            fa.kind = this.famiKind.SelectedIndex;

            // 会社情報
            cm.setaiNo = this.setaiNo;
            cm.famiNo = this.famiNo;
            cm.comanyName = this.comName.Text;
            cm.comSimei = this.famiName.Text;
            cm.comSimeiRubi = this.famiNameRubi.Text;
            cm.comZip = this.comZip1.Text + "-" + this.comZip2.Text;
            cm.comAddr = this.comAddr.Text;
            cm.comTel = this.comTel.Text;
            cm.comKata = this.comKata.Text;
        }
        private void Can_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
