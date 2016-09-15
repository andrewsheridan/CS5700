using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonMatcher.Matching;
using PersonMatcher.DataObjects;

namespace PersonMatcher.Matching.Tests
{
    [TestClass()]
    public class BirthInfoMatchStrategyTests
    {
        [TestMethod()]
        public void MatchTestWrongType()
        {
            MatchStrategy matcher = new BirthInfoMatchStrategy();

            Adult a = new Adult("", "", 1, "", "", "", "", "", 1993, 09, 15, "");
            Adult b = new Adult("", "", 2, "", "", "", "", "", 1993, 09, 15, "");
            Person c = new Person(3, "", "", "", "", "", 1993, 09, 15, "");
            Person d = new Person(4, "", "", "", "", "", 1993, 09, 15, "");
            
            Assert.IsFalse(matcher.Match(a, b));
            Assert.IsFalse(matcher.Match(c, d));
            Assert.IsFalse(matcher.Match(a, c));
        }
    }
}