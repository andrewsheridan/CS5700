using System;
using PersonMatcher.DataObjects;

namespace PersonMatcher.Matching
{
    public class ContactInfoMatchStrategy : MatchStrategy
    {
        public bool Match(Person a, Person b)
        {
            if(a.GetType() == typeof(Adult) && b.GetType() == typeof(Adult))
            {
                return Match(a as Adult, b as Adult);
            }
            return false;
        }
        
        private bool Match(Adult a, Adult b)
        {
            if ((String.IsNullOrWhiteSpace(a.Phone1) && String.IsNullOrWhiteSpace(a.Phone2)) || (String.IsNullOrWhiteSpace(b.Phone1) && String.IsNullOrWhiteSpace(b.Phone2)))
                return false;
            else if ((!String.IsNullOrEmpty(a.Phone1) && !String.IsNullOrEmpty(b.Phone1)) && (a.Phone1 == b.Phone1))
                return true;
            else if ((!String.IsNullOrEmpty(a.Phone1) && !String.IsNullOrEmpty(b.Phone2)) && (a.Phone1 == b.Phone2))
                return true;
            else if ((!String.IsNullOrEmpty(a.Phone2) && !String.IsNullOrEmpty(b.Phone1)) && (a.Phone2 == b.Phone1))
                return true;
            else if ((!String.IsNullOrEmpty(a.Phone2) && !String.IsNullOrEmpty(b.Phone2)) && (a.Phone2 == b.Phone2))
                return true;
            else return false;
        }
    }
}
