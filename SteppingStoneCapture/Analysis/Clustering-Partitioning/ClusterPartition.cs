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
    public partial class ClusterPartition : Form
    {
        private const int CheckNum = 5;
        private const int CNum = 5;
        private const int MaxSend = 1024;
        private const double epsilon = 0.01;



        private class Echo_Set
        {
            float gap;
            Echo_Set next_e;
            int sn;
            int en;

            private Echo_Set(float gap = 0, Echo_Set next_e = null, int sn = 0, int en = 0)
            {
                this.gap = gap;
                this.next_e = next_e;
                this.sn = sn;
                this.en = en;
            }
        }


        private class X_Set
        {
            float gap;
            X_Set next_e;
            int sn;
            int en;
            private X_Set(float gap = 0, X_Set next_e = null, int sn = 0, int en = 0)
            {
                this.gap = gap;
                this.next_e = next_e;
                this.sn = sn;
                this.en = en;
            }
        }

        private class C_Cluster
        {
            X_Set next_x;
            X_Set X_t;
            C_Cluster next_c;
            float ratio;
            float center;

            private C_Cluster(X_Set next_x = null, X_Set X_t = null, C_Cluster next_c = null, float ratio = 0, float center = 0)
            {
                this.next_x = next_x;
                this.X_t = X_t;
                this.next_c = next_c;
                this.ratio = ratio;
                this.center = center;
            }
        }


        private class Send_Set
        {
            Echo_Set next;
            Send_Set next_s;

            private Send_Set(Echo_Set next = null, Send_Set next_s = null)
            {
                this.next = next;
                this.next_s = next_s;
            }
        }


        private class Sort_Gap
        {
            float gap;
            int sn;
            int en;
            Sort_Gap next;

            private Sort_Gap(float gap = 0, int sn = 0, int en = 0, Sort_Gap next = null)
            {
                this.gap = gap;
                this.sn = sn;
                this.en = en;
                this.next = next;
            }
        }


        private class Rtt_Echo
        {
            float gap;
            int sn;
            int en;
            Rtt_Echo next_e;

            private Rtt_Echo(float gap = 0, int sn = 0, int en = 0, Rtt_Echo next_e = null)
            {
                this.gap = gap;
                this.sn = sn;
                this.en = en;
                this.next_e = next_e;
            }
        }

        private class Rtt_Send
        {
            Rtt_Echo next;
            Rtt_Send next_s;
            float ave;
            float std;

            private Rtt_Send(Rtt_Echo next = null, Rtt_Send next_s = null, float ave = 0, float std = 0)
            {
                this.next = next;
                this.next_s = next_s;
                this.ave = ave;
                this.std = std;
            }
        }


        private class Cluster_Data
        {
            float gap;
            int sn;
            int en;
            Cluster_Data next_d;

            private Cluster_Data(float gap = 0, int sn = 0, int en = 0, Cluster_Data next_d = null)
            {
                this.gap = gap;
                this.sn = sn;
                this.en = en;
                this.next_d = next_d;
            }
        }


        private class Cluster_Set
        {
            Cluster_Data next_d;
            float ave;
            int num;
            int n;
            Cluster_Set next_c;

            private Cluster_Set(Cluster_Data next_d = null, float ave = 0, int num = 0, int n = 0, Cluster_Set next_c = null)
            {
                this.next_d = next_d;
                this.ave = ave;
                this.num = num;
                this.n = n;
                this.next_c = next_c;
            }
        }







        public ClusterPartition()
        {
            InitializeComponent();
            Visible = true;
            btnOk.Enabled = false;
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Cancel?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
                        
        }
    }
}
