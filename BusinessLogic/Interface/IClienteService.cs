using Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Interface
{
    public interface IClienteService
    {
        public IEnumerable<Cliente> Listar();
        public void Adicionar(Cliente cli);
        public void Excluir(Cliente cli);
        public void Alterar(Cliente cli);
        public Cliente ObterClientePorEmail(string email);
    }
}
