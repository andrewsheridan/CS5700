using System;
using PersonMatcher.DataObjects;

namespace PersonMatcher.Matching
{
    class FullNameMatchStrategy : MatchStrategy
    {
        public bool Match(Person a, Person b)
        {
            if (String.IsNullOrWhiteSpace(a.FirstName)
                || String.IsNullOrWhiteSpace(b.FirstName)
                || String.IsNullOrWhiteSpace(a.MiddleName)
                || String.IsNullOrWhiteSpace(b.MiddleName)
                || String.IsNullOrWhiteSpace(a.LastName)
                || String.IsNullOrWhiteSpace(b.LastName))
            {
                return false;
            }
            else if (a.FirstName.ToLower() == b.FirstName.ToLower()
                && a.MiddleName.ToLower() == b.MiddleName.ToLower()
                && a.LastName.ToLower() == b.LastName.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
