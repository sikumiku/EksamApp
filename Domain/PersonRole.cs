using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PersonRole
    {
        public int PersonRoleId { get; set; }

        public string Name { get; set; }

        // collections
        public List<Person> Persons { get; set; }
    }
}
