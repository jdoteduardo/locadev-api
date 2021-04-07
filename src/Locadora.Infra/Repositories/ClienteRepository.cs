using Locadora.Domain.Entities;
using Locadora.Infra.Context;
using Locadora.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly LocadoraContext _context;

        public ClienteRepository(LocadoraContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> Buscar(Expression<Func<Cliente, bool>> predicate)
        {
            return await _context.Clientes
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }

        public virtual async Task Cancelar(long id)
        {
            var obj = await ObterPorId(id);

            if (obj != null)
            {
                var cliente = _context.Clientes.SingleOrDefault(x => x.Id == id);
                cliente.Ativo = false;
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<Cliente> ObterPorEmail(string email)
        {
            var emailCliente = await _context.Clientes
                                   .Where
                                   (
                                        x =>
                                            x.Email.ToLower() == email.ToLower()
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return emailCliente.FirstOrDefault();
        }

        public virtual async Task<Cliente> ObterPorNome(string nomeCompleto)
        {
            var nome = await _context.Clientes
                                   .Where
                                   (
                                        x =>
                                            x.NomeCompleto.ToLower() == nomeCompleto.ToLower()
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return nome.FirstOrDefault();
        }

        public virtual async Task<List<Cliente>> PesquisarPorEmail(string email)
        {
            var emails = await _context.Clientes
                                   .Where
                                   (
                                        x =>
                                            x.Email.ToLower().Contains(email.ToLower())
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return emails;
        }
    }
}
