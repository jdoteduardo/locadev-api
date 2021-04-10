using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> ObterPorNome(string nomeCompleto);
        Task<Cliente> ObterPorEmail(string email);
        Task<List<Cliente>> PesquisarPorEmail(string email);
        Task<List<Cliente>> Buscar(Expression<Func<Cliente, bool>> predicate);
    }
}
