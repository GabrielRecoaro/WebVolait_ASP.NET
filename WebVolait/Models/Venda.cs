using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.Models
{
    public class Venda
    {
        public int NotaFiscal { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Data da Venda", AutoGenerateFilter = false)]
        public string DataVenda { get; set; }

    }
}