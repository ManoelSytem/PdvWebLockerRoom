using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Models
{
    public class CupomNaoFiscalModel
    {
        public CupomNaoFiscalModel()
        {

        }
        public ClienteModel cliente { get; set; }
        public string codPedidoVenda { get; set; }
        public DateTime dataHora { get; set; }
        public List<ConsumoModel> consumoModel { get; set; }
        public string status { get; set; }
        public string desconto { get; set; }
        public string acrescimo { get; set; }
        public string formaDePagamento { get; set; }
    }

}
