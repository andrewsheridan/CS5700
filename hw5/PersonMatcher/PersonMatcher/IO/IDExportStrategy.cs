using System;
using System.Collections.Generic;
using System.IO;
using PersonMatcher.Matching;
using PersonMatcher.DataObjects;

namespace PersonMatcher.IO
{
    public class IDExportStrategy : ExportStrategy
    {
        public override string Export(string filename, List<Match> matches, List<Person> people)
        {
            string output = "";

            foreach (Match m in matches)
            {
                output += m.ToString() + Environment.NewLine;
            }
            
            StreamWriter writer = new StreamWriter(_filePath + filename + "_ID_Export.txt");
            writer.Write(output);
            writer.Close();

            return output;
        }
    }
}
