using ContactManager.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Models.Contact
{
    public class Supplier
    {
        public Person Person { get; set; }
        public string Telephone { get; set; }

    }
}