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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.incEBox = new System.Windows.Forms.TextBox();
            this.incSBox = new System.Windows.Forms.TextBox();
            this.outEBox = new System.Windows.Forms.TextBox();
            this.outSBox = new System.Windows.Forms.TextBox();
            this.numericThres = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.incEButton = new System.Windows.Forms.Button();
            this.incSButton = new System.Windows.Forms.Button();
            this.outEButton = new System.Windows.Forms.Button();
            this.outSButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.inRTTLabel = new System.Windows.Forms.Label();
            this.outRTTLabel = new System.Windows.Forms.Label();
            this.diffRTTLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericThres)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Incoming Echo File";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Incoming Send File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Outgoing Echo File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Outgoing Send File";
            // 
            // incEBox
            // 
            this.incEBox.Location = new System.Drawing.Point(16, 80);
            this.incEBox.Name = "incEBox";
            this.incEBox.ReadOnly = true;
            this.incEBox.Size = new System.Drawing.Size(195, 20);
            this.incEBox.TabIndex = 4;
            this.incEBox.TextChanged += new System.EventHandler(this.incEBox_TextChanged);
            // 
            // incSBox
            // 
            this.incSBox.Location = new System.Drawing.Point(16, 138);
            this.incSBox.Name = "incSBox";
            this.incSBox.ReadOnly = true;
            this.incSBox.Size = new System.Drawing.Size(195, 20);
            this.incSBox.TabIndex = 5;
            this.incSBox.TextChanged += new System.EventHandler(this.incSBox_TextChanged);
            // 
            // outEBox
            // 
            this.outEBox.Location = new System.Drawing.Point(16, 198);
            this.outEBox.Name = "outEBox";
            this.outEBox.ReadOnly = true;
            this.outEBox.Size = new System.Drawing.Size(195, 20);
            this.outEBox.TabIndex = 6;
            this.outEBox.TextChanged += new System.EventHandler(this.outEBox_TextChanged);
            // 
            // outSBox
            // 
            this.outSBox.Location = new System.Drawing.Point(16, 260);
            this.outSBox.Name = "outSBox";
            this.outSBox.ReadOnly = true;
            this.outSBox.Size = new System.Drawing.Size(195, 20);
            this.outSBox.TabIndex = 7;
            this.outSBox.TextChanged += new System.EventHandler(this.outSBox_TextChanged);
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
            // incEButton
            // 
            this.incEButton.Location = new System.Drawing.Point(226, 78);
            this.incEButton.Name = "incEButton";
            this.incEButton.Size = new System.Drawing.Size(75, 23);
            this.incEButton.TabIndex = 31;
            this.incEButton.Text = "Browse...";
            this.incEButton.UseVisualStyleBackColor = true;
            this.incEButton.Click += new System.EventHandler(this.incEButton_Click);
            // 
            // incSButton
            // 
            this.incSButton.Enabled = false;
            this.incSButton.Location = new System.Drawing.Point(226, 135);
            this.incSButton.Name = "incSButton";
            this.incSButton.Size = new System.Drawing.Size(75, 23);
            this.incSButton.TabIndex = 32;
            this.incSButton.Text = "Browse...";
            this.incSButton.UseVisualStyleBackColor = true;
            this.incSButton.Click += new System.EventHandler(this.incSButton_Click);
            // 
            // outEButton
            // 
            this.outEButton.Enabled = false;
            this.outEButton.Location = new System.Drawing.Point(226, 198);
            this.outEButton.Name = "outEButton";
            this.outEButton.Size = new System.Drawing.Size(75, 23);
            this.outEButton.TabIndex = 33;
            this.outEButton.Text = "Browse...";
            this.outEButton.UseVisualStyleBackColor = true;
            this.outEButton.Click += new System.EventHandler(this.outEButton_Click);
            // 
            // outSButton
            // 
            this.outSButton.Enabled = false;
            this.outSButton.Location = new System.Drawing.Point(226, 257);
            this.outSButton.Name = "outSButton";
            this.outSButton.Size = new System.Drawing.Size(75, 23);
            this.outSButton.TabIndex = 34;
            this.outSButton.Text = "Browse...";
            this.outSButton.UseVisualStyleBackColor = true;
            this.outSButton.Click += new System.EventHandler(this.outSButton_Click);
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
            // RandomWalk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 326);
            this.Controls.Add(this.diffRTTLabel);
            this.Controls.Add(this.outRTTLabel);
            this.Controls.Add(this.inRTTLabel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.outSButton);
            this.Controls.Add(this.outEButton);
            this.Controls.Add(this.incSButton);
            this.Controls.Add(this.incEButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericThres);
            this.Controls.Add(this.outSBox);
            this.Controls.Add(this.outEBox);
            this.Controls.Add(this.incSBox);
            this.Controls.Add(this.incEBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RandomWalk";
            this.Text = "RandomWalk";
            ((System.ComponentModel.ISupportInitialize)(this.numericThres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox incEBox;
        private System.Windows.Forms.TextBox incSBox;
        private System.Windows.Forms.TextBox outEBox;
        private System.Windows.Forms.TextBox outSBox;
        private System.Windows.Forms.NumericUpDown numericThres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button incEButton;
        private System.Windows.Forms.Button incSButton;
        private System.Windows.Forms.Button outEButton;
        private System.Windows.Forms.Button outSButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label inRTTLabel;
        private System.Windows.Forms.Label outRTTLabel;
        private System.Windows.Forms.Label diffRTTLabel;
    }
}