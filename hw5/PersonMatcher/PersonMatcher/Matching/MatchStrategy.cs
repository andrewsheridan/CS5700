using PersonMatcher.DataObjects;

namespace PersonMatcher.Matching
{
    public interface MatchStrategy
    {
        bool Match(Person a, Person b);
    }
}
