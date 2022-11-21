using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.Models
{
    public class Contato
    {

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Email para contato")]
        [MaxLength(15, ErrorMessage = "Tem demais")]
        public string Email { get; set; }

        [Display(Name = "Mensagem")]
        public string Mensagem { get; set; }

    }
}