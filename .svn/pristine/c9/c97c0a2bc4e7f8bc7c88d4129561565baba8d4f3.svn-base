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
    public partial class dataEdit : Form
    {
        public dataEdit()
        {
            InitializeComponent();
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;

        }

        private void dataEdit_Load(object sender, EventArgs e)
        {
        }

        private void endEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataAdd_Click(object sender, EventArgs e)
        {
            addMember ad = new addMember();
            ad.Show();
        }

        private void memDsp_Click(object sender, EventArgs e)
        {
            dspMember dp = new dspMember();
            dp.Show();
        }

        private void comDsp_Click(object sender, EventArgs e)
        {
            comSrch cr = new comSrch();
            cr.Show();

        }

        private void grpDisp_Click(object sender, EventArgs e)
        {
            grpDspSrch gds = new grpDspSrch();
            gds.Show();
        }

        private void dataChg_Click(object sender, EventArgs e)
        {
            updateMember upd = new updateMember();
            upd.Show();
        }

        private void dataDel_Click(object sender, EventArgs e)
        {
            memDeleteForm dl = new memDeleteForm();
            dl.Show();
        }

        private void jarnalPrint_Click(object sender, EventArgs e)
        {
            printAll itiran = new printAll();
            itiran.ShowDialog();
        }

        private void hagakiPrt_Click(object sender, EventArgs e)
        {
            hagakiPrn hgn = new hagakiPrn();
            hgn.Show();
        }

        private void addGrp_Click(object sender, EventArgs e)
        {
            grpAddChg gp = new grpAddChg();
            gp.Show();
        }
    }
}
