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
    public partial class comInput : Form
    {
        public comInput()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAs_Click(object sender, EventArgs e)
        {
            comInfoDTO tmpCom = new comInfoDTO();

            // 会社情報
            tmpCom.comName = this.comName.Text;
            tmpCom.comZip1 = this.zip1.Text;
            tmpCom.comZip2 = this.zip2.Text;
            tmpCom.comKata = this.comKata.Text;
            tmpCom.comShimeiRubi = this.comShimeiRubi.Text;
            tmpCom.comShimei = this.comShimei.Text;
            tmpCom.comAddress = this.comAddr.Text;
            addMember.mCompany.Add(tmpCom);
            
            DialogResult rst =  MessageBox.Show("続けて入力しますか？", "確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (rst == DialogResult.Yes)
            {

            }
            else
            {
                this.Close();
            }
        }
    }
}
