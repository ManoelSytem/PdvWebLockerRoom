using BackOfficeFoodService.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeFoodService.Servico
{
    public interface IClienteServico
    {
        [Post("/Cliente/Create")]
        Task<ActionResultado> Post(ClienteModel clienteModel);
        [Get("/Cliente/ObterClientePorEmail")]
        Task<ClienteModel> ObterClientePorEmail(string email);
        [Get("/Cliente/ObterListaDeCliente")]
        Task<List<ClienteModel>> ObterListaDeCliente();
        [Get("/Cliente/ObterClientePorIdUser")]
        Task<ClienteModel> ObterClientePorIdUser(int IdUser);
        [Put("/Cliente/PutCliente")]
        Task<ActionResultado> AtualizarCliente(ClienteModel clienteModel);
    
    }
}
