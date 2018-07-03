namespace SteppingStoneCapture.Analysis.RandomWalkDetection
{
    partial class RandomWalk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericThres = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.inRTTLabel = new System.Windows.Forms.Label();
            this.outRTTLabel = new System.Windows.Forms.Label();
            this.diffRTTLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.incBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.outBox = new System.Windows.Forms.TextBox();
            this.incButton = new System.Windows.Forms.Button();
            this.outButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericThres)).BeginInit();
            this.SuspendLayout();
            // 
            // numericThres
            // 
            this.numericThres.Location = new System.Drawing.Point(16, 305);
            this.numericThres.Margin = new System.Windows.Forms.Padding(2);
            this.numericThres.Name = "numericThres";
            this.numericThres.ReadOnly = true;
            this.numericThres.Size = new System.Drawing.Size(90, 20);
            this.numericThres.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 290);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Threshold:";
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.Location = new System.Drawing.Point(554, 41);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 35;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // inRTTLabel
            // 
            this.inRTTLabel.AutoSize = true;
            this.inRTTLabel.Location = new System.Drawing.Point(367, 170);
            this.inRTTLabel.Name = "inRTTLabel";
            this.inRTTLabel.Size = new System.Drawing.Size(137, 13);
            this.inRTTLabel.TabIndex = 36;
            this.inRTTLabel.Text = "Number of incoming RTTs: ";
            // 
            // outRTTLabel
            // 
            this.outRTTLabel.AutoSize = true;
            this.outRTTLabel.Location = new System.Drawing.Point(367, 205);
            this.outRTTLabel.Name = "outRTTLabel";
            this.outRTTLabel.Size = new System.Drawing.Size(136, 13);
            this.outRTTLabel.TabIndex = 37;
            this.outRTTLabel.Text = "Number of outgoing RTTs: ";
            // 
            // diffRTTLabel
            // 
            this.diffRTTLabel.AutoSize = true;
            this.diffRTTLabel.Location = new System.Drawing.Point(367, 230);
            this.diffRTTLabel.Name = "diffRTTLabel";
            this.diffRTTLabel.Size = new System.Drawing.Size(92, 13);
            this.diffRTTLabel.TabIndex = 38;
            this.diffRTTLabel.Text = "Difference RTTs: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Incoming Connection File:";
            // 
            // incBox
            // 
            this.incBox.Location = new System.Drawing.Point(16, 145);
            this.incBox.Name = "incBox";
            this.incBox.ReadOnly = true;
            this.incBox.Size = new System.Drawing.Size(215, 20);
            this.incBox.TabIndex = 40;
            this.incBox.TextChanged += new System.EventHandler(this.incBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Outgoing Connection File:";
            // 
            // outBox
            // 
            this.outBox.Location = new System.Drawing.Point(16, 241);
            this.outBox.Name = "outBox";
            this.outBox.ReadOnly = true;
            this.outBox.Size = new System.Drawing.Size(215, 20);
            this.outBox.TabIndex = 42;
            this.outBox.TextChanged += new System.EventHandler(this.outBox_TextChanged);
            // 
            // incButton
            // 
            this.incButton.Location = new System.Drawing.Point(237, 145);
            this.incButton.Name = "incButton";
            this.incButton.Size = new System.Drawing.Size(75, 23);
            this.incButton.TabIndex = 43;
            this.incButton.Text = "Browse...";
            this.incButton.UseVisualStyleBackColor = true;
            this.incButton.Click += new System.EventHandler(this.incButton_Click);
            // 
            // outButton
            // 
            this.outButton.Enabled = false;
            this.outButton.Location = new System.Drawing.Point(237, 241);
            this.outButton.Name = "outButton";
            this.outButton.Size = new System.Drawing.Size(75, 23);
            this.outButton.TabIndex = 44;
            this.outButton.Text = "Browse...";
            this.outButton.UseVisualStyleBackColor = true;
            this.outButton.Click += new System.EventHandler(this.outButton_Click);
            // 
            // RandomWalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 326);
            this.Controls.Add(this.outButton);
            this.Controls.Add(this.incButton);
            this.Controls.Add(this.outBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.incBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diffRTTLabel);
            this.Controls.Add(this.outRTTLabel);
            this.Controls.Add(this.inRTTLabel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericThres);
            this.Name = "RandomWalk";
            this.Text = "RandomWalk";
            ((System.ComponentModel.ISupportInitialize)(this.numericThres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericThres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label inRTTLabel;
        private System.Windows.Forms.Label outRTTLabel;
        private System.Windows.Forms.Label diffRTTLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox incBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outBox;
        private System.Windows.Forms.Button incButton;
        private System.Windows.Forms.Button outButton;
    }
}