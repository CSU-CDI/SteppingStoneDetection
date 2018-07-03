using System;
using System.Windows.Forms;

namespace SteppingStoneCapture.Tools
{
    public partial class TextInput : Form
    {
        private string inputtedText;
        public TextInput(string val)
        {
            InitializeComponent();
            inputtedText = val;
            NumPacketBox.Text = inputtedText.ToString();
            
        }

        public string InputtedText { get => inputtedText; set => inputtedText = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            InputtedText = NumPacketBox.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
