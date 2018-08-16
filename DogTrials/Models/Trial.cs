using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogTrials.Models
{
    public class Trial
    {
        public int ID { get; set; }

        public int? ClubID { get; set; }

        public Club Club { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public bool IsActive { get; set; }

        ICollection<Stake> ActiveStakes { get; set; }

        ICollection<EntryFee> EntryFees { get; set; }

        ICollection<Judge> Judges { get; set; }
    }
}
