using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebVolait.ViewModels
{
    public class CadastroCompraViewModel
    {

        public int NotaFiscal { get; set; }

        public DateTime DataCompra { get; set; }

        public decimal ValorTotal { get; set; }

        public long CPFCliente { get; set; }

        public string Cupom { get; set; }

        public string CodTipoPagto { get; set; }

    }
}