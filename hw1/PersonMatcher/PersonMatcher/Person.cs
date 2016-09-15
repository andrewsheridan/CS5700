using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PersonMatcher
{
    [DataContract]
    public class Person
    {
        [DataMember, XmlElement(DataType = "ObjectId")]
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
    }
}
