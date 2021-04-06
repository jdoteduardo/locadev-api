using Locadora.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Infra.Interfaces
{
    public interface IBaseRepository<T> where T: Base
    {
        Task<T> Criar(T obj);
        Task<T> Atualizar(T obj);
        Task Excluir(long id);
        Task<T> ObterPorId(long id);
        Task<List<T>> ObterTodos();
    }
}
