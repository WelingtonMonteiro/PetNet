using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.PetNet.Web.ViewModels
{
    public class AnimalIndexViewModel
    {
        [DisplayName("Código")]
        public long Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Raça")]
        public string Breed { get; set; }

        [DisplayName("Idade")]
        public int Age { get; set; }

        [DisplayName("Cor")]
        public string Color { get; set; }

        [DisplayName("Data de Nascimento")]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Castrado")]
        public bool IsCastrated { get; set; }

        [DisplayName("Sexo")]
        public string Gender { get; set; }
    }
}