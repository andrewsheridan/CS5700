using Microsoft.VisualStudio.TestTools.UnitTesting;

using PersonMatcher.DataObjects;

namespace PersonMatcher.Matching.Tests
{
    [TestClass()]
    public class ContactInfoMatchStrategyTests
    {
        [TestMethod()]
        public void MatchTestWrongType()
        {
            MatchStrategy matcher = new ContactInfoMatchStrategy();

            Person a = new Person(1, "", "", "", "", "", 1993, 09, 15, "");
            Person b = new Person(2, "", "", "", "", "", 1993, 09, 15, "");
            Child c = new Child("", "", 1, "", "", "", "", 3, "", "", "", "", "", 1993, 09, 15, "");
            Child d = new Child("", "", 1, "", "", "", "", 4, "", "", "", "", "", 1993, 09, 15, "");

            Assert.IsFalse(matcher.Match(a, b));
            Assert.IsFalse(matcher.Match(c, d));
            Assert.IsFalse(matcher.Match(a, c));
        }

        [TestMethod()]
        public void MatchTestSuccess()
        {
            MatchStrategy matcher = new ContactInfoMatchStrategy();

            Adult a = new Adult("801-555-5555", "", 1, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");
            Adult b = new Adult("", "801-555-5555", 2, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");

            Adult c = new Adult("801-666-6666", "", 3, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");
            Adult d = new Adult("801-666-6666", "", 4, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");

            Assert.IsTrue(matcher.Match(a, b));
            Assert.IsTrue(matcher.Match(c, d));
        }

        [TestMethod()]
        public void MatchTestFailure()
        {
            MatchStrategy matcher = new ContactInfoMatchStrategy();
            Adult a = new Adult("801-666-6666", "", 1, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");
            Adult b = new Adult("801-234-1353", "", 2, "file", "social", "Name", "Name2", "Name3", 1993, 9, 15, "M");

            Assert.IsFalse(matcher.Match(a, b));
        }
    }
}