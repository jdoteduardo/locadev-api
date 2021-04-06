using Locadora.Domain.Entities;
using Locadora.Infra.Context;
using Locadora.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
