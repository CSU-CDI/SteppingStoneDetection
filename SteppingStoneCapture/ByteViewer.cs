using System;
using System.Drawing;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace SteppingStoneCapture
{
    public class ByteViewerForm : System.Windows.Forms.Form
    {
        private ByteViewer byteviewer;
        public CougarPacket cp;

        public ByteViewerForm()
        {
            // Initialize the controls other than the ByteViewer.
            InitializeForm();
            // Initialize the ByteViewer.
            byteviewer = new ByteViewer();
            byteviewer.Location = new Point(8, 46);
            byteviewer.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top ;
            byteviewer.SetBytes(new byte[] { });
            this.Controls.Add(byteviewer);
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        // Show a file selection dialog and cues the byte viewer to 
        // load the data in a selected file.
        private void loadBytesFromFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            byteviewer.SetFile(ofd.FileName);
        }

        // Clear the bytes in the byte viewer.
        private void clearBytes(object sender, EventArgs e)
        {
            byteviewer.SetBytes(new byte[] { });
        }

        public void setBytes(byte[] arr)
        {
            byteviewer.SetBytes(arr);
        }

        // Changes the display mode of the byte viewer according to the 
        // Text property of the RadioButton sender control.
        private void changeByteMode(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton rbutton =
                (System.Windows.Forms.RadioButton)sender;

            DisplayMode mode;
            switch (rbutton.Text)
            {
                case "ANSI":
                    mode = DisplayMode.Ansi;
                    break;
                default:
                    mode = DisplayMode.Hexdump;
                    break;
            }

            // Sets the display mode.
            byteviewer.SetDisplayMode(mode);
        }

        private void InitializeForm()
        {
            this.SuspendLayout();
            this.MinimumSize = new System.Drawing.Size(660, 400);
            this.Name = "Packet Detail";
            this.Text = "Packet Detail";

            System.Windows.Forms.GroupBox group = new System.Windows.Forms.GroupBox();
            group.Location = new Point(418, 3);
            group.Size = new Size(220, 36);
            group.Text = "Display Mode";
            this.Controls.Add(group);

            System.Windows.Forms.RadioButton rbutton2 = new System.Windows.Forms.RadioButton();
            rbutton2.Location = new Point(54, 15);
            rbutton2.Size = new Size(50, 16);
            rbutton2.Text = "ANSI";
            rbutton2.Click += new EventHandler(this.changeByteMode);
            group.Controls.Add(rbutton2);

            System.Windows.Forms.RadioButton rbutton3 = new System.Windows.Forms.RadioButton();
            rbutton3.Location = new Point(106, 15);
            rbutton3.Size = new Size(46, 16);
            rbutton3.Text = "Hex";
            rbutton3.Click += new EventHandler(this.changeByteMode);
            rbutton3.Checked = true;
            group.Controls.Add(rbutton3);
        }

        private void InitializeComponent()
        {
          //  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ByteViewerForm));
            //this.SuspendLayout();
            // 
            // ByteViewerForm
            // 
            this.Name = "Packet Detail";
            this.Load += new System.EventHandler(this.ByteViewerForm_Load);
            this.ResumeLayout(false);

        }

        private void ByteViewerForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}