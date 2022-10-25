using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace WebVolait.ViewModels
{
    public class CadastroClienteViewModel
    {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe seu nome")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string UsuNome { get; set; }

        [Required(ErrorMessage = "Informe seu login")]
        [MaxLength(50, ErrorMessage = "O login deve ter no máximo 50 caracteres")]
        [Remote("SelectLogin", "Autenticacao", ErrorMessage = "O login já existe!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [MaxLength(50, ErrorMessage = "A senha deve ter no máximo 50 caracteres")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirme a senha")]
        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage = "As senhas não são iguais")]
        public string ConfirmaSenha { get; set; }

    }
}