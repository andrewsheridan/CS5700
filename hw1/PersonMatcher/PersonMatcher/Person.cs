using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonMatcher
{
    abstract class Person
    {
        private int ObjectId { get; set; }
        private string StateFileNumber { get; set; }
        private string SocialSecurityNumber { get; set; }
        private string FirstName { get; set; }
        private string MiddleName { get; set; }
        private string LastName { get; set; }
        private int BirthYear { get; set; }
        private int BirthMonth { get; set; }
        private int BirthDay { get; set; }
        private string Gender { get; set; }
    }
}
