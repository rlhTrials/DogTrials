using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogTrials.Models
{
    public class EntryFee
    {
        public int ID { get; set; }

        public Stake Stake { get; set; }

        public Trial Trial { get; set; }

        public decimal Fee { get; set; }
    }
}
