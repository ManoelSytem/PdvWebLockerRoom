using BackOfficeFoodService.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Servico
{
    public interface ICaixaService
    {
        [Get("/Caixa/ObterListaFormaPagamento")]
        Task<List<FormaPagamentoModel>> ObterListaPagamento();
        [Get("/Caixa/ObterContaPendente")]
        Task<ContaModel> ObterContaPendente(string seqAbreMesa);
        [Post("/Caixa/BaixaConta")]
        Task<ActionResultado> BaixaConta(decimal valorEntrada, string formaPgto, int codigoConta);
    }
}
