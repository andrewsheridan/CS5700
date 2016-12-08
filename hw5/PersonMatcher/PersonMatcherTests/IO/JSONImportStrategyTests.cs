using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

using PersonMatcher.IO;
using PersonMatcher.DataObjects;

namespace PersonMatcher.IO.Tests
{
    [TestClass()]
    public class JSONImportExportStrategyTests
    {
        [TestMethod()]
        public void ImportAdultSuccess()
        {
            string[] lines = { "[{ \"__type\":\"Adult:#PersonMatcher.DataObjects\",\"BirthDay\":19,\"BirthMonth\":9,\"BirthYear\":1992,\"FirstName\":\"Jack\",\"Gender\":\"M\",\"LastName\":\"Isaacons\",\"MiddleName\":\"Michael\",\"ObjectId\":34,\"SocialSecurityNumber\":\"701678634\",\"StateFileNumber\":\"1992 61052\",\"Phone1\":\"385-801-4548\",\"Phone2\":null}]" };

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/JsonImportTestAdultSuccess.json", lines);

            JsonImportStrategy importer = new JsonImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/JsonImportTestAdultSuccess.json");
            Adult testPerson = personList[0] as Adult;

            Assert.AreEqual(34, testPerson.ObjectId);
            Assert.AreEqual("701678634", testPerson.SocialSecurityNumber);
            Assert.AreEqual("1992 61052", testPerson.StateFileNumber);
            Assert.AreEqual("Jack", testPerson.FirstName);
            Assert.AreEqual("Michael", testPerson.MiddleName);
            Assert.AreEqual("Isaacons", testPerson.LastName);
            Assert.AreEqual(1992, testPerson.BirthYear);
            Assert.AreEqual(9, testPerson.BirthMonth);
            Assert.AreEqual(19, testPerson.BirthDay);
            Assert.AreEqual("M", testPerson.Gender);
            Assert.AreEqual("385-801-4548", testPerson.Phone1);
            Assert.AreEqual(null, testPerson.Phone2);
        }

        [TestMethod()]
        public void ImportChildSuccess()
        {
            string[] lines = { "[{ \"__type\":\"Child:#PersonMatcher.DataObjects\",\"BirthDay\":17,\"BirthMonth\":4,\"BirthYear\":2006,\"FirstName\":\"Karl\",\"Gender\":\"M\",\"LastName\":\"Newton\",\"MiddleName\":\"A\",\"ObjectId\":40,\"SocialSecurityNumber\":\"163966807\",\"StateFileNumber\":\"2006 52946\",\"BirthCounty\":\"Carbon\",\"BirthOrder\":0,\"IsPartOfMultipleBirth\":\"F\",\"MotherFirstName\":\"Firstname\",\"MotherLastName\":\"Williamson\",\"MotherMiddleName\":\"Sue\",\"NewbornScreeningNumber\":192837}]" };
            File.WriteAllLines(Directory.GetCurrentDirectory() + "/JsonImportTestChildSuccess.json", lines);

            JsonImportStrategy importer = new JsonImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/JsonImportTestChildSuccess.json");
            Child testPerson = personList[0] as Child;

            Assert.AreEqual(40, testPerson.ObjectId);
            Assert.AreEqual("163966807", testPerson.SocialSecurityNumber);
            Assert.AreEqual("2006 52946", testPerson.StateFileNumber);
            Assert.AreEqual("Karl", testPerson.FirstName);
            Assert.AreEqual("A", testPerson.MiddleName);
            Assert.AreEqual("Newton", testPerson.LastName);
            Assert.AreEqual(2006, testPerson.BirthYear);
            Assert.AreEqual(4, testPerson.BirthMonth);
            Assert.AreEqual(17, testPerson.BirthDay);
            Assert.AreEqual("M", testPerson.Gender);
            Assert.AreEqual("F", testPerson.IsPartOfMultipleBirth);
            Assert.AreEqual(192837, testPerson.NewbornScreeningNumber);
            Assert.AreEqual(0, testPerson.BirthOrder);
            Assert.AreEqual("Carbon", testPerson.BirthCounty);
            Assert.AreEqual("Firstname", testPerson.MotherFirstName);
            Assert.AreEqual("Sue", testPerson.MotherMiddleName);
            Assert.AreEqual("Williamson", testPerson.MotherLastName);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.Runtime.Serialization.SerializationException))]
        public void IncorrectFormatting()
        {
            string[] lines = { "[{ \"__type\":\"Child:#PersonMatcher.DataObjects\",\"FirstName\":Karl, \"ObjectId\":40}]" };

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/JsonImportTestIncorrectFormatting.json", lines);

            JsonImportStrategy importer = new JsonImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/JsonImportTestIncorrectFormatting.json");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.Runtime.Serialization.SerializationException))]
        public void MissingObjectId()
        {
            string[] lines = { "[{ \"__type\":\"Child:#PersonMatcher.DataObjects\",\"FirstName\":\"Karl\"}]" };

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/JsonImportTestMissingObjectId.json", lines);

            JsonImportStrategy importer = new JsonImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/JsonImportTestMissingObjectId.json");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.Runtime.Serialization.SerializationException))]
        public void NotJson()
        {
            string[] lines = { "[{ \"__type\":\"Child:#PersonMatcher.DataObjects\",\"FirstName\":\"Karl\"}]" };

            File.WriteAllLines(Directory.GetCurrentDirectory() + "/JsonImportTest.xml", lines);

            JsonImportStrategy importer = new JsonImportStrategy();
            List<Person> personList = importer.Import(Directory.GetCurrentDirectory() + "/JsonImportTest.xml");
        }
    }
}