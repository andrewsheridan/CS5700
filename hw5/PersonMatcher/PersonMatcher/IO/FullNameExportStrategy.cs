using System;
using System.Collections.Generic;
using PersonMatcher.DataObjects;
using PersonMatcher.Matching;
using System.IO;

namespace PersonMatcher.IO
{
    public class FullNameExportStrategy : ExportStrategy
    {
        public override string Export(string filename, List<Match> matches, List<Person> people)
        {
            string output = "";

            foreach (Match m in matches)
            {
                Person a = people.Find(x => x.ObjectId == m.ObjectId1);
                Person b = people.Find(y => y.ObjectId == m.ObjectId2);
                output += a.FirstName.PadRight(20);
                if (a.MiddleName != null)
                    output += a.MiddleName.PadRight(20);
                output += a.LastName.PadRight(20);

                output += " | ";

                output += b.FirstName.PadRight(20);
                if (b.MiddleName != null)
                    output += b.MiddleName.PadRight(20);
                output += b.LastName.PadRight(20);

                output += Environment.NewLine;
            }

            StreamWriter writer = new StreamWriter(_filePath + filename + "_FullName_Export.txt");
            writer.Write(output);
            writer.Close();

            return output;
        }
    }
}
