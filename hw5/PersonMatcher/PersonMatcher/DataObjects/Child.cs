using System.Runtime.Serialization;

namespace PersonMatcher.DataObjects
{
    [DataContract]
    public class Child : Person
    {
        [DataMember]
        public int NewbornScreeningNumber { get; set; }

        [DataMember]
        public string IsPartOfMultipleBirth { get; set; }

        [DataMember]
        public int BirthOrder { get; set; }

        [DataMember]
        public string BirthCounty { get; set; }

        [DataMember]
        public string MotherFirstName { get; set; }

        [DataMember]
        public string MotherMiddleName { get; set; }

        [DataMember]
        public string MotherLastName { get; set; }
       
        public Child(int newbornScreeningNumber, string isPartOfMultipleBirth, int birthOrder, string birthCountry
            , string motherFirstName, string motherMiddleName, string motherLastName, int objectId, string stateFileNumber
            , string socialSecurityNumber, string firstName, string middleName, string lastName, int birthYear, int birthMonth
            , int birthDay, string gender)
            :base(new Person(objectId, stateFileNumber, socialSecurityNumber, firstName, middleName, lastName, birthYear, birthMonth, birthDay, gender))
        {
            NewbornScreeningNumber = newbornScreeningNumber;
            IsPartOfMultipleBirth = isPartOfMultipleBirth;
            BirthOrder = birthOrder;
            BirthCounty = birthCountry;
            MotherFirstName = motherFirstName;
            MotherMiddleName = motherMiddleName;
            MotherLastName = MotherLastName;
        }

        public Child() { }
    }
}
