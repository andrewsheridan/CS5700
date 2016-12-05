using PersonMatcher.DataObjects;
using PersonMatcher.Matching;
using System.Collections.Generic;

namespace PersonMatcher.IO
{
    public interface ExportStrategy
    {
        string Export (string filename, List<Match> matches, List<Person> people);
    }
}
