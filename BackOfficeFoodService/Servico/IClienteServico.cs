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

    }
}
