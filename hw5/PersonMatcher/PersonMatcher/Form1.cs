using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using PersonMatcher.IO;
using PersonMatcher.Matching;

namespace PersonMatcher
{
    public partial class Form1 : Form
    {
        private string filename;
        MatchStrategyEnum matchStrategy;
        ExportStrategyEnum exportStrategy;
        public Form1()
        {
            InitializeComponent();
            matchStrategyComboBox.DataSource = Enum.GetValues(typeof(MatchStrategyEnum));
            exportStrategyComboBox.DataSource = Enum.GetValues(typeof(ExportStrategyEnum));
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                selectedFileTextBox.Text = filename;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(matchStrategyComboBox.SelectedValue.ToString(), out matchStrategy);
        }



        private void findMatchesButton_Click(object sender, EventArgs e)
        {
            PersonMatcher personMatcher = new PersonMatcher(filename, matchStrategy, exportStrategy);
            matchResultsTextBox.Text = personMatcher.Run();
        }

        private void exportStrategyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(exportStrategyComboBox.SelectedValue.ToString(), out exportStrategy);
        }
    }
}
