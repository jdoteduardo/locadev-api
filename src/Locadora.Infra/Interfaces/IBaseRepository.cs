using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Locadora.Infra.Interfaces
{
    public interface IBaseRepository<T> where T: Base
    {
        Task<T> Criar(T obj);
        Task<T> Atualizar(T obj);
        Task<T> ObterPorId(long id);
        Task<List<T>> ObterTodos();
    }
}
