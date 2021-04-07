using Locadora.Domain.Entities;
using Locadora.Infra.Context;
using Locadora.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual async Task Cancelar(long id)
        {
            var obj = await ObterPorId(id);

            if (obj != null)
            {
                var aluguel = _context.Alugueis.SingleOrDefault(x => x.Id == id);
                aluguel.Ativo = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
