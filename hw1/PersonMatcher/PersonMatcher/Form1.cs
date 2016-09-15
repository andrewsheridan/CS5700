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
        private PersonMatcher personMatcher = new PersonMatcher();
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(MatchStrategyEnum));
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Contains(".xml"))
                {
                    personMatcher.StorageStrategy = new XmlImportExportStrategy();
                    personMatcher.Import(openFileDialog1.FileName);
                    currentFileLabel.Text = openFileDialog1.SafeFileName;
                }
                else if(openFileDialog1.FileName.Contains(".json"))
                {
                    personMatcher.StorageStrategy = new JsonImportExportStrategy();
                    personMatcher.Import(openFileDialog1.FileName);
                    currentFileLabel.Text = openFileDialog1.SafeFileName;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatchStrategyEnum strategy;
            Enum.TryParse(comboBox1.SelectedValue.ToString(), out strategy);
            personMatcher.setMatchStrategyByEnum(strategy);
        }



        private void findMatchesButton_Click(object sender, EventArgs e)
        {
            matchResultsTextBox.Text = personMatcher.GetMatchesAsString();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(saveFileDialog1.FileName != "")
                {
                    StreamWriter file = new StreamWriter(saveFileDialog1.FileName);
                    file.Write(matchResultsTextBox.Text);
                    file.Close();
                }
            }
        }
    }
}
