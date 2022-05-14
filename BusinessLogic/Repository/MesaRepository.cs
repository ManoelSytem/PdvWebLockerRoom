using Aplication.Interface;
using Dominio;
using InfraEstrutura;
using InfraEstrutura.Interface;
using InfraEstrutura.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Aplication.Repository
{
    public class MesaRepository 
    {
        RepositoryGeneric<Mesa> _repositoryGeneric;
        AplicationDbContext _context;
        public MesaRepository()
        {
            _context = new AplicationDbContext();
            _repositoryGeneric = new RepositoryGeneric<Mesa>(_context);
        }

        public void Add(Mesa mesa)
        {
            _repositoryGeneric.Add(mesa);
        }

        public IEnumerable<Mesa> GetAll()
        {
           return _repositoryGeneric.Get();
        }

        public Mesa GetbyId(int codMesa)
        {
            return _repositoryGeneric.GetById(m => m.codigo == codMesa);
        }
        public string ObterUltimaSeqAbreMesa(int codMesa, int numeroMesa)
        {
            string maxSeqAbreMesa = _context.Mesa.Max(u => u.seqAbreMesa);
            if(!string.IsNullOrEmpty(maxSeqAbreMesa))
              return  maxSeqAbreMesa = Convert.ToString(Convert.ToInt32(maxSeqAbreMesa) + 1);
            return Convert.ToString(codMesa+ numeroMesa);
        }

        public void edit(Mesa mesa)
        {
            _repositoryGeneric.Update(mesa);
        }

        public void update(Mesa mesa)
        {
            _context.Mesa.Update(mesa).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
