using InfraEstrutura.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InfraEstrutura.Repository
{
    public class RepositoryGeneric<T> : IRepository<T> where T : class
    {
        private readonly AplicationDbContext _context;
        public RepositoryGeneric(AplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
           return _context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Single(predicate);
        }

        public T GetByIdFind(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

    }

}
