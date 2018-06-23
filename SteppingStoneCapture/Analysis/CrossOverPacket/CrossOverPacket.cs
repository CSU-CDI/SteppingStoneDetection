using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteppingStoneCapture.Analysis
{
    public partial class CrossOverPacket : Form
    {
        public CrossOverPacket()
        {
            InitializeComponent();
            Visible = true;
            btnOk.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Cancel?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {

        }
    }
}
