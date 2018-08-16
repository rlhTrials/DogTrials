using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogTrials.Models
{
    public class Dog
    {
        public int ID { get; set; }

        public string RegisteredName { get; set; }

        public string CallName { get; set; }

        public Sex Sex { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public string RegistrationNumber { get; set; }

        public Breed Breed { get; set; }

        public int OwnerID { get; set; }

        public Person Owner { get; set; }
    }
}
