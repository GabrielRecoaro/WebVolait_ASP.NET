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

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "CPF do cliente", AutoGenerateFilter = false)]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "O CPF digitado é inválido")]
        public string CPFCliente { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Nome Completo", AutoGenerateFilter = false)]
        public string NomeCliente { get; set; }

        [Display(Name = "Nome Social (caso tenha)")]
        [MaxLength(50)]
        public string NomeSocialCliente { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "*E-mail em formato inválido.")]
        public string LoginCliente { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "Número de Telefone")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "O número de telefone digitado é inválido")]
        public string TelefoneCliente { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        public string SenhaCliente { get; set; }
       
        [Display(Name = "Confirme sua senha")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [Compare(nameof(SenhaCliente), ErrorMessage = "As senhas não coincidem")]
        public string ConfirmaSenhaCliente { get; set; }

    }
}
