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
        public void Success()
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

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/XmlImportTestSuccess.xml", lines);

            XmlImportStrategy importer = new XmlImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/XmlImportTestSuccess.xml");
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

        [TestMethod()]
        public void SuccessChild()
        {
            string[] lines = { "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                ,"<ArrayOfPerson xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">"
                ,"<Person xsi:type=\"Child\">"
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
                ,"<NewbornScreeningNumber>192837</NewbornScreeningNumber>"
                ,"<IsPartOfMultipleBirth>F</IsPartOfMultipleBirth>"
                ,"<BirthOrder>0</BirthOrder>"
                ,"<BirthCounty>Washington</BirthCounty>"
                ,"<MotherFirstName>Firstname</MotherFirstName>"
                ,"<MotherMiddleName>Hildaguard</MotherMiddleName>"
                ,"<MotherLastName>Lastname</MotherLastName>"
                ,"</Person>"
                ,"</ArrayOfPerson>"
             };

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/XmlImportTestSuccessChild.xml", lines);

            XmlImportStrategy importer = new XmlImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/XmlImportTestSuccessChild.xml");
            Child testPerson = personList[0] as Child;

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
            Assert.AreEqual("F", testPerson.IsPartOfMultipleBirth);
            Assert.AreEqual(192837, testPerson.NewbornScreeningNumber);
            Assert.AreEqual(0, testPerson.BirthOrder);
            Assert.AreEqual("Washington", testPerson.BirthCounty);
            Assert.AreEqual("Firstname", testPerson.MotherFirstName);
            Assert.AreEqual("Hildaguard", testPerson.MotherMiddleName);
            Assert.AreEqual("Lastname", testPerson.MotherLastName);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void NoXMLNS()
        {
            
            string[] lines = { "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                ,"<ArrayOfPerson>"
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

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/XmlImportTestNoXmlns.xml", lines);

            XmlImportStrategy importer = new XmlImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/XmlImportTestNoXmlns.xml");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.Runtime.Serialization.SerializationException))]
        public void MissingObjectID()
        {
            string[] lines = { "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                ,"<ArrayOfPerson xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">"
                ,"<Person xsi:type=\"Adult\">"
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

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/XmlImportTestMissingObjectId.xml", lines);

            XmlImportStrategy importer = new XmlImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/XmlImportTestMissingObjectId.xml");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.Runtime.Serialization.SerializationException))]
        public void NoXmlVersion()
        {
            string[] lines = { 
                "<ArrayOfPerson xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">"
                ,"<Person xsi:type=\"Adult\">"
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

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/XmlImportTestNoXmlVersion.xml", lines);

            XmlImportStrategy importer = new XmlImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/XmlImportTestNoXmlVersion.xml");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.Runtime.Serialization.SerializationException))]
        public void NotXml()
        {
            string[] lines = {
                "{",
                    "\"__type\":\"Adult:#PersonMatcher.DataObjects\"",
                    "\"BirthDay\":27",
                    "\"BirthMonth\":12",
                    "\"BirthYear\":1981",
                    "\"FirstName\":\"Edward\"",
                    "\"Gender\": \"M\"",
                    "\"LastName\":\"Johnson\"",
                    "\"MiddleName\":\"Karl\"",
                    "\"ObjectId\":33",
                    "\"SocialSecurityNumber\":\"701678634\"",
                    "\"StateFileNumber\":\"1981 19210\"",
                    "\"Phone1\":\"801-206-2175\"",
                    "\"Phone2\":null",
                "}"
            };

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/XmlImportFailure.json", lines);

            XmlImportStrategy importer = new XmlImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/XmlImportFailure.json");
        }

    }
}