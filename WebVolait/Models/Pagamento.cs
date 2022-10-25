using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.Models
{
    public class Pagamento
    {

        public int IdTipoPgto { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Tipo de Pagamento", AutoGenerateFilter = false)]
        public string TipoPgto { get; set; }

    }
}