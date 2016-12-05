using PersonMatcher.IO;
using PersonMatcher.Matching;
using PersonMatcher.DataObjects;
using System.Collections.Generic;
using System;

namespace PersonMatcher
{
    public enum MatchStrategyEnum { AllStrategies, BirthInfo, ContactInfo, FullName, GovernmentInfo  };
    public enum ExportStrategyEnum { ID, AllInfo, FullName};
    public class PersonMatcher
    {
        private List<DataObjects.Person> personList;
        public ImportStrategy ReadStrategy { get; set; }
        public ExportStrategy WriteStrategy { get; set; }
        private string FileName { get; set; }
        
        public MatchStrategy Matcher { get; set; }

        public PersonMatcher(string filename, MatchStrategyEnum matchStrategy, ExportStrategyEnum exportStrategy)
        {
            FileName = filename;
            ReadStrategy = GetImportStrategy(filename);
            WriteStrategy = getExportStrategyByEnum(exportStrategy);
            Matcher = getMatchStrategyByEnum(matchStrategy);
            WriteStrategy = new IDFileExportStrategy();
        }

        public string Run()
        {
            personList = ReadStrategy.Import(FileName);
            List<Match> matches = FindMatches();
            return WriteStrategy.Export(FileName, matches, personList);
        }

        public MatchStrategy getMatchStrategyByEnum(MatchStrategyEnum strategy)
        {
            switch (strategy)
            {
                case MatchStrategyEnum.BirthInfo:
                    return new BirthInfoMatchStrategy();
                case MatchStrategyEnum.ContactInfo:
                    return new ContactInfoMatchStrategy();
                case MatchStrategyEnum.FullName:
                    return new FullNameMatchStrategy();
                case MatchStrategyEnum.GovernmentInfo:
                    return new GovernmentInfoMatchStrategy();
                case MatchStrategyEnum.AllStrategies:
                    return new AllMatchStrategy();
                default:
                    return new FullNameMatchStrategy();
            }
        }

        public ExportStrategy getExportStrategyByEnum(ExportStrategyEnum strategy)
        {
            switch (strategy)
            {
                case ExportStrategyEnum.ID:
                    return new IDFileExportStrategy();
                case ExportStrategyEnum.AllInfo:
                    throw new NotImplementedException();
                case ExportStrategyEnum.FullName:
                    throw new NotImplementedException();
                default:
                    return new IDFileExportStrategy();
            }
        }

        public ImportStrategy GetImportStrategy(string inputFileName)
        {
            if (inputFileName.Contains(".xml"))
            {
                return new XmlImportStrategy();
            }
            else if (inputFileName.Contains(".json"))
            {
                return new JsonImportStrategy();
            } else
            {
                //Todo: Make it fail in this case
                return null;
            }
        }

        public List<Matching.Match> FindMatches()
        {   
            int personCount = personList.Count;

            List<Matching.Match> matchList = new List<Matching.Match>();

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
                        matchList.Add(new Matching.Match(personList[i].ObjectId, personList[j].ObjectId));
                    }
                }
            }

            return matchList;
        }
    }
}
