using System;
using System.Collections.Generic;
using System.IO;
using PersonMatcher.Matching;
using PersonMatcher.DataObjects;

namespace PersonMatcher.IO
{
    public class IDFileExportStrategy : ExportStrategy
    {
        private string _filePath = Environment.CurrentDirectory + "\\..\\..\\..\\..\\Exports\\";
        
        public string Export(string filename, List<Match> matches, List<Person> people)
        {
            string output = "";
            
            foreach(Match m in matches)
            {
                output += m.ToString() + Environment.NewLine;
            }
            filename = System.IO.Path.GetFileNameWithoutExtension(filename);
            StreamWriter writer = new StreamWriter(_filePath + filename + "_ID_Export.txt");
            writer.Write(output);
            writer.Close();

            return output;
        }
    }
}
