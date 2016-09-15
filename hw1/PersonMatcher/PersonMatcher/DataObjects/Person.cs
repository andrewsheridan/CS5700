using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PersonMatcher.DataObjects
{
    [DataContract, XmlType("Person")]
    public class Person
    {
        [DataMember]
        public int ObjectId { get; set; }
        [DataMember]
        public string StateFileNumber { get; set; }
        [DataMember]
        public string SocialSecurityNumber { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int BirthYear { get; set; }
        [DataMember]
        public int BirthMonth { get; set; }
        [DataMember]
        public int BirthDay { get; set; }
        [DataMember]
        public string Gender { get; set; }

        public Person(int objectId, string stateFileNumber, string socialSecurityNumber
            , string firstName, string middleName, string lastName, int birthYear, int birthMonth
            , int birthDay, string gender)
        {
            ObjectId = objectId;
            StateFileNumber = stateFileNumber;
            SocialSecurityNumber = socialSecurityNumber;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthYear = birthYear;
            BirthMonth = birthMonth;
            BirthDay = birthDay;
            Gender = gender;
        }

        public Person(Person person)
        {
            ObjectId = person.ObjectId;
            StateFileNumber = person.StateFileNumber;
            SocialSecurityNumber = person.SocialSecurityNumber;
            FirstName = person.FirstName;
            MiddleName = person.MiddleName;
            LastName = person.LastName;
            BirthYear = person.BirthYear;
            BirthMonth = person.BirthMonth;
            BirthDay = person.BirthDay;
            Gender = person.Gender;
        }

        public Person() { }
    }
}
