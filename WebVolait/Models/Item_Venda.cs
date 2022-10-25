using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.Models
{
    public class Item_Venda
    {
        public int IdItemVenda { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Quantidade de Item Venda", AutoGenerateFilter = false)]
        public string QtdeItemVenda { get; set; }


        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Valor Item Venda", AutoGenerateFilter = false)]
        public int ValorItemVenda { get; set; }
    }
}