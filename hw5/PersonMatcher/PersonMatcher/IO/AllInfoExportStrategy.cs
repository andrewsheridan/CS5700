using System;
using System.Collections.Generic;
using System.Linq;
using PersonMatcher.DataObjects;
using PersonMatcher.Matching;
using System.IO;

namespace PersonMatcher.IO
{
    public class AllInfoExportStrategy : ExportStrategy
    {
        public override string Export(string filename, List<Match> matches, List<Person> people)
        {
            string output = "";

            foreach (Match m in matches)
            {
                Person a = people.Find(x => x.ObjectId == m.ObjectId1);
                Person b = people.Find(y => y.ObjectId == m.ObjectId2);

                var list1 = a.GetType().GetProperties().OrderBy(x => x.Name).Select(x => x.Name);
                var list2 = b.GetType().GetProperties().OrderBy(x => x.Name).Select(x => x.Name);
                
                foreach(var item in list1)
                {
                    output += (item + ": ").PadRight(50);
                    output += (a.GetType().GetProperty(item).GetValue(a) + " ").PadRight(50);
                    output += (b.GetType().GetProperty(item).GetValue(b) + " ").PadRight(50);
                    output += Environment.NewLine;
                }
                output += "------------------------------------" + Environment.NewLine;
            }

            StreamWriter writer = new StreamWriter(_filePath + filename + "_FullName_Export.txt");
            writer.Write(output);
            writer.Close();

            return output;
        }
    }
}
