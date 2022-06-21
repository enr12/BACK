using IES300.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES300.API.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        T ObterPorId(int id, bool asNoTracking = true);
        IList<T> ObterTodos();
        void Inserir(T entity);
        void Alterar(T entity);
        bool Deletar(int id);
    }
}
