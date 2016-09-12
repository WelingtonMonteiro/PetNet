using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.PetNet.Domain
{
    public class Animal
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public string Color { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsCastrated { get; set; }

        public GenderEnum Gender { get; set; }

    }
}
