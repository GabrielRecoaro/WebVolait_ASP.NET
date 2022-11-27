using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVolait.ViewModels
{
    public class CadastroCompraViewModel
    {

        [Display(Name = "Nota fiscal da compra")]
        public int NotaFiscal { get; set; }

        [Display(Name = "Nota fiscal da compra")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataCompra { get; set; }

        [Display(Name = "Valor total da compra")]
        public decimal ValorTotal { get; set; }

        [Display(Name = "CPF do cliente")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public long CPFCliente { get; set; }

        [Display(Name = "Cupom de desconto")]
        public string Cupom { get; set; }
        
        [Display(Name = "Tipo de pagamento")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string CodTipoPagto { get; set; }

        [Display(Name = "Quantidade de passagens")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public int QuantidadePassagem { get; set; }

        public int Passagem { get; set; }

    }
}
