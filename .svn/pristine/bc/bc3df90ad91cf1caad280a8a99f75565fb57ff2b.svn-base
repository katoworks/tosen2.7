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
    public partial class grpAddChg : Form
    {
        public grpAddChg()
        {
            InitializeComponent();

            // inithalize
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;

            this.grpList.DropDownStyle = ComboBoxStyle.DropDownList;
            ba = new baseAddrDAO();
            dbClass db = new dbClass();
            List<string> iList = new List<string>();
            iList = db.getKindList();
            foreach (string item in iList)
            {
                this.grpList.Items.Add(item);
            }
            this.grpList.SelectedIndex = 0;
        }

        private baseAddrDAO ba;

        private void canBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addGrpBtn_Click(object sender, EventArgs e)
        {
            if (this.addGrpName.Text == "")
            {
                DialogResult result = MessageBox.Show("ファイルを上書きしますか？", "質問", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            }
        }
    }
}
