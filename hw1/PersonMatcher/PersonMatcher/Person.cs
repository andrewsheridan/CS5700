using System.Runtime.Serialization;

namespace PersonMatcher
{
    [DataContract]
    public class Person
    {
        [DataMember]
        private int ObjectId { get; set; }
        [DataMember]
        private string StateFileNumber { get; set; }
        [DataMember]
        private string SocialSecurityNumber { get; set; }
        [DataMember]
        private string FirstName { get; set; }
        [DataMember]
        private string MiddleName { get; set; }
        [DataMember]
        private string LastName { get; set; }
        [DataMember]
        private int BirthYear { get; set; }
        [DataMember]
        private int BirthMonth { get; set; }
        [DataMember]
        private int BirthDay { get; set; }
        [DataMember]
        private string Gender { get; set; }
    }
}
