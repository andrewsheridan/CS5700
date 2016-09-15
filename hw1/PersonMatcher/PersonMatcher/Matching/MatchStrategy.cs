using PersonMatcher.DataObjects;

namespace PersonMatcher.Matching
{
    public abstract class MatchStrategy
    {
        public abstract bool Match(Person a, Person b);
    }
}
