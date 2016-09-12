using FATEA.PetNet.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.PetNet.Web.ViewModels
{
    public class AnimalEditViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public long Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength (50, ErrorMessage = "O nome deve ter no máximo 50 caracters.")]
        [MinLength(3, ErrorMessage = "O nome do animal deve ter no mínomo 3 caracteres")]
        public string Name { get; set; }

        [DisplayName("Raça")]
        [Required(ErrorMessage = "A raça é obrigatório.")]
        [MaxLength(20, ErrorMessage = "A raça deve ter no máximo 20 caracters.")]
        [MinLength(3, ErrorMessage = "A raça do animal deve ter no mínomo 3 caracteres")]
        public string Breed { get; set; }

        [DisplayName("Idade")]
        [Required(ErrorMessage = "A idade é obrigatório.")]
        public int Age { get; set; }

        [DisplayName("Cor")]
        [Required(ErrorMessage = "A cor é obrigatório.")]
        [MaxLength(25, ErrorMessage = "A cor deve ter no máximo 25 caracters.")]
        [MinLength(3, ErrorMessage = "A cor do animal deve ter no mínomo 3 caracteres")]
        public string Color { get; set; }

        [DisplayName("Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A data de nascimento é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Castrado")]
        [Required(ErrorMessage = "O estado da castração é obrigatório.")]
        public bool IsCastrated { get; set; }

        [DisplayName("Sexo")]
        [Required(ErrorMessage = "O sexo é obrigatório.")]
        public GenderEnum Gender { get; set; }
    }
}