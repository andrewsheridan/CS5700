using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatcher.Matching
{
    public class GovernmentInfoMatchStrategy : MatchStrategy
    {
        public override bool Match(Person a, Person b)
        {
            if (String.IsNullOrWhiteSpace(a.StateFileNumber)
                || String.IsNullOrWhiteSpace(b.StateFileNumber)
                || String.IsNullOrWhiteSpace(a.SocialSecurityNumber)
                || String.IsNullOrWhiteSpace(b.SocialSecurityNumber))
            {
                return false;
            }
            else if (a.StateFileNumber == b.StateFileNumber && a.SocialSecurityNumber == b.SocialSecurityNumber)
            {
                return true;
            }
            else return false;
        }
    }
}
