using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace SteppingStoneCapture
{
    public partial class IOConnection : Form
    {
        public IOConnection()
        {
            InitializeComponent();
            txtIpOne.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }
        
    }
}
