using PersonMatcher.IO;
using PersonMatcher.Matching;
using PersonMatcher.DataObjects;
using System.Collections.Generic;
using System;

namespace PersonMatcher
{
    public enum MatchStrategyEnum { BirthInfo, ContactInfo, FullName, GovernmentInfo };
    public class PersonMatcher
    {
        //private PersonSet personSet;
        private List<Person> personList;
        public ImportExportStrategy StorageStrategy { get; set; }
        
        public MatchStrategy Matcher { get; set; }

        public PersonMatcher()
        {
            Matcher = new FullNameMatchStrategy();
            personList = new List<Person>();
        }

        public void setMatchStrategyByEnum(MatchStrategyEnum strategy)
        {
            switch (strategy)
            {
                case MatchStrategyEnum.BirthInfo:
                    Matcher = new BirthInfoMatchStrategy();
                    break;
                case MatchStrategyEnum.ContactInfo:
                    Matcher = new ContactInfoMatchStrategy();
                    break;
                case MatchStrategyEnum.FullName:
                    Matcher = new FullNameMatchStrategy();
                    break;
                case MatchStrategyEnum.GovernmentInfo:
                    Matcher = new GovernmentInfoMatchStrategy();
                    break;
                default:
                    Matcher = new FullNameMatchStrategy();
                    break;
            }
        }

        public void Import(string inputFileName)
        {
            personList = StorageStrategy.Import(inputFileName);
        }

        public string GetMatchesAsString()
        {
            string output = "";
            List<Match> matches = FindMatches();

            for(int i = 0; i < matches.Count; i++)
            {
                output += matches[i].ToString() + Environment.NewLine;
            }

            return output;
        }

        public List<Match> FindMatches()
        {
            int personCount = personList.Count;
            
            List<Match> matchList = new List<Match>();

            if (personCount == 0)
            {
                return matchList;
            }

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
