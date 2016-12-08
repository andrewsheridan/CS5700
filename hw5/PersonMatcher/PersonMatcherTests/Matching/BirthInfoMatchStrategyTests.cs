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
            DataObjects.Person c = new DataObjects.Person(3, "", "", "", "", "", 1993, 09, 15, "");
            DataObjects.Person d = new DataObjects.Person(4, "", "", "", "", "", 1993, 09, 15, "");
            
            Assert.IsFalse(matcher.Match(a, b));
            Assert.IsFalse(matcher.Match(c, d));
            Assert.IsFalse(matcher.Match(a, c));
        }

        [TestMethod()]
        public void MatchTestSuccess()
        {
            MatchStrategy matcher = new BirthInfoMatchStrategy();

            Child a = new Child(12345, "F", 1, "Utah", "First", "Middle", "Last", 1, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");
            Child b = new Child(12345, "F", 1, "Utah", "First", "Middle", "Last", 2, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");

            Child c = new Child(54321, "T", 2, "Utah", "First", "Middle", "Last", 3, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");
            Child d = new Child(54321, "T", 2, "Utah", "First", "Middle", "Last", 4, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");

            Assert.IsTrue(matcher.Match(a, b));
            Assert.IsTrue(matcher.Match(c, d));
        }

        [TestMethod()]
        public void MatchTestFailure()
        {
            MatchStrategy matcher = new BirthInfoMatchStrategy();
            //Different newborn screening numbers
            Child a = new Child(05948, "F", 1, "Utah", "First", "Middle", "Last", 1, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");
            Child b = new Child(12345, "F", 1, "Utah", "First", "Middle", "Last", 2, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");
            //Different birth orders
            Child c = new Child(54321, "T", 2, "Utah", "First", "Middle", "Last", 3, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");
            Child d = new Child(54321, "T", 1, "Utah", "First", "Middle", "Last", 4, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");

            Assert.IsFalse(matcher.Match(a, b));
            Assert.IsFalse(matcher.Match(c, d));
        }
    }
}