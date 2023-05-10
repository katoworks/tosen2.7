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
    public partial class dataEditMenu : Form
    {
        public dataEditMenu()
        {
            InitializeComponent();
        }

        private void editExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kaisyaPrint_Click(object sender, EventArgs e)
        {
            comSrch cr = new comSrch();
            cr.Show();
        }

        private void groupPrint_Click(object sender, EventArgs e)
        {
            grpDspSrch gds = new grpDspSrch();
            gds.Show();
        }

        private void simeiPrint_Click(object sender, EventArgs e)
        {
            dspMember dp = new dspMember();
            dp.Show();

        }

        private void listPrint_Click(object sender, EventArgs e)
        {
            printAll itiran = new printAll();
            itiran.ShowDialog();
        }

        private void hagakiPrt_Click(object sender, EventArgs e)
        {
            hagakiPrn hgn = new hagakiPrn();
            hgn.Show();
        }

        private void dataChg_Click(object sender, EventArgs e)
        {
            srchChgMember chgUpd = new srchChgMember();
            
            chgUpd.ShowDialog();
            //updateMember upd = new updateMember();
            //upd.Show();
        }

        private void dataAdd_Click(object sender, EventArgs e)
        {
            //addMember ad = new addMember();
            //ad.Show();
            addMember2 ad2 = new addMember2();
            ad2.Show();

        }

        private void export_Click(object sender, EventArgs e)
        {
            baseAddrDAO baseDao = new baseAddrDAO();
            famiAddrDAO famiDao = new famiAddrDAO();
            comTableDAO comDat = new comTableDAO();

            this.infomation.Text = "基本情報のバックアップ中";
            string fullPath = baseDao.export();
            this.infomation.Text = "家族情報のバックアップ中";
            this.infomation.Refresh();
            famiDao.export(fullPath);
            this.infomation.Text = "会社情報のバックアップ中";
            this.infomation.Refresh();
            comDat.export(fullPath);
            
            DialogResult rst = MessageBox.Show("データが保存されました", "インフォメーション", MessageBoxButtons.OK);

        }
    }
}
