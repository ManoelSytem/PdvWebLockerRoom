using Dominio;
using InfraEstrutura.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interface
{
    interface IClienteRepository : IRepository<Cliente>
    {
        IEnumerable<Cliente> GetClientesPorNome();
    }
}
