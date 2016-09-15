using System.Runtime.Serialization;

namespace PersonMatcher.DataObjects
{
    [DataContract]
    public class Adult : Person
    {
        [DataMember]
        public string Phone1 { get; set; }

        [DataMember]
        public string Phone2 { get; set; }

        public Adult(string phone1, string phone2, int objectId, string stateFileNumber, string socialSecurityNumber
            , string firstName, string middleName, string lastName, int birthYear, int birthMonth
            , int birthDay, string gender) 
            : base(new Person(objectId, stateFileNumber, socialSecurityNumber, firstName, middleName, lastName, birthYear, birthMonth, birthDay, gender))
        {
            Phone1 = phone1;
            Phone2 = phone2;
        }

        public Adult() { }
    }
}
