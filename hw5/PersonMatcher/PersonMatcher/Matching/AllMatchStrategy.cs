using System.Collections.Generic;
using PersonMatcher.DataObjects;

namespace PersonMatcher.Matching
{
    public class AllMatchStrategy : MatchStrategy
    {
        private List<MatchStrategy> matchList;

        public AllMatchStrategy()
        {
            matchList = new List<MatchStrategy>();
            matchList.Add(new BirthInfoMatchStrategy());
            matchList.Add(new ContactInfoMatchStrategy());
            matchList.Add(new FullNameMatchStrategy());
            matchList.Add(new GovernmentInfoMatchStrategy());
        }


        public bool Match(DataObjects.Person a, DataObjects.Person b)
        {
            for(int i = 0; i < matchList.Count; i++)
            {
                if(matchList[i].Match(a, b))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
