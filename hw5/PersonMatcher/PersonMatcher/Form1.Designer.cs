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
            this.matchResultsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.matchStrategyComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.exportStrategyComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.selectedFileTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "All files(*.*)|*.*|JSON files (*.json)|*.json|XML (*.xml)|*.xml";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(12, 28);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(198, 40);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "Import File";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // matchResultsTextBox
            // 
            this.matchResultsTextBox.Location = new System.Drawing.Point(216, 28);
            this.matchResultsTextBox.Multiline = true;
            this.matchResultsTextBox.Name = "matchResultsTextBox";
            this.matchResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.matchResultsTextBox.Size = new System.Drawing.Size(372, 279);
            this.matchResultsTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Match Results";
            // 
            // matchStrategyComboBox
            // 
            this.matchStrategyComboBox.FormattingEnabled = true;
            this.matchStrategyComboBox.Items.AddRange(new object[] {
            "Birth Info",
            "Contact Info",
            "Full Name",
            "Government Info"});
            this.matchStrategyComboBox.Location = new System.Drawing.Point(12, 169);
            this.matchStrategyComboBox.Name = "matchStrategyComboBox";
            this.matchStrategyComboBox.Size = new System.Drawing.Size(198, 21);
            this.matchStrategyComboBox.TabIndex = 6;
            this.matchStrategyComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Matching Strategy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select Import File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Selected File:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Export Strategy";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(12, 267);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(198, 40);
            this.runButton.TabIndex = 13;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.findMatchesButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text File (*.txt)|*.txt";
            // 
            // exportStrategyComboBox
            // 
            this.exportStrategyComboBox.FormattingEnabled = true;
            this.exportStrategyComboBox.Items.AddRange(new object[] {
            "Output IDs",
            "Output All Information"});
            this.exportStrategyComboBox.Location = new System.Drawing.Point(12, 219);
            this.exportStrategyComboBox.Name = "exportStrategyComboBox";
            this.exportStrategyComboBox.Size = new System.Drawing.Size(198, 21);
            this.exportStrategyComboBox.TabIndex = 14;
            this.exportStrategyComboBox.SelectedIndexChanged += new System.EventHandler(this.exportStrategyComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Step 4: Run Person Matcher";
            // 
            // selectedFileTextBox
            // 
            this.selectedFileTextBox.Location = new System.Drawing.Point(12, 96);
            this.selectedFileTextBox.Multiline = true;
            this.selectedFileTextBox.Name = "selectedFileTextBox";
            this.selectedFileTextBox.ReadOnly = true;
            this.selectedFileTextBox.Size = new System.Drawing.Size(198, 54);
            this.selectedFileTextBox.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 318);
            this.Controls.Add(this.selectedFileTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.exportStrategyComboBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.matchStrategyComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.matchResultsTextBox);
            this.Controls.Add(this.importButton);
            this.Name = "Form1";
            this.Text = "Person Matcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.TextBox matchResultsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox matchStrategyComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox exportStrategyComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox selectedFileTextBox;
    }
}

