using ContactManager.Models.Common;
using System;

namespace ContactManager.Models.Contact
{
    
    public class Customer
    {
        public Person Person { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Email { get; set; }
    }
}