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
    public partial class tosen : Form
    {
        public tosen()
        {
            InitializeComponent();
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            this.ControlBox = !this.ControlBox;
        }

        private void pgEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void configDat_Click(object sender, EventArgs e)
        {
            //dataEdit de=new dataEdit();
            dataEditMenu de = new dataEditMenu();
            de.Show();
        }
    }
}
