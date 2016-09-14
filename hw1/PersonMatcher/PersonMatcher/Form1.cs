using System;
using System.Windows.Forms;
using System.Collections.Generic;
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
                    List<Person> personList = personMatcher.Import(openFileDialog1.FileName);
                }
                else if(openFileDialog1.FileName.Contains(".json"))
                {
                    personMatcher.StorageStrategy = new JsonImportExportStrategy();
                    List<Person> personList = personMatcher.Import(openFileDialog1.FileName);
                }
            }
            else
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
