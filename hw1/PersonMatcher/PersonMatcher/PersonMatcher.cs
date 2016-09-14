using PersonMatcher.IO;
using PersonMatcher.Matching;
using System.Collections.Generic;

namespace PersonMatcher
{
    public class PersonMatcher
    {
        //private PersonSet personSet;
        private List<Person> personList;
        public ImportExportStrategy StorageStrategy { get; set; }

        public MatchStrategy Matcher { get; set; }

        public PersonMatcher()
        {
            Matcher = new FullNameMatchStrategy();
        }

        public List<Person> Import(string inputFileName)
        {
            personList = StorageStrategy.Import(inputFileName);
            Run();
            return personList;
        }

        public List<Match> Run()
        {
            int personCount = personList.Count;
            List<Match> matchList = new List<Match>();
            
            for (int i = 0; i < personCount; i++)
            {
                for(int j = i + 1; j < personCount; j++)
                {
                    if(Matcher.Match(personList[i], personList[j]))
                    {
                        matchList.Add(new Match(personList[i].ObjectId, personList[j].ObjectId));
                    }
                }
            }

            return matchList;
        }
    }
}
