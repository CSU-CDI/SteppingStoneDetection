namespace SteppingStoneCapture.Analysis.TimeThumbprint
{
    partial class SessionTimeThumbprint
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
            this.Incominglabel = new System.Windows.Forms.Label();
            this.incomingBox = new System.Windows.Forms.TextBox();
            this.Outgoinglabel = new System.Windows.Forms.Label();
            this.outgoingBox = new System.Windows.Forms.TextBox();
            this.matchLabel = new System.Windows.Forms.Label();
            this.matchBox = new System.Windows.Forms.TextBox();
            this.similLabel = new System.Windows.Forms.Label();
            this.similarityBox = new System.Windows.Forms.TextBox();
            this.incButton = new System.Windows.Forms.Button();
            this.outButton = new System.Windows.Forms.Button();
            this.compButton = new System.Windows.Forms.Button();
            this.isLabel = new System.Windows.Forms.Label();
            this.osLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Incominglabel
            // 
            this.Incominglabel.AutoSize = true;
            this.Incominglabel.Location = new System.Drawing.Point(31, 98);
            this.Incominglabel.Name = "Incominglabel";
            this.Incominglabel.Size = new System.Drawing.Size(72, 13);
            this.Incominglabel.TabIndex = 0;
            this.Incominglabel.Text = "Incoming File:";
            // 
            // incomingBox
            // 
            this.incomingBox.Location = new System.Drawing.Point(109, 98);
            this.incomingBox.Name = "incomingBox";
            this.incomingBox.Size = new System.Drawing.Size(286, 20);
            this.incomingBox.TabIndex = 1;
            // 
            // Outgoinglabel
            // 
            this.Outgoinglabel.AutoSize = true;
            this.Outgoinglabel.Location = new System.Drawing.Point(31, 148);
            this.Outgoinglabel.Name = "Outgoinglabel";
            this.Outgoinglabel.Size = new System.Drawing.Size(72, 13);
            this.Outgoinglabel.TabIndex = 2;
            this.Outgoinglabel.Text = "Outgoing File:";
            // 
            // outgoingBox
            // 
            this.outgoingBox.Location = new System.Drawing.Point(109, 148);
            this.outgoingBox.Name = "outgoingBox";
            this.outgoingBox.Size = new System.Drawing.Size(286, 20);
            this.outgoingBox.TabIndex = 3;
            // 
            // matchLabel
            // 
            this.matchLabel.AutoSize = true;
            this.matchLabel.Location = new System.Drawing.Point(34, 220);
            this.matchLabel.Name = "matchLabel";
            this.matchLabel.Size = new System.Drawing.Size(90, 13);
            this.matchLabel.TabIndex = 4;
            this.matchLabel.Text = "Match Threshold:";
            // 
            // matchBox
            // 
            this.matchBox.Location = new System.Drawing.Point(130, 220);
            this.matchBox.Name = "matchBox";
            this.matchBox.Size = new System.Drawing.Size(100, 20);
            this.matchBox.TabIndex = 5;
            // 
            // similLabel
            // 
            this.similLabel.AutoSize = true;
            this.similLabel.Location = new System.Drawing.Point(37, 267);
            this.similLabel.Name = "similLabel";
            this.similLabel.Size = new System.Drawing.Size(100, 13);
            this.similLabel.TabIndex = 6;
            this.similLabel.Text = "Similarity Threshold:";
            // 
            // similarityBox
            // 
            this.similarityBox.Location = new System.Drawing.Point(144, 267);
            this.similarityBox.Name = "similarityBox";
            this.similarityBox.Size = new System.Drawing.Size(100, 20);
            this.similarityBox.TabIndex = 7;
            // 
            // incButton
            // 
            this.incButton.Location = new System.Drawing.Point(401, 98);
            this.incButton.Name = "incButton";
            this.incButton.Size = new System.Drawing.Size(75, 23);
            this.incButton.TabIndex = 8;
            this.incButton.Text = "Browse...";
            this.incButton.UseVisualStyleBackColor = true;
            this.incButton.Click += new System.EventHandler(this.incButton_Click);
            // 
            // outButton
            // 
            this.outButton.Location = new System.Drawing.Point(401, 146);
            this.outButton.Name = "outButton";
            this.outButton.Size = new System.Drawing.Size(75, 23);
            this.outButton.TabIndex = 9;
            this.outButton.Text = "Broswe...";
            this.outButton.UseVisualStyleBackColor = true;
            this.outButton.Click += new System.EventHandler(this.outButton_Click);
            // 
            // compButton
            // 
            this.compButton.Location = new System.Drawing.Point(595, 125);
            this.compButton.Name = "compButton";
            this.compButton.Size = new System.Drawing.Size(75, 23);
            this.compButton.TabIndex = 10;
            this.compButton.Text = "Compare";
            this.compButton.UseVisualStyleBackColor = true;
            this.compButton.Click += new System.EventHandler(this.compButton_Click);
            // 
            // isLabel
            // 
            this.isLabel.AutoSize = true;
            this.isLabel.Location = new System.Drawing.Point(34, 309);
            this.isLabel.Name = "isLabel";
            this.isLabel.Size = new System.Drawing.Size(108, 13);
            this.isLabel.TabIndex = 11;
            this.isLabel.Text = "Incoming Sequence: ";
            // 
            // osLabel
            // 
            this.osLabel.AutoSize = true;
            this.osLabel.Location = new System.Drawing.Point(34, 349);
            this.osLabel.Name = "osLabel";
            this.osLabel.Size = new System.Drawing.Size(108, 13);
            this.osLabel.TabIndex = 12;
            this.osLabel.Text = "Outgoing Sequence: ";
            // 
            // SessionTimeThumbprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 414);
            this.Controls.Add(this.osLabel);
            this.Controls.Add(this.isLabel);
            this.Controls.Add(this.compButton);
            this.Controls.Add(this.outButton);
            this.Controls.Add(this.incButton);
            this.Controls.Add(this.similarityBox);
            this.Controls.Add(this.similLabel);
            this.Controls.Add(this.matchBox);
            this.Controls.Add(this.matchLabel);
            this.Controls.Add(this.outgoingBox);
            this.Controls.Add(this.Outgoinglabel);
            this.Controls.Add(this.incomingBox);
            this.Controls.Add(this.Incominglabel);
            this.Name = "SessionTimeThumbprint";
            this.Text = "Session-Time Thumbprint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Incominglabel;
        private System.Windows.Forms.TextBox incomingBox;
        private System.Windows.Forms.Label Outgoinglabel;
        private System.Windows.Forms.TextBox outgoingBox;
        private System.Windows.Forms.Label matchLabel;
        private System.Windows.Forms.TextBox matchBox;
        private System.Windows.Forms.Label similLabel;
        private System.Windows.Forms.TextBox similarityBox;
        private System.Windows.Forms.Button incButton;
        private System.Windows.Forms.Button outButton;
        private System.Windows.Forms.Button compButton;
        private System.Windows.Forms.Label isLabel;
        private System.Windows.Forms.Label osLabel;
    }
}