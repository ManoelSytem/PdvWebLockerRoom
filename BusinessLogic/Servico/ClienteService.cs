using Aplication.Interface;
using Dominio;
using InfraEstrutura.Interface;
using InfraEstrutura.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Servico
{
    public class ClienteService : IClienteService,  IDisposable
    {
        UnitOfWork _uow;
        public ClienteService()
        {
            _uow = new UnitOfWork();
        }

        public IEnumerable<Cliente> Listar()
        {
            return _uow.ClienteRepository.Get();
        }
        public void Adicionar(Cliente cli)
        {
            _uow.ClienteRepository.Add(cli);
            _uow.Commit();
        }
        public void Excluir(Cliente cli)
        {
            _uow.ClienteRepository.Delete(cli);
            _uow.Commit();
        }
        public void Alterar(Cliente cli)
        {
            _uow.ClienteRepository.Update(cli);
            _uow.Commit();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public Cliente ObterClientePorEmail(string email)
        {
           return _uow.ClienteRepository.Get().Where(c => c.email == email).First();
        }
    }
}
