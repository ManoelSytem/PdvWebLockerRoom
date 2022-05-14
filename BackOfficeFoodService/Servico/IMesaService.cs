using BackOfficeFoodService.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Servico
{
    public interface IMesaService
    {
        [Post("/Mesa/Create")]
        Task<ActionResultado> Post(MesaModel mesaModel);
        [Post("/Mesa/AbrirMesa")]
        Task<ActionResultado> AbrirMesa(int codMesa, int numeroMesa);
        [Post("/Mesa/FechamentoMesa")]
        Task<ActionResultado> FechamentoMesa(int codMesa, string seqAbreMesa, decimal totalFechamento);
        [Post("/Mesa/AdicionaConsumoMesa")]
        Task<ActionResultado> AdicionaConsumoMesa(ConsumoModel ConsumoModel);
        [Get("/Mesa/ObterListaMesa")]
        Task<List<MesaModel>> ObterListaMesa();
        [Get("/Mesa/ObterConsumoDaMesa")]
        Task<List<ConsumoModel>> ObterConsumoDaMesa(string seqAbreMesa, bool EcupomFiscal);
        [Delete("/Mesa/DeleteProdutoConsumoMesa")]
        Task<ActionResultado> DeleteProdutoConsumoMesa(string codigoItemConsumo, int codMesa);

    }
}
