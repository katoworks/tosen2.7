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
    public partial class confirmAdd : Form
    {
        public confirmAdd()
        {
            InitializeComponent();
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;
        }

        public basicInfo baseInfo { set; get; }
        public List<famiAddr> famiDat { set; get; }
        public cominfo comDat { set; get; }

        public void reload()
        {
            //基本情報のデータ設定
            this.basName.Text = this.baseInfo.name;
            this.basNameRubi.Text = this.baseInfo.nameRubi;
            this.zipCode1.Text = this.baseInfo.zipCode.Substring(0, 3);
            this.zipCode2.Text = this.baseInfo.zipCode.Substring(3, 4);
            this.basAddr.Text = this.baseInfo.address;

            //家族情報のデータ設定

        }

        private void save1_Click(object sender, EventArgs e)
        {

        }
    }
}
