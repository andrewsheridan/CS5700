using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

using PersonMatcher.IO;
using PersonMatcher.DataObjects;

namespace PersonMatcher.IO.Tests
{
    [TestClass()]
    public class XmlImportExportStrategyTests
    {
        [TestMethod()]
        public void ImportTest()
        {
            string[] lines = { "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                ,"<ArrayOfPerson xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">"
                ,"<Person xsi:type=\"Adult\">"
                ,"<ObjectId>124</ObjectId>"
                ,"<StateFileNumber>1995 01598</StateFileNumber>"
                ,"<SocialSecurityNumber>614485273</SocialSecurityNumber>"
                ,"<FirstName>Jane</FirstName>"
                ,"<MiddleName>Mary</MiddleName>"
                ,"<LastName>Davis</LastName>"
                ,"<BirthYear>1995</BirthYear>"
                ,"<BirthMonth>3</BirthMonth>"
                ,"<BirthDay>7</BirthDay>"
                ,"<Gender>F</Gender>"
                ,"<Phone1>435-700-8142</Phone1>"
                ,"<Phone2>828-1786</Phone2>"
                ,"</Person>"
                ,"</ArrayOfPerson>"
             };

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/XmlImportTest.xml", lines);

            XmlImportStrategy importer = new XmlImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/XmlImportTest.xml");
            Adult testPerson = personList[0] as Adult;

            Assert.AreEqual(124, testPerson.ObjectId);
            Assert.AreEqual("614485273", testPerson.SocialSecurityNumber);
            Assert.AreEqual("1995 01598", testPerson.StateFileNumber);
            Assert.AreEqual("Jane", testPerson.FirstName);
            Assert.AreEqual("Mary", testPerson.MiddleName);
            Assert.AreEqual("Davis", testPerson.LastName);
            Assert.AreEqual(1995, testPerson.BirthYear);
            Assert.AreEqual(3, testPerson.BirthMonth);
            Assert.AreEqual(7, testPerson.BirthDay);
            Assert.AreEqual("F", testPerson.Gender);
            Assert.AreEqual("435-700-8142", testPerson.Phone1);
            Assert.AreEqual("828-1786", testPerson.Phone2);
        }
    }
}