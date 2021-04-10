using Locadora.Core.Exceptions;
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
    public class AluguelRepository : BaseRepository<Aluguel>, IAluguelRepository
    {
        private readonly LocadoraContext _context;

        public AluguelRepository(LocadoraContext context) : base(context)
        {
            _context = context;
        }
    }
}
