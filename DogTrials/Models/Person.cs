using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogTrials.Models
{
    public class Person
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public Country Country { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public ICollection<Dog> Dogs { get; set; }
    }
}
