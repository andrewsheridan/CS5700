using PersonMatcher.DataObjects;

namespace PersonMatcher.Matching
{
    public interface MatchStrategy
    {
        bool Match(DataObjects.Person a, DataObjects.Person b);
    }
}
