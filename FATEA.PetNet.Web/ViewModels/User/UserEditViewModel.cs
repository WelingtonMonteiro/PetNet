using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FATEA.PetNet.Web.ViewModels.User
{
    public class UserEditViewModel
    {
        [DisplayName("Email")]
        [Required(ErrorMessage="O email do usuario é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "O email deve conter até 20 caracteres")]
        [MinLength(5, ErrorMessage = "O email deve conter no minimo 5 caracteres")]
        public string UserName { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "A senha do usuario é obrigatório")]
        [DataType(DataType.Password)]
        [MaxLength(14, ErrorMessage = "A senha deve conter no máximo 14 caracteres")]
        [MinLength(3, ErrorMessage = "A senha deve conter no minimo 6 caracteres")]
        public string Password { get; set; }

        [DisplayName("Perfil")]
        [Required(ErrorMessage = "O perfil do usuario é obrigatorio")]
        public string RoleId { get; set; }

    }
}