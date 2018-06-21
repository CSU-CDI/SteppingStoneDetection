using System;
using System.IO;
using System.Windows.Forms;

namespace SteppingStoneCapture.Tools
{
    /// <summary>
    /// Form to encapsulate the .NET WebBrowser Control and allow loading html help files
    /// </summary>
    /// <remarks>
    ///     Assumes help html files are stored under the bin directory that the .exe
    ///     is stored in within a Resources directory.
    /// </remarks>
    public partial class HtmlHelpForm : Form
    {
        public HtmlHelpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for the Html Help Form 
        /// </summary>
        /// <param name="helpFilePath">
        /// The absolute path to the desired html file
        /// </param>
        public HtmlHelpForm(string helpFilePath)
        {
            InitializeComponent();// this is the line!!
            //Verify that a valid file path was entered
            if (File.Exists(helpFilePath) &&
                ((Path.GetExtension(helpFilePath) == ".html") || Path.GetExtension(helpFilePath) == ".htm"))
            {
                // Create a url based off the specified help file's location
                var url = new Uri(helpFilePath);
                // Direct the WebBrowser to path
                this.htmlWebBrowser.Navigate(url);
            }

            else
            {
                // show a message box with inputted file path if there was an error locating the file
                MessageBox.Show(String.Format("Error locating:\n {0,-20}", helpFilePath));
            }
        }

        /// <summary>
        /// Statically creates the proper path from the inputted file name
        /// <para/>
        ///     Assumes that files are stored in a Resources directory
        ///     under the bin directory the .exe file is stored in
        /// </summary>
        /// <param name="helpFileName">
        /// String containing the desired help html file name and extension: i.e. "example.html"
        /// </param>     
        public static void ShowHelp(string helpFileName)
        {
            // get the current directory the application is running in
            string curDir = System.IO.Directory.GetCurrentDirectory();

            // Create the Help form with the correctly formatted path
            string absolutePath = String.Format(@"{0}\Resources\{1}", curDir, helpFileName);
            Tools.HtmlHelpForm hhf = new Tools.HtmlHelpForm(absolutePath)
            {
                Text = "Help"
            };

            hhf.ShowDialog();
        }

        /// <summary>
        /// Statically creates the proper path from the inputted file name
        /// <para/>
        ///     Assumes that files are stored in a Resources directory
        ///     under the bin directory the .exe file is stored in
        /// </summary>
        /// <param name="helpFileName">
        /// String containing the desired help html file name and extension: i.e. "example.html"
        /// </param>
        /// <param name="titleName">
        /// String containing text for the title of the html help form
        /// </param>
        public static void ShowHelp(string helpFileName, string titleName)
        {
            // get the current directory the application is running in
            string curDir = System.IO.Directory.GetCurrentDirectory();

            // Create the Help form with the correctly formatted path
            string absolutePath = String.Format(@"{0}\Resources\{1}", curDir, helpFileName);
            Tools.HtmlHelpForm hhf = new Tools.HtmlHelpForm(absolutePath)
            {
                Text = titleName
            };

            hhf.ShowDialog();
        }
    }
}
