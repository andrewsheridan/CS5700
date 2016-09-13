using System;
using System.Windows.Forms;
using PersonMatcher.IO;

namespace PersonMatcher
{
    public partial class Form1 : Form
    {
        private PersonMatcher personMatcher = new PersonMatcher();
        public Form1()
        {
            InitializeComponent();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Contains(".xml"))
                {
                    personMatcher.StorageStrategy = new XmlImportExportStrategy();
                    importResultsTextBox.Text = personMatcher.Import(openFileDialog1.FileName).ToString();
                }
                //else
                //{
                //    personMatcher.StorageStrategy = new JsonImportExportStrategy();
                //    personMatcher.Import(openFileDialog1.FileName);
                //}
            }
            else
            {

            }
        }
    }
}
