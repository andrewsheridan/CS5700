﻿using System.Runtime.Serialization;

namespace PersonMatcher
{
    [DataContract]
    public class Child : Person
    {
        [DataMember]
        public string NewbornScreeningNumber { get; set; }

        [DataMember]
        public bool IsPartOfMultipleBirth { get; set; }

        [DataMember]
        public int BirthOrder { get; set; }

        [DataMember]
        public string BirthCountry { get; set; }

        [DataMember]
        public string MotherFirstName { get; set; }

        [DataMember]
        public string MotherMiddleName { get; set; }

        [DataMember]
        public string MotherLastName { get; set; }
       

    }
}
