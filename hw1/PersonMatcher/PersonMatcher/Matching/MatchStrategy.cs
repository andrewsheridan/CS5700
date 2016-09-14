using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatcher.Matching
{
    public abstract class MatchStrategy
    {
        public abstract bool Match(Person a, Person b);
    }
}
