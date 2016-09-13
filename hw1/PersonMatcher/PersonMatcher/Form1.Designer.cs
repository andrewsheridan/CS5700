namespace PersonMatcher
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.importButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.importResultsTextBox = new System.Windows.Forms.TextBox();
            this.matchResultsTextBox = new System.Windows.Forms.TextBox();
            this.personListLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JSON files (*.json)|*.json|XML (*.xml*)|*.xml*";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(12, 12);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(181, 40);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "Import from File";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Find Matches";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // importResultsTextBox
            // 
            this.importResultsTextBox.Location = new System.Drawing.Point(12, 83);
            this.importResultsTextBox.Multiline = true;
            this.importResultsTextBox.Name = "importResultsTextBox";
            this.importResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.importResultsTextBox.Size = new System.Drawing.Size(181, 229);
            this.importResultsTextBox.TabIndex = 2;
            // 
            // matchResultsTextBox
            // 
            this.matchResultsTextBox.Location = new System.Drawing.Point(199, 83);
            this.matchResultsTextBox.Multiline = true;
            this.matchResultsTextBox.Name = "matchResultsTextBox";
            this.matchResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.matchResultsTextBox.Size = new System.Drawing.Size(181, 229);
            this.matchResultsTextBox.TabIndex = 3;
            // 
            // personListLabel
            // 
            this.personListLabel.AutoSize = true;
            this.personListLabel.Location = new System.Drawing.Point(65, 67);
            this.personListLabel.Name = "personListLabel";
            this.personListLabel.Size = new System.Drawing.Size(74, 13);
            this.personListLabel.TabIndex = 4;
            this.personListLabel.Text = "Import Results";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Match Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.personListLabel);
            this.Controls.Add(this.matchResultsTextBox);
            this.Controls.Add(this.importResultsTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.importButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox importResultsTextBox;
        private System.Windows.Forms.TextBox matchResultsTextBox;
        private System.Windows.Forms.Label personListLabel;
        private System.Windows.Forms.Label label1;
    }
}

