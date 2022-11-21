using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebVolait.ViewModels
{
    public class LoginFuncionarioViewModel
    {
        public string urlRetorno { get; set; }

        [Required(ErrorMessage = "Informe o Login")]
        [MaxLength(50, ErrorMessage = "O Login deve ter até 50 caracteres")]
        public string LoginFuncionario { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [MinLength(6, ErrorMessage = "A Senha deve ter pelo menos 6 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


    }
}