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
    public partial class famiAdd : Form
    {
        public famiAdd()
        {
            InitializeComponent();

            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;
            db = new dbClass();

            fdao = new famiAddrDAO();
            fb = new famiInfoBeen();
            kind = db.getKindList();

            this.kindList.Items.Clear();

            foreach(string kl in kind)
            {
                this.kindList.Items.Add(kl);
            }
            this.kindList.SelectedIndex = 0;
        }

        public int setaiNo { set; get; }
        private famiAddrDAO fdao;
        private famiInfoBeen fb;
        private List<string> kind;
        private dbClass db;

        private void saveAddDat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("データを保存します。", "情報追加", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    fdao.famiryNo = fdao.getFamiNo(this.setaiNo);
                    fdao.setaiNo = this.setaiNo;
                    fb.name = this.name.Text;
                    fb.nameRubi = this.nameRubi.Text;
                    fb.tel = this.famiTel.Text;
                    fb.kind = this.kindList.SelectedIndex;
                    fdao.update(fb);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
