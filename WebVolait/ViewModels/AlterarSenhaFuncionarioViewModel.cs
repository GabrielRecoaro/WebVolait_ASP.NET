using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.ViewModels
{
    public class AlterarSenhaFuncionarioViewModel
    {
        [Display(Name = "Senha Atual")]
        [Required(ErrorMessage = "Informe a senha atual")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        [DataType(DataType.Password)]
        public string SenhaAtual { get; set; }

        [Display(Name = "Nova Senha")]
        [Required(ErrorMessage = "Informe a nova senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        [DataType(DataType.Password)]
        public string NovaSenha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "Confirme a senha")]
        [DataType(DataType.Password)]
        [Compare(nameof(NovaSenha), ErrorMessage = "As senha são diferentess")]
        public string ConfirmarSenha { get; set; }

    }
}