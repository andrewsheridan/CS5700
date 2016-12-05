using PersonMatcher.DataObjects;
using PersonMatcher.Matching;
using System.Collections.Generic;

namespace PersonMatcher.IO
{
    public abstract class ExportStrategy
    {
        protected string _filePath = "..\\..\\..\\..\\Exports\\";
        public abstract string Export (string filename, List<Match> matches, List<Person> people);
    }
}
