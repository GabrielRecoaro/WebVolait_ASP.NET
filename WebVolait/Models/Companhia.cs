using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.Models
{
    public class Companhia
    {

        public int CNPJCompanhia { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Companhia Aérea", AutoGenerateFilter = false)]
        public string NomeCompanhia { get; set; }
    }
}
