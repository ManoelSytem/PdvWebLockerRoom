using Aplication.Interface;
using Dominio;
using InfraEstrutura;
using InfraEstrutura.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Aplication.Repository
{
    public class ProdutoRepository : IRepository<Produto>, IProduto
    {
        AplicationDbContext _context;
        public ProdutoRepository()
        {
            _context = new  AplicationDbContext();
        }

        public void Add(Produto entity)
        {
            _context.Produto.Add(entity);
        }
        public Produto GetById(int codigoProduto)
        {
            return _context.Produto.Where(p => p.codigo == codigoProduto).OrderBy(c => c.codigo).Single();
        }

        public void DeleteProdutoPorCliente(int codProduto, string cliente)
        {
            (from prod in _context.Produto
             where prod.codigo == codProduto && prod.cliente == cliente && prod.delete != "1"
             select prod).ToList().ForEach(x => x.delete = "1");
            _context.SaveChanges();
        }

        public void AtualizarProduto(int codProduto, Produto produto)
        {
            var prod = GetById(codProduto);
            prod.nome = produto.nome;
            prod.descricao = produto.descricao;
            prod.valor = produto.valor;
            prod.update = "1";
            _context.Update(prod).State = EntityState.Modified;
            _context.SaveChanges();
        }

        
        public void Delete(Produto entity)
        {
            throw new NotImplementedException();
        }
      
        public IEnumerable<Produto> Get()
        {
            throw new NotImplementedException();
        }
        public void Update(Produto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Get(Expression<Func<Produto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Produto GetById(Expression<Func<Produto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Produto GetByIdFind(Expression<Func<Produto, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
