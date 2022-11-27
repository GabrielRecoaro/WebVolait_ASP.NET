using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebVolait.ViewModels
{
    public class CadastroCupomViewModel
    {

        [Display(Name = "Id do cupom")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public int CupomId { get; set; }

        [Display(Name = "Código do cupom")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Cupomcode { get; set; }

        [Display(Name = "Valor de desconto do cupom")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public decimal Valordesconto { get; set; }

        [Display(Name = "Data de validade do cupom")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime Cupomvalidade { get; set; }

        

    }
}
