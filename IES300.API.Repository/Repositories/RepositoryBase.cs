using IES300.API.Domain.Entities;
using IES300.API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES300.API.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly ApiDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(ApiDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T ObterPorId(int id, bool asNoTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (asNoTracking)
                query = query.AsNoTracking();

            return query.FirstOrDefault(x => x.Id == id);
        }

        public IList<T> ObterTodos()
        {
            return _dbSet.ToList();
        }

        public void Inserir(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Alterar(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public bool Deletar(int id)
        {
            var entity = ObterPorId(id);

            if(entity != null && entity.Ativado)
            {
                entity.Ativado = false;
                _dbSet.Update(entity);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
