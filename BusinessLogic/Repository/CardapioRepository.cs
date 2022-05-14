using Dominio;
using InfraEstrutura;
using InfraEstrutura.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Aplication.Repository
{
    public class CardapioRepository : IRepository<Cardapio>
    {
        AplicationDbContext _context;
        public CardapioRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Cardapio entity)
        {
            _context.Cardapio.Add(entity);
        }

        public void Delete(Cardapio entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cardapio> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cardapio> Get(Expression<Func<Cardapio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Cardapio GetById(Expression<Func<Cardapio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Cardapio GetByIdFind(Expression<Func<Cardapio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Cardapio entity)
        {
            throw new NotImplementedException();
        }
    }
}
