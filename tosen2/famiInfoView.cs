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
    public partial class famiInfoView : Form
    {
        public famiInfoView()
        {
            InitializeComponent();

            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;

            // 基本情報
            this.zip1.Text = addMember.mMember.zip1;
            this.zip2.Text = addMember.mMember.zip2;
            this.address.Text = addMember.mMember.address;
            this.name.Text = addMember.mMember.name;
            this.nameRubi.Text = addMember.mMember.nameRubi;
            this.tel.Text = addMember.mMember.tel;

            // 会社情報
            this.comName.Text = addMember.mCompany[0].comName;
            this.comKata.Text = addMember.mCompany[0].comKata;
            this.comSimei.Text = addMember.mCompany[0].comShimei;
            this.comShimeiRubi.Text = addMember.mCompany[0].comShimeiRubi;
            this.comZip1.Text = addMember.mCompany[0].comZip1;
            this.comZip2.Text = addMember.mCompany[0].comZip2;
            this.comAddr.Text = addMember.mCompany[0].comAddress;
        }
        private void infoOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void famiryInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
