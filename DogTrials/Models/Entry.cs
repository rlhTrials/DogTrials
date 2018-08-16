using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogTrials.Models
{
    public class Entry
    {
        public int ID { get; set; }

        public Trial Trial { get; set; }

        public Dog Dog { get; set; }

        public Person Handler { get; set; }

        public Stake Stake { get; set; }

        public bool Paid { get; set; }
    }
}
