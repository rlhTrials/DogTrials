using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogTrials.Models
{
    public class Judge
    {
        public int ID { get; set; }

        public Stake Stake { get; set; }

        public Trial Trial { get; set; }

        public Person Person { get; set; }
    }
}
