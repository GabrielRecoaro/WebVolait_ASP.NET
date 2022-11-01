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
        [MaxLength(100)]
        [Display(Name = "Nome", AutoGenerateFilter = false)]
        public string NomeCliente { get; set; }

        [Display(Name = "Nome Social")]
        [MaxLength(50)]
        public string NomeSocialCliente { get; set; }

        [Display(Name = "E-mail")]
        public string EmailCliente { get; set; }

        [Display(Name = "Número de Telefone")]
        public string TelefoneCliente { get; set; }

        [Display(Name = "Endereço")]
        public string EnderecoCliente { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(50)]
        public string LoginCliente { get; set; }

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