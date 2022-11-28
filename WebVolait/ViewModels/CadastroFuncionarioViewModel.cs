using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.ViewModels
{
    public class CadastroFuncionarioViewModel
    {
        [Display(Name = "CPF do Funcionário")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "O CPF digitado é inválido")]
        public string CPFFuncionario { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Nome Completo", AutoGenerateFilter = false)]
        public string NomeFuncionario { get; set; }

        [Display(Name = "Nome Social")]
        [MaxLength(50)]
        public string NomeSocialFuncionario { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string LoginFuncionario { get; set; }

        [Display(Name = "Número de Telefone")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "O número de telefone digitado é inválido")]
        public string TelefoneFuncionario { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        public string SenhaFuncionario { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua senha")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Compare(nameof(SenhaFuncionario), ErrorMessage = "As senhas não coincidem")]
        public string ConfirmaSenhaFuncionario { get; set; }

    }
}
