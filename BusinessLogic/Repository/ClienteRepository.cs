using BusinessLogic.Interface;
using Dominio;
using InfraEstrutura;
using InfraEstrutura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Repository
{
    public class ClienteRepository : IRepository<Cliente>, IClienteRepository
    {
        AplicationDbContext _context;
        public ClienteRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Cliente entity)
        {
            _context.Cliente.Add(entity);
        }
        public void Delete(Cliente entity)
        {
            _context.Cliente.Remove(entity);
        }
        public IEnumerable<Cliente> Get()
        {
            return _context.Cliente.ToList();
        }
        public void Update(Cliente entity)
        {
            _context.Cliente.Update(entity);
        }
        public IEnumerable<Cliente> GetClientesPorNome()
        {
            return Get().OrderBy(c => c.nome).ToList();
        }

        public IEnumerable<Cliente> Get(Expression<Func<Cliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(Expression<Func<Cliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Cliente GetByIdFind(Expression<Func<Cliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
